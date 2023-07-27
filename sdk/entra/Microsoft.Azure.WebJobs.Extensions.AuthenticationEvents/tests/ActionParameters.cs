using Microsoft.Azure.WebJobs.Host.Executors;
using System.Net.Http;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests
{

    /// <summary>Parameter class for action parameters passed from BaseTest</summary>
    public class ActionParameters
    {
        /// <summary>Gets or sets the request message.</summary>
        /// <value>The request message.</value>
        public HttpRequestMessage RequestMessage { get; set; }
        /// <summary>Gets or sets the function data.</summary>
        /// <value>The function data.</value>
        public TriggeredFunctionData FunctionData { get; set; }
    }

}
