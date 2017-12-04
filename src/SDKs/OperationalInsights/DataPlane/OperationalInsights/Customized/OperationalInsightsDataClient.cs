using Microsoft.Azure.OperationalInsights.Models;
using Microsoft.Rest;
using System.Collections.Generic;
using System.Net.Http;

namespace Microsoft.Azure.OperationalInsights
{
    public partial class OperationalInsightsDataClient : ServiceClient<OperationalInsightsDataClient>, IOperationalInsightsDataClient
    {
        /// <summary>
        /// Initializes a new instance of the OperationalInsightsDataClient class.
        /// </summary>
        /// <param name='credentials'>
        /// Required. Subscription credentials which uniquely identify client subscription.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        public OperationalInsightsDataClient(ServiceClientCredentials credentials)
            : this(credentials, (DelegatingHandler[])null)
        {
        }

        partial void CustomInitialize()
        {
            var firstHandler = this.FirstMessageHandler as DelegatingHandler;
            if (firstHandler == null) return;

            var customHandler = new CustomDelegatingHandler
            {
                InnerHandler = firstHandler.InnerHandler,
                Client = this,
            };

            firstHandler.InnerHandler = customHandler;
        }

        public IList<string> AdditionalWorkspaces { get; set; } = new List<string>();

        public ApiPreferences Preferences { get; set; } = new ApiPreferences();

        public string NameHeader { get; set; }

        public string RequestId { get; set; }
    }
}
