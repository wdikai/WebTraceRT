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

    [RoutePrefix("trace")]
    public class TraceController : ApiController
    {
        [Route("{host}/{maxHops:int}/{timeout:int}")]
        public JsonResult<TraceResult> Get(string host, int maxHops, int timeout) 
        {
            var result = Tracerouter.Trace(host, maxHops, timeout);
            return Json<TraceResult>(result);
        }
    }
}
