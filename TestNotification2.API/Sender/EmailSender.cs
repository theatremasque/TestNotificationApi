using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace TestNotification2.API.Sender;

public class EmailSender : IEmailSender
{
    private readonly SmtpSettings _settings;

    public EmailSender(IOptions<SmtpSettings> settings)
    {
        _settings = settings.Value;
    }

    public async Task SendAsync(MimeMessage message, CancellationToken cancellationToken)
    {
        using var client = new SmtpClient();
        try
        {
            await client.ConnectAsync(_settings.Server, _settings.Port, SecureSocketOptions.StartTls, cancellationToken);
            await client.AuthenticateAsync(_settings.Email, _settings.Password, cancellationToken);
            await client.SendAsync(message, cancellationToken);
        }
        catch (Exception e)
        {
            throw;
        }
        finally
        {
            await client.DisconnectAsync(true, cancellationToken);
        }
    }
}