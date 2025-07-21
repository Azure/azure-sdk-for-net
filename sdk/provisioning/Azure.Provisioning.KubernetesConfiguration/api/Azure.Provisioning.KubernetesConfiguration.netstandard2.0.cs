namespace Azure.Provisioning.KubernetesConfiguration
{
    public partial class HelmOperatorProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HelmOperatorProperties() { }
        public Azure.Provisioning.BicepValue<string> ChartValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ChartVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HelmReleaseProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HelmReleaseProperties() { }
        public Azure.Provisioning.BicepValue<long> FailureCount { get { throw null; } }
        public Azure.Provisioning.KubernetesConfiguration.KubernetesObjectReference HelmChartRef { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> InstallFailureCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> LastRevisionApplied { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> UpgradeFailureCount { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KubernetesAzureBlob : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KubernetesAzureBlob() { }
        public Azure.Provisioning.BicepValue<string> AccountKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ContainerName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LocalAuthRef { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> ManagedIdentityClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SasToken { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.KubernetesServicePrincipal ServicePrincipal { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> SyncIntervalInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> TimeoutInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KubernetesBucket : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KubernetesBucket() { }
        public Azure.Provisioning.BicepValue<string> AccessKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> BucketName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LocalAuthRef { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> SyncIntervalInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> TimeoutInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseInsecureCommunication { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KubernetesClusterExtension : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public KubernetesClusterExtension(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Resources.ManagedServiceIdentity AksAssignedIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AutoUpgradeMinorVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> ConfigurationProtectedSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> ConfigurationSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CurrentVersion { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> CustomLocationSettings { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ResponseError> ErrorInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ExtensionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSystemExtension { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> PackageUri { get { throw null; } }
        public Azure.Provisioning.Resources.ArmPlan Plan { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.KubernetesConfigurationProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ReleaseTrain { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.KubernetesClusterExtensionScope Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.KubernetesConfiguration.KubernetesClusterExtensionStatus> Statuses { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.KubernetesConfiguration.KubernetesConfigurationBuiltInRole role, Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPrincipalType> principalType, Azure.Provisioning.BicepValue<System.Guid> principalId, string? bicepIdentifierSuffix = null) { throw null; }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.KubernetesConfiguration.KubernetesConfigurationBuiltInRole role, Azure.Provisioning.Roles.UserAssignedIdentity identity) { throw null; }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.KubernetesConfiguration.KubernetesClusterExtension FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_03_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class KubernetesClusterExtensionScope : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KubernetesClusterExtensionScope() { }
        public Azure.Provisioning.BicepValue<string> ClusterReleaseNamespace { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TargetNamespace { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KubernetesClusterExtensionStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KubernetesClusterExtensionStatus() { }
        public Azure.Provisioning.BicepValue<string> Code { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.KubernetesClusterExtensionStatusLevel> Level { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Time { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum KubernetesClusterExtensionStatusLevel
    {
        Error = 0,
        Warning = 1,
        Information = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KubernetesConfigurationBuiltInRole : System.IEquatable<Azure.Provisioning.KubernetesConfiguration.KubernetesConfigurationBuiltInRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KubernetesConfigurationBuiltInRole(string value) { throw null; }
        public static Azure.Provisioning.KubernetesConfiguration.KubernetesConfigurationBuiltInRole AzureContainerStorageContributor { get { throw null; } }
        public static Azure.Provisioning.KubernetesConfiguration.KubernetesConfigurationBuiltInRole AzureContainerStorageOperator { get { throw null; } }
        public static Azure.Provisioning.KubernetesConfiguration.KubernetesConfigurationBuiltInRole AzureContainerStorageOwner { get { throw null; } }
        public static Azure.Provisioning.KubernetesConfiguration.KubernetesConfigurationBuiltInRole KubernetesExtensionContributor { get { throw null; } }
        public bool Equals(Azure.Provisioning.KubernetesConfiguration.KubernetesConfigurationBuiltInRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static string GetBuiltInRoleName(Azure.Provisioning.KubernetesConfiguration.KubernetesConfigurationBuiltInRole value) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Provisioning.KubernetesConfiguration.KubernetesConfigurationBuiltInRole left, Azure.Provisioning.KubernetesConfiguration.KubernetesConfigurationBuiltInRole right) { throw null; }
        public static implicit operator Azure.Provisioning.KubernetesConfiguration.KubernetesConfigurationBuiltInRole (string value) { throw null; }
        public static bool operator !=(Azure.Provisioning.KubernetesConfiguration.KubernetesConfigurationBuiltInRole left, Azure.Provisioning.KubernetesConfiguration.KubernetesConfigurationBuiltInRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum KubernetesConfigurationComplianceStateType
    {
        Pending = 0,
        Compliant = 1,
        Noncompliant = 2,
        Installed = 3,
        Failed = 4,
    }
    public partial class KubernetesConfigurationComplianceStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KubernetesConfigurationComplianceStatus() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.KubernetesConfigurationComplianceStateType> ComplianceState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastConfigAppliedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.KubernetesConfigurationMesageLevel> MessageLevel { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum KubernetesConfigurationMesageLevel
    {
        Error = 0,
        Warning = 1,
        Information = 2,
    }
    public enum KubernetesConfigurationProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        Creating = 3,
        Updating = 4,
        Deleting = 5,
    }
    public enum KubernetesConfigurationProvisioningStateType
    {
        Accepted = 0,
        Deleting = 1,
        Running = 2,
        Succeeded = 3,
        Failed = 4,
    }
    public enum KubernetesConfigurationScope
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="cluster")]
        Cluster = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="namespace")]
        Namespace = 1,
    }
    public enum KubernetesConfigurationSourceKind
    {
        GitRepository = 0,
        Bucket = 1,
        AzureBlob = 2,
    }
    public enum KubernetesFluxComplianceState
    {
        Compliant = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Non-Compliant")]
        NonCompliant = 1,
        Pending = 2,
        Suspended = 3,
        Unknown = 4,
    }
    public partial class KubernetesFluxConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public KubernetesFluxConfiguration(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.KubernetesConfiguration.KubernetesAzureBlob AzureBlob { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.KubernetesBucket Bucket { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.KubernetesFluxComplianceState> ComplianceState { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> ConfigurationProtectedSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ErrorMessage { get { throw null; } }
        public Azure.Provisioning.KubernetesConfiguration.KubernetesGitRepository GitRepository { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsReconciliationSuspended { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.KubernetesConfiguration.Kustomization> Kustomizations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Namespace { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.KubernetesConfigurationProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RepositoryPublicKey { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.KubernetesConfigurationScope> Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.KubernetesConfigurationSourceKind> SourceKind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceSyncedCommitId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> SourceUpdatedOn { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.KubernetesConfiguration.KubernetesObjectStatus> Statuses { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StatusUpdatedOn { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.KubernetesConfiguration.KubernetesConfigurationBuiltInRole role, Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPrincipalType> principalType, Azure.Provisioning.BicepValue<System.Guid> principalId, string? bicepIdentifierSuffix = null) { throw null; }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.KubernetesConfiguration.KubernetesConfigurationBuiltInRole role, Azure.Provisioning.Roles.UserAssignedIdentity identity) { throw null; }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.KubernetesConfiguration.KubernetesFluxConfiguration FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_03_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_05_01;
            public static readonly string V2024_11_01;
        }
    }
    public partial class KubernetesGitRepository : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KubernetesGitRepository() { }
        public Azure.Provisioning.BicepValue<string> HttpsCACert { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HttpsUser { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LocalAuthRef { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.KubernetesGitRepositoryRef RepositoryRef { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SshKnownHosts { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> SyncIntervalInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> TimeoutInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KubernetesGitRepositoryRef : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KubernetesGitRepositoryRef() { }
        public Azure.Provisioning.BicepValue<string> Branch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Commit { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Semver { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tag { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KubernetesObjectReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KubernetesObjectReference() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Namespace { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KubernetesObjectStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KubernetesObjectStatus() { }
        public Azure.Provisioning.KubernetesConfiguration.KubernetesObjectReference AppliedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.KubernetesFluxComplianceState> ComplianceState { get { throw null; } }
        public Azure.Provisioning.KubernetesConfiguration.HelmReleaseProperties HelmReleaseProperties { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Namespace { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.KubernetesConfiguration.KubernetesObjectStatusCondition> StatusConditions { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KubernetesObjectStatusCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KubernetesObjectStatusCondition() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastTransitionOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ObjectStatusConditionDefinitionType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Reason { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum KubernetesOperator
    {
        Flux = 0,
    }
    public enum KubernetesOperatorScope
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="cluster")]
        Cluster = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="namespace")]
        Namespace = 1,
    }
    public partial class KubernetesServicePrincipal : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KubernetesServicePrincipal() { }
        public Azure.Provisioning.BicepValue<string> ClientCertificate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientCertificatePassword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ClientCertificateSendChain { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KubernetesSourceControlConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public KubernetesSourceControlConfiguration(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.KubernetesConfiguration.KubernetesConfigurationComplianceStatus ComplianceStatus { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> ConfigurationProtectedSettings { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.HelmOperatorProperties HelmOperatorProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsHelmOperatorEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OperatorInstanceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OperatorNamespace { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OperatorParams { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.KubernetesOperatorScope> OperatorScope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.KubernetesOperator> OperatorType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.KubernetesConfigurationProvisioningStateType> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RepositoryPublicKey { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> RepositoryUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SshKnownHostsContents { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.KubernetesConfiguration.KubernetesSourceControlConfiguration FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_03_01;
            public static readonly string V2022_03_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_05_01;
        }
    }
    public partial class Kustomization : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public Kustomization() { }
        public Azure.Provisioning.BicepList<string> DependsOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Force { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Prune { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> RetryIntervalInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> SyncIntervalInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> TimeoutInSeconds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
