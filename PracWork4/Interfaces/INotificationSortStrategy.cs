using PracWork4;

public interface INotificationSortStrategy
{
    bool CanSort(NotificationFilterOptions options);
    IOrderedQueryable<Notification> Sort(IQueryable<Notification> query, bool descending);
    IOrderedQueryable<Notification> ThenSort(IOrderedQueryable<Notification> query, bool descending);
}
