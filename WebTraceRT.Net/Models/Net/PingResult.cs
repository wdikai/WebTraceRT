namespace TraceRT.Models.Net
{
    public class PingResult
    {
        public string Address { get; set; }

        public long Ttl { get; set; }

        public string Status { get; set; }

        public long RoundtripTime { get; set; }

        public byte[] Buffer { get; set; }
    }
}