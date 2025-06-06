using BaleBotNet.Enums;
using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static async Task<bool> SendChatAction(
        this BaleBotClient bot,
        ChatId chatId,
        ChatAction action
    ) =>
        await bot.SendRequest<bool>(
            BotRequest.CreateGet($"sendChatAction?chat_id={chatId}&action={action.Serialize()}")
        );
}
