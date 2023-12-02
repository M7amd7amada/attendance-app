namespace Attendance.Shared.Data;

public class PageRdesult<T> : PagedResultBase where T : class
{
    public IList<T> Results { get; set; } = new List<T>();
}