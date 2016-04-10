namespace WebTraceRT.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Results;
    using TraceRT.Models.Net;
    using WebTraceRT.Net;

    [RoutePrefix("ping")]
    public class PingController : ApiController
    {
        [Route("{host}")]
        public JsonResult<PingResult> Get(string host)
        {
            PingResult result = Pinger.Send(host);
            return Json<PingResult>(result);
        }

        [Route("{host}/{bufferSize:int}/{ttl:int}/{timeout:int}")]
        public JsonResult<PingResult> Get(string host, int bufferSize, int ttl, int timeout)
        {
            PingResult result = Pinger.Send(host, bufferSize, ttl, timeout);
            return Json<PingResult>(result);
        }
    }
}
