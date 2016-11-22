// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Trafficmanager.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an Azure traffic manager profile endpoint.
    /// </summary>
    public interface ITrafficManagerEndpoint  :
        IExternalChildResource<ITrafficManagerEndpoint,ITrafficManagerProfile>,
        IWrapper<EndpointInner>
    {
        /// <return>
        /// The priority of the endpoint which is used when traffic manager profile is configured with
        /// Priority traffic-routing method.
        /// </return>
        int RoutingPriority { get; }

        /// <return>The endpoint type.</return>
        EndpointType EndpointType { get; }

        /// <return>True if the endpoint is enabled, false otherwise.</return>
        bool IsEnabled { get; }

        /// <return>
        /// The weight of the endpoint which is used when traffic manager profile is configured with
        /// Weighted traffic-routing method.
        /// </return>
        int RoutingWeight { get; }

        /// <return>The monitor status of the endpoint.</return>
        EndpointMonitorStatus MonitorStatus { get; }
    }
}