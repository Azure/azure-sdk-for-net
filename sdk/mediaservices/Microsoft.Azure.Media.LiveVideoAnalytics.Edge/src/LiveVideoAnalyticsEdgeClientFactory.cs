// -----------------------------------------------------------------------
//  <copyright company="Microsoft Corporation">
//      Copyright (C) Microsoft Corporation. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

using System;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Media.LiveVideoAnalytics.Edge.Handlers;

namespace Microsoft.Azure.Media.LiveVideoAnalytics.Edge
{
    /// <summary>
    /// Static factory for the client.
    /// </summary>
    public static class LiveVideoAnalyticsEdgeClientFactory
    {
        /// <summary>
        /// Creates an instance of the Azure Media Services Edge for local calls within the edge hub.
        /// </summary>
        /// <param name="moduleClient">Current module client.</param>
        /// <param name="deviceId">Target device id.</param>
        /// <param name="moduleId">Target module id.</param>
        /// <param name="responseTimeout">The response timeout.</param>
        /// <param name="connectionTimeout">The connection timeout.</param>
        /// <returns>A newly created instance of the client.</returns>
        public static ILiveVideoAnalyticsEdgeClient Create(
            ModuleClient moduleClient,
            string deviceId,
            string moduleId,
            TimeSpan? responseTimeout = null,
            TimeSpan? connectionTimeout = null)
        {
            var directMethodCallDelegatingHandler = new ModuleClientDelegatingHandler(moduleClient, deviceId, moduleId, responseTimeout, connectionTimeout);

            return new LiveVideoAnalyticsEdgeClient(new[] { directMethodCallDelegatingHandler });
        }

        /// <summary>
        /// Creates an instance of the Azure Media Services Edge for remote calls to the IoT hub.
        /// </summary>
        /// <param name="serviceClient">IoT Hub Service client.</param>
        /// <param name="deviceId">Target device id.</param>
        /// <param name="moduleId">Target module id.</param>
        /// <param name="responseTimeout">The response timeout.</param>
        /// <param name="connectionTimeout">The connection timeout.</param>
        /// <returns>A newly created instance of the client.</returns>
        public static ILiveVideoAnalyticsEdgeClient Create(
            ServiceClient serviceClient,
            string deviceId,
            string moduleId,
            TimeSpan? responseTimeout = null,
            TimeSpan? connectionTimeout = null)
        {
            var directMethodCallDelegatingHandler = new ServiceClientDelegatingHandler(serviceClient, deviceId, moduleId, responseTimeout, connectionTimeout);

            return new LiveVideoAnalyticsEdgeClient(new[] { directMethodCallDelegatingHandler });
        }
    }
}
