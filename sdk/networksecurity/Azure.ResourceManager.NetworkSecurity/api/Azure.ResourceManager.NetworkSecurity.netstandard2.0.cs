namespace Azure.ResourceManager.NetworkSecurity
{
    public partial class AzureResourceManagerNetworkSecurityContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerNetworkSecurityContext() { }
        public static Azure.ResourceManager.NetworkSecurity.AzureResourceManagerNetworkSecurityContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class NetworkSecurityExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> Get(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource> GetNeuroShield(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string neuroShieldName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource>> GetNeuroShieldAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string neuroShieldName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource GetNeuroShieldFindingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource GetNeuroShieldMitigationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource GetNeuroShieldProtectedResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.NeuroShieldResource GetNeuroShieldResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.NeuroShieldCollection GetNeuroShields(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource> GetNeuroShields(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? maxCount = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource> GetNeuroShieldsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? maxCount = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryResource GetNeuroShieldSummaryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class NeuroShieldCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource>, System.Collections.IEnumerable
    {
        protected NeuroShieldCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string neuroShieldName, Azure.ResourceManager.NetworkSecurity.NeuroShieldData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string neuroShieldName, Azure.ResourceManager.NetworkSecurity.NeuroShieldData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string neuroShieldName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string neuroShieldName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource> Get(string neuroShieldName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource> GetAll(int? maxCount = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource> GetAllAsync(int? maxCount = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource>> GetAsync(string neuroShieldName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource> GetIfExists(string neuroShieldName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource>> GetIfExistsAsync(string neuroShieldName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NeuroShieldData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldData>
    {
        public NeuroShieldData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProperties properties) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeuroShieldFindingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource>, System.Collections.IEnumerable
    {
        protected NeuroShieldFindingCollection() { }
        public virtual Azure.Response<bool> Exists(string findingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string findingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource> Get(string findingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource> GetAll(int? maxCount = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource> GetAllAsync(int? maxCount = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource>> GetAsync(string findingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource> GetIfExists(string findingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource>> GetIfExistsAsync(string findingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NeuroShieldFindingData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData>
    {
        internal NeuroShieldFindingData() { }
        public Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeuroShieldFindingResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NeuroShieldFindingResource() { }
        public virtual Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string neuroShieldName, string protectedResourceName, string findingId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationActionResult> Mitigate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationActionResult>> MitigateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationActionResult> Rollback(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationActionResult>> RollbackAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeuroShieldMitigationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource>, System.Collections.IEnumerable
    {
        protected NeuroShieldMitigationCollection() { }
        public virtual Azure.Response<bool> Exists(string mitigationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string mitigationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource> Get(string mitigationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource> GetAll(int? maxCount = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource> GetAllAsync(int? maxCount = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource>> GetAsync(string mitigationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource> GetIfExists(string mitigationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource>> GetIfExistsAsync(string mitigationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NeuroShieldMitigationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData>
    {
        internal NeuroShieldMitigationData() { }
        public Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeuroShieldMitigationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NeuroShieldMitigationResource() { }
        public virtual Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string neuroShieldName, string protectedResourceName, string mitigationId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource> Execute(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource>> ExecuteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource> Rollback(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource>> RollbackAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeuroShieldProtectedResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NeuroShieldProtectedResource() { }
        public virtual Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string neuroShieldName, string protectedResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource> GetNeuroShieldFinding(string findingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource>> GetNeuroShieldFindingAsync(string findingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingCollection GetNeuroShieldFindings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource> GetNeuroShieldMitigation(string mitigationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource>> GetNeuroShieldMitigationAsync(string mitigationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationCollection GetNeuroShieldMitigations() { throw null; }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestResult> TriggerInventoryUpload(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestResult>> TriggerInventoryUploadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NeuroShieldProtectedResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource>, System.Collections.IEnumerable
    {
        protected NeuroShieldProtectedResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string protectedResourceName, Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string protectedResourceName, Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string protectedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string protectedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource> Get(string protectedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource> GetAll(int? maxCount = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource> GetAllAsync(int? maxCount = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource>> GetAsync(string protectedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource> GetIfExists(string protectedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource>> GetIfExistsAsync(string protectedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NeuroShieldProtectedResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData>
    {
        public NeuroShieldProtectedResourceData(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceProperties properties) { }
        public Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeuroShieldResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NeuroShieldResource() { }
        public virtual Azure.ResourceManager.NetworkSecurity.NeuroShieldData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string neuroShieldName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource> GetNeuroShieldFindings(int? maxCount = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource> GetNeuroShieldFindingsAsync(int? maxCount = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource> GetNeuroShieldMitigations(int? maxCount = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource> GetNeuroShieldMitigationsAsync(int? maxCount = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource> GetNeuroShieldProtectedResource(string protectedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource>> GetNeuroShieldProtectedResourceAsync(string protectedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceCollection GetNeuroShieldProtectedResources() { throw null; }
        public virtual Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryResource GetNeuroShieldSummary() { throw null; }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource> Update(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatch patch, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource>> UpdateAsync(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatch patch, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NeuroShieldSummaryData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData>
    {
        internal NeuroShieldSummaryData() { }
        public Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSummaryProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeuroShieldSummaryResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NeuroShieldSummaryResource() { }
        public virtual Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string neuroShieldName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.NetworkSecurity.Mocking
{
    public partial class MockableNetworkSecurityArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableNetworkSecurityArmClient() { }
        public virtual Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource GetNeuroShieldFindingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource GetNeuroShieldMitigationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource GetNeuroShieldProtectedResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetworkSecurity.NeuroShieldResource GetNeuroShieldResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryResource GetNeuroShieldSummaryResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableNetworkSecurityResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableNetworkSecurityResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource> GetNeuroShield(string neuroShieldName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource>> GetNeuroShieldAsync(string neuroShieldName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkSecurity.NeuroShieldCollection GetNeuroShields() { throw null; }
    }
    public partial class MockableNetworkSecuritySubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableNetworkSecuritySubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> Get(Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetAsync(Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource> GetNeuroShields(int? maxCount = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource> GetNeuroShieldsAsync(int? maxCount = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.NetworkSecurity.Models
{
    public static partial class ArmNetworkSecurityModelFactory
    {
        public static Azure.ResourceManager.NetworkSecurity.NeuroShieldData NeuroShieldData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProperties properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData NeuroShieldFindingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingProperties NeuroShieldFindingProperties(Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState?), string cveId = null, Azure.Core.ResourceIdentifier virtualMachineArmId = null, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold severity = default(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold), string description = null, string reason = null, System.DateTimeOffset? detectedOn = default(System.DateTimeOffset?), Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus status = default(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus)) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestMetadata NeuroShieldInventoryUploadRequestMetadata(string requestId = null, System.DateTimeOffset requestedOn = default(System.DateTimeOffset), System.DateTimeOffset expiresOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestResult NeuroShieldInventoryUploadRequestResult(string requestId = null, System.DateTimeOffset requestedOn = default(System.DateTimeOffset), System.DateTimeOffset expiresOn = default(System.DateTimeOffset), bool deduplicated = false) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationActionResult NeuroShieldMitigationActionResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData> value = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData NeuroShieldMitigationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationProperties NeuroShieldMitigationProperties(Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState?), Azure.Core.ResourceIdentifier findingId = null, string cveId = null, Azure.Core.ResourceIdentifier virtualMachineArmId = null, int rank = 0, string commandsSummary = null, bool isRollbackable = false, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus status = default(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus), string statusDetails = null, System.DateTimeOffset? appliedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatch NeuroShieldPatch(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchTags tags = null, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchProperties NeuroShieldPatchProperties(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode? responseMode = default(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode?), Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold? severityThreshold = default(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold?), string description = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchTags NeuroShieldPatchTags(System.Collections.Generic.IDictionary<string, string> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProperties NeuroShieldProperties(Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield? provisioningState = default(Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield?), System.Guid? resourceGuid = default(System.Guid?), Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode responseMode = default(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode), Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold? severityThreshold = default(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold?), string description = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData NeuroShieldProtectedResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceIdentity NeuroShieldProtectedResourceIdentity(System.Guid? principalId = default(System.Guid?), System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.Models.ManagedServiceIdentityType type = default(Azure.ResourceManager.Models.ManagedServiceIdentityType), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceUserAssignedIdentity> userAssignedIdentities = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceProperties NeuroShieldProtectedResourceProperties(Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield? provisioningState = default(Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield?), Azure.Core.ResourceIdentifier targetResourceId = null, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceIdentity targetIdentity = null, System.DateTimeOffset? agentHealthLastSeenOn = default(System.DateTimeOffset?), Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestMetadata inventoryUploadRequest = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceUserAssignedIdentity NeuroShieldProtectedResourceUserAssignedIdentity(System.Guid? principalId = default(System.Guid?), System.Guid? clientId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData NeuroShieldSummaryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSummaryProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSummaryProperties NeuroShieldSummaryProperties(Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState?), int protectedCount = 0, int scannedProtectedCount = 0, int activeFindings = 0, int criticalFindings = 0, int highFindings = 0, int mediumFindings = 0, int lowFindings = 0, int unreachableFindings = 0, int awaitingApprovalMitigations = 0, int queuedMitigations = 0, int inProgressMitigations = 0, int succeededMitigations = 0, int failedMitigations = 0, int rollbackInProgressMitigations = 0) { throw null; }
    }
    public partial class NeuroShieldFindingProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingProperties>
    {
        internal NeuroShieldFindingProperties() { }
        public string CveId { get { throw null; } }
        public string Description { get { throw null; } }
        public System.DateTimeOffset? DetectedOn { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold Severity { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus Status { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualMachineArmId { get { throw null; } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NeuroShieldFindingStatus : System.IEquatable<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NeuroShieldFindingStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus Active { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus AwaitingApproval { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus Mitigated { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus MitigationInProgress { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus MitigationsExhausted { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus Skipped { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus Unreachable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus left, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus left, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NeuroShieldInventoryUploadRequestMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestMetadata>
    {
        internal NeuroShieldInventoryUploadRequestMetadata() { }
        public System.DateTimeOffset ExpiresOn { get { throw null; } }
        public System.DateTimeOffset RequestedOn { get { throw null; } }
        public string RequestId { get { throw null; } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeuroShieldInventoryUploadRequestResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestResult>
    {
        internal NeuroShieldInventoryUploadRequestResult() { }
        public bool Deduplicated { get { throw null; } }
        public System.DateTimeOffset ExpiresOn { get { throw null; } }
        public System.DateTimeOffset RequestedOn { get { throw null; } }
        public string RequestId { get { throw null; } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeuroShieldMitigationActionResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationActionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationActionResult>
    {
        internal NeuroShieldMitigationActionResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationActionResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationActionResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationActionResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationActionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationActionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationActionResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationActionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationActionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationActionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeuroShieldMitigationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationProperties>
    {
        internal NeuroShieldMitigationProperties() { }
        public System.DateTimeOffset? AppliedOn { get { throw null; } }
        public string CommandsSummary { get { throw null; } }
        public string CveId { get { throw null; } }
        public Azure.Core.ResourceIdentifier FindingId { get { throw null; } }
        public bool IsRollbackable { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public int Rank { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus Status { get { throw null; } }
        public string StatusDetails { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualMachineArmId { get { throw null; } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NeuroShieldMitigationStatus : System.IEquatable<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NeuroShieldMitigationStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus AwaitingApproval { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus Queued { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus RollbackFailed { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus RollbackInProgress { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus RolledBack { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus Skipped { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus left, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus left, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NeuroShieldPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatch>
    {
        public NeuroShieldPatch() { }
        public Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchTags Tags { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeuroShieldPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchProperties>
    {
        public NeuroShieldPatchProperties() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode? ResponseMode { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold? SeverityThreshold { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeuroShieldPatchTags : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchTags>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchTags>
    {
        public NeuroShieldPatchTags() { }
        public System.Collections.Generic.IDictionary<string, string> AdditionalProperties { get { throw null; } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchTags JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchTags PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchTags System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchTags>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchTags>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchTags System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchTags>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchTags>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchTags>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeuroShieldProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProperties>
    {
        public NeuroShieldProperties(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode responseMode) { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield? ProvisioningState { get { throw null; } }
        public System.Guid? ResourceGuid { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode ResponseMode { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold? SeverityThreshold { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeuroShieldProtectedResourceIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceIdentity>
    {
        public NeuroShieldProtectedResourceIdentity(Azure.ResourceManager.Models.ManagedServiceIdentityType type) { }
        public System.Guid? PrincipalId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentityType Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceUserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeuroShieldProtectedResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceProperties>
    {
        public NeuroShieldProtectedResourceProperties(Azure.Core.ResourceIdentifier targetResourceId) { }
        public System.DateTimeOffset? AgentHealthLastSeenOn { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestMetadata InventoryUploadRequest { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceIdentity TargetIdentity { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeuroShieldProtectedResourceUserAssignedIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceUserAssignedIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceUserAssignedIdentity>
    {
        public NeuroShieldProtectedResourceUserAssignedIdentity() { }
        public System.Guid? ClientId { get { throw null; } set { } }
        public System.Guid? PrincipalId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceUserAssignedIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceUserAssignedIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceUserAssignedIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceUserAssignedIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceUserAssignedIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceUserAssignedIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceUserAssignedIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceUserAssignedIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceUserAssignedIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NeuroShieldResponseMode : System.IEquatable<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NeuroShieldResponseMode(string value) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode Auto { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode left, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode left, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NeuroShieldSeverityThreshold : System.IEquatable<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NeuroShieldSeverityThreshold(string value) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold Critical { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold High { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold Low { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold left, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold left, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NeuroShieldSummaryProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSummaryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSummaryProperties>
    {
        internal NeuroShieldSummaryProperties() { }
        public int ActiveFindings { get { throw null; } }
        public int AwaitingApprovalMitigations { get { throw null; } }
        public int CriticalFindings { get { throw null; } }
        public int FailedMitigations { get { throw null; } }
        public int HighFindings { get { throw null; } }
        public int InProgressMitigations { get { throw null; } }
        public int LowFindings { get { throw null; } }
        public int MediumFindings { get { throw null; } }
        public int ProtectedCount { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public int QueuedMitigations { get { throw null; } }
        public int RollbackInProgressMitigations { get { throw null; } }
        public int ScannedProtectedCount { get { throw null; } }
        public int SucceededMitigations { get { throw null; } }
        public int UnreachableFindings { get { throw null; } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSummaryProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSummaryProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSummaryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSummaryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSummaryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSummaryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSummaryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSummaryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSummaryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningStateNeuroShield : System.IEquatable<Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningStateNeuroShield(string value) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield Canceled { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield Creating { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield Deleting { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield Succeeded { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield left, Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield left, Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProvisioningState : System.IEquatable<Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState left, Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState left, Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
