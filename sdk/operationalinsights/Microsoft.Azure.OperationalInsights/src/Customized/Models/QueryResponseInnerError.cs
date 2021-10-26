namespace Microsoft.Azure.OperationalInsights.Models
{
    public class QueryResponseInnerError
    {
        public int Severity { get; set; }
        public string SeverityName { get; set; }
        public string Message { get; set; }
        public string Code { get; set; }
    }
}