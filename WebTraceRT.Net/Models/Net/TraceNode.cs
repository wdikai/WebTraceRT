namespace TraceRT.Models.Net
{
    public class TraceNode
    {
        public string Address { get; set; }

        public long Ttl { get; set; }

        public long RoundtripTime { get; set; }

        public string Status { get; set; }
        
    }
}