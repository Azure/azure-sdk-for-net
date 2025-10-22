namespace Azure.ResourceManager.MongoCluster
{
    public partial class AzureResourceManagerMongoClusterContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerMongoClusterContext() { }
        public static Azure.ResourceManager.MongoCluster.AzureResourceManagerMongoClusterContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
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
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.MongoClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.MongoClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.MongoClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.MongoClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class MongoClusterExtensions
    {
        public static Azure.Response<Azure.ResourceManager.MongoCluster.Models.MongoClusterNameAvailabilityResult> CheckMongoClusterNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.MongoCluster.Models.MongoClusterNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.Models.MongoClusterNameAvailabilityResult>> CheckMongoClusterNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.MongoCluster.Models.MongoClusterNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterResource> GetMongoCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string mongoClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterResource>> GetMongoClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string mongoClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleResource GetMongoClusterFirewallRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResource GetMongoClusterPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MongoCluster.MongoClusterResource GetMongoClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MongoCluster.MongoClusterCollection GetMongoClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MongoCluster.MongoClusterResource> GetMongoClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MongoCluster.MongoClusterResource> GetMongoClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MongoCluster.MongoClusterUserResource GetMongoClusterUserResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MongoClusterFirewallRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleResource>, System.Collections.IEnumerable
    {
        protected MongoClusterFirewallRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleResource> Get(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleResource>> GetAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleResource> GetIfExists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleResource>> GetIfExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MongoClusterFirewallRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleData>
    {
        public MongoClusterFirewallRuleData() { }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterFirewallRuleProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoClusterFirewallRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MongoClusterFirewallRuleResource() { }
        public virtual Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string mongoClusterName, string firewallRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MongoClusterPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MongoClusterPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string mongoClusterName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MongoClusterPrivateEndpointConnectionResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected MongoClusterPrivateEndpointConnectionResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MongoClusterPrivateEndpointConnectionResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResourceData>
    {
        public MongoClusterPrivateEndpointConnectionResourceData() { }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.MongoCluster.Models.MongoClusterConnectionStringsResult> GetConnectionStrings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.Models.MongoClusterConnectionStringsResult>> GetConnectionStringsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleResource> GetMongoClusterFirewallRule(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleResource>> GetMongoClusterFirewallRuleAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleCollection GetMongoClusterFirewallRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResource> GetMongoClusterPrivateEndpointConnectionResource(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResource>> GetMongoClusterPrivateEndpointConnectionResourceAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResourceCollection GetMongoClusterPrivateEndpointConnectionResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterUserResource> GetMongoClusterUser(string userName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterUserResource>> GetMongoClusterUserAsync(string userName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MongoCluster.MongoClusterUserCollection GetMongoClusterUsers() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkResourceData> GetPrivateLinks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkResourceData> GetPrivateLinksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MongoCluster.Models.MongoClusterReplica> GetReplicasByParent(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MongoCluster.Models.MongoClusterReplica> GetReplicasByParentAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Promote(Azure.WaitUntil waitUntil, Azure.ResourceManager.MongoCluster.Models.PromoteReplicaContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PromoteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MongoCluster.Models.PromoteReplicaContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MongoCluster.MongoClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.MongoClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.MongoClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.MongoClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoCluster.MongoClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MongoCluster.Models.MongoClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoCluster.MongoClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MongoCluster.Models.MongoClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MongoClusterUserCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MongoCluster.MongoClusterUserResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MongoCluster.MongoClusterUserResource>, System.Collections.IEnumerable
    {
        protected MongoClusterUserCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoCluster.MongoClusterUserResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string userName, Azure.ResourceManager.MongoCluster.MongoClusterUserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoCluster.MongoClusterUserResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string userName, Azure.ResourceManager.MongoCluster.MongoClusterUserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string userName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string userName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterUserResource> Get(string userName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MongoCluster.MongoClusterUserResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MongoCluster.MongoClusterUserResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterUserResource>> GetAsync(string userName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MongoCluster.MongoClusterUserResource> GetIfExists(string userName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MongoCluster.MongoClusterUserResource>> GetIfExistsAsync(string userName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MongoCluster.MongoClusterUserResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MongoCluster.MongoClusterUserResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MongoCluster.MongoClusterUserResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MongoCluster.MongoClusterUserResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MongoClusterUserData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.MongoClusterUserData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterUserData>
    {
        public MongoClusterUserData() { }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterUserProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.MongoClusterUserData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.MongoClusterUserData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.MongoClusterUserData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.MongoClusterUserData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterUserData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterUserData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterUserData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoClusterUserResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.MongoClusterUserData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterUserData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MongoClusterUserResource() { }
        public virtual Azure.ResourceManager.MongoCluster.MongoClusterUserData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string mongoClusterName, string userName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterUserResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.MongoClusterUserResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MongoCluster.MongoClusterUserData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.MongoClusterUserData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.MongoClusterUserData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.MongoClusterUserData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterUserData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterUserData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.MongoClusterUserData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoCluster.MongoClusterUserResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MongoCluster.MongoClusterUserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoCluster.MongoClusterUserResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MongoCluster.MongoClusterUserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.MongoCluster.Mocking
{
    public partial class MockableMongoClusterArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableMongoClusterArmClient() { }
        public virtual Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleResource GetMongoClusterFirewallRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResource GetMongoClusterPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MongoCluster.MongoClusterResource GetMongoClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MongoCluster.MongoClusterUserResource GetMongoClusterUserResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.MongoCluster.Models.MongoClusterNameAvailabilityResult> CheckMongoClusterNameAvailability(Azure.Core.AzureLocation location, Azure.ResourceManager.MongoCluster.Models.MongoClusterNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.Models.MongoClusterNameAvailabilityResult>> CheckMongoClusterNameAvailabilityAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.MongoCluster.Models.MongoClusterNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MongoCluster.MongoClusterResource> GetMongoClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MongoCluster.MongoClusterResource> GetMongoClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.MongoCluster.Models
{
    public static partial class ArmMongoClusterModelFactory
    {
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterConnectionString MongoClusterConnectionString(string uri = null, string description = null, string name = null) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterConnectionStringsResult MongoClusterConnectionStringsResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.MongoCluster.Models.MongoClusterConnectionString> connectionStrings = null) { throw null; }
        public static Azure.ResourceManager.MongoCluster.MongoClusterData MongoClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.MongoCluster.Models.MongoClusterProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.MongoCluster.MongoClusterFirewallRuleData MongoClusterFirewallRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.MongoCluster.Models.MongoClusterFirewallRuleProperties properties = null) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterFirewallRuleProperties MongoClusterFirewallRuleProperties(Azure.ResourceManager.MongoCluster.Models.MongoClusterProvisioningState? provisioningState = default(Azure.ResourceManager.MongoCluster.Models.MongoClusterProvisioningState?), string startIPAddress = null, string endIPAddress = null) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterNameAvailabilityResult MongoClusterNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.MongoCluster.Models.MongoClusterNameUnavailableReason? reason = default(Azure.ResourceManager.MongoCluster.Models.MongoClusterNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnection MongoClusterPrivateEndpointConnection(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnectionProperties MongoClusterPrivateEndpointConnectionProperties(System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.MongoCluster.MongoClusterPrivateEndpointConnectionResourceData MongoClusterPrivateEndpointConnectionResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkResourceData MongoClusterPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkResourceProperties MongoClusterPrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterProperties MongoClusterProperties(Azure.ResourceManager.MongoCluster.Models.MongoClusterCreateMode? createMode = default(Azure.ResourceManager.MongoCluster.Models.MongoClusterCreateMode?), Azure.ResourceManager.MongoCluster.Models.MongoClusterRestoreContent restoreParameters = null, Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicaContent replicaParameters = null, Azure.ResourceManager.MongoCluster.Models.MongoClusterAdministratorProperties administrator = null, string serverVersion = null, string connectionString = null, Azure.ResourceManager.MongoCluster.Models.MongoClusterProvisioningState? provisioningState = default(Azure.ResourceManager.MongoCluster.Models.MongoClusterProvisioningState?), Azure.ResourceManager.MongoCluster.Models.MongoClusterStatus? clusterStatus = default(Azure.ResourceManager.MongoCluster.Models.MongoClusterStatus?), Azure.ResourceManager.MongoCluster.Models.MongoClusterPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.MongoCluster.Models.MongoClusterPublicNetworkAccess?), Azure.ResourceManager.MongoCluster.Models.HighAvailabilityMode? highAvailabilityTargetMode = default(Azure.ResourceManager.MongoCluster.Models.HighAvailabilityMode?), Azure.ResourceManager.MongoCluster.Models.MongoClusterStorageProperties storage = null, int? shardingShardCount = default(int?), string computeTier = null, string backupEarliestRestoreTime = null, Azure.ResourceManager.MongoCluster.Models.MongoClusterDataApiMode? dataApiMode = default(Azure.ResourceManager.MongoCluster.Models.MongoClusterDataApiMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnection> privateEndpointConnections = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MongoCluster.Models.MongoClusterPreviewFeature> previewFeatures = null, Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationProperties replica = null, string infrastructureVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MongoCluster.Models.MongoClusterAuthenticationMode> authConfigAllowedModes = null, Azure.ResourceManager.MongoCluster.Models.MongoClusterCmkEncryptionProperties customerManagedKeyEncryption = null) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterReplica MongoClusterReplica(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.MongoCluster.Models.MongoClusterProperties properties = null) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationProperties MongoClusterReplicationProperties(Azure.Core.ResourceIdentifier sourceResourceId = null, Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationRole? role = default(Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationRole?), Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationState? replicationState = default(Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationState?)) { throw null; }
        public static Azure.ResourceManager.MongoCluster.MongoClusterUserData MongoClusterUserData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.MongoCluster.Models.MongoClusterUserProperties properties = null) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterUserProperties MongoClusterUserProperties(Azure.ResourceManager.MongoCluster.Models.MongoClusterProvisioningState? provisioningState = default(Azure.ResourceManager.MongoCluster.Models.MongoClusterProvisioningState?), Azure.ResourceManager.MongoCluster.Models.MongoClusterIdentityProvider identityProvider = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MongoCluster.Models.MongoClusterDatabaseRole> roles = null) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.PromoteReplicaContent PromoteReplicaContent(Azure.ResourceManager.MongoCluster.Models.MongoClusterPromoteOption promoteOption = default(Azure.ResourceManager.MongoCluster.Models.MongoClusterPromoteOption), Azure.ResourceManager.MongoCluster.Models.MongoClusterPromoteMode? mode = default(Azure.ResourceManager.MongoCluster.Models.MongoClusterPromoteMode?)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HighAvailabilityMode : System.IEquatable<Azure.ResourceManager.MongoCluster.Models.HighAvailabilityMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HighAvailabilityMode(string value) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.HighAvailabilityMode Disabled { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.HighAvailabilityMode SameZone { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.HighAvailabilityMode ZoneRedundantPreferred { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MongoCluster.Models.HighAvailabilityMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MongoCluster.Models.HighAvailabilityMode left, Azure.ResourceManager.MongoCluster.Models.HighAvailabilityMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MongoCluster.Models.HighAvailabilityMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MongoCluster.Models.HighAvailabilityMode left, Azure.ResourceManager.MongoCluster.Models.HighAvailabilityMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MongoClusterAdministratorProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterAdministratorProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterAdministratorProperties>
    {
        public MongoClusterAdministratorProperties() { }
        public string Password { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterAdministratorProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterAdministratorProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterAdministratorProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterAdministratorProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterAdministratorProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterAdministratorProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterAdministratorProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MongoClusterAuthenticationMode : System.IEquatable<Azure.ResourceManager.MongoCluster.Models.MongoClusterAuthenticationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MongoClusterAuthenticationMode(string value) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterAuthenticationMode MicrosoftEntraId { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterAuthenticationMode NativeAuth { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MongoCluster.Models.MongoClusterAuthenticationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MongoCluster.Models.MongoClusterAuthenticationMode left, Azure.ResourceManager.MongoCluster.Models.MongoClusterAuthenticationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MongoCluster.Models.MongoClusterAuthenticationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MongoCluster.Models.MongoClusterAuthenticationMode left, Azure.ResourceManager.MongoCluster.Models.MongoClusterAuthenticationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MongoClusterCmkEncryptionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterCmkEncryptionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterCmkEncryptionProperties>
    {
        public MongoClusterCmkEncryptionProperties() { }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterKeyEncryptionKeyIdentity KeyEncryptionKeyIdentity { get { throw null; } set { } }
        public string KeyEncryptionKeyUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterCmkEncryptionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterCmkEncryptionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterCmkEncryptionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterCmkEncryptionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterCmkEncryptionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterCmkEncryptionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterCmkEncryptionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoClusterConnectionString : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterConnectionString>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterConnectionString>
    {
        internal MongoClusterConnectionString() { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public string Uri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterConnectionString System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterConnectionString>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterConnectionString>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterConnectionString System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterConnectionString>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterConnectionString>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterConnectionString>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoClusterConnectionStringsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterConnectionStringsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterConnectionStringsResult>
    {
        internal MongoClusterConnectionStringsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MongoCluster.Models.MongoClusterConnectionString> ConnectionStrings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterConnectionStringsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterConnectionStringsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterConnectionStringsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterConnectionStringsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterConnectionStringsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterConnectionStringsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterConnectionStringsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MongoClusterCreateMode : System.IEquatable<Azure.ResourceManager.MongoCluster.Models.MongoClusterCreateMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MongoClusterCreateMode(string value) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterCreateMode Default { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterCreateMode GeoReplica { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterCreateMode PointInTimeRestore { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterCreateMode Replica { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MongoCluster.Models.MongoClusterCreateMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MongoCluster.Models.MongoClusterCreateMode left, Azure.ResourceManager.MongoCluster.Models.MongoClusterCreateMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MongoCluster.Models.MongoClusterCreateMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MongoCluster.Models.MongoClusterCreateMode left, Azure.ResourceManager.MongoCluster.Models.MongoClusterCreateMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MongoClusterDataApiMode : System.IEquatable<Azure.ResourceManager.MongoCluster.Models.MongoClusterDataApiMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MongoClusterDataApiMode(string value) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterDataApiMode Disabled { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterDataApiMode Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MongoCluster.Models.MongoClusterDataApiMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MongoCluster.Models.MongoClusterDataApiMode left, Azure.ResourceManager.MongoCluster.Models.MongoClusterDataApiMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MongoCluster.Models.MongoClusterDataApiMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MongoCluster.Models.MongoClusterDataApiMode left, Azure.ResourceManager.MongoCluster.Models.MongoClusterDataApiMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MongoClusterDatabaseRole : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterDatabaseRole>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterDatabaseRole>
    {
        public MongoClusterDatabaseRole(string db, Azure.ResourceManager.MongoCluster.Models.MongoClusterUserRole role) { }
        public string Db { get { throw null; } set { } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterUserRole Role { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterDatabaseRole System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterDatabaseRole>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterDatabaseRole>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterDatabaseRole System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterDatabaseRole>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterDatabaseRole>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterDatabaseRole>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoClusterEntraIdentityProvider : Azure.ResourceManager.MongoCluster.Models.MongoClusterIdentityProvider, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterEntraIdentityProvider>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterEntraIdentityProvider>
    {
        public MongoClusterEntraIdentityProvider(Azure.ResourceManager.MongoCluster.Models.MongoClusterEntraIdentityProviderProperties properties) { }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterEntraPrincipalType? MongoClusterEntraIdentityProviderPrincipalType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterEntraIdentityProvider System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterEntraIdentityProvider>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterEntraIdentityProvider>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterEntraIdentityProvider System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterEntraIdentityProvider>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterEntraIdentityProvider>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterEntraIdentityProvider>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoClusterEntraIdentityProviderProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterEntraIdentityProviderProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterEntraIdentityProviderProperties>
    {
        public MongoClusterEntraIdentityProviderProperties(Azure.ResourceManager.MongoCluster.Models.MongoClusterEntraPrincipalType principalType) { }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterEntraPrincipalType PrincipalType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterEntraIdentityProviderProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterEntraIdentityProviderProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterEntraIdentityProviderProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterEntraIdentityProviderProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterEntraIdentityProviderProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterEntraIdentityProviderProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterEntraIdentityProviderProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MongoClusterEntraPrincipalType : System.IEquatable<Azure.ResourceManager.MongoCluster.Models.MongoClusterEntraPrincipalType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MongoClusterEntraPrincipalType(string value) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterEntraPrincipalType ServicePrincipal { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterEntraPrincipalType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MongoCluster.Models.MongoClusterEntraPrincipalType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MongoCluster.Models.MongoClusterEntraPrincipalType left, Azure.ResourceManager.MongoCluster.Models.MongoClusterEntraPrincipalType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MongoCluster.Models.MongoClusterEntraPrincipalType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MongoCluster.Models.MongoClusterEntraPrincipalType left, Azure.ResourceManager.MongoCluster.Models.MongoClusterEntraPrincipalType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MongoClusterFirewallRuleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterFirewallRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterFirewallRuleProperties>
    {
        public MongoClusterFirewallRuleProperties(string startIPAddress, string endIPAddress) { }
        public string EndIPAddress { get { throw null; } set { } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterProvisioningState? ProvisioningState { get { throw null; } }
        public string StartIPAddress { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterFirewallRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterFirewallRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterFirewallRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterFirewallRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterFirewallRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterFirewallRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterFirewallRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MongoClusterIdentityProvider : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterIdentityProvider>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterIdentityProvider>
    {
        protected MongoClusterIdentityProvider() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterIdentityProvider System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterIdentityProvider>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterIdentityProvider>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterIdentityProvider System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterIdentityProvider>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterIdentityProvider>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterIdentityProvider>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoClusterKeyEncryptionKeyIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterKeyEncryptionKeyIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterKeyEncryptionKeyIdentity>
    {
        public MongoClusterKeyEncryptionKeyIdentity() { }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterKeyEncryptionKeyIdentityType? IdentityType { get { throw null; } set { } }
        public string UserAssignedIdentityResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterKeyEncryptionKeyIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterKeyEncryptionKeyIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterKeyEncryptionKeyIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterKeyEncryptionKeyIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterKeyEncryptionKeyIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterKeyEncryptionKeyIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterKeyEncryptionKeyIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MongoClusterKeyEncryptionKeyIdentityType : System.IEquatable<Azure.ResourceManager.MongoCluster.Models.MongoClusterKeyEncryptionKeyIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MongoClusterKeyEncryptionKeyIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterKeyEncryptionKeyIdentityType UserAssignedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MongoCluster.Models.MongoClusterKeyEncryptionKeyIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MongoCluster.Models.MongoClusterKeyEncryptionKeyIdentityType left, Azure.ResourceManager.MongoCluster.Models.MongoClusterKeyEncryptionKeyIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MongoCluster.Models.MongoClusterKeyEncryptionKeyIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MongoCluster.Models.MongoClusterKeyEncryptionKeyIdentityType left, Azure.ResourceManager.MongoCluster.Models.MongoClusterKeyEncryptionKeyIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MongoClusterNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterNameAvailabilityContent>
    {
        public MongoClusterNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoClusterNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterNameAvailabilityResult>
    {
        internal MongoClusterNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterNameUnavailableReason? Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MongoClusterNameUnavailableReason : System.IEquatable<Azure.ResourceManager.MongoCluster.Models.MongoClusterNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MongoClusterNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterNameUnavailableReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterNameUnavailableReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MongoCluster.Models.MongoClusterNameUnavailableReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MongoCluster.Models.MongoClusterNameUnavailableReason left, Azure.ResourceManager.MongoCluster.Models.MongoClusterNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.MongoCluster.Models.MongoClusterNameUnavailableReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MongoCluster.Models.MongoClusterNameUnavailableReason left, Azure.ResourceManager.MongoCluster.Models.MongoClusterNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MongoClusterPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPatch>
    {
        public MongoClusterPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MongoClusterPreviewFeature : System.IEquatable<Azure.ResourceManager.MongoCluster.Models.MongoClusterPreviewFeature>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MongoClusterPreviewFeature(string value) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterPreviewFeature GeoReplicas { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MongoCluster.Models.MongoClusterPreviewFeature other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MongoCluster.Models.MongoClusterPreviewFeature left, Azure.ResourceManager.MongoCluster.Models.MongoClusterPreviewFeature right) { throw null; }
        public static implicit operator Azure.ResourceManager.MongoCluster.Models.MongoClusterPreviewFeature (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MongoCluster.Models.MongoClusterPreviewFeature left, Azure.ResourceManager.MongoCluster.Models.MongoClusterPreviewFeature right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MongoClusterPrivateEndpointConnection : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnection>
    {
        internal MongoClusterPrivateEndpointConnection() { }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnectionProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoClusterPrivateEndpointConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnectionProperties>
    {
        public MongoClusterPrivateEndpointConnectionProperties(Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkServiceConnectionState privateLinkServiceConnectionState) { }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class MongoClusterPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkResourceData>
    {
        internal MongoClusterPrivateLinkResourceData() { }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkResourceProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoClusterPrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkResourceProperties>
    {
        internal MongoClusterPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MongoClusterPromoteMode : System.IEquatable<Azure.ResourceManager.MongoCluster.Models.MongoClusterPromoteMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MongoClusterPromoteMode(string value) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterPromoteMode Switchover { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MongoCluster.Models.MongoClusterPromoteMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MongoCluster.Models.MongoClusterPromoteMode left, Azure.ResourceManager.MongoCluster.Models.MongoClusterPromoteMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MongoCluster.Models.MongoClusterPromoteMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MongoCluster.Models.MongoClusterPromoteMode left, Azure.ResourceManager.MongoCluster.Models.MongoClusterPromoteMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MongoClusterPromoteOption : System.IEquatable<Azure.ResourceManager.MongoCluster.Models.MongoClusterPromoteOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MongoClusterPromoteOption(string value) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterPromoteOption Forced { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MongoCluster.Models.MongoClusterPromoteOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MongoCluster.Models.MongoClusterPromoteOption left, Azure.ResourceManager.MongoCluster.Models.MongoClusterPromoteOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.MongoCluster.Models.MongoClusterPromoteOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MongoCluster.Models.MongoClusterPromoteOption left, Azure.ResourceManager.MongoCluster.Models.MongoClusterPromoteOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MongoClusterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterProperties>
    {
        public MongoClusterProperties() { }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterAdministratorProperties Administrator { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MongoCluster.Models.MongoClusterAuthenticationMode> AuthConfigAllowedModes { get { throw null; } }
        public string BackupEarliestRestoreTime { get { throw null; } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterStatus? ClusterStatus { get { throw null; } }
        public string ComputeTier { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterCreateMode? CreateMode { get { throw null; } set { } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterCmkEncryptionProperties CustomerManagedKeyEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterDataApiMode? DataApiMode { get { throw null; } set { } }
        public Azure.ResourceManager.MongoCluster.Models.HighAvailabilityMode? HighAvailabilityTargetMode { get { throw null; } set { } }
        public string InfrastructureVersion { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MongoCluster.Models.MongoClusterPreviewFeature> PreviewFeatures { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationProperties Replica { get { throw null; } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicaContent ReplicaParameters { get { throw null; } set { } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterRestoreContent RestoreParameters { get { throw null; } set { } }
        public string ServerVersion { get { throw null; } set { } }
        public int? ShardingShardCount { get { throw null; } set { } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterStorageProperties Storage { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MongoClusterProvisioningState : System.IEquatable<Azure.ResourceManager.MongoCluster.Models.MongoClusterProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MongoClusterProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterProvisioningState Dropping { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MongoCluster.Models.MongoClusterProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MongoCluster.Models.MongoClusterProvisioningState left, Azure.ResourceManager.MongoCluster.Models.MongoClusterProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MongoCluster.Models.MongoClusterProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MongoCluster.Models.MongoClusterProvisioningState left, Azure.ResourceManager.MongoCluster.Models.MongoClusterProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MongoClusterPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.MongoCluster.Models.MongoClusterPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MongoClusterPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MongoCluster.Models.MongoClusterPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MongoCluster.Models.MongoClusterPublicNetworkAccess left, Azure.ResourceManager.MongoCluster.Models.MongoClusterPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.MongoCluster.Models.MongoClusterPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MongoCluster.Models.MongoClusterPublicNetworkAccess left, Azure.ResourceManager.MongoCluster.Models.MongoClusterPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MongoClusterReplica : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterReplica>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterReplica>
    {
        internal MongoClusterReplica() { }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterReplica System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterReplica>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterReplica>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterReplica System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterReplica>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterReplica>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterReplica>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoClusterReplicaContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicaContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicaContent>
    {
        public MongoClusterReplicaContent(Azure.Core.ResourceIdentifier sourceResourceId, Azure.Core.AzureLocation sourceLocation) { }
        public Azure.Core.AzureLocation SourceLocation { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicaContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicaContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicaContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicaContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicaContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicaContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicaContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoClusterReplicationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationProperties>
    {
        internal MongoClusterReplicationProperties() { }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationState? ReplicationState { get { throw null; } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationRole? Role { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MongoClusterReplicationRole : System.IEquatable<Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MongoClusterReplicationRole(string value) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationRole AsyncReplica { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationRole GeoAsyncReplica { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationRole Primary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationRole left, Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationRole (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationRole left, Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MongoClusterReplicationState : System.IEquatable<Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MongoClusterReplicationState(string value) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationState Active { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationState Broken { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationState Catchup { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationState Reconfiguring { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationState left, Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationState left, Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MongoClusterRestoreContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterRestoreContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterRestoreContent>
    {
        public MongoClusterRestoreContent() { }
        public System.DateTimeOffset? PointInTimeUTC { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
    public partial class MongoClusterStorageProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterStorageProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterStorageProperties>
    {
        public MongoClusterStorageProperties() { }
        public long? SizeGb { get { throw null; } set { } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterStorageType? Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterStorageProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterStorageProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterStorageProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterStorageProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterStorageProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterStorageProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterStorageProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MongoClusterStorageType : System.IEquatable<Azure.ResourceManager.MongoCluster.Models.MongoClusterStorageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MongoClusterStorageType(string value) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterStorageType PremiumSSD { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterStorageType PremiumSSDv2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MongoCluster.Models.MongoClusterStorageType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MongoCluster.Models.MongoClusterStorageType left, Azure.ResourceManager.MongoCluster.Models.MongoClusterStorageType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MongoCluster.Models.MongoClusterStorageType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MongoCluster.Models.MongoClusterStorageType left, Azure.ResourceManager.MongoCluster.Models.MongoClusterStorageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MongoClusterUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterUpdateProperties>
    {
        public MongoClusterUpdateProperties() { }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterAdministratorProperties Administrator { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MongoCluster.Models.MongoClusterAuthenticationMode> AuthConfigAllowedModes { get { throw null; } }
        public string BackupEarliestRestoreTime { get { throw null; } }
        public string ComputeTier { get { throw null; } set { } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterCmkEncryptionProperties CustomerManagedKeyEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterDataApiMode? DataApiMode { get { throw null; } set { } }
        public Azure.ResourceManager.MongoCluster.Models.HighAvailabilityMode? HighAvailabilityTargetMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MongoCluster.Models.MongoClusterPreviewFeature> PreviewFeatures { get { throw null; } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string ServerVersion { get { throw null; } set { } }
        public int? ShardingShardCount { get { throw null; } set { } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterStorageProperties Storage { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MongoClusterUserProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterUserProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterUserProperties>
    {
        public MongoClusterUserProperties() { }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterIdentityProvider IdentityProvider { get { throw null; } set { } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MongoCluster.Models.MongoClusterDatabaseRole> Roles { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterUserProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterUserProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterUserProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterUserProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterUserProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterUserProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterUserProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MongoClusterUserRole : System.IEquatable<Azure.ResourceManager.MongoCluster.Models.MongoClusterUserRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MongoClusterUserRole(string value) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterUserRole Root { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MongoCluster.Models.MongoClusterUserRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MongoCluster.Models.MongoClusterUserRole left, Azure.ResourceManager.MongoCluster.Models.MongoClusterUserRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.MongoCluster.Models.MongoClusterUserRole (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MongoCluster.Models.MongoClusterUserRole left, Azure.ResourceManager.MongoCluster.Models.MongoClusterUserRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PromoteReplicaContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.PromoteReplicaContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.PromoteReplicaContent>
    {
        public PromoteReplicaContent(Azure.ResourceManager.MongoCluster.Models.MongoClusterPromoteOption promoteOption) { }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterPromoteMode? Mode { get { throw null; } set { } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterPromoteOption PromoteOption { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.PromoteReplicaContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.PromoteReplicaContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.PromoteReplicaContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.PromoteReplicaContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.PromoteReplicaContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.PromoteReplicaContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.PromoteReplicaContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
