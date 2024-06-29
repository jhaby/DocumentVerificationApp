using CommunityToolkit.Mvvm.Messaging.Messages;

namespace BlockVerify.Models;

public class ResultCompletedMessage : ValueChangedMessage<string>
{
    public ResultCompletedMessage(string value) : base(value)
    {
    }
}
