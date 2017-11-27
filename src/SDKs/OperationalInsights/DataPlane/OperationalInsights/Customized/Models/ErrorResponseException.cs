namespace Microsoft.Azure.OperationalInsights.Models
{
    using Microsoft.Rest;

    public partial class ErrorResponseException : RestException
    {
        public override string ToString()
        {
            return Body != null ? Body.ToString() : Response.Content;
        }
    }
}
