namespace Microsoft.Azure.OperationalInsights.Models
{
    using System.Collections.Generic;

    public class QueryResponseError
    {
        public string Code { get; set; }
        public List<QueryResponseError> Details { get; set; }
        public string Message { get; set; }
        public QueryResponseInnerError InnerError { get; set; }
    }
}