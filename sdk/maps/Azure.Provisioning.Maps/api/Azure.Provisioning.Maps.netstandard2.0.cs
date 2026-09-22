namespace Azure.Provisioning.Maps
{
    public partial class CustomerManagedKeyEncryption : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CustomerManagedKeyEncryption() { }
        public Azure.Provisioning.Maps.CustomerManagedKeyEncryptionKeyIdentity KeyEncryptionKeyIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> KeyEncryptionKeyUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CustomerManagedKeyEncryptionKeyIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CustomerManagedKeyEncryptionKeyIdentity() { }
        public Azure.Provisioning.BicepValue<System.Guid> DelegatedIdentityClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> FederatedClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Maps.MapsIdentityType> IdentityType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> UserAssignedIdentityResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MapsAccount : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MapsAccount(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Maps.MapsAccountKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Maps.MapsAccountProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Maps.MapsSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Maps.MapsAccount FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_10_01_PREVIEW;
        }
    }
    public enum MapsAccountKind
    {
        Gen2 = 0,
    }
    public partial class MapsAccountProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MapsAccountProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Maps.MapsCorsRule> CorsRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DisableLocalAuth { get { throw null; } set { } }
        public Azure.Provisioning.Maps.MapsEncryption Encryption { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Maps.MapsLinkedResource> LinkedResources { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Maps.MapsLocationItem> Locations { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Maps.MapsPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Maps.MapsPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> UniqueId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MapsCorsRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MapsCorsRule() { }
        public Azure.Provisioning.BicepList<string> AllowedOrigins { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MapsCreator : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MapsCreator(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Maps.MapsAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.Maps.MapsCreatorProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Maps.MapsCreator FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_10_01_PREVIEW;
        }
    }
    public partial class MapsCreatorProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MapsCreatorProperties() { }
        public Azure.Provisioning.BicepValue<int> ConsumedStorageUnitSizeInBytes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> StorageUnits { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TotalStorageUnitSizeInBytes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MapsEncryption : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MapsEncryption() { }
        public Azure.Provisioning.Maps.CustomerManagedKeyEncryption CustomerManagedKeyEncryption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Maps.MapsInfrastructureEncryption> InfrastructureEncryption { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MapsIdentityType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="systemAssignedIdentity")]
        SystemAssignedIdentity = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="userAssignedIdentity")]
        UserAssignedIdentity = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="delegatedResourceIdentity")]
        DelegatedResourceIdentity = 2,
    }
    public enum MapsInfrastructureEncryption
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="enabled")]
        Enabled = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="disabled")]
        Disabled = 1,
    }
    public partial class MapsLinkedResource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MapsLinkedResource() { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UniqueName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MapsLocationItem : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MapsLocationItem() { }
        public Azure.Provisioning.BicepValue<string> LocationName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MapsPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MapsPrivateEndpointConnection(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Maps.MapsAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.Maps.MapsPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Maps.MapsPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Maps.MapsPrivateEndpointConnection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_10_01_PREVIEW;
        }
    }
    public enum MapsPrivateEndpointConnectionProvisioningState
    {
        Succeeded = 0,
        Creating = 1,
        Deleting = 2,
        Failed = 3,
    }
    public enum MapsPrivateEndpointServiceConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
    }
    public partial class MapsPrivateLinkResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal MapsPrivateLinkResource() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> GroupId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Maps.MapsAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> RequiredMembers { get { throw null; } }
        public Azure.Provisioning.BicepList<string> RequiredZoneNames { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Maps.MapsPrivateLinkResource FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_10_01_PREVIEW;
        }
    }
    public partial class MapsPrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MapsPrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Maps.MapsPrivateEndpointServiceConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MapsPublicNetworkAccess
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="enabled")]
        Enabled = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="disabled")]
        Disabled = 1,
    }
    public partial class MapsSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MapsSku() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Maps.MapsSkuName> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tier { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MapsSkuName
    {
        G2 = 0,
    }
}
