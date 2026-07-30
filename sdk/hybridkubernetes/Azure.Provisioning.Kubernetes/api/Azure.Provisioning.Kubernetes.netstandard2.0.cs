namespace Azure.Provisioning.Kubernetes
{
    public partial class ConnectedCluster : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ConnectedCluster(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kubernetes.ConnectedClusterKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Kubernetes.ConnectedClusterProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.Kubernetes.KubernetesBuiltInRole role, Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPrincipalType> principalType, Azure.Provisioning.BicepValue<System.Guid> principalId, string bicepIdentifierSuffix = null) { throw null; }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.Kubernetes.KubernetesBuiltInRole role, Azure.Provisioning.Roles.UserAssignedIdentity identity) { throw null; }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Kubernetes.ConnectedCluster FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_12_01_PREVIEW;
            public static readonly string V2025_08_01_PREVIEW;
            public static readonly string V2025_12_01_PREVIEW;
        }
    }
    public partial class ConnectedClusterAadProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnectedClusterAadProfile() { }
        public Azure.Provisioning.BicepList<string> AdminGroupObjectIds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableAzureRbac { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ConnectedClusterAgentError : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnectedClusterAgentError() { }
        public Azure.Provisioning.BicepValue<string> Component { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> OccurredOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Severity { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ConnectedClusterArcAgentProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnectedClusterArcAgentProfile() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kubernetes.ConnectedClusterAutoUpgradeMode> AgentAutoUpgrade { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Kubernetes.ConnectedClusterAgentError> AgentErrors { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AgentState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DesiredAgentVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Kubernetes.ConnectedClusterSystemComponent> SystemComponents { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ConnectedClusterArcAgentryConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnectedClusterArcAgentryConfiguration() { }
        public Azure.Provisioning.BicepValue<string> Feature { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> ProtectedSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Settings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ConnectedClusterAutoUpgradeMode
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum ConnectedClusterAzureHybridBenefit
    {
        True = 0,
        False = 1,
        NotApplicable = 2,
    }
    public enum ConnectedClusterConnectivityStatus
    {
        Connecting = 0,
        Connected = 1,
        Offline = 2,
        Expired = 3,
        AgentNotInstalled = 4,
    }
    public enum ConnectedClusterKind
    {
        ProvisionedCluster = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AWS")]
        Aws = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="GCP")]
        Gcp = 2,
    }
    public partial class ConnectedClusterOidcIssuerProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnectedClusterOidcIssuerProfile() { }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IssuerUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SelfHostedIssuerUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ConnectedClusterPrivateLinkState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class ConnectedClusterProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnectedClusterProperties() { }
        public Azure.Provisioning.Kubernetes.ConnectedClusterAadProfile AadProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AgentPublicKeyCertificate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AgentVersion { get { throw null; } }
        public Azure.Provisioning.Kubernetes.ConnectedClusterArcAgentProfile ArcAgentProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Kubernetes.ConnectedClusterArcAgentryConfiguration> ArcAgentryConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kubernetes.ConnectedClusterAzureHybridBenefit> AzureHybridBenefit { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kubernetes.ConnectedClusterConnectivityStatus> ConnectivityStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Distribution { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DistributionVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Infrastructure { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsGatewayEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KubernetesVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastConnectivityOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ManagedIdentityCertificateExpirationOn { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> MiscellaneousProperties { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Offering { get { throw null; } }
        public Azure.Provisioning.Kubernetes.ConnectedClusterOidcIssuerProfile OidcIssuerProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateLinkScopeResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kubernetes.ConnectedClusterPrivateLinkState> PrivateLinkState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kubernetes.ConnectedClusterProvisioningState> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SecurityIsWorkloadIdentityEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TotalCoreCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> TotalNodeCount { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ConnectedClusterProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        Provisioning = 3,
        Updating = 4,
        Deleting = 5,
        Accepted = 6,
    }
    public partial class ConnectedClusterSystemComponent : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnectedClusterSystemComponent() { }
        public Azure.Provisioning.BicepValue<string> CurrentVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> MajorVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Type { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserSpecifiedVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KubernetesBuiltInRole : System.IEquatable<Azure.Provisioning.Kubernetes.KubernetesBuiltInRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KubernetesBuiltInRole(string value) { throw null; }
        public static Azure.Provisioning.Kubernetes.KubernetesBuiltInRole KubernetesClusterAzureArcOnboarding { get { throw null; } }
        public bool Equals(Azure.Provisioning.Kubernetes.KubernetesBuiltInRole other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public static string GetBuiltInRoleName(Azure.Provisioning.Kubernetes.KubernetesBuiltInRole value) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Provisioning.Kubernetes.KubernetesBuiltInRole left, Azure.Provisioning.Kubernetes.KubernetesBuiltInRole right) { throw null; }
        public static implicit operator Azure.Provisioning.Kubernetes.KubernetesBuiltInRole (string value) { throw null; }
        public static bool operator !=(Azure.Provisioning.Kubernetes.KubernetesBuiltInRole left, Azure.Provisioning.Kubernetes.KubernetesBuiltInRole right) { throw null; }
        public override string ToString() { throw null; }
    }
}
