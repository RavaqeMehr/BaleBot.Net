using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    // Commented because has server error
    [Obsolete("Throws Error: Bale Api not work correctly")]
    public static async Task<Message> SendAnimation(
        this BaleBotClient bot,
        string chatId,
        string fileIdOrUrl,
        string? caption = null,
        long? replyToMessageId = null,
        IReplyMarkup? replyMarkup = null
    ) =>
        await SendFile(
            bot,
            SendMethod.SendAnimation,
            chatId,
            fileIdOrUrl,
            caption,
            replyToMessageId,
            replyMarkup
        );

    [Obsolete("Throws Error: Bale Api not work correctly")]
    public static async Task<Message> SendAnimation(
        this BaleBotClient bot,
        long chatId,
        string fileIdOrUrl,
        string? caption = null,
        long? replyToMessageId = null,
        IReplyMarkup? replyMarkup = null
    ) =>
        await SendAnimation(
            bot,
            chatId.ToString(),
            fileIdOrUrl,
            caption,
            replyToMessageId,
            replyMarkup
        );

    public static async Task<Message> SendAnimation(
        this BaleBotClient bot,
        string chatId,
        FileInfo fileInfo,
        string? fileName = null,
        string? caption = null,
        long? replyToMessageId = null,
        IReplyMarkup? replyMarkup = null
    ) =>
        await SendFile(
            bot,
            SendMethod.SendAnimation,
            chatId,
            fileInfo,
            fileName,
            caption,
            replyToMessageId,
            replyMarkup
        );

    public static async Task<Message> SendAnimation(
        this BaleBotClient bot,
        long chatId,
        FileInfo fileInfo,
        string? fileName = null,
        string? caption = null,
        long? replyToMessageId = null,
        IReplyMarkup? replyMarkup = null
    ) =>
        await SendAnimation(
            bot,
            chatId.ToString(),
            fileInfo,
            fileName,
            caption,
            replyToMessageId,
            replyMarkup
        );
}
