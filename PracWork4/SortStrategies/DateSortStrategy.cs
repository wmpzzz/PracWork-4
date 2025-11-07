using PracWork4;
// Sort Strategies
public class DateSortStrategy : INotificationSortStrategy
{
    public bool CanSort(NotificationFilterOptions options) =>
        options.SortBy == null || options.SortBy == SortNotificationBy.Date;

    public IOrderedQueryable<Notification> Sort(IQueryable<Notification> query, bool descending) =>
        descending ? query.OrderByDescending(n => n.CreatedAt) : query.OrderBy(n => n.CreatedAt);

    public IOrderedQueryable<Notification> ThenSort(IOrderedQueryable<Notification> query, bool descending) =>
        descending ? query.ThenByDescending(n => n.CreatedAt) : query.ThenBy(n => n.CreatedAt);
}
