using PracWork4;

public class TitleSortStrategy : INotificationSortStrategy
{
    public bool CanSort(NotificationFilterOptions options) =>
        options.SortBy == SortNotificationBy.Title;

    public IOrderedQueryable<Notification> Sort(IQueryable<Notification> query, bool descending) =>
        descending ? query.OrderByDescending(n => n.Title) : query.OrderBy(n => n.Title);

    public IOrderedQueryable<Notification> ThenSort(IOrderedQueryable<Notification> query, bool descending) =>
        descending ? query.ThenByDescending(n => n.Title) : query.ThenBy(n => n.Title);
}
