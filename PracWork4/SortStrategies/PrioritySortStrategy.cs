using PracWork4;

public class PrioritySortStrategy : INotificationSortStrategy
{
    public bool CanSort(NotificationFilterOptions options) =>
        options.SortBy == SortNotificationBy.Priority;

    public IOrderedQueryable<Notification> Sort(IQueryable<Notification> query, bool descending) =>
        descending ? query.OrderByDescending(n => n.Priority) : query.OrderBy(n => n.Priority);

    public IOrderedQueryable<Notification> ThenSort(IOrderedQueryable<Notification> query, bool descending) =>
        descending ? query.ThenByDescending(n => n.Priority) : query.ThenBy(n => n.Priority);
}
