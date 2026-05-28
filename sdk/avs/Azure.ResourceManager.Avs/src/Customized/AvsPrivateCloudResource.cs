// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Avs.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Avs
{
    /// <summary>
    /// A Class representing an AvsPrivateCloud along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct an <see cref="AvsPrivateCloudResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetAvsPrivateCloudResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource"/> using the GetAvsPrivateCloud method.
    /// </summary>
    public partial class AvsPrivateCloudResource : ArmResource
    {
        /// <summary>
        /// Get a private cloud workload network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/{workloadNetworkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="workloadNetworkName"> Name for the workload network in the private cloud. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release.", false)]
        public virtual Response<WorkloadNetworkResource> GetWorkloadNetwork(WorkloadNetworkName workloadNetworkName, CancellationToken cancellationToken = default)
        {
            return GetWorkloadNetworks().Get(workloadNetworkName, cancellationToken);
        }

        /// <summary>
        /// Get a private cloud workload network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/{workloadNetworkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="workloadNetworkName"> Name for the workload network in the private cloud. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release.", false)]
        public virtual async Task<Response<WorkloadNetworkResource>> GetWorkloadNetworkAsync(WorkloadNetworkName workloadNetworkName, CancellationToken cancellationToken = default)
        {
            return await GetWorkloadNetworks().GetAsync(workloadNetworkName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a collection of WorkloadNetworkResources in the AvsPrivateCloud. </summary>
        /// <returns> An object representing collection of WorkloadNetworkResources and their operations over a WorkloadNetworkResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release.", false)]
        public virtual WorkloadNetworkCollection GetWorkloadNetworks()
        {
            return GetCachedClient(client => new WorkloadNetworkCollection(client, Id));
        }

        /// <summary>
        /// Get dhcp by id in a private cloud workload network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/default/dhcpConfigurations/{dhcpId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_GetDhcp</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkDhcpResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="dhcpId"> NSX DHCP identifier. Generally the same as the DHCP display name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dhcpId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="dhcpId"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<WorkloadNetworkDhcpResource> GetWorkloadNetworkDhcp(string dhcpId, CancellationToken cancellationToken = default)
        {
            return GetWorkloadNetwork().GetWorkloadNetworkDhcps().Get(dhcpId, cancellationToken);
        }

        /// <summary>
        /// Get dhcp by id in a private cloud workload network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/default/dhcpConfigurations/{dhcpId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_GetDhcp</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkDhcpResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="dhcpId"> NSX DHCP identifier. Generally the same as the DHCP display name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dhcpId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="dhcpId"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<WorkloadNetworkDhcpResource>> GetWorkloadNetworkDhcpAsync(string dhcpId, CancellationToken cancellationToken = default)
        {
            return await GetWorkloadNetwork().GetWorkloadNetworkDhcps().GetAsync(dhcpId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a collection of WorkloadNetworkDhcpResources in the AvsPrivateCloud. </summary>
        /// <returns> An object representing collection of WorkloadNetworkDhcpResources and their operations over a WorkloadNetworkDhcpResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual WorkloadNetworkDhcpCollection GetWorkloadNetworkDhcps()
        {
            return GetWorkloadNetwork().GetWorkloadNetworkDhcps();
        }

        /// <summary>
        /// Get a DNS service by id in a private cloud workload network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/default/dnsServices/{dnsServiceId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_GetDnsService</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkDnsServiceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="dnsServiceId"> NSX DNS Service identifier. Generally the same as the DNS Service's display name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dnsServiceId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="dnsServiceId"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<WorkloadNetworkDnsServiceResource> GetWorkloadNetworkDnsService(string dnsServiceId, CancellationToken cancellationToken = default)
        {
            return GetWorkloadNetwork().GetWorkloadNetworkDnsServices().Get(dnsServiceId, cancellationToken);
        }

        /// <summary>
        /// Get a DNS service by id in a private cloud workload network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/default/dnsServices/{dnsServiceId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_GetDnsService</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkDnsServiceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="dnsServiceId"> NSX DNS Service identifier. Generally the same as the DNS Service's display name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dnsServiceId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="dnsServiceId"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<WorkloadNetworkDnsServiceResource>> GetWorkloadNetworkDnsServiceAsync(string dnsServiceId, CancellationToken cancellationToken = default)
        {
            return await GetWorkloadNetwork().GetWorkloadNetworkDnsServices().GetAsync(dnsServiceId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a collection of WorkloadNetworkDnsServiceResources in the AvsPrivateCloud. </summary>
        /// <returns> An object representing collection of WorkloadNetworkDnsServiceResources and their operations over a WorkloadNetworkDnsServiceResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual WorkloadNetworkDnsServiceCollection GetWorkloadNetworkDnsServices()
        {
            return GetWorkloadNetwork().GetWorkloadNetworkDnsServices();
        }

        /// <summary>
        /// Get a DNS zone by id in a private cloud workload network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/default/dnsZones/{dnsZoneId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_GetDnsZone</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkDnsZoneResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="dnsZoneId"> NSX DNS Zone identifier. Generally the same as the DNS Zone's display name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dnsZoneId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="dnsZoneId"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<WorkloadNetworkDnsZoneResource> GetWorkloadNetworkDnsZone(string dnsZoneId, CancellationToken cancellationToken = default)
        {
            return GetWorkloadNetwork().GetWorkloadNetworkDnsZones().Get(dnsZoneId, cancellationToken);
        }

        /// <summary>
        /// Get a DNS zone by id in a private cloud workload network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/default/dnsZones/{dnsZoneId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_GetDnsZone</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkDnsZoneResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="dnsZoneId"> NSX DNS Zone identifier. Generally the same as the DNS Zone's display name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dnsZoneId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="dnsZoneId"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<WorkloadNetworkDnsZoneResource>> GetWorkloadNetworkDnsZoneAsync(string dnsZoneId, CancellationToken cancellationToken = default)
        {
            return await GetWorkloadNetwork().GetWorkloadNetworkDnsZones().GetAsync(dnsZoneId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a collection of WorkloadNetworkDnsZoneResources in the AvsPrivateCloud. </summary>
        /// <returns> An object representing collection of WorkloadNetworkDnsZoneResources and their operations over a WorkloadNetworkDnsZoneResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual WorkloadNetworkDnsZoneCollection GetWorkloadNetworkDnsZones()
        {
            return GetWorkloadNetwork().GetWorkloadNetworkDnsZones();
        }

        /// <summary>
        /// Get a gateway by id in a private cloud workload network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/default/gateways/{gatewayId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_GetGateway</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkGatewayResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="gatewayId"> NSX Gateway identifier. Generally the same as the Gateway's display name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="gatewayId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="gatewayId"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<WorkloadNetworkGatewayResource> GetWorkloadNetworkGateway(string gatewayId, CancellationToken cancellationToken = default)
        {
            return GetWorkloadNetwork().GetWorkloadNetworkGateways().Get(gatewayId, cancellationToken);
        }

        /// <summary>
        /// Get a gateway by id in a private cloud workload network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/default/gateways/{gatewayId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_GetGateway</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkGatewayResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="gatewayId"> NSX Gateway identifier. Generally the same as the Gateway's display name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="gatewayId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="gatewayId"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<WorkloadNetworkGatewayResource>> GetWorkloadNetworkGatewayAsync(string gatewayId, CancellationToken cancellationToken = default)
        {
            return await GetWorkloadNetwork().GetWorkloadNetworkGateways().GetAsync(gatewayId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a collection of WorkloadNetworkGatewayResources in the AvsPrivateCloud. </summary>
        /// <returns> An object representing collection of WorkloadNetworkGatewayResources and their operations over a WorkloadNetworkGatewayResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual WorkloadNetworkGatewayCollection GetWorkloadNetworkGateways()
        {
            return GetWorkloadNetwork().GetWorkloadNetworkGateways();
        }

        /// <summary>
        /// Get a port mirroring profile by id in a private cloud workload network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/default/portMirroringProfiles/{portMirroringId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_GetPortMirroring</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkPortMirroringProfileResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="portMirroringId"> NSX Port Mirroring identifier. Generally the same as the Port Mirroring display name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="portMirroringId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="portMirroringId"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<WorkloadNetworkPortMirroringProfileResource> GetWorkloadNetworkPortMirroringProfile(string portMirroringId, CancellationToken cancellationToken = default)
        {
            return GetWorkloadNetwork().GetWorkloadNetworkPortMirroringProfiles().Get(portMirroringId, cancellationToken);
        }

        /// <summary>
        /// Get a port mirroring profile by id in a private cloud workload network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/default/portMirroringProfiles/{portMirroringId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_GetPortMirroring</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkPortMirroringProfileResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="portMirroringId"> NSX Port Mirroring identifier. Generally the same as the Port Mirroring display name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="portMirroringId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="portMirroringId"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<WorkloadNetworkPortMirroringProfileResource>> GetWorkloadNetworkPortMirroringProfileAsync(string portMirroringId, CancellationToken cancellationToken = default)
        {
            return await GetWorkloadNetwork().GetWorkloadNetworkPortMirroringProfiles().GetAsync(portMirroringId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a collection of WorkloadNetworkPortMirroringProfileResources in the AvsPrivateCloud. </summary>
        /// <returns> An object representing collection of WorkloadNetworkPortMirroringProfileResources and their operations over a WorkloadNetworkPortMirroringProfileResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual WorkloadNetworkPortMirroringProfileCollection GetWorkloadNetworkPortMirroringProfiles()
        {
            return GetWorkloadNetwork().GetWorkloadNetworkPortMirroringProfiles();
        }

        /// <summary>
        /// Get a Public IP Block by id in a private cloud workload network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/default/publicIPs/{publicIPId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_GetPublicIP</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkPublicIPResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="publicIPId"> NSX Public IP Block identifier. Generally the same as the Public IP Block's display name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="publicIPId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="publicIPId"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<WorkloadNetworkPublicIPResource> GetWorkloadNetworkPublicIP(string publicIPId, CancellationToken cancellationToken = default)
        {
            return GetWorkloadNetwork().GetWorkloadNetworkPublicIPs().Get(publicIPId, cancellationToken);
        }

        /// <summary>
        /// Get a Public IP Block by id in a private cloud workload network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/default/publicIPs/{publicIPId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_GetPublicIP</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkPublicIPResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="publicIPId"> NSX Public IP Block identifier. Generally the same as the Public IP Block's display name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="publicIPId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="publicIPId"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<WorkloadNetworkPublicIPResource>> GetWorkloadNetworkPublicIPAsync(string publicIPId, CancellationToken cancellationToken = default)
        {
            return await GetWorkloadNetwork().GetWorkloadNetworkPublicIPs().GetAsync(publicIPId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a collection of WorkloadNetworkPublicIPResources in the AvsPrivateCloud. </summary>
        /// <returns> An object representing collection of WorkloadNetworkPublicIPResources and their operations over a WorkloadNetworkPublicIPResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual WorkloadNetworkPublicIPCollection GetWorkloadNetworkPublicIPs()
        {
            return GetWorkloadNetwork().GetWorkloadNetworkPublicIPs();
        }

        /// <summary>
        /// Get a segment by id in a private cloud workload network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/default/segments/{segmentId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_GetSegment</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkSegmentResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="segmentId"> NSX Segment identifier. Generally the same as the Segment's display name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="segmentId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="segmentId"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<WorkloadNetworkSegmentResource> GetWorkloadNetworkSegment(string segmentId, CancellationToken cancellationToken = default)
        {
            return GetWorkloadNetwork().GetWorkloadNetworkSegments().Get(segmentId, cancellationToken);
        }

        /// <summary>
        /// Get a segment by id in a private cloud workload network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/default/segments/{segmentId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_GetSegment</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkSegmentResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="segmentId"> NSX Segment identifier. Generally the same as the Segment's display name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="segmentId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="segmentId"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<WorkloadNetworkSegmentResource>> GetWorkloadNetworkSegmentAsync(string segmentId, CancellationToken cancellationToken = default)
        {
            return await GetWorkloadNetwork().GetWorkloadNetworkSegments().GetAsync(segmentId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a collection of WorkloadNetworkSegmentResources in the AvsPrivateCloud. </summary>
        /// <returns> An object representing collection of WorkloadNetworkSegmentResources and their operations over a WorkloadNetworkSegmentResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual WorkloadNetworkSegmentCollection GetWorkloadNetworkSegments()
        {
            return GetWorkloadNetwork().GetWorkloadNetworkSegments();
        }

        /// <summary>
        /// Get a virtual machine by id in a private cloud workload network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/default/virtualMachines/{virtualMachineId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_GetVirtualMachine</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkVirtualMachineResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="virtualMachineId"> Virtual Machine identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualMachineId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="virtualMachineId"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<WorkloadNetworkVirtualMachineResource> GetWorkloadNetworkVirtualMachine(string virtualMachineId, CancellationToken cancellationToken = default)
        {
            return GetWorkloadNetwork().GetWorkloadNetworkVirtualMachines().Get(virtualMachineId, cancellationToken);
        }

        /// <summary>
        /// Get a virtual machine by id in a private cloud workload network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/default/virtualMachines/{virtualMachineId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_GetVirtualMachine</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkVirtualMachineResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="virtualMachineId"> Virtual Machine identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualMachineId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="virtualMachineId"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<WorkloadNetworkVirtualMachineResource>> GetWorkloadNetworkVirtualMachineAsync(string virtualMachineId, CancellationToken cancellationToken = default)
        {
            return await GetWorkloadNetwork().GetWorkloadNetworkVirtualMachines().GetAsync(virtualMachineId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a collection of WorkloadNetworkVirtualMachineResources in the AvsPrivateCloud. </summary>
        /// <returns> An object representing collection of WorkloadNetworkVirtualMachineResources and their operations over a WorkloadNetworkVirtualMachineResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual WorkloadNetworkVirtualMachineCollection GetWorkloadNetworkVirtualMachines()
        {
            return GetWorkloadNetwork().GetWorkloadNetworkVirtualMachines();
        }

        /// <summary>
        /// Get a vm group by id in a private cloud workload network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/default/vmGroups/{vmGroupId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_GetVmGroup</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkVmGroupResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="vmGroupId"> NSX VM Group identifier. Generally the same as the VM Group's display name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmGroupId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vmGroupId"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<WorkloadNetworkVmGroupResource> GetWorkloadNetworkVmGroup(string vmGroupId, CancellationToken cancellationToken = default)
        {
            return GetWorkloadNetwork().GetWorkloadNetworkVmGroups().Get(vmGroupId, cancellationToken);
        }

        /// <summary>
        /// Get a vm group by id in a private cloud workload network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/workloadNetworks/default/vmGroups/{vmGroupId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WorkloadNetworks_GetVmGroup</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="WorkloadNetworkVmGroupResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="vmGroupId"> NSX VM Group identifier. Generally the same as the VM Group's display name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vmGroupId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vmGroupId"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<WorkloadNetworkVmGroupResource>> GetWorkloadNetworkVmGroupAsync(string vmGroupId, CancellationToken cancellationToken = default)
        {
            return await GetWorkloadNetwork().GetWorkloadNetworkVmGroups().GetAsync(vmGroupId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a collection of WorkloadNetworkVmGroupResources in the AvsPrivateCloud. </summary>
        /// <returns> An object representing collection of WorkloadNetworkVmGroupResources and their operations over a WorkloadNetworkVmGroupResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual WorkloadNetworkVmGroupCollection GetWorkloadNetworkVmGroups()
        {
            return GetWorkloadNetwork().GetWorkloadNetworkVmGroups();
        }
    }
}
