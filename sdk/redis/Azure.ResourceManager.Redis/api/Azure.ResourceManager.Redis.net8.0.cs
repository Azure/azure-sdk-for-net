namespace Azure.ResourceManager.Redis
{
    public partial class AzureResourceManagerRedisContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerRedisContext() { }
        public static Azure.ResourceManager.Redis.AzureResourceManagerRedisContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class RedisCacheAccessPolicyAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentResource>, System.Collections.IEnumerable
    {
        protected RedisCacheAccessPolicyAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accessPolicyAssignmentName, Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accessPolicyAssignmentName, Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accessPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accessPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentResource> Get(string accessPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentResource>> GetAsync(string accessPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentResource> GetIfExists(string accessPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentResource>> GetIfExistsAsync(string accessPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RedisCacheAccessPolicyAssignmentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentData>
    {
        public RedisCacheAccessPolicyAssignmentData() { }
        public string AccessPolicyName { get { throw null; } set { } }
        public System.Guid ObjectId { get { throw null; } set { } }
        public string ObjectIdAlias { get { throw null; } set { } }
        public Azure.ResourceManager.Redis.Models.AccessPolicyAssignmentProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RedisCacheAccessPolicyAssignmentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RedisCacheAccessPolicyAssignmentResource() { }
        public virtual Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cacheName, string accessPolicyAssignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RedisCacheAccessPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Redis.RedisCacheAccessPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.RedisCacheAccessPolicyResource>, System.Collections.IEnumerable
    {
        protected RedisCacheAccessPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisCacheAccessPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accessPolicyName, Azure.ResourceManager.Redis.RedisCacheAccessPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisCacheAccessPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accessPolicyName, Azure.ResourceManager.Redis.RedisCacheAccessPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accessPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accessPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisCacheAccessPolicyResource> Get(string accessPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Redis.RedisCacheAccessPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Redis.RedisCacheAccessPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisCacheAccessPolicyResource>> GetAsync(string accessPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Redis.RedisCacheAccessPolicyResource> GetIfExists(string accessPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Redis.RedisCacheAccessPolicyResource>> GetIfExistsAsync(string accessPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Redis.RedisCacheAccessPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Redis.RedisCacheAccessPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Redis.RedisCacheAccessPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.RedisCacheAccessPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RedisCacheAccessPolicyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisCacheAccessPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisCacheAccessPolicyData>
    {
        public RedisCacheAccessPolicyData() { }
        public string Permissions { get { throw null; } set { } }
        public Azure.ResourceManager.Redis.Models.AccessPolicyProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.AccessPolicyType? Type { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Redis.RedisCacheAccessPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisCacheAccessPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisCacheAccessPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.RedisCacheAccessPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisCacheAccessPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisCacheAccessPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisCacheAccessPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RedisCacheAccessPolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisCacheAccessPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisCacheAccessPolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RedisCacheAccessPolicyResource() { }
        public virtual Azure.ResourceManager.Redis.RedisCacheAccessPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cacheName, string accessPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisCacheAccessPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisCacheAccessPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Redis.RedisCacheAccessPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisCacheAccessPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisCacheAccessPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.RedisCacheAccessPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisCacheAccessPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisCacheAccessPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisCacheAccessPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisCacheAccessPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.RedisCacheAccessPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisCacheAccessPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.RedisCacheAccessPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RedisCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Redis.RedisResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.RedisResource>, System.Collections.IEnumerable
    {
        protected RedisCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Redis.Models.RedisCreateOrUpdateContent redisCreateOrUpdateContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Redis.Models.RedisCreateOrUpdateContent redisCreateOrUpdateContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Redis.RedisResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Redis.RedisResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Redis.RedisResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Redis.RedisResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Redis.RedisResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Redis.RedisResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Redis.RedisResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.RedisResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RedisData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisData>
    {
        internal RedisData() { }
        public Azure.ResourceManager.Redis.Models.RedisAccessKeys AccessKeys { get { throw null; } }
        public bool? EnableNonSslPort { get { throw null; } }
        public string HostName { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Redis.Models.RedisInstanceDetails> Instances { get { throw null; } }
        public bool? IsAccessKeyAuthenticationDisabled { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Redis.Models.RedisLinkedServer> LinkedServers { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.RedisTlsVersion? MinimumTlsVersion { get { throw null; } }
        public int? Port { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.RedisProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess? PublicNetworkAccess { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.RedisCommonConfiguration RedisConfiguration { get { throw null; } }
        public string RedisVersion { get { throw null; } }
        public int? ReplicasPerMaster { get { throw null; } }
        public int? ReplicasPerPrimary { get { throw null; } }
        public int? ShardCount { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.RedisSku Sku { get { throw null; } }
        public int? SslPort { get { throw null; } }
        public string StaticIP { get { throw null; } }
        public string SubnetId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> TenantSettings { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.UpdateChannel? UpdateChannel { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.ZonalAllocationPolicy? ZonalAllocationPolicy { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Redis.RedisData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.RedisData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class RedisExtensions
    {
        public static Azure.Response CheckNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Redis.Models.RedisNameAvailabilityContent redisNameAvailabilityContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> CheckNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Redis.Models.RedisNameAvailabilityContent redisNameAvailabilityContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Redis.Models.RedisOperationStatus> Get(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Redis.RedisCollection GetAllRedis(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.Models.RedisOperationStatus>> GetAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Redis.RedisResource> GetRedis(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Redis.RedisResource> GetRedis(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisResource>> GetRedisAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Redis.RedisResource> GetRedisAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentResource GetRedisCacheAccessPolicyAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Redis.RedisCacheAccessPolicyResource GetRedisCacheAccessPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Redis.RedisFirewallRuleResource GetRedisFirewallRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource GetRedisLinkedServerWithPropertyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Redis.RedisPatchScheduleResource GetRedisPatchScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource GetRedisPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Redis.RedisResource GetRedisResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class RedisFirewallRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Redis.RedisFirewallRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.RedisFirewallRuleResource>, System.Collections.IEnumerable
    {
        protected RedisFirewallRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisFirewallRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleName, Azure.ResourceManager.Redis.RedisFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisFirewallRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleName, Azure.ResourceManager.Redis.RedisFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisFirewallRuleResource> Get(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Redis.RedisFirewallRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Redis.RedisFirewallRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisFirewallRuleResource>> GetAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Redis.RedisFirewallRuleResource> GetIfExists(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Redis.RedisFirewallRuleResource>> GetIfExistsAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Redis.RedisFirewallRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Redis.RedisFirewallRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Redis.RedisFirewallRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.RedisFirewallRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RedisFirewallRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisFirewallRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisFirewallRuleData>
    {
        public RedisFirewallRuleData(string startIP, string endIP) { }
        public string EndIP { get { throw null; } set { } }
        public string StartIP { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Redis.RedisFirewallRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisFirewallRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisFirewallRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.RedisFirewallRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisFirewallRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisFirewallRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisFirewallRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RedisFirewallRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisFirewallRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisFirewallRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RedisFirewallRuleResource() { }
        public virtual Azure.ResourceManager.Redis.RedisFirewallRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cacheName, string ruleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisFirewallRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisFirewallRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Redis.RedisFirewallRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisFirewallRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisFirewallRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.RedisFirewallRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisFirewallRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisFirewallRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisFirewallRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisFirewallRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.RedisFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisFirewallRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.RedisFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RedisLinkedServerWithPropertyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource>, System.Collections.IEnumerable
    {
        protected RedisLinkedServerWithPropertyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string linkedServerName, Azure.ResourceManager.Redis.Models.RedisRedisRebootParametersCreatOrUpdateContent redisRedisRebootParametersCreatOrUpdateContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string linkedServerName, Azure.ResourceManager.Redis.Models.RedisRedisRebootParametersCreatOrUpdateContent redisRedisRebootParametersCreatOrUpdateContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string linkedServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string linkedServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource> Get(string linkedServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource>> GetAsync(string linkedServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource> GetIfExists(string linkedServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource>> GetIfExistsAsync(string linkedServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RedisLinkedServerWithPropertyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyData>
    {
        internal RedisLinkedServerWithPropertyData() { }
        public string GeoReplicatedPrimaryHostName { get { throw null; } }
        public Azure.Core.ResourceIdentifier LinkedRedisCacheId { get { throw null; } }
        public Azure.Core.AzureLocation LinkedRedisCacheLocation { get { throw null; } }
        public string PrimaryHostName { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.RedisLinkedServerRole ServerRole { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RedisLinkedServerWithPropertyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RedisLinkedServerWithPropertyResource() { }
        public virtual Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string linkedServerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.Models.RedisRedisRebootParametersCreatOrUpdateContent redisRedisRebootParametersCreatOrUpdateContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.Models.RedisRedisRebootParametersCreatOrUpdateContent redisRedisRebootParametersCreatOrUpdateContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RedisPatchScheduleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Redis.RedisPatchScheduleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.RedisPatchScheduleResource>, System.Collections.IEnumerable
    {
        protected RedisPatchScheduleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisPatchScheduleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName @default, Azure.ResourceManager.Redis.RedisPatchScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisPatchScheduleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName @default, Azure.ResourceManager.Redis.RedisPatchScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName @default, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName @default, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisPatchScheduleResource> Get(Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName @default, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Redis.RedisPatchScheduleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Redis.RedisPatchScheduleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisPatchScheduleResource>> GetAsync(Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName @default, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Redis.RedisPatchScheduleResource> GetIfExists(Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName @default, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Redis.RedisPatchScheduleResource>> GetIfExistsAsync(Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName @default, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Redis.RedisPatchScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Redis.RedisPatchScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Redis.RedisPatchScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.RedisPatchScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RedisPatchScheduleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisPatchScheduleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisPatchScheduleData>
    {
        public RedisPatchScheduleData(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.Models.RedisPatchScheduleSetting> scheduleEntries) { }
        public string Location { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Redis.Models.RedisPatchScheduleSetting> ScheduleEntries { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Redis.RedisPatchScheduleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisPatchScheduleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisPatchScheduleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.RedisPatchScheduleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisPatchScheduleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisPatchScheduleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisPatchScheduleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RedisPatchScheduleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisPatchScheduleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisPatchScheduleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RedisPatchScheduleResource() { }
        public virtual Azure.ResourceManager.Redis.RedisPatchScheduleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName @default) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisPatchScheduleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisPatchScheduleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Redis.RedisPatchScheduleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisPatchScheduleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisPatchScheduleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.RedisPatchScheduleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisPatchScheduleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisPatchScheduleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisPatchScheduleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisPatchScheduleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.RedisPatchScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisPatchScheduleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.RedisPatchScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RedisPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected RedisPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RedisPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData>
    {
        public RedisPrivateEndpointConnectionData() { }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.RedisPrivateLinkServiceConnectionState RedisPrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.Redis.Models.RedisPrivateEndpointConnectionProvisioningState? RedisProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RedisPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RedisPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cacheName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RedisResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RedisResource() { }
        public virtual Azure.ResourceManager.Redis.RedisData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ExportData(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.Models.ExportRdbContent exportRdbContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExportDataAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.Models.ExportRdbContent exportRdbContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult> FlushCache(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult>> FlushCacheAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.Models.RedisForceRebootResult> ForceReboot(Azure.ResourceManager.Redis.Models.RedisRebootParametersContent redisRebootParametersContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.Models.RedisForceRebootResult>> ForceRebootAsync(Azure.ResourceManager.Redis.Models.RedisRebootParametersContent redisRebootParametersContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Redis.Models.RedisPrivateLinkResource> GetByRedisCache(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Redis.Models.RedisPrivateLinkResource> GetByRedisCacheAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.Models.RedisAccessKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.Models.RedisAccessKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Redis.RedisCacheAccessPolicyCollection GetRedisCacheAccessPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisCacheAccessPolicyResource> GetRedisCacheAccessPolicy(string accessPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentResource> GetRedisCacheAccessPolicyAssignment(string accessPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentResource>> GetRedisCacheAccessPolicyAssignmentAsync(string accessPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentCollection GetRedisCacheAccessPolicyAssignments() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisCacheAccessPolicyResource>> GetRedisCacheAccessPolicyAsync(string accessPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisFirewallRuleResource> GetRedisFirewallRule(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisFirewallRuleResource>> GetRedisFirewallRuleAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Redis.RedisFirewallRuleCollection GetRedisFirewallRules() { throw null; }
        public virtual Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyCollection GetRedisLinkedServerWithProperties() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource> GetRedisLinkedServerWithProperty(string linkedServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource>> GetRedisLinkedServerWithPropertyAsync(string linkedServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisPatchScheduleResource> GetRedisPatchSchedule(Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName @default, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisPatchScheduleResource>> GetRedisPatchScheduleAsync(Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName @default, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Redis.RedisPatchScheduleCollection GetRedisPatchSchedules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource> GetRedisPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource>> GetRedisPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionCollection GetRedisPrivateEndpointConnections() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Redis.Models.RedisUpgradeNotification> GetUpgradeNotifications(double history, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Redis.Models.RedisUpgradeNotification> GetUpgradeNotificationsAsync(double history, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ImportData(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.Models.ImportRdbContent importRdbContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ImportDataAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.Models.ImportRdbContent importRdbContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.Models.RedisAccessKeys> RegenerateKey(Azure.ResourceManager.Redis.Models.RedisRegenerateKeyContent redisRegenerateKeyContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.Models.RedisAccessKeys>> RegenerateKeyAsync(Azure.ResourceManager.Redis.Models.RedisRegenerateKeyContent redisRegenerateKeyContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Redis.RedisData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.RedisData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.RedisData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.RedisData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.Models.RedisPatch redisPatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Redis.RedisResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Redis.Models.RedisPatch redisPatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Redis.Mocking
{
    public partial class MockableRedisArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableRedisArmClient() { }
        public virtual Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentResource GetRedisCacheAccessPolicyAssignmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Redis.RedisCacheAccessPolicyResource GetRedisCacheAccessPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Redis.RedisFirewallRuleResource GetRedisFirewallRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyResource GetRedisLinkedServerWithPropertyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Redis.RedisPatchScheduleResource GetRedisPatchScheduleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionResource GetRedisPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Redis.RedisResource GetRedisResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableRedisResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableRedisResourceGroupResource() { }
        public virtual Azure.ResourceManager.Redis.RedisCollection GetAllRedis() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.RedisResource> GetRedis(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.RedisResource>> GetRedisAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableRedisSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableRedisSubscriptionResource() { }
        public virtual Azure.Response CheckNameAvailability(Azure.ResourceManager.Redis.Models.RedisNameAvailabilityContent redisNameAvailabilityContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckNameAvailabilityAsync(Azure.ResourceManager.Redis.Models.RedisNameAvailabilityContent redisNameAvailabilityContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Redis.Models.RedisOperationStatus> Get(string location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Redis.Models.RedisOperationStatus>> GetAsync(string location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Redis.RedisResource> GetRedis(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Redis.RedisResource> GetRedisAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Redis.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessPolicyAssignmentProvisioningState : System.IEquatable<Azure.ResourceManager.Redis.Models.AccessPolicyAssignmentProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessPolicyAssignmentProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Redis.Models.AccessPolicyAssignmentProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.AccessPolicyAssignmentProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.AccessPolicyAssignmentProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.AccessPolicyAssignmentProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.AccessPolicyAssignmentProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.AccessPolicyAssignmentProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Redis.Models.AccessPolicyAssignmentProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Redis.Models.AccessPolicyAssignmentProvisioningState left, Azure.ResourceManager.Redis.Models.AccessPolicyAssignmentProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.AccessPolicyAssignmentProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.AccessPolicyAssignmentProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Redis.Models.AccessPolicyAssignmentProvisioningState left, Azure.ResourceManager.Redis.Models.AccessPolicyAssignmentProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessPolicyProvisioningState : System.IEquatable<Azure.ResourceManager.Redis.Models.AccessPolicyProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessPolicyProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Redis.Models.AccessPolicyProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.AccessPolicyProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.AccessPolicyProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.AccessPolicyProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.AccessPolicyProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.AccessPolicyProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Redis.Models.AccessPolicyProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Redis.Models.AccessPolicyProvisioningState left, Azure.ResourceManager.Redis.Models.AccessPolicyProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.AccessPolicyProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.AccessPolicyProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Redis.Models.AccessPolicyProvisioningState left, Azure.ResourceManager.Redis.Models.AccessPolicyProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessPolicyType : System.IEquatable<Azure.ResourceManager.Redis.Models.AccessPolicyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessPolicyType(string value) { throw null; }
        public static Azure.ResourceManager.Redis.Models.AccessPolicyType BuiltIn { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.AccessPolicyType Custom { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Redis.Models.AccessPolicyType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Redis.Models.AccessPolicyType left, Azure.ResourceManager.Redis.Models.AccessPolicyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.AccessPolicyType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.AccessPolicyType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Redis.Models.AccessPolicyType left, Azure.ResourceManager.Redis.Models.AccessPolicyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmRedisModelFactory
    {
        public static Azure.ResourceManager.Redis.Models.ExportRdbContent ExportRdbContent(string format = null, string prefix = null, string container = null, string preferredDataArchiveAuthMethod = null, string storageSubscriptionId = null) { throw null; }
        public static Azure.ResourceManager.Redis.Models.ImportRdbContent ImportRdbContent(string format = null, System.Collections.Generic.IEnumerable<string> files = null, string preferredDataArchiveAuthMethod = null, string storageSubscriptionId = null) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisAccessKeys RedisAccessKeys(string primaryKey = null, string secondaryKey = null) { throw null; }
        public static Azure.ResourceManager.Redis.RedisCacheAccessPolicyAssignmentData RedisCacheAccessPolicyAssignmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Redis.Models.AccessPolicyAssignmentProvisioningState? provisioningState = default(Azure.ResourceManager.Redis.Models.AccessPolicyAssignmentProvisioningState?), System.Guid? objectId = default(System.Guid?), string objectIdAlias = null, string accessPolicyName = null) { throw null; }
        public static Azure.ResourceManager.Redis.RedisCacheAccessPolicyData RedisCacheAccessPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Redis.Models.AccessPolicyProvisioningState? provisioningState = default(Azure.ResourceManager.Redis.Models.AccessPolicyProvisioningState?), Azure.ResourceManager.Redis.Models.AccessPolicyType? type = default(Azure.ResourceManager.Redis.Models.AccessPolicyType?), string permissions = null) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisCommonConfiguration RedisCommonConfiguration(bool? isRdbBackupEnabled, string rdbBackupFrequency, int? rdbBackupMaxSnapshotCount, string rdbStorageConnectionString, bool? isAofBackupEnabled, string aofStorageConnectionString0, string aofStorageConnectionString1, string maxFragmentationMemoryReserved, string maxMemoryPolicy, string maxMemoryReserved, string maxMemoryDelta, string maxClients, string preferredDataArchiveAuthMethod, string preferredDataPersistenceAuthMethod, string zonalConfiguration, string authNotRequired, string storageSubscriptionId, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisCommonConfiguration RedisCommonConfiguration(bool? isRdbBackupEnabled, string rdbBackupFrequency, int? rdbBackupMaxSnapshotCount, string rdbStorageConnectionString, bool? isAofBackupEnabled, string aofStorageConnectionString0, string aofStorageConnectionString1, string maxFragmentationMemoryReserved, string maxMemoryPolicy, string maxMemoryReserved, string maxMemoryDelta, string maxClients, string preferredDataArchiveAuthMethod, string preferredDataPersistenceAuthMethod, string zonalConfiguration, string authNotRequired, string storageSubscriptionId, string isAadEnabled, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisCommonConfiguration RedisCommonConfiguration(bool? isRdbBackupEnabled = default(bool?), string rdbBackupFrequency = null, int? rdbBackupMaxSnapshotCount = default(int?), string rdbStorageConnectionString = null, bool? isAofBackupEnabled = default(bool?), string aofStorageConnectionString0 = null, string aofStorageConnectionString1 = null, string maxFragmentationMemoryReserved = null, string maxMemoryPolicy = null, string maxMemoryReserved = null, string maxMemoryDelta = null, string maxClients = null, string notifyKeyspaceEvents = null, string preferredDataArchiveAuthMethod = null, string preferredDataPersistenceAuthMethod = null, string zonalConfiguration = null, string authnotRequired = null, string storageSubscriptionId = null, string isAadEnabled = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisCreateOrUpdateContent RedisCreateOrUpdateContent(Azure.ResourceManager.Redis.Models.RedisCommonConfiguration redisConfiguration = null, string redisVersion = null, bool? enableNonSslPort = default(bool?), int? replicasPerMaster = default(int?), int? replicasPerPrimary = default(int?), System.Collections.Generic.IDictionary<string, string> tenantSettings = null, int? shardCount = default(int?), Azure.ResourceManager.Redis.Models.RedisTlsVersion? minimumTlsVersion = default(Azure.ResourceManager.Redis.Models.RedisTlsVersion?), Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess?), Azure.ResourceManager.Redis.Models.UpdateChannel? updateChannel = default(Azure.ResourceManager.Redis.Models.UpdateChannel?), bool? isAccessKeyAuthenticationDisabled = default(bool?), Azure.ResourceManager.Redis.Models.ZonalAllocationPolicy? zonalAllocationPolicy = default(Azure.ResourceManager.Redis.Models.ZonalAllocationPolicy?), Azure.ResourceManager.Redis.Models.RedisSku sku = null, string subnetId = null, string staticIP = null, System.Collections.Generic.IEnumerable<string> zones = null, string location = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisCreateOrUpdateContent RedisCreateOrUpdateContent(System.Collections.Generic.IEnumerable<string> zones, Azure.Core.AzureLocation location, System.Collections.Generic.IDictionary<string, string> tags, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.Redis.Models.RedisCommonConfiguration redisConfiguration, string redisVersion, bool? enableNonSslPort, int? replicasPerMaster, int? replicasPerPrimary, System.Collections.Generic.IDictionary<string, string> tenantSettings, int? shardCount, Azure.ResourceManager.Redis.Models.RedisTlsVersion? minimumTlsVersion, Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess? publicNetworkAccess, Azure.ResourceManager.Redis.Models.UpdateChannel? updateChannel, Azure.ResourceManager.Redis.Models.RedisSku sku, Azure.Core.ResourceIdentifier subnetId, System.Net.IPAddress staticIP) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisCreateOrUpdateContent RedisCreateOrUpdateContent(System.Collections.Generic.IEnumerable<string> zones, Azure.Core.AzureLocation location, System.Collections.Generic.IDictionary<string, string> tags, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.Redis.Models.RedisCommonConfiguration redisConfiguration, string redisVersion, bool? enableNonSslPort, int? replicasPerMaster, int? replicasPerPrimary, System.Collections.Generic.IDictionary<string, string> tenantSettings, int? shardCount, Azure.ResourceManager.Redis.Models.RedisTlsVersion? minimumTlsVersion, Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess? publicNetworkAccess, Azure.ResourceManager.Redis.Models.UpdateChannel? updateChannel, bool? isAccessKeyAuthenticationDisabled, Azure.ResourceManager.Redis.Models.RedisSku sku, Azure.Core.ResourceIdentifier subnetId, System.Net.IPAddress staticIP) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisCreateOrUpdateContent RedisCreateOrUpdateContent(System.Collections.Generic.IEnumerable<string> zones, Azure.Core.AzureLocation location, System.Collections.Generic.IDictionary<string, string> tags, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.Redis.Models.RedisCommonConfiguration redisConfiguration, string redisVersion, bool? enableNonSslPort, int? replicasPerMaster, int? replicasPerPrimary, System.Collections.Generic.IDictionary<string, string> tenantSettings, int? shardCount, Azure.ResourceManager.Redis.Models.RedisTlsVersion? minimumTlsVersion, Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess? publicNetworkAccess, Azure.ResourceManager.Redis.Models.UpdateChannel? updateChannel, bool? isAccessKeyAuthenticationDisabled, Azure.ResourceManager.Redis.Models.ZonalAllocationPolicy? zonalAllocationPolicy, Azure.ResourceManager.Redis.Models.RedisSku sku, Azure.Core.ResourceIdentifier subnetId, System.Net.IPAddress staticIP) { throw null; }
        public static Azure.ResourceManager.Redis.RedisData RedisData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Redis.Models.RedisCommonConfiguration redisConfiguration = null, string redisVersion = null, bool? enableNonSslPort = default(bool?), int? replicasPerMaster = default(int?), int? replicasPerPrimary = default(int?), System.Collections.Generic.IDictionary<string, string> tenantSettings = null, int? shardCount = default(int?), Azure.ResourceManager.Redis.Models.RedisTlsVersion? minimumTlsVersion = default(Azure.ResourceManager.Redis.Models.RedisTlsVersion?), Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess?), Azure.ResourceManager.Redis.Models.UpdateChannel? updateChannel = default(Azure.ResourceManager.Redis.Models.UpdateChannel?), bool? isAccessKeyAuthenticationDisabled = default(bool?), Azure.ResourceManager.Redis.Models.ZonalAllocationPolicy? zonalAllocationPolicy = default(Azure.ResourceManager.Redis.Models.ZonalAllocationPolicy?), Azure.ResourceManager.Redis.Models.RedisSku sku = null, string subnetId = null, string staticIP = null, Azure.ResourceManager.Redis.Models.RedisProvisioningState? provisioningState = default(Azure.ResourceManager.Redis.Models.RedisProvisioningState?), string hostName = null, int? port = default(int?), int? sslPort = default(int?), Azure.ResourceManager.Redis.Models.RedisAccessKeys accessKeys = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.Models.RedisLinkedServer> linkedServers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.Models.RedisInstanceDetails> instances = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData> privateEndpointConnections = null, System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Redis.RedisData RedisData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, System.Collections.Generic.IEnumerable<string> zones, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.Redis.Models.RedisCommonConfiguration redisConfiguration, string redisVersion, bool? enableNonSslPort, int? replicasPerMaster, int? replicasPerPrimary, System.Collections.Generic.IDictionary<string, string> tenantSettings, int? shardCount, Azure.ResourceManager.Redis.Models.RedisTlsVersion? minimumTlsVersion, Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess? publicNetworkAccess, Azure.ResourceManager.Redis.Models.RedisSku sku, Azure.Core.ResourceIdentifier subnetId, System.Net.IPAddress staticIP, Azure.ResourceManager.Redis.Models.RedisProvisioningState? provisioningState, string hostName, int? port, int? sslPort, Azure.ResourceManager.Redis.Models.RedisAccessKeys accessKeys, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> linkedServers, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.Models.RedisInstanceDetails> instances, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData> privateEndpointConnections) { throw null; }
        public static Azure.ResourceManager.Redis.RedisData RedisData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, System.Collections.Generic.IEnumerable<string> zones, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.Redis.Models.RedisCommonConfiguration redisConfiguration, string redisVersion, bool? enableNonSslPort, int? replicasPerMaster, int? replicasPerPrimary, System.Collections.Generic.IDictionary<string, string> tenantSettings, int? shardCount, Azure.ResourceManager.Redis.Models.RedisTlsVersion? minimumTlsVersion, Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess? publicNetworkAccess, Azure.ResourceManager.Redis.Models.UpdateChannel? updateChannel, Azure.ResourceManager.Redis.Models.RedisSku sku, Azure.Core.ResourceIdentifier subnetId, System.Net.IPAddress staticIP, Azure.ResourceManager.Redis.Models.RedisProvisioningState? provisioningState, string hostName, int? port, int? sslPort, Azure.ResourceManager.Redis.Models.RedisAccessKeys accessKeys, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> linkedServers, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.Models.RedisInstanceDetails> instances, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData> privateEndpointConnections) { throw null; }
        public static Azure.ResourceManager.Redis.RedisData RedisData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, System.Collections.Generic.IEnumerable<string> zones, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.Redis.Models.RedisCommonConfiguration redisConfiguration, string redisVersion, bool? enableNonSslPort, int? replicasPerMaster, int? replicasPerPrimary, System.Collections.Generic.IDictionary<string, string> tenantSettings, int? shardCount, Azure.ResourceManager.Redis.Models.RedisTlsVersion? minimumTlsVersion, Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess? publicNetworkAccess, Azure.ResourceManager.Redis.Models.UpdateChannel? updateChannel, bool? isAccessKeyAuthenticationDisabled, Azure.ResourceManager.Redis.Models.RedisSku sku, Azure.Core.ResourceIdentifier subnetId, System.Net.IPAddress staticIP, Azure.ResourceManager.Redis.Models.RedisProvisioningState? provisioningState, string hostName, int? port, int? sslPort, Azure.ResourceManager.Redis.Models.RedisAccessKeys accessKeys, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> linkedServers, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.Models.RedisInstanceDetails> instances, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData> privateEndpointConnections) { throw null; }
        public static Azure.ResourceManager.Redis.RedisData RedisData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, System.Collections.Generic.IEnumerable<string> zones, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.Redis.Models.RedisCommonConfiguration redisConfiguration, string redisVersion, bool? enableNonSslPort, int? replicasPerMaster, int? replicasPerPrimary, System.Collections.Generic.IDictionary<string, string> tenantSettings, int? shardCount, Azure.ResourceManager.Redis.Models.RedisTlsVersion? minimumTlsVersion, Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess? publicNetworkAccess, Azure.ResourceManager.Redis.Models.UpdateChannel? updateChannel, bool? isAccessKeyAuthenticationDisabled, Azure.ResourceManager.Redis.Models.ZonalAllocationPolicy? zonalAllocationPolicy, Azure.ResourceManager.Redis.Models.RedisSku sku, Azure.Core.ResourceIdentifier subnetId, System.Net.IPAddress staticIP, Azure.ResourceManager.Redis.Models.RedisProvisioningState? provisioningState, string hostName, int? port, int? sslPort, Azure.ResourceManager.Redis.Models.RedisAccessKeys accessKeys, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> linkedServers, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.Models.RedisInstanceDetails> instances, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData> privateEndpointConnections) { throw null; }
        public static Azure.ResourceManager.Redis.RedisFirewallRuleData RedisFirewallRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string startIP = null, string endIP = null) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisForceRebootResult RedisForceRebootResult(string message = null) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisInstanceDetails RedisInstanceDetails(int? sslPort = default(int?), int? nonSslPort = default(int?), string zone = null, int? shardId = default(int?), bool? isMaster = default(bool?), bool? isPrimary = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisLinkedServer RedisLinkedServer(string id = null) { throw null; }
        public static Azure.ResourceManager.Redis.RedisLinkedServerWithPropertyData RedisLinkedServerWithPropertyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier linkedRedisCacheId = null, Azure.Core.AzureLocation? linkedRedisCacheLocation = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Redis.Models.RedisLinkedServerRole? serverRole = default(Azure.ResourceManager.Redis.Models.RedisLinkedServerRole?), string geoReplicatedPrimaryHostName = null, string primaryHostName = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisNameAvailabilityContent RedisNameAvailabilityContent(string name = null, string type = null) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisOperationStatus RedisOperationStatus(Azure.Core.ResourceIdentifier id, string name, string status, float? percentComplete, System.DateTimeOffset? startOn, System.DateTimeOffset? endOn, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Models.OperationStatusResult> operations, Azure.ResponseError error, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> properties) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisOperationStatus RedisOperationStatus(System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> properties = null) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisPatch RedisPatch(Azure.ResourceManager.Redis.Models.RedisCommonConfiguration redisConfiguration = null, string redisVersion = null, bool? enableNonSslPort = default(bool?), int? replicasPerMaster = default(int?), int? replicasPerPrimary = default(int?), System.Collections.Generic.IDictionary<string, string> tenantSettings = null, int? shardCount = default(int?), Azure.ResourceManager.Redis.Models.RedisTlsVersion? minimumTlsVersion = default(Azure.ResourceManager.Redis.Models.RedisTlsVersion?), Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess?), Azure.ResourceManager.Redis.Models.UpdateChannel? updateChannel = default(Azure.ResourceManager.Redis.Models.UpdateChannel?), bool? isAccessKeyAuthenticationDisabled = default(bool?), Azure.ResourceManager.Redis.Models.ZonalAllocationPolicy? zonalAllocationPolicy = default(Azure.ResourceManager.Redis.Models.ZonalAllocationPolicy?), Azure.ResourceManager.Redis.Models.RedisSku sku = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Redis.RedisPatchScheduleData RedisPatchScheduleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.Models.RedisPatchScheduleSetting> scheduleEntries = null, string location = null) { throw null; }
        public static Azure.ResourceManager.Redis.RedisPatchScheduleData RedisPatchScheduleData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.Core.AzureLocation? location, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Redis.Models.RedisPatchScheduleSetting> scheduleEntries) { throw null; }
        public static Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData RedisPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.Core.ResourceIdentifier privateEndpointId, Azure.ResourceManager.Redis.Models.RedisPrivateLinkServiceConnectionState redisPrivateLinkServiceConnectionState, Azure.ResourceManager.Redis.Models.RedisPrivateEndpointConnectionProvisioningState? redisProvisioningState) { throw null; }
        public static Azure.ResourceManager.Redis.RedisPrivateEndpointConnectionData RedisPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.ResourceManager.Redis.Models.RedisPrivateLinkServiceConnectionState redisPrivateLinkServiceConnectionState = null, Azure.ResourceManager.Redis.Models.RedisPrivateEndpointConnectionProvisioningState? redisProvisioningState = default(Azure.ResourceManager.Redis.Models.RedisPrivateEndpointConnectionProvisioningState?), Azure.Core.ResourceIdentifier privateEndpointId = null) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisPrivateLinkResource RedisPrivateLinkResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Redis.Models.RedisPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisPrivateLinkResource RedisPrivateLinkResource(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string groupId, System.Collections.Generic.IEnumerable<string> requiredMembers, System.Collections.Generic.IEnumerable<string> requiredZoneNames) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisPrivateLinkResourceProperties RedisPrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisRebootParametersContent RedisRebootParametersContent(Azure.ResourceManager.Redis.Models.RedisRebootType? rebootType = default(Azure.ResourceManager.Redis.Models.RedisRebootType?), int? shardId = default(int?), System.Collections.Generic.IEnumerable<int> ports = null) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisRedisRebootParametersCreatOrUpdateContent RedisRedisRebootParametersCreatOrUpdateContent(Azure.Core.ResourceIdentifier linkedRedisCacheId = null, Azure.Core.AzureLocation? linkedRedisCacheLocation = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Redis.Models.RedisLinkedServerRole? serverRole = default(Azure.ResourceManager.Redis.Models.RedisLinkedServerRole?), string geoReplicatedPrimaryHostName = null, string primaryHostName = null) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisRegenerateKeyContent RedisRegenerateKeyContent(Azure.ResourceManager.Redis.Models.RedisRegenerateKeyType keyType = Azure.ResourceManager.Redis.Models.RedisRegenerateKeyType.Primary) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisUpgradeNotification RedisUpgradeNotification(string name = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.Collections.Generic.IReadOnlyDictionary<string, string> upsellNotification = null) { throw null; }
    }
    public partial class ExportRdbContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.ExportRdbContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.ExportRdbContent>
    {
        public ExportRdbContent(string prefix, string container) { }
        public string Container { get { throw null; } }
        public string Format { get { throw null; } set { } }
        public string PreferredDataArchiveAuthMethod { get { throw null; } set { } }
        public string Prefix { get { throw null; } }
        public string StorageSubscriptionId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Redis.Models.ExportRdbContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Redis.Models.ExportRdbContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Redis.Models.ExportRdbContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.ExportRdbContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.ExportRdbContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.Models.ExportRdbContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.ExportRdbContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.ExportRdbContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.ExportRdbContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImportRdbContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.ImportRdbContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.ImportRdbContent>
    {
        public ImportRdbContent(System.Collections.Generic.IEnumerable<string> files) { }
        public System.Collections.Generic.IList<string> Files { get { throw null; } }
        public string Format { get { throw null; } set { } }
        public string PreferredDataArchiveAuthMethod { get { throw null; } set { } }
        public string StorageSubscriptionId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Redis.Models.ImportRdbContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Redis.Models.ImportRdbContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Redis.Models.ImportRdbContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.ImportRdbContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.ImportRdbContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.Models.ImportRdbContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.ImportRdbContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.ImportRdbContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.ImportRdbContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RedisAccessKeys : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisAccessKeys>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisAccessKeys>
    {
        internal RedisAccessKeys() { }
        public string PrimaryKey { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
        protected virtual Azure.ResourceManager.Redis.Models.RedisAccessKeys JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Redis.Models.RedisAccessKeys PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Redis.Models.RedisAccessKeys System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisAccessKeys>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisAccessKeys>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.Models.RedisAccessKeys System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisAccessKeys>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisAccessKeys>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisAccessKeys>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RedisCommonConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisCommonConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisCommonConfiguration>
    {
        public RedisCommonConfiguration() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string AofStorageConnectionString0 { get { throw null; } set { } }
        public string AofStorageConnectionString1 { get { throw null; } set { } }
        public string AuthnotRequired { get { throw null; } set { } }
        public string IsAadEnabled { get { throw null; } set { } }
        public bool? IsAofBackupEnabled { get { throw null; } set { } }
        public bool? IsRdbBackupEnabled { get { throw null; } set { } }
        public string MaxClients { get { throw null; } }
        public string MaxFragmentationMemoryReserved { get { throw null; } set { } }
        public string MaxMemoryDelta { get { throw null; } set { } }
        public string MaxMemoryPolicy { get { throw null; } set { } }
        public string MaxMemoryReserved { get { throw null; } set { } }
        public string NotifyKeyspaceEvents { get { throw null; } set { } }
        public string PreferredDataArchiveAuthMethod { get { throw null; } }
        public string PreferredDataPersistenceAuthMethod { get { throw null; } set { } }
        public string RdbBackupFrequency { get { throw null; } set { } }
        public int? RdbBackupMaxSnapshotCount { get { throw null; } set { } }
        public string RdbStorageConnectionString { get { throw null; } set { } }
        public string StorageSubscriptionId { get { throw null; } set { } }
        public string ZonalConfiguration { get { throw null; } }
        protected virtual Azure.ResourceManager.Redis.Models.RedisCommonConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Redis.Models.RedisCommonConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Redis.Models.RedisCommonConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisCommonConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisCommonConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.Models.RedisCommonConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisCommonConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisCommonConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisCommonConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RedisCreateOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisCreateOrUpdateContent>
    {
        public RedisCreateOrUpdateContent(Azure.ResourceManager.Redis.Models.RedisSku sku, string location) { }
        public bool? EnableNonSslPort { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? IsAccessKeyAuthenticationDisabled { get { throw null; } }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.RedisTlsVersion? MinimumTlsVersion { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess? PublicNetworkAccess { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.RedisCommonConfiguration RedisConfiguration { get { throw null; } }
        public string RedisVersion { get { throw null; } }
        public int? ReplicasPerMaster { get { throw null; } }
        public int? ReplicasPerPrimary { get { throw null; } }
        public int? ShardCount { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.RedisSku Sku { get { throw null; } }
        public string StaticIP { get { throw null; } }
        public string SubnetId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> TenantSettings { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.UpdateChannel? UpdateChannel { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.ZonalAllocationPolicy? ZonalAllocationPolicy { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected virtual Azure.ResourceManager.Redis.Models.RedisCreateOrUpdateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Redis.Models.RedisCreateOrUpdateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Redis.Models.RedisCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.Models.RedisCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum RedisDayOfWeek
    {
        Monday = 0,
        Tuesday = 1,
        Wednesday = 2,
        Thursday = 3,
        Friday = 4,
        Saturday = 5,
        Sunday = 6,
        Everyday = 7,
        Weekend = 8,
    }
    public partial class RedisForceRebootResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisForceRebootResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisForceRebootResult>
    {
        internal RedisForceRebootResult() { }
        public string Message { get { throw null; } }
        protected virtual Azure.ResourceManager.Redis.Models.RedisForceRebootResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Redis.Models.RedisForceRebootResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Redis.Models.RedisForceRebootResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisForceRebootResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisForceRebootResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.Models.RedisForceRebootResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisForceRebootResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisForceRebootResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisForceRebootResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RedisInstanceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisInstanceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisInstanceDetails>
    {
        internal RedisInstanceDetails() { }
        public bool? IsMaster { get { throw null; } }
        public bool? IsPrimary { get { throw null; } }
        public int? NonSslPort { get { throw null; } }
        public int? ShardId { get { throw null; } }
        public int? SslPort { get { throw null; } }
        public string Zone { get { throw null; } }
        protected virtual Azure.ResourceManager.Redis.Models.RedisInstanceDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Redis.Models.RedisInstanceDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Redis.Models.RedisInstanceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisInstanceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisInstanceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.Models.RedisInstanceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisInstanceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisInstanceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisInstanceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RedisLinkedServer : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisLinkedServer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisLinkedServer>
    {
        internal RedisLinkedServer() { }
        public string Id { get { throw null; } }
        protected virtual Azure.ResourceManager.Redis.Models.RedisLinkedServer JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Redis.Models.RedisLinkedServer PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Redis.Models.RedisLinkedServer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisLinkedServer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisLinkedServer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.Models.RedisLinkedServer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisLinkedServer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisLinkedServer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisLinkedServer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum RedisLinkedServerRole
    {
        Primary = 0,
        Secondary = 1,
    }
    public partial class RedisNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisNameAvailabilityContent>
    {
        public RedisNameAvailabilityContent(string name, string type) { }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.Redis.Models.RedisNameAvailabilityContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Redis.Models.RedisNameAvailabilityContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Redis.Models.RedisNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.Models.RedisNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RedisOperationStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisOperationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisOperationStatus>
    {
        internal RedisOperationStatus() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Redis.Models.RedisOperationStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Redis.Models.RedisOperationStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Redis.Models.RedisOperationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisOperationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisOperationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.Models.RedisOperationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisOperationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisOperationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisOperationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RedisPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisPatch>
    {
        public RedisPatch() { }
        public bool? EnableNonSslPort { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? IsAccessKeyAuthenticationDisabled { get { throw null; } set { } }
        public Azure.ResourceManager.Redis.Models.RedisTlsVersion? MinimumTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Redis.Models.RedisCommonConfiguration RedisConfiguration { get { throw null; } set { } }
        public string RedisVersion { get { throw null; } set { } }
        public int? ReplicasPerMaster { get { throw null; } set { } }
        public int? ReplicasPerPrimary { get { throw null; } set { } }
        public int? ShardCount { get { throw null; } set { } }
        public Azure.ResourceManager.Redis.Models.RedisSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> TenantSettings { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.UpdateChannel? UpdateChannel { get { throw null; } set { } }
        public Azure.ResourceManager.Redis.Models.ZonalAllocationPolicy? ZonalAllocationPolicy { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Redis.Models.RedisPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Redis.Models.RedisPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Redis.Models.RedisPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.Models.RedisPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisPatchScheduleDefaultName : System.IEquatable<Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisPatchScheduleDefaultName(string value) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName left, Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName left, Azure.ResourceManager.Redis.Models.RedisPatchScheduleDefaultName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RedisPatchScheduleSetting : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisPatchScheduleSetting>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisPatchScheduleSetting>
    {
        public RedisPatchScheduleSetting(Azure.ResourceManager.Redis.Models.RedisDayOfWeek dayOfWeek, int startHourUtc) { }
        public Azure.ResourceManager.Redis.Models.RedisDayOfWeek DayOfWeek { get { throw null; } set { } }
        public System.TimeSpan? MaintenanceWindow { get { throw null; } set { } }
        public int StartHourUtc { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Redis.Models.RedisPatchScheduleSetting JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Redis.Models.RedisPatchScheduleSetting PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Redis.Models.RedisPatchScheduleSetting System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisPatchScheduleSetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisPatchScheduleSetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.Models.RedisPatchScheduleSetting System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisPatchScheduleSetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisPatchScheduleSetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisPatchScheduleSetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.Redis.Models.RedisPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Redis.Models.RedisPrivateEndpointConnectionProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Redis.Models.RedisPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Redis.Models.RedisPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.RedisPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.RedisPrivateEndpointConnectionProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Redis.Models.RedisPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Redis.Models.RedisPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.Redis.Models.RedisPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Redis.Models.RedisPrivateEndpointServiceConnectionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Redis.Models.RedisPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Redis.Models.RedisPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.RedisPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.RedisPrivateEndpointServiceConnectionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Redis.Models.RedisPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Redis.Models.RedisPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RedisPrivateLinkResource : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisPrivateLinkResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisPrivateLinkResource>
    {
        internal RedisPrivateLinkResource() { }
        public Azure.ResourceManager.Redis.Models.RedisPrivateLinkResourceProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Redis.Models.RedisPrivateLinkResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisPrivateLinkResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisPrivateLinkResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.Models.RedisPrivateLinkResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisPrivateLinkResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisPrivateLinkResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisPrivateLinkResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RedisPrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisPrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisPrivateLinkResourceProperties>
    {
        internal RedisPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        protected virtual Azure.ResourceManager.Redis.Models.RedisPrivateLinkResourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Redis.Models.RedisPrivateLinkResourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Redis.Models.RedisPrivateLinkResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisPrivateLinkResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisPrivateLinkResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.Models.RedisPrivateLinkResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisPrivateLinkResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisPrivateLinkResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisPrivateLinkResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RedisPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisPrivateLinkServiceConnectionState>
    {
        public RedisPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Redis.Models.RedisPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Redis.Models.RedisPrivateLinkServiceConnectionState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Redis.Models.RedisPrivateLinkServiceConnectionState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Redis.Models.RedisPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.Models.RedisPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisProvisioningState : System.IEquatable<Azure.ResourceManager.Redis.Models.RedisProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisProvisioningState ConfiguringAAD { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisProvisioningState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisProvisioningState Linking { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisProvisioningState RecoveringScaleFailure { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisProvisioningState Scaling { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisProvisioningState Unlinking { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisProvisioningState Unprovisioning { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Redis.Models.RedisProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Redis.Models.RedisProvisioningState left, Azure.ResourceManager.Redis.Models.RedisProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.RedisProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.RedisProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Redis.Models.RedisProvisioningState left, Azure.ResourceManager.Redis.Models.RedisProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess left, Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess left, Azure.ResourceManager.Redis.Models.RedisPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RedisRebootParametersContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisRebootParametersContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisRebootParametersContent>
    {
        public RedisRebootParametersContent() { }
        public System.Collections.Generic.IList<int> Ports { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.RedisRebootType? RebootType { get { throw null; } set { } }
        public int? ShardId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Redis.Models.RedisRebootParametersContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Redis.Models.RedisRebootParametersContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Redis.Models.RedisRebootParametersContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisRebootParametersContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisRebootParametersContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.Models.RedisRebootParametersContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisRebootParametersContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisRebootParametersContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisRebootParametersContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisRebootType : System.IEquatable<Azure.ResourceManager.Redis.Models.RedisRebootType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisRebootType(string value) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisRebootType AllNodes { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisRebootType PrimaryNode { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisRebootType SecondaryNode { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Redis.Models.RedisRebootType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Redis.Models.RedisRebootType left, Azure.ResourceManager.Redis.Models.RedisRebootType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.RedisRebootType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.RedisRebootType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Redis.Models.RedisRebootType left, Azure.ResourceManager.Redis.Models.RedisRebootType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RedisRedisRebootParametersCreatOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisRedisRebootParametersCreatOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisRedisRebootParametersCreatOrUpdateContent>
    {
        public RedisRedisRebootParametersCreatOrUpdateContent(Azure.Core.ResourceIdentifier linkedRedisCacheId, Azure.Core.AzureLocation linkedRedisCacheLocation, Azure.ResourceManager.Redis.Models.RedisLinkedServerRole serverRole) { }
        public string GeoReplicatedPrimaryHostName { get { throw null; } }
        public Azure.Core.ResourceIdentifier LinkedRedisCacheId { get { throw null; } }
        public Azure.Core.AzureLocation LinkedRedisCacheLocation { get { throw null; } }
        public string PrimaryHostName { get { throw null; } }
        public Azure.ResourceManager.Redis.Models.RedisLinkedServerRole ServerRole { get { throw null; } }
        protected virtual Azure.ResourceManager.Redis.Models.RedisRedisRebootParametersCreatOrUpdateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Redis.Models.RedisRedisRebootParametersCreatOrUpdateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Redis.Models.RedisRedisRebootParametersCreatOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisRedisRebootParametersCreatOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisRedisRebootParametersCreatOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.Models.RedisRedisRebootParametersCreatOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisRedisRebootParametersCreatOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisRedisRebootParametersCreatOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisRedisRebootParametersCreatOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RedisRegenerateKeyContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisRegenerateKeyContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisRegenerateKeyContent>
    {
        public RedisRegenerateKeyContent(Azure.ResourceManager.Redis.Models.RedisRegenerateKeyType keyType) { }
        public Azure.ResourceManager.Redis.Models.RedisRegenerateKeyType KeyType { get { throw null; } }
        protected virtual Azure.ResourceManager.Redis.Models.RedisRegenerateKeyContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Redis.Models.RedisRegenerateKeyContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Redis.Models.RedisRegenerateKeyContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisRegenerateKeyContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisRegenerateKeyContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.Models.RedisRegenerateKeyContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisRegenerateKeyContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisRegenerateKeyContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisRegenerateKeyContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum RedisRegenerateKeyType
    {
        Primary = 0,
        Secondary = 1,
    }
    public partial class RedisSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisSku>
    {
        public RedisSku(Azure.ResourceManager.Redis.Models.RedisSkuName name, Azure.ResourceManager.Redis.Models.RedisSkuFamily family, int capacity) { }
        public int Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.Redis.Models.RedisSkuFamily Family { get { throw null; } set { } }
        public Azure.ResourceManager.Redis.Models.RedisSkuName Name { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Redis.Models.RedisSku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Redis.Models.RedisSku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Redis.Models.RedisSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.Models.RedisSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisSkuFamily : System.IEquatable<Azure.ResourceManager.Redis.Models.RedisSkuFamily>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisSkuFamily(string value) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisSkuFamily BasicOrStandard { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisSkuFamily Premium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Redis.Models.RedisSkuFamily other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Redis.Models.RedisSkuFamily left, Azure.ResourceManager.Redis.Models.RedisSkuFamily right) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.RedisSkuFamily (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.RedisSkuFamily? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Redis.Models.RedisSkuFamily left, Azure.ResourceManager.Redis.Models.RedisSkuFamily right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisSkuName : System.IEquatable<Azure.ResourceManager.Redis.Models.RedisSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisSkuName(string value) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisSkuName Basic { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisSkuName Premium { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisSkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Redis.Models.RedisSkuName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Redis.Models.RedisSkuName left, Azure.ResourceManager.Redis.Models.RedisSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.RedisSkuName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.RedisSkuName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Redis.Models.RedisSkuName left, Azure.ResourceManager.Redis.Models.RedisSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedisTlsVersion : System.IEquatable<Azure.ResourceManager.Redis.Models.RedisTlsVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedisTlsVersion(string value) { throw null; }
        public static Azure.ResourceManager.Redis.Models.RedisTlsVersion Tls1_0 { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisTlsVersion Tls1_1 { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisTlsVersion Tls1_2 { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisTlsVersion _10 { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisTlsVersion _11 { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.RedisTlsVersion _12 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Redis.Models.RedisTlsVersion other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Redis.Models.RedisTlsVersion left, Azure.ResourceManager.Redis.Models.RedisTlsVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.RedisTlsVersion (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.RedisTlsVersion? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Redis.Models.RedisTlsVersion left, Azure.ResourceManager.Redis.Models.RedisTlsVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RedisUpgradeNotification : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisUpgradeNotification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisUpgradeNotification>
    {
        internal RedisUpgradeNotification() { }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> UpsellNotification { get { throw null; } }
        protected virtual Azure.ResourceManager.Redis.Models.RedisUpgradeNotification JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Redis.Models.RedisUpgradeNotification PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Redis.Models.RedisUpgradeNotification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisUpgradeNotification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Redis.Models.RedisUpgradeNotification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Redis.Models.RedisUpgradeNotification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisUpgradeNotification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisUpgradeNotification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Redis.Models.RedisUpgradeNotification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpdateChannel : System.IEquatable<Azure.ResourceManager.Redis.Models.UpdateChannel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpdateChannel(string value) { throw null; }
        public static Azure.ResourceManager.Redis.Models.UpdateChannel Preview { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.UpdateChannel Stable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Redis.Models.UpdateChannel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Redis.Models.UpdateChannel left, Azure.ResourceManager.Redis.Models.UpdateChannel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.UpdateChannel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.UpdateChannel? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Redis.Models.UpdateChannel left, Azure.ResourceManager.Redis.Models.UpdateChannel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ZonalAllocationPolicy : System.IEquatable<Azure.ResourceManager.Redis.Models.ZonalAllocationPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ZonalAllocationPolicy(string value) { throw null; }
        public static Azure.ResourceManager.Redis.Models.ZonalAllocationPolicy Automatic { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.ZonalAllocationPolicy NoZones { get { throw null; } }
        public static Azure.ResourceManager.Redis.Models.ZonalAllocationPolicy UserDefined { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Redis.Models.ZonalAllocationPolicy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Redis.Models.ZonalAllocationPolicy left, Azure.ResourceManager.Redis.Models.ZonalAllocationPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.ZonalAllocationPolicy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Redis.Models.ZonalAllocationPolicy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Redis.Models.ZonalAllocationPolicy left, Azure.ResourceManager.Redis.Models.ZonalAllocationPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
}
