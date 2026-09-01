namespace Azure.Provisioning.KubernetesConfiguration.FluxConfigurations
{
    public partial class AzureBlob : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AzureBlob() { }
        public Azure.Provisioning.BicepValue<string> AccountKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ContainerName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LocalAuthRef { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ManagedIdentityClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SasToken { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.FluxConfigurations.FluxServicePrincipal ServicePrincipal { get { throw null; } set { } }
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
    public partial class FluxConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FluxConfiguration(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.KubernetesConfiguration.FluxConfigurations.AzureBlob AzureBlob { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.FluxConfigurations.FluxBucket Bucket { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.FluxConfigurations.FluxComplianceState> ComplianceState { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> ConfigurationProtectedSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ErrorMessage { get { throw null; } }
        public Azure.Provisioning.KubernetesConfiguration.FluxConfigurations.FluxGitRepository GitRepository { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.FluxConfigurations.FluxConfigurationScopeType> InstallationScope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSuspended { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsWaitForReconciliation { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.KubernetesConfiguration.FluxConfigurations.FluxConfigurationsKustomization> Kustomizations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Namespace { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.FluxConfigurations.OciRepository OciRepository { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.FluxConfigurations.FluxConfigurationProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ReconciliationWaitDuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RepositoryPublicKey { get { throw null; } }
        public Azure.Provisioning.Primitives.ProvisionableResource Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.FluxConfigurations.FluxConfigurationSourceKindType> SourceKind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceSyncedCommitId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> SourceUpdatedOn { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.KubernetesConfiguration.FluxConfigurations.FluxObjectStatus> Statuses { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StatusUpdatedOn { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.KubernetesConfiguration.FluxConfigurations.FluxConfiguration FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_04_01;
        }
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
    public partial class FluxConfigurationsKustomization : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FluxConfigurationsKustomization() { }
        public Azure.Provisioning.BicepList<string> DependsOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsForce { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsPrune { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsWait { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.FluxConfigurations.FluxPostBuild PostBuild { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> RetryIntervalInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> SyncIntervalInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> TimeoutInSeconds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.FluxConfigurations.FluxConfigurationProviderType> Provider { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.FluxConfigurations.FluxRepositoryReference RepositoryRef { get { throw null; } set { } }
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
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.FluxConfigurations.FluxConfigurationOperationType> Operation { get { throw null; } set { } }
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
        public Azure.Provisioning.KubernetesConfiguration.FluxConfigurations.FluxObjectReference AppliedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.FluxConfigurations.FluxComplianceState> ComplianceState { get { throw null; } }
        public Azure.Provisioning.KubernetesConfiguration.FluxConfigurations.HelmReleaseProperties HelmReleaseProperties { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Namespace { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.KubernetesConfiguration.FluxConfigurations.FluxObjectStatusCondition> StatusConditions { get { throw null; } }
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
        public Azure.Provisioning.BicepList<Azure.Provisioning.KubernetesConfiguration.FluxConfigurations.FluxSubstitution> SubstituteFrom { get { throw null; } set { } }
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
        public Azure.Provisioning.KubernetesConfiguration.FluxConfigurations.FluxObjectReference HelmChartRef { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> InstallFailureCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> LastRevisionApplied { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> UpgradeFailureCount { get { throw null; } }
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
        public Azure.Provisioning.KubernetesConfiguration.FluxConfigurations.FluxLayerSelector LayerSelector { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LocalAuthRef { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.FluxConfigurations.OciRepositoryRef RepositoryRef { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceAccountName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> SyncIntervalInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> TimeoutInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.FluxConfigurations.FluxTlsConfig TlsConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseWorkloadIdentity { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.FluxConfigurations.OciRepositoryVerify Verify { get { throw null; } set { } }
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
        public Azure.Provisioning.BicepList<Azure.Provisioning.KubernetesConfiguration.FluxConfigurations.MatchOidcIdentity> MatchOidcIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Provider { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> VerificationConfig { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
