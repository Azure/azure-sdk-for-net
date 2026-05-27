// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.ManagedNetworkFabric.Models;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    // Backward compatibility shim for the TypeSpec migration. The new generator does not synthesize the
    // same convenience constructor from the flattened properties. Removing this file would drop the shipped
    // constructor used by callers to create a minimal NetworkFabricData instance.
    public partial class NetworkFabricData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkFabricData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkFabricData(AzureLocation location, string networkFabricSku, ResourceIdentifier networkFabricControllerId, int serverCountPerRack, string ipv4Prefix, long fabricAsn, TerminalServerConfiguration terminalServerConfiguration, ManagementNetworkConfigurationProperties managementNetworkConfiguration)
            : base(location)
        {
            NetworkFabricSku = networkFabricSku;
            NetworkFabricControllerId = networkFabricControllerId;
            ServerCountPerRack = serverCountPerRack;
            IPv4Prefix = ipv4Prefix;
            FabricAsn = fabricAsn;
            TerminalServerConfiguration = terminalServerConfiguration;
            ManagementNetworkConfiguration = managementNetworkConfiguration;
        }
    }
}
