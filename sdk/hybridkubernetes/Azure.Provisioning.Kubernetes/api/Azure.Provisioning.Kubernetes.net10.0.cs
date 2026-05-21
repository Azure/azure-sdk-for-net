namespace Azure.Provisioning.Kubernetes
{
    public partial class AadProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AadProfile() { }
        public Azure.Provisioning.BicepList<string> AdminGroupObjectIDs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableAzureRBAC { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TenantID { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AgentError : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AgentError() { }
        public Azure.Provisioning.BicepValue<string> Component { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Severity { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> Time { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ArcAgentProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArcAgentProfile() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kubernetes.AutoUpgradeOptions> AgentAutoUpgrade { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Kubernetes.AgentError> AgentErrors { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AgentState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DesiredAgentVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Kubernetes.SystemComponent> SystemComponents { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ArcAgentryConfigurations : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ArcAgentryConfigurations() { }
        public Azure.Provisioning.BicepValue<string> Feature { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> ProtectedSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Settings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AutoUpgradeOptions
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum AzureHybridBenefit
    {
        True = 0,
        False = 1,
        NotApplicable = 2,
    }
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
            public static readonly string V2026_05_01;
        }
    }
    public enum ConnectedClusterKind
    {
        ProvisionedCluster = 0,
    }
    public partial class ConnectedClusterProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnectedClusterProperties() { }
        public Azure.Provisioning.Kubernetes.AadProfile AadProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AgentPublicKeyCertificate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AgentVersion { get { throw null; } }
        public Azure.Provisioning.Kubernetes.ArcAgentProfile ArcAgentProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Kubernetes.ArcAgentryConfigurations> ArcAgentryConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kubernetes.AzureHybridBenefit> AzureHybridBenefit { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kubernetes.ConnectivityStatus> ConnectivityStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Distribution { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DistributionVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> GatewayEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Infrastructure { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KubernetesVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastConnectivityOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ManagedIdentityCertificateExpirationOn { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> MiscellaneousProperties { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Offering { get { throw null; } }
        public Azure.Provisioning.Kubernetes.OidcIssuerProfile OidcIssuerProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateLinkScopeResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kubernetes.PrivateLinkState> PrivateLinkState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kubernetes.ProvisioningState> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SecurityWorkloadIdentityEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TotalCoreCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> TotalNodeCount { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ConnectivityStatus
    {
        Connecting = 0,
        Connected = 1,
        Offline = 2,
        Expired = 3,
        AgentNotInstalled = 4,
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
    public partial class OidcIssuerProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OidcIssuerProfile() { }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IssuerUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SelfHostedIssuerUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PrivateLinkState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum ProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        Provisioning = 3,
        Updating = 4,
        Deleting = 5,
        Accepted = 6,
    }
    public partial class SystemComponent : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SystemComponent() { }
        public Azure.Provisioning.BicepValue<string> CurrentVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> MajorVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Type { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserSpecifiedVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
