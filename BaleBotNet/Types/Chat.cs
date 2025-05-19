using BaleBotNet.Enums;

namespace BaleBotNet.Types;

public class Chat
{
    public long Id { get; set; }
    public ChatType Type { get; set; }
    public string? Title { get; set; }
    public string? Username { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public ChatPhoto? Photo { get; set; }
    public string? InviteLink { get; set; }
}
