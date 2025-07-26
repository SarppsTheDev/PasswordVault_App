namespace locktopus_domain.Helpers;

public class PaginatedList<T>(List<T> items, int pageIndex, int totalPages, int totalCount)
{
    public List<T> Items { get; } = items;
    public int PageIndex { get; } = pageIndex;
    public int TotalPages { get; } = totalPages;
    public int TotalCount { get; } = totalCount;
}