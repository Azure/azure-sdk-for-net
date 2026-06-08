// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.ManagedNetworkFabric.Models;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    public partial class NetworkFabricData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkFabricData"/>. </summary>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="networkFabricSku"> Supported Network Fabric SKU.Example: Compute / Aggregate racks. Once the user chooses a particular SKU, only supported racks can be added to the Network Fabric. The SKU determines whether it is a single / multi rack Network Fabric. </param>
        /// <param name="networkFabricControllerId"> Azure resource ID for the NetworkFabricController the NetworkFabric belongs. </param>
        /// <param name="serverCountPerRack"> Number of servers.Possible values are from 1-16. </param>
        /// <param name="iPv4Prefix"> IPv4Prefix for Management Network. Example: 10.1.0.0/19. </param>
        /// <param name="fabricAsn"> ASN of CE devices for CE/PE connectivity. </param>
        /// <param name="terminalServerConfiguration"> Network and credentials configuration currently applied to terminal server. </param>
        /// <param name="managementNetworkConfiguration"> Configuration to be used to setup the management network. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="networkFabricSku"/>, <paramref name="networkFabricControllerId"/>, <paramref name="iPv4Prefix"/>, <paramref name="terminalServerConfiguration"/> or <paramref name="managementNetworkConfiguration"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This constructor is obsolete and will be removed in a future version. Use the constructor with NetworkFabricTerminalServerConfiguration instead.")]
        public NetworkFabricData(AzureLocation location, string networkFabricSku, ResourceIdentifier networkFabricControllerId, int serverCountPerRack, string iPv4Prefix, long fabricAsn, TerminalServerConfiguration terminalServerConfiguration, ManagementNetworkConfigurationProperties managementNetworkConfiguration)
            : this(location, networkFabricSku, networkFabricControllerId, serverCountPerRack, iPv4Prefix, fabricAsn, terminalServerConfiguration?.ToNetworkFabricTerminalServerConfiguration(), managementNetworkConfiguration)
        {
        }

        /// <summary> Network and credentials configuration currently applied to terminal server. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use TerminalServerSettings instead.")]
        public TerminalServerConfiguration TerminalServerConfiguration
        {
            get => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use TerminalServerSettings instead.");
            set => throw new NotSupportedException("This property is obsolete and will be removed in a future version. Use TerminalServerSettings instead.");
        }
    }
}
