namespace Microsoft.Azure.OperationalInsights.Models
{
    public class QueryResponseInnerError
    {
        /// <summary>
        /// A machine readable severity code.
        /// </summary>
        public int Severity { get; set; }
        /// <summary>
        /// A human readable severity message.
        /// </summary>
        public string SeverityName { get; set; }
        /// <summary>
        /// A human readable error message.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// A machine readable error code.
        /// </summary>
        public string Code { get; set; }
    }
}