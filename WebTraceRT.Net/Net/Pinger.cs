namespace WebTraceRT.Net
{
    using System.Diagnostics;
    using System.Net.NetworkInformation;
    using System.Text;
    using TraceRT.Models.Net;

    public static class Pinger
    {
        public static PingResult Send(
            string host,
            int bufferSize = 32,
            int ttl = 100,
            int timeout = 100)
        {
            PingResult result = new PingResult();
            try
            {
                var pinger = new Ping();
                byte[] buffer = Encoding.ASCII.GetBytes(new string('a', 32));
                var timer = Stopwatch.StartNew();
                var options = new PingOptions(ttl, true);

                timer.Restart();
                var reply = pinger.Send(host, timeout, buffer, options);
                timer.Stop();

                if (reply.Status != IPStatus.TimedOut)
                {
                    result.Address = reply.Address.ToString();
                }
                else
                {
                    result.Address = "*";
                }
                result.Status = reply.Status.ToString();
                result.Ttl = ttl;
                result.RoundtripTime = timer.ElapsedMilliseconds;
	        }
	        catch (System.Exception)
            {
                result.Status = "Invalide";
	        }

            return result;
        }
    }
}
