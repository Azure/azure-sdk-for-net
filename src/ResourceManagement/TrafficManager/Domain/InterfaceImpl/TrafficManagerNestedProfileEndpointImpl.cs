// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.TrafficManager.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.TrafficManager.Fluent.Models;

    internal partial class TrafficManagerNestedProfileEndpointImpl 
    {
        /// <summary>
        /// Gets the monitor status of the endpoint.
        /// </summary>
        Microsoft.Azure.Management.TrafficManager.Fluent.EndpointMonitorStatus Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerEndpoint.MonitorStatus
        {
            get
            {
                return this.MonitorStatus() as Microsoft.Azure.Management.TrafficManager.Fluent.EndpointMonitorStatus;
            }
        }

        /// <summary>
        /// Gets the priority of the endpoint which is used when traffic manager profile is configured with
        /// Priority traffic-routing method.
        /// </summary>
        long Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerEndpoint.RoutingPriority
        {
            get
            {
                return this.RoutingPriority();
            }
        }

        /// <summary>
        /// Gets the endpoint type.
        /// </summary>
        Microsoft.Azure.Management.TrafficManager.Fluent.EndpointType Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerEndpoint.EndpointType
        {
            get
            {
                return this.EndpointType();
            }
        }

        /// <summary>
        /// Gets the weight of the endpoint which is used when traffic manager profile is configured with
        /// Weighted traffic-routing method.
        /// </summary>
        long Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerEndpoint.RoutingWeight
        {
            get
            {
                return this.RoutingWeight();
            }
        }

        /// <summary>
        /// Gets true if the endpoint is enabled, false otherwise.
        /// </summary>
        bool Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerEndpoint.IsEnabled
        {
            get
            {
                return this.IsEnabled();
            }
        }

        /// <summary>
        /// Gets the location of the traffic that the endpoint handles.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerNestedProfileEndpoint.SourceTrafficLocation
        {
            get
            {
                return this.SourceTrafficLocation() as Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region;
            }
        }

        /// <summary>
        /// Gets the number of child endpoints to be online to consider nested profile as healthy.
        /// </summary>
        long Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerNestedProfileEndpoint.MinimumChildEndpointCount
        {
            get
            {
                return this.MinimumChildEndpointCount();
            }
        }

        /// <summary>
        /// Gets the nested traffic manager profile resource id.
        /// </summary>
        string Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerNestedProfileEndpoint.NestedProfileId
        {
            get
            {
                return this.NestedProfileId();
            }
        }
    }
}