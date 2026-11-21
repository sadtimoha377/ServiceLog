using ServiceLog.Models;

namespace ServiceLog.Services.RequestLog;

public class RequestLogService : IRequestLogService
{
    private readonly List<RequestLogItem> _requests = new();
    private readonly object _lock = new();

    public void Log(string method, string path)
    {
        var request = new RequestLogItem
        {
            Method = method,
            Path = path
        };

        lock (_lock)
        {
            _requests.Add(request);
        }

        Console.WriteLine($"{request.Method} {request.Path}");
    }

    public IReadOnlyList<RequestLogItem> GetAll()
    {
        lock (_lock)
        {
            return _requests.ToList();
        }
    }
}
