namespace Azure.ResourceManager.MongoCluster
{
    public partial class FirewallRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MongoCluster.FirewallRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MongoCluster.FirewallRuleResource>, System.Collections.IEnumerable
    {
        protected FirewallRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoCluster.FirewallRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.MongoCluster.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoCluster.FirewallRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.MongoCluster.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MongoCluster.FirewallRuleResource> Get(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MongoCluster.FirewallRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MongoCluster.FirewallRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.FirewallRuleResource>> GetAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MongoCluster.FirewallRuleResource> GetIfExists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MongoCluster.FirewallRuleResource>> GetIfExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MongoCluster.FirewallRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MongoCluster.FirewallRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MongoCluster.FirewallRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MongoCluster.FirewallRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FirewallRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.FirewallRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.FirewallRuleData>
    {
        public FirewallRuleData() { }
        public Azure.ResourceManager.MongoCluster.Models.FirewallRuleProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.MongoCluster.FirewallRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.FirewallRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.FirewallRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.FirewallRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.FirewallRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.FirewallRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.FirewallRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FirewallRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.FirewallRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.FirewallRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FirewallRuleResource() { }
        public virtual Azure.ResourceManager.MongoCluster.FirewallRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string mongoClusterName, string firewallRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MongoCluster.FirewallRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.FirewallRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MongoCluster.FirewallRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.FirewallRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.FirewallRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.FirewallRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.FirewallRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.FirewallRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.FirewallRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoCluster.FirewallRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MongoCluster.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoCluster.FirewallRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MongoCluster.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MongoClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MongoCluster.MongoClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MongoCluster.MongoClusterResource>, System.Collections.IEnumerable
    {
        protected MongoClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoCluster.MongoClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string mongoClusterName, Azure.ResourceManager.MongoCluster.MongoClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoCluster.MongoClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string mongoClusterName, Azure.ResourceManager.MongoCluster.MongoClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string mongoClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string mongoClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterResource> Get(string mongoClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MongoCluster.MongoClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MongoCluster.MongoClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterResource>> GetAsync(string mongoClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MongoCluster.MongoClusterResource> GetIfExists(string mongoClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MongoCluster.MongoClusterResource>> GetIfExistsAsync(string mongoClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MongoCluster.MongoClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MongoCluster.MongoClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MongoCluster.MongoClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MongoCluster.MongoClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MongoClusterData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.MongoClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterData>
    {
        public MongoClusterData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.MongoCluster.MongoClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.MongoClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.MongoClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.MongoClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class MongoClusterExtensions
    {
        public static Azure.Response<Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityResult> CheckNameAvailabilityMongoCluster(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityResult>> CheckNameAvailabilityMongoClusterAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MongoCluster.FirewallRuleResource GetFirewallRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterResource> GetMongoCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string mongoClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterResource>> GetMongoClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string mongoClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MongoCluster.MongoClusterResource GetMongoClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MongoCluster.MongoClusterCollection GetMongoClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MongoCluster.MongoClusterResource> GetMongoClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MongoCluster.MongoClusterResource> GetMongoClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResource GetPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MongoClusterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.MongoClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MongoClusterResource() { }
        public virtual Azure.ResourceManager.MongoCluster.MongoClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string mongoClusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MongoCluster.Models.ListConnectionStringsResult> GetConnectionStrings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.Models.ListConnectionStringsResult>> GetConnectionStringsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MongoCluster.FirewallRuleResource> GetFirewallRule(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.FirewallRuleResource>> GetFirewallRuleAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MongoCluster.FirewallRuleCollection GetFirewallRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResource> GetPrivateEndpointConnectionResource(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResource>> GetPrivateEndpointConnectionResourceAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResourceCollection GetPrivateEndpointConnectionResources() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrviateLinkResourceData> GetPrivateLinks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrviateLinkResourceData> GetPrivateLinksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MongoCluster.MongoClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.MongoClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.MongoClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.MongoClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoCluster.MongoClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MongoCluster.MongoClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoCluster.MongoClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MongoCluster.MongoClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string mongoClusterName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected PrivateEndpointConnectionResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateEndpointConnectionResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResourceData>
    {
        public PrivateEndpointConnectionResourceData() { }
        public Azure.ResourceManager.MongoCluster.Models.PrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.MongoCluster.Mocking
{
    public partial class MockableMongoClusterArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableMongoClusterArmClient() { }
        public virtual Azure.ResourceManager.MongoCluster.FirewallRuleResource GetFirewallRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MongoCluster.MongoClusterResource GetMongoClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResource GetPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableMongoClusterResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMongoClusterResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterResource> GetMongoCluster(string mongoClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterResource>> GetMongoClusterAsync(string mongoClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MongoCluster.MongoClusterCollection GetMongoClusters() { throw null; }
    }
    public partial class MockableMongoClusterSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMongoClusterSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityResult> CheckNameAvailabilityMongoCluster(string location, Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityResult>> CheckNameAvailabilityMongoClusterAsync(string location, Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MongoCluster.MongoClusterResource> GetMongoClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MongoCluster.MongoClusterResource> GetMongoClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.MongoCluster.Models
{
    public static partial class ArmMongoClusterModelFactory
    {
        public static Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityResult CheckNameAvailabilityResult(bool? nameAvailable = default(bool?), Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityReason? reason = default(Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.ConnectionString ConnectionString(string uri = null, string description = null) { throw null; }
        public static Azure.ResourceManager.MongoCluster.FirewallRuleData FirewallRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.MongoCluster.Models.FirewallRuleProperties properties = null) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.FirewallRuleProperties FirewallRuleProperties(Azure.ResourceManager.MongoCluster.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.MongoCluster.Models.ProvisioningState?), string startIPAddress = null, string endIPAddress = null) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.ListConnectionStringsResult ListConnectionStringsResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.MongoCluster.Models.ConnectionString> connectionStrings = null) { throw null; }
        public static Azure.ResourceManager.MongoCluster.MongoClusterData MongoClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.MongoCluster.Models.MongoClusterProperties properties = null) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnection MongoClusterPrivateEndpointConnection(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.MongoCluster.Models.PrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkResourceProperties MongoClusterPrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterProperties MongoClusterProperties(Azure.ResourceManager.MongoCluster.Models.CreateMode? createMode = default(Azure.ResourceManager.MongoCluster.Models.CreateMode?), Azure.ResourceManager.MongoCluster.Models.MongoClusterRestoreContent restoreParameters = null, string administratorLogin = null, string administratorLoginPassword = null, string serverVersion = null, string connectionString = null, string earliestRestoreTime = null, Azure.ResourceManager.MongoCluster.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.MongoCluster.Models.ProvisioningState?), Azure.ResourceManager.MongoCluster.Models.MongoClusterStatus? clusterStatus = default(Azure.ResourceManager.MongoCluster.Models.MongoClusterStatus?), Azure.ResourceManager.MongoCluster.Models.PublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.MongoCluster.Models.PublicNetworkAccess?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.MongoCluster.Models.NodeGroupSpec> nodeGroupSpecs = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnection> privateEndpointConnections = null) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterPrviateLinkResourceData MongoClusterPrviateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.PrivateEndpointConnectionProperties PrivateEndpointConnectionProperties(System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.MongoCluster.PrivateEndpointConnectionResourceData PrivateEndpointConnectionResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.MongoCluster.Models.PrivateEndpointConnectionProperties properties = null) { throw null; }
    }
    public partial class CheckNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityContent>
    {
        public CheckNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CheckNameAvailabilityReason : System.IEquatable<Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CheckNameAvailabilityReason(string value) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityReason left, Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityReason left, Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CheckNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityResult>
    {
        internal CheckNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityReason? Reason { get { throw null; } }
        Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.CheckNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectionString : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.ConnectionString>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.ConnectionString>
    {
        internal ConnectionString() { }
        public string Description { get { throw null; } }
        public string Uri { get { throw null; } }
        Azure.ResourceManager.MongoCluster.Models.ConnectionString System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.ConnectionString>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.ConnectionString>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.ConnectionString System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.ConnectionString>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.ConnectionString>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.ConnectionString>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreateMode : System.IEquatable<Azure.ResourceManager.MongoCluster.Models.CreateMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreateMode(string value) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.CreateMode Default { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.CreateMode PointInTimeRestore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MongoCluster.Models.CreateMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MongoCluster.Models.CreateMode left, Azure.ResourceManager.MongoCluster.Models.CreateMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MongoCluster.Models.CreateMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MongoCluster.Models.CreateMode left, Azure.ResourceManager.MongoCluster.Models.CreateMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FirewallRuleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.FirewallRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.FirewallRuleProperties>
    {
        public FirewallRuleProperties(string startIPAddress, string endIPAddress) { }
        public string EndIPAddress { get { throw null; } set { } }
        public Azure.ResourceManager.MongoCluster.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string StartIPAddress { get { throw null; } set { } }
        Azure.ResourceManager.MongoCluster.Models.FirewallRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.FirewallRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.FirewallRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.FirewallRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.FirewallRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.FirewallRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.FirewallRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ListConnectionStringsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.ListConnectionStringsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.ListConnectionStringsResult>
    {
        internal ListConnectionStringsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MongoCluster.Models.ConnectionString> ConnectionStrings { get { throw null; } }
        Azure.ResourceManager.MongoCluster.Models.ListConnectionStringsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.ListConnectionStringsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.ListConnectionStringsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.ListConnectionStringsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.ListConnectionStringsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.ListConnectionStringsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.ListConnectionStringsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoClusterPrivateEndpointConnection : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnection>
    {
        internal MongoClusterPrivateEndpointConnection() { }
        public Azure.ResourceManager.MongoCluster.Models.PrivateEndpointConnectionProperties Properties { get { throw null; } }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MongoClusterPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MongoClusterPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MongoClusterPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MongoClusterPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MongoClusterPrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkResourceProperties>
    {
        internal MongoClusterPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoClusterPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkServiceConnectionState>
    {
        public MongoClusterPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoClusterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterProperties>
    {
        public MongoClusterProperties() { }
        public string AdministratorLogin { get { throw null; } set { } }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterStatus? ClusterStatus { get { throw null; } }
        public string ConnectionString { get { throw null; } }
        public Azure.ResourceManager.MongoCluster.Models.CreateMode? CreateMode { get { throw null; } set { } }
        public string EarliestRestoreTime { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MongoCluster.Models.NodeGroupSpec> NodeGroupSpecs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.MongoCluster.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MongoCluster.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterRestoreContent RestoreParameters { get { throw null; } set { } }
        public string ServerVersion { get { throw null; } set { } }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoClusterPrviateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrviateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrviateLinkResourceData>
    {
        internal MongoClusterPrviateLinkResourceData() { }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkResourceProperties Properties { get { throw null; } }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterPrviateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrviateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrviateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterPrviateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrviateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrviateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrviateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoClusterRestoreContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterRestoreContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterRestoreContent>
    {
        public MongoClusterRestoreContent() { }
        public System.DateTimeOffset? PointInTimeUTC { get { throw null; } set { } }
        public string SourceResourceId { get { throw null; } set { } }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterRestoreContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterRestoreContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterRestoreContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterRestoreContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterRestoreContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterRestoreContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterRestoreContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MongoClusterStatus : System.IEquatable<Azure.ResourceManager.MongoCluster.Models.MongoClusterStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MongoClusterStatus(string value) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterStatus Dropping { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterStatus Provisioning { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterStatus Ready { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterStatus Starting { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterStatus Stopped { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterStatus Stopping { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MongoCluster.Models.MongoClusterStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MongoCluster.Models.MongoClusterStatus left, Azure.ResourceManager.MongoCluster.Models.MongoClusterStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MongoCluster.Models.MongoClusterStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MongoCluster.Models.MongoClusterStatus left, Azure.ResourceManager.MongoCluster.Models.MongoClusterStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NodeGroupSpec : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.NodeGroupSpec>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.NodeGroupSpec>
    {
        public NodeGroupSpec() { }
        public long? DiskSizeGB { get { throw null; } set { } }
        public bool? EnableHa { get { throw null; } set { } }
        public Azure.ResourceManager.MongoCluster.Models.NodeKind? Kind { get { throw null; } set { } }
        public int? NodeCount { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        Azure.ResourceManager.MongoCluster.Models.NodeGroupSpec System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.NodeGroupSpec>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.NodeGroupSpec>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.NodeGroupSpec System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.NodeGroupSpec>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.NodeGroupSpec>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.NodeGroupSpec>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NodeKind : System.IEquatable<Azure.ResourceManager.MongoCluster.Models.NodeKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NodeKind(string value) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.NodeKind Shard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MongoCluster.Models.NodeKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MongoCluster.Models.NodeKind left, Azure.ResourceManager.MongoCluster.Models.NodeKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.MongoCluster.Models.NodeKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MongoCluster.Models.NodeKind left, Azure.ResourceManager.MongoCluster.Models.NodeKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateEndpointConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.PrivateEndpointConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.PrivateEndpointConnectionProperties>
    {
        public PrivateEndpointConnectionProperties(Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkServiceConnectionState privateLinkServiceConnectionState) { }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.MongoCluster.Models.PrivateEndpointConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.PrivateEndpointConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.PrivateEndpointConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.PrivateEndpointConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.PrivateEndpointConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.PrivateEndpointConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.PrivateEndpointConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.MongoCluster.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.ProvisioningState Dropping { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.ProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MongoCluster.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MongoCluster.Models.ProvisioningState left, Azure.ResourceManager.MongoCluster.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MongoCluster.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MongoCluster.Models.ProvisioningState left, Azure.ResourceManager.MongoCluster.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.MongoCluster.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MongoCluster.Models.PublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MongoCluster.Models.PublicNetworkAccess left, Azure.ResourceManager.MongoCluster.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.MongoCluster.Models.PublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MongoCluster.Models.PublicNetworkAccess left, Azure.ResourceManager.MongoCluster.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
}
