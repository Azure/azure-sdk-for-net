// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Trafficmanager.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using TrafficManagerProfile.Update;

    /// <summary>
    /// An immutable client-side representation of an Azure traffic manager profile.
    /// </summary>
    public interface ITrafficManagerProfile  :
        IGroupableResource,
        IRefreshable<ITrafficManagerProfile>,
        IWrapper<ProfileInner>,
        IUpdatable<TrafficManagerProfile.Update.IUpdate>
    {
        /// <return>The DNS Time-To-Live (TTL), in seconds.</return>
        int TimeToLive { get; }

        /// <return>The path that is monitored to check the health of traffic manager profile endpoints.</return>
        string MonitoringPath { get; }

        /// <return>External endpoints in the traffic manager profile, indexed by the name.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,ITrafficManagerExternalEndpoint> ExternalEndpoints { get; }

        /// <return>Azure endpoints in the traffic manager profile, indexed by the name.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,ITrafficManagerAzureEndpoint> AzureEndpoints { get; }

        /// <return>Fully qualified domain name (FQDN) of the traffic manager profile.</return>
        string Fqdn { get; }

        /// <return>Nested traffic manager profile endpoints in this traffic manager profile, indexed by the name.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,ITrafficManagerNestedProfileEndpoint> NestedProfileEndpoints { get; }

        /// <return>The port that is monitored to check the health of traffic manager profile endpoints.</return>
        int MonitoringPort { get; }

        /// <return>The relative DNS name of the traffic manager profile.</return>
        string DnsLabel { get; }

        /// <return>True if the traffic manager profile is enabled, false if enabled.</return>
        bool IsEnabled { get; }

        /// <return>The routing method used to route traffic to traffic manager profile endpoints.</return>
        TrafficRoutingMethod TrafficRoutingMethod { get; }

        /// <return>
        /// Profile monitor status which is combination of the endpoint monitor status values for all endpoints in
        /// the profile, and the configured profile status.
        /// </return>
        ProfileMonitorStatus MonitorStatus { get; }
    }
}