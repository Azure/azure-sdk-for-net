// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    /// <summary> Configuration to be used to setup the management network. </summary>
    public partial class ManagementNetworkConfigurationProperties : Azure.ResourceManager.ManagedNetworkFabric.Models.ManagementNetworkConfigurationPatchableProperties
    {
        private VpnConfigurationProperties _infrastructureVpnConfigurationProperties;
        private VpnConfigurationProperties _workloadVpnConfigurationProperties;

        /// <summary> Initializes a new instance of <see cref="ManagementNetworkConfigurationProperties"/>. </summary>
        /// <param name="infrastructureVpnConfiguration"> VPN Configuration properties. </param>
        /// <param name="workloadVpnConfiguration"> VPN Configuration properties. </param>
        public ManagementNetworkConfigurationProperties(VpnConfigurationPatchableProperties infrastructureVpnConfiguration, VpnConfigurationPatchableProperties workloadVpnConfiguration)
            : base(infrastructureVpnConfiguration, workloadVpnConfiguration, additionalBinaryDataProperties: null)
        {
        }

        /// <summary> Initializes a new instance of <see cref="ManagementNetworkConfigurationProperties"/>. </summary>
        /// <param name="infrastructureVpnConfiguration"> VPN Configuration properties. </param>
        /// <param name="workloadVpnConfiguration"> VPN Configuration properties. </param>
        public ManagementNetworkConfigurationProperties(VpnConfigurationProperties infrastructureVpnConfiguration, VpnConfigurationProperties workloadVpnConfiguration)
            : base(ToPatchable(infrastructureVpnConfiguration), ToPatchable(workloadVpnConfiguration), additionalBinaryDataProperties: null)
        {
            _infrastructureVpnConfigurationProperties = infrastructureVpnConfiguration;
            _workloadVpnConfigurationProperties = workloadVpnConfiguration;
        }

        /// <summary> VPN Configuration properties. </summary>
        public new VpnConfigurationProperties InfrastructureVpnConfiguration
        {
            get => _infrastructureVpnConfigurationProperties;
            set
            {
                _infrastructureVpnConfigurationProperties = value;
                base.InfrastructureVpnConfiguration = ToPatchable(value);
            }
        }

        /// <summary> VPN Configuration properties. </summary>
        public new VpnConfigurationProperties WorkloadVpnConfiguration
        {
            get => _workloadVpnConfigurationProperties;
            set
            {
                _workloadVpnConfigurationProperties = value;
                base.WorkloadVpnConfiguration = ToPatchable(value);
            }
        }

        private static VpnConfigurationPatchableProperties ToPatchable(VpnConfigurationProperties value)
        {
            if (value is null)
            {
                return null;
            }

            return new VpnConfigurationPatchableProperties
            {
                NetworkToNetworkInterconnectId = value.NetworkToNetworkInterconnectId,
                PeeringOption = value.PeeringOption,
                OptionBProperties = value.OptionBProperties,
                OptionAProperties = ToPatchable(value.OptionAProperties)
            };
        }

        private static VpnConfigurationPatchableOptionAProperties ToPatchable(VpnConfigurationOptionAProperties value)
        {
            if (value is null)
            {
                return null;
            }

            return new VpnConfigurationPatchableOptionAProperties(value.VlanId, value.PeerASN)
            {
                Mtu = value.Mtu,
                BfdConfiguration = value.BfdConfiguration,
                PrimaryIpv4Prefix = value.PrimaryIpv4Prefix,
                PrimaryIpv6Prefix = value.PrimaryIpv6Prefix,
                SecondaryIpv4Prefix = value.SecondaryIpv4Prefix,
                SecondaryIpv6Prefix = value.SecondaryIpv6Prefix
            };
        }
    }
}
