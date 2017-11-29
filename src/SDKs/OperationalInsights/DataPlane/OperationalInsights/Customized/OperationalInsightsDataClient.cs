using Microsoft.Azure.OperationalInsights.Models;
using Microsoft.Rest;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Microsoft.Azure.OperationalInsights
{
    public partial class OperationalInsightsDataClient : ServiceClient<OperationalInsightsDataClient>, IOperationalInsightsDataClient
    {
        public static OperationalInsightsDataClient CreateClient(ServiceClientCredentials credentials, params DelegatingHandler[] handlers)
        {
            return CreateClient(credentials, null, handlers);
        }

        public static OperationalInsightsDataClient CreateClient(ServiceClientCredentials credentials, HttpClientHandler rootHandler = null, params DelegatingHandler[] handlers)
        {
            var customHandler = new CustomDelegatingHandler();
            if (handlers == null)
            {
                handlers = new[] { customHandler };
            }
            else
            {
                handlers = new[] { customHandler }.Concat(handlers).ToArray();
            }

            var client = new OperationalInsightsDataClient(credentials, rootHandler, handlers);
            customHandler.Client = client;

            return client;
        }

        public IList<string> AdditionalWorkspaces { get; set; } = new List<string>();

        public ApiPreferences Preferences { get; set; } = new ApiPreferences();

        public string NameHeader { get; set; }

        public string RequestId { get; set; }
    }
}
