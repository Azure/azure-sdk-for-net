// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // Backward compatibility shims for the TypeSpec migration. These preserve old acronym-cased
    // members and pre-migration property types.
    public partial class NetworkFabricPatch
    {
        /// <summary> ASN of CE devices for CE/PE connectivity. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("FabricAsn is deprecated, use FabricASN instead.")]
        public long? FabricAsn
        {
            get => FabricASN;
            set => FabricASN = value;
        }

        /// <summary> IPv4Prefix for Management Network. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("IPv4Prefix is deprecated, use Ipv4Prefix instead.")]
        public string IPv4Prefix
        {
            get => Properties is null ? default : Properties.Ipv4Prefix;
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                Properties.Ipv4Prefix = value;
            }
        }

        /// <summary> IPv6Prefix for Management Network. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("IPv6Prefix is deprecated, use Ipv6Prefix instead.")]
        public string IPv6Prefix
        {
            get => Properties is null ? default : Properties.Ipv6Prefix;
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                Properties.Ipv6Prefix = value;
            }
        }

        /// <summary> Network and credentials configuration already applied to terminal server. </summary>
        [CodeGenMember("TerminalServerConfiguration")]
        public NetworkFabricPatchablePropertiesTerminalServerConfiguration TerminalServerConfiguration
        {
            get => Properties?.TerminalServerConfiguration;
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                Properties.TerminalServerConfiguration = value;
            }
        }

        /// <summary> Configuration to be used to setup the management network. </summary>
        [CodeGenMember("ManagementNetworkConfiguration")]
        public ManagementNetworkConfigurationPatchableProperties ManagementNetworkConfiguration
        {
            get => Properties?.ManagementNetworkConfiguration is null
                ? default
                : new ManagementNetworkConfigurationPatchableProperties(Properties.ManagementNetworkConfiguration.InfrastructureVpnConfiguration, Properties.ManagementNetworkConfiguration.WorkloadVpnConfiguration, additionalBinaryDataProperties: null);
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                Properties.ManagementNetworkConfiguration = value is null
                    ? default
                    : new ManagementNetworkConfigurationPatchableProperties
                    {
                        InfrastructureVpnConfiguration = value.InfrastructureVpnConfiguration,
                        WorkloadVpnConfiguration = value.WorkloadVpnConfiguration
                    };
            }
        }
    }
}
