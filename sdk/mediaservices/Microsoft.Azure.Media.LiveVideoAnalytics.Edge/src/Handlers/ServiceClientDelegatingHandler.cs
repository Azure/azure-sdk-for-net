// -----------------------------------------------------------------------
//  <copyright company="Microsoft Corporation">
//      Copyright (C) Microsoft Corporation. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;

namespace Microsoft.Azure.Media.LiveVideoAnalytics.Edge.Handlers
{
    /// <summary>
    /// HTTP delegating handler that rewrites API requests as direct method calls.
    /// </summary>
    internal class ServiceClientDelegatingHandler : IotClientDelegatingHandler
    {
        private readonly ServiceClient _serviceClient;
        private readonly string _deviceId;
        private readonly string _moduleId;
        private readonly TimeSpan _responseTimeout;
        private readonly TimeSpan _connectionTimeout;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceClientDelegatingHandler"/> class.
        /// </summary>
        /// <param name="serviceClient">Service client.</param>
        /// <param name="deviceId">Hub device id.</param>
        /// <param name="moduleId">Hub module id.</param>
        /// <param name="responseTimeout">The response timeout.</param>
        /// <param name="connectionTimeout">The connection timeout.</param>
        public ServiceClientDelegatingHandler(ServiceClient serviceClient, string deviceId, string moduleId, TimeSpan? responseTimeout, TimeSpan? connectionTimeout)
        {
            _serviceClient = serviceClient;
            _deviceId = deviceId;
            _moduleId = moduleId;

            // Azure Devices SDK uses default timeouts if Timespan.Zero is specified.
            _responseTimeout = responseTimeout ?? TimeSpan.Zero;
            _connectionTimeout = connectionTimeout ?? TimeSpan.Zero;
        }

        /// <inheritdoc />
        protected override async Task<(HttpStatusCode ResponseStatus, string ResponseString)> SendIotRequestAsync(string methodName, string requestString)
        {
            var directMethod = new CloudToDeviceMethod(methodName, _responseTimeout, _connectionTimeout);
            directMethod.SetPayloadJson(requestString);

            var directMethodResponse = await _serviceClient.InvokeDeviceMethodAsync(_deviceId, _moduleId, directMethod);

            return ((HttpStatusCode)directMethodResponse.Status, directMethodResponse.GetPayloadAsJson());
        }
    }
}
