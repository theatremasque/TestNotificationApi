using MediatR;
using Microsoft.EntityFrameworkCore;
using TestNotification2.API.Entities;
using TestNotification2.API.Infrastructure;
using TestNotification2.API.Notifications;

namespace TestNotification2.API.NotificationHandlers;

public class PublicationMessageHandler : INotificationHandler<OnPublicationDisapprovedNotification>
{
    private readonly NotificationDbContext _ctx;

    public PublicationMessageHandler(NotificationDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task Handle(OnPublicationDisapprovedNotification notification, CancellationToken cancellationToken)
    {
        var isInJob = await _ctx.PublicationNotifications
            .AnyAsync(n => 
                n.PublicationId == notification.PublicationId &&
                n.Status != NotificationStatus.Send,
                cancellationToken);
        
        if (!isInJob)
        {
            var entity = new PublicationNotification
            {
                PublicationId = notification.PublicationId,
                Status = NotificationStatus.Queued
            };
            
            _ctx.PublicationNotifications.Add(entity);

            await _ctx.SaveChangesAsync(cancellationToken);
        }
    }
}