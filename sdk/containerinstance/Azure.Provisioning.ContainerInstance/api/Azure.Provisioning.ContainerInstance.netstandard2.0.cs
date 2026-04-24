namespace Azure.Provisioning.ContainerInstance
{
    public partial class ApplicationGateway : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGateway() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerInstance.ApplicationGatewayBackendAddressPool> BackendAddressPools { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Resource { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationGatewayBackendAddressPool : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayBackendAddressPool() { }
        public Azure.Provisioning.BicepValue<string> Resource { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AzureFileShareAccessTier
    {
        Cool = 0,
        Hot = 1,
        Premium = 2,
        TransactionOptimized = 3,
    }
    public enum AzureFileShareAccessType
    {
        Shared = 0,
        Exclusive = 1,
    }
    public partial class ContainerEnvironmentVariable : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerEnvironmentVariable() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecureValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecureValueReference { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerEvent : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerEvent() { }
        public Azure.Provisioning.BicepValue<int> Count { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> EventType { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> FirstTimestamp { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastTimestamp { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerGpuResourceInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerGpuResourceInfo() { }
        public Azure.Provisioning.BicepValue<int> Count { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerInstance.ContainerGpuSku> Sku { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerGpuSku
    {
        K80 = 0,
        P100 = 1,
        V100 = 2,
    }
    public partial class ContainerGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerGroup(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ConfidentialComputeCcePolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerInstance.ContainerInstanceOperatingSystemType> ContainerGroupOSType { get { throw null; } set { } }
        public Azure.Provisioning.ContainerInstance.ContainerGroupProfileReferenceDefinition ContainerGroupProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerInstance.ContainerInstanceContainer> Containers { get { throw null; } set { } }
        public Azure.Provisioning.ContainerInstance.ContainerGroupLogAnalytics DiagnosticsLogAnalytics { get { throw null; } set { } }
        public Azure.Provisioning.ContainerInstance.ContainerGroupDnsConfiguration DnsConfig { get { throw null; } set { } }
        public Azure.Provisioning.ContainerInstance.ContainerGroupEncryptionProperties EncryptionProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerInstance.DeploymentExtensionSpec> Extensions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.ContainerInstance.ContainerGroupIdentityAccessControlLevels IdentityAcls { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerInstance.ContainerGroupImageRegistryCredential> ImageRegistryCredentials { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerInstance.InitContainerDefinitionContent> InitContainers { get { throw null; } set { } }
        public Azure.Provisioning.ContainerInstance.ContainerGroupInstanceView InstanceView { get { throw null; } }
        public Azure.Provisioning.ContainerInstance.ContainerGroupIPAddress IPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsCreatedFromStandbyPool { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerInstance.ContainerGroupPriority> Priority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerInstance.ContainerGroupRestartPolicy> RestartPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerInstance.ContainerGroupSecretReference> SecretReferences { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerInstance.ContainerGroupSku> Sku { get { throw null; } set { } }
        public Azure.Provisioning.ContainerInstance.StandbyPoolProfileDefinition StandbyPoolProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerInstance.ContainerGroupSubnetId> SubnetIds { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerInstance.ContainerVolume> Volumes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerInstance.ContainerGroup FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_09_01;
        }
    }
    public partial class ContainerGroupDnsConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerGroupDnsConfiguration() { }
        public Azure.Provisioning.BicepList<string> NameServers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Options { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SearchDomains { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerGroupElasticProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerGroupElasticProfile() { }
        public Azure.Provisioning.BicepValue<int> DesiredCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GuidNamingPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> MaintainDesiredCount { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerGroupEncryptionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerGroupEncryptionProperties() { }
        public Azure.Provisioning.BicepValue<string> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> VaultBaseUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerGroupFileShare : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerGroupFileShare() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerInstance.ContainerGroupFileShareProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceGroupName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerGroupFileShareProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerGroupFileShareProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerInstance.AzureFileShareAccessTier> ShareAccessTier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerInstance.AzureFileShareAccessType> ShareAccessType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerGroupIdentityAccessControl : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerGroupIdentityAccessControl() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerInstance.ContainerGroupIdentityAccessLevel> Access { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Identity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerGroupIdentityAccessControlLevels : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerGroupIdentityAccessControlLevels() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerInstance.ContainerGroupIdentityAccessControl> Acls { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerInstance.ContainerGroupIdentityAccessLevel> DefaultAccess { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerGroupIdentityAccessLevel
    {
        All = 0,
        System = 1,
        User = 2,
    }
    public partial class ContainerGroupImageRegistryCredential : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerGroupImageRegistryCredential() { }
        public Azure.Provisioning.BicepValue<string> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> IdentityUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PasswordReference { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Server { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerGroupInstanceView : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerGroupInstanceView() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerInstance.ContainerEvent> Events { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> State { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerGroupIPAddress : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerGroupIPAddress() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerInstance.ContainerGroupIPAddressType> AddressType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerInstance.DnsNameLabelReusePolicy> AutoGeneratedDomainNameLabelScope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DnsNameLabel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Fqdn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Net.IPAddress> IP { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerInstance.ContainerGroupPort> Ports { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerGroupIPAddressType
    {
        Public = 0,
        Private = 1,
    }
    public partial class ContainerGroupLogAnalytics : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerGroupLogAnalytics() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerInstance.ContainerGroupLogAnalyticsLogType> LogType { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkspaceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkspaceKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> WorkspaceResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerGroupLogAnalyticsLogType
    {
        ContainerInsights = 0,
        ContainerInstanceLogs = 1,
    }
    public partial class ContainerGroupNetworkProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerGroupNetworkProfile() { }
        public Azure.Provisioning.ContainerInstance.ApplicationGateway ApplicationGateway { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerInstance.LoadBalancerBackendAddressPool> LoadBalancerBackendAddressPools { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerGroupNetworkProtocol
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="TCP")]
        Tcp = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UDP")]
        Udp = 1,
    }
    public partial class ContainerGroupPort : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerGroupPort() { }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerInstance.ContainerGroupNetworkProtocol> Protocol { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerGroupPriority
    {
        Regular = 0,
        Spot = 1,
    }
    public partial class ContainerGroupProfile : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerGroupProfile(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ConfidentialComputeCcePolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerInstance.ContainerInstanceContainer> Containers { get { throw null; } set { } }
        public Azure.Provisioning.ContainerInstance.ContainerGroupLogAnalytics DiagnosticsLogAnalytics { get { throw null; } set { } }
        public Azure.Provisioning.ContainerInstance.ContainerGroupEncryptionProperties EncryptionProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerInstance.DeploymentExtensionSpec> Extensions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerInstance.ContainerGroupImageRegistryCredential> ImageRegistryCredentials { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerInstance.InitContainerDefinitionContent> InitContainers { get { throw null; } set { } }
        public Azure.Provisioning.ContainerInstance.ContainerGroupIPAddress IPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerInstance.ContainerInstanceOperatingSystemType> OSType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerInstance.ContainerGroupPriority> Priority { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<int> RegisteredRevisions { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerInstance.ContainerGroupRestartPolicy> RestartPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Revision { get { throw null; } }
        public Azure.Provisioning.ContainerInstance.ContainerSecurityContextDefinition SecurityContext { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ShutdownGracePeriod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerInstance.ContainerGroupSku> Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> TimeToLive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseKrypton { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerInstance.ContainerVolume> Volumes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerInstance.ContainerGroupProfile FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_09_01;
        }
    }
    public partial class ContainerGroupProfileReferenceDefinition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerGroupProfileReferenceDefinition() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Revision { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerGroupProfileRevision : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerGroupProfileRevision(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerInstance.ContainerGroupProfile Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerInstance.ContainerGroupProfileRevision FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_09_01;
        }
    }
    public partial class ContainerGroupProfileStub : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerGroupProfileStub() { }
        public Azure.Provisioning.ContainerInstance.NGroupContainerGroupProperties ContainerGroupProperties { get { throw null; } set { } }
        public Azure.Provisioning.ContainerInstance.ContainerGroupNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Revision { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerInstance.ContainerGroupFileShare> StorageFileShares { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerGroupRestartPolicy
    {
        Always = 0,
        OnFailure = 1,
        Never = 2,
    }
    public partial class ContainerGroupSecretReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerGroupSecretReference() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> SecretReferenceUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerGroupSku
    {
        NotSpecified = 0,
        Standard = 1,
        Dedicated = 2,
        Confidential = 3,
    }
    public partial class ContainerGroupSubnetId : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerGroupSubnetId() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerHttpGet : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerHttpGet() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerInstance.ContainerHttpHeader> HttpHeaders { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerInstance.ContainerHttpGetScheme> Scheme { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerHttpGetScheme
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="http")]
        Http = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="https")]
        Https = 1,
    }
    public partial class ContainerHttpHeader : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerHttpHeader() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerInstanceAzureFileVolume : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerInstanceAzureFileVolume() { }
        public Azure.Provisioning.BicepValue<bool> IsReadOnly { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ShareName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountKeyReference { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerInstanceContainer : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerInstanceContainer() { }
        public Azure.Provisioning.BicepList<string> Command { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> ConfigMapKeyValuePairs { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerInstance.ContainerEnvironmentVariable> EnvironmentVariables { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Image { get { throw null; } set { } }
        public Azure.Provisioning.ContainerInstance.ContainerInstanceView InstanceView { get { throw null; } }
        public Azure.Provisioning.ContainerInstance.ContainerProbe LivenessProbe { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerInstance.ContainerPort> Ports { get { throw null; } set { } }
        public Azure.Provisioning.ContainerInstance.ContainerProbe ReadinessProbe { get { throw null; } set { } }
        public Azure.Provisioning.ContainerInstance.ContainerResourceRequirements Resources { get { throw null; } set { } }
        public Azure.Provisioning.ContainerInstance.ContainerSecurityContextDefinition SecurityContext { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerInstance.ContainerVolumeMount> VolumeMounts { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerInstanceGitRepoVolume : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerInstanceGitRepoVolume() { }
        public Azure.Provisioning.BicepValue<string> Directory { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Repository { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Revision { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerInstanceOperatingSystemType
    {
        Windows = 0,
        Linux = 1,
    }
    public partial class ContainerInstanceView : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerInstanceView() { }
        public Azure.Provisioning.ContainerInstance.ContainerState CurrentState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerInstance.ContainerEvent> Events { get { throw null; } }
        public Azure.Provisioning.ContainerInstance.ContainerState PreviousState { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> RestartCount { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerNetworkProtocol
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="TCP")]
        Tcp = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UDP")]
        Udp = 1,
    }
    public partial class ContainerPort : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerPort() { }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerInstance.ContainerNetworkProtocol> Protocol { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerProbe : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerProbe() { }
        public Azure.Provisioning.BicepList<string> ExecCommand { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FailureThreshold { get { throw null; } set { } }
        public Azure.Provisioning.ContainerInstance.ContainerHttpGet HttpGet { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> InitialDelayInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PeriodInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SuccessThreshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TimeoutInSeconds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerResourceLimits : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerResourceLimits() { }
        public Azure.Provisioning.BicepValue<double> Cpu { get { throw null; } set { } }
        public Azure.Provisioning.ContainerInstance.ContainerGpuResourceInfo Gpu { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> MemoryInGB { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerResourceRequestsContent : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerResourceRequestsContent() { }
        public Azure.Provisioning.BicepValue<double> Cpu { get { throw null; } set { } }
        public Azure.Provisioning.ContainerInstance.ContainerGpuResourceInfo Gpu { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> MemoryInGB { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerResourceRequirements : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerResourceRequirements() { }
        public Azure.Provisioning.ContainerInstance.ContainerResourceLimits Limits { get { throw null; } set { } }
        public Azure.Provisioning.ContainerInstance.ContainerResourceRequestsContent Requests { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerSecurityContextCapabilitiesDefinition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerSecurityContextCapabilitiesDefinition() { }
        public Azure.Provisioning.BicepList<string> Add { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Drop { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerSecurityContextDefinition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerSecurityContextDefinition() { }
        public Azure.Provisioning.BicepValue<bool> AllowPrivilegeEscalation { get { throw null; } set { } }
        public Azure.Provisioning.ContainerInstance.ContainerSecurityContextCapabilitiesDefinition Capabilities { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsPrivileged { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RunAsGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RunAsUser { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SeccompProfile { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerState() { }
        public Azure.Provisioning.BicepValue<string> DetailStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> ExitCode { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> FinishOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> State { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerVolume : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerVolume() { }
        public Azure.Provisioning.ContainerInstance.ContainerInstanceAzureFileVolume AzureFile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> EmptyDir { get { throw null; } set { } }
        public Azure.Provisioning.ContainerInstance.ContainerInstanceGitRepoVolume GitRepo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Secret { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> SecretReference { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerVolumeMount : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerVolumeMount() { }
        public Azure.Provisioning.BicepValue<bool> IsReadOnly { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MountPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeploymentExtensionSpec : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DeploymentExtensionSpec() { }
        public Azure.Provisioning.BicepValue<string> ExtensionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> ProtectedSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Settings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DnsNameLabelReusePolicy
    {
        Unsecure = 0,
        TenantReuse = 1,
        SubscriptionReuse = 2,
        ResourceGroupReuse = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Noreuse")]
        NoReuse = 4,
    }
    public partial class InitContainerDefinitionContent : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public InitContainerDefinitionContent() { }
        public Azure.Provisioning.BicepList<string> Command { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerInstance.ContainerEnvironmentVariable> EnvironmentVariables { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Image { get { throw null; } set { } }
        public Azure.Provisioning.ContainerInstance.InitContainerPropertiesDefinitionInstanceView InstanceView { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerInstance.ContainerSecurityContextDefinition SecurityContext { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerInstance.ContainerVolumeMount> VolumeMounts { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class InitContainerPropertiesDefinitionInstanceView : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public InitContainerPropertiesDefinitionInstanceView() { }
        public Azure.Provisioning.ContainerInstance.ContainerState CurrentState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerInstance.ContainerEvent> Events { get { throw null; } }
        public Azure.Provisioning.ContainerInstance.ContainerState PreviousState { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> RestartCount { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LoadBalancerBackendAddressPool : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LoadBalancerBackendAddressPool() { }
        public Azure.Provisioning.BicepValue<string> Resource { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NGroup(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerInstance.ContainerGroupProfileStub> ContainerGroupProfiles { get { throw null; } set { } }
        public Azure.Provisioning.ContainerInstance.ContainerGroupElasticProfile ElasticProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PlacementFaultDomainCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerInstance.NGroupProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.ContainerInstance.NGroupUpdateProfile UpdateProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerInstance.NGroup FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_09_01;
        }
    }
    public partial class NGroupContainerGroupProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NGroupContainerGroupProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerInstance.NGroupContainerGroupPropertyContainer> Containers { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerInstance.ContainerGroupSubnetId> SubnetIds { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerInstance.NGroupContainerGroupPropertyVolume> Volumes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NGroupContainerGroupPropertyContainer : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NGroupContainerGroupPropertyContainer() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerInstance.ContainerVolumeMount> NGroupCGPropertyContainerVolumeMounts { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NGroupContainerGroupPropertyVolume : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NGroupContainerGroupPropertyVolume() { }
        public Azure.Provisioning.ContainerInstance.ContainerInstanceAzureFileVolume AzureFile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum NGroupProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Failed = 2,
        Succeeded = 3,
        Canceled = 4,
        Deleting = 5,
        Migrating = 6,
    }
    public partial class NGroupRollingUpdateProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NGroupRollingUpdateProfile() { }
        public Azure.Provisioning.BicepValue<bool> InPlaceUpdate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxBatchPercent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxUnhealthyPercent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PauseTimeBetweenBatches { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum NGroupUpdateMode
    {
        Manual = 0,
        Rolling = 1,
    }
    public partial class NGroupUpdateProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NGroupUpdateProfile() { }
        public Azure.Provisioning.ContainerInstance.NGroupRollingUpdateProfile RollingUpdateProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerInstance.NGroupUpdateMode> UpdateMode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StandbyPoolProfileDefinition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StandbyPoolProfileDefinition() { }
        public Azure.Provisioning.BicepValue<bool> FailContainerGroupCreateOnReuseFailure { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
