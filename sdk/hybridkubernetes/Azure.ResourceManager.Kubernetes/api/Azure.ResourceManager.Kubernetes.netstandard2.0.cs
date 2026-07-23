namespace Azure.ResourceManager.Kubernetes
{
    public partial class AzureResourceManagerKubernetesContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerKubernetesContext() { }
        public static Azure.ResourceManager.Kubernetes.AzureResourceManagerKubernetesContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ConnectedClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kubernetes.ConnectedClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kubernetes.ConnectedClusterResource>, System.Collections.IEnumerable
    {
        protected ConnectedClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kubernetes.ConnectedClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.Kubernetes.ConnectedClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kubernetes.ConnectedClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.Kubernetes.ConnectedClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kubernetes.ConnectedClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kubernetes.ConnectedClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kubernetes.ConnectedClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kubernetes.ConnectedClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Kubernetes.ConnectedClusterResource> GetIfExists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Kubernetes.ConnectedClusterResource>> GetIfExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Kubernetes.ConnectedClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kubernetes.ConnectedClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Kubernetes.ConnectedClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kubernetes.ConnectedClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConnectedClusterData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.ConnectedClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.ConnectedClusterData>
    {
        public ConnectedClusterData(Azure.Core.AzureLocation location, Azure.ResourceManager.Kubernetes.Models.ConnectedClusterProperties properties, Azure.ResourceManager.Models.ManagedServiceIdentity identity) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Kubernetes.Models.ConnectedClusterKind? Kind { get { throw null; } set { } }
        public Azure.ResourceManager.Kubernetes.Models.ConnectedClusterProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Kubernetes.ConnectedClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.ConnectedClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.ConnectedClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Kubernetes.ConnectedClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.ConnectedClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.ConnectedClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.ConnectedClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedClusterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.ConnectedClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.ConnectedClusterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConnectedClusterResource() { }
        public virtual Azure.ResourceManager.Kubernetes.ConnectedClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Kubernetes.ConnectedClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kubernetes.ConnectedClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kubernetes.ConnectedClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kubernetes.ConnectedClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialsResult> GetClusterUserCredential(Azure.ResourceManager.Kubernetes.Models.GetClusterUserCredentialContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialsResult>> GetClusterUserCredentialAsync(Azure.ResourceManager.Kubernetes.Models.GetClusterUserCredentialContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kubernetes.ConnectedClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kubernetes.ConnectedClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kubernetes.ConnectedClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kubernetes.ConnectedClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Kubernetes.ConnectedClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.ConnectedClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.ConnectedClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Kubernetes.ConnectedClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.ConnectedClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.ConnectedClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.ConnectedClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kubernetes.ConnectedClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kubernetes.ConnectedClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class KubernetesExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Kubernetes.ConnectedClusterResource> GetConnectedCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kubernetes.ConnectedClusterResource>> GetConnectedClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Kubernetes.ConnectedClusterResource GetConnectedClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Kubernetes.ConnectedClusterCollection GetConnectedClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Kubernetes.ConnectedClusterResource> GetConnectedClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Kubernetes.ConnectedClusterResource> GetConnectedClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Kubernetes.Mocking
{
    public partial class MockableKubernetesArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableKubernetesArmClient() { }
        public virtual Azure.ResourceManager.Kubernetes.ConnectedClusterResource GetConnectedClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableKubernetesResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableKubernetesResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Kubernetes.ConnectedClusterResource> GetConnectedCluster(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kubernetes.ConnectedClusterResource>> GetConnectedClusterAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Kubernetes.ConnectedClusterCollection GetConnectedClusters() { throw null; }
    }
    public partial class MockableKubernetesSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableKubernetesSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Kubernetes.ConnectedClusterResource> GetConnectedClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kubernetes.ConnectedClusterResource> GetConnectedClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Kubernetes.Models
{
    public static partial class ArmKubernetesModelFactory
    {
        public static Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialHybridConnectionConfig ClusterUserCredentialHybridConnectionConfig(long? expirationTimeInSeconds = default(long?), string hybridConnectionName = null, string relay = null, string token = null, string relayTid = null, string relayType = null) { throw null; }
        public static Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialResult ClusterUserCredentialResult(string name = null, System.BinaryData value = null) { throw null; }
        public static Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialsResult ClusterUserCredentialsResult(Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialHybridConnectionConfig hybridConnectionConfig = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialResult> kubeconfigs = null) { throw null; }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAadProfile ConnectedClusterAadProfile(bool? enableAzureRbac = default(bool?), System.Collections.Generic.IEnumerable<string> adminGroupObjectIds = null, string tenantId = null) { throw null; }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAgentError ConnectedClusterAgentError(string message = null, string severity = null, string component = null, System.DateTimeOffset? occurredOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectedClusterArcAgentProfile ConnectedClusterArcAgentProfile(string desiredAgentVersion = null, Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAutoUpgradeMode? agentAutoUpgrade = default(Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAutoUpgradeMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterSystemComponent> systemComponents = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAgentError> agentErrors = null, string agentState = null) { throw null; }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectedClusterArcAgentryConfiguration ConnectedClusterArcAgentryConfiguration(string feature = null, System.Collections.Generic.IDictionary<string, string> settings = null, System.Collections.Generic.IDictionary<string, string> protectedSettings = null) { throw null; }
        public static Azure.ResourceManager.Kubernetes.ConnectedClusterData ConnectedClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Kubernetes.Models.ConnectedClusterProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Kubernetes.Models.ConnectedClusterKind? kind = default(Azure.ResourceManager.Kubernetes.Models.ConnectedClusterKind?)) { throw null; }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectedClusterOidcIssuerProfile ConnectedClusterOidcIssuerProfile(bool? enabled = default(bool?), string issuerUri = null, string selfHostedIssuerUri = null) { throw null; }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatch ConnectedClusterPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatchProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatchProperties ConnectedClusterPatchProperties(string distribution = null, string distributionVersion = null, Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAzureHybridBenefit? azureHybridBenefit = default(Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAzureHybridBenefit?), bool? isGatewayEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectedClusterProperties ConnectedClusterProperties(string agentPublicKeyCertificate = null, string kubernetesVersion = null, int? totalNodeCount = default(int?), int? totalCoreCount = default(int?), string agentVersion = null, Azure.ResourceManager.Kubernetes.Models.ConnectedClusterProvisioningState? provisioningState = default(Azure.ResourceManager.Kubernetes.Models.ConnectedClusterProvisioningState?), string distribution = null, string distributionVersion = null, string infrastructure = null, string offering = null, System.DateTimeOffset? managedIdentityCertificateExpirationOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastConnectivityOn = default(System.DateTimeOffset?), Azure.ResourceManager.Kubernetes.Models.ConnectedClusterConnectivityStatus? connectivityStatus = default(Azure.ResourceManager.Kubernetes.Models.ConnectedClusterConnectivityStatus?), Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPrivateLinkState? privateLinkState = default(Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPrivateLinkState?), Azure.Core.ResourceIdentifier privateLinkScopeResourceId = null, Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAzureHybridBenefit? azureHybridBenefit = default(Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAzureHybridBenefit?), Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAadProfile aadProfile = null, Azure.ResourceManager.Kubernetes.Models.ConnectedClusterArcAgentProfile arcAgentProfile = null, bool? isWorkloadIdentityEnabled = default(bool?), Azure.ResourceManager.Kubernetes.Models.ConnectedClusterOidcIssuerProfile oidcIssuerProfile = null, bool? isGatewayEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterArcAgentryConfiguration> arcAgentryConfigurations = null, System.Collections.Generic.IReadOnlyDictionary<string, string> miscellaneousProperties = null) { throw null; }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectedClusterSystemComponent ConnectedClusterSystemComponent(string type = null, string userSpecifiedVersion = null, int? majorVersion = default(int?), string currentVersion = null) { throw null; }
        public static Azure.ResourceManager.Kubernetes.Models.GetClusterUserCredentialContent GetClusterUserCredentialContent(Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialAuthenticationMethod authenticationMethod = default(Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialAuthenticationMethod), bool useClientProxy = false) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterUserCredentialAuthenticationMethod : System.IEquatable<Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialAuthenticationMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterUserCredentialAuthenticationMethod(string value) { throw null; }
        public static Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialAuthenticationMethod Aad { get { throw null; } }
        public static Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialAuthenticationMethod Token { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialAuthenticationMethod other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialAuthenticationMethod left, Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialAuthenticationMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialAuthenticationMethod (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialAuthenticationMethod? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialAuthenticationMethod left, Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialAuthenticationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterUserCredentialHybridConnectionConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialHybridConnectionConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialHybridConnectionConfig>
    {
        internal ClusterUserCredentialHybridConnectionConfig() { }
        public long? ExpirationTimeInSeconds { get { throw null; } }
        public string HybridConnectionName { get { throw null; } }
        public string Relay { get { throw null; } }
        public string RelayTid { get { throw null; } }
        public string RelayType { get { throw null; } }
        public string Token { get { throw null; } }
        protected virtual Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialHybridConnectionConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialHybridConnectionConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialHybridConnectionConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialHybridConnectionConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialHybridConnectionConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialHybridConnectionConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialHybridConnectionConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialHybridConnectionConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialHybridConnectionConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterUserCredentialResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialResult>
    {
        internal ClusterUserCredentialResult() { }
        public string Name { get { throw null; } }
        public System.BinaryData Value { get { throw null; } }
        protected virtual Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterUserCredentialsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialsResult>
    {
        internal ClusterUserCredentialsResult() { }
        public Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialHybridConnectionConfig HybridConnectionConfig { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialResult> Kubeconfigs { get { throw null; } }
        protected virtual Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialsResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialsResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedClusterAadProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAadProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAadProfile>
    {
        public ConnectedClusterAadProfile() { }
        public System.Collections.Generic.IList<string> AdminGroupObjectIds { get { throw null; } }
        public bool? EnableAzureRbac { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAadProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAadProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAadProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAadProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAadProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAadProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAadProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAadProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAadProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedClusterAgentError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAgentError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAgentError>
    {
        public ConnectedClusterAgentError() { }
        public string Component { get { throw null; } }
        public string Message { get { throw null; } }
        public System.DateTimeOffset? OccurredOn { get { throw null; } }
        public string Severity { get { throw null; } }
        protected virtual Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAgentError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAgentError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAgentError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAgentError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAgentError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAgentError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAgentError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAgentError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAgentError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedClusterArcAgentProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterArcAgentProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterArcAgentProfile>
    {
        public ConnectedClusterArcAgentProfile() { }
        public Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAutoUpgradeMode? AgentAutoUpgrade { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAgentError> AgentErrors { get { throw null; } }
        public string AgentState { get { throw null; } }
        public string DesiredAgentVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterSystemComponent> SystemComponents { get { throw null; } }
        protected virtual Azure.ResourceManager.Kubernetes.Models.ConnectedClusterArcAgentProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Kubernetes.Models.ConnectedClusterArcAgentProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Kubernetes.Models.ConnectedClusterArcAgentProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterArcAgentProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterArcAgentProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Kubernetes.Models.ConnectedClusterArcAgentProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterArcAgentProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterArcAgentProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterArcAgentProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedClusterArcAgentryConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterArcAgentryConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterArcAgentryConfiguration>
    {
        public ConnectedClusterArcAgentryConfiguration() { }
        public string Feature { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ProtectedSettings { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Settings { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Kubernetes.Models.ConnectedClusterArcAgentryConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Kubernetes.Models.ConnectedClusterArcAgentryConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Kubernetes.Models.ConnectedClusterArcAgentryConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterArcAgentryConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterArcAgentryConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Kubernetes.Models.ConnectedClusterArcAgentryConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterArcAgentryConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterArcAgentryConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterArcAgentryConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectedClusterAutoUpgradeMode : System.IEquatable<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAutoUpgradeMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectedClusterAutoUpgradeMode(string value) { throw null; }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAutoUpgradeMode Disabled { get { throw null; } }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAutoUpgradeMode Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAutoUpgradeMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAutoUpgradeMode left, Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAutoUpgradeMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAutoUpgradeMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAutoUpgradeMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAutoUpgradeMode left, Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAutoUpgradeMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectedClusterAzureHybridBenefit : System.IEquatable<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAzureHybridBenefit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectedClusterAzureHybridBenefit(string value) { throw null; }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAzureHybridBenefit False { get { throw null; } }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAzureHybridBenefit NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAzureHybridBenefit True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAzureHybridBenefit other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAzureHybridBenefit left, Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAzureHybridBenefit right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAzureHybridBenefit (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAzureHybridBenefit? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAzureHybridBenefit left, Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAzureHybridBenefit right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectedClusterConnectivityStatus : System.IEquatable<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterConnectivityStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectedClusterConnectivityStatus(string value) { throw null; }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectedClusterConnectivityStatus AgentNotInstalled { get { throw null; } }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectedClusterConnectivityStatus Connected { get { throw null; } }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectedClusterConnectivityStatus Connecting { get { throw null; } }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectedClusterConnectivityStatus Expired { get { throw null; } }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectedClusterConnectivityStatus Offline { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kubernetes.Models.ConnectedClusterConnectivityStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kubernetes.Models.ConnectedClusterConnectivityStatus left, Azure.ResourceManager.Kubernetes.Models.ConnectedClusterConnectivityStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kubernetes.Models.ConnectedClusterConnectivityStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Kubernetes.Models.ConnectedClusterConnectivityStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kubernetes.Models.ConnectedClusterConnectivityStatus left, Azure.ResourceManager.Kubernetes.Models.ConnectedClusterConnectivityStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectedClusterKind : System.IEquatable<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectedClusterKind(string value) { throw null; }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectedClusterKind Aws { get { throw null; } }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectedClusterKind Gcp { get { throw null; } }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectedClusterKind ProvisionedCluster { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kubernetes.Models.ConnectedClusterKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kubernetes.Models.ConnectedClusterKind left, Azure.ResourceManager.Kubernetes.Models.ConnectedClusterKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kubernetes.Models.ConnectedClusterKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Kubernetes.Models.ConnectedClusterKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kubernetes.Models.ConnectedClusterKind left, Azure.ResourceManager.Kubernetes.Models.ConnectedClusterKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConnectedClusterOidcIssuerProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterOidcIssuerProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterOidcIssuerProfile>
    {
        public ConnectedClusterOidcIssuerProfile() { }
        public bool? Enabled { get { throw null; } set { } }
        public string IssuerUri { get { throw null; } }
        public string SelfHostedIssuerUri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Kubernetes.Models.ConnectedClusterOidcIssuerProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Kubernetes.Models.ConnectedClusterOidcIssuerProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Kubernetes.Models.ConnectedClusterOidcIssuerProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterOidcIssuerProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterOidcIssuerProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Kubernetes.Models.ConnectedClusterOidcIssuerProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterOidcIssuerProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterOidcIssuerProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterOidcIssuerProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedClusterPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatch>
    {
        public ConnectedClusterPatch() { }
        public Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedClusterPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatchProperties>
    {
        public ConnectedClusterPatchProperties() { }
        public Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAzureHybridBenefit? AzureHybridBenefit { get { throw null; } set { } }
        public string Distribution { get { throw null; } set { } }
        public string DistributionVersion { get { throw null; } set { } }
        public bool? IsGatewayEnabled { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectedClusterPrivateLinkState : System.IEquatable<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPrivateLinkState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectedClusterPrivateLinkState(string value) { throw null; }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPrivateLinkState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPrivateLinkState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPrivateLinkState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPrivateLinkState left, Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPrivateLinkState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPrivateLinkState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPrivateLinkState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPrivateLinkState left, Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPrivateLinkState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConnectedClusterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterProperties>
    {
        public ConnectedClusterProperties(string agentPublicKeyCertificate) { }
        public Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAadProfile AadProfile { get { throw null; } set { } }
        public string AgentPublicKeyCertificate { get { throw null; } set { } }
        public string AgentVersion { get { throw null; } }
        public Azure.ResourceManager.Kubernetes.Models.ConnectedClusterArcAgentProfile ArcAgentProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterArcAgentryConfiguration> ArcAgentryConfigurations { get { throw null; } set { } }
        public Azure.ResourceManager.Kubernetes.Models.ConnectedClusterAzureHybridBenefit? AzureHybridBenefit { get { throw null; } set { } }
        public Azure.ResourceManager.Kubernetes.Models.ConnectedClusterConnectivityStatus? ConnectivityStatus { get { throw null; } }
        public string Distribution { get { throw null; } set { } }
        public string DistributionVersion { get { throw null; } set { } }
        public string Infrastructure { get { throw null; } set { } }
        public bool? IsGatewayEnabled { get { throw null; } set { } }
        public bool? IsWorkloadIdentityEnabled { get { throw null; } set { } }
        public string KubernetesVersion { get { throw null; } }
        public System.DateTimeOffset? LastConnectivityOn { get { throw null; } }
        public System.DateTimeOffset? ManagedIdentityCertificateExpirationOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> MiscellaneousProperties { get { throw null; } }
        public string Offering { get { throw null; } }
        public Azure.ResourceManager.Kubernetes.Models.ConnectedClusterOidcIssuerProfile OidcIssuerProfile { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateLinkScopeResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPrivateLinkState? PrivateLinkState { get { throw null; } set { } }
        public Azure.ResourceManager.Kubernetes.Models.ConnectedClusterProvisioningState? ProvisioningState { get { throw null; } set { } }
        public int? TotalCoreCount { get { throw null; } }
        public int? TotalNodeCount { get { throw null; } }
        protected virtual Azure.ResourceManager.Kubernetes.Models.ConnectedClusterProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Kubernetes.Models.ConnectedClusterProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Kubernetes.Models.ConnectedClusterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Kubernetes.Models.ConnectedClusterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectedClusterProvisioningState : System.IEquatable<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectedClusterProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectedClusterProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectedClusterProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectedClusterProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectedClusterProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectedClusterProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectedClusterProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectedClusterProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kubernetes.Models.ConnectedClusterProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kubernetes.Models.ConnectedClusterProvisioningState left, Azure.ResourceManager.Kubernetes.Models.ConnectedClusterProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kubernetes.Models.ConnectedClusterProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Kubernetes.Models.ConnectedClusterProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kubernetes.Models.ConnectedClusterProvisioningState left, Azure.ResourceManager.Kubernetes.Models.ConnectedClusterProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConnectedClusterSystemComponent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterSystemComponent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterSystemComponent>
    {
        public ConnectedClusterSystemComponent() { }
        public string CurrentVersion { get { throw null; } }
        public int? MajorVersion { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        public string UserSpecifiedVersion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Kubernetes.Models.ConnectedClusterSystemComponent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Kubernetes.Models.ConnectedClusterSystemComponent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Kubernetes.Models.ConnectedClusterSystemComponent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterSystemComponent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterSystemComponent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Kubernetes.Models.ConnectedClusterSystemComponent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterSystemComponent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterSystemComponent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterSystemComponent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetClusterUserCredentialContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.GetClusterUserCredentialContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.GetClusterUserCredentialContent>
    {
        public GetClusterUserCredentialContent(Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialAuthenticationMethod authenticationMethod, bool useClientProxy) { }
        public Azure.ResourceManager.Kubernetes.Models.ClusterUserCredentialAuthenticationMethod AuthenticationMethod { get { throw null; } }
        public bool UseClientProxy { get { throw null; } }
        protected virtual Azure.ResourceManager.Kubernetes.Models.GetClusterUserCredentialContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Kubernetes.Models.GetClusterUserCredentialContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Kubernetes.Models.GetClusterUserCredentialContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.GetClusterUserCredentialContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.GetClusterUserCredentialContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Kubernetes.Models.GetClusterUserCredentialContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.GetClusterUserCredentialContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.GetClusterUserCredentialContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.GetClusterUserCredentialContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
