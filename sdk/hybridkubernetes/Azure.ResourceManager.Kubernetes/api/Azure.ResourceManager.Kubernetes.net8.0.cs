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
        public ConnectedClusterData(Azure.Core.AzureLocation location, Azure.ResourceManager.Models.ManagedServiceIdentity identity, string agentPublicKeyCertificate) { }
        public string AgentPublicKeyCertificate { get { throw null; } set { } }
        public string AgentVersion { get { throw null; } }
        public Azure.ResourceManager.Kubernetes.Models.ConnectivityStatus? ConnectivityStatus { get { throw null; } }
        public string Distribution { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Infrastructure { get { throw null; } set { } }
        public string KubernetesVersion { get { throw null; } }
        public System.DateTimeOffset? LastConnectivityOn { get { throw null; } }
        public System.DateTimeOffset? ManagedIdentityCertificateExpirationOn { get { throw null; } }
        public string Offering { get { throw null; } }
        public string PrivateLinkScopeResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Kubernetes.Models.PrivateLinkState? PrivateLinkState { get { throw null; } set { } }
        public Azure.ResourceManager.Kubernetes.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
        public int? TotalCoreCount { get { throw null; } }
        public int? TotalNodeCount { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public virtual Azure.Response<Azure.ResourceManager.Kubernetes.Models.CredentialResults> GetClusterUserCredential(Azure.ResourceManager.Kubernetes.Models.ListClusterUserCredentialProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kubernetes.Models.CredentialResults>> GetClusterUserCredentialAsync(Azure.ResourceManager.Kubernetes.Models.ListClusterUserCredentialProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kubernetes.ConnectedClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kubernetes.ConnectedClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kubernetes.ConnectedClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kubernetes.ConnectedClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Kubernetes.ConnectedClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.ConnectedClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.ConnectedClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Kubernetes.ConnectedClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.ConnectedClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.ConnectedClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.ConnectedClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kubernetes.ConnectedClusterResource> Update(Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kubernetes.ConnectedClusterResource>> UpdateAsync(Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.ResourceManager.Kubernetes.ConnectedClusterData ConnectedClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string agentPublicKeyCertificate = null, string kubernetesVersion = null, int? totalNodeCount = default(int?), int? totalCoreCount = default(int?), string agentVersion = null, Azure.ResourceManager.Kubernetes.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Kubernetes.Models.ProvisioningState?), string distribution = null, string infrastructure = null, string offering = null, System.DateTimeOffset? managedIdentityCertificateExpirationOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastConnectivityOn = default(System.DateTimeOffset?), Azure.ResourceManager.Kubernetes.Models.ConnectivityStatus? connectivityStatus = default(Azure.ResourceManager.Kubernetes.Models.ConnectivityStatus?), Azure.ResourceManager.Kubernetes.Models.PrivateLinkState? privateLinkState = default(Azure.ResourceManager.Kubernetes.Models.PrivateLinkState?), string privateLinkScopeResourceId = null) { throw null; }
        public static Azure.ResourceManager.Kubernetes.Models.CredentialResult CredentialResult(string name = null, byte[] value = null) { throw null; }
        public static Azure.ResourceManager.Kubernetes.Models.CredentialResults CredentialResults(Azure.ResourceManager.Kubernetes.Models.HybridConnectionConfig hybridConnectionConfig = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kubernetes.Models.CredentialResult> kubeconfigs = null) { throw null; }
        public static Azure.ResourceManager.Kubernetes.Models.HybridConnectionConfig HybridConnectionConfig(long? expirationTime = default(long?), string hybridConnectionName = null, string relay = null, string token = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AuthenticationMethod : System.IEquatable<Azure.ResourceManager.Kubernetes.Models.AuthenticationMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AuthenticationMethod(string value) { throw null; }
        public static Azure.ResourceManager.Kubernetes.Models.AuthenticationMethod AAD { get { throw null; } }
        public static Azure.ResourceManager.Kubernetes.Models.AuthenticationMethod Token { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kubernetes.Models.AuthenticationMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kubernetes.Models.AuthenticationMethod left, Azure.ResourceManager.Kubernetes.Models.AuthenticationMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kubernetes.Models.AuthenticationMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kubernetes.Models.AuthenticationMethod left, Azure.ResourceManager.Kubernetes.Models.AuthenticationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConnectedClusterPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatch>
    {
        public ConnectedClusterPatch() { }
        public System.BinaryData Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ConnectedClusterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectivityStatus : System.IEquatable<Azure.ResourceManager.Kubernetes.Models.ConnectivityStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectivityStatus(string value) { throw null; }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectivityStatus Connected { get { throw null; } }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectivityStatus Connecting { get { throw null; } }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectivityStatus Expired { get { throw null; } }
        public static Azure.ResourceManager.Kubernetes.Models.ConnectivityStatus Offline { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kubernetes.Models.ConnectivityStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kubernetes.Models.ConnectivityStatus left, Azure.ResourceManager.Kubernetes.Models.ConnectivityStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kubernetes.Models.ConnectivityStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kubernetes.Models.ConnectivityStatus left, Azure.ResourceManager.Kubernetes.Models.ConnectivityStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CredentialResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.CredentialResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.CredentialResult>
    {
        internal CredentialResult() { }
        public string Name { get { throw null; } }
        public byte[] Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Kubernetes.Models.CredentialResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.CredentialResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.CredentialResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Kubernetes.Models.CredentialResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.CredentialResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.CredentialResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.CredentialResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CredentialResults : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.CredentialResults>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.CredentialResults>
    {
        internal CredentialResults() { }
        public Azure.ResourceManager.Kubernetes.Models.HybridConnectionConfig HybridConnectionConfig { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Kubernetes.Models.CredentialResult> Kubeconfigs { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Kubernetes.Models.CredentialResults System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.CredentialResults>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.CredentialResults>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Kubernetes.Models.CredentialResults System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.CredentialResults>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.CredentialResults>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.CredentialResults>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridConnectionConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.HybridConnectionConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.HybridConnectionConfig>
    {
        internal HybridConnectionConfig() { }
        public long? ExpirationTime { get { throw null; } }
        public string HybridConnectionName { get { throw null; } }
        public string Relay { get { throw null; } }
        public string Token { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Kubernetes.Models.HybridConnectionConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.HybridConnectionConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.HybridConnectionConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Kubernetes.Models.HybridConnectionConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.HybridConnectionConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.HybridConnectionConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.HybridConnectionConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ListClusterUserCredentialProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ListClusterUserCredentialProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ListClusterUserCredentialProperties>
    {
        public ListClusterUserCredentialProperties(Azure.ResourceManager.Kubernetes.Models.AuthenticationMethod authenticationMethod, bool clientProxy) { }
        public Azure.ResourceManager.Kubernetes.Models.AuthenticationMethod AuthenticationMethod { get { throw null; } }
        public bool ClientProxy { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Kubernetes.Models.ListClusterUserCredentialProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ListClusterUserCredentialProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Kubernetes.Models.ListClusterUserCredentialProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Kubernetes.Models.ListClusterUserCredentialProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ListClusterUserCredentialProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ListClusterUserCredentialProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Kubernetes.Models.ListClusterUserCredentialProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateLinkState : System.IEquatable<Azure.ResourceManager.Kubernetes.Models.PrivateLinkState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateLinkState(string value) { throw null; }
        public static Azure.ResourceManager.Kubernetes.Models.PrivateLinkState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Kubernetes.Models.PrivateLinkState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kubernetes.Models.PrivateLinkState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kubernetes.Models.PrivateLinkState left, Azure.ResourceManager.Kubernetes.Models.PrivateLinkState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kubernetes.Models.PrivateLinkState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kubernetes.Models.PrivateLinkState left, Azure.ResourceManager.Kubernetes.Models.PrivateLinkState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Kubernetes.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Kubernetes.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Kubernetes.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Kubernetes.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Kubernetes.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Kubernetes.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Kubernetes.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Kubernetes.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kubernetes.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kubernetes.Models.ProvisioningState left, Azure.ResourceManager.Kubernetes.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kubernetes.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kubernetes.Models.ProvisioningState left, Azure.ResourceManager.Kubernetes.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
