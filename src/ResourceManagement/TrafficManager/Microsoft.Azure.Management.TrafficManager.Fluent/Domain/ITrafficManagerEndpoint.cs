// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.TrafficManager.Fluent
{
    using Management.TrafficManager.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an Azure traffic manager profile endpoint.
    /// </summary>
    public interface ITrafficManagerEndpoint  :
        IExternalChildResource<Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerEndpoint,Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfile>,
        IHasInner<EndpointInner>
    {
        /// <summary>
        /// Gets the priority of the endpoint which is used when traffic manager profile is configured with
        /// Priority traffic-routing method.
        /// </summary>
        int RoutingPriority { get; }

        /// <summary>
        /// Gets the endpoint type.
        /// </summary>
        Microsoft.Azure.Management.TrafficManager.Fluent.EndpointType EndpointType { get; }

        /// <summary>
        /// Gets true if the endpoint is enabled, false otherwise.
        /// </summary>
        bool IsEnabled { get; }

        /// <summary>
        /// Gets the weight of the endpoint which is used when traffic manager profile is configured with
        /// Weighted traffic-routing method.
        /// </summary>
        int RoutingWeight { get; }

        /// <summary>
        /// Gets the monitor status of the endpoint.
        /// </summary>
        Microsoft.Azure.Management.TrafficManager.Fluent.EndpointMonitorStatus MonitorStatus { get; }
    }
}