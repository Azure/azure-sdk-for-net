// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    /// <summary> The Network Fabric resource definition. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This compatibility type is obsolete and will be removed in a future version. Use NetworkFabricPatchContent instead.")]
    public partial class NetworkFabricPatch : NetworkRackPatch
    {
        /// <summary> Initializes a new instance of <see cref="NetworkFabricPatch"/>. </summary>
        public NetworkFabricPatch()
        {
        }

        /// <summary> Initializes a new instance of <see cref="NetworkFabricPatch"/>. </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <param name="properties"> Network Fabric Patch properties. </param>
        /// <param name="identity"> The managed service identities assigned to this resource. </param>
        internal NetworkFabricPatch(IDictionary<string, string> tags, IDictionary<string, BinaryData> additionalBinaryDataProperties, NetworkFabricPatchProperties properties, NetworkFabricManagedServiceIdentityPatch identity) : base(tags, additionalBinaryDataProperties)
        {
            Properties = properties;
            Identity = identity;
        }

        /// <summary> Network Fabric Patch properties. </summary>
        internal NetworkFabricPatchProperties Properties { get; set; }

        /// <summary> The managed service identities assigned to this resource. </summary>
        public NetworkFabricManagedServiceIdentityPatch Identity { get; set; }

        /// <summary> Switch configuration description. </summary>
        public string Annotation
        {
            get
            {
                return Properties is null ? default : Properties.Annotation;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                Properties.Annotation = value;
            }
        }

        /// <summary> Number of compute racks associated to Network Fabric. </summary>
        public int? RackCount
        {
            get
            {
                return Properties is null ? default : Properties.RackCount;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                Properties.RackCount = value;
            }
        }

        /// <summary> Number of servers.Possible values are from 1-16. </summary>
        public int? ServerCountPerRack
        {
            get
            {
                return Properties is null ? default : Properties.ServerCountPerRack;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                Properties.ServerCountPerRack = value;
            }
        }

        /// <summary> IPv4Prefix for Management Network. Example: 10.1.0.0/19. </summary>
        public string IPv4Prefix
        {
            get
            {
                return Properties is null ? default : Properties.IPv4Prefix;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                Properties.IPv4Prefix = value;
            }
        }

        /// <summary> IPv6Prefix for Management Network. Example: 3FFE:FFFF:0:CD40::/59. </summary>
        public string IPv6Prefix
        {
            get
            {
                return Properties is null ? default : Properties.IPv6Prefix;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                Properties.IPv6Prefix = value;
            }
        }

        /// <summary> ASN of CE devices for CE/PE connectivity. </summary>
        public long? FabricAsn
        {
            get
            {
                return Properties is null ? default : Properties.FabricAsn;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                Properties.FabricAsn = value;
            }
        }

        /// <summary> Network and credentials configuration already applied to terminal server. </summary>
        public NetworkFabricPatchablePropertiesTerminalServerConfiguration TerminalServerConfiguration
        {
            get
            {
                return Properties is null ? default : Properties.TerminalServerConfiguration;
            }
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
        public ManagementNetworkConfigurationPatchableProperties ManagementNetworkConfiguration
        {
            get
            {
                return Properties is null ? default : Properties.ManagementNetworkConfiguration;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                Properties.ManagementNetworkConfiguration = value;
            }
        }

        /// <summary> Bring your own storage account configurations for Network Fabric. </summary>
        public StorageAccountPatchConfiguration StorageAccountConfiguration
        {
            get
            {
                return Properties is null ? default : Properties.StorageAccountConfiguration;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                Properties.StorageAccountConfiguration = value;
            }
        }

        /// <summary> Hardware alert threshold percentage. Possible values are from 20 to 100. </summary>
        public int? HardwareAlertThreshold
        {
            get
            {
                return Properties is null ? default : Properties.HardwareAlertThreshold;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                Properties.HardwareAlertThreshold = value;
            }
        }

        /// <summary> Control Plane Access Control List ARM resource IDs. </summary>
        public IList<ResourceIdentifier> ControlPlaneAcls
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                return Properties.ControlPlaneAcls;
            }
        }

        /// <summary> Trusted IP Prefix ARM resource IDs. </summary>
        public IList<ResourceIdentifier> TrustedIPPrefixes
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                return Properties.TrustedIPPrefixes;
            }
        }

        /// <summary> Unique Route Distinguisher configuration. </summary>
        public UniqueRouteDistinguisherPatchProperties UniqueRdConfiguration
        {
            get
            {
                return Properties is null ? default : Properties.UniqueRdConfiguration;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                Properties.UniqueRdConfiguration = value;
            }
        }

        /// <summary> NetworkFabric feature flag configuration information. </summary>
        public IList<NetworkFabricFeatureFlag> FeatureFlags
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                return Properties.FeatureFlags;
            }
        }

        /// <summary> Authorized transciever configuration for NetworkFabric. </summary>
        public AuthorizedTransceiverPatchProperties AuthorizedTransceiver
        {
            get
            {
                return Properties is null ? default : Properties.AuthorizedTransceiver;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                Properties.AuthorizedTransceiver = value;
            }
        }

        /// <summary> QoS configuration state. Default is Disabled. </summary>
        public NetworkFabricQosConfigurationState? QosConfigurationState
        {
            get
            {
                return Properties is null ? default : Properties.QosConfigurationState;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkFabricPatchProperties();
                }
                Properties.QosConfigurationState = value;
            }
        }
    }
}
