namespace WebTraceRT.Net
{
    using System;
    using System.Diagnostics;
    using System.Net.NetworkInformation;
    using System.Text;
    using System.Threading.Tasks;
    using TraceRT.Models.Net;

    public static class Tracerouter
    {
        public static TraceResult Trace(
            string host,
            int maxTtl = 100,
            int timeout = 100)
        {
            String tempStatus = "";
            TraceResult result = new TraceResult();
            try 
	        {	        
		        Ping pinger = new Ping();
                byte[] buffer = Encoding.ASCII.GetBytes(new string('a', 32));
                Stopwatch timer = Stopwatch.StartNew();
                for (int ttl = 1; ttl < maxTtl; ttl++)
                {
                    PingOptions options = new PingOptions(ttl, true);
                    timer.Restart();
                    PingReply reply = pinger.Send(host, timeout, buffer, options);
                    timer.Stop();

                    TraceNode node = new TraceNode();

                    if (reply.Status != IPStatus.TimedOut)
                    { 
                        node.Address = reply.Address.ToString();
                    }
                    else 
                    {
                        node.Address = "*";
                    }
                    node.Status = reply.Status.ToString();
                    node.Ttl = ttl;
                    node.RoundtripTime = timer.ElapsedMilliseconds;

                    result.Nodes.Add(node);
                    if (reply.Status == IPStatus.Success)
                    {
                        tempStatus = "Success";
                        break;
                    }
                }
                if (string.IsNullOrEmpty(tempStatus))
                    tempStatus = "TooSmallValueMaxHops";
	        }
	        catch (Exception)
	        {
                tempStatus = "InvalidTrace";
	        }

            result.Status = tempStatus;

            return result;
        }
    }
}
