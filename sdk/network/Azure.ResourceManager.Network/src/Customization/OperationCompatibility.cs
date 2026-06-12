// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    public partial class AzureFirewallCollection
    {
        [global::Azure.Core.ForwardsClientCalls]
        public virtual Task<ArmOperation<AzureFirewallResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string azureFirewallName, AzureFirewallData data, CancellationToken cancellationToken)
            => CreateOrUpdateAsync(waitUntil, azureFirewallName, data, createAfcControlPlane: default, cancellationToken);

        [global::Azure.Core.ForwardsClientCalls]
        public virtual ArmOperation<AzureFirewallResource> CreateOrUpdate(WaitUntil waitUntil, string azureFirewallName, AzureFirewallData data, CancellationToken cancellationToken)
            => CreateOrUpdate(waitUntil, azureFirewallName, data, createAfcControlPlane: default, cancellationToken);
    }

    public partial class AzureFirewallResource
    {
        public virtual Task<ArmOperation> PacketCaptureAsync(WaitUntil waitUntil, FirewallPacketCaptureRequestContent content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation PacketCapture(WaitUntil waitUntil, FirewallPacketCaptureRequestContent content, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<AzureFirewallPacketCaptureResult>> PacketCaptureOperationAsync(WaitUntil waitUntil, FirewallPacketCaptureRequestContent content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<AzureFirewallPacketCaptureResult> PacketCaptureOperation(WaitUntil waitUntil, FirewallPacketCaptureRequestContent content, CancellationToken cancellationToken) => default;
    }

    public partial class BackendAddressPoolResource
    {
        public virtual Task<ArmOperation<BackendAddressInboundNatRulePortMappings>> GetInboundNatRulePortMappingsLoadBalancerAsync(WaitUntil waitUntil, QueryInboundNatRulePortMappingContent content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<BackendAddressInboundNatRulePortMappings> GetInboundNatRulePortMappingsLoadBalancer(WaitUntil waitUntil, QueryInboundNatRulePortMappingContent content, CancellationToken cancellationToken) => default;
    }

    public partial class BastionHostResource
    {
        public virtual Task<ArmOperation<BastionHostResource>> UpdateAsync(WaitUntil waitUntil, BastionHostData data, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<BastionHostResource> Update(WaitUntil waitUntil, BastionHostData data, CancellationToken cancellationToken) => default;
    }

    public partial class BgpConnectionResource
    {
        public virtual Task<ArmOperation<PeerRouteList>> GetAdvertisedRoutesVirtualHubBgpConnectionAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<PeerRouteList> GetAdvertisedRoutesVirtualHubBgpConnection(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<PeerRouteList>> GetLearnedRoutesVirtualHubBgpConnectionAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<PeerRouteList> GetLearnedRoutesVirtualHubBgpConnection(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<IDictionary<string, IList<PeerRoute>>>> GetVirtualHubBgpConnectionAdvertisedRoutesAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<IDictionary<string, IList<PeerRoute>>> GetVirtualHubBgpConnectionAdvertisedRoutes(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<IDictionary<string, IList<PeerRoute>>>> GetVirtualHubBgpConnectionLearnedRoutesAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<IDictionary<string, IList<PeerRoute>>> GetVirtualHubBgpConnectionLearnedRoutes(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
    }

    public partial class ConnectionMonitorCollection
    {
        public virtual Task<ArmOperation<ConnectionMonitorResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string connectionMonitorName, ConnectionMonitorCreateOrUpdateContent content, string migrate, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<ConnectionMonitorResource> CreateOrUpdate(WaitUntil waitUntil, string connectionMonitorName, ConnectionMonitorCreateOrUpdateContent content, string migrate, CancellationToken cancellationToken) => default;
    }

    public partial class ConnectionMonitorResource
    {
        public virtual Task<ArmOperation<ConnectionMonitorQueryResult>> QueryAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<ConnectionMonitorQueryResult> Query(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation> StartAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        public virtual ArmOperation Start(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
    }

    public partial class ExpressRouteCircuitPeeringResource
    {
        public virtual Task<ArmOperation<ExpressRouteCircuitsArpTableListResult>> GetArpTableExpressRouteCircuitAsync(WaitUntil waitUntil, string devicePath, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<ExpressRouteCircuitsArpTableListResult> GetArpTableExpressRouteCircuit(WaitUntil waitUntil, string devicePath, CancellationToken cancellationToken) => default;
        public virtual Task<Response<ExpressRouteCircuitStats>> GetPeeringStatsExpressRouteCircuitAsync(CancellationToken cancellationToken) => default;
        public virtual Response<ExpressRouteCircuitStats> GetPeeringStatsExpressRouteCircuit(CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<ExpressRouteCircuitsRoutesTableListResult>> GetRoutesTableExpressRouteCircuitAsync(WaitUntil waitUntil, string devicePath, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<ExpressRouteCircuitsRoutesTableListResult> GetRoutesTableExpressRouteCircuit(WaitUntil waitUntil, string devicePath, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<ExpressRouteCircuitsRoutesTableSummaryListResult>> GetRoutesTableSummaryExpressRouteCircuitAsync(WaitUntil waitUntil, string devicePath, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<ExpressRouteCircuitsRoutesTableSummaryListResult> GetRoutesTableSummaryExpressRouteCircuit(WaitUntil waitUntil, string devicePath, CancellationToken cancellationToken) => default;
    }

    public partial class ExpressRouteCrossConnectionPeeringResource
    {
        public virtual Task<ArmOperation<ExpressRouteCircuitsArpTableListResult>> GetArpTableExpressRouteCrossConnectionAsync(WaitUntil waitUntil, string devicePath, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<ExpressRouteCircuitsArpTableListResult> GetArpTableExpressRouteCrossConnection(WaitUntil waitUntil, string devicePath, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<ExpressRouteCircuitsRoutesTableListResult>> GetRoutesTableExpressRouteCrossConnectionAsync(WaitUntil waitUntil, string devicePath, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<ExpressRouteCircuitsRoutesTableListResult> GetRoutesTableExpressRouteCrossConnection(WaitUntil waitUntil, string devicePath, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<ExpressRouteCrossConnectionsRoutesTableSummaryListResult>> GetRoutesTableSummaryExpressRouteCrossConnectionAsync(WaitUntil waitUntil, string devicePath, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<ExpressRouteCrossConnectionsRoutesTableSummaryListResult> GetRoutesTableSummaryExpressRouteCrossConnection(WaitUntil waitUntil, string devicePath, CancellationToken cancellationToken) => default;
    }

    public partial class ExpressRoutePortResource
    {
        public virtual ExpressRoutePortAuthorizationCollection GetExpressRoutePortAuthorizations()
        {
            var resourceGroup = Client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName));
            return resourceGroup.GetExpressRoutePortAuthorizations(Id.Name);
        }

        [ForwardsClientCalls]
        public virtual Task<Response<ExpressRoutePortAuthorizationResource>> GetExpressRoutePortAuthorizationAsync(string authorizationName, CancellationToken cancellationToken = default)
            => GetExpressRoutePortAuthorizations().GetAsync(authorizationName, cancellationToken);

        [ForwardsClientCalls]
        public virtual Response<ExpressRoutePortAuthorizationResource> GetExpressRoutePortAuthorization(string authorizationName, CancellationToken cancellationToken = default)
            => GetExpressRoutePortAuthorizations().Get(authorizationName, cancellationToken);

        public virtual Task<Response<GenerateExpressRoutePortsLoaResult>> GenerateLoaAsync(GenerateExpressRoutePortsLoaContent content, CancellationToken cancellationToken) => default;
        public virtual Response<GenerateExpressRoutePortsLoaResult> GenerateLoa(GenerateExpressRoutePortsLoaContent content, CancellationToken cancellationToken) => default;
    }

    public partial class FirewallPolicyResource
    {
        [global::Azure.Core.ForwardsClientCalls]
        public virtual Task<ArmOperation> DeployFirewallPolicyDeploymentAsync(WaitUntil waitUntil, CancellationToken cancellationToken)
            => DeployAsync(waitUntil, cancellationToken);

        [global::Azure.Core.ForwardsClientCalls]
        public virtual ArmOperation DeployFirewallPolicyDeployment(WaitUntil waitUntil, CancellationToken cancellationToken)
            => Deploy(waitUntil, cancellationToken);

        public virtual Task<Response<IdpsSignatureListResult>> GetFirewallPolicyIdpsSignatureAsync(IdpsQueryContent content, CancellationToken cancellationToken) => default;
        public virtual Response<IdpsSignatureListResult> GetFirewallPolicyIdpsSignature(IdpsQueryContent content, CancellationToken cancellationToken) => default;
        public virtual Task<Response<SignatureOverridesFilterValuesResult>> GetFirewallPolicyIdpsSignaturesFilterValueAsync(SignatureOverridesFilterValuesQueryContent content, CancellationToken cancellationToken) => default;
        public virtual Response<SignatureOverridesFilterValuesResult> GetFirewallPolicyIdpsSignaturesFilterValue(SignatureOverridesFilterValuesQueryContent content, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<FirewallPolicyResource>> UpdateAsync(WaitUntil waitUntil, FirewallPolicyData data, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<FirewallPolicyResource> Update(WaitUntil waitUntil, FirewallPolicyData data, CancellationToken cancellationToken) => default;
    }

    public partial class IpamPoolCollection
    {
        public virtual Task<ArmOperation<IpamPoolResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string ipamPoolName, IpamPoolData data, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<IpamPoolResource> CreateOrUpdate(WaitUntil waitUntil, string ipamPoolName, IpamPoolData data, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<IpamPoolResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string ipamPoolName, IpamPoolData data, string ifMatch, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<IpamPoolResource> CreateOrUpdate(WaitUntil waitUntil, string ipamPoolName, IpamPoolData data, string ifMatch, CancellationToken cancellationToken) => default;
    }

    public partial class IpamPoolResource
    {
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, string ifMatch, CancellationToken cancellationToken) => default;
        public virtual ArmOperation Delete(WaitUntil waitUntil, string ifMatch, CancellationToken cancellationToken) => default;
        public virtual Task<Response<IpamPoolResource>> UpdateAsync(IpamPoolPatch patch, CancellationToken cancellationToken) => default;
        public virtual Response<IpamPoolResource> Update(IpamPoolPatch patch, CancellationToken cancellationToken) => default;
        public virtual Task<Response<IpamPoolResource>> UpdateAsync(IpamPoolPatch patch, string ifMatch, CancellationToken cancellationToken) => default;
        public virtual Response<IpamPoolResource> Update(IpamPoolPatch patch, string ifMatch, CancellationToken cancellationToken) => default;
    }

    public partial class ManagementGroupNetworkManagerConnectionCollection
    {
        public virtual Task<ArmOperation<ManagementGroupNetworkManagerConnectionResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string networkManagerConnectionName, NetworkManagerConnectionData data, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<ManagementGroupNetworkManagerConnectionResource> CreateOrUpdate(WaitUntil waitUntil, string networkManagerConnectionName, NetworkManagerConnectionData data, CancellationToken cancellationToken) => default;
    }

    public partial class ManagementGroupNetworkManagerConnectionResource
    {
        public virtual Task<ArmOperation<ManagementGroupNetworkManagerConnectionResource>> UpdateAsync(WaitUntil waitUntil, NetworkManagerConnectionData data, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<ManagementGroupNetworkManagerConnectionResource> Update(WaitUntil waitUntil, NetworkManagerConnectionData data, CancellationToken cancellationToken) => default;
    }

    public partial class NetworkGroupCollection
    {
        public virtual Task<ArmOperation<NetworkGroupResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string networkGroupName, NetworkGroupData data, string ifMatch, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<NetworkGroupResource> CreateOrUpdate(WaitUntil waitUntil, string networkGroupName, NetworkGroupData data, string ifMatch, CancellationToken cancellationToken) => default;
    }

    public partial class NetworkGroupResource
    {
        public virtual Task<ArmOperation<NetworkGroupResource>> UpdateAsync(WaitUntil waitUntil, NetworkGroupData data, string ifMatch, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<NetworkGroupResource> Update(WaitUntil waitUntil, NetworkGroupData data, string ifMatch, CancellationToken cancellationToken) => default;
    }

    public partial class NetworkManagerResource
    {
        public virtual Task<ArmOperation<NetworkManagerCommit>> PostNetworkManagerCommitAsync(WaitUntil waitUntil, NetworkManagerCommit content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<NetworkManagerCommit> PostNetworkManagerCommit(WaitUntil waitUntil, NetworkManagerCommit content, CancellationToken cancellationToken) => default;
    }

    public partial class NetworkVerifierWorkspaceCollection
    {
        public virtual Task<ArmOperation<NetworkVerifierWorkspaceResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string networkVerifierWorkspaceName, NetworkVerifierWorkspaceData data, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<NetworkVerifierWorkspaceResource> CreateOrUpdate(WaitUntil waitUntil, string networkVerifierWorkspaceName, NetworkVerifierWorkspaceData data, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<NetworkVerifierWorkspaceResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string networkVerifierWorkspaceName, NetworkVerifierWorkspaceData data, string ifMatch, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<NetworkVerifierWorkspaceResource> CreateOrUpdate(WaitUntil waitUntil, string networkVerifierWorkspaceName, NetworkVerifierWorkspaceData data, string ifMatch, CancellationToken cancellationToken) => default;
    }

    public partial class NetworkVerifierWorkspaceResource
    {
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, string ifMatch, CancellationToken cancellationToken) => default;
        public virtual ArmOperation Delete(WaitUntil waitUntil, string ifMatch, CancellationToken cancellationToken) => default;
        public virtual Task<Response<NetworkVerifierWorkspaceResource>> UpdateAsync(NetworkVerifierWorkspacePatch patch, CancellationToken cancellationToken) => default;
        public virtual Response<NetworkVerifierWorkspaceResource> Update(NetworkVerifierWorkspacePatch patch, CancellationToken cancellationToken) => default;
        public virtual Task<Response<NetworkVerifierWorkspaceResource>> UpdateAsync(NetworkVerifierWorkspacePatch patch, string ifMatch, CancellationToken cancellationToken) => default;
        public virtual Response<NetworkVerifierWorkspaceResource> Update(NetworkVerifierWorkspacePatch patch, string ifMatch, CancellationToken cancellationToken) => default;
    }

    public partial class NetworkVirtualApplianceResource
    {
        public virtual Task<Response> RestartAsync(NetworkVirtualApplianceInstanceIds content, CancellationToken cancellationToken) => default;
        public virtual Response Restart(NetworkVirtualApplianceInstanceIds content, CancellationToken cancellationToken) => default;
    }

    public partial class P2SVpnGatewayResource
    {
        public virtual Task<ArmOperation> DisconnectP2SVpnConnectionsAsync(WaitUntil waitUntil, P2SVpnConnectionRequest content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation DisconnectP2SVpnConnections(WaitUntil waitUntil, P2SVpnConnectionRequest content, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<P2SVpnGatewayResource>> GetP2SVpnConnectionHealthAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<P2SVpnGatewayResource> GetP2SVpnConnectionHealth(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<P2SVpnConnectionHealth>> GetP2SVpnConnectionHealthDetailedAsync(WaitUntil waitUntil, P2SVpnConnectionHealthContent content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<P2SVpnConnectionHealth> GetP2SVpnConnectionHealthDetailed(WaitUntil waitUntil, P2SVpnConnectionHealthContent content, CancellationToken cancellationToken) => default;
    }

    public partial class PacketCaptureCollection
    {
        public virtual Task<ArmOperation<PacketCaptureResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string packetCaptureName, PacketCaptureCreateOrUpdateContent content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<PacketCaptureResource> CreateOrUpdate(WaitUntil waitUntil, string packetCaptureName, PacketCaptureCreateOrUpdateContent content, CancellationToken cancellationToken) => default;
    }

    public partial class PacketCaptureResource
    {
        public virtual Task<ArmOperation<PacketCaptureResource>> UpdateAsync(WaitUntil waitUntil, PacketCaptureCreateOrUpdateContent content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<PacketCaptureResource> Update(WaitUntil waitUntil, PacketCaptureCreateOrUpdateContent content, CancellationToken cancellationToken) => default;
    }

    public partial class PublicIPAddressResource
    {
        public virtual Task<ArmOperation<PublicIPAddressResource>> DisassociateCloudServiceReservedPublicIPAsync(WaitUntil waitUntil, DisassociateCloudServicePublicIPContent content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<PublicIPAddressResource> DisassociateCloudServiceReservedPublicIP(WaitUntil waitUntil, DisassociateCloudServicePublicIPContent content, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<PublicIPAddressResource>> ReserveCloudServicePublicIPAddressAsync(WaitUntil waitUntil, ReserveCloudServicePublicIPAddressContent content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<PublicIPAddressResource> ReserveCloudServicePublicIPAddress(WaitUntil waitUntil, ReserveCloudServicePublicIPAddressContent content, CancellationToken cancellationToken) => default;
    }

    public partial class SubscriptionNetworkManagerConnectionCollection
    {
        public virtual Task<ArmOperation<SubscriptionNetworkManagerConnectionResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string networkManagerConnectionName, NetworkManagerConnectionData data, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<SubscriptionNetworkManagerConnectionResource> CreateOrUpdate(WaitUntil waitUntil, string networkManagerConnectionName, NetworkManagerConnectionData data, CancellationToken cancellationToken) => default;
    }

    public partial class SubscriptionNetworkManagerConnectionResource
    {
        public virtual Task<ArmOperation<SubscriptionNetworkManagerConnectionResource>> UpdateAsync(WaitUntil waitUntil, NetworkManagerConnectionData data, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<SubscriptionNetworkManagerConnectionResource> Update(WaitUntil waitUntil, NetworkManagerConnectionData data, CancellationToken cancellationToken) => default;
    }

    [CodeGenSuppress("GetEffectiveVirtualHubRoutesAsync", typeof(WaitUntil), typeof(EffectiveRoutesContent), typeof(CancellationToken))]
    [CodeGenSuppress("GetEffectiveVirtualHubRoutes", typeof(WaitUntil), typeof(EffectiveRoutesContent), typeof(CancellationToken))]
    [CodeGenSuppress("GetInboundRoutesAsync", typeof(WaitUntil), typeof(VirtualHubInboundRoutesContent), typeof(CancellationToken))]
    [CodeGenSuppress("GetInboundRoutes", typeof(WaitUntil), typeof(VirtualHubInboundRoutesContent), typeof(CancellationToken))]
    [CodeGenSuppress("GetOutboundRoutesAsync", typeof(WaitUntil), typeof(VirtualHubOutboundRoutesContent), typeof(CancellationToken))]
    [CodeGenSuppress("GetOutboundRoutes", typeof(WaitUntil), typeof(VirtualHubOutboundRoutesContent), typeof(CancellationToken))]
    public partial class VirtualHubResource
    {
        public virtual Task<ArmOperation> GetEffectiveVirtualHubRoutesAsync(WaitUntil waitUntil, EffectiveRoutesContent content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation GetEffectiveVirtualHubRoutes(WaitUntil waitUntil, EffectiveRoutesContent content, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation> GetInboundRoutesAsync(WaitUntil waitUntil, VirtualHubInboundRoutesContent content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation GetInboundRoutes(WaitUntil waitUntil, VirtualHubInboundRoutesContent content, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation> GetOutboundRoutesAsync(WaitUntil waitUntil, VirtualHubOutboundRoutesContent content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation GetOutboundRoutes(WaitUntil waitUntil, VirtualHubOutboundRoutesContent content, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<VirtualHubEffectiveRouteList>> GetVirtualHubEffectiveRoutesAsync(WaitUntil waitUntil, EffectiveRoutesContent content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<VirtualHubEffectiveRouteList> GetVirtualHubEffectiveRoutes(WaitUntil waitUntil, EffectiveRoutesContent content, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<EffectiveRouteMapRouteList>> GetVirtualHubInboundRoutesAsync(WaitUntil waitUntil, VirtualHubInboundRoutesContent content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<EffectiveRouteMapRouteList> GetVirtualHubInboundRoutes(WaitUntil waitUntil, VirtualHubInboundRoutesContent content, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<EffectiveRouteMapRouteList>> GetVirtualHubOutboundRoutesAsync(WaitUntil waitUntil, VirtualHubOutboundRoutesContent content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<EffectiveRouteMapRouteList> GetVirtualHubOutboundRoutes(WaitUntil waitUntil, VirtualHubOutboundRoutesContent content, CancellationToken cancellationToken) => default;
    }

    public partial class VirtualNetworkGatewayConnectionResource
    {
        public virtual Task<ArmOperation<string>> StartPacketCaptureAsync(WaitUntil waitUntil, VpnPacketCaptureStartParameters content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<string> StartPacketCapture(WaitUntil waitUntil, VpnPacketCaptureStartParameters content, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<string>> StopPacketCaptureAsync(WaitUntil waitUntil, VpnPacketCaptureStopParameters content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<string> StopPacketCapture(WaitUntil waitUntil, VpnPacketCaptureStopParameters content, CancellationToken cancellationToken) => default;
    }

    public partial class VirtualNetworkGatewayResource
    {
        public virtual Task<ArmOperation<string>> GenerateVpnClientPackageAsync(WaitUntil waitUntil, VpnClientContent content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<string> GenerateVpnClientPackage(WaitUntil waitUntil, VpnClientContent content, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<string>> GenerateVpnProfileAsync(WaitUntil waitUntil, VpnClientParameters content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<string> GenerateVpnProfile(WaitUntil waitUntil, VpnClientParameters content, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<string>> GeneratevpnclientpackageAsync(WaitUntil waitUntil, VpnClientParameters content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<string> Generatevpnclientpackage(WaitUntil waitUntil, VpnClientParameters content, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<VpnClientIPsecParameters>> GetVpnclientIPsecParametersAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<VpnClientIPsecParameters> GetVpnclientIPsecParameters(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<VpnClientIPsecParameters>> SetVpnclientIPsecParametersAsync(WaitUntil waitUntil, VpnClientIPsecParameters content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<VpnClientIPsecParameters> SetVpnclientIPsecParameters(WaitUntil waitUntil, VpnClientIPsecParameters content, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<string>> StartPacketCaptureAsync(WaitUntil waitUntil, VpnPacketCaptureStartParameters content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<string> StartPacketCapture(WaitUntil waitUntil, VpnPacketCaptureStartParameters content, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<string>> StopPacketCaptureAsync(WaitUntil waitUntil, VpnPacketCaptureStopParameters content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<string> StopPacketCapture(WaitUntil waitUntil, VpnPacketCaptureStopParameters content, CancellationToken cancellationToken) => default;
    }

    public partial class VirtualWanResource
    {
        public virtual Task<ArmOperation> DownloadVpnSitesConfigurationAsync(WaitUntil waitUntil, GetVpnSitesConfigurationContent content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation DownloadVpnSitesConfiguration(WaitUntil waitUntil, GetVpnSitesConfigurationContent content, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<VpnProfileResponse>> GenerateVirtualWanVpnServerConfigurationVpnProfileAsync(WaitUntil waitUntil, VirtualWanVpnProfileContent content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<VpnProfileResponse> GenerateVirtualWanVpnServerConfigurationVpnProfile(WaitUntil waitUntil, VirtualWanVpnProfileContent content, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<VpnServerConfigurationsResponse>> GetVpnServerConfigurationsAssociatedWithVirtualWanAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<VpnServerConfigurationsResponse> GetVpnServerConfigurationsAssociatedWithVirtualWan(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
    }

    public partial class VpnGatewayResource
    {
        public virtual Task<ArmOperation<VpnGatewayResource>> ResetAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<VpnGatewayResource> Reset(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
    }

    public partial class VpnSiteLinkConnectionResource
    {
        public virtual Task<ArmOperation<string>> GetIkeSasVpnLinkConnectionAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<string> GetIkeSasVpnLinkConnection(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation> ResetConnectionVpnLinkConnectionAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        public virtual ArmOperation ResetConnectionVpnLinkConnection(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
    }
}
