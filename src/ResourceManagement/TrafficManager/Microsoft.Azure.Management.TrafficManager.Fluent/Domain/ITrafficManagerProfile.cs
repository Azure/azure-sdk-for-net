// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.TrafficManager.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Update;
    using Microsoft.Azure.Management.TrafficManager.Fluent.Models;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure traffic manager profile.
    /// </summary>
    public interface ITrafficManagerProfile  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManager,Models.ProfileInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfile>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<TrafficManagerProfile.Update.IUpdate>
    {
        /// <summary>
        /// Gets the path that is monitored to check the health of traffic manager profile endpoints.
        /// </summary>
        string MonitoringPath { get; }

        /// <summary>
        /// Gets nested traffic manager profile endpoints in this traffic manager profile, indexed by the name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerNestedProfileEndpoint> NestedProfileEndpoints { get; }

        /// <summary>
        /// Gets external endpoints in the traffic manager profile, indexed by the name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerExternalEndpoint> ExternalEndpoints { get; }

        /// <summary>
        /// Gets the relative DNS name of the traffic manager profile.
        /// </summary>
        string DnsLabel { get; }

        /// <summary>
        /// Gets the routing method used to route traffic to traffic manager profile endpoints.
        /// </summary>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficRoutingMethod TrafficRoutingMethod { get; }

        /// <summary>
        /// Gets profile monitor status which is combination of the endpoint monitor status values for all endpoints in
        /// the profile, and the configured profile status.
        /// </summary>
        Microsoft.Azure.Management.TrafficManager.Fluent.ProfileMonitorStatus MonitorStatus { get; }

        /// <summary>
        /// Gets Azure endpoints in the traffic manager profile, indexed by the name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerAzureEndpoint> AzureEndpoints { get; }

        /// <summary>
        /// Gets fully qualified domain name (FQDN) of the traffic manager profile.
        /// </summary>
        string Fqdn { get; }

        /// <summary>
        /// Gets true if the traffic manager profile is enabled, false if enabled.
        /// </summary>
        bool IsEnabled { get; }

        /// <summary>
        /// Gets the DNS Time-To-Live (TTL), in seconds.
        /// </summary>
        long TimeToLive { get; }

        /// <summary>
        /// Gets the port that is monitored to check the health of traffic manager profile endpoints.
        /// </summary>
        long MonitoringPort { get; }
    }
}