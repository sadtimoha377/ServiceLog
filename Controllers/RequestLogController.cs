using Microsoft.AspNetCore.Mvc;
using ServiceLog.Services.RequestLog;

namespace ServiceLog.Controllers
{
    public class RequestLogController : Controller
    {
        private readonly IRequestLogService _requestLog;

        public RequestLogController(IRequestLogService requestLog)
        {
            _requestLog = requestLog;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_requestLog.GetAll());
        }
    }
}
