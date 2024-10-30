using MediatR;

namespace TestNotification2.API.Notifications;

public record OnPublicationDisapprovedNotification(int PublicationId) : INotification;