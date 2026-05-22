// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.ManagedNetworkFabric.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    // Backward compatibility shims for the TypeSpec migration. These preserve old acronym-cased
    // members that now generate with .NET-standard Ipv4/Ipv6/ASN casing.
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
            Ipv4Prefix = ipv4Prefix;
            FabricASN = fabricAsn;
            TerminalServerConfiguration = terminalServerConfiguration;
            ManagementNetworkConfiguration = managementNetworkConfiguration;
        }

        /// <summary> Network and credentials configuration currently applied to terminal server. </summary>
        [CodeGenMember("TerminalServerConfiguration")]
        public TerminalServerConfiguration TerminalServerConfiguration
        {
            get => Properties?.TerminalServerConfiguration as TerminalServerConfiguration;
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricProperties();
                }
                Properties.TerminalServerConfiguration = value;
            }
        }

        /// <summary> Configuration to be used to setup the management network. </summary>
        [CodeGenMember("ManagementNetworkConfiguration")]
        public ManagementNetworkConfigurationProperties ManagementNetworkConfiguration
        {
            get => Properties?.ManagementNetworkConfiguration as ManagementNetworkConfigurationProperties;
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricProperties();
                }
                Properties.ManagementNetworkConfiguration = value;
            }
        }

        /// <summary> ASN of CE devices for CE/PE connectivity. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("FabricAsn is deprecated, use FabricASN instead.")]
        public long FabricAsn
        {
            get => FabricASN;
            set => FabricASN = value;
        }

        /// <summary> IPv4Prefix for Management Network. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("IPv4Prefix is deprecated, use Ipv4Prefix instead.")]
        public string IPv4Prefix
        {
            get => Ipv4Prefix;
            set => Ipv4Prefix = value;
        }

        /// <summary> IPv6Prefix for Management Network. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("IPv6Prefix is deprecated, use Ipv6Prefix instead.")]
        public string IPv6Prefix
        {
            get => Ipv6Prefix;
            set => Ipv6Prefix = value;
        }
    }
}
