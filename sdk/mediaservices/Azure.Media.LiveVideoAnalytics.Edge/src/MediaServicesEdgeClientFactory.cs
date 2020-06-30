// -----------------------------------------------------------------------
//  <copyright company="Microsoft Corporation">
//      Copyright (C) Microsoft Corporation. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

using System;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Client;
using Azure.Media.LiveVideoAnalytics.Edge.Handlers;

namespace Azure.Media.LiveVideoAnalytics.Edge
{
    /// <summary>
    /// Static factory for the client.
    /// </summary>
    public static class MediaServicesEdgeClientFactory
    {
        /// <summary>
        /// Creates an instance of the Azure Media Services Edge for local calls within the edge hub.
        /// </summary>
        /// <param name="moduleClient">Current module client.</param>
        /// <param name="deviceId">Target device id.</param>
        /// <param name="moduleId">Target module id.</param>
        /// <returns>A newly created instance of the client.</returns>
        public static IMediaServicesEdgeClient Create(ModuleClient moduleClient, string deviceId, string moduleId)
        {
            var directMethodCallDelegatingHandler = new ModuleClientDelegatingHandler(moduleClient, deviceId, moduleId);

            return new MediaServicesEdgeClient(new[] { directMethodCallDelegatingHandler });
        }

        /// <summary>
        /// Creates an instance of the Azure Media Services Edge for remote calls to the IoT hub.
        /// </summary>
        /// <param name="serviceClient">IoT Hub Service client.</param>
        /// <param name="edgeClientConfiguration">The edge client configuration.</param>.
        /// <returns>A newly created instance of the client.</returns>
        public static IMediaServicesEdgeClient Create(ServiceClient serviceClient, EdgeClientConfiguration edgeClientConfiguration)
        {
            var directMethodCallDelegatingHandler = new ServiceClientDelegatingHandler(serviceClient, edgeClientConfiguration);

            return new MediaServicesEdgeClient(new[] { directMethodCallDelegatingHandler });
        }
    }
}
