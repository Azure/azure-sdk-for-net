namespace Microsoft.Azure.OperationalInsights.Models
{
    using System.Collections.Generic;

    public class QueryResponseError
    {
        /// <summary>
        /// A machine readable error code.
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Error details.
        /// </summary>
        public List<QueryResponseError> Details { get; set; }
        /// <summary>
        /// A human readable error message.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Inner error details if they exist.
        /// </summary>
        public QueryResponseInnerError InnerError { get; set; }
    }
}