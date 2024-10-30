using MimeKit;

namespace TestNotification2.API.Sender;

public interface IEmailSender
{
    Task SendAsync(MimeMessage message, CancellationToken cancellationToken);
}