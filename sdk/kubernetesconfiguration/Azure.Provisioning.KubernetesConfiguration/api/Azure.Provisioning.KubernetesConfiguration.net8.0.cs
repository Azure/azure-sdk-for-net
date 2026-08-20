namespace Azure.Provisioning.KubernetesConfiguration
{
    public partial class AzureBlob : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AzureBlob() { }
        public Azure.Provisioning.BicepValue<string> AccountKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ContainerName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LocalAuthRef { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ManagedIdentityClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SasToken { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.FluxServicePrincipal ServicePrincipal { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> SyncIntervalInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> TimeoutInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FluxBucket : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FluxBucket() { }
        public Azure.Provisioning.BicepValue<string> AccessKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> BucketName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsInsecure { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LocalAuthRef { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> SyncIntervalInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> TimeoutInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum FluxComplianceState
    {
        Compliant = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Non-Compliant")]
        NonCompliant = 1,
        Pending = 2,
        Suspended = 3,
        Unknown = 4,
    }
    public enum FluxConfigurationOperationType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="extract")]
        Extract = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="copy")]
        Copy = 1,
    }
    public enum FluxConfigurationProviderType
    {
        Azure = 0,
        GitHub = 1,
        Generic = 2,
    }
    public enum FluxConfigurationProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        Creating = 3,
        Updating = 4,
        Deleting = 5,
    }
    public enum FluxConfigurationScopeType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="cluster")]
        Cluster = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="namespace")]
        Namespace = 1,
    }
    public enum FluxConfigurationSourceKindType
    {
        GitRepository = 0,
        Bucket = 1,
        AzureBlob = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="OCIRepository")]
        OciRepository = 3,
    }
    public partial class FluxGitRepository : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FluxGitRepository() { }
        public Azure.Provisioning.BicepValue<string> HttpsCACert { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HttpsUser { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LocalAuthRef { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.FluxConfigurationProviderType> Provider { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.FluxRepositoryReference RepositoryRef { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SshKnownHosts { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> SyncIntervalInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> TimeoutInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FluxLayerSelector : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FluxLayerSelector() { }
        public Azure.Provisioning.BicepValue<string> MediaType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.FluxConfigurationOperationType> Operation { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FluxObjectReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FluxObjectReference() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Namespace { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FluxObjectStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FluxObjectStatus() { }
        public Azure.Provisioning.KubernetesConfiguration.FluxObjectReference AppliedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.FluxComplianceState> ComplianceState { get { throw null; } }
        public Azure.Provisioning.KubernetesConfiguration.HelmReleaseProperties HelmReleaseProperties { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Namespace { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.KubernetesConfiguration.FluxObjectStatusCondition> StatusConditions { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FluxObjectStatusCondition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FluxObjectStatusCondition() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastTransitionOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Reason { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Type { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FluxPostBuild : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FluxPostBuild() { }
        public Azure.Provisioning.BicepDictionary<string> Substitute { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.KubernetesConfiguration.FluxSubstitution> SubstituteFrom { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FluxRepositoryReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FluxRepositoryReference() { }
        public Azure.Provisioning.BicepValue<string> Branch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Commit { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Semver { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tag { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FluxServicePrincipal : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FluxServicePrincipal() { }
        public Azure.Provisioning.BicepValue<string> ClientCertificate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientCertificatePassword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsClientCertificateSendChain { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FluxSubstitution : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FluxSubstitution() { }
        public Azure.Provisioning.BicepValue<bool> IsOptional { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FluxTlsConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FluxTlsConfig() { }
        public Azure.Provisioning.BicepValue<string> CaCertificate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientCertificate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateKey { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HelmReleaseProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public HelmReleaseProperties() { }
        public Azure.Provisioning.BicepValue<long> FailureCount { get { throw null; } }
        public Azure.Provisioning.KubernetesConfiguration.FluxObjectReference HelmChartRef { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> InstallFailureCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> LastRevisionApplied { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> UpgradeFailureCount { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KubernetesClusterAccessDetail : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KubernetesClusterAccessDetail() { }
        public Azure.Provisioning.BicepList<string> AllowedActions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Entity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KubernetesClusterAdditionalDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KubernetesClusterAdditionalDetails() { }
        public Azure.Provisioning.BicepValue<string> Docs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ReleaseNotes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TroubleshootingGuide { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum KubernetesClusterAutoUpgradeMode
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="none")]
        None = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="patch")]
        Patch = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="compatible")]
        Compatible = 2,
    }
    public partial class KubernetesClusterExtension : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public KubernetesClusterExtension(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.KubernetesConfiguration.KubernetesClusterAdditionalDetails AdditionalDetails { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity AksAssignedIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.KubernetesClusterAutoUpgradeMode> AutoUpgradeMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> ConfigurationProtectedSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> ConfigurationSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CurrentVersion { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> CustomLocationSettings { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ResponseError> ErrorInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ExtensionState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ExtensionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAutoUpgradeMinorVersionEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSystemExtension { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ManagedBy { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.KubernetesClusterManagementDetails ManagementDetails { get { throw null; } set { } }
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
            public static readonly string V2025_03_01;
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
    public partial class KubernetesClusterManagementDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KubernetesClusterManagementDetails() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.KubernetesConfiguration.KubernetesClusterAccessDetail> AccessDetails { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Category { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
        public override bool Equals(object? obj) { throw null; }
        public static string GetBuiltInRoleName(Azure.Provisioning.KubernetesConfiguration.KubernetesConfigurationBuiltInRole value) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Provisioning.KubernetesConfiguration.KubernetesConfigurationBuiltInRole left, Azure.Provisioning.KubernetesConfiguration.KubernetesConfigurationBuiltInRole right) { throw null; }
        public static implicit operator Azure.Provisioning.KubernetesConfiguration.KubernetesConfigurationBuiltInRole (string value) { throw null; }
        public static bool operator !=(Azure.Provisioning.KubernetesConfiguration.KubernetesConfigurationBuiltInRole left, Azure.Provisioning.KubernetesConfiguration.KubernetesConfigurationBuiltInRole right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class KubernetesFluxConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public KubernetesFluxConfiguration(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.KubernetesConfiguration.AzureBlob AzureBlob { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.FluxBucket Bucket { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.FluxComplianceState> ComplianceState { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> ConfigurationProtectedSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ErrorMessage { get { throw null; } }
        public Azure.Provisioning.KubernetesConfiguration.FluxGitRepository GitRepository { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsSuspended { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsWaitForReconciliation { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.KubernetesConfiguration.Kustomization> Kustomizations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Namespace { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.OciRepository OciRepository { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.FluxConfigurationProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ReconciliationWaitDuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RepositoryPublicKey { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.FluxConfigurationScopeType> Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.FluxConfigurationSourceKindType> SourceKind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceSyncedCommitId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> SourceUpdatedOn { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.KubernetesConfiguration.FluxObjectStatus> Statuses { get { throw null; } }
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
            public static readonly string V2025_04_01;
        }
    }
    public partial class Kustomization : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public Kustomization() { }
        public Azure.Provisioning.BicepList<string> DependsOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsForce { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsPrune { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsWait { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.FluxPostBuild PostBuild { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> RetryIntervalInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> SyncIntervalInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> TimeoutInSeconds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MatchOidcIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MatchOidcIdentity() { }
        public Azure.Provisioning.BicepValue<string> Issuer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Subject { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OciRepository : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OciRepository() { }
        public Azure.Provisioning.BicepValue<bool> IsInsecure { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.FluxLayerSelector LayerSelector { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LocalAuthRef { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.OciRepositoryRef RepositoryRef { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceAccountName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> SyncIntervalInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> TimeoutInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.FluxTlsConfig TlsConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseWorkloadIdentity { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.OciRepositoryVerify Verify { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OciRepositoryRef : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OciRepositoryRef() { }
        public Azure.Provisioning.BicepValue<string> Digest { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Semver { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tag { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OciRepositoryVerify : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OciRepositoryVerify() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.KubernetesConfiguration.MatchOidcIdentity> MatchOidcIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Provider { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> VerificationConfig { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
