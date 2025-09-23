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
        public static Azure.ResourceManager.MongoCluster.UserResource GetUserResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkResourceData> GetPrivateLinks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateLinkResourceData> GetPrivateLinksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MongoCluster.Models.MongoClusterReplica> GetReplicasByParent(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MongoCluster.Models.MongoClusterReplica> GetReplicasByParentAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MongoCluster.UserResource> GetUser(string userName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.UserResource>> GetUserAsync(string userName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MongoCluster.UserCollection GetUsers() { throw null; }
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
    public partial class UserCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MongoCluster.UserResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MongoCluster.UserResource>, System.Collections.IEnumerable
    {
        protected UserCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoCluster.UserResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string userName, Azure.ResourceManager.MongoCluster.UserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoCluster.UserResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string userName, Azure.ResourceManager.MongoCluster.UserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string userName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string userName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MongoCluster.UserResource> Get(string userName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MongoCluster.UserResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MongoCluster.UserResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.UserResource>> GetAsync(string userName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MongoCluster.UserResource> GetIfExists(string userName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MongoCluster.UserResource>> GetIfExistsAsync(string userName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MongoCluster.UserResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MongoCluster.UserResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MongoCluster.UserResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MongoCluster.UserResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class UserData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.UserData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.UserData>
    {
        public UserData() { }
        public Azure.ResourceManager.MongoCluster.Models.UserProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.UserData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.UserData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.UserData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.UserData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.UserData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.UserData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.UserData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.UserData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.UserData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected UserResource() { }
        public virtual Azure.ResourceManager.MongoCluster.UserData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string mongoClusterName, string userName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MongoCluster.UserResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MongoCluster.UserResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MongoCluster.UserData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.UserData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.UserData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.UserData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.UserData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.UserData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.UserData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoCluster.UserResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MongoCluster.UserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MongoCluster.UserResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MongoCluster.UserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.MongoCluster.UserResource GetUserResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterProperties MongoClusterProperties(Azure.ResourceManager.MongoCluster.Models.MongoClusterCreateMode? createMode = default(Azure.ResourceManager.MongoCluster.Models.MongoClusterCreateMode?), Azure.ResourceManager.MongoCluster.Models.MongoClusterRestoreContent restoreParameters = null, Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicaContent replicaParameters = null, Azure.ResourceManager.MongoCluster.Models.MongoClusterAdministratorProperties administrator = null, string serverVersion = null, string connectionString = null, Azure.ResourceManager.MongoCluster.Models.MongoClusterProvisioningState? provisioningState = default(Azure.ResourceManager.MongoCluster.Models.MongoClusterProvisioningState?), Azure.ResourceManager.MongoCluster.Models.MongoClusterStatus? clusterStatus = default(Azure.ResourceManager.MongoCluster.Models.MongoClusterStatus?), Azure.ResourceManager.MongoCluster.Models.MongoClusterPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.MongoCluster.Models.MongoClusterPublicNetworkAccess?), Azure.ResourceManager.MongoCluster.Models.HighAvailabilityMode? highAvailabilityTargetMode = default(Azure.ResourceManager.MongoCluster.Models.HighAvailabilityMode?), Azure.ResourceManager.MongoCluster.Models.StorageProperties storage = null, int? shardingShardCount = default(int?), string computeTier = null, string backupEarliestRestoreTime = null, Azure.ResourceManager.MongoCluster.Models.DataApiMode? dataApiMode = default(Azure.ResourceManager.MongoCluster.Models.DataApiMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.MongoCluster.Models.MongoClusterPrivateEndpointConnection> privateEndpointConnections = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MongoCluster.Models.MongoClusterPreviewFeature> previewFeatures = null, Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationProperties replica = null, string infrastructureVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MongoCluster.Models.AuthenticationMode> authConfigAllowedModes = null, Azure.ResourceManager.MongoCluster.Models.CustomerManagedKeyEncryptionProperties customerManagedKeyEncryption = null) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterReplica MongoClusterReplica(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.MongoCluster.Models.MongoClusterProperties properties = null) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationProperties MongoClusterReplicationProperties(Azure.Core.ResourceIdentifier sourceResourceId = null, Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationRole? role = default(Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationRole?), Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationState? replicationState = default(Azure.ResourceManager.MongoCluster.Models.MongoClusterReplicationState?)) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.PromoteReplicaContent PromoteReplicaContent(Azure.ResourceManager.MongoCluster.Models.MongoClusterPromoteOption promoteOption = default(Azure.ResourceManager.MongoCluster.Models.MongoClusterPromoteOption), Azure.ResourceManager.MongoCluster.Models.MongoClusterPromoteMode? mode = default(Azure.ResourceManager.MongoCluster.Models.MongoClusterPromoteMode?)) { throw null; }
        public static Azure.ResourceManager.MongoCluster.UserData UserData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.MongoCluster.Models.UserProperties properties = null) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.UserProperties UserProperties(Azure.ResourceManager.MongoCluster.Models.MongoClusterProvisioningState? provisioningState = default(Azure.ResourceManager.MongoCluster.Models.MongoClusterProvisioningState?), Azure.ResourceManager.MongoCluster.Models.IdentityProvider identityProvider = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MongoCluster.Models.DatabaseRole> roles = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AuthenticationMode : System.IEquatable<Azure.ResourceManager.MongoCluster.Models.AuthenticationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AuthenticationMode(string value) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.AuthenticationMode MicrosoftEntraId { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.AuthenticationMode NativeAuth { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MongoCluster.Models.AuthenticationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MongoCluster.Models.AuthenticationMode left, Azure.ResourceManager.MongoCluster.Models.AuthenticationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MongoCluster.Models.AuthenticationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MongoCluster.Models.AuthenticationMode left, Azure.ResourceManager.MongoCluster.Models.AuthenticationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomerManagedKeyEncryptionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.CustomerManagedKeyEncryptionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.CustomerManagedKeyEncryptionProperties>
    {
        public CustomerManagedKeyEncryptionProperties(Azure.ResourceManager.MongoCluster.Models.KeyEncryptionKeyIdentity keyEncryptionKeyIdentity, string keyEncryptionKeyUri) { }
        public Azure.ResourceManager.MongoCluster.Models.KeyEncryptionKeyIdentity KeyEncryptionKeyIdentity { get { throw null; } set { } }
        public string KeyEncryptionKeyUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.CustomerManagedKeyEncryptionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.CustomerManagedKeyEncryptionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.CustomerManagedKeyEncryptionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.CustomerManagedKeyEncryptionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.CustomerManagedKeyEncryptionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.CustomerManagedKeyEncryptionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.CustomerManagedKeyEncryptionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataApiMode : System.IEquatable<Azure.ResourceManager.MongoCluster.Models.DataApiMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataApiMode(string value) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.DataApiMode Disabled { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.DataApiMode Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MongoCluster.Models.DataApiMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MongoCluster.Models.DataApiMode left, Azure.ResourceManager.MongoCluster.Models.DataApiMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MongoCluster.Models.DataApiMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MongoCluster.Models.DataApiMode left, Azure.ResourceManager.MongoCluster.Models.DataApiMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabaseRole : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.DatabaseRole>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.DatabaseRole>
    {
        public DatabaseRole(string db, Azure.ResourceManager.MongoCluster.Models.UserRole role) { }
        public string Db { get { throw null; } set { } }
        public Azure.ResourceManager.MongoCluster.Models.UserRole Role { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.DatabaseRole System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.DatabaseRole>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.DatabaseRole>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.DatabaseRole System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.DatabaseRole>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.DatabaseRole>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.DatabaseRole>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntraIdentityProvider : Azure.ResourceManager.MongoCluster.Models.IdentityProvider, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.EntraIdentityProvider>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.EntraIdentityProvider>
    {
        public EntraIdentityProvider(Azure.ResourceManager.MongoCluster.Models.EntraIdentityProviderProperties properties) { }
        public Azure.ResourceManager.MongoCluster.Models.EntraPrincipalType? EntraIdentityProviderPrincipalType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.EntraIdentityProvider System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.EntraIdentityProvider>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.EntraIdentityProvider>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.EntraIdentityProvider System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.EntraIdentityProvider>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.EntraIdentityProvider>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.EntraIdentityProvider>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntraIdentityProviderProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.EntraIdentityProviderProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.EntraIdentityProviderProperties>
    {
        public EntraIdentityProviderProperties(Azure.ResourceManager.MongoCluster.Models.EntraPrincipalType principalType) { }
        public Azure.ResourceManager.MongoCluster.Models.EntraPrincipalType PrincipalType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.EntraIdentityProviderProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.EntraIdentityProviderProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.EntraIdentityProviderProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.EntraIdentityProviderProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.EntraIdentityProviderProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.EntraIdentityProviderProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.EntraIdentityProviderProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EntraPrincipalType : System.IEquatable<Azure.ResourceManager.MongoCluster.Models.EntraPrincipalType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EntraPrincipalType(string value) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.EntraPrincipalType ServicePrincipal { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.EntraPrincipalType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MongoCluster.Models.EntraPrincipalType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MongoCluster.Models.EntraPrincipalType left, Azure.ResourceManager.MongoCluster.Models.EntraPrincipalType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MongoCluster.Models.EntraPrincipalType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MongoCluster.Models.EntraPrincipalType left, Azure.ResourceManager.MongoCluster.Models.EntraPrincipalType right) { throw null; }
        public override string ToString() { throw null; }
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
    public abstract partial class IdentityProvider : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.IdentityProvider>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.IdentityProvider>
    {
        protected IdentityProvider() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.IdentityProvider System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.IdentityProvider>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.IdentityProvider>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.IdentityProvider System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.IdentityProvider>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.IdentityProvider>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.IdentityProvider>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyEncryptionKeyIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.KeyEncryptionKeyIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.KeyEncryptionKeyIdentity>
    {
        public KeyEncryptionKeyIdentity(Azure.ResourceManager.MongoCluster.Models.KeyEncryptionKeyIdentityType identityType, string userAssignedIdentityResourceId) { }
        public Azure.ResourceManager.MongoCluster.Models.KeyEncryptionKeyIdentityType IdentityType { get { throw null; } set { } }
        public string UserAssignedIdentityResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.KeyEncryptionKeyIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.KeyEncryptionKeyIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.KeyEncryptionKeyIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.KeyEncryptionKeyIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.KeyEncryptionKeyIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.KeyEncryptionKeyIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.KeyEncryptionKeyIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyEncryptionKeyIdentityType : System.IEquatable<Azure.ResourceManager.MongoCluster.Models.KeyEncryptionKeyIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyEncryptionKeyIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.KeyEncryptionKeyIdentityType UserAssignedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MongoCluster.Models.KeyEncryptionKeyIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MongoCluster.Models.KeyEncryptionKeyIdentityType left, Azure.ResourceManager.MongoCluster.Models.KeyEncryptionKeyIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MongoCluster.Models.KeyEncryptionKeyIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MongoCluster.Models.KeyEncryptionKeyIdentityType left, Azure.ResourceManager.MongoCluster.Models.KeyEncryptionKeyIdentityType right) { throw null; }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.MongoCluster.Models.AuthenticationMode> AuthConfigAllowedModes { get { throw null; } }
        public string BackupEarliestRestoreTime { get { throw null; } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterStatus? ClusterStatus { get { throw null; } }
        public string ComputeTier { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterCreateMode? CreateMode { get { throw null; } set { } }
        public Azure.ResourceManager.MongoCluster.Models.CustomerManagedKeyEncryptionProperties CustomerManagedKeyEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.MongoCluster.Models.DataApiMode? DataApiMode { get { throw null; } set { } }
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
        public Azure.ResourceManager.MongoCluster.Models.StorageProperties Storage { get { throw null; } set { } }
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
    public partial class MongoClusterUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterUpdateProperties>
    {
        public MongoClusterUpdateProperties() { }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterAdministratorProperties Administrator { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MongoCluster.Models.AuthenticationMode> AuthConfigAllowedModes { get { throw null; } }
        public string BackupEarliestRestoreTime { get { throw null; } }
        public string ComputeTier { get { throw null; } set { } }
        public Azure.ResourceManager.MongoCluster.Models.DataApiMode? DataApiMode { get { throw null; } set { } }
        public Azure.ResourceManager.MongoCluster.Models.HighAvailabilityMode? HighAvailabilityTargetMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MongoCluster.Models.MongoClusterPreviewFeature> PreviewFeatures { get { throw null; } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string ServerVersion { get { throw null; } set { } }
        public int? ShardingShardCount { get { throw null; } set { } }
        public Azure.ResourceManager.MongoCluster.Models.StorageProperties Storage { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.MongoClusterUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.MongoClusterUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class StorageProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.StorageProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.StorageProperties>
    {
        public StorageProperties() { }
        public long? SizeGb { get { throw null; } set { } }
        public Azure.ResourceManager.MongoCluster.Models.StorageType? Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.StorageProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.StorageProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.StorageProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.StorageProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.StorageProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.StorageProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.StorageProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageType : System.IEquatable<Azure.ResourceManager.MongoCluster.Models.StorageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageType(string value) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.StorageType PremiumSSD { get { throw null; } }
        public static Azure.ResourceManager.MongoCluster.Models.StorageType PremiumSSDv2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MongoCluster.Models.StorageType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MongoCluster.Models.StorageType left, Azure.ResourceManager.MongoCluster.Models.StorageType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MongoCluster.Models.StorageType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MongoCluster.Models.StorageType left, Azure.ResourceManager.MongoCluster.Models.StorageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.UserProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.UserProperties>
    {
        public UserProperties() { }
        public Azure.ResourceManager.MongoCluster.Models.IdentityProvider IdentityProvider { get { throw null; } set { } }
        public Azure.ResourceManager.MongoCluster.Models.MongoClusterProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MongoCluster.Models.DatabaseRole> Roles { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.UserProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.UserProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MongoCluster.Models.UserProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MongoCluster.Models.UserProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.UserProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.UserProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MongoCluster.Models.UserProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UserRole : System.IEquatable<Azure.ResourceManager.MongoCluster.Models.UserRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UserRole(string value) { throw null; }
        public static Azure.ResourceManager.MongoCluster.Models.UserRole Root { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MongoCluster.Models.UserRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MongoCluster.Models.UserRole left, Azure.ResourceManager.MongoCluster.Models.UserRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.MongoCluster.Models.UserRole (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MongoCluster.Models.UserRole left, Azure.ResourceManager.MongoCluster.Models.UserRole right) { throw null; }
        public override string ToString() { throw null; }
    }
}
