using PracWork4;

public class SearchTextFilterStrategy : INotificationFilterStrategy
{
    public bool CanFilter(NotificationFilterOptions options) =>
        !string.IsNullOrWhiteSpace(options.SearchText);

    public IQueryable<Notification> Filter(IQueryable<Notification> query, NotificationFilterOptions options)
    {
        var searchText = options.SearchText!.Trim().ToLower();
        return query.Where(n =>
            n.Title.ToLower().Contains(searchText) ||
            (n.Content != null && n.Content.ToLower().Contains(searchText))
        );
    }
}
