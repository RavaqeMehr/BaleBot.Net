using System.Net.Http.Json;
using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<WebhookInfo> DeleteWebhook(this BaleBotClient bot) =>
        await bot.SetWebhook(string.Empty);
}
