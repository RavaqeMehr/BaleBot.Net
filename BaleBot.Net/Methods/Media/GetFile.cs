using System.Net.Http.Json;
using File = BaleBot.Net.Types.File;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<File> GetFile(this BaleBotClient bot, string fileId)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "getFile")
        {
            Content = JsonContent.Create(new { file_id = fileId })
        };

        return await bot.SendRequest<File>(request);
    }

    public static async Task<Stream?> Download(this BaleBotClient bot, string fileId)
    {
        return await bot.StreamDownloader(File.GetFileUrl(bot, fileId));
    }

    public static async Task<Stream?> Download(this BaleBotClient bot, File file)
    {
        if (file.FileUrl(bot) is string url)
        {
            return await bot.StreamDownloader(url);
        }

        return null;
    }

    public static async Task<bool> Download(
        this BaleBotClient bot,
        string fileId,
        FileStream fileStream
    )
    {
        if (await bot.Download(fileId) is Stream stream)
        {
            await stream.CopyToAsync(fileStream);

            return true;
        }

        return false;
    }

    public static async Task<bool> Download(
        this BaleBotClient bot,
        File file,
        FileStream fileStream
    )
    {
        if (file.FileUrl(bot) is string url)
        {
            await using var stream = await bot.StreamDownloader(url);

            if (stream != null)
            {
                await stream.CopyToAsync(fileStream);

                return true;
            }
        }

        return false;
    }

    public static async Task<bool> Download(this BaleBotClient bot, string fileId, string savePath)
    {
        await using var fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write);

        return await bot.Download(fileId, fileStream);
    }

    public static async Task<bool> Download(this BaleBotClient bot, File file, string savePath)
    {
        await using var fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write);

        return await bot.Download(file, fileStream);
    }
}
