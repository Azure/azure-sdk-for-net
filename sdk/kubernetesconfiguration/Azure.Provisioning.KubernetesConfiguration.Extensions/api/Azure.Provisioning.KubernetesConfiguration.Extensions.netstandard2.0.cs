namespace Azure.Provisioning.KubernetesConfiguration.Extensions
{
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
        public KubernetesClusterExtension(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.KubernetesConfiguration.Extensions.KubernetesClusterAdditionalDetails AdditionalDetails { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity AksAssignedIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.Extensions.KubernetesClusterAutoUpgradeMode> AutoUpgradeMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> ConfigurationProtectedSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> ConfigurationSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CurrentVersion { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> CustomLocationSettings { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ResponseError> ErrorInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ExtensionState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ExtensionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.Extensions.KubernetesClusterExtensionScope InstallationScope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAutoUpgradeMinorVersionEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSystemExtension { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ManagedBy { get { throw null; } set { } }
        public Azure.Provisioning.KubernetesConfiguration.Extensions.KubernetesClusterManagementDetails ManagementDetails { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> PackageUri { get { throw null; } }
        public Azure.Provisioning.Resources.ArmPlan Plan { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.Extensions.KubernetesConfigurationProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ReleaseTrain { get { throw null; } set { } }
        public Azure.Provisioning.Primitives.ProvisionableResource Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.KubernetesConfiguration.Extensions.KubernetesClusterExtensionStatus> Statuses { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.KubernetesConfiguration.Extensions.KubernetesClusterExtension FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
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
        public Azure.Provisioning.BicepValue<Azure.Provisioning.KubernetesConfiguration.Extensions.KubernetesClusterExtensionStatusLevel> Level { get { throw null; } set { } }
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
        public Azure.Provisioning.BicepList<Azure.Provisioning.KubernetesConfiguration.Extensions.KubernetesClusterAccessDetail> AccessDetails { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Category { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
}
