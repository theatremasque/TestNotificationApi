namespace TestNotification2.API.Jobs;

public class EmailProcessorJob
{
    public async Task ExecuteAsync(CancellationToken token)
    {
        // get notifications
        
        // db -> [key: email, value: [{ title, notificationId }]]
        
        // start fireAndForget job for each group formed by PersonId
        
        // foreach -> BacgroundJob.Enqueue(() => job.Execute([key: email, value: [{ title, notificationId }]]))
        
        throw new NotImplementedException();
    }
}