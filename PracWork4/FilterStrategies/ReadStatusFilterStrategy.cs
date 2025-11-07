using PracWork4;
// Filter Strategies
public class ReadStatusFilterStrategy : INotificationFilterStrategy
{
    public bool CanFilter(NotificationFilterOptions options) => options.IsRead.HasValue;

    public IQueryable<Notification> Filter(IQueryable<Notification> query, NotificationFilterOptions options)
    {
        return query.Where(n => n.IsRead == options.IsRead!.Value);
    }
}
