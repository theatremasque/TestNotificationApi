using TestNotification2.API.Infrastructure;

namespace TestNotification2.API.Jobs;

public class SendEmailJob
{
    private readonly NotificationDbContext _ctx;

    public SendEmailJob(NotificationDbContext ctx)
    {
        _ctx = ctx;
    }
    
    public async Task ExecuteAsync(string email, (string, int)[] titleAndNotifications, CancellationToken token)
    {
        try
        {
            // set status to InProgress
            // ExecuteUpdate -> set status to In Progress
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        
        try
        {
            // create message
            // MessageCreator.Create(...)
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        try
        {
            // try send
            // EmailSender.Send(...)
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}