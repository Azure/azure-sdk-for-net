namespace Azure.ResourceManager.HorizonDb
{
    public partial class AzureResourceManagerHorizonDbContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerHorizonDbContext() { }
        public static Azure.ResourceManager.HorizonDb.AzureResourceManagerHorizonDbContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class HorizonDbClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDb.HorizonDbClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDb.HorizonDbClusterResource>, System.Collections.IEnumerable
    {
        protected HorizonDbClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDb.HorizonDbClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.HorizonDb.HorizonDbClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDb.HorizonDbClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.HorizonDb.HorizonDbClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDb.HorizonDbClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDb.HorizonDbClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDb.HorizonDbClusterResource> GetIfExists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDb.HorizonDbClusterResource>> GetIfExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDb.HorizonDbClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDb.HorizonDbClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDb.HorizonDbClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDb.HorizonDbClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDbClusterData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbClusterData>
    {
        public HorizonDbClusterData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDb.HorizonDbClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDb.HorizonDbClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbClusterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbClusterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDbClusterResource() { }
        public virtual Azure.ResourceManager.HorizonDb.HorizonDbClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbPoolResource> GetHorizonDbPool(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbPoolResource>> GetHorizonDbPoolAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDb.HorizonDbPoolCollection GetHorizonDbPools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResource> GetHorizonDbPrivateLinkResource(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResource>> GetHorizonDbPrivateLinkResourceAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResourceCollection GetHorizonDbPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResource> GetPrivateEndpointConnectionResource(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResource>> GetPrivateEndpointConnectionResourceAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResourceCollection GetPrivateEndpointConnectionResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDb.HorizonDbClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDb.HorizonDbClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDb.HorizonDbClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDb.HorizonDbClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class HorizonDbExtensions
    {
        public static Azure.ResourceManager.ArmOperation Delete(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbClusterResource> GetHorizonDbCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbClusterResource>> GetHorizonDbClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HorizonDb.HorizonDbClusterResource GetHorizonDbClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDb.HorizonDbClusterCollection GetHorizonDbClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HorizonDb.HorizonDbClusterResource> GetHorizonDbClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HorizonDb.HorizonDbClusterResource> GetHorizonDbClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleResource GetHorizonDbFirewallRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource> GetHorizonDbParameterGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource>> GetHorizonDbParameterGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource GetHorizonDbParameterGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupCollection GetHorizonDbParameterGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource> GetHorizonDbParameterGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource> GetHorizonDbParameterGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HorizonDb.HorizonDbPoolResource GetHorizonDbPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResource GetHorizonDbPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDb.HorizonDbReplicaResource GetHorizonDbReplicaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResource GetPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointConnection> Update(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HorizonDb.Models.PrivateEndpointConnectionUpdate properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointConnection>> UpdateAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HorizonDb.Models.PrivateEndpointConnectionUpdate properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HorizonDbFirewallRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleResource>, System.Collections.IEnumerable
    {
        protected HorizonDbFirewallRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleResource> Get(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleResource>> GetAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleResource> GetIfExists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleResource>> GetIfExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDbFirewallRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleData>
    {
        public HorizonDbFirewallRuleData() { }
        public Azure.ResourceManager.HorizonDb.Models.HorizonDbFirewallRuleProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbFirewallRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDbFirewallRuleResource() { }
        public virtual Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string poolName, string firewallRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HorizonDbParameterGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource>, System.Collections.IEnumerable
    {
        protected HorizonDbParameterGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string parameterGroupName, Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string parameterGroupName, Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource> Get(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource>> GetAsync(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource> GetIfExists(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource>> GetIfExistsAsync(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDbParameterGroupData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupData>
    {
        public HorizonDbParameterGroupData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbParameterGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDbParameterGroupResource() { }
        public virtual Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parameterGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupConnectionProperties> GetConnections(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupConnectionProperties> GetConnectionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource> GetVersions(int? version = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource> GetVersionsAsync(int? version = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HorizonDbPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDb.HorizonDbPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDb.HorizonDbPoolResource>, System.Collections.IEnumerable
    {
        protected HorizonDbPoolCollection() { }
        public virtual Azure.Response<bool> Exists(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbPoolResource> Get(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDb.HorizonDbPoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDb.HorizonDbPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbPoolResource>> GetAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDb.HorizonDbPoolResource> GetIfExists(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDb.HorizonDbPoolResource>> GetIfExistsAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDb.HorizonDbPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDb.HorizonDbPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDb.HorizonDbPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDb.HorizonDbPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDbPoolData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbPoolData>
    {
        internal HorizonDbPoolData() { }
        public Azure.ResourceManager.HorizonDb.Models.HorizonDbPoolProperties Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDb.HorizonDbPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDb.HorizonDbPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbPoolResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbPoolData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDbPoolResource() { }
        public virtual Azure.ResourceManager.HorizonDb.HorizonDbPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string poolName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleResource> GetHorizonDbFirewallRule(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleResource>> GetHorizonDbFirewallRuleAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleCollection GetHorizonDbFirewallRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbReplicaResource> GetHorizonDbReplica(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbReplicaResource>> GetHorizonDbReplicaAsync(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDb.HorizonDbReplicaCollection GetHorizonDbReplicas() { throw null; }
        Azure.ResourceManager.HorizonDb.HorizonDbPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDb.HorizonDbPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbPrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDbPrivateLinkResource() { }
        public virtual Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string groupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected HorizonDbPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResource> GetIfExists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResource>> GetIfExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDbPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResourceData>
    {
        internal HorizonDbPrivateLinkResourceData() { }
        public Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateLinkResourceProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbReplicaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDb.HorizonDbReplicaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDb.HorizonDbReplicaResource>, System.Collections.IEnumerable
    {
        protected HorizonDbReplicaCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDb.HorizonDbReplicaResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string replicaName, Azure.ResourceManager.HorizonDb.HorizonDbReplicaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDb.HorizonDbReplicaResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string replicaName, Azure.ResourceManager.HorizonDb.HorizonDbReplicaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbReplicaResource> Get(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDb.HorizonDbReplicaResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDb.HorizonDbReplicaResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbReplicaResource>> GetAsync(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDb.HorizonDbReplicaResource> GetIfExists(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDb.HorizonDbReplicaResource>> GetIfExistsAsync(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDb.HorizonDbReplicaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDb.HorizonDbReplicaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDb.HorizonDbReplicaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDb.HorizonDbReplicaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDbReplicaData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbReplicaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbReplicaData>
    {
        public HorizonDbReplicaData() { }
        public Azure.ResourceManager.HorizonDb.Models.HorizonDbReplicaProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDb.HorizonDbReplicaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbReplicaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbReplicaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDb.HorizonDbReplicaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbReplicaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbReplicaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbReplicaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbReplicaResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbReplicaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbReplicaData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDbReplicaResource() { }
        public virtual Azure.ResourceManager.HorizonDb.HorizonDbReplicaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string poolName, string replicaName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbReplicaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbReplicaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDb.HorizonDbReplicaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbReplicaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.HorizonDbReplicaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDb.HorizonDbReplicaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbReplicaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbReplicaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.HorizonDbReplicaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDb.HorizonDbReplicaResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDb.Models.HorizonDbReplicaPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDb.HorizonDbReplicaResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDb.Models.HorizonDbReplicaPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateEndpointConnectionResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected PrivateEndpointConnectionResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateEndpointConnectionResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResourceData>
    {
        internal PrivateEndpointConnectionResourceData() { }
        public Azure.ResourceManager.HorizonDb.Models.PrivateEndpointConnectionProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.HorizonDb.Mocking
{
    public partial class MockableHorizonDbArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableHorizonDbArmClient() { }
        public virtual Azure.ResourceManager.HorizonDb.HorizonDbClusterResource GetHorizonDbClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleResource GetHorizonDbFirewallRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource GetHorizonDbParameterGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDb.HorizonDbPoolResource GetHorizonDbPoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResource GetHorizonDbPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDb.HorizonDbReplicaResource GetHorizonDbReplicaResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResource GetPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableHorizonDbResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHorizonDbResourceGroupResource() { }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbClusterResource> GetHorizonDbCluster(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbClusterResource>> GetHorizonDbClusterAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDb.HorizonDbClusterCollection GetHorizonDbClusters() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource> GetHorizonDbParameterGroup(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource>> GetHorizonDbParameterGroupAsync(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupCollection GetHorizonDbParameterGroups() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointConnection> Update(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HorizonDb.Models.PrivateEndpointConnectionUpdate properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointConnection>> UpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HorizonDb.Models.PrivateEndpointConnectionUpdate properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableHorizonDbSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHorizonDbSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDb.HorizonDbClusterResource> GetHorizonDbClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDb.HorizonDbClusterResource> GetHorizonDbClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource> GetHorizonDbParameterGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupResource> GetHorizonDbParameterGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HorizonDb.Models
{
    public static partial class ArmHorizonDbModelFactory
    {
        public static Azure.ResourceManager.HorizonDb.HorizonDbClusterData HorizonDbClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterParameterGroupConnectionProperties HorizonDbClusterParameterGroupConnectionProperties(Azure.Core.ResourceIdentifier id = null, string syncStatus = null, bool? applyImmediately = default(bool?)) { throw null; }
        public static Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterPatch HorizonDbClusterPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterPropertiesForPatchUpdate properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterProperties HorizonDbClusterProperties(string administratorLogin = null, string administratorLoginPassword = null, string version = null, Azure.ResourceManager.HorizonDb.Models.CreateModeCluster? createMode = default(Azure.ResourceManager.HorizonDb.Models.CreateModeCluster?), System.DateTimeOffset? pointInTimeUTC = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier sourceClusterResourceId = null, string poolName = null, int? replicaCount = default(int?), int? vCores = default(int?), string processorType = null, Azure.ResourceManager.HorizonDb.Models.PublicNetworkAccessState? publicNetworkAccess = default(Azure.ResourceManager.HorizonDb.Models.PublicNetworkAccessState?), Azure.ResourceManager.HorizonDb.Models.State? state = default(Azure.ResourceManager.HorizonDb.Models.State?), string fullyQualifiedDomainName = null, string readonlyEndpoint = null, Azure.ResourceManager.HorizonDb.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDb.Models.ProvisioningState?), Azure.ResourceManager.HorizonDb.Models.ZonePlacementPolicy? zonePlacementPolicy = default(Azure.ResourceManager.HorizonDb.Models.ZonePlacementPolicy?), Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterParameterGroupConnectionProperties parameterGroup = null) { throw null; }
        public static Azure.ResourceManager.HorizonDb.HorizonDbFirewallRuleData HorizonDbFirewallRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDb.Models.HorizonDbFirewallRuleProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDb.Models.HorizonDbFirewallRuleProperties HorizonDbFirewallRuleProperties(string startIpAddress = null, string endIpAddress = null, string description = null, Azure.ResourceManager.HorizonDb.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDb.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupConnectionProperties HorizonDbParameterGroupConnectionProperties(string name = null, Azure.Core.ResourceIdentifier id = null, string type = null) { throw null; }
        public static Azure.ResourceManager.HorizonDb.HorizonDbParameterGroupData HorizonDbParameterGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupPatch HorizonDbParameterGroupPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupPropertiesForPatchUpdate properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupProperties HorizonDbParameterGroupProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDb.Models.ParameterProperties> parameters = null, string description = null, int? pgVersion = default(int?), int? version = default(int?), bool? applyImmediately = default(bool?), Azure.ResourceManager.HorizonDb.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDb.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupPropertiesForPatchUpdate HorizonDbParameterGroupPropertiesForPatchUpdate(System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDb.Models.ParameterProperties> parameters = null, string description = null, bool? applyImmediately = default(bool?)) { throw null; }
        public static Azure.ResourceManager.HorizonDb.HorizonDbPoolData HorizonDbPoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDb.Models.HorizonDbPoolProperties properties = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.HorizonDb.Models.HorizonDbPoolProperties HorizonDbPoolProperties(Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.HorizonDb.Models.State? state = default(Azure.ResourceManager.HorizonDb.Models.State?), int? replicaCount = default(int?), string version = null, Azure.ResourceManager.HorizonDb.Models.CreateModePool? createMode = default(Azure.ResourceManager.HorizonDb.Models.CreateModePool?), Azure.ResourceManager.HorizonDb.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDb.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointConnection HorizonDbPrivateEndpointConnection(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDb.Models.PrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDb.HorizonDbPrivateLinkResourceData HorizonDbPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateLinkResourceProperties HorizonDbPrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.HorizonDb.HorizonDbReplicaData HorizonDbReplicaData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDb.Models.HorizonDbReplicaProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDb.Models.HorizonDbReplicaProperties HorizonDbReplicaProperties(Azure.ResourceManager.HorizonDb.Models.ReplicaRole? role = default(Azure.ResourceManager.HorizonDb.Models.ReplicaRole?), Azure.ResourceManager.HorizonDb.Models.State? status = default(Azure.ResourceManager.HorizonDb.Models.State?), string fullyQualifiedDomainName = null, string availabilityZone = null, Azure.ResourceManager.HorizonDb.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDb.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDb.Models.ParameterProperties ParameterProperties(string name = null, string description = null, string value = null, string dataType = null, string allowedValues = null, bool? isDynamic = default(bool?), bool? isReadOnly = default(bool?), System.Uri documentationLink = null, string unit = null) { throw null; }
        public static Azure.ResourceManager.HorizonDb.Models.PrivateEndpointConnectionProperties PrivateEndpointConnectionProperties(System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDb.PrivateEndpointConnectionResourceData PrivateEndpointConnectionResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDb.Models.PrivateEndpointConnectionProperties properties = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreateModeCluster : System.IEquatable<Azure.ResourceManager.HorizonDb.Models.CreateModeCluster>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreateModeCluster(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDb.Models.CreateModeCluster Create { get { throw null; } }
        public static Azure.ResourceManager.HorizonDb.Models.CreateModeCluster PointInTimeRestore { get { throw null; } }
        public static Azure.ResourceManager.HorizonDb.Models.CreateModeCluster Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDb.Models.CreateModeCluster other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDb.Models.CreateModeCluster left, Azure.ResourceManager.HorizonDb.Models.CreateModeCluster right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDb.Models.CreateModeCluster (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDb.Models.CreateModeCluster? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDb.Models.CreateModeCluster left, Azure.ResourceManager.HorizonDb.Models.CreateModeCluster right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreateModePool : System.IEquatable<Azure.ResourceManager.HorizonDb.Models.CreateModePool>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreateModePool(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDb.Models.CreateModePool Create { get { throw null; } }
        public static Azure.ResourceManager.HorizonDb.Models.CreateModePool Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDb.Models.CreateModePool other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDb.Models.CreateModePool left, Azure.ResourceManager.HorizonDb.Models.CreateModePool right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDb.Models.CreateModePool (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDb.Models.CreateModePool? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDb.Models.CreateModePool left, Azure.ResourceManager.HorizonDb.Models.CreateModePool right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HorizonDbClusterParameterGroupConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterParameterGroupConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterParameterGroupConnectionProperties>
    {
        public HorizonDbClusterParameterGroupConnectionProperties() { }
        public bool? ApplyImmediately { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string SyncStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterParameterGroupConnectionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterParameterGroupConnectionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterParameterGroupConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterParameterGroupConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterParameterGroupConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterParameterGroupConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterParameterGroupConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterParameterGroupConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterParameterGroupConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbClusterPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterPatch>
    {
        public HorizonDbClusterPatch() { }
        public Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterPropertiesForPatchUpdate Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbClusterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterProperties>
    {
        public HorizonDbClusterProperties(string administratorLogin) { }
        public string AdministratorLogin { get { throw null; } set { } }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDb.Models.CreateModeCluster? CreateMode { get { throw null; } set { } }
        public string FullyQualifiedDomainName { get { throw null; } }
        public Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterParameterGroupConnectionProperties ParameterGroup { get { throw null; } set { } }
        public System.DateTimeOffset? PointInTimeUTC { get { throw null; } set { } }
        public string PoolName { get { throw null; } set { } }
        public string ProcessorType { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDb.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HorizonDb.Models.PublicNetworkAccessState? PublicNetworkAccess { get { throw null; } }
        public string ReadonlyEndpoint { get { throw null; } }
        public int? ReplicaCount { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceClusterResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDb.Models.State? State { get { throw null; } }
        public int? VCores { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDb.Models.ZonePlacementPolicy? ZonePlacementPolicy { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbClusterPropertiesForPatchUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterPropertiesForPatchUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterPropertiesForPatchUpdate>
    {
        public HorizonDbClusterPropertiesForPatchUpdate() { }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterParameterGroupConnectionProperties ParameterGroup { get { throw null; } set { } }
        public int? VCores { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterPropertiesForPatchUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterPropertiesForPatchUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterPropertiesForPatchUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterPropertiesForPatchUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterPropertiesForPatchUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterPropertiesForPatchUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterPropertiesForPatchUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterPropertiesForPatchUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbClusterPropertiesForPatchUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbFirewallRuleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbFirewallRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbFirewallRuleProperties>
    {
        public HorizonDbFirewallRuleProperties(string startIpAddress, string endIpAddress) { }
        public string Description { get { throw null; } set { } }
        public string EndIpAddress { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDb.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string StartIpAddress { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDb.Models.HorizonDbFirewallRuleProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDb.Models.HorizonDbFirewallRuleProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDb.Models.HorizonDbFirewallRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbFirewallRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbFirewallRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDb.Models.HorizonDbFirewallRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbFirewallRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbFirewallRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbFirewallRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbParameterGroupConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupConnectionProperties>
    {
        internal HorizonDbParameterGroupConnectionProperties() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupConnectionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupConnectionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbParameterGroupPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupPatch>
    {
        public HorizonDbParameterGroupPatch() { }
        public Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupPropertiesForPatchUpdate Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbParameterGroupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupProperties>
    {
        public HorizonDbParameterGroupProperties() { }
        public bool? ApplyImmediately { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HorizonDb.Models.ParameterProperties> Parameters { get { throw null; } }
        public int? PgVersion { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDb.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public int? Version { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbParameterGroupPropertiesForPatchUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupPropertiesForPatchUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupPropertiesForPatchUpdate>
    {
        public HorizonDbParameterGroupPropertiesForPatchUpdate() { }
        public bool? ApplyImmediately { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HorizonDb.Models.ParameterProperties> Parameters { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupPropertiesForPatchUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupPropertiesForPatchUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupPropertiesForPatchUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupPropertiesForPatchUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupPropertiesForPatchUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupPropertiesForPatchUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupPropertiesForPatchUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupPropertiesForPatchUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbParameterGroupPropertiesForPatchUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbPoolProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbPoolProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbPoolProperties>
    {
        internal HorizonDbPoolProperties() { }
        public Azure.ResourceManager.HorizonDb.Models.CreateModePool? CreateMode { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.HorizonDb.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public int? ReplicaCount { get { throw null; } }
        public Azure.ResourceManager.HorizonDb.Models.State? State { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDb.Models.HorizonDbPoolProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDb.Models.HorizonDbPoolProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDb.Models.HorizonDbPoolProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbPoolProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbPoolProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDb.Models.HorizonDbPoolProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbPoolProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbPoolProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbPoolProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbPrivateEndpointConnection : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointConnection>
    {
        internal HorizonDbPrivateEndpointConnection() { }
        public Azure.ResourceManager.HorizonDb.Models.PrivateEndpointConnectionProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointConnection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointConnection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDbPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDbPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointConnectionProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointConnectionProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDbPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDbPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointServiceConnectionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointServiceConnectionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HorizonDbPrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateLinkResourceProperties>
    {
        internal HorizonDbPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateLinkResourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateLinkResourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateLinkResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateLinkResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateLinkResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateLinkResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateLinkResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateLinkResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateLinkResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateLinkServiceConnectionState>
    {
        public HorizonDbPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateLinkServiceConnectionState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateLinkServiceConnectionState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbReplicaPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbReplicaPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbReplicaPatch>
    {
        public HorizonDbReplicaPatch() { }
        public Azure.ResourceManager.HorizonDb.Models.ReplicaRole? HorizonDbReplicaPropertiesForPatchUpdateRole { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDb.Models.HorizonDbReplicaPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDb.Models.HorizonDbReplicaPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDb.Models.HorizonDbReplicaPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbReplicaPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbReplicaPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDb.Models.HorizonDbReplicaPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbReplicaPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbReplicaPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbReplicaPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbReplicaProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbReplicaProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbReplicaProperties>
    {
        public HorizonDbReplicaProperties() { }
        public string AvailabilityZone { get { throw null; } set { } }
        public string FullyQualifiedDomainName { get { throw null; } }
        public Azure.ResourceManager.HorizonDb.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HorizonDb.Models.ReplicaRole? Role { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDb.Models.State? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDb.Models.HorizonDbReplicaProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDb.Models.HorizonDbReplicaProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDb.Models.HorizonDbReplicaProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbReplicaProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbReplicaProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDb.Models.HorizonDbReplicaProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbReplicaProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbReplicaProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.HorizonDbReplicaProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OptionalPropertiesUpdateableProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.OptionalPropertiesUpdateableProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.OptionalPropertiesUpdateableProperties>
    {
        public OptionalPropertiesUpdateableProperties() { }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDb.Models.OptionalPropertiesUpdateableProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDb.Models.OptionalPropertiesUpdateableProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDb.Models.OptionalPropertiesUpdateableProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.OptionalPropertiesUpdateableProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.OptionalPropertiesUpdateableProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDb.Models.OptionalPropertiesUpdateableProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.OptionalPropertiesUpdateableProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.OptionalPropertiesUpdateableProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.OptionalPropertiesUpdateableProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ParameterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.ParameterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.ParameterProperties>
    {
        public ParameterProperties() { }
        public string AllowedValues { get { throw null; } }
        public string DataType { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Uri DocumentationLink { get { throw null; } }
        public bool? IsDynamic { get { throw null; } }
        public bool? IsReadOnly { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string Unit { get { throw null; } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDb.Models.ParameterProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDb.Models.ParameterProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDb.Models.ParameterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.ParameterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.ParameterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDb.Models.ParameterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.ParameterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.ParameterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.ParameterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateEndpointConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.PrivateEndpointConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.PrivateEndpointConnectionProperties>
    {
        internal PrivateEndpointConnectionProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } }
        public Azure.ResourceManager.HorizonDb.Models.HorizonDbPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDb.Models.PrivateEndpointConnectionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDb.Models.PrivateEndpointConnectionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDb.Models.PrivateEndpointConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.PrivateEndpointConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.PrivateEndpointConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDb.Models.PrivateEndpointConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.PrivateEndpointConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.PrivateEndpointConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.PrivateEndpointConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateEndpointConnectionUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.PrivateEndpointConnectionUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.PrivateEndpointConnectionUpdate>
    {
        public PrivateEndpointConnectionUpdate() { }
        public Azure.ResourceManager.HorizonDb.Models.OptionalPropertiesUpdateableProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDb.Models.PrivateEndpointConnectionUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDb.Models.PrivateEndpointConnectionUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDb.Models.PrivateEndpointConnectionUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.PrivateEndpointConnectionUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDb.Models.PrivateEndpointConnectionUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDb.Models.PrivateEndpointConnectionUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.PrivateEndpointConnectionUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.PrivateEndpointConnectionUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDb.Models.PrivateEndpointConnectionUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.HorizonDb.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDb.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDb.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HorizonDb.Models.ProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.HorizonDb.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.HorizonDb.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDb.Models.ProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDb.Models.ProvisioningState left, Azure.ResourceManager.HorizonDb.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDb.Models.ProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDb.Models.ProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDb.Models.ProvisioningState left, Azure.ResourceManager.HorizonDb.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccessState : System.IEquatable<Azure.ResourceManager.HorizonDb.Models.PublicNetworkAccessState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccessState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDb.Models.PublicNetworkAccessState Disabled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDb.Models.PublicNetworkAccessState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDb.Models.PublicNetworkAccessState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDb.Models.PublicNetworkAccessState left, Azure.ResourceManager.HorizonDb.Models.PublicNetworkAccessState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDb.Models.PublicNetworkAccessState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDb.Models.PublicNetworkAccessState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDb.Models.PublicNetworkAccessState left, Azure.ResourceManager.HorizonDb.Models.PublicNetworkAccessState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReplicaRole : System.IEquatable<Azure.ResourceManager.HorizonDb.Models.ReplicaRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReplicaRole(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDb.Models.ReplicaRole Read { get { throw null; } }
        public static Azure.ResourceManager.HorizonDb.Models.ReplicaRole ReadWrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDb.Models.ReplicaRole other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDb.Models.ReplicaRole left, Azure.ResourceManager.HorizonDb.Models.ReplicaRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDb.Models.ReplicaRole (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDb.Models.ReplicaRole? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDb.Models.ReplicaRole left, Azure.ResourceManager.HorizonDb.Models.ReplicaRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct State : System.IEquatable<Azure.ResourceManager.HorizonDb.Models.State>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public State(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDb.Models.State Disabled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDb.Models.State Dropping { get { throw null; } }
        public static Azure.ResourceManager.HorizonDb.Models.State Healthy { get { throw null; } }
        public static Azure.ResourceManager.HorizonDb.Models.State Ready { get { throw null; } }
        public static Azure.ResourceManager.HorizonDb.Models.State Starting { get { throw null; } }
        public static Azure.ResourceManager.HorizonDb.Models.State Stopped { get { throw null; } }
        public static Azure.ResourceManager.HorizonDb.Models.State Stopping { get { throw null; } }
        public static Azure.ResourceManager.HorizonDb.Models.State Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDb.Models.State other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDb.Models.State left, Azure.ResourceManager.HorizonDb.Models.State right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDb.Models.State (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDb.Models.State? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDb.Models.State left, Azure.ResourceManager.HorizonDb.Models.State right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ZonePlacementPolicy : System.IEquatable<Azure.ResourceManager.HorizonDb.Models.ZonePlacementPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ZonePlacementPolicy(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDb.Models.ZonePlacementPolicy BestEffort { get { throw null; } }
        public static Azure.ResourceManager.HorizonDb.Models.ZonePlacementPolicy Strict { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDb.Models.ZonePlacementPolicy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDb.Models.ZonePlacementPolicy left, Azure.ResourceManager.HorizonDb.Models.ZonePlacementPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDb.Models.ZonePlacementPolicy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDb.Models.ZonePlacementPolicy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDb.Models.ZonePlacementPolicy left, Azure.ResourceManager.HorizonDb.Models.ZonePlacementPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
}
