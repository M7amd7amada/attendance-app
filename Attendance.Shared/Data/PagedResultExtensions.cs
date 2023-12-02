namespace Attendance.Shared.Data;

public static class PagedResultExtensions
{
    public static PageRdesult<T> GetPaged<T>(
        this IQueryable<T> query,
        int page,
        int pageSize) where T : class
    {
        var result = new PageRdesult<T>
        {
            CurrentPage = page,
            PageSize = pageSize,
            RowCount = query.Count()
        };

        var pageCount = (double)result.RowCount / pageSize;
        result.PageCount = (int)Math.Ceiling(pageCount);

        var skip = (page - 1) * pageSize;
        result.Results = query.Skip(skip).Take(pageSize).ToList();

        return result;
    }
}