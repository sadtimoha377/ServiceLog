using ServiceLog.Models;

namespace ServiceLog.Services.RequestLog;

public interface IRequestLogService
{
    void Log(string method, string path);
    IReadOnlyList<RequestLogItem> GetAll();
}
