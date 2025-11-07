using PracWork4;

public interface INotificationFilterStrategy
{
    bool CanFilter(NotificationFilterOptions options);
    IQueryable<Notification> Filter(IQueryable<Notification> query, NotificationFilterOptions options);
}
