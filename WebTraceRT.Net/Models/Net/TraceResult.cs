namespace TraceRT.Models.Net
{
    using System.Collections.Generic;

    public class TraceResult
    {
        public TraceResult()
        {
            this.Nodes = new List<TraceNode>();
        }

        public List<TraceNode> Nodes { get; set; }

        public string Status { get; set; }
    }
}
