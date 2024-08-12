using System.Net;
using System.Net.Http;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests
{
    internal class TestAuthResponse : WebJobsAuthenticationEventResponse
    {
        internal TestAuthResponse(HttpStatusCode code, string content)
        : this(code)
        {
            Content = new StringContent(content);
        }

        internal TestAuthResponse(HttpStatusCode code)
        {
            StatusCode = code;
        }

        internal override void BuildJsonElement()
        { }
    }
}
