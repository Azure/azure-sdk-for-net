namespace Azure.Provisioning.KeyVault
{
    public enum IdentityAccessCertificatePermission
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="all")]
        All = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="get")]
        Get = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="list")]
        List = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="delete")]
        Delete = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="create")]
        Create = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="import")]
        Import = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="update")]
        Update = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="managecontacts")]
        ManageContacts = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="getissuers")]
        GetIssuers = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="listissuers")]
        ListIssuers = 9,
        [System.Runtime.Serialization.DataMemberAttribute(Name="setissuers")]
        SetIssuers = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="deleteissuers")]
        DeleteIssuers = 11,
        [System.Runtime.Serialization.DataMemberAttribute(Name="manageissuers")]
        ManageIssuers = 12,
        [System.Runtime.Serialization.DataMemberAttribute(Name="recover")]
        Recover = 13,
        [System.Runtime.Serialization.DataMemberAttribute(Name="purge")]
        Purge = 14,
        [System.Runtime.Serialization.DataMemberAttribute(Name="backup")]
        Backup = 15,
        [System.Runtime.Serialization.DataMemberAttribute(Name="restore")]
        Restore = 16,
    }
    public enum IdentityAccessKeyPermission
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="all")]
        All = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="encrypt")]
        Encrypt = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="decrypt")]
        Decrypt = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="wrapKey")]
        WrapKey = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="unwrapKey")]
        UnwrapKey = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="sign")]
        Sign = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="verify")]
        Verify = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="get")]
        Get = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="list")]
        List = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="create")]
        Create = 9,
        [System.Runtime.Serialization.DataMemberAttribute(Name="update")]
        Update = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="import")]
        Import = 11,
        [System.Runtime.Serialization.DataMemberAttribute(Name="delete")]
        Delete = 12,
        [System.Runtime.Serialization.DataMemberAttribute(Name="backup")]
        Backup = 13,
        [System.Runtime.Serialization.DataMemberAttribute(Name="restore")]
        Restore = 14,
        [System.Runtime.Serialization.DataMemberAttribute(Name="recover")]
        Recover = 15,
        [System.Runtime.Serialization.DataMemberAttribute(Name="purge")]
        Purge = 16,
        [System.Runtime.Serialization.DataMemberAttribute(Name="release")]
        Release = 17,
        [System.Runtime.Serialization.DataMemberAttribute(Name="rotate")]
        Rotate = 18,
        [System.Runtime.Serialization.DataMemberAttribute(Name="getrotationpolicy")]
        Getrotationpolicy = 19,
        [System.Runtime.Serialization.DataMemberAttribute(Name="setrotationpolicy")]
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
        [System.Runtime.Serialization.DataMemberAttribute(Name="all")]
        All = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="get")]
        Get = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="list")]
        List = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="set")]
        Set = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="delete")]
        Delete = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="backup")]
        Backup = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="restore")]
        Restore = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="recover")]
        Recover = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="purge")]
        Purge = 8,
    }
    public enum IdentityAccessStoragePermission
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="all")]
        All = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="get")]
        Get = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="list")]
        List = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="delete")]
        Delete = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="set")]
        Set = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="update")]
        Update = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="regeneratekey")]
        RegenerateKey = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="recover")]
        Recover = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="purge")]
        Purge = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="backup")]
        Backup = 9,
        [System.Runtime.Serialization.DataMemberAttribute(Name="restore")]
        Restore = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="setsas")]
        SetSas = 11,
        [System.Runtime.Serialization.DataMemberAttribute(Name="listsas")]
        ListSas = 12,
        [System.Runtime.Serialization.DataMemberAttribute(Name="getsas")]
        GetSas = 13,
        [System.Runtime.Serialization.DataMemberAttribute(Name="deletesas")]
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultBuiltInRole : System.IEquatable<Azure.Provisioning.KeyVault.KeyVaultBuiltInRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultBuiltInRole(string value) { throw null; }
        public static Azure.Provisioning.KeyVault.KeyVaultBuiltInRole KeyVaultAdministrator { get { throw null; } }
        public static Azure.Provisioning.KeyVault.KeyVaultBuiltInRole KeyVaultCertificatesOfficer { get { throw null; } }
        public static Azure.Provisioning.KeyVault.KeyVaultBuiltInRole KeyVaultCertificateUser { get { throw null; } }
        public static Azure.Provisioning.KeyVault.KeyVaultBuiltInRole KeyVaultContributor { get { throw null; } }
        public static Azure.Provisioning.KeyVault.KeyVaultBuiltInRole KeyVaultCryptoOfficer { get { throw null; } }
        public static Azure.Provisioning.KeyVault.KeyVaultBuiltInRole KeyVaultCryptoServiceEncryptionUser { get { throw null; } }
        public static Azure.Provisioning.KeyVault.KeyVaultBuiltInRole KeyVaultCryptoServiceReleaseUser { get { throw null; } }
        public static Azure.Provisioning.KeyVault.KeyVaultBuiltInRole KeyVaultCryptoUser { get { throw null; } }
        public static Azure.Provisioning.KeyVault.KeyVaultBuiltInRole KeyVaultDataAccessAdministrator { get { throw null; } }
        public static Azure.Provisioning.KeyVault.KeyVaultBuiltInRole KeyVaultReader { get { throw null; } }
        public static Azure.Provisioning.KeyVault.KeyVaultBuiltInRole KeyVaultSecretsOfficer { get { throw null; } }
        public static Azure.Provisioning.KeyVault.KeyVaultBuiltInRole KeyVaultSecretsUser { get { throw null; } }
        public static Azure.Provisioning.KeyVault.KeyVaultBuiltInRole ManagedHsmContributor { get { throw null; } }
        public bool Equals(Azure.Provisioning.KeyVault.KeyVaultBuiltInRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static string GetBuiltInRoleName(Azure.Provisioning.KeyVault.KeyVaultBuiltInRole value) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Provisioning.KeyVault.KeyVaultBuiltInRole left, Azure.Provisioning.KeyVault.KeyVaultBuiltInRole right) { throw null; }
        public static implicit operator Azure.Provisioning.KeyVault.KeyVaultBuiltInRole (string value) { throw null; }
        public static bool operator !=(Azure.Provisioning.KeyVault.KeyVaultBuiltInRole left, Azure.Provisioning.KeyVault.KeyVaultBuiltInRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum KeyVaultCreateMode
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="default")]
        Default = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="recover")]
        Recover = 1,
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
        public KeyVaultPrivateEndpointConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.KeyVault.KeyVaultPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.KeyVault.KeyVaultService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KeyVault.KeyVaultPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.KeyVault.KeyVaultPrivateEndpointConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_01;
            public static readonly string V2016_10_01;
            public static readonly string V2018_02_14;
            public static readonly string V2019_09_01;
            public static readonly string V2021_10_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_07_01;
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2023_08_01_PREVIEW;
            public static readonly string V2024_11_01;
        }
    }
    public partial class KeyVaultPrivateEndpointConnectionItemData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KeyVaultPrivateEndpointConnectionItemData() { }
        public Azure.Provisioning.KeyVault.KeyVaultPrivateLinkServiceConnectionState ConnectionState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
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
        public KeyVaultSecret(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.KeyVault.KeyVaultService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.KeyVault.SecretProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.KeyVault.KeyVaultSecret FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_01;
            public static readonly string V2016_10_01;
            public static readonly string V2018_02_14;
            public static readonly string V2019_09_01;
            public static readonly string V2021_10_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_07_01;
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2023_08_01_PREVIEW;
            public static readonly string V2024_11_01;
        }
    }
    public partial class KeyVaultService : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public KeyVaultService(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.KeyVault.KeyVaultProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.KeyVault.KeyVaultBuiltInRole role, Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPrincipalType> principalType, Azure.Provisioning.BicepValue<System.Guid> principalId, string? bicepIdentifierSuffix = null) { throw null; }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.KeyVault.KeyVaultBuiltInRole role, Azure.Provisioning.Roles.UserAssignedIdentity identity) { throw null; }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.KeyVault.KeyVaultService FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_01;
            public static readonly string V2016_10_01;
            public static readonly string V2018_02_14;
            public static readonly string V2019_09_01;
            public static readonly string V2021_10_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_07_01;
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2023_08_01_PREVIEW;
            public static readonly string V2024_11_01;
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
        [System.Runtime.Serialization.DataMemberAttribute(Name="standard")]
        Standard = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="premium")]
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
        public ManagedHsm(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.KeyVault.ManagedHsmProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.KeyVault.ManagedHsmSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.KeyVault.ManagedHsm FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_10_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_07_01;
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2023_08_01_PREVIEW;
            public static readonly string V2024_11_01;
        }
    }
    public enum ManagedHsmActionsRequiredMessage
    {
        None = 0,
    }
    public enum ManagedHsmCreateMode
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="default")]
        Default = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="recover")]
        Recover = 1,
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
        public Azure.Provisioning.BicepList<Azure.Provisioning.KeyVault.ManagedHsmVirtualNetworkRule> VirtualNetworkRules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedHsmPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedHsmPrivateEndpointConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.KeyVault.ManagedHsm? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.KeyVault.ManagedHsmPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KeyVault.ManagedHsmPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.KeyVault.ManagedHsmSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.KeyVault.ManagedHsmPrivateEndpointConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_10_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_07_01;
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            public static readonly string V2023_08_01_PREVIEW;
            public static readonly string V2024_11_01;
        }
    }
    public partial class ManagedHsmPrivateEndpointConnectionItemData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedHsmPrivateEndpointConnectionItemData() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.KeyVault.ManagedHsmPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } }
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
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ScheduledPurgeOn { get { throw null; } }
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
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_B1")]
        StandardB1 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Custom_B32")]
        CustomB32 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Custom_B6")]
        CustomB6 = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Custom_C42")]
        CustomC42 = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Custom_C10")]
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
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> Created { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> Expires { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> NotBefore { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> Updated { get { throw null; } }
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
