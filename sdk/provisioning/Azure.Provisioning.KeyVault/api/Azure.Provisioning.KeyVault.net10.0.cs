namespace Azure.Provisioning.KeyVault
{
    public partial class DeletedKeyVault : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DeletedKeyVault(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.KeyVault.DeletedKeyVaultProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.KeyVault.DeletedKeyVault FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class DeletedKeyVaultProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DeletedKeyVaultProperties() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> DeletionDate { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> PurgeProtectionEnabled { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ScheduledPurgeDate { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VaultId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeletedManagedHsm : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DeletedManagedHsm(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.KeyVault.DeletedManagedHsmProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.KeyVault.DeletedManagedHsm FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class DeletedManagedHsmProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DeletedManagedHsmProperties() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> DeletionDate { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ManagedHsmId { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> PurgeProtectionEnabled { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ScheduledPurgeDate { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum IdentityAccessCertificatePermission
    {
        All = 0,
        Get = 1,
        List = 2,
        Delete = 3,
        Create = 4,
        Import = 5,
        Update = 6,
        ManageContacts = 7,
        GetIssuers = 8,
        ListIssuers = 9,
        SetIssuers = 10,
        DeleteIssuers = 11,
        ManageIssuers = 12,
        Recover = 13,
        Purge = 14,
        Backup = 15,
        Restore = 16,
    }
    public enum IdentityAccessKeyPermission
    {
        All = 0,
        Encrypt = 1,
        Decrypt = 2,
        WrapKey = 3,
        UnwrapKey = 4,
        Sign = 5,
        Verify = 6,
        Get = 7,
        List = 8,
        Create = 9,
        Update = 10,
        Import = 11,
        Delete = 12,
        Backup = 13,
        Restore = 14,
        Recover = 15,
        Purge = 16,
        Release = 17,
        Rotate = 18,
        Getrotationpolicy = 19,
        Setrotationpolicy = 20,
    }
    public partial class IdentityAccessPermissions : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IdentityAccessPermissions() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.KeyVault.IdentityAccessCertificatePermission> Certificates { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.KeyVault.IdentityAccessKeyPermission> Keys { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.KeyVault.IdentityAccessSecretPermission> Secrets { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.KeyVault.IdentityAccessStoragePermission> Storage { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum IdentityAccessSecretPermission
    {
        All = 0,
        Get = 1,
        List = 2,
        Set = 3,
        Delete = 4,
        Backup = 5,
        Restore = 6,
        Recover = 7,
        Purge = 8,
    }
    public enum IdentityAccessStoragePermission
    {
        All = 0,
        Get = 1,
        List = 2,
        Delete = 3,
        Set = 4,
        Update = 5,
        RegenerateKey = 6,
        Recover = 7,
        Purge = 8,
        Backup = 9,
        Restore = 10,
        SetSas = 11,
        ListSas = 12,
        GetSas = 13,
        DeleteSas = 14,
    }
    public partial class KeyVaultAccessPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KeyVaultAccessPolicy() { }
        public Azure.Provisioning.BicepValue<System.Guid> ApplicationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ObjectId { get { throw null; } set { } }
        public Azure.Provisioning.KeyVault.IdentityAccessPermissions Permissions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum KeyVaultActionsRequiredMessage
    {
        None = 0,
    }
    public enum KeyVaultCreateMode
    {
        Recover = 0,
        Default = 1,
    }
    public partial class KeyVaultIPRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KeyVaultIPRule() { }
        public Azure.Provisioning.BicepValue<string> AddressRange { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum KeyVaultNetworkRuleAction
    {
        Allow = 0,
        Deny = 1,
    }
    public enum KeyVaultNetworkRuleBypassOption
    {
        AzureServices = 0,
        None = 1,
    }
    public partial class KeyVaultNetworkRuleSet : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KeyVaultNetworkRuleSet() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KeyVault.KeyVaultNetworkRuleBypassOption> Bypass { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KeyVault.KeyVaultNetworkRuleAction> DefaultAction { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.KeyVault.KeyVaultIPRule> IPRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.KeyVault.KeyVaultVirtualNetworkRule> VirtualNetworkRules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KeyVaultPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public KeyVaultPrivateEndpointConnection(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.KeyVault.KeyVaultPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.KeyVault.KeyVaultService Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KeyVault.KeyVaultPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.KeyVault.KeyVaultPrivateEndpointConnection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class KeyVaultPrivateEndpointConnectionItemData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KeyVaultPrivateEndpointConnectionItemData() { }
        public Azure.Provisioning.KeyVault.KeyVaultPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KeyVault.KeyVaultPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum KeyVaultPrivateEndpointConnectionProvisioningState
    {
        Succeeded = 0,
        Creating = 1,
        Updating = 2,
        Deleting = 3,
        Failed = 4,
        Disconnected = 5,
    }
    public enum KeyVaultPrivateEndpointServiceConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Disconnected = 3,
    }
    public partial class KeyVaultPrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KeyVaultPrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KeyVault.KeyVaultActionsRequiredMessage> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KeyVault.KeyVaultPrivateEndpointServiceConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KeyVaultProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KeyVaultProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.KeyVault.KeyVaultAccessPolicy> AccessPolicies { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KeyVault.KeyVaultCreateMode> CreateMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnabledForDeployment { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnabledForDiskEncryption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnabledForTemplateDeployment { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePurgeProtection { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableRbacAuthorization { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableSoftDelete { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HsmPoolResourceId { get { throw null; } }
        public Azure.Provisioning.KeyVault.KeyVaultNetworkRuleSet NetworkRuleSet { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.KeyVault.KeyVaultPrivateEndpointConnectionItemData> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KeyVault.KeyVaultProvisioningState> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.KeyVault.KeyVaultSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SoftDeleteRetentionInDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> VaultUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum KeyVaultProvisioningState
    {
        Succeeded = 0,
        RegisteringDns = 1,
    }
    public partial class KeyVaultSecret : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public KeyVaultSecret(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.KeyVault.KeyVaultService Parent { get { throw null; } set { } }
        public Azure.Provisioning.KeyVault.SecretProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.KeyVault.KeyVaultSecret FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class KeyVaultService : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public KeyVaultService(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.KeyVault.KeyVaultProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.KeyVault.KeyVaultService FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class KeyVaultSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KeyVaultSku() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KeyVault.KeyVaultSkuFamily> Family { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KeyVault.KeyVaultSkuName> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum KeyVaultSkuFamily
    {
        A = 0,
    }
    public enum KeyVaultSkuName
    {
        Standard = 0,
        Premium = 1,
    }
    public partial class KeyVaultVirtualNetworkRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KeyVaultVirtualNetworkRule() { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IgnoreMissingVnetServiceEndpoint { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedHsm : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedHsm(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.KeyVault.ManagedHsmProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.KeyVault.ManagedHsmSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.KeyVault.ManagedHsm FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public enum ManagedHsmActionsRequiredMessage
    {
        None = 0,
    }
    public enum ManagedHsmCreateMode
    {
        Recover = 0,
        Default = 1,
    }
    public partial class ManagedHsmGeoReplicatedRegion : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedHsmGeoReplicatedRegion() { }
        public Azure.Provisioning.BicepValue<bool> IsPrimary { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KeyVault.ManagedHsmGeoReplicatedRegionProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ManagedHsmGeoReplicatedRegionProvisioningState
    {
        Preprovisioning = 0,
        Provisioning = 1,
        Succeeded = 2,
        Failed = 3,
        Deleting = 4,
        Cleanup = 5,
    }
    public partial class ManagedHsmIPRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedHsmIPRule() { }
        public Azure.Provisioning.BicepValue<string> AddressRange { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ManagedHsmNetworkRuleAction
    {
        Allow = 0,
        Deny = 1,
    }
    public enum ManagedHsmNetworkRuleBypassOption
    {
        AzureServices = 0,
        None = 1,
    }
    public partial class ManagedHsmNetworkRuleSet : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedHsmNetworkRuleSet() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KeyVault.ManagedHsmNetworkRuleBypassOption> Bypass { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KeyVault.ManagedHsmNetworkRuleAction> DefaultAction { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.KeyVault.ManagedHsmIPRule> IPRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.KeyVault.ManagedHsmServiceTagRule> ServiceTags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.KeyVault.ManagedHsmVirtualNetworkRule> VirtualNetworkRules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedHsmPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedHsmPrivateEndpointConnection(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.KeyVault.ManagedHsm Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.KeyVault.ManagedHsmPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KeyVault.ManagedHsmPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.KeyVault.ManagedHsmSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.KeyVault.ManagedHsmPrivateEndpointConnection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_05_01;
        }
    }
    public partial class ManagedHsmPrivateEndpointConnectionItemData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedHsmPrivateEndpointConnectionItemData() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.KeyVault.ManagedHsmPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KeyVault.ManagedHsmPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ManagedHsmPrivateEndpointConnectionProvisioningState
    {
        Succeeded = 0,
        Creating = 1,
        Updating = 2,
        Deleting = 3,
        Failed = 4,
        Disconnected = 5,
    }
    public enum ManagedHsmPrivateEndpointServiceConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Disconnected = 3,
    }
    public partial class ManagedHsmPrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedHsmPrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KeyVault.ManagedHsmActionsRequiredMessage> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KeyVault.ManagedHsmPrivateEndpointServiceConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedHsmProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedHsmProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KeyVault.ManagedHsmCreateMode> CreateMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePurgeProtection { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableSoftDelete { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> HsmUri { get { throw null; } }
        public Azure.Provisioning.BicepList<string> InitialAdminObjectIds { get { throw null; } set { } }
        public Azure.Provisioning.KeyVault.ManagedHsmNetworkRuleSet NetworkRuleSet { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.KeyVault.ManagedHsmPrivateEndpointConnectionItemData> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KeyVault.ManagedHsmProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KeyVault.ManagedHsmPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.KeyVault.ManagedHsmGeoReplicatedRegion> Regions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ScheduledPurgeDate { get { throw null; } }
        public Azure.Provisioning.KeyVault.ManagedHSMSecurityDomainProperties SecurityDomainProperties { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> SoftDeleteRetentionInDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StatusMessage { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ManagedHsmProvisioningState
    {
        Succeeded = 0,
        Provisioning = 1,
        Failed = 2,
        Updating = 3,
        Deleting = 4,
        Activated = 5,
        SecurityDomainRestore = 6,
        Restoring = 7,
    }
    public enum ManagedHsmPublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum ManagedHSMSecurityDomainActivationStatus
    {
        Active = 0,
        NotActivated = 1,
        Unknown = 2,
        Failed = 3,
    }
    public partial class ManagedHSMSecurityDomainProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedHSMSecurityDomainProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KeyVault.ManagedHSMSecurityDomainActivationStatus> ActivationStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ActivationStatusMessage { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedHsmServiceTagRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedHsmServiceTagRule() { }
        public Azure.Provisioning.BicepValue<string> Tag { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedHsmSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedHsmSku() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KeyVault.ManagedHsmSkuFamily> Family { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KeyVault.ManagedHsmSkuName> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ManagedHsmSkuFamily
    {
        B = 0,
        C = 1,
    }
    public enum ManagedHsmSkuName
    {
        StandardB1 = 0,
        CustomB32 = 1,
        CustomB6 = 2,
        CustomC42 = 3,
        CustomC10 = 4,
    }
    public partial class ManagedHsmVirtualNetworkRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedHsmVirtualNetworkRule() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecretAttributes : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecretAttributes() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecretProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecretProperties() { }
        public Azure.Provisioning.KeyVault.SecretAttributes Attributes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ContentType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> SecretUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SecretUriWithVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
