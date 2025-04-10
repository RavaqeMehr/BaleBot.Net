using BaleBot.Net.Methods;
using BaleBot.Net.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.DependencyInjection;

namespace BaleBot.Net
{
    public static class BaleBotClientExtentionMethods
    {
        public static IServiceCollection AddBaleBotClient(
            this IServiceCollection services,
            string token,
            int timeout = 60
        )
        {
            return services
                .AddSingleton(new BaleBotClient(token, timeout))
                .Configure<JsonOptions>(options =>
                {
                    options.SerializerOptions.PropertyNameCaseInsensitive = BaleBotClient
                        .jsonOption
                        .PropertyNameCaseInsensitive;

                    options.SerializerOptions.PropertyNamingPolicy = BaleBotClient
                        .jsonOption
                        .PropertyNamingPolicy;
                });
        }

        private static string SetWebhook(
            WebApplication app,
            string appBaseUrl,
            string webhookPrefix
        )
        {
            var bot = app.Services.GetRequiredService<BaleBotClient>();

            var salt = Guid.NewGuid().ToString().Replace("-", "");
            var webhookPath = $"{webhookPrefix}/{salt}";
            var webhookUrl = $"{appBaseUrl}{webhookPath}";

            Console.WriteLine($"Webhook URL: {webhookUrl}");
            Console.WriteLine($"Webhook Path: {webhookPath}");

            _ = bot.SetWebhook(webhookUrl).Result;

            return webhookPath;
        }

        public static WebApplication MapBaleBotWebhook(
            this WebApplication app,
            string appBaseUrl,
            Func<Message, Task> handleMessage,
            Func<Message, Task> handleEditedMessage,
            Func<CallbackQuery, Task> handleCallbackQuery,
            Func<PreCheckoutQuery, Task> handlePreCheckoutQuery,
            string webhookPrefix = "/webhooks/bale"
        )
        {
            var webhookPath = SetWebhook(app, appBaseUrl, webhookPrefix);

            app.MapPost(
                webhookPath,
                async (Update update) =>
                {
                    switch (update)
                    {
                        case { Message: { } message }:
                            await handleMessage(message);
                            break;
                        case { EditedMessage: { } editedMessage }:
                            await handleEditedMessage(editedMessage);
                            break;
                        case { CallbackQuery: { } callbackQuery }:
                            await handleCallbackQuery(callbackQuery);
                            break;
                        case { PreCheckoutQuery: { } preCheckoutQuery }:
                            await handlePreCheckoutQuery(preCheckoutQuery);
                            break;

                        default:
                            throw new NotImplementedException(
                                $"Update type {update.GetType()} not implemented."
                            );
                    }
                }
            );

            return app;
        }

        public static WebApplication MapBaleBotWebhook(
            this WebApplication app,
            string appBaseUrl,
            Func<Update, Task> handleUpdate,
            string webhookPrefix = "/webhooks/bale"
        )
        {
            var webhookPath = SetWebhook(app, appBaseUrl, webhookPrefix);

            app.MapPost(webhookPath, async (Update update) => await handleUpdate(update));

            return app;
        }
    }
}
