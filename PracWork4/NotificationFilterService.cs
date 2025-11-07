using PracWork4;

// Main Service
public class NotificationFilterService
{
    private readonly IEnumerable<INotificationFilterStrategy> _filterStrategies;
    private readonly IEnumerable<INotificationSortStrategy> _sortStrategies;

    public NotificationFilterService()
    {
        // In a real application, these would be injected via dependency injection
        _filterStrategies = new INotificationFilterStrategy[]
        {
            new ReadStatusFilterStrategy(),
            new TypeFilterStrategy(),
            new PriorityFilterStrategy(),
            new SearchTextFilterStrategy()
        };

        _sortStrategies = new INotificationSortStrategy[]
        {
            new DateSortStrategy(),
            new PrioritySortStrategy(),
            new TitleSortStrategy()
        };
    }

    public IEnumerable<Notification> FilterAndSort(
        IEnumerable<Notification> notifications,
        NotificationFilterOptions options)
    {
        if (notifications == null)
            throw new ArgumentNullException(nameof(notifications));

        if (options == null)
            throw new ArgumentNullException(nameof(options));

        var query = notifications.AsQueryable();

        // Apply filters
        foreach (var filterStrategy in _filterStrategies)
        {
            if (filterStrategy.CanFilter(options))
            {
                query = filterStrategy.Filter(query, options);
            }
        }

        // Apply sorting
        query = ApplySorting(query, options);

        return query.ToList();
    }

    private IQueryable<Notification> ApplySorting(IQueryable<Notification> query, NotificationFilterOptions options)
    {
        var primarySortStrategy = _sortStrategies.FirstOrDefault(s => s.CanSort(options))
                                ?? new DateSortStrategy(); // Default fallback

        var orderedQuery = primarySortStrategy.Sort(query, options.Descending);

        // Apply secondary sorts for consistent ordering
        foreach (var secondaryStrategy in _sortStrategies.Where(s => s != primarySortStrategy))
        {
            orderedQuery = secondaryStrategy.ThenSort(orderedQuery, options.Descending);
        }

        // Always include ID as final sort for complete determinism
        orderedQuery = options.Descending
            ? orderedQuery.ThenByDescending(n => n.Id)
            : orderedQuery.ThenBy(n => n.Id);

        return orderedQuery;
    }
}
