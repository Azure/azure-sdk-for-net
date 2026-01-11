namespace Azure.Provisioning.Kubernetes
{
    public partial class ConnectedCluster : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ConnectedCluster(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AgentPublicKeyCertificate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AgentVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kubernetes.ConnectivityStatus> ConnectivityStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Distribution { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Infrastructure { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KubernetesVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastConnectivityOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ManagedIdentityCertificateExpirationOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Offering { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrivateLinkScopeResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kubernetes.PrivateLinkState> PrivateLinkState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kubernetes.ProvisioningState> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TotalCoreCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> TotalNodeCount { get { throw null; } }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.Kubernetes.KubernetesBuiltInRole role, Azure.Provisioning.BicepValue<Azure.Provisioning.Authorization.RoleManagementPrincipalType> principalType, Azure.Provisioning.BicepValue<System.Guid> principalId, string? bicepIdentifierSuffix = null) { throw null; }
        public Azure.Provisioning.Authorization.RoleAssignment CreateRoleAssignment(Azure.Provisioning.Kubernetes.KubernetesBuiltInRole role, Azure.Provisioning.Roles.UserAssignedIdentity identity) { throw null; }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Kubernetes.ConnectedCluster FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_03_01;
            public static readonly string V2021_10_01;
            public static readonly string V2024_01_01;
        }
    }
    public enum ConnectivityStatus
    {
        Connecting = 0,
        Connected = 1,
        Offline = 2,
        Expired = 3,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KubernetesBuiltInRole : System.IEquatable<Azure.Provisioning.Kubernetes.KubernetesBuiltInRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KubernetesBuiltInRole(string value) { throw null; }
        public static Azure.Provisioning.Kubernetes.KubernetesBuiltInRole KubernetesClusterAzureArcOnboarding { get { throw null; } }
        public bool Equals(Azure.Provisioning.Kubernetes.KubernetesBuiltInRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static string GetBuiltInRoleName(Azure.Provisioning.Kubernetes.KubernetesBuiltInRole value) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Provisioning.Kubernetes.KubernetesBuiltInRole left, Azure.Provisioning.Kubernetes.KubernetesBuiltInRole right) { throw null; }
        public static implicit operator Azure.Provisioning.Kubernetes.KubernetesBuiltInRole (string value) { throw null; }
        public static bool operator !=(Azure.Provisioning.Kubernetes.KubernetesBuiltInRole left, Azure.Provisioning.Kubernetes.KubernetesBuiltInRole right) { throw null; }
        public override string ToString() { throw null; }
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
}
