namespace TestNotification2.API.Entities;

public class PublicationNotification
{
    public int Id { get; set; }

    public int PublicationId { get; set; }

    public NotificationStatus Status { get; set; }
}

public enum NotificationStatus
{
    Queued = 0,
    InProgress = 1,
    Send = 2,
    Failed = 3
}