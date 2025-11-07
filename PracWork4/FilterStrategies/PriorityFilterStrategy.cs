using PracWork4;

public class PriorityFilterStrategy : INotificationFilterStrategy
{
    public bool CanFilter(NotificationFilterOptions options) => options.MinPriority.HasValue;

    public IQueryable<Notification> Filter(IQueryable<Notification> query, NotificationFilterOptions options)
    {
        return query.Where(n => n.Priority >= options.MinPriority!.Value);
    }
}
