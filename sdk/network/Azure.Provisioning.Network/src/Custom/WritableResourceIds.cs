// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

#pragma warning disable SA1402 // Keep the repeated writable Id compatibility declarations together.

namespace Azure.Provisioning.Network
{
    public partial class ApplicationSecurityGroup
    {
        private BicepValue<ResourceIdentifier> _compatibilityId;

        /// <summary> Gets or sets the resource identifier. </summary>
        [CodeGenMember("Id")]
        public BicepValue<ResourceIdentifier> Id
        {
            get { Initialize(); return _compatibilityId; }
            set { Initialize(); _compatibilityId.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityId = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
    }

    public partial class BackendAddressPool
    {
        private BicepValue<ResourceIdentifier> _compatibilityId;

        /// <summary> Gets or sets the resource identifier. </summary>
        [CodeGenMember("Id")]
        public BicepValue<ResourceIdentifier> Id
        {
            get { Initialize(); return _compatibilityId; }
            set { Initialize(); _compatibilityId.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityId = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
    }

    public partial class FirewallPolicy
    {
        private BicepValue<ResourceIdentifier> _compatibilityId;

        /// <summary> Gets or sets the resource identifier. </summary>
        [CodeGenMember("Id")]
        public BicepValue<ResourceIdentifier> Id
        {
            get { Initialize(); return _compatibilityId; }
            set { Initialize(); _compatibilityId.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityId = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
    }

    public partial class FlowLog
    {
        private BicepValue<ResourceIdentifier> _compatibilityId;

        /// <summary> Gets or sets the resource identifier. </summary>
        [CodeGenMember("Id")]
        public BicepValue<ResourceIdentifier> Id
        {
            get { Initialize(); return _compatibilityId; }
            set { Initialize(); _compatibilityId.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityId = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
    }

    public partial class InboundNatRule
    {
        private BicepValue<ResourceIdentifier> _compatibilityId;

        /// <summary> Gets or sets the resource identifier. </summary>
        [CodeGenMember("Id")]
        public BicepValue<ResourceIdentifier> Id
        {
            get { Initialize(); return _compatibilityId; }
            set { Initialize(); _compatibilityId.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityId = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
    }

    public partial class LoadBalancer
    {
        private BicepValue<ResourceIdentifier> _compatibilityId;

        /// <summary> Gets or sets the resource identifier. </summary>
        [CodeGenMember("Id")]
        public BicepValue<ResourceIdentifier> Id
        {
            get { Initialize(); return _compatibilityId; }
            set { Initialize(); _compatibilityId.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityId = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
    }

    public partial class NatGateway
    {
        private BicepValue<ResourceIdentifier> _compatibilityId;

        /// <summary> Gets or sets the resource identifier. </summary>
        [CodeGenMember("Id")]
        public BicepValue<ResourceIdentifier> Id
        {
            get { Initialize(); return _compatibilityId; }
            set { Initialize(); _compatibilityId.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityId = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
    }

    public partial class NetworkInterface
    {
        private BicepValue<ResourceIdentifier> _compatibilityId;

        /// <summary> Gets or sets the resource identifier. </summary>
        [CodeGenMember("Id")]
        public BicepValue<ResourceIdentifier> Id
        {
            get { Initialize(); return _compatibilityId; }
            set { Initialize(); _compatibilityId.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityId = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
    }

    public partial class NetworkInterfaceTapConfiguration
    {
        private BicepValue<ResourceIdentifier> _compatibilityId;

        /// <summary> Gets or sets the resource identifier. </summary>
        [CodeGenMember("Id")]
        public BicepValue<ResourceIdentifier> Id
        {
            get { Initialize(); return _compatibilityId; }
            set { Initialize(); _compatibilityId.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityId = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
    }

    public partial class NetworkPrivateEndpointConnection
    {
        private BicepValue<ResourceIdentifier> _compatibilityId;

        /// <summary> Gets or sets the resource identifier. </summary>
        [CodeGenMember("Id")]
        public BicepValue<ResourceIdentifier> Id
        {
            get { Initialize(); return _compatibilityId; }
            set { Initialize(); _compatibilityId.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityId = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
    }

    public partial class NetworkSecurityGroup
    {
        private BicepValue<ResourceIdentifier> _compatibilityId;

        /// <summary> Gets or sets the resource identifier. </summary>
        [CodeGenMember("Id")]
        public BicepValue<ResourceIdentifier> Id
        {
            get { Initialize(); return _compatibilityId; }
            set { Initialize(); _compatibilityId.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityId = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
    }

    public partial class NetworkWatcher
    {
        private BicepValue<ResourceIdentifier> _compatibilityId;

        /// <summary> Gets or sets the resource identifier. </summary>
        [CodeGenMember("Id")]
        public BicepValue<ResourceIdentifier> Id
        {
            get { Initialize(); return _compatibilityId; }
            set { Initialize(); _compatibilityId.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityId = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
    }

    public partial class PrivateDnsZoneGroup
    {
        private BicepValue<ResourceIdentifier> _compatibilityId;

        /// <summary> Gets or sets the resource identifier. </summary>
        [CodeGenMember("Id")]
        public BicepValue<ResourceIdentifier> Id
        {
            get { Initialize(); return _compatibilityId; }
            set { Initialize(); _compatibilityId.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityId = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
    }

    public partial class PrivateEndpoint
    {
        private BicepValue<ResourceIdentifier> _compatibilityId;

        /// <summary> Gets or sets the resource identifier. </summary>
        [CodeGenMember("Id")]
        public BicepValue<ResourceIdentifier> Id
        {
            get { Initialize(); return _compatibilityId; }
            set { Initialize(); _compatibilityId.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityId = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
    }

    public partial class PrivateLinkService
    {
        private BicepValue<ResourceIdentifier> _compatibilityId;

        /// <summary> Gets or sets the resource identifier. </summary>
        [CodeGenMember("Id")]
        public BicepValue<ResourceIdentifier> Id
        {
            get { Initialize(); return _compatibilityId; }
            set { Initialize(); _compatibilityId.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityId = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
    }

    public partial class PublicIPAddress
    {
        private BicepValue<ResourceIdentifier> _compatibilityId;

        /// <summary> Gets or sets the resource identifier. </summary>
        [CodeGenMember("Id")]
        public BicepValue<ResourceIdentifier> Id
        {
            get { Initialize(); return _compatibilityId; }
            set { Initialize(); _compatibilityId.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityId = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
    }

    public partial class PublicIPPrefix
    {
        private BicepValue<ResourceIdentifier> _compatibilityId;

        /// <summary> Gets or sets the resource identifier. </summary>
        [CodeGenMember("Id")]
        public BicepValue<ResourceIdentifier> Id
        {
            get { Initialize(); return _compatibilityId; }
            set { Initialize(); _compatibilityId.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityId = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
    }

    public partial class RouteResource
    {
        private BicepValue<ResourceIdentifier> _compatibilityId;

        /// <summary> Gets or sets the resource identifier. </summary>
        [CodeGenMember("Id")]
        public BicepValue<ResourceIdentifier> Id
        {
            get { Initialize(); return _compatibilityId; }
            set { Initialize(); _compatibilityId.Assign(value); }
        }

        partial void DefineAdditionalProperties()
        {
            _compatibilityId = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
            _compatibilityHasBgpOverride = DefineProperty<bool>(
                nameof(HasBgpOverride),
                new string[] { "properties", "hasBgpOverride" });
        }
    }

    public partial class RouteTable
    {
        private BicepValue<ResourceIdentifier> _compatibilityId;

        /// <summary> Gets or sets the resource identifier. </summary>
        [CodeGenMember("Id")]
        public BicepValue<ResourceIdentifier> Id
        {
            get { Initialize(); return _compatibilityId; }
            set { Initialize(); _compatibilityId.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityId = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
    }

    public partial class SecurityRule
    {
        private BicepValue<ResourceIdentifier> _compatibilityId;

        /// <summary> Gets or sets the resource identifier. </summary>
        [CodeGenMember("Id")]
        public BicepValue<ResourceIdentifier> Id
        {
            get { Initialize(); return _compatibilityId; }
            set { Initialize(); _compatibilityId.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityId = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
    }

    public partial class ServiceEndpointPolicy
    {
        private BicepValue<ResourceIdentifier> _compatibilityId;

        /// <summary> Gets or sets the resource identifier. </summary>
        [CodeGenMember("Id")]
        public BicepValue<ResourceIdentifier> Id
        {
            get { Initialize(); return _compatibilityId; }
            set { Initialize(); _compatibilityId.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityId = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
    }

    public partial class ServiceEndpointPolicyDefinition
    {
        private BicepValue<ResourceIdentifier> _compatibilityId;

        /// <summary> Gets or sets the resource identifier. </summary>
        [CodeGenMember("Id")]
        public BicepValue<ResourceIdentifier> Id
        {
            get { Initialize(); return _compatibilityId; }
            set { Initialize(); _compatibilityId.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityId = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
    }

    public partial class SubnetResource
    {
        private BicepValue<ResourceIdentifier> _compatibilityId;

        /// <summary> Gets or sets the resource identifier. </summary>
        [CodeGenMember("Id")]
        public BicepValue<ResourceIdentifier> Id
        {
            get { Initialize(); return _compatibilityId; }
            set { Initialize(); _compatibilityId.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityId = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
    }

    public partial class VirtualNetwork
    {
        private BicepValue<ResourceIdentifier> _compatibilityId;

        /// <summary> Gets or sets the resource identifier. </summary>
        [CodeGenMember("Id")]
        public BicepValue<ResourceIdentifier> Id
        {
            get { Initialize(); return _compatibilityId; }
            set { Initialize(); _compatibilityId.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityId = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
    }

    public partial class VirtualNetworkPeering
    {
        private BicepValue<ResourceIdentifier> _compatibilityId;

        /// <summary> Gets or sets the resource identifier. </summary>
        [CodeGenMember("Id")]
        public BicepValue<ResourceIdentifier> Id
        {
            get { Initialize(); return _compatibilityId; }
            set { Initialize(); _compatibilityId.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityId = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
    }

    public partial class VirtualNetworkTap
    {
        private BicepValue<ResourceIdentifier> _compatibilityId;

        /// <summary> Gets or sets the resource identifier. </summary>
        [CodeGenMember("Id")]
        public BicepValue<ResourceIdentifier> Id
        {
            get { Initialize(); return _compatibilityId; }
            set { Initialize(); _compatibilityId.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityId = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
    }
}
