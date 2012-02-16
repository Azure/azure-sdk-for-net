using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Windows.Foundation;

namespace Microsoft.WindowsAzure.ServiceLayer.Implementation
{
    /// <summary>
    /// REST proxy for the service bus interface.
    /// </summary>
    class ServiceBusRestProxy: IServiceBusService
    {
        /// <summary>
        /// Gets the service options.
        /// </summary>
        internal ServiceBusServiceConfig ServiceConfig { get; private set; }

        /// <summary>
        /// Gets HTTP client used for communicating with the service.
        /// </summary>
        HttpClient Channel { get; set; }

        /// <summary>
        /// Gets the token manager used for authentication
        /// </summary>
        Implementation.WrapTokenManager TokenManager { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="serviceOptions">Service options</param>
        internal ServiceBusRestProxy(ServiceBusServiceConfig serviceOptions)
        {
            Debug.Assert(serviceOptions != null);

            ServiceConfig = serviceOptions;
            Channel = new HttpClient();
            TokenManager = new WrapTokenManager(ServiceConfig);
        }

        /// <summary>
        /// Gets all available queues in the namespace.
        /// </summary>
        /// <returns>All queues in the namespace</returns>
        IAsyncOperation<IEnumerable<QueueInfo>> IServiceBusService.ListQueuesAsync()
        {
            Uri uri = new Uri(ServiceConfig.ServiceBusUri, "$Resources/Queues");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);

            return AuthenticateRequestAsync(request)
                .ContinueWith<HttpResponseMessage>(r => { return Channel.SendAsync(r.Result).Result; }, TaskContinuationOptions.OnlyOnRanToCompletion)
                .ContinueWith<IEnumerable<QueueInfo>>(r => { return GetQueues(r.Result); }, TaskContinuationOptions.OnlyOnRanToCompletion)
                .AsAsyncOperation<IEnumerable<QueueInfo>>();
        }

        /// <summary>
        /// Authenticates the request.
        /// </summary>
        /// <param name="request">Request to authenticate</param>
        /// <returns>Authenticated request</returns>
        Task<HttpRequestMessage> AuthenticateRequestAsync(HttpRequestMessage request)
        {
            return TokenManager.GetTokenAsync(request.RequestUri.AbsolutePath)
                .ContinueWith(t => { return t.Result.Authorize(request); }, TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        /// <summary>
        /// Extracts queues from the given HTTP response.
        /// </summary>
        /// <param name="response">HTTP response</param>
        /// <returns>Collection of queues</returns>
        IEnumerable<QueueInfo> GetQueues(HttpResponseMessage response)
        {
            Debug.Assert(response.IsSuccessStatusCode);

            throw new NotImplementedException();
        }
    }
}
