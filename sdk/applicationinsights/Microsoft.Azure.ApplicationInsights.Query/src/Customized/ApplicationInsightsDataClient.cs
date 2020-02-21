using Microsoft.Azure.ApplicationInsights.Query.Models;
using Microsoft.Rest;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.ApplicationInsights.Query
{
    public partial class ApplicationInsightsDataClient : ServiceClient<ApplicationInsightsDataClient>, IApplicationInsightsDataClient
    {
        /// <summary>
        /// Initializes a new instance of the ApplicationInsightsDataClient class.
        /// </summary>
        /// <param name='credentials'>
        /// Required. Subscription credentials which uniquely identify client subscription.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        public ApplicationInsightsDataClient(ServiceClientCredentials credentials) : this(credentials, (DelegatingHandler[])null)
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

        public IList<string> AdditionalApplications { get; set; } = new List<string>();

        public ApiPreferences Preferences { get; set; } = new ApiPreferences();

        public string NameHeader { get; set; }

        public string RequestId { get; set; }
    }
}
