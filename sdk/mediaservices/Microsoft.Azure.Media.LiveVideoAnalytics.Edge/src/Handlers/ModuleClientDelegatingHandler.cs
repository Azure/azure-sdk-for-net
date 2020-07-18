// -----------------------------------------------------------------------
//  <copyright company="Microsoft Corporation">
//      Copyright (C) Microsoft Corporation. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;

namespace Microsoft.Azure.Media.LiveVideoAnalytics.Edge.Handlers
{
    /// <summary>
    /// HTTP delegating handler that rewrites API requests as direct method calls.
    /// </summary>
    internal class ModuleClientDelegatingHandler : IotClientDelegatingHandler
    {
        private readonly ModuleClient _moduleClient;
        private readonly string _deviceId;
        private readonly string _moduleId;
        private readonly TimeSpan _responseTimeout;
        private readonly TimeSpan _connectionTimeout;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleClientDelegatingHandler"/> class.
        /// </summary>
        /// <param name="moduleClient">Current module client.</param>
        /// <param name="deviceId">Hub device id.</param>
        /// <param name="moduleId">Hub module id.</param>
        /// <param name="responseTimeout">The response timeout.</param>
        /// <param name="connectionTimeout">The connection timeout.</param>
        public ModuleClientDelegatingHandler(ModuleClient moduleClient, string deviceId, string moduleId, TimeSpan? responseTimeout, TimeSpan? connectionTimeout)
        {
            _moduleClient = moduleClient;
            _deviceId = deviceId;
            _moduleId = moduleId;

            // Azure Devices SDK uses default timeouts if Timespan.Zero is specified.
            _responseTimeout = responseTimeout ?? TimeSpan.Zero;
            _connectionTimeout = connectionTimeout ?? TimeSpan.Zero;
        }

        /// <inheritdoc />
        protected override async Task<(HttpStatusCode ResponseStatus, string ResponseString)> SendIotRequestAsync(string methodName, string requestString)
        {
            var directMethod = new MethodRequest(methodName, Encoding.UTF8.GetBytes(requestString), _responseTimeout, _connectionTimeout);
            var directMethodResponse = await _moduleClient.InvokeMethodAsync(_deviceId, _moduleId, directMethod);

            return ((HttpStatusCode)directMethodResponse.Status, directMethodResponse.ResultAsJson);
        }
    }
}
