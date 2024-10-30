namespace TestNotification2.API;
/// <summary>
/// define a model that will contain the data
/// of SMTP from appsettings.json
/// </summary>
public class SmtpSettings
{
    public string Server { get; set; }

    public int Port { get; set; }

    public string Email { get; set; }
    
    public string Password { get; set; }
}