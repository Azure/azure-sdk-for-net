using Microsoft.Rest;

namespace Microsoft.Azure.ApplicationInsights.Query.Models
{
    public partial class ErrorResponseException : RestException
    {
        public override string ToString()
        {
            return Body != null ? Body.ToString() : Response.Content;
        }
    }
}
