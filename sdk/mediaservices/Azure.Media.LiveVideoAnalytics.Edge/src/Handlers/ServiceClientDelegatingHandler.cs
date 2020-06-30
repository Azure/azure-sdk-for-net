// -----------------------------------------------------------------------
//  <copyright company="Microsoft Corporation">
//      Copyright (C) Microsoft Corporation. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;

namespace Azure.Media.LiveVideoAnalytics.Edge
{
    /// <summary>
    /// HTTP delegating handler that rewrites API requests as direct method calls.
    /// </summary>
    internal class ServiceClientDelegatingHandler : IotClientDelegatingHandler
    {
        private readonly ServiceClient _serviceClient;
        private readonly EdgeClientConfiguration _edgeClientConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceClientDelegatingHandler"/> class.
        /// </summary>
        /// <param name="serviceClient">Service client.</param>
        /// <param name="edgeClientConfiguration">The edge client configuration.</param>
        public ServiceClientDelegatingHandler(ServiceClient serviceClient, EdgeClientConfiguration edgeClientConfiguration)
        {
            _serviceClient = serviceClient;
            _edgeClientConfiguration = edgeClientConfiguration;
        }

        /// <inheritdoc />
        protected override async Task<(HttpStatusCode ResponseStatus, string ResponseString)> SendIotRequestAsync(string methodName, string requestString)
        {
            var directMethod = new CloudToDeviceMethod(
                methodName,
                _edgeClientConfiguration.ResponseTimeout,
                _edgeClientConfiguration.ConnectTimeout);

            directMethod.SetPayloadJson(requestString);

            var directMethodResponse = await _serviceClient.InvokeDeviceMethodAsync(
                _edgeClientConfiguration.DeviceId,
                _edgeClientConfiguration.ModuleId,
                directMethod);

            return ((HttpStatusCode)directMethodResponse.Status, directMethodResponse.GetPayloadAsJson());
        }
    }
}
