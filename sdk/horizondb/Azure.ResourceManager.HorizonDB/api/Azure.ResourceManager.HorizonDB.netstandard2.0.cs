namespace Azure.ResourceManager.HorizonDB
{
    public partial class AzureResourceManagerHorizonDBContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerHorizonDBContext() { }
        public static Azure.ResourceManager.HorizonDB.AzureResourceManagerHorizonDBContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class HorizonDBClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>, System.Collections.IEnumerable
    {
        protected HorizonDBClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.HorizonDB.HorizonDBClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.HorizonDB.HorizonDBClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> GetIfExists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>> GetIfExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDBClusterData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>
    {
        public HorizonDBClusterData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBClusterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDBClusterResource() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> GetHorizonDBPool(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>> GetHorizonDBPoolAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBPoolCollection GetHorizonDBPools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource> GetHorizonDBPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource>> GetHorizonDBPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionCollection GetHorizonDBPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource> GetHorizonDBPrivateLinkResource(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource>> GetHorizonDBPrivateLinkResourceAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceCollection GetHorizonDBPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class HorizonDBExtensions
    {
        public static Azure.ResourceManager.ArmOperation DeletePrivateEndpointConnection(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeletePrivateEndpointConnectionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> GetHorizonDBCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>> GetHorizonDBClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBClusterResource GetHorizonDBClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBClusterCollection GetHorizonDBClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> GetHorizonDBClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> GetHorizonDBClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource GetHorizonDBFirewallRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> GetHorizonDBParameterGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>> GetHorizonDBParameterGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource GetHorizonDBParameterGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupCollection GetHorizonDBParameterGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> GetHorizonDBParameterGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> GetHorizonDBParameterGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBPoolResource GetHorizonDBPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource GetHorizonDBPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource GetHorizonDBPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBReplicaResource GetHorizonDBReplicaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnection> UpdatePrivateEndpointConnection(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnection>> UpdatePrivateEndpointConnectionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HorizonDBFirewallRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource>, System.Collections.IEnumerable
    {
        protected HorizonDBFirewallRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource> Get(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource>> GetAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource> GetIfExists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource>> GetIfExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDBFirewallRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData>
    {
        public HorizonDBFirewallRuleData() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBFirewallRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDBFirewallRuleResource() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string poolName, string firewallRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HorizonDBParameterGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>, System.Collections.IEnumerable
    {
        protected HorizonDBParameterGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string parameterGroupName, Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string parameterGroupName, Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> Get(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>> GetAsync(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> GetIfExists(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>> GetIfExistsAsync(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDBParameterGroupData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>
    {
        public HorizonDBParameterGroupData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBParameterGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDBParameterGroupResource() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parameterGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties> GetConnections(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties> GetConnectionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> GetVersions(int? version = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> GetVersionsAsync(int? version = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HorizonDBPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>, System.Collections.IEnumerable
    {
        protected HorizonDBPoolCollection() { }
        public virtual Azure.Response<bool> Exists(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> Get(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>> GetAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> GetIfExists(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>> GetIfExistsAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDBPoolData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>
    {
        internal HorizonDBPoolData() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBPoolResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDBPoolResource() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string poolName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource> GetHorizonDBFirewallRule(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource>> GetHorizonDBFirewallRuleAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleCollection GetHorizonDBFirewallRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBReplicaResource> GetHorizonDBReplica(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBReplicaResource>> GetHorizonDBReplicaAsync(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBReplicaCollection GetHorizonDBReplicas() { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected HorizonDBPrivateEndpointConnectionCollection() { }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDBPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>
    {
        internal HorizonDBPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDBPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBPrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDBPrivateLinkResource() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string groupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected HorizonDBPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource> GetIfExists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource>> GetIfExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDBPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>
    {
        internal HorizonDBPrivateLinkResourceData() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBReplicaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBReplicaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBReplicaResource>, System.Collections.IEnumerable
    {
        protected HorizonDBReplicaCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBReplicaResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string replicaName, Azure.ResourceManager.HorizonDB.HorizonDBReplicaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBReplicaResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string replicaName, Azure.ResourceManager.HorizonDB.HorizonDBReplicaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBReplicaResource> Get(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBReplicaResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBReplicaResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBReplicaResource>> GetAsync(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBReplicaResource> GetIfExists(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBReplicaResource>> GetIfExistsAsync(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBReplicaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBReplicaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBReplicaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBReplicaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDBReplicaData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBReplicaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBReplicaData>
    {
        public HorizonDBReplicaData() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBReplicaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBReplicaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBReplicaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBReplicaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBReplicaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBReplicaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBReplicaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBReplicaResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBReplicaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBReplicaData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDBReplicaResource() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBReplicaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string poolName, string replicaName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBReplicaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBReplicaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBReplicaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBReplicaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBReplicaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBReplicaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBReplicaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBReplicaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBReplicaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBReplicaResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBReplicaResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HorizonDB.Mocking
{
    public partial class MockableHorizonDBArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableHorizonDBArmClient() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBClusterResource GetHorizonDBClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource GetHorizonDBFirewallRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource GetHorizonDBParameterGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBPoolResource GetHorizonDBPoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource GetHorizonDBPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource GetHorizonDBPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBReplicaResource GetHorizonDBReplicaResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableHorizonDBResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHorizonDBResourceGroupResource() { }
        public virtual Azure.ResourceManager.ArmOperation DeletePrivateEndpointConnection(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeletePrivateEndpointConnectionAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> GetHorizonDBCluster(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>> GetHorizonDBClusterAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBClusterCollection GetHorizonDBClusters() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> GetHorizonDBParameterGroup(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>> GetHorizonDBParameterGroupAsync(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupCollection GetHorizonDBParameterGroups() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnection> UpdatePrivateEndpointConnection(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnection>> UpdatePrivateEndpointConnectionAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableHorizonDBSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHorizonDBSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> GetHorizonDBClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> GetHorizonDBClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> GetHorizonDBParameterGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> GetHorizonDBParameterGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HorizonDB.Models
{
    public static partial class ArmHorizonDBModelFactory
    {
        public static Azure.ResourceManager.HorizonDB.HorizonDBClusterData HorizonDBClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterParameterGroupConnectionProperties HorizonDBClusterParameterGroupConnectionProperties(Azure.Core.ResourceIdentifier id = null, string syncStatus = null, bool? applyImmediately = default(bool?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch HorizonDBClusterPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPropertiesForPatchUpdate properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties HorizonDBClusterProperties(string administratorLogin = null, string administratorLoginPassword = null, string version = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBCreateModeCluster? createMode = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBCreateModeCluster?), System.DateTimeOffset? pointInTimeUTC = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier sourceClusterResourceId = null, string poolName = null, int? replicaCount = default(int?), int? vCores = default(int?), string processorType = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState? publicNetworkAccess = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState?), Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState? state = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState?), string fullyQualifiedDomainName = null, string readonlyEndpoint = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState?), Azure.ResourceManager.HorizonDB.Models.HorizonDBZonePlacementPolicy? zonePlacementPolicy = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBZonePlacementPolicy?), Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterParameterGroupConnectionProperties parameterGroup = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData HorizonDBFirewallRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties HorizonDBFirewallRuleProperties(string startIpAddress = null, string endIpAddress = null, string description = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties HorizonDBParameterGroupConnectionProperties(string name = null, Azure.Core.ResourceIdentifier id = null, string type = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData HorizonDBParameterGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch HorizonDBParameterGroupPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPropertiesForPatchUpdate properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties HorizonDBParameterGroupProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties> parameters = null, string description = null, int? pgVersion = default(int?), int? version = default(int?), bool? applyImmediately = default(bool?), Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPropertiesForPatchUpdate HorizonDBParameterGroupPropertiesForPatchUpdate(System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties> parameters = null, string description = null, bool? applyImmediately = default(bool?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties HorizonDBParameterProperties(string name = null, string description = null, string value = null, string dataType = null, string allowedValues = null, bool? isDynamic = default(bool?), bool? isReadOnly = default(bool?), System.Uri documentationLink = null, string unit = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBPoolData HorizonDBPoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties properties = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties HorizonDBPoolProperties(Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState? state = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState?), int? replicaCount = default(int?), string version = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBCreateModePool? createMode = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBCreateModePool?), Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnection HorizonDBPrivateEndpointConnection(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData HorizonDBPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData HorizonDBPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties HorizonDBPrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBReplicaData HorizonDBReplicaData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaProperties HorizonDBReplicaProperties(Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaRole? role = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaRole?), Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState? status = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState?), string fullyQualifiedDomainName = null, string availabilityZone = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionProperties PrivateEndpointConnectionProperties(System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState?)) { throw null; }
    }
    public partial class HorizonDBClusterParameterGroupConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterParameterGroupConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterParameterGroupConnectionProperties>
    {
        public HorizonDBClusterParameterGroupConnectionProperties() { }
        public bool? ApplyImmediately { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string SyncStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterParameterGroupConnectionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterParameterGroupConnectionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterParameterGroupConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterParameterGroupConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterParameterGroupConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterParameterGroupConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterParameterGroupConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterParameterGroupConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterParameterGroupConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBClusterPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch>
    {
        public HorizonDBClusterPatch() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPropertiesForPatchUpdate Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBClusterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties>
    {
        public HorizonDBClusterProperties(string administratorLogin) { }
        public string AdministratorLogin { get { throw null; } set { } }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBCreateModeCluster? CreateMode { get { throw null; } set { } }
        public string FullyQualifiedDomainName { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterParameterGroupConnectionProperties ParameterGroup { get { throw null; } set { } }
        public System.DateTimeOffset? PointInTimeUTC { get { throw null; } set { } }
        public string PoolName { get { throw null; } set { } }
        public string ProcessorType { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState? PublicNetworkAccess { get { throw null; } }
        public string ReadonlyEndpoint { get { throw null; } }
        public int? ReplicaCount { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceClusterResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState? State { get { throw null; } }
        public int? VCores { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBZonePlacementPolicy? ZonePlacementPolicy { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBClusterPropertiesForPatchUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPropertiesForPatchUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPropertiesForPatchUpdate>
    {
        public HorizonDBClusterPropertiesForPatchUpdate() { }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterParameterGroupConnectionProperties ParameterGroup { get { throw null; } set { } }
        public int? VCores { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPropertiesForPatchUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPropertiesForPatchUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPropertiesForPatchUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPropertiesForPatchUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPropertiesForPatchUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPropertiesForPatchUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPropertiesForPatchUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPropertiesForPatchUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPropertiesForPatchUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBClusterState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBClusterState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState Disabled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState Dropping { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState Healthy { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState Ready { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState Starting { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState Stopped { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState Stopping { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState left, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState left, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBCreateModeCluster : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBCreateModeCluster>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBCreateModeCluster(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBCreateModeCluster Create { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBCreateModeCluster PointInTimeRestore { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBCreateModeCluster Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBCreateModeCluster other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBCreateModeCluster left, Azure.ResourceManager.HorizonDB.Models.HorizonDBCreateModeCluster right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBCreateModeCluster (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBCreateModeCluster? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBCreateModeCluster left, Azure.ResourceManager.HorizonDB.Models.HorizonDBCreateModeCluster right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBCreateModePool : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBCreateModePool>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBCreateModePool(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBCreateModePool Create { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBCreateModePool Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBCreateModePool other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBCreateModePool left, Azure.ResourceManager.HorizonDB.Models.HorizonDBCreateModePool right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBCreateModePool (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBCreateModePool? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBCreateModePool left, Azure.ResourceManager.HorizonDB.Models.HorizonDBCreateModePool right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HorizonDBFirewallRuleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties>
    {
        public HorizonDBFirewallRuleProperties(string startIpAddress, string endIpAddress) { }
        public string Description { get { throw null; } set { } }
        public string EndIpAddress { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? ProvisioningState { get { throw null; } }
        public string StartIpAddress { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBParameterGroupConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties>
    {
        internal HorizonDBParameterGroupConnectionProperties() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBParameterGroupPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch>
    {
        public HorizonDBParameterGroupPatch() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPropertiesForPatchUpdate Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBParameterGroupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties>
    {
        public HorizonDBParameterGroupProperties() { }
        public bool? ApplyImmediately { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties> Parameters { get { throw null; } }
        public int? PgVersion { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? ProvisioningState { get { throw null; } }
        public int? Version { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBParameterGroupPropertiesForPatchUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPropertiesForPatchUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPropertiesForPatchUpdate>
    {
        public HorizonDBParameterGroupPropertiesForPatchUpdate() { }
        public bool? ApplyImmediately { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties> Parameters { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPropertiesForPatchUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPropertiesForPatchUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPropertiesForPatchUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPropertiesForPatchUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPropertiesForPatchUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPropertiesForPatchUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPropertiesForPatchUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPropertiesForPatchUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPropertiesForPatchUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBParameterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties>
    {
        public HorizonDBParameterProperties() { }
        public string AllowedValues { get { throw null; } }
        public string DataType { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Uri DocumentationLink { get { throw null; } }
        public bool? IsDynamic { get { throw null; } }
        public bool? IsReadOnly { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string Unit { get { throw null; } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBPoolProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties>
    {
        internal HorizonDBPoolProperties() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBCreateModePool? CreateMode { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? ProvisioningState { get { throw null; } }
        public int? ReplicaCount { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState? State { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBPrivateEndpointConnection : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnection>
    {
        internal HorizonDBPrivateEndpointConnection() { }
        public Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBPrivateEndpointConnectionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionPatch>
    {
        public HorizonDBPrivateEndpointConnectionPatch() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionPatchProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBPrivateEndpointConnectionPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionPatchProperties>
    {
        public HorizonDBPrivateEndpointConnectionPatchProperties() { }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HorizonDBPrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties>
    {
        internal HorizonDBPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState>
    {
        public HorizonDBPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBProvisioningState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState left, Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState left, Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBPublicNetworkAccessState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBPublicNetworkAccessState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState Disabled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState left, Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState left, Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HorizonDBReplicaPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaPatch>
    {
        public HorizonDBReplicaPatch() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaRole? Role { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBReplicaProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaProperties>
    {
        public HorizonDBReplicaProperties() { }
        public string AvailabilityZone { get { throw null; } set { } }
        public string FullyQualifiedDomainName { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaRole? Role { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBReplicaRole : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBReplicaRole(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaRole Read { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaRole ReadWrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaRole other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaRole left, Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaRole (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaRole? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaRole left, Azure.ResourceManager.HorizonDB.Models.HorizonDBReplicaRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBZonePlacementPolicy : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBZonePlacementPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBZonePlacementPolicy(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBZonePlacementPolicy BestEffort { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBZonePlacementPolicy Strict { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBZonePlacementPolicy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBZonePlacementPolicy left, Azure.ResourceManager.HorizonDB.Models.HorizonDBZonePlacementPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBZonePlacementPolicy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBZonePlacementPolicy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBZonePlacementPolicy left, Azure.ResourceManager.HorizonDB.Models.HorizonDBZonePlacementPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateEndpointConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionProperties>
    {
        internal PrivateEndpointConnectionProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
