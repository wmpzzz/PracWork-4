using PracWork4;

public class TypeFilterStrategy : INotificationFilterStrategy
{
    public bool CanFilter(NotificationFilterOptions options) =>
        options.Types != null && options.Types.Length > 0;

    public IQueryable<Notification> Filter(IQueryable<Notification> query, NotificationFilterOptions options)
    {
        return query.Where(n => options.Types!.Contains(n.Type));
    }
}
