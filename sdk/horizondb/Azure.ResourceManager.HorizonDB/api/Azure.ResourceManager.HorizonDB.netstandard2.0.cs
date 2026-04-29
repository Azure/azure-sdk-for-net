namespace Azure.ResourceManager.HorizonDB
{
    public partial class AzureResourceManagerHorizonDBContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerHorizonDBContext() { }
        public static Azure.ResourceManager.HorizonDB.AzureResourceManagerHorizonDBContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class HorizonDbClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDbClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDbClusterResource>, System.Collections.IEnumerable
    {
        protected HorizonDbClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDbClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.HorizonDB.HorizonDbClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDbClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.HorizonDB.HorizonDbClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDbClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDbClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDbClusterResource> GetIfExists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDbClusterResource>> GetIfExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.HorizonDbClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDbClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.HorizonDbClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDbClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDbClusterData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbClusterData>
    {
        public HorizonDbClusterData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDbClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDbClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbClusterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbClusterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDbClusterResource() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDbClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbPoolResource> GetHorizonDbPool(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbPoolResource>> GetHorizonDbPoolAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDbPoolCollection GetHorizonDbPools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResource> GetHorizonDbPrivateLinkResource(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResource>> GetHorizonDbPrivateLinkResourceAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResourceCollection GetHorizonDbPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResource> GetPrivateEndpointConnectionResource(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResource>> GetPrivateEndpointConnectionResourceAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResourceCollection GetPrivateEndpointConnectionResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDbClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDbClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDbClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDbClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class HorizonDBExtensions
    {
        public static Azure.ResourceManager.ArmOperation Delete(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbClusterResource> GetHorizonDbCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbClusterResource>> GetHorizonDbClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDbClusterResource GetHorizonDbClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDbClusterCollection GetHorizonDbClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDbClusterResource> GetHorizonDbClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDbClusterResource> GetHorizonDbClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleResource GetHorizonDbFirewallRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource> GetHorizonDbParameterGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource>> GetHorizonDbParameterGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource GetHorizonDbParameterGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupCollection GetHorizonDbParameterGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource> GetHorizonDbParameterGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource> GetHorizonDbParameterGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDbPoolResource GetHorizonDbPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResource GetHorizonDbPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDbReplicaResource GetHorizonDbReplicaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResource GetPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnection> Update(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionUpdate properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnection>> UpdateAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionUpdate properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HorizonDbFirewallRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleResource>, System.Collections.IEnumerable
    {
        protected HorizonDbFirewallRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleResource> Get(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleResource>> GetAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleResource> GetIfExists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleResource>> GetIfExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDbFirewallRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleData>
    {
        public HorizonDbFirewallRuleData() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDbFirewallRuleProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbFirewallRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDbFirewallRuleResource() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string poolName, string firewallRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HorizonDbParameterGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource>, System.Collections.IEnumerable
    {
        protected HorizonDbParameterGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string parameterGroupName, Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string parameterGroupName, Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource> Get(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource>> GetAsync(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource> GetIfExists(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource>> GetIfExistsAsync(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDbParameterGroupData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupData>
    {
        public HorizonDbParameterGroupData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbParameterGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDbParameterGroupResource() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parameterGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupConnectionProperties> GetConnections(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupConnectionProperties> GetConnectionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource> GetVersions(int? version = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource> GetVersionsAsync(int? version = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HorizonDbPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDbPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDbPoolResource>, System.Collections.IEnumerable
    {
        protected HorizonDbPoolCollection() { }
        public virtual Azure.Response<bool> Exists(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbPoolResource> Get(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDbPoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDbPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbPoolResource>> GetAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDbPoolResource> GetIfExists(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDbPoolResource>> GetIfExistsAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.HorizonDbPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDbPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.HorizonDbPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDbPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDbPoolData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbPoolData>
    {
        internal HorizonDbPoolData() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDbPoolProperties Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDbPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDbPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbPoolResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbPoolData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDbPoolResource() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDbPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string poolName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleResource> GetHorizonDbFirewallRule(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleResource>> GetHorizonDbFirewallRuleAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleCollection GetHorizonDbFirewallRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbReplicaResource> GetHorizonDbReplica(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbReplicaResource>> GetHorizonDbReplicaAsync(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDbReplicaCollection GetHorizonDbReplicas() { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDbPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDbPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbPrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDbPrivateLinkResource() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string groupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected HorizonDbPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResource> GetIfExists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResource>> GetIfExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDbPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResourceData>
    {
        internal HorizonDbPrivateLinkResourceData() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbReplicaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDbReplicaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDbReplicaResource>, System.Collections.IEnumerable
    {
        protected HorizonDbReplicaCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDbReplicaResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string replicaName, Azure.ResourceManager.HorizonDB.HorizonDbReplicaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDbReplicaResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string replicaName, Azure.ResourceManager.HorizonDB.HorizonDbReplicaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbReplicaResource> Get(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDbReplicaResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDbReplicaResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbReplicaResource>> GetAsync(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDbReplicaResource> GetIfExists(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDbReplicaResource>> GetIfExistsAsync(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.HorizonDbReplicaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDbReplicaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.HorizonDbReplicaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDbReplicaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDbReplicaData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbReplicaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbReplicaData>
    {
        public HorizonDbReplicaData() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDbReplicaProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDbReplicaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbReplicaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbReplicaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDbReplicaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbReplicaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbReplicaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbReplicaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbReplicaResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbReplicaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbReplicaData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDbReplicaResource() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDbReplicaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string poolName, string replicaName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbReplicaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbReplicaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDbReplicaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbReplicaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDbReplicaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDbReplicaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbReplicaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbReplicaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDbReplicaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDbReplicaResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.HorizonDbReplicaPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDbReplicaResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.HorizonDbReplicaPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateEndpointConnectionResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected PrivateEndpointConnectionResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateEndpointConnectionResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResourceData>
    {
        internal PrivateEndpointConnectionResourceData() { }
        public Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.HorizonDB.Mocking
{
    public partial class MockableHorizonDBArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableHorizonDBArmClient() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDbClusterResource GetHorizonDbClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleResource GetHorizonDbFirewallRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource GetHorizonDbParameterGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDbPoolResource GetHorizonDbPoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResource GetHorizonDbPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDbReplicaResource GetHorizonDbReplicaResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResource GetPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableHorizonDBResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHorizonDBResourceGroupResource() { }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbClusterResource> GetHorizonDbCluster(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbClusterResource>> GetHorizonDbClusterAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDbClusterCollection GetHorizonDbClusters() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource> GetHorizonDbParameterGroup(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource>> GetHorizonDbParameterGroupAsync(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupCollection GetHorizonDbParameterGroups() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnection> Update(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionUpdate properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnection>> UpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionUpdate properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableHorizonDBSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHorizonDBSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDbClusterResource> GetHorizonDbClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDbClusterResource> GetHorizonDbClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource> GetHorizonDbParameterGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupResource> GetHorizonDbParameterGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HorizonDB.Models
{
    public static partial class ArmHorizonDBModelFactory
    {
        public static Azure.ResourceManager.HorizonDB.HorizonDbClusterData HorizonDbClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterParameterGroupConnectionProperties HorizonDbClusterParameterGroupConnectionProperties(Azure.Core.ResourceIdentifier id = null, string syncStatus = null, bool? applyImmediately = default(bool?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterPatch HorizonDbClusterPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterPropertiesForPatchUpdate properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterProperties HorizonDbClusterProperties(string administratorLogin = null, string administratorLoginPassword = null, string version = null, Azure.ResourceManager.HorizonDB.Models.CreateModeCluster? createMode = default(Azure.ResourceManager.HorizonDB.Models.CreateModeCluster?), System.DateTimeOffset? pointInTimeUTC = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier sourceClusterResourceId = null, string poolName = null, int? replicaCount = default(int?), int? vCores = default(int?), string processorType = null, Azure.ResourceManager.HorizonDB.Models.PublicNetworkAccessState? publicNetworkAccess = default(Azure.ResourceManager.HorizonDB.Models.PublicNetworkAccessState?), Azure.ResourceManager.HorizonDB.Models.State? state = default(Azure.ResourceManager.HorizonDB.Models.State?), string fullyQualifiedDomainName = null, string readonlyEndpoint = null, Azure.ResourceManager.HorizonDB.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.ProvisioningState?), Azure.ResourceManager.HorizonDB.Models.ZonePlacementPolicy? zonePlacementPolicy = default(Azure.ResourceManager.HorizonDB.Models.ZonePlacementPolicy?), Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterParameterGroupConnectionProperties parameterGroup = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDbFirewallRuleData HorizonDbFirewallRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.HorizonDbFirewallRuleProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDbFirewallRuleProperties HorizonDbFirewallRuleProperties(string startIpAddress = null, string endIpAddress = null, string description = null, Azure.ResourceManager.HorizonDB.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupConnectionProperties HorizonDbParameterGroupConnectionProperties(string name = null, Azure.Core.ResourceIdentifier id = null, string type = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDbParameterGroupData HorizonDbParameterGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupPatch HorizonDbParameterGroupPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupPropertiesForPatchUpdate properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupProperties HorizonDbParameterGroupProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.Models.ParameterProperties> parameters = null, string description = null, int? pgVersion = default(int?), int? version = default(int?), bool? applyImmediately = default(bool?), Azure.ResourceManager.HorizonDB.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupPropertiesForPatchUpdate HorizonDbParameterGroupPropertiesForPatchUpdate(System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.Models.ParameterProperties> parameters = null, string description = null, bool? applyImmediately = default(bool?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDbPoolData HorizonDbPoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.HorizonDbPoolProperties properties = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDbPoolProperties HorizonDbPoolProperties(Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.HorizonDB.Models.State? state = default(Azure.ResourceManager.HorizonDB.Models.State?), int? replicaCount = default(int?), string version = null, Azure.ResourceManager.HorizonDB.Models.CreateModePool? createMode = default(Azure.ResourceManager.HorizonDB.Models.CreateModePool?), Azure.ResourceManager.HorizonDB.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnection HorizonDBPrivateEndpointConnection(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDbPrivateLinkResourceData HorizonDbPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties HorizonDBPrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDbReplicaData HorizonDbReplicaData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.HorizonDbReplicaProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDbReplicaProperties HorizonDbReplicaProperties(Azure.ResourceManager.HorizonDB.Models.ReplicaRole? role = default(Azure.ResourceManager.HorizonDB.Models.ReplicaRole?), Azure.ResourceManager.HorizonDB.Models.State? status = default(Azure.ResourceManager.HorizonDB.Models.State?), string fullyQualifiedDomainName = null, string availabilityZone = null, Azure.ResourceManager.HorizonDB.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ParameterProperties ParameterProperties(string name = null, string description = null, string value = null, string dataType = null, string allowedValues = null, bool? isDynamic = default(bool?), bool? isReadOnly = default(bool?), System.Uri documentationLink = null, string unit = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionProperties PrivateEndpointConnectionProperties(System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.PrivateEndpointConnectionResourceData PrivateEndpointConnectionResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionProperties properties = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreateModeCluster : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.CreateModeCluster>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreateModeCluster(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.CreateModeCluster Create { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.CreateModeCluster PointInTimeRestore { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.CreateModeCluster Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.CreateModeCluster other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.CreateModeCluster left, Azure.ResourceManager.HorizonDB.Models.CreateModeCluster right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.CreateModeCluster (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.CreateModeCluster? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.CreateModeCluster left, Azure.ResourceManager.HorizonDB.Models.CreateModeCluster right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreateModePool : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.CreateModePool>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreateModePool(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.CreateModePool Create { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.CreateModePool Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.CreateModePool other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.CreateModePool left, Azure.ResourceManager.HorizonDB.Models.CreateModePool right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.CreateModePool (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.CreateModePool? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.CreateModePool left, Azure.ResourceManager.HorizonDB.Models.CreateModePool right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HorizonDbClusterParameterGroupConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterParameterGroupConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterParameterGroupConnectionProperties>
    {
        public HorizonDbClusterParameterGroupConnectionProperties() { }
        public bool? ApplyImmediately { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string SyncStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterParameterGroupConnectionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterParameterGroupConnectionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterParameterGroupConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterParameterGroupConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterParameterGroupConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterParameterGroupConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterParameterGroupConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterParameterGroupConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterParameterGroupConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbClusterPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterPatch>
    {
        public HorizonDbClusterPatch() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterPropertiesForPatchUpdate Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbClusterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterProperties>
    {
        public HorizonDbClusterProperties(string administratorLogin) { }
        public string AdministratorLogin { get { throw null; } set { } }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.CreateModeCluster? CreateMode { get { throw null; } set { } }
        public string FullyQualifiedDomainName { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterParameterGroupConnectionProperties ParameterGroup { get { throw null; } set { } }
        public System.DateTimeOffset? PointInTimeUTC { get { throw null; } set { } }
        public string PoolName { get { throw null; } set { } }
        public string ProcessorType { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.PublicNetworkAccessState? PublicNetworkAccess { get { throw null; } }
        public string ReadonlyEndpoint { get { throw null; } }
        public int? ReplicaCount { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceClusterResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.State? State { get { throw null; } }
        public int? VCores { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.ZonePlacementPolicy? ZonePlacementPolicy { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbClusterPropertiesForPatchUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterPropertiesForPatchUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterPropertiesForPatchUpdate>
    {
        public HorizonDbClusterPropertiesForPatchUpdate() { }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterParameterGroupConnectionProperties ParameterGroup { get { throw null; } set { } }
        public int? VCores { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterPropertiesForPatchUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterPropertiesForPatchUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterPropertiesForPatchUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterPropertiesForPatchUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterPropertiesForPatchUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterPropertiesForPatchUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterPropertiesForPatchUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterPropertiesForPatchUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbClusterPropertiesForPatchUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbFirewallRuleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbFirewallRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbFirewallRuleProperties>
    {
        public HorizonDbFirewallRuleProperties(string startIpAddress, string endIpAddress) { }
        public string Description { get { throw null; } set { } }
        public string EndIpAddress { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string StartIpAddress { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDbFirewallRuleProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDbFirewallRuleProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDbFirewallRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbFirewallRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbFirewallRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDbFirewallRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbFirewallRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbFirewallRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbFirewallRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbParameterGroupConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupConnectionProperties>
    {
        internal HorizonDbParameterGroupConnectionProperties() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupConnectionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupConnectionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbParameterGroupPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupPatch>
    {
        public HorizonDbParameterGroupPatch() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupPropertiesForPatchUpdate Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbParameterGroupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupProperties>
    {
        public HorizonDbParameterGroupProperties() { }
        public bool? ApplyImmediately { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HorizonDB.Models.ParameterProperties> Parameters { get { throw null; } }
        public int? PgVersion { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public int? Version { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbParameterGroupPropertiesForPatchUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupPropertiesForPatchUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupPropertiesForPatchUpdate>
    {
        public HorizonDbParameterGroupPropertiesForPatchUpdate() { }
        public bool? ApplyImmediately { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HorizonDB.Models.ParameterProperties> Parameters { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupPropertiesForPatchUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupPropertiesForPatchUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupPropertiesForPatchUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupPropertiesForPatchUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupPropertiesForPatchUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupPropertiesForPatchUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupPropertiesForPatchUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupPropertiesForPatchUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbParameterGroupPropertiesForPatchUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbPoolProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbPoolProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbPoolProperties>
    {
        internal HorizonDbPoolProperties() { }
        public Azure.ResourceManager.HorizonDB.Models.CreateModePool? CreateMode { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public int? ReplicaCount { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.State? State { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDbPoolProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDbPoolProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDbPoolProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbPoolProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbPoolProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDbPoolProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbPoolProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbPoolProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbPoolProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class HorizonDbReplicaPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbReplicaPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbReplicaPatch>
    {
        public HorizonDbReplicaPatch() { }
        public Azure.ResourceManager.HorizonDB.Models.ReplicaRole? HorizonDbReplicaPropertiesForPatchUpdateRole { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDbReplicaPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDbReplicaPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDbReplicaPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbReplicaPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbReplicaPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDbReplicaPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbReplicaPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbReplicaPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbReplicaPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDbReplicaProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbReplicaProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbReplicaProperties>
    {
        public HorizonDbReplicaProperties() { }
        public string AvailabilityZone { get { throw null; } set { } }
        public string FullyQualifiedDomainName { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ReplicaRole? Role { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.State? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDbReplicaProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDbReplicaProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDbReplicaProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbReplicaProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbReplicaProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDbReplicaProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbReplicaProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbReplicaProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDbReplicaProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OptionalPropertiesUpdateableProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.OptionalPropertiesUpdateableProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.OptionalPropertiesUpdateableProperties>
    {
        public OptionalPropertiesUpdateableProperties() { }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.OptionalPropertiesUpdateableProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.OptionalPropertiesUpdateableProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.OptionalPropertiesUpdateableProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.OptionalPropertiesUpdateableProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.OptionalPropertiesUpdateableProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.OptionalPropertiesUpdateableProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.OptionalPropertiesUpdateableProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.OptionalPropertiesUpdateableProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.OptionalPropertiesUpdateableProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ParameterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ParameterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ParameterProperties>
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
        protected virtual Azure.ResourceManager.HorizonDB.Models.ParameterProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ParameterProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ParameterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ParameterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ParameterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ParameterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ParameterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ParameterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ParameterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PrivateEndpointConnectionUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionUpdate>
    {
        public PrivateEndpointConnectionUpdate() { }
        public Azure.ResourceManager.HorizonDB.Models.OptionalPropertiesUpdateableProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PrivateEndpointConnectionUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ProvisioningState left, Azure.ResourceManager.HorizonDB.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ProvisioningState left, Azure.ResourceManager.HorizonDB.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccessState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.PublicNetworkAccessState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccessState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.PublicNetworkAccessState Disabled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.PublicNetworkAccessState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.PublicNetworkAccessState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.PublicNetworkAccessState left, Azure.ResourceManager.HorizonDB.Models.PublicNetworkAccessState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.PublicNetworkAccessState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.PublicNetworkAccessState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.PublicNetworkAccessState left, Azure.ResourceManager.HorizonDB.Models.PublicNetworkAccessState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReplicaRole : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ReplicaRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReplicaRole(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ReplicaRole Read { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ReplicaRole ReadWrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ReplicaRole other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ReplicaRole left, Azure.ResourceManager.HorizonDB.Models.ReplicaRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ReplicaRole (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ReplicaRole? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ReplicaRole left, Azure.ResourceManager.HorizonDB.Models.ReplicaRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct State : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.State>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public State(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.State Disabled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.State Dropping { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.State Healthy { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.State Ready { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.State Starting { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.State Stopped { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.State Stopping { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.State Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.State other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.State left, Azure.ResourceManager.HorizonDB.Models.State right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.State (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.State? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.State left, Azure.ResourceManager.HorizonDB.Models.State right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ZonePlacementPolicy : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ZonePlacementPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ZonePlacementPolicy(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ZonePlacementPolicy BestEffort { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ZonePlacementPolicy Strict { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ZonePlacementPolicy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ZonePlacementPolicy left, Azure.ResourceManager.HorizonDB.Models.ZonePlacementPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ZonePlacementPolicy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ZonePlacementPolicy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ZonePlacementPolicy left, Azure.ResourceManager.HorizonDB.Models.ZonePlacementPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
}
