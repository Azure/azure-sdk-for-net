using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.OperationalInsights
{
    internal class CustomDelegatingHandler : DelegatingHandler
    {
        internal OperationalInsightsDataClient Client { get; set; }

        internal const string InternalNameHeader = "csharpsdk";

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var appName = InternalNameHeader;
            if (!string.IsNullOrWhiteSpace(Client.NameHeader))
            {
                appName += $",{Client.NameHeader}";
            }

            request.Headers.Add("prefer", Client.Preferences.ToString());
            request.Headers.Add("x-ms-app", appName);
            request.Headers.Add("x-ms-client-request-id", Client.RequestId ?? Guid.NewGuid().ToString());
            
            // Call the inner handler.
            var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
            
            return response;
        }
    }
}
