namespace Azure.Provisioning.ContainerRegistry
{
    public enum AadAuthenticationAsArmPolicyStatus
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="enabled")]
        Enabled = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="disabled")]
        Disabled = 1,
    }
    public enum ActionsRequiredForPrivateLinkServiceConsumer
    {
        None = 0,
        Recreate = 1,
    }
    public partial class ConnectedRegistry : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ConnectedRegistry(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ConnectedRegistryActivationStatus> ActivationStatus { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Core.ResourceIdentifier> ClientTokenIds { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ConnectedRegistryParent ConnectedRegistryParent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ConnectedRegistryConnectionState> ConnectionState { get { throw null; } }
        public Azure.Provisioning.ContainerRegistry.GarbageCollectionProperties GarbageCollection { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastActivityOn { get { throw null; } }
        public Azure.Provisioning.ContainerRegistry.ConnectedRegistryLogging Logging { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ConnectedRegistryLoginServer LoginServer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ConnectedRegistryMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> NotificationsList { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.ConnectedRegistryStatusDetail> StatusDetails { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerRegistry.ConnectedRegistry FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_04_01;
        }
    }
    public enum ConnectedRegistryActivationStatus
    {
        Active = 0,
        Inactive = 1,
    }
    public enum ConnectedRegistryAuditLogStatus
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum ConnectedRegistryConnectionState
    {
        Online = 0,
        Offline = 1,
        Syncing = 2,
        Unhealthy = 3,
    }
    public partial class ConnectedRegistryLogging : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnectedRegistryLogging() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ConnectedRegistryAuditLogStatus> AuditLogStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ConnectedRegistryLogLevel> LogLevel { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ConnectedRegistryLoginServer : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnectedRegistryLoginServer() { }
        public Azure.Provisioning.BicepValue<string> Host { get { throw null; } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryTlsProperties Tls { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ConnectedRegistryLogLevel
    {
        Debug = 0,
        Information = 1,
        Warning = 2,
        Error = 3,
        None = 4,
    }
    public enum ConnectedRegistryMode
    {
        ReadWrite = 0,
        ReadOnly = 1,
        Registry = 2,
        Mirror = 3,
    }
    public partial class ConnectedRegistryParent : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnectedRegistryParent() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ConnectedRegistrySyncProperties SyncProperties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ConnectedRegistryStatusDetail : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnectedRegistryStatusDetail() { }
        public Azure.Provisioning.BicepValue<string> Code { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> CorrelationId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> StatusDetailType { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> Timestamp { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ConnectedRegistrySyncProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnectedRegistrySyncProperties() { }
        public Azure.Provisioning.BicepValue<string> GatewayEndpoint { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastSyncOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> MessageTtl { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Schedule { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> SyncWindow { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TokenId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryAgentPool : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerRegistryAgentPool(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<int> Count { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryOS> OS { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VirtualNetworkSubnetResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerRegistry.ContainerRegistryAgentPool FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_03_01;
            public static readonly string V2017_10_01;
            public static readonly string V2019_05_01;
            public static readonly string V2021_09_01;
            public static readonly string V2022_12_01;
            public static readonly string V2023_07_01;
            public static readonly string V2025_04_01;
        }
    }
    public partial class ContainerRegistryAuthCredential : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryAuthCredential() { }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryCredentialHealth CredentialHealth { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryCredentialName> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PasswordSecretIdentifier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UsernameSecretIdentifier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryBaseImageDependency : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryBaseImageDependency() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryBaseImageDependencyType> DependencyType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Digest { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Registry { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Repository { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Tag { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerRegistryBaseImageDependencyType
    {
        BuildTime = 0,
        RunTime = 1,
    }
    public partial class ContainerRegistryBaseImageTrigger : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryBaseImageTrigger() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryBaseImageTriggerType> BaseImageTriggerType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryTriggerStatus> Status { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UpdateTriggerEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryUpdateTriggerPayloadType> UpdateTriggerPayloadType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerRegistryBaseImageTriggerType
    {
        All = 0,
        Runtime = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryBuiltInRole : System.IEquatable<Azure.Provisioning.ContainerRegistry.ContainerRegistryBuiltInRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryBuiltInRole(string value) { throw null; }
        public static Azure.Provisioning.ContainerRegistry.ContainerRegistryBuiltInRole AcrDelete { get { throw null; } }
        public static Azure.Provisioning.ContainerRegistry.ContainerRegistryBuiltInRole AcrImageSigner { get { throw null; } }
        public static Azure.Provisioning.ContainerRegistry.ContainerRegistryBuiltInRole AcrPull { get { throw null; } }
        public static Azure.Provisioning.ContainerRegistry.ContainerRegistryBuiltInRole AcrPush { get { throw null; } }
        public static Azure.Provisioning.ContainerRegistry.ContainerRegistryBuiltInRole AcrQuarantineReader { get { throw null; } }
        public static Azure.Provisioning.ContainerRegistry.ContainerRegistryBuiltInRole AcrQuarantineWriter { get { throw null; } }
        public bool Equals(Azure.Provisioning.ContainerRegistry.ContainerRegistryBuiltInRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static string GetBuiltInRoleName(Azure.Provisioning.ContainerRegistry.ContainerRegistryBuiltInRole value) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Provisioning.ContainerRegistry.ContainerRegistryBuiltInRole left, Azure.Provisioning.ContainerRegistry.ContainerRegistryBuiltInRole right) { throw null; }
        public static implicit operator Azure.Provisioning.ContainerRegistry.ContainerRegistryBuiltInRole (string value) { throw null; }
        public static bool operator !=(Azure.Provisioning.ContainerRegistry.ContainerRegistryBuiltInRole left, Azure.Provisioning.ContainerRegistry.ContainerRegistryBuiltInRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryCacheRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerRegistryCacheRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CredentialSetResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SourceRepository { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TargetRepository { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerRegistry.ContainerRegistryCacheRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_07_01;
            public static readonly string V2025_04_01;
        }
    }
    public enum ContainerRegistryCertificateType
    {
        LocalDirectory = 0,
    }
    public enum ContainerRegistryCpuVariant
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="v6")]
        V6 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="v7")]
        V7 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="v8")]
        V8 = 2,
    }
    public partial class ContainerRegistryCredentialHealth : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryCredentialHealth() { }
        public Azure.Provisioning.BicepValue<string> ErrorCode { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ErrorMessage { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryCredentialHealthStatus> Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerRegistryCredentialHealthStatus
    {
        Healthy = 0,
        Unhealthy = 1,
    }
    public enum ContainerRegistryCredentialName
    {
        Credential1 = 0,
    }
    public partial class ContainerRegistryCredentials : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryCredentials() { }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.ContainerRegistry.CustomRegistryCredentials> CustomRegistries { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.SourceRegistryLoginMode> SourceRegistryLoginMode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryCredentialSet : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerRegistryCredentialSet(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.ContainerRegistryAuthCredential> AuthCredentials { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LoginServer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerRegistry.ContainerRegistryCredentialSet FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_07_01;
            public static readonly string V2025_04_01;
        }
    }
    public partial class ContainerRegistryDockerBuildContent : Azure.Provisioning.ContainerRegistry.ContainerRegistryRunContent
    {
        public ContainerRegistryDockerBuildContent() { }
        public Azure.Provisioning.BicepValue<int> AgentCpu { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.ContainerRegistryRunArgument> Arguments { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryCredentials Credentials { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DockerFilePath { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ImageNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsPushEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> NoCache { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryPlatformProperties Platform { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Target { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TimeoutInSeconds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryDockerBuildStep : Azure.Provisioning.ContainerRegistry.ContainerRegistryTaskStepProperties
    {
        public ContainerRegistryDockerBuildStep() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.ContainerRegistryRunArgument> Arguments { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DockerFilePath { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ImageNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsPushEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> NoCache { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Target { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryEncodedTaskRunContent : Azure.Provisioning.ContainerRegistry.ContainerRegistryRunContent
    {
        public ContainerRegistryEncodedTaskRunContent() { }
        public Azure.Provisioning.BicepValue<int> AgentCpu { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryCredentials Credentials { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncodedTaskContent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncodedValuesContent { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryPlatformProperties Platform { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TimeoutInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.ContainerRegistryTaskOverridableValue> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryEncodedTaskStep : Azure.Provisioning.ContainerRegistry.ContainerRegistryTaskStepProperties
    {
        public ContainerRegistryEncodedTaskStep() { }
        public Azure.Provisioning.BicepValue<string> EncodedTaskContent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncodedValuesContent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.ContainerRegistryTaskOverridableValue> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryEncryption : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryEncryption() { }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryEncryptionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerRegistryEncryptionStatus
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="enabled")]
        Enabled = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="disabled")]
        Disabled = 1,
    }
    public enum ContainerRegistryExportPolicyStatus
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="enabled")]
        Enabled = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="disabled")]
        Disabled = 1,
    }
    public partial class ContainerRegistryFileTaskRunContent : Azure.Provisioning.ContainerRegistry.ContainerRegistryRunContent
    {
        public ContainerRegistryFileTaskRunContent() { }
        public Azure.Provisioning.BicepValue<int> AgentCpu { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryCredentials Credentials { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryPlatformProperties Platform { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TaskFilePath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TimeoutInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.ContainerRegistryTaskOverridableValue> Values { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ValuesFilePath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryFileTaskStep : Azure.Provisioning.ContainerRegistry.ContainerRegistryTaskStepProperties
    {
        public ContainerRegistryFileTaskStep() { }
        public Azure.Provisioning.BicepValue<string> TaskFilePath { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.ContainerRegistryTaskOverridableValue> Values { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ValuesFilePath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryImageDescriptor : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryImageDescriptor() { }
        public Azure.Provisioning.BicepValue<string> Digest { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Registry { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Repository { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tag { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryImageUpdateTrigger : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryImageUpdateTrigger() { }
        public Azure.Provisioning.BicepValue<System.Guid> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.ContainerRegistryImageDescriptor> Images { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> Timestamp { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryIPRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryIPRule() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryIPRuleAction> Action { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IPAddressOrRange { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerRegistryIPRuleAction
    {
        Allow = 0,
    }
    public partial class ContainerRegistryKeyVaultProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryKeyVaultProperties() { }
        public Azure.Provisioning.BicepValue<string> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsKeyRotationEnabled { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> KeyIdentifier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastKeyRotationTimestamp { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> VersionedKeyIdentifier { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerRegistryNetworkRuleBypassOption
    {
        AzureServices = 0,
        None = 1,
    }
    public enum ContainerRegistryNetworkRuleDefaultAction
    {
        Allow = 0,
        Deny = 1,
    }
    public partial class ContainerRegistryNetworkRuleSet : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryNetworkRuleSet() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryNetworkRuleDefaultAction> DefaultAction { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.ContainerRegistryIPRule> IPRules { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerRegistryOS
    {
        Windows = 0,
        Linux = 1,
    }
    public enum ContainerRegistryOSArchitecture
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="amd64")]
        Amd64 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="x86")]
        X86 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="386")]
        ThreeHundredEightySix = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="arm")]
        Arm = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="arm64")]
        Arm64 = 4,
    }
    public partial class ContainerRegistryOverrideTaskStepProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryOverrideTaskStepProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.ContainerRegistryRunArgument> Arguments { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ContextPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> File { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Target { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UpdateTriggerToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.ContainerRegistryTaskOverridableValue> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryPlatformProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryPlatformProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryOSArchitecture> Architecture { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryOS> OS { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryCpuVariant> Variant { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryPolicies : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryPolicies() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.AadAuthenticationAsArmPolicyStatus> AzureADAuthenticationAsArmStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryExportPolicyStatus> ExportStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryPolicyStatus> QuarantineStatus { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryRetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryTrustPolicy TrustPolicy { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerRegistryPolicyStatus
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="enabled")]
        Enabled = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="disabled")]
        Disabled = 1,
    }
    public partial class ContainerRegistryPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerRegistryPrivateEndpointConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerRegistry.ContainerRegistryPrivateEndpointConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_09_01;
            public static readonly string V2022_12_01;
            public static readonly string V2023_07_01;
            public static readonly string V2025_04_01;
        }
    }
    public partial class ContainerRegistryPrivateEndpointConnectionData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryPrivateEndpointConnectionData() { }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryPrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryPrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ActionsRequiredForPrivateLinkServiceConsumer> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryPrivateLinkServiceConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerRegistryPrivateLinkServiceConnectionStatus
    {
        Approved = 0,
        Pending = 1,
        Rejected = 2,
        Disconnected = 3,
    }
    public enum ContainerRegistryProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Failed = 4,
        Canceled = 5,
    }
    public enum ContainerRegistryPublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class ContainerRegistryReplication : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerRegistryReplication(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsRegionEndpointEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryResourceStatus Status { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryZoneRedundancy> ZoneRedundancy { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerRegistry.ContainerRegistryReplication FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_10_01;
            public static readonly string V2019_05_01;
            public static readonly string V2021_09_01;
            public static readonly string V2022_12_01;
            public static readonly string V2023_07_01;
            public static readonly string V2025_04_01;
        }
    }
    public partial class ContainerRegistryResourceStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryResourceStatus() { }
        public Azure.Provisioning.BicepValue<string> DisplayStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> Timestamp { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryRetentionPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryRetentionPolicy() { }
        public Azure.Provisioning.BicepValue<int> Days { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastUpdatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryPolicyStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryRunArgument : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryRunArgument() { }
        public Azure.Provisioning.BicepValue<bool> IsSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryRunContent : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryRunContent() { }
        public Azure.Provisioning.BicepValue<string> AgentPoolName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsArchiveEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LogTemplate { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryRunData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryRunData() { }
        public Azure.Provisioning.BicepValue<int> AgentCpu { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AgentPoolName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> CustomRegistries { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> FinishOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryImageUpdateTrigger ImageUpdateTrigger { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsArchiveEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastUpdatedOn { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryImageDescriptor LogArtifact { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.ContainerRegistryImageDescriptor> OutputImages { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryPlatformProperties Platform { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryProvisioningState> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RunErrorMessage { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RunId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryRunType> RunType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceRegistryAuth { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistrySourceTriggerDescriptor SourceTrigger { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryRunStatus> Status { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Task { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryTimerTriggerDescriptor TimerTrigger { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UpdateTriggerToken { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerRegistryRunStatus
    {
        Queued = 0,
        Started = 1,
        Running = 2,
        Succeeded = 3,
        Failed = 4,
        Canceled = 5,
        Error = 6,
        Timeout = 7,
    }
    public enum ContainerRegistryRunType
    {
        QuickBuild = 0,
        QuickRun = 1,
        AutoBuild = 2,
        AutoRun = 3,
    }
    public partial class ContainerRegistrySecretObject : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistrySecretObject() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistrySecretObjectType> ObjectType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerRegistrySecretObjectType
    {
        Opaque = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Vaultsecret")]
        VaultSecret = 1,
    }
    public partial class ContainerRegistryService : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerRegistryService(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepList<string> DataEndpointHostNames { get { throw null; } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryEncryption Encryption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAdminUserEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAnonymousPullEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDataEndpointEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LoginServer { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryNetworkRuleBypassOption> NetworkRuleBypassOptions { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryNetworkRuleSet NetworkRuleSet { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryPolicies Policies { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistrySku Sku { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryResourceStatus Status { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryZoneRedundancy> ZoneRedundancy { get { throw null; } set { } }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.ContainerRegistry.ContainerRegistryBuiltInRole role, Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPrincipalType> principalType, Azure.Provisioning.BicepValue<System.Guid> principalId, string? bicepIdentifierSuffix = null) { throw null; }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.ContainerRegistry.ContainerRegistryBuiltInRole role, Azure.Provisioning.Roles.UserAssignedIdentity identity) { throw null; }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerRegistry.ContainerRegistryService FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_03_01;
            public static readonly string V2017_10_01;
            public static readonly string V2019_05_01;
            public static readonly string V2021_09_01;
            public static readonly string V2022_12_01;
            public static readonly string V2023_07_01;
            public static readonly string V2025_04_01;
        }
    }
    public partial class ContainerRegistrySku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistrySku() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistrySkuName> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistrySkuTier> Tier { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerRegistrySkuName
    {
        Classic = 0,
        Basic = 1,
        Standard = 2,
        Premium = 3,
    }
    public enum ContainerRegistrySkuTier
    {
        Classic = 0,
        Basic = 1,
        Standard = 2,
        Premium = 3,
    }
    public partial class ContainerRegistrySourceTrigger : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistrySourceTrigger() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.SourceCodeRepoProperties SourceRepository { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.ContainerRegistrySourceTriggerEvent> SourceTriggerEvents { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryTriggerStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistrySourceTriggerDescriptor : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistrySourceTriggerDescriptor() { }
        public Azure.Provisioning.BicepValue<string> BranchName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CommitId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EventType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProviderType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PullRequestId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> RepositoryUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerRegistrySourceTriggerEvent
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="commit")]
        Commit = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="pullrequest")]
        PullRequest = 1,
    }
    public partial class ContainerRegistryTask : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerRegistryTask(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<int> AgentCpu { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AgentPoolName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryCredentials Credentials { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSystemTask { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LogTemplate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryPlatformProperties Platform { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryTaskStatus> Status { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryTaskStepProperties Step { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TimeoutInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryTriggerProperties Trigger { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerRegistry.ContainerRegistryTask FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_09_01;
            public static readonly string V2019_04_01;
        }
    }
    public partial class ContainerRegistryTaskOverridableValue : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryTaskOverridableValue() { }
        public Azure.Provisioning.BicepValue<bool> IsSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryTaskRun : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerRegistryTaskRun(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ForceUpdateTag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryRunContent RunRequest { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryRunData RunResult { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerRegistry.ContainerRegistryTaskRun FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_03_01;
            public static readonly string V2017_10_01;
            public static readonly string V2019_05_01;
            public static readonly string V2021_09_01;
            public static readonly string V2022_12_01;
            public static readonly string V2023_07_01;
            public static readonly string V2025_04_01;
        }
    }
    public partial class ContainerRegistryTaskRunContent : Azure.Provisioning.ContainerRegistry.ContainerRegistryRunContent
    {
        public ContainerRegistryTaskRunContent() { }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryOverrideTaskStepProperties OverrideTaskStepProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TaskId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerRegistryTaskStatus
    {
        Disabled = 0,
        Enabled = 1,
    }
    public partial class ContainerRegistryTaskStepProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryTaskStepProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.ContainerRegistryBaseImageDependency> BaseImageDependencies { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ContextAccessToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ContextPath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryTimerTrigger : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryTimerTrigger() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Schedule { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryTriggerStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryTimerTriggerDescriptor : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryTimerTriggerDescriptor() { }
        public Azure.Provisioning.BicepValue<string> ScheduleOccurrence { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TimerTriggerName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryTlsCertificateProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryTlsCertificateProperties() { }
        public Azure.Provisioning.BicepValue<string> CertificateLocation { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryCertificateType> CertificateType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryTlsProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryTlsProperties() { }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryTlsCertificateProperties Certificate { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryTlsStatus> Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerRegistryTlsStatus
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class ContainerRegistryToken : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerRegistryToken(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryTokenCredentials Credentials { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ScopeMapId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryTokenStatus> Status { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerRegistry.ContainerRegistryToken FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_12_01;
            public static readonly string V2023_07_01;
            public static readonly string V2025_04_01;
        }
    }
    public partial class ContainerRegistryTokenCertificate : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryTokenCertificate() { }
        public Azure.Provisioning.BicepValue<string> EncodedPemCertificate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryTokenCertificateName> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Thumbprint { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerRegistryTokenCertificateName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="certificate1")]
        Certificate1 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="certificate2")]
        Certificate2 = 1,
    }
    public partial class ContainerRegistryTokenCredentials : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryTokenCredentials() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.ContainerRegistryTokenCertificate> Certificates { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.ContainerRegistryTokenPassword> Passwords { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryTokenPassword : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryTokenPassword() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryTokenPasswordName> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerRegistryTokenPasswordName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="password1")]
        Password1 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="password2")]
        Password2 = 1,
    }
    public enum ContainerRegistryTokenStatus
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="enabled")]
        Enabled = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="disabled")]
        Disabled = 1,
    }
    public partial class ContainerRegistryTriggerProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryTriggerProperties() { }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryBaseImageTrigger BaseImageTrigger { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.ContainerRegistrySourceTrigger> SourceTriggers { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.ContainerRegistryTimerTrigger> TimerTriggers { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerRegistryTriggerStatus
    {
        Disabled = 0,
        Enabled = 1,
    }
    public partial class ContainerRegistryTrustPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryTrustPolicy() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryTrustPolicyType> PolicyType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryPolicyStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerRegistryTrustPolicyType
    {
        Notary = 0,
    }
    public enum ContainerRegistryUpdateTriggerPayloadType
    {
        Default = 0,
        Token = 1,
    }
    public partial class ContainerRegistryWebhook : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerRegistryWebhook(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.ContainerRegistryWebhookAction> Actions { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> CustomHeaders { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ServiceUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryWebhookStatus> Status { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerRegistry.ContainerRegistryWebhook FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_10_01;
            public static readonly string V2019_05_01;
            public static readonly string V2021_09_01;
            public static readonly string V2022_12_01;
            public static readonly string V2023_07_01;
            public static readonly string V2025_04_01;
        }
    }
    public enum ContainerRegistryWebhookAction
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="push")]
        Push = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="delete")]
        Delete = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="quarantine")]
        Quarantine = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="chart_push")]
        ChartPush = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="chart_delete")]
        ChartDelete = 4,
    }
    public enum ContainerRegistryWebhookStatus
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="enabled")]
        Enabled = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="disabled")]
        Disabled = 1,
    }
    public enum ContainerRegistryZoneRedundancy
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class CustomRegistryCredentials : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CustomRegistryCredentials() { }
        public Azure.Provisioning.BicepValue<string> Identity { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistrySecretObject Password { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistrySecretObject UserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GarbageCollectionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GarbageCollectionProperties() { }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Schedule { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ScopeMap : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ScopeMap(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> Actions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.ContainerRegistryService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.ContainerRegistryProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ScopeMapType { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerRegistry.ScopeMap FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_12_01;
            public static readonly string V2023_07_01;
            public static readonly string V2025_04_01;
        }
    }
    public partial class SourceCodeRepoAuthInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SourceCodeRepoAuthInfo() { }
        public Azure.Provisioning.BicepValue<int> ExpireInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RefreshToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Token { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.SourceCodeRepoAuthTokenType> TokenType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SourceCodeRepoAuthTokenType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="PAT")]
        Pat = 0,
        OAuth = 1,
    }
    public partial class SourceCodeRepoProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SourceCodeRepoProperties() { }
        public Azure.Provisioning.BicepValue<string> Branch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> RepositoryUri { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.SourceCodeRepoAuthInfo SourceControlAuthProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.SourceControlType> SourceControlType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SourceControlType
    {
        Github = 0,
        VisualStudioTeamService = 1,
    }
    public enum SourceRegistryLoginMode
    {
        None = 0,
        Default = 1,
    }
}
