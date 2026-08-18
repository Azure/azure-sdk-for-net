// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

#pragma warning disable SA1402 // Keep the repeated writable Name compatibility declarations together.

namespace Azure.Provisioning.Network
{
    public partial class ContainerNetworkInterface
    {
        private BicepValue<string> _compatibilityName;
        private BicepValue<ResourceIdentifier> _compatibilityContainerId;

        /// <summary> Gets or sets the resource name. </summary>
        [CodeGenMember("Name")]
        public BicepValue<string> Name
        {
            get { Initialize(); return _compatibilityName; }
            set { Initialize(); _compatibilityName.Assign(value); }
        }

        /// <summary> Gets or sets the container resource identifier. </summary>
        [CodeGenMember("ContainerId")]
        public BicepValue<ResourceIdentifier> ContainerId
        {
            get { Initialize(); return _compatibilityContainerId; }
            set { Initialize(); _compatibilityContainerId.Assign(value); }
        }

        partial void DefineAdditionalProperties()
        {
            _compatibilityName = DefineProperty<string>(nameof(Name), new string[] { "name" });
            _compatibilityContainerId = DefineProperty<ResourceIdentifier>(
                nameof(ContainerId),
                new string[] { "properties", "container", "id" });
        }
    }

    public partial class FirewallPolicyDraft
    {
        private BicepValue<string> _compatibilityName;

        /// <summary> Gets or sets the resource name. </summary>
        [CodeGenMember("Name")]
        public BicepValue<string> Name
        {
            get { Initialize(); return _compatibilityName; }
            set { Initialize(); _compatibilityName.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityName = DefineProperty<string>(nameof(Name), new string[] { "name" });
    }

    public partial class FirewallPolicyRuleCollectionGroupDraft
    {
        private BicepValue<string> _compatibilityName;

        /// <summary> Gets or sets the resource name. </summary>
        [CodeGenMember("Name")]
        public BicepValue<string> Name
        {
            get { Initialize(); return _compatibilityName; }
            set { Initialize(); _compatibilityName.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityName = DefineProperty<string>(nameof(Name), new string[] { "name" });
    }

    public partial class PolicySignaturesOverridesForIdps
    {
        private BicepValue<string> _compatibilityName;

        /// <summary> Gets or sets the resource name. </summary>
        [CodeGenMember("Name")]
        public BicepValue<string> Name
        {
            get { Initialize(); return _compatibilityName; }
            set { Initialize(); _compatibilityName.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityName = DefineProperty<string>(nameof(Name), new string[] { "name" });
    }

    public partial class ResourceNavigationLink
    {
        private BicepValue<string> _compatibilityName;
        private BicepValue<ResourceType> _compatibilityLinkedResourceType;
        private BicepValue<ResourceIdentifier> _compatibilityLink;

        /// <summary> Gets or sets the resource name. </summary>
        [CodeGenMember("Name")]
        public BicepValue<string> Name
        {
            get { Initialize(); return _compatibilityName; }
            set { Initialize(); _compatibilityName.Assign(value); }
        }

        /// <summary> Gets or sets the linked resource type. </summary>
        [CodeGenMember("LinkedResourceType")]
        public BicepValue<ResourceType> LinkedResourceType
        {
            get { Initialize(); return _compatibilityLinkedResourceType; }
            set { Initialize(); _compatibilityLinkedResourceType.Assign(value); }
        }

        /// <summary> Gets or sets the linked resource identifier. </summary>
        [CodeGenMember("Link")]
        public BicepValue<ResourceIdentifier> Link
        {
            get { Initialize(); return _compatibilityLink; }
            set { Initialize(); _compatibilityLink.Assign(value); }
        }

        partial void DefineAdditionalProperties()
        {
            _compatibilityName = DefineProperty<string>(nameof(Name), new string[] { "name" });
            _compatibilityLinkedResourceType = DefineProperty<ResourceType>(
                nameof(LinkedResourceType),
                new string[] { "properties", "linkedResourceType" });
            _compatibilityLink = DefineProperty<ResourceIdentifier>(
                nameof(Link),
                new string[] { "properties", "link" });
        }
    }

    public partial class ServiceAssociationLink
    {
        private BicepValue<string> _compatibilityName;
        private BicepValue<ResourceType> _compatibilityLinkedResourceType;
        private BicepValue<ResourceIdentifier> _compatibilityLink;
        private BicepValue<bool> _compatibilityAllowDelete;
        private BicepList<AzureLocation> _compatibilityLocations;

        /// <summary> Gets or sets the resource name. </summary>
        [CodeGenMember("Name")]
        public BicepValue<string> Name
        {
            get { Initialize(); return _compatibilityName; }
            set { Initialize(); _compatibilityName.Assign(value); }
        }

        /// <summary> Gets or sets the linked resource type. </summary>
        [CodeGenMember("LinkedResourceType")]
        public BicepValue<ResourceType> LinkedResourceType
        {
            get { Initialize(); return _compatibilityLinkedResourceType; }
            set { Initialize(); _compatibilityLinkedResourceType.Assign(value); }
        }

        /// <summary> Gets or sets the linked resource identifier. </summary>
        [CodeGenMember("Link")]
        public BicepValue<ResourceIdentifier> Link
        {
            get { Initialize(); return _compatibilityLink; }
            set { Initialize(); _compatibilityLink.Assign(value); }
        }

        /// <summary> Gets or sets whether deletion is allowed. </summary>
        [CodeGenMember("AllowDelete")]
        public BicepValue<bool> AllowDelete
        {
            get { Initialize(); return _compatibilityAllowDelete; }
            set { Initialize(); _compatibilityAllowDelete.Assign(value); }
        }

        /// <summary> Gets or sets the locations. </summary>
        [CodeGenMember("Locations")]
        public BicepList<AzureLocation> Locations
        {
            get { Initialize(); return _compatibilityLocations; }
            set { Initialize(); _compatibilityLocations.Assign(value); }
        }

        partial void DefineAdditionalProperties()
        {
            _compatibilityName = DefineProperty<string>(nameof(Name), new string[] { "name" });
            _compatibilityLinkedResourceType = DefineProperty<ResourceType>(
                nameof(LinkedResourceType),
                new string[] { "properties", "linkedResourceType" });
            _compatibilityLink = DefineProperty<ResourceIdentifier>(
                nameof(Link),
                new string[] { "properties", "link" });
            _compatibilityAllowDelete = DefineProperty<bool>(
                nameof(AllowDelete),
                new string[] { "properties", "allowDelete" });
            _compatibilityLocations = DefineListProperty<AzureLocation>(
                nameof(Locations),
                new string[] { "properties", "locations" });
        }
    }

    public partial class VirtualNetworkApplianceIPConfiguration
    {
        private BicepValue<string> _compatibilityName;
        private BicepValue<string> _compatibilityPrivateIPAddress;
        private BicepValue<NetworkIPAllocationMethod> _compatibilityPrivateIPAllocationMethod;
        private BicepValue<NetworkIPVersion> _compatibilityPrivateIPAddressVersion;

        /// <summary> Gets or sets the resource name. </summary>
        [CodeGenMember("Name")]
        public BicepValue<string> Name
        {
            get { Initialize(); return _compatibilityName; }
            set { Initialize(); _compatibilityName.Assign(value); }
        }

        /// <summary> Gets or sets the private IP address. </summary>
        [CodeGenMember("PrivateIPAddress")]
        public BicepValue<string> PrivateIPAddress
        {
            get { Initialize(); return _compatibilityPrivateIPAddress; }
            set { Initialize(); _compatibilityPrivateIPAddress.Assign(value); }
        }

        /// <summary> Gets or sets the private IP allocation method. </summary>
        [CodeGenMember("PrivateIPAllocationMethod")]
        public BicepValue<NetworkIPAllocationMethod> PrivateIPAllocationMethod
        {
            get { Initialize(); return _compatibilityPrivateIPAllocationMethod; }
            set { Initialize(); _compatibilityPrivateIPAllocationMethod.Assign(value); }
        }

        /// <summary> Gets or sets the private IP address version. </summary>
        [CodeGenMember("PrivateIPAddressVersion")]
        public BicepValue<NetworkIPVersion> PrivateIPAddressVersion
        {
            get { Initialize(); return _compatibilityPrivateIPAddressVersion; }
            set { Initialize(); _compatibilityPrivateIPAddressVersion.Assign(value); }
        }

        partial void DefineAdditionalProperties()
        {
            _compatibilityName = DefineProperty<string>(nameof(Name), new string[] { "name" });
            _compatibilityPrimary = DefineProperty<bool>(nameof(Primary), new string[] { "properties", "primary" });
            _compatibilityPrivateIPAddress = DefineProperty<string>(
                nameof(PrivateIPAddress),
                new string[] { "properties", "privateIPAddress" });
            _compatibilityPrivateIPAllocationMethod = DefineProperty<NetworkIPAllocationMethod>(
                nameof(PrivateIPAllocationMethod),
                new string[] { "properties", "privateIPAllocationMethod" });
            _compatibilityPrivateIPAddressVersion = DefineProperty<NetworkIPVersion>(
                nameof(PrivateIPAddressVersion),
                new string[] { "properties", "privateIPAddressVersion" });
        }
    }

    public partial class VpnLinkConnectionSharedKey
    {
        private BicepValue<string> _compatibilityName;

        /// <summary> Gets or sets the resource name. </summary>
        [CodeGenMember("Name")]
        public BicepValue<string> Name
        {
            get { Initialize(); return _compatibilityName; }
            set { Initialize(); _compatibilityName.Assign(value); }
        }

        partial void DefineAdditionalProperties() =>
            _compatibilityName = DefineProperty<string>(nameof(Name), new string[] { "name" });
    }
}
