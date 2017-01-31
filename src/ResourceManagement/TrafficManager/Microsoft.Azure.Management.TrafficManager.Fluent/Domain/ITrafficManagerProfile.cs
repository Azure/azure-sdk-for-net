// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.TrafficManager.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using TrafficManagerProfile.Update;
    using System.Collections.Generic;
    using Management.TrafficManager.Fluent.Models;

    /// <summary>
    /// An immutable client-side representation of an Azure traffic manager profile.
    /// </summary>
    public interface ITrafficManagerProfile  :
        IGroupableResource<ITrafficManager>,
        IRefreshable<Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfile>,
        IWrapper<ProfileInner>,
        IUpdatable<TrafficManagerProfile.Update.IUpdate>
    {
        /// <summary>
        /// Gets the DNS Time-To-Live (TTL), in seconds.
        /// </summary>
        int TimeToLive { get; }

        /// <summary>
        /// Gets the path that is monitored to check the health of traffic manager profile endpoints.
        /// </summary>
        string MonitoringPath { get; }

        /// <summary>
        /// Gets external endpoints in the traffic manager profile, indexed by the name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerExternalEndpoint> ExternalEndpoints { get; }

        /// <summary>
        /// Gets Azure endpoints in the traffic manager profile, indexed by the name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerAzureEndpoint> AzureEndpoints { get; }

        /// <summary>
        /// Gets fully qualified domain name (FQDN) of the traffic manager profile.
        /// </summary>
        string Fqdn { get; }

        /// <summary>
        /// Gets nested traffic manager profile endpoints in this traffic manager profile, indexed by the name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerNestedProfileEndpoint> NestedProfileEndpoints { get; }

        /// <summary>
        /// Gets the port that is monitored to check the health of traffic manager profile endpoints.
        /// </summary>
        int MonitoringPort { get; }

        /// <summary>
        /// Gets the relative DNS name of the traffic manager profile.
        /// </summary>
        string DnsLabel { get; }

        /// <summary>
        /// Gets true if the traffic manager profile is enabled, false if enabled.
        /// </summary>
        bool IsEnabled { get; }

        /// <summary>
        /// Gets the routing method used to route traffic to traffic manager profile endpoints.
        /// </summary>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficRoutingMethod TrafficRoutingMethod { get; }

        /// <summary>
        /// Gets profile monitor status which is combination of the endpoint monitor status values for all endpoints in
        /// the profile, and the configured profile status.
        /// </summary>
        Microsoft.Azure.Management.TrafficManager.Fluent.ProfileMonitorStatus MonitorStatus { get; }
    }
}