using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<Message> SendDocument(
        this BaleBotClient bot,
        string chatId,
        string fileIdOrUrl,
        string? caption = null,
        long? replyToMessageId = null,
        IReplyMarkup? replyMarkup = null
    ) =>
        await SendFile(
            bot,
            SendMethod.SendDocument,
            chatId,
            fileIdOrUrl,
            caption,
            replyToMessageId,
            replyMarkup
        );

    public static async Task<Message> SendDocument(
        this BaleBotClient bot,
        long chatId,
        string fileIdOrUrl,
        string? caption = null,
        long? replyToMessageId = null,
        IReplyMarkup? replyMarkup = null
    ) =>
        await SendDocument(
            bot,
            chatId.ToString(),
            fileIdOrUrl,
            caption,
            replyToMessageId,
            replyMarkup
        );

    public static async Task<Message> SendDocument(
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
            SendMethod.SendAudio,
            chatId,
            fileInfo,
            fileName,
            caption,
            replyToMessageId,
            replyMarkup
        );

    public static async Task<Message> SendDocument(
        this BaleBotClient bot,
        long chatId,
        FileInfo fileInfo,
        string? fileName = null,
        string? caption = null,
        long? replyToMessageId = null,
        IReplyMarkup? replyMarkup = null
    ) =>
        await SendDocument(
            bot,
            chatId.ToString(),
            fileInfo,
            fileName,
            caption,
            replyToMessageId,
            replyMarkup
        );
}
