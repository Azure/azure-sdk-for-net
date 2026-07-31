namespace Azure.Provisioning.ServiceFabric
{
    public partial class ApplicationDeltaHealthPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationDeltaHealthPolicy() { }
        public Azure.Provisioning.BicepValue<int> MaxPercentDeltaUnhealthyServices { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.ServiceFabric.ServiceTypeDeltaHealthPolicy> ServiceTypeDeltaHealthPolicies { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationHealthPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationHealthPolicy() { }
        public Azure.Provisioning.BicepValue<int> MaxPercentUnhealthyServices { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.ServiceFabric.ServiceTypeHealthPolicy> ServiceTypeHealthPolicies { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationMetricDescription : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationMetricDescription() { }
        public Azure.Provisioning.BicepValue<long> MaximumCapacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> ReservationCapacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> TotalApplicationCapacity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ApplicationMoveCost
    {
        Zero = 0,
        Low = 1,
        Medium = 2,
        High = 3,
    }
    public enum ApplicationRollingUpgradeMode
    {
        Invalid = 0,
        UnmonitoredAuto = 1,
        UnmonitoredManual = 2,
        Monitored = 3,
    }
    public partial class ApplicationUpgradePolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationUpgradePolicy() { }
        public Azure.Provisioning.ServiceFabric.ArmApplicationHealthPolicy ApplicationHealthPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ForceRestart { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RecreateApplication { get { throw null; } set { } }
        public Azure.Provisioning.ServiceFabric.ArmRollingUpgradeMonitoringPolicy RollingUpgradeMonitoringPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceFabric.ApplicationRollingUpgradeMode> UpgradeMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> UpgradeReplicaSetCheckTimeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationUserAssignedIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationUserAssignedIdentity() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> PrincipalId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ArmApplicationHealthPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArmApplicationHealthPolicy() { }
        public Azure.Provisioning.BicepValue<bool> ConsiderWarningAsError { get { throw null; } set { } }
        public Azure.Provisioning.ServiceFabric.ArmServiceTypeHealthPolicy DefaultServiceTypeHealthPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxPercentUnhealthyDeployedApplications { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.ServiceFabric.ArmServiceTypeHealthPolicy> ServiceTypeHealthPolicyMap { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ArmRollingUpgradeMonitoringPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArmRollingUpgradeMonitoringPolicy() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceFabric.ArmUpgradeFailureAction> FailureAction { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> HealthCheckRetryTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> HealthCheckStableDuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> HealthCheckWaitDuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> UpgradeDomainTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> UpgradeTimeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ArmServicePackageActivationMode
    {
        SharedProcess = 0,
        ExclusiveProcess = 1,
    }
    public partial class ArmServiceTypeHealthPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArmServiceTypeHealthPolicy() { }
        public Azure.Provisioning.BicepValue<int> MaxPercentUnhealthyPartitionsPerService { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxPercentUnhealthyReplicasPerPartition { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxPercentUnhealthyServices { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ArmUpgradeFailureAction
    {
        Rollback = 0,
        Manual = 1,
    }
    public partial class ClusterAadSetting : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ClusterAadSetting() { }
        public Azure.Provisioning.BicepValue<string> ClientApplication { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClusterApplication { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ClusterAddOnFeature
    {
        RepairManager = 0,
        DnsService = 1,
        BackupRestoreService = 2,
        ResourceMonitorService = 3,
    }
    public partial class ClusterCertificateDescription : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ClusterCertificateDescription() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> Thumbprint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ThumbprintSecondary { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceFabric.ClusterCertificateStoreName> X509StoreName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ClusterCertificateStoreName
    {
        AddressBook = 0,
        AuthRoot = 1,
        CertificateAuthority = 2,
        Disallowed = 3,
        My = 4,
        Root = 5,
        TrustedPeople = 6,
        TrustedPublisher = 7,
    }
    public partial class ClusterClientCertificateCommonName : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ClusterClientCertificateCommonName() { }
        public Azure.Provisioning.BicepValue<string> CertificateCommonName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> CertificateIssuerThumbprint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAdmin { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ClusterClientCertificateThumbprint : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ClusterClientCertificateThumbprint() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> CertificateThumbprint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAdmin { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ClusterDurabilityLevel
    {
        Bronze = 0,
        Silver = 1,
        Gold = 2,
    }
    public partial class ClusterEndpointRangeDescription : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ClusterEndpointRangeDescription() { }
        public Azure.Provisioning.BicepValue<int> EndPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> StartPort { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ClusterEnvironment
    {
        Windows = 0,
        Linux = 1,
    }
    public partial class ClusterHealthPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ClusterHealthPolicy() { }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.ServiceFabric.ApplicationHealthPolicy> ApplicationHealthPolicies { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxPercentUnhealthyApplications { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxPercentUnhealthyNodes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ClusterNodeTypeDescription : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ClusterNodeTypeDescription() { }
        public Azure.Provisioning.ServiceFabric.ClusterEndpointRangeDescription ApplicationPorts { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Capacities { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ClientConnectionEndpointPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceFabric.ClusterDurabilityLevel> DurabilityLevel { get { throw null; } set { } }
        public Azure.Provisioning.ServiceFabric.ClusterEndpointRangeDescription EphemeralPorts { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> HttpGatewayEndpointPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> HttpGatewayTokenAuthEndpointPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsMultipleAvailabilityZonesSupported { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsPrimary { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsStateless { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> PlacementProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ReverseProxyEndpointPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> VmInstanceCount { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ClusterNotification : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ClusterNotification() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceFabric.ClusterNotificationCategory> NotificationCategory { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceFabric.ClusterNotificationLevel> NotificationLevel { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ServiceFabric.ClusterNotificationTarget> NotificationTargets { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ClusterNotificationCategory
    {
        WaveProgress = 0,
    }
    public enum ClusterNotificationChannel
    {
        EmailUser = 0,
        EmailSubscription = 1,
    }
    public enum ClusterNotificationLevel
    {
        Critical = 0,
        All = 1,
    }
    public partial class ClusterNotificationTarget : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ClusterNotificationTarget() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceFabric.ClusterNotificationChannel> NotificationChannel { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Receivers { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ClusterReliabilityLevel
    {
        None = 0,
        Bronze = 1,
        Silver = 2,
        Gold = 3,
        Platinum = 4,
    }
    public partial class ClusterServerCertificateCommonName : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ClusterServerCertificateCommonName() { }
        public Azure.Provisioning.BicepValue<string> CertificateCommonName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> CertificateIssuerThumbprint { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ClusterServerCertificateCommonNames : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ClusterServerCertificateCommonNames() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ServiceFabric.ClusterServerCertificateCommonName> CommonNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceFabric.ClusterCertificateStoreName> X509StoreName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ClusterUpgradeCadence
    {
        Wave0 = 0,
        Wave1 = 1,
        Wave2 = 2,
    }
    public partial class ClusterUpgradeDeltaHealthPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ClusterUpgradeDeltaHealthPolicy() { }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.ServiceFabric.ApplicationDeltaHealthPolicy> ApplicationDeltaHealthPolicies { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxPercentDeltaUnhealthyApplications { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxPercentDeltaUnhealthyNodes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxPercentUpgradeDomainDeltaUnhealthyNodes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ClusterUpgradeMode
    {
        Automatic = 0,
        Manual = 1,
    }
    public partial class ClusterUpgradePolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ClusterUpgradePolicy() { }
        public Azure.Provisioning.ServiceFabric.ClusterUpgradeDeltaHealthPolicy DeltaHealthPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ForceRestart { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> HealthCheckRetryTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> HealthCheckStableDuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> HealthCheckWaitDuration { get { throw null; } set { } }
        public Azure.Provisioning.ServiceFabric.ClusterHealthPolicy HealthPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> UpgradeDomainTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> UpgradeReplicaSetCheckTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> UpgradeTimeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ClusterVersionDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ClusterVersionDetails() { }
        public Azure.Provisioning.BicepValue<string> CodeVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceFabric.ClusterEnvironment> Environment { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> SupportExpireOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DiagnosticsStorageAccountConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DiagnosticsStorageAccountConfig() { }
        public Azure.Provisioning.BicepValue<System.Uri> BlobEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProtectedAccountKeyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProtectedAccountKeyName2 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> QueueEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> TableEndpoint { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NamedPartitionSchemeDescription : Azure.Provisioning.ServiceFabric.PartitionSchemeDescription
    {
        public NamedPartitionSchemeDescription() { }
        public Azure.Provisioning.BicepValue<int> Count { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Names { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PartitionSchemeDescription : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PartitionSchemeDescription() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceCorrelationDescription : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceCorrelationDescription() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceFabric.ServiceCorrelationScheme> Scheme { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ServiceCorrelationScheme
    {
        Invalid = 0,
        Affinity = 1,
        AlignedAffinity = 2,
        NonAlignedAffinity = 3,
    }
    public partial class ServiceFabricApplication : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceFabricApplication(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ServiceFabric.ApplicationUserAssignedIdentity> ManagedIdentities { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> MaximumNodes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ServiceFabric.ApplicationMetricDescription> Metrics { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> MinimumNodes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.ServiceFabric.ServiceFabricCluster Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> RemoveApplicationCapacity { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TypeName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TypeVersion { get { throw null; } set { } }
        public Azure.Provisioning.ServiceFabric.ApplicationUpgradePolicy UpgradePolicy { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ServiceFabric.ServiceFabricApplication FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_11_01_PREVIEW;
            public static readonly string V2026_03_01_PREVIEW;
        }
    }
    public partial class ServiceFabricApplicationType : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceFabricApplicationType(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ServiceFabric.ServiceFabricCluster Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ServiceFabric.ServiceFabricApplicationType FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_11_01_PREVIEW;
            public static readonly string V2026_03_01_PREVIEW;
        }
    }
    public partial class ServiceFabricApplicationTypeVersion : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceFabricApplicationTypeVersion(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.Uri> AppPackageUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> DefaultParameterList { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ServiceFabric.ServiceFabricApplicationType Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ServiceFabric.ServiceFabricApplicationTypeVersion FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_11_01_PREVIEW;
            public static readonly string V2026_03_01_PREVIEW;
        }
    }
    public partial class ServiceFabricCluster : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceFabricCluster(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ServiceFabric.ClusterAddOnFeature> AddOnFeatures { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ServiceFabric.ClusterVersionDetails> AvailableClusterVersions { get { throw null; } }
        public Azure.Provisioning.ServiceFabric.ClusterAadSetting AzureActiveDirectory { get { throw null; } set { } }
        public Azure.Provisioning.ServiceFabric.ClusterCertificateDescription Certificate { get { throw null; } set { } }
        public Azure.Provisioning.ServiceFabric.ClusterServerCertificateCommonNames CertificateCommonNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ServiceFabric.ClusterClientCertificateCommonName> ClientCertificateCommonNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ServiceFabric.ClusterClientCertificateThumbprint> ClientCertificateThumbprints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClusterCodeVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ClusterEndpoint { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ClusterId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceFabric.ServiceFabricClusterState> ClusterState { get { throw null; } }
        public Azure.Provisioning.ServiceFabric.DiagnosticsStorageAccountConfig DiagnosticsStorageAccountConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ServiceFabric.SettingsSectionDescription> FabricSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEventStoreServiceEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsHttpGatewayExclusiveAuthModeEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsInfrastructureServiceManagerEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsWaveUpgradePaused { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ManagementEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> MaxUnusedVersionsToKeep { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ServiceFabric.ClusterNodeTypeDescription> NodeTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ServiceFabric.ClusterNotification> Notifications { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceFabric.ServiceFabricProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceFabric.ClusterReliabilityLevel> ReliabilityLevel { get { throw null; } set { } }
        public Azure.Provisioning.ServiceFabric.ClusterCertificateDescription ReverseProxyCertificate { get { throw null; } set { } }
        public Azure.Provisioning.ServiceFabric.ClusterServerCertificateCommonNames ReverseProxyCertificateCommonNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceFabric.SfZonalUpgradeMode> ServiceFabricZonalUpgradeMode { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.ServiceFabric.ClusterUpgradePolicy UpgradeDescription { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceFabric.ClusterUpgradeMode> UpgradeMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> UpgradePauseEndOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> UpgradePauseStartOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceFabric.ClusterUpgradeCadence> UpgradeWave { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VmImage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceFabric.VmssZonalUpgradeMode> VmssZonalUpgradeMode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ServiceFabric.ServiceFabricCluster FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_11_01_PREVIEW;
            public static readonly string V2026_03_01_PREVIEW;
        }
    }
    public enum ServiceFabricClusterState
    {
        WaitingForNodes = 0,
        Deploying = 1,
        BaselineUpgrade = 2,
        UpdatingUserConfiguration = 3,
        UpdatingUserCertificate = 4,
        UpdatingInfrastructure = 5,
        EnforcingClusterVersion = 6,
        UpgradeServiceUnreachable = 7,
        AutoScale = 8,
        Ready = 9,
    }
    public enum ServiceFabricProvisioningState
    {
        Updating = 0,
        Succeeded = 1,
        Failed = 2,
        Canceled = 3,
    }
    public partial class ServiceFabricService : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceFabricService(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ServiceFabric.ServiceFabricApplication Parent { get { throw null; } set { } }
        public Azure.Provisioning.ServiceFabric.ServiceResourceProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ServiceFabric.ServiceFabricService FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_11_01_PREVIEW;
            public static readonly string V2026_03_01_PREVIEW;
        }
    }
    public partial class ServiceFabricVmSizeResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal ServiceFabricVmSizeResource() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> VmSize { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ServiceFabric.ServiceFabricVmSizeResource FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_11_01_PREVIEW;
            public static readonly string V2026_03_01_PREVIEW;
        }
    }
    public partial class ServiceLoadMetricDescription : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceLoadMetricDescription() { }
        public Azure.Provisioning.BicepValue<int> DefaultLoad { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PrimaryDefaultLoad { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SecondaryDefaultLoad { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceFabric.ServiceLoadMetricWeight> Weight { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ServiceLoadMetricWeight
    {
        Zero = 0,
        Low = 1,
        Medium = 2,
        High = 3,
    }
    public partial class ServicePlacementPolicyDescription : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServicePlacementPolicyDescription() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceResourceProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceResourceProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ServiceFabric.ServiceCorrelationDescription> CorrelationScheme { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceFabric.ApplicationMoveCost> DefaultMoveCost { get { throw null; } set { } }
        public Azure.Provisioning.ServiceFabric.PartitionSchemeDescription PartitionDescription { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PlacementConstraints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ServiceDnsName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ServiceFabric.ServiceLoadMetricDescription> ServiceLoadMetrics { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ServiceFabric.ArmServicePackageActivationMode> ServicePackageActivationMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ServiceFabric.ServicePlacementPolicyDescription> ServicePlacementPolicies { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceTypeName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceTypeDeltaHealthPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceTypeDeltaHealthPolicy() { }
        public Azure.Provisioning.BicepValue<int> MaxPercentDeltaUnhealthyServices { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceTypeHealthPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceTypeHealthPolicy() { }
        public Azure.Provisioning.BicepValue<int> MaxPercentUnhealthyServices { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SettingsParameterDescription : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SettingsParameterDescription() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SettingsSectionDescription : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SettingsSectionDescription() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ServiceFabric.SettingsParameterDescription> Parameters { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SfZonalUpgradeMode
    {
        Parallel = 0,
        Hierarchical = 1,
    }
    public partial class SingletonPartitionSchemeDescription : Azure.Provisioning.ServiceFabric.PartitionSchemeDescription
    {
        public SingletonPartitionSchemeDescription() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StatefulServiceProperties : Azure.Provisioning.ServiceFabric.ServiceResourceProperties
    {
        public StatefulServiceProperties() { }
        public Azure.Provisioning.BicepValue<bool> HasPersistedState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinReplicaSetSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> QuorumLossWaitDuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ReplicaRestartWaitDuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StandByReplicaKeepDuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TargetReplicaSetSize { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StatelessServiceProperties : Azure.Provisioning.ServiceFabric.ServiceResourceProperties
    {
        public StatelessServiceProperties() { }
        public Azure.Provisioning.BicepValue<string> InstanceCloseDelayDuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> InstanceCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinInstanceCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> MinInstancePercentage { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class UniformInt64RangePartitionSchemeDescription : Azure.Provisioning.ServiceFabric.PartitionSchemeDescription
    {
        public UniformInt64RangePartitionSchemeDescription() { }
        public Azure.Provisioning.BicepValue<int> Count { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HighKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LowKey { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VmssZonalUpgradeMode
    {
        Parallel = 0,
        Hierarchical = 1,
    }
}
