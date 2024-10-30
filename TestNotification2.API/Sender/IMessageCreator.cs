using MimeKit;

namespace TestNotification2.API.Sender;

public interface IMessageCreator
{
    public MimeMessage Create(string email, string subject, string[] titles);
}