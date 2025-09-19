namespace Azure.ResourceManager.Quota
{
    public partial class AzureResourceManagerQuotaContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerQuotaContext() { }
        public static Azure.ResourceManager.Quota.AzureResourceManagerQuotaContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class CurrentQuotaLimitBaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource>, System.Collections.IEnumerable
    {
        protected CurrentQuotaLimitBaseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.Quota.CurrentQuotaLimitBaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.Quota.CurrentQuotaLimitBaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource> GetIfExists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource>> GetIfExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CurrentQuotaLimitBaseData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseData>
    {
        public CurrentQuotaLimitBaseData() { }
        public Azure.ResourceManager.Quota.Models.QuotaProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.CurrentQuotaLimitBaseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.CurrentQuotaLimitBaseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CurrentQuotaLimitBaseResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CurrentQuotaLimitBaseResource() { }
        public virtual Azure.ResourceManager.Quota.CurrentQuotaLimitBaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string resourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Quota.CurrentQuotaLimitBaseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.CurrentQuotaLimitBaseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Quota.CurrentQuotaLimitBaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Quota.CurrentQuotaLimitBaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CurrentUsagesBaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Quota.CurrentUsagesBaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.CurrentUsagesBaseResource>, System.Collections.IEnumerable
    {
        protected CurrentUsagesBaseCollection() { }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.CurrentUsagesBaseResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Quota.CurrentUsagesBaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Quota.CurrentUsagesBaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.CurrentUsagesBaseResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Quota.CurrentUsagesBaseResource> GetIfExists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Quota.CurrentUsagesBaseResource>> GetIfExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Quota.CurrentUsagesBaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Quota.CurrentUsagesBaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Quota.CurrentUsagesBaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.CurrentUsagesBaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CurrentUsagesBaseData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.CurrentUsagesBaseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.CurrentUsagesBaseData>
    {
        internal CurrentUsagesBaseData() { }
        public Azure.ResourceManager.Quota.Models.QuotaUsagesProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.CurrentUsagesBaseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.CurrentUsagesBaseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.CurrentUsagesBaseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.CurrentUsagesBaseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.CurrentUsagesBaseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.CurrentUsagesBaseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.CurrentUsagesBaseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CurrentUsagesBaseResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.CurrentUsagesBaseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.CurrentUsagesBaseData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CurrentUsagesBaseResource() { }
        public virtual Azure.ResourceManager.Quota.CurrentUsagesBaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string resourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.CurrentUsagesBaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.CurrentUsagesBaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Quota.CurrentUsagesBaseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.CurrentUsagesBaseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.CurrentUsagesBaseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.CurrentUsagesBaseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.CurrentUsagesBaseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.CurrentUsagesBaseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.CurrentUsagesBaseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotaEntityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Quota.GroupQuotaEntityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.GroupQuotaEntityResource>, System.Collections.IEnumerable
    {
        protected GroupQuotaEntityCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.GroupQuotaEntityResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string groupQuotaName, Azure.ResourceManager.Quota.GroupQuotaEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.GroupQuotaEntityResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string groupQuotaName, Azure.ResourceManager.Quota.GroupQuotaEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string groupQuotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupQuotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.GroupQuotaEntityResource> Get(string groupQuotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Quota.GroupQuotaEntityResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Quota.GroupQuotaEntityResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.GroupQuotaEntityResource>> GetAsync(string groupQuotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Quota.GroupQuotaEntityResource> GetIfExists(string groupQuotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Quota.GroupQuotaEntityResource>> GetIfExistsAsync(string groupQuotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Quota.GroupQuotaEntityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Quota.GroupQuotaEntityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Quota.GroupQuotaEntityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.GroupQuotaEntityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GroupQuotaEntityData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaEntityData>
    {
        public GroupQuotaEntityData() { }
        public Azure.ResourceManager.Quota.Models.GroupQuotasEntityProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.GroupQuotaEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.GroupQuotaEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotaEntityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaEntityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GroupQuotaEntityResource() { }
        public virtual Azure.ResourceManager.Quota.GroupQuotaEntityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string managementGroupId, string groupQuotaName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.GroupQuotaEntityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.GroupQuotaEntityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.GroupQuotaLimitListResource> GetGroupQuotaLimitList(string resourceProviderName, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.GroupQuotaLimitListResource>> GetGroupQuotaLimitListAsync(string resourceProviderName, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Quota.GroupQuotaLimitListCollection GetGroupQuotaLimitLists() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Quota.GroupQuotaRequestStatusResource> GetGroupQuotaLimitsRequests(string resourceProviderName, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Quota.GroupQuotaRequestStatusResource> GetGroupQuotaLimitsRequestsAsync(string resourceProviderName, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.GroupQuotaRequestStatusResource> GetGroupQuotaRequestStatus(string requestId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.GroupQuotaRequestStatusResource>> GetGroupQuotaRequestStatusAsync(string requestId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Quota.GroupQuotaRequestStatusCollection GetGroupQuotaRequestStatuses() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusResource> GetGroupQuotasEnforcementStatus(string resourceProviderName, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusResource>> GetGroupQuotasEnforcementStatusAsync(string resourceProviderName, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusCollection GetGroupQuotasEnforcementStatuses() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.GroupQuotaSubscriptionResource> GetGroupQuotaSubscription(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.GroupQuotaSubscriptionResource>> GetGroupQuotaSubscriptionAsync(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusResource> GetGroupQuotaSubscriptionRequestStatus(string requestId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusResource>> GetGroupQuotaSubscriptionRequestStatusAsync(string requestId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusCollection GetGroupQuotaSubscriptionRequestStatuses() { throw null; }
        public virtual Azure.ResourceManager.Quota.GroupQuotaSubscriptionCollection GetGroupQuotaSubscriptions() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Quota.Models.GroupQuotaResourceUsages> List(string resourceProviderName, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Quota.Models.GroupQuotaResourceUsages> ListAsync(string resourceProviderName, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Quota.GroupQuotaEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.GroupQuotaEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.GroupQuotaEntityResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Quota.Models.GroupQuotaEntityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.GroupQuotaEntityResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Quota.Models.GroupQuotaEntityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GroupQuotaLimitListCollection : Azure.ResourceManager.ArmCollection
    {
        protected GroupQuotaLimitListCollection() { }
        public virtual Azure.Response<bool> Exists(string resourceProviderName, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceProviderName, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.GroupQuotaLimitListResource> Get(string resourceProviderName, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.GroupQuotaLimitListResource>> GetAsync(string resourceProviderName, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Quota.GroupQuotaLimitListResource> GetIfExists(string resourceProviderName, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Quota.GroupQuotaLimitListResource>> GetIfExistsAsync(string resourceProviderName, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GroupQuotaLimitListData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaLimitListData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaLimitListData>
    {
        public GroupQuotaLimitListData() { }
        public Azure.ResourceManager.Quota.Models.GroupQuotaLimitListProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.GroupQuotaLimitListData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaLimitListData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaLimitListData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.GroupQuotaLimitListData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaLimitListData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaLimitListData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaLimitListData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotaLimitListResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaLimitListData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaLimitListData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GroupQuotaLimitListResource() { }
        public virtual Azure.ResourceManager.Quota.GroupQuotaLimitListData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string managementGroupId, string groupQuotaName, string resourceProviderName, Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.GroupQuotaLimitListResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.GroupQuotaLimitListResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Quota.GroupQuotaLimitListData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaLimitListData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaLimitListData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.GroupQuotaLimitListData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaLimitListData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaLimitListData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaLimitListData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.GroupQuotaLimitListResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Quota.GroupQuotaLimitListData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.GroupQuotaLimitListResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Quota.GroupQuotaLimitListData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GroupQuotaRequestStatusCollection : Azure.ResourceManager.ArmCollection
    {
        protected GroupQuotaRequestStatusCollection() { }
        public virtual Azure.Response<bool> Exists(string requestId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string requestId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.GroupQuotaRequestStatusResource> Get(string requestId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.GroupQuotaRequestStatusResource>> GetAsync(string requestId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Quota.GroupQuotaRequestStatusResource> GetIfExists(string requestId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Quota.GroupQuotaRequestStatusResource>> GetIfExistsAsync(string requestId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GroupQuotaRequestStatusData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaRequestStatusData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaRequestStatusData>
    {
        public GroupQuotaRequestStatusData() { }
        public Azure.ResourceManager.Quota.Models.GroupQuotaRequestStatusProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.GroupQuotaRequestStatusData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaRequestStatusData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaRequestStatusData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.GroupQuotaRequestStatusData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaRequestStatusData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaRequestStatusData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaRequestStatusData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotaRequestStatusResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaRequestStatusData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaRequestStatusData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GroupQuotaRequestStatusResource() { }
        public virtual Azure.ResourceManager.Quota.GroupQuotaRequestStatusData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string managementGroupId, string groupQuotaName, string requestId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.GroupQuotaRequestStatusResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.GroupQuotaRequestStatusResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Quota.GroupQuotaRequestStatusData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaRequestStatusData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaRequestStatusData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.GroupQuotaRequestStatusData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaRequestStatusData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaRequestStatusData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaRequestStatusData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotasEnforcementStatusCollection : Azure.ResourceManager.ArmCollection
    {
        protected GroupQuotasEnforcementStatusCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceProviderName, Azure.Core.AzureLocation location, Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceProviderName, Azure.Core.AzureLocation location, Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceProviderName, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceProviderName, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusResource> Get(string resourceProviderName, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusResource>> GetAsync(string resourceProviderName, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusResource> GetIfExists(string resourceProviderName, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusResource>> GetIfExistsAsync(string resourceProviderName, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GroupQuotasEnforcementStatusData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusData>
    {
        public GroupQuotasEnforcementStatusData() { }
        public Azure.ResourceManager.Quota.Models.GroupQuotasEnforcementStatusProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotasEnforcementStatusResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GroupQuotasEnforcementStatusResource() { }
        public virtual Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string managementGroupId, string groupQuotaName, string resourceProviderName, Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GroupQuotaSubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Quota.GroupQuotaSubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.GroupQuotaSubscriptionResource>, System.Collections.IEnumerable
    {
        protected GroupQuotaSubscriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.GroupQuotaSubscriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.GroupQuotaSubscriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.GroupQuotaSubscriptionResource> Get(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Quota.GroupQuotaSubscriptionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Quota.GroupQuotaSubscriptionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.GroupQuotaSubscriptionResource>> GetAsync(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Quota.GroupQuotaSubscriptionResource> GetIfExists(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Quota.GroupQuotaSubscriptionResource>> GetIfExistsAsync(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Quota.GroupQuotaSubscriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Quota.GroupQuotaSubscriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Quota.GroupQuotaSubscriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.GroupQuotaSubscriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GroupQuotaSubscriptionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionData>
    {
        public GroupQuotaSubscriptionData() { }
        public Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.GroupQuotaSubscriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.GroupQuotaSubscriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotaSubscriptionRequestStatusCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusResource>, System.Collections.IEnumerable
    {
        protected GroupQuotaSubscriptionRequestStatusCollection() { }
        public virtual Azure.Response<bool> Exists(string requestId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string requestId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusResource> Get(string requestId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusResource>> GetAsync(string requestId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusResource> GetIfExists(string requestId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusResource>> GetIfExistsAsync(string requestId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GroupQuotaSubscriptionRequestStatusData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusData>
    {
        public GroupQuotaSubscriptionRequestStatusData() { }
        public Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionRequestStatusProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotaSubscriptionRequestStatusResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GroupQuotaSubscriptionRequestStatusResource() { }
        public virtual Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string managementGroupId, string groupQuotaName, string requestId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotaSubscriptionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GroupQuotaSubscriptionResource() { }
        public virtual Azure.ResourceManager.Quota.GroupQuotaSubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string managementGroupId, string groupQuotaName, string subscriptionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.GroupQuotaSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.GroupQuotaSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Quota.GroupQuotaSubscriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.GroupQuotaSubscriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.GroupQuotaSubscriptionResource> Update(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.GroupQuotaSubscriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QuotaAllocationRequestStatusCollection : Azure.ResourceManager.ArmCollection
    {
        protected QuotaAllocationRequestStatusCollection() { }
        public virtual Azure.Response<bool> Exists(string allocationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string allocationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource> Get(string allocationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource> GetAll(string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource> GetAllAsync(string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource>> GetAsync(string allocationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource> GetIfExists(string allocationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource>> GetIfExistsAsync(string allocationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QuotaAllocationRequestStatusData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusData>
    {
        public QuotaAllocationRequestStatusData() { }
        public string FaultCode { get { throw null; } }
        public Azure.ResourceManager.Quota.Models.QuotaRequestStatus? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Quota.Models.QuotaAllocationRequestBase RequestedResource { get { throw null; } set { } }
        public System.DateTimeOffset? RequestSubmittedOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.QuotaAllocationRequestStatusData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.QuotaAllocationRequestStatusData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuotaAllocationRequestStatusResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected QuotaAllocationRequestStatusResource() { }
        public virtual Azure.ResourceManager.Quota.QuotaAllocationRequestStatusData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string managementGroupId, string subscriptionId, string groupQuotaName, string resourceProviderName, string allocationId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Quota.QuotaAllocationRequestStatusData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.QuotaAllocationRequestStatusData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class QuotaExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource> GetCurrentQuotaLimitBase(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource>> GetCurrentQuotaLimitBaseAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource GetCurrentQuotaLimitBaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Quota.CurrentQuotaLimitBaseCollection GetCurrentQuotaLimitBases(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Quota.CurrentUsagesBaseResource> GetCurrentUsagesBase(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.CurrentUsagesBaseResource>> GetCurrentUsagesBaseAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Quota.CurrentUsagesBaseResource GetCurrentUsagesBaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Quota.CurrentUsagesBaseCollection GetCurrentUsagesBases(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Quota.GroupQuotaEntityCollection GetGroupQuotaEntities(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Quota.GroupQuotaEntityResource> GetGroupQuotaEntity(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string groupQuotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.GroupQuotaEntityResource>> GetGroupQuotaEntityAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string groupQuotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Quota.GroupQuotaEntityResource GetGroupQuotaEntityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Quota.GroupQuotaLimitListResource GetGroupQuotaLimitListResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Quota.GroupQuotaRequestStatusResource GetGroupQuotaRequestStatusResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusResource GetGroupQuotasEnforcementStatusResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusResource GetGroupQuotaSubscriptionRequestStatusResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Quota.GroupQuotaSubscriptionResource GetGroupQuotaSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource> GetQuotaAllocationRequestStatus(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string subscriptionId, string groupQuotaName, string resourceProviderName, string allocationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource>> GetQuotaAllocationRequestStatusAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string subscriptionId, string groupQuotaName, string resourceProviderName, string allocationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Quota.QuotaAllocationRequestStatusCollection GetQuotaAllocationRequestStatuses(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string subscriptionId, string groupQuotaName, string resourceProviderName) { throw null; }
        public static Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource GetQuotaAllocationRequestStatusResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Quota.Models.QuotaOperationResult> GetQuotaOperations(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Quota.Models.QuotaOperationResult> GetQuotaOperationsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Quota.QuotaRequestDetailResource> GetQuotaRequestDetail(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.QuotaRequestDetailResource>> GetQuotaRequestDetailAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Quota.QuotaRequestDetailResource GetQuotaRequestDetailResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Quota.QuotaRequestDetailCollection GetQuotaRequestDetails(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListResource> GetSubscriptionQuotaAllocationsList(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string subscriptionId, string groupQuotaName, string resourceProviderName, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListResource>> GetSubscriptionQuotaAllocationsListAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string subscriptionId, string groupQuotaName, string resourceProviderName, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListResource GetSubscriptionQuotaAllocationsListResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListCollection GetSubscriptionQuotaAllocationsLists(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource) { throw null; }
    }
    public partial class QuotaRequestDetailCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Quota.QuotaRequestDetailResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.QuotaRequestDetailResource>, System.Collections.IEnumerable
    {
        protected QuotaRequestDetailCollection() { }
        public virtual Azure.Response<bool> Exists(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.QuotaRequestDetailResource> Get(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Quota.QuotaRequestDetailResource> GetAll(string filter = null, int? top = default(int?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Quota.QuotaRequestDetailResource> GetAllAsync(string filter = null, int? top = default(int?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.QuotaRequestDetailResource>> GetAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Quota.QuotaRequestDetailResource> GetIfExists(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Quota.QuotaRequestDetailResource>> GetIfExistsAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Quota.QuotaRequestDetailResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Quota.QuotaRequestDetailResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Quota.QuotaRequestDetailResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.QuotaRequestDetailResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class QuotaRequestDetailData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.QuotaRequestDetailData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.QuotaRequestDetailData>
    {
        internal QuotaRequestDetailData() { }
        public Azure.ResourceManager.Quota.Models.ServiceErrorDetail Error { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Quota.Models.QuotaRequestState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? RequestSubmitOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Quota.Models.QuotaSubRequestDetail> Value { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.QuotaRequestDetailData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.QuotaRequestDetailData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.QuotaRequestDetailData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.QuotaRequestDetailData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.QuotaRequestDetailData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.QuotaRequestDetailData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.QuotaRequestDetailData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuotaRequestDetailResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.QuotaRequestDetailData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.QuotaRequestDetailData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected QuotaRequestDetailResource() { }
        public virtual Azure.ResourceManager.Quota.QuotaRequestDetailData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.QuotaRequestDetailResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.QuotaRequestDetailResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Quota.QuotaRequestDetailData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.QuotaRequestDetailData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.QuotaRequestDetailData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.QuotaRequestDetailData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.QuotaRequestDetailData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.QuotaRequestDetailData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.QuotaRequestDetailData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubscriptionQuotaAllocationsListCollection : Azure.ResourceManager.ArmCollection
    {
        protected SubscriptionQuotaAllocationsListCollection() { }
        public virtual Azure.Response<bool> Exists(string subscriptionId, string groupQuotaName, string resourceProviderName, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string subscriptionId, string groupQuotaName, string resourceProviderName, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListResource> Get(string subscriptionId, string groupQuotaName, string resourceProviderName, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListResource>> GetAsync(string subscriptionId, string groupQuotaName, string resourceProviderName, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListResource> GetIfExists(string subscriptionId, string groupQuotaName, string resourceProviderName, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListResource>> GetIfExistsAsync(string subscriptionId, string groupQuotaName, string resourceProviderName, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionQuotaAllocationsListData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListData>
    {
        public SubscriptionQuotaAllocationsListData() { }
        public Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocationsListProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubscriptionQuotaAllocationsListResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SubscriptionQuotaAllocationsListResource() { }
        public virtual Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string managementGroupId, string subscriptionId, string groupQuotaName, string resourceProviderName, Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Quota.Mocking
{
    public partial class MockableQuotaArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableQuotaArmClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource> GetCurrentQuotaLimitBase(Azure.Core.ResourceIdentifier scope, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource>> GetCurrentQuotaLimitBaseAsync(Azure.Core.ResourceIdentifier scope, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource GetCurrentQuotaLimitBaseResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Quota.CurrentQuotaLimitBaseCollection GetCurrentQuotaLimitBases(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.CurrentUsagesBaseResource> GetCurrentUsagesBase(Azure.Core.ResourceIdentifier scope, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.CurrentUsagesBaseResource>> GetCurrentUsagesBaseAsync(Azure.Core.ResourceIdentifier scope, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Quota.CurrentUsagesBaseResource GetCurrentUsagesBaseResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Quota.CurrentUsagesBaseCollection GetCurrentUsagesBases(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Quota.GroupQuotaEntityResource GetGroupQuotaEntityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Quota.GroupQuotaLimitListResource GetGroupQuotaLimitListResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Quota.GroupQuotaRequestStatusResource GetGroupQuotaRequestStatusResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusResource GetGroupQuotasEnforcementStatusResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusResource GetGroupQuotaSubscriptionRequestStatusResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Quota.GroupQuotaSubscriptionResource GetGroupQuotaSubscriptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource GetQuotaAllocationRequestStatusResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.QuotaRequestDetailResource> GetQuotaRequestDetail(Azure.Core.ResourceIdentifier scope, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.QuotaRequestDetailResource>> GetQuotaRequestDetailAsync(Azure.Core.ResourceIdentifier scope, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Quota.QuotaRequestDetailResource GetQuotaRequestDetailResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Quota.QuotaRequestDetailCollection GetQuotaRequestDetails(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListResource GetSubscriptionQuotaAllocationsListResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableQuotaManagementGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableQuotaManagementGroupResource() { }
        public virtual Azure.ResourceManager.Quota.GroupQuotaEntityCollection GetGroupQuotaEntities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.GroupQuotaEntityResource> GetGroupQuotaEntity(string groupQuotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.GroupQuotaEntityResource>> GetGroupQuotaEntityAsync(string groupQuotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource> GetQuotaAllocationRequestStatus(string subscriptionId, string groupQuotaName, string resourceProviderName, string allocationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource>> GetQuotaAllocationRequestStatusAsync(string subscriptionId, string groupQuotaName, string resourceProviderName, string allocationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Quota.QuotaAllocationRequestStatusCollection GetQuotaAllocationRequestStatuses(string subscriptionId, string groupQuotaName, string resourceProviderName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListResource> GetSubscriptionQuotaAllocationsList(string subscriptionId, string groupQuotaName, string resourceProviderName, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListResource>> GetSubscriptionQuotaAllocationsListAsync(string subscriptionId, string groupQuotaName, string resourceProviderName, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListCollection GetSubscriptionQuotaAllocationsLists() { throw null; }
    }
    public partial class MockableQuotaTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableQuotaTenantResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Quota.Models.QuotaOperationResult> GetQuotaOperations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Quota.Models.QuotaOperationResult> GetQuotaOperationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Quota.Models
{
    public static partial class ArmQuotaModelFactory
    {
        public static Azure.ResourceManager.Quota.CurrentQuotaLimitBaseData CurrentQuotaLimitBaseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Quota.Models.QuotaProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Quota.CurrentUsagesBaseData CurrentUsagesBaseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Quota.Models.QuotaUsagesProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.GroupQuotaDetails GroupQuotaDetails(string resourceName, long? limit, string comment, string unit, long? availableLimit = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.Models.SubscriptionAllocatedQuota> allocatedToSubscriptionsValue = null, string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.GroupQuotaDetails GroupQuotaDetails(string resourceName = null, long? limit = default(long?), string comment = null, string unit = null, string value = null, string localizedValue = null, long? availableLimit = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.Models.SubscriptionAllocatedQuota> allocatedToSubscriptionsValue = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.GroupQuotaEntityBase GroupQuotaEntityBase(string displayName = null, Azure.ResourceManager.Quota.Models.GroupType? groupType = default(Azure.ResourceManager.Quota.Models.GroupType?), Azure.ResourceManager.Quota.Models.QuotaRequestStatus? provisioningState = default(Azure.ResourceManager.Quota.Models.QuotaRequestStatus?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Quota.Models.GroupQuotaEntityBase GroupQuotaEntityBase(string displayName, Azure.ResourceManager.Quota.Models.QuotaRequestStatus? provisioningState) { throw null; }
        public static Azure.ResourceManager.Quota.GroupQuotaEntityData GroupQuotaEntityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Quota.Models.GroupQuotasEntityProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.GroupQuotaEntityPatch GroupQuotaEntityPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Quota.Models.GroupQuotasEntityPatchProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Quota.GroupQuotaLimitListData GroupQuotaLimitListData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Quota.Models.GroupQuotaLimitListProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.GroupQuotaLimitListProperties GroupQuotaLimitListProperties(Azure.ResourceManager.Quota.Models.QuotaRequestStatus? provisioningState = default(Azure.ResourceManager.Quota.Models.QuotaRequestStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.Models.GroupQuotaLimit> value = null, string nextLink = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.GroupQuotaLimitProperties GroupQuotaLimitProperties(string resourceName, long? limit, string comment, string unit, long? availableLimit = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.Models.SubscriptionAllocatedQuota> allocatedToSubscriptionsValue = null, string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.GroupQuotaLimitProperties GroupQuotaLimitProperties(string resourceName = null, long? limit = default(long?), string comment = null, string unit = null, string value = null, string localizedValue = null, long? availableLimit = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.Models.SubscriptionAllocatedQuota> allocatedToSubscriptionsValue = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.GroupQuotaRequestBase GroupQuotaRequestBase(long? limit = default(long?), string region = null, string comments = null, string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.Quota.GroupQuotaRequestStatusData GroupQuotaRequestStatusData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Quota.Models.GroupQuotaRequestStatusProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.GroupQuotaRequestStatusProperties GroupQuotaRequestStatusProperties(Azure.ResourceManager.Quota.Models.GroupQuotaRequestBase requestedResource = null, System.DateTimeOffset? requestSubmittedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Quota.Models.QuotaRequestStatus? provisioningState = default(Azure.ResourceManager.Quota.Models.QuotaRequestStatus?), string faultCode = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.GroupQuotaResourceUsages GroupQuotaResourceUsages(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Quota.Models.GroupQuotaUsagesBase properties = null) { throw null; }
        public static Azure.ResourceManager.Quota.GroupQuotasEnforcementStatusData GroupQuotasEnforcementStatusData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Quota.Models.GroupQuotasEnforcementStatusProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.GroupQuotasEnforcementStatusProperties GroupQuotasEnforcementStatusProperties(Azure.ResourceManager.Quota.Models.EnforcementState? enforcementEnabled = default(Azure.ResourceManager.Quota.Models.EnforcementState?), string enforcedGroupName = null, Azure.ResourceManager.Quota.Models.QuotaRequestStatus? provisioningState = default(Azure.ResourceManager.Quota.Models.QuotaRequestStatus?), string faultCode = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.GroupQuotasEntityBasePatch GroupQuotasEntityBasePatch(string displayName = null, Azure.ResourceManager.Quota.Models.QuotaRequestStatus? provisioningState = default(Azure.ResourceManager.Quota.Models.QuotaRequestStatus?)) { throw null; }
        public static Azure.ResourceManager.Quota.Models.GroupQuotasEntityPatchProperties GroupQuotasEntityPatchProperties(string displayName = null, Azure.ResourceManager.Quota.Models.QuotaRequestStatus? provisioningState = default(Azure.ResourceManager.Quota.Models.QuotaRequestStatus?)) { throw null; }
        public static Azure.ResourceManager.Quota.Models.GroupQuotasEntityProperties GroupQuotasEntityProperties(string displayName = null, Azure.ResourceManager.Quota.Models.GroupType? groupType = default(Azure.ResourceManager.Quota.Models.GroupType?), Azure.ResourceManager.Quota.Models.QuotaRequestStatus? provisioningState = default(Azure.ResourceManager.Quota.Models.QuotaRequestStatus?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Quota.Models.GroupQuotasEntityProperties GroupQuotasEntityProperties(string displayName, Azure.ResourceManager.Quota.Models.QuotaRequestStatus? provisioningState) { throw null; }
        public static Azure.ResourceManager.Quota.GroupQuotaSubscriptionData GroupQuotaSubscriptionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionProperties GroupQuotaSubscriptionProperties(string subscriptionId = null, Azure.ResourceManager.Quota.Models.QuotaRequestStatus? provisioningState = default(Azure.ResourceManager.Quota.Models.QuotaRequestStatus?)) { throw null; }
        public static Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusData GroupQuotaSubscriptionRequestStatusData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionRequestStatusProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionRequestStatusProperties GroupQuotaSubscriptionRequestStatusProperties(string subscriptionId = null, System.DateTimeOffset? requestSubmitOn = default(System.DateTimeOffset?), Azure.ResourceManager.Quota.Models.QuotaRequestStatus? provisioningState = default(Azure.ResourceManager.Quota.Models.QuotaRequestStatus?)) { throw null; }
        public static Azure.ResourceManager.Quota.Models.GroupQuotaUsagesBase GroupQuotaUsagesBase(string value = null, string localizedValue = null, long? limit = default(long?), long? usages = default(long?), string unit = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.QuotaAllocationRequestBase QuotaAllocationRequestBase(long? limit = default(long?), string value = null, string localizedValue = null, string region = null) { throw null; }
        public static Azure.ResourceManager.Quota.QuotaAllocationRequestStatusData QuotaAllocationRequestStatusData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Quota.Models.QuotaAllocationRequestBase requestedResource = null, System.DateTimeOffset? requestSubmittedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Quota.Models.QuotaRequestStatus? provisioningState = default(Azure.ResourceManager.Quota.Models.QuotaRequestStatus?), string faultCode = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.QuotaOperationDisplay QuotaOperationDisplay(string provider = null, string resource = null, string operation = null, string description = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.QuotaOperationResult QuotaOperationResult(string name = null, Azure.ResourceManager.Quota.Models.QuotaOperationDisplay display = null, string origin = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.QuotaProperties QuotaProperties(Azure.ResourceManager.Quota.Models.QuotaLimitJsonObject limit = null, string unit = null, Azure.ResourceManager.Quota.Models.QuotaRequestResourceName name = null, string resourceTypeName = null, System.TimeSpan? quotaPeriod = default(System.TimeSpan?), bool? isQuotaApplicable = default(bool?), System.BinaryData properties = null) { throw null; }
        public static Azure.ResourceManager.Quota.QuotaRequestDetailData QuotaRequestDetailData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Quota.Models.QuotaRequestState? provisioningState = default(Azure.ResourceManager.Quota.Models.QuotaRequestState?), string message = null, Azure.ResourceManager.Quota.Models.ServiceErrorDetail error = null, System.DateTimeOffset? requestSubmitOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.Models.QuotaSubRequestDetail> value = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.QuotaRequestResourceName QuotaRequestResourceName(string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.QuotaSubRequestDetail QuotaSubRequestDetail(Azure.ResourceManager.Quota.Models.QuotaRequestResourceName name = null, string resourceTypeName = null, string unit = null, Azure.ResourceManager.Quota.Models.QuotaRequestState? provisioningState = default(Azure.ResourceManager.Quota.Models.QuotaRequestState?), string message = null, System.Guid? subRequestId = default(System.Guid?), Azure.ResourceManager.Quota.Models.QuotaLimitJsonObject limit = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.QuotaUsagesObject QuotaUsagesObject(int value = 0, Azure.ResourceManager.Quota.Models.QuotaUsagesType? usagesType = default(Azure.ResourceManager.Quota.Models.QuotaUsagesType?)) { throw null; }
        public static Azure.ResourceManager.Quota.Models.QuotaUsagesProperties QuotaUsagesProperties(Azure.ResourceManager.Quota.Models.QuotaUsagesObject usages = null, string unit = null, Azure.ResourceManager.Quota.Models.QuotaRequestResourceName name = null, string resourceTypeName = null, System.TimeSpan? quotaPeriod = default(System.TimeSpan?), bool? isQuotaApplicable = default(bool?), System.BinaryData properties = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.ServiceErrorDetail ServiceErrorDetail(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.SubscriptionAllocatedQuota SubscriptionAllocatedQuota(string subscriptionId = null, long? quotaAllocated = default(long?)) { throw null; }
        public static Azure.ResourceManager.Quota.SubscriptionQuotaAllocationsListData SubscriptionQuotaAllocationsListData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocationsListProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocationsListProperties SubscriptionQuotaAllocationsListProperties(Azure.ResourceManager.Quota.Models.QuotaRequestStatus? provisioningState = default(Azure.ResourceManager.Quota.Models.QuotaRequestStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocations> value = null, string nextLink = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocationsProperties SubscriptionQuotaAllocationsProperties(string resourceName = null, long? limit = default(long?), long? shareableQuota = default(long?), string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.SubscriptionQuotaDetails SubscriptionQuotaDetails(string resourceName = null, long? limit = default(long?), long? shareableQuota = default(long?), string value = null, string localizedValue = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnforcementState : System.IEquatable<Azure.ResourceManager.Quota.Models.EnforcementState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnforcementState(string value) { throw null; }
        public static Azure.ResourceManager.Quota.Models.EnforcementState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Quota.Models.EnforcementState Enabled { get { throw null; } }
        public static Azure.ResourceManager.Quota.Models.EnforcementState NotAvailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Quota.Models.EnforcementState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Quota.Models.EnforcementState left, Azure.ResourceManager.Quota.Models.EnforcementState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Quota.Models.EnforcementState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Quota.Models.EnforcementState left, Azure.ResourceManager.Quota.Models.EnforcementState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GroupQuotaDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaDetails>
    {
        public GroupQuotaDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Quota.Models.SubscriptionAllocatedQuota> AllocatedToSubscriptionsValue { get { throw null; } }
        public long? AvailableLimit { get { throw null; } }
        public string Comment { get { throw null; } set { } }
        public long? Limit { get { throw null; } set { } }
        public string LocalizedValue { get { throw null; } }
        public string ResourceName { get { throw null; } set { } }
        public string Unit { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotaDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotaDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotaEntityBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaEntityBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaEntityBase>
    {
        public GroupQuotaEntityBase() { }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Quota.Models.GroupType? GroupType { get { throw null; } }
        public Azure.ResourceManager.Quota.Models.QuotaRequestStatus? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotaEntityBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaEntityBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaEntityBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotaEntityBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaEntityBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaEntityBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaEntityBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotaEntityPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaEntityPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaEntityPatch>
    {
        public GroupQuotaEntityPatch() { }
        public Azure.ResourceManager.Quota.Models.GroupQuotasEntityPatchProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotaEntityPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaEntityPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaEntityPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotaEntityPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaEntityPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaEntityPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaEntityPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotaLimit : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaLimit>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaLimit>
    {
        public GroupQuotaLimit() { }
        public Azure.ResourceManager.Quota.Models.GroupQuotaLimitProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotaLimit System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaLimit>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaLimit>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotaLimit System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaLimit>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaLimit>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaLimit>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotaLimitListProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaLimitListProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaLimitListProperties>
    {
        public GroupQuotaLimitListProperties() { }
        public string NextLink { get { throw null; } }
        public Azure.ResourceManager.Quota.Models.QuotaRequestStatus? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Quota.Models.GroupQuotaLimit> Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotaLimitListProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaLimitListProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaLimitListProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotaLimitListProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaLimitListProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaLimitListProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaLimitListProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotaLimitProperties : Azure.ResourceManager.Quota.Models.GroupQuotaDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaLimitProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaLimitProperties>
    {
        public GroupQuotaLimitProperties() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotaLimitProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaLimitProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaLimitProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotaLimitProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaLimitProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaLimitProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaLimitProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotaRequestBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaRequestBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaRequestBase>
    {
        public GroupQuotaRequestBase() { }
        public string Comments { get { throw null; } set { } }
        public long? Limit { get { throw null; } set { } }
        public string LocalizedValue { get { throw null; } }
        public string Region { get { throw null; } set { } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotaRequestBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaRequestBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaRequestBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotaRequestBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaRequestBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaRequestBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaRequestBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotaRequestStatusProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaRequestStatusProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaRequestStatusProperties>
    {
        public GroupQuotaRequestStatusProperties() { }
        public string FaultCode { get { throw null; } }
        public Azure.ResourceManager.Quota.Models.QuotaRequestStatus? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Quota.Models.GroupQuotaRequestBase RequestedResource { get { throw null; } set { } }
        public System.DateTimeOffset? RequestSubmittedOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotaRequestStatusProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaRequestStatusProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaRequestStatusProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotaRequestStatusProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaRequestStatusProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaRequestStatusProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaRequestStatusProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotaResourceUsages : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaResourceUsages>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaResourceUsages>
    {
        internal GroupQuotaResourceUsages() { }
        public Azure.ResourceManager.Quota.Models.GroupQuotaUsagesBase Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotaResourceUsages System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaResourceUsages>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaResourceUsages>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotaResourceUsages System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaResourceUsages>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaResourceUsages>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaResourceUsages>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotasEnforcementStatusProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotasEnforcementStatusProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotasEnforcementStatusProperties>
    {
        public GroupQuotasEnforcementStatusProperties() { }
        public string EnforcedGroupName { get { throw null; } }
        public Azure.ResourceManager.Quota.Models.EnforcementState? EnforcementEnabled { get { throw null; } set { } }
        public string FaultCode { get { throw null; } }
        public Azure.ResourceManager.Quota.Models.QuotaRequestStatus? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotasEnforcementStatusProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotasEnforcementStatusProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotasEnforcementStatusProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotasEnforcementStatusProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotasEnforcementStatusProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotasEnforcementStatusProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotasEnforcementStatusProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotasEntityBasePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityBasePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityBasePatch>
    {
        public GroupQuotasEntityBasePatch() { }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Quota.Models.QuotaRequestStatus? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotasEntityBasePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityBasePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityBasePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotasEntityBasePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityBasePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityBasePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityBasePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotasEntityPatchProperties : Azure.ResourceManager.Quota.Models.GroupQuotasEntityBasePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityPatchProperties>
    {
        public GroupQuotasEntityPatchProperties() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotasEntityPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotasEntityPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotasEntityProperties : Azure.ResourceManager.Quota.Models.GroupQuotaEntityBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityProperties>
    {
        public GroupQuotasEntityProperties() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotasEntityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotasEntityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotaSubscriptionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionProperties>
    {
        public GroupQuotaSubscriptionProperties() { }
        public Azure.ResourceManager.Quota.Models.QuotaRequestStatus? ProvisioningState { get { throw null; } }
        public string SubscriptionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotaSubscriptionRequestStatusProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionRequestStatusProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionRequestStatusProperties>
    {
        public GroupQuotaSubscriptionRequestStatusProperties() { }
        public Azure.ResourceManager.Quota.Models.QuotaRequestStatus? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? RequestSubmitOn { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionRequestStatusProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionRequestStatusProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionRequestStatusProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionRequestStatusProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionRequestStatusProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionRequestStatusProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionRequestStatusProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotaUsagesBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaUsagesBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaUsagesBase>
    {
        internal GroupQuotaUsagesBase() { }
        public long? Limit { get { throw null; } }
        public string LocalizedValue { get { throw null; } }
        public string Unit { get { throw null; } }
        public long? Usages { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotaUsagesBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaUsagesBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaUsagesBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotaUsagesBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaUsagesBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaUsagesBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaUsagesBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GroupType : System.IEquatable<Azure.ResourceManager.Quota.Models.GroupType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GroupType(string value) { throw null; }
        public static Azure.ResourceManager.Quota.Models.GroupType AllocationGroup { get { throw null; } }
        public static Azure.ResourceManager.Quota.Models.GroupType EnforcedGroup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Quota.Models.GroupType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Quota.Models.GroupType left, Azure.ResourceManager.Quota.Models.GroupType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Quota.Models.GroupType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Quota.Models.GroupType left, Azure.ResourceManager.Quota.Models.GroupType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuotaAllocationRequestBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaAllocationRequestBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaAllocationRequestBase>
    {
        public QuotaAllocationRequestBase() { }
        public long? Limit { get { throw null; } set { } }
        public string LocalizedValue { get { throw null; } }
        public string Region { get { throw null; } set { } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.QuotaAllocationRequestBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaAllocationRequestBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaAllocationRequestBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.QuotaAllocationRequestBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaAllocationRequestBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaAllocationRequestBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaAllocationRequestBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class QuotaLimitJsonObject : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaLimitJsonObject>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaLimitJsonObject>
    {
        protected QuotaLimitJsonObject() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.QuotaLimitJsonObject System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaLimitJsonObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaLimitJsonObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.QuotaLimitJsonObject System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaLimitJsonObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaLimitJsonObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaLimitJsonObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuotaLimitObject : Azure.ResourceManager.Quota.Models.QuotaLimitJsonObject, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaLimitObject>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaLimitObject>
    {
        public QuotaLimitObject(int value) { }
        public Azure.ResourceManager.Quota.Models.QuotaLimitType? LimitType { get { throw null; } set { } }
        public int Value { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.QuotaLimitObject System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaLimitObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaLimitObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.QuotaLimitObject System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaLimitObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaLimitObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaLimitObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QuotaLimitType : System.IEquatable<Azure.ResourceManager.Quota.Models.QuotaLimitType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QuotaLimitType(string value) { throw null; }
        public static Azure.ResourceManager.Quota.Models.QuotaLimitType Independent { get { throw null; } }
        public static Azure.ResourceManager.Quota.Models.QuotaLimitType Shared { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Quota.Models.QuotaLimitType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Quota.Models.QuotaLimitType left, Azure.ResourceManager.Quota.Models.QuotaLimitType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Quota.Models.QuotaLimitType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Quota.Models.QuotaLimitType left, Azure.ResourceManager.Quota.Models.QuotaLimitType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuotaOperationDisplay : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaOperationDisplay>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaOperationDisplay>
    {
        internal QuotaOperationDisplay() { }
        public string Description { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.QuotaOperationDisplay System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaOperationDisplay>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaOperationDisplay>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.QuotaOperationDisplay System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaOperationDisplay>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaOperationDisplay>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaOperationDisplay>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuotaOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaOperationResult>
    {
        internal QuotaOperationResult() { }
        public Azure.ResourceManager.Quota.Models.QuotaOperationDisplay Display { get { throw null; } }
        public string Name { get { throw null; } }
        public string Origin { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.QuotaOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.QuotaOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuotaProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaProperties>
    {
        public QuotaProperties() { }
        public bool? IsQuotaApplicable { get { throw null; } }
        public Azure.ResourceManager.Quota.Models.QuotaLimitJsonObject Limit { get { throw null; } set { } }
        public Azure.ResourceManager.Quota.Models.QuotaRequestResourceName Name { get { throw null; } set { } }
        public System.BinaryData Properties { get { throw null; } set { } }
        public System.TimeSpan? QuotaPeriod { get { throw null; } }
        public string ResourceTypeName { get { throw null; } set { } }
        public string Unit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.QuotaProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.QuotaProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuotaRequestResourceName : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaRequestResourceName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaRequestResourceName>
    {
        public QuotaRequestResourceName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.QuotaRequestResourceName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaRequestResourceName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaRequestResourceName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.QuotaRequestResourceName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaRequestResourceName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaRequestResourceName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaRequestResourceName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QuotaRequestState : System.IEquatable<Azure.ResourceManager.Quota.Models.QuotaRequestState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QuotaRequestState(string value) { throw null; }
        public static Azure.ResourceManager.Quota.Models.QuotaRequestState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Quota.Models.QuotaRequestState Failed { get { throw null; } }
        public static Azure.ResourceManager.Quota.Models.QuotaRequestState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Quota.Models.QuotaRequestState Invalid { get { throw null; } }
        public static Azure.ResourceManager.Quota.Models.QuotaRequestState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Quota.Models.QuotaRequestState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Quota.Models.QuotaRequestState left, Azure.ResourceManager.Quota.Models.QuotaRequestState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Quota.Models.QuotaRequestState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Quota.Models.QuotaRequestState left, Azure.ResourceManager.Quota.Models.QuotaRequestState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QuotaRequestStatus : System.IEquatable<Azure.ResourceManager.Quota.Models.QuotaRequestStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QuotaRequestStatus(string value) { throw null; }
        public static Azure.ResourceManager.Quota.Models.QuotaRequestStatus Accepted { get { throw null; } }
        public static Azure.ResourceManager.Quota.Models.QuotaRequestStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.Quota.Models.QuotaRequestStatus Created { get { throw null; } }
        public static Azure.ResourceManager.Quota.Models.QuotaRequestStatus Escalated { get { throw null; } }
        public static Azure.ResourceManager.Quota.Models.QuotaRequestStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Quota.Models.QuotaRequestStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.Quota.Models.QuotaRequestStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.Quota.Models.QuotaRequestStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Quota.Models.QuotaRequestStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Quota.Models.QuotaRequestStatus left, Azure.ResourceManager.Quota.Models.QuotaRequestStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Quota.Models.QuotaRequestStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Quota.Models.QuotaRequestStatus left, Azure.ResourceManager.Quota.Models.QuotaRequestStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuotaSubRequestDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaSubRequestDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaSubRequestDetail>
    {
        internal QuotaSubRequestDetail() { }
        public Azure.ResourceManager.Quota.Models.QuotaLimitJsonObject Limit { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Quota.Models.QuotaRequestResourceName Name { get { throw null; } }
        public Azure.ResourceManager.Quota.Models.QuotaRequestState? ProvisioningState { get { throw null; } }
        public string ResourceTypeName { get { throw null; } }
        public System.Guid? SubRequestId { get { throw null; } }
        public string Unit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.QuotaSubRequestDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaSubRequestDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaSubRequestDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.QuotaSubRequestDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaSubRequestDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaSubRequestDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaSubRequestDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuotaUsagesObject : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaUsagesObject>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaUsagesObject>
    {
        internal QuotaUsagesObject() { }
        public Azure.ResourceManager.Quota.Models.QuotaUsagesType? UsagesType { get { throw null; } }
        public int Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.QuotaUsagesObject System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaUsagesObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaUsagesObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.QuotaUsagesObject System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaUsagesObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaUsagesObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaUsagesObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuotaUsagesProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaUsagesProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaUsagesProperties>
    {
        internal QuotaUsagesProperties() { }
        public bool? IsQuotaApplicable { get { throw null; } }
        public Azure.ResourceManager.Quota.Models.QuotaRequestResourceName Name { get { throw null; } }
        public System.BinaryData Properties { get { throw null; } }
        public System.TimeSpan? QuotaPeriod { get { throw null; } }
        public string ResourceTypeName { get { throw null; } }
        public string Unit { get { throw null; } }
        public Azure.ResourceManager.Quota.Models.QuotaUsagesObject Usages { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.QuotaUsagesProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaUsagesProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaUsagesProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.QuotaUsagesProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaUsagesProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaUsagesProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaUsagesProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QuotaUsagesType : System.IEquatable<Azure.ResourceManager.Quota.Models.QuotaUsagesType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QuotaUsagesType(string value) { throw null; }
        public static Azure.ResourceManager.Quota.Models.QuotaUsagesType Combined { get { throw null; } }
        public static Azure.ResourceManager.Quota.Models.QuotaUsagesType Individual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Quota.Models.QuotaUsagesType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Quota.Models.QuotaUsagesType left, Azure.ResourceManager.Quota.Models.QuotaUsagesType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Quota.Models.QuotaUsagesType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Quota.Models.QuotaUsagesType left, Azure.ResourceManager.Quota.Models.QuotaUsagesType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceErrorDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.ServiceErrorDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.ServiceErrorDetail>
    {
        internal ServiceErrorDetail() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.ServiceErrorDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.ServiceErrorDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.ServiceErrorDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.ServiceErrorDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.ServiceErrorDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.ServiceErrorDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.ServiceErrorDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubscriptionAllocatedQuota : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.SubscriptionAllocatedQuota>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.SubscriptionAllocatedQuota>
    {
        internal SubscriptionAllocatedQuota() { }
        public long? QuotaAllocated { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.SubscriptionAllocatedQuota System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.SubscriptionAllocatedQuota>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.SubscriptionAllocatedQuota>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.SubscriptionAllocatedQuota System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.SubscriptionAllocatedQuota>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.SubscriptionAllocatedQuota>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.SubscriptionAllocatedQuota>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubscriptionQuotaAllocations : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocations>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocations>
    {
        public SubscriptionQuotaAllocations() { }
        public Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocationsProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocations System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocations>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocations>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocations System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocations>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocations>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocations>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubscriptionQuotaAllocationsListProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocationsListProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocationsListProperties>
    {
        public SubscriptionQuotaAllocationsListProperties() { }
        public string NextLink { get { throw null; } }
        public Azure.ResourceManager.Quota.Models.QuotaRequestStatus? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocations> Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocationsListProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocationsListProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocationsListProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocationsListProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocationsListProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocationsListProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocationsListProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubscriptionQuotaAllocationsProperties : Azure.ResourceManager.Quota.Models.SubscriptionQuotaDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocationsProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocationsProperties>
    {
        public SubscriptionQuotaAllocationsProperties() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocationsProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocationsProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocationsProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocationsProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocationsProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocationsProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaAllocationsProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubscriptionQuotaDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaDetails>
    {
        public SubscriptionQuotaDetails() { }
        public long? Limit { get { throw null; } set { } }
        public string LocalizedValue { get { throw null; } }
        public string ResourceName { get { throw null; } set { } }
        public long? ShareableQuota { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.SubscriptionQuotaDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.SubscriptionQuotaDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
