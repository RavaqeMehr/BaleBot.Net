namespace BaleBotNet.Types;

public class ReplyKeyboardMarkup : IReplyMarkup
{
    public KeyboardButton[][] Keyboard { get; set; } = default!;

    public override string ToString() => BaleBotClient.SerializeToJson(this)!;
}
