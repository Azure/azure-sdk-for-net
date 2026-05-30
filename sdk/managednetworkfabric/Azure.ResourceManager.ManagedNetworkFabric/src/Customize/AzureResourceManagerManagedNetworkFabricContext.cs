// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using Azure.ResourceManager.ManagedNetworkFabric.Models;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
#pragma warning disable CS0618 // Register obsolete compatibility models for ModelReaderWriter.
    [ModelReaderWriterBuildable(typeof(InternalNetworkBgpConfiguration))]
    [ModelReaderWriterBuildable(typeof(InternalNetworkStaticRouteConfiguration))]
    [ModelReaderWriterBuildable(typeof(NetworkToNetworkInterconnectOptionBLayer3Configuration))]
    [ModelReaderWriterBuildable(typeof(NetworkTapPatchableParametersDestinationsItem))]
    [ModelReaderWriterBuildable(typeof(NetworkTapPropertiesDestinationsItem))]
    [ModelReaderWriterBuildable(typeof(NetworkFabricPatchablePropertiesTerminalServerConfiguration))]
    [ModelReaderWriterBuildable(typeof(TerminalServerPatchableProperties))]
    [ModelReaderWriterBuildable(typeof(TerminalServerConfiguration))]
    [ModelReaderWriterBuildable(typeof(VpnConfigurationPatchableOptionAProperties))]
    [ModelReaderWriterBuildable(typeof(VpnConfigurationOptionAProperties))]
    [ModelReaderWriterBuildable(typeof(OptionAProperties))]
    [ModelReaderWriterBuildable(typeof(NetworkDevicePatch))]
    [ModelReaderWriterBuildable(typeof(NetworkFabricAccessControlListPatch))]
    [ModelReaderWriterBuildable(typeof(NetworkFabricControllerPatch))]
    [ModelReaderWriterBuildable(typeof(NetworkFabricInternetGatewayPatch))]
    [ModelReaderWriterBuildable(typeof(NetworkFabricInternetGatewayRulePatch))]
    [ModelReaderWriterBuildable(typeof(NetworkFabricIPCommunityPatch))]
    [ModelReaderWriterBuildable(typeof(NetworkFabricIPExtendedCommunityPatch))]
    [ModelReaderWriterBuildable(typeof(NetworkFabricIPPrefixPatch))]
    [ModelReaderWriterBuildable(typeof(NetworkFabricL2IsolationDomainPatch))]
    [ModelReaderWriterBuildable(typeof(NetworkFabricL3IsolationDomainPatch))]
    [ModelReaderWriterBuildable(typeof(NetworkFabricNeighborGroupPatch))]
    [ModelReaderWriterBuildable(typeof(NetworkFabricPatch))]
    [ModelReaderWriterBuildable(typeof(NetworkFabricRoutePolicyPatch))]
    [ModelReaderWriterBuildable(typeof(NetworkPacketBrokerPatch))]
    [ModelReaderWriterBuildable(typeof(NetworkTapPatch))]
    [ModelReaderWriterBuildable(typeof(NetworkTapRulePatch))]
    [ModelReaderWriterBuildable(typeof(NetworkFabricOperationStatusResult))]
#pragma warning restore CS0618
    public partial class AzureResourceManagerManagedNetworkFabricContext
    {
    }
}
