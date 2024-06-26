namespace Azure.ResourceManager.Quota
{
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
    public partial class GroupQuotaLimitCollection : Azure.ResourceManager.ArmCollection
    {
        protected GroupQuotaLimitCollection() { }
        public virtual Azure.Response<bool> Exists(string resourceName, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.GroupQuotaLimitResource> Get(string resourceName, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Quota.GroupQuotaLimitResource> GetAll(string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Quota.GroupQuotaLimitResource> GetAllAsync(string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.GroupQuotaLimitResource>> GetAsync(string resourceName, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Quota.GroupQuotaLimitResource> GetIfExists(string resourceName, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Quota.GroupQuotaLimitResource>> GetIfExistsAsync(string resourceName, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GroupQuotaLimitData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaLimitData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaLimitData>
    {
        public GroupQuotaLimitData() { }
        public Azure.ResourceManager.Quota.Models.GroupQuotaDetails Properties { get { throw null; } set { } }
        Azure.ResourceManager.Quota.GroupQuotaLimitData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaLimitData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaLimitData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.GroupQuotaLimitData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaLimitData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaLimitData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaLimitData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotaLimitResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaLimitData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaLimitData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GroupQuotaLimitResource() { }
        public virtual Azure.ResourceManager.Quota.GroupQuotaLimitData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string managementGroupId, string groupQuotaName, string resourceProviderName, string resourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.GroupQuotaLimitResource> Get(string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.GroupQuotaLimitResource>> GetAsync(string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Quota.GroupQuotaLimitData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaLimitData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaLimitData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.GroupQuotaLimitData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaLimitData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaLimitData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaLimitData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotasEnforcementResponseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseResource>, System.Collections.IEnumerable
    {
        protected GroupQuotasEnforcementResponseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseResource> Get(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseResource>> GetAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseResource> GetIfExists(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseResource>> GetIfExistsAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GroupQuotasEnforcementResponseData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseData>
    {
        public GroupQuotasEnforcementResponseData() { }
        public Azure.ResourceManager.Quota.Models.GroupQuotasEnforcementResponseProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotasEnforcementResponseResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GroupQuotasEnforcementResponseResource() { }
        public virtual Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string managementGroupId, string groupQuotaName, string resourceProviderName, Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GroupQuotasEntityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Quota.GroupQuotasEntityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.GroupQuotasEntityResource>, System.Collections.IEnumerable
    {
        protected GroupQuotasEntityCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.GroupQuotasEntityResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string groupQuotaName, Azure.ResourceManager.Quota.GroupQuotasEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.GroupQuotasEntityResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string groupQuotaName, Azure.ResourceManager.Quota.GroupQuotasEntityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string groupQuotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupQuotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.GroupQuotasEntityResource> Get(string groupQuotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Quota.GroupQuotasEntityResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Quota.GroupQuotasEntityResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.GroupQuotasEntityResource>> GetAsync(string groupQuotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Quota.GroupQuotasEntityResource> GetIfExists(string groupQuotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Quota.GroupQuotasEntityResource>> GetIfExistsAsync(string groupQuotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Quota.GroupQuotasEntityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Quota.GroupQuotasEntityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Quota.GroupQuotasEntityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.GroupQuotasEntityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GroupQuotasEntityData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotasEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotasEntityData>
    {
        public GroupQuotasEntityData() { }
        public Azure.ResourceManager.Quota.Models.GroupQuotasEntityBase Properties { get { throw null; } set { } }
        Azure.ResourceManager.Quota.GroupQuotasEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotasEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotasEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.GroupQuotasEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotasEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotasEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotasEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotasEntityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotasEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotasEntityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GroupQuotasEntityResource() { }
        public virtual Azure.ResourceManager.Quota.GroupQuotasEntityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.SubmittedResourceRequestStatusResource> CreateOrUpdateGroupQuotaLimitsRequest(Azure.WaitUntil waitUntil, string resourceProviderName, string resourceName, Azure.ResourceManager.Quota.SubmittedResourceRequestStatusData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.SubmittedResourceRequestStatusResource>> CreateOrUpdateGroupQuotaLimitsRequestAsync(Azure.WaitUntil waitUntil, string resourceProviderName, string resourceName, Azure.ResourceManager.Quota.SubmittedResourceRequestStatusData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string managementGroupId, string groupQuotaName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.GroupQuotasEntityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.GroupQuotasEntityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.GroupQuotaLimitResource> GetGroupQuotaLimit(string resourceProviderName, string resourceName, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.GroupQuotaLimitResource>> GetGroupQuotaLimitAsync(string resourceProviderName, string resourceName, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Quota.GroupQuotaLimitCollection GetGroupQuotaLimits(string resourceProviderName) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Quota.SubmittedResourceRequestStatusResource> GetGroupQuotaLimitsRequests(string resourceProviderName, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Quota.SubmittedResourceRequestStatusResource> GetGroupQuotaLimitsRequestsAsync(string resourceProviderName, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseResource> GetGroupQuotasEnforcementResponse(string resourceProviderName, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseResource>> GetGroupQuotasEnforcementResponseAsync(string resourceProviderName, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseCollection GetGroupQuotasEnforcementResponses(string resourceProviderName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdResource> GetGroupQuotaSubscriptionId(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdResource>> GetGroupQuotaSubscriptionIdAsync(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdCollection GetGroupQuotaSubscriptionIds() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusResource> GetGroupQuotaSubscriptionRequestStatus(string requestId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusResource>> GetGroupQuotaSubscriptionRequestStatusAsync(string requestId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusCollection GetGroupQuotaSubscriptionRequestStatuses() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Quota.Models.ResourceUsages> GetGroupQuotaUsages(string resourceProviderName, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Quota.Models.ResourceUsages> GetGroupQuotaUsagesAsync(string resourceProviderName, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.SubmittedResourceRequestStatusResource> GetSubmittedResourceRequestStatus(string requestId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.SubmittedResourceRequestStatusResource>> GetSubmittedResourceRequestStatusAsync(string requestId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Quota.SubmittedResourceRequestStatusCollection GetSubmittedResourceRequestStatuses() { throw null; }
        Azure.ResourceManager.Quota.GroupQuotasEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotasEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotasEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.GroupQuotasEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotasEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotasEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotasEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.GroupQuotasEntityResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Quota.Models.GroupQuotasEntityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.GroupQuotasEntityResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Quota.Models.GroupQuotasEntityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.SubmittedResourceRequestStatusResource> UpdateGroupQuotaLimitsRequest(Azure.WaitUntil waitUntil, string resourceProviderName, string resourceName, Azure.ResourceManager.Quota.SubmittedResourceRequestStatusData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.SubmittedResourceRequestStatusResource>> UpdateGroupQuotaLimitsRequestAsync(Azure.WaitUntil waitUntil, string resourceProviderName, string resourceName, Azure.ResourceManager.Quota.SubmittedResourceRequestStatusData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GroupQuotaSubscriptionIdCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdResource>, System.Collections.IEnumerable
    {
        protected GroupQuotaSubscriptionIdCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdResource> Get(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdResource>> GetAsync(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdResource> GetIfExists(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdResource>> GetIfExistsAsync(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GroupQuotaSubscriptionIdData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdData>
    {
        public GroupQuotaSubscriptionIdData() { }
        public Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionIdProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotaSubscriptionIdResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GroupQuotaSubscriptionIdResource() { }
        public virtual Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string managementGroupId, string groupQuotaName, string subscriptionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdResource> Update(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdResource>> UpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class QuotaAllocationRequestStatusCollection : Azure.ResourceManager.ArmCollection
    {
        protected QuotaAllocationRequestStatusCollection() { }
        public virtual Azure.Response<bool> Exists(string subscriptionId, string groupQuotaName, string allocationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string subscriptionId, string groupQuotaName, string allocationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource> Get(string subscriptionId, string groupQuotaName, string allocationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource>> GetAsync(string subscriptionId, string groupQuotaName, string allocationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource> GetIfExists(string subscriptionId, string groupQuotaName, string allocationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource>> GetIfExistsAsync(string subscriptionId, string groupQuotaName, string allocationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QuotaAllocationRequestStatusData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusData>
    {
        public QuotaAllocationRequestStatusData() { }
        public string FaultCode { get { throw null; } }
        public Azure.ResourceManager.Quota.Models.RequestState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Quota.Models.QuotaAllocationRequestBase RequestedResource { get { throw null; } set { } }
        public System.DateTimeOffset? RequestSubmitOn { get { throw null; } }
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
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string managementGroupId, string subscriptionId, string groupQuotaName, string allocationId) { throw null; }
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
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource> CreateOrUpdateGroupQuotaSubscriptionAllocationRequest(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, Azure.WaitUntil waitUntil, string subscriptionId, string groupQuotaName, string resourceProviderName, string resourceName, Azure.ResourceManager.Quota.QuotaAllocationRequestStatusData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource>> CreateOrUpdateGroupQuotaSubscriptionAllocationRequestAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, Azure.WaitUntil waitUntil, string subscriptionId, string groupQuotaName, string resourceProviderName, string resourceName, Azure.ResourceManager.Quota.QuotaAllocationRequestStatusData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource> GetCurrentQuotaLimitBase(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource>> GetCurrentQuotaLimitBaseAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource GetCurrentQuotaLimitBaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Quota.CurrentQuotaLimitBaseCollection GetCurrentQuotaLimitBases(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Quota.CurrentUsagesBaseResource> GetCurrentUsagesBase(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.CurrentUsagesBaseResource>> GetCurrentUsagesBaseAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Quota.CurrentUsagesBaseResource GetCurrentUsagesBaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Quota.CurrentUsagesBaseCollection GetCurrentUsagesBases(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Quota.GroupQuotaLimitResource GetGroupQuotaLimitResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseResource GetGroupQuotasEnforcementResponseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Quota.GroupQuotasEntityCollection GetGroupQuotasEntities(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Quota.GroupQuotasEntityResource> GetGroupQuotasEntity(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string groupQuotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.GroupQuotasEntityResource>> GetGroupQuotasEntityAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string groupQuotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Quota.GroupQuotasEntityResource GetGroupQuotasEntityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdResource GetGroupQuotaSubscriptionIdResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusResource GetGroupQuotaSubscriptionRequestStatusResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource> GetQuotaAllocationRequestStatus(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string subscriptionId, string groupQuotaName, string allocationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource>> GetQuotaAllocationRequestStatusAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string subscriptionId, string groupQuotaName, string allocationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Quota.QuotaAllocationRequestStatusCollection GetQuotaAllocationRequestStatuses(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource> GetQuotaAllocationRequestStatusesByResourceProvider(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string subscriptionId, string groupQuotaName, string resourceProviderName, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource> GetQuotaAllocationRequestStatusesByResourceProviderAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string subscriptionId, string groupQuotaName, string resourceProviderName, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource GetQuotaAllocationRequestStatusResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Quota.Models.QuotaOperationResult> GetQuotaOperations(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Quota.Models.QuotaOperationResult> GetQuotaOperationsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Quota.QuotaRequestDetailResource> GetQuotaRequestDetail(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.QuotaRequestDetailResource>> GetQuotaRequestDetailAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Quota.QuotaRequestDetailResource GetQuotaRequestDetailResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Quota.QuotaRequestDetailCollection GetQuotaRequestDetails(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Quota.SubmittedResourceRequestStatusResource GetSubmittedResourceRequestStatusResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationResource> GetSubscriptionQuotaAllocation(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string subscriptionId, string groupQuotaName, string resourceName, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationResource>> GetSubscriptionQuotaAllocationAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string subscriptionId, string groupQuotaName, string resourceName, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Quota.SubscriptionQuotaAllocationResource GetSubscriptionQuotaAllocationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Quota.SubscriptionQuotaAllocationCollection GetSubscriptionQuotaAllocations(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string subscriptionId, string groupQuotaName) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource> UpdateGroupQuotaSubscriptionAllocationRequest(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, Azure.WaitUntil waitUntil, string subscriptionId, string groupQuotaName, string resourceProviderName, string resourceName, Azure.ResourceManager.Quota.QuotaAllocationRequestStatusData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource>> UpdateGroupQuotaSubscriptionAllocationRequestAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, Azure.WaitUntil waitUntil, string subscriptionId, string groupQuotaName, string resourceProviderName, string resourceName, Azure.ResourceManager.Quota.QuotaAllocationRequestStatusData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class SubmittedResourceRequestStatusCollection : Azure.ResourceManager.ArmCollection
    {
        protected SubmittedResourceRequestStatusCollection() { }
        public virtual Azure.Response<bool> Exists(string requestId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string requestId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.SubmittedResourceRequestStatusResource> Get(string requestId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.SubmittedResourceRequestStatusResource>> GetAsync(string requestId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Quota.SubmittedResourceRequestStatusResource> GetIfExists(string requestId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Quota.SubmittedResourceRequestStatusResource>> GetIfExistsAsync(string requestId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubmittedResourceRequestStatusData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.SubmittedResourceRequestStatusData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.SubmittedResourceRequestStatusData>
    {
        public SubmittedResourceRequestStatusData() { }
        public Azure.ResourceManager.Quota.Models.SubmittedResourceRequestStatusProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.Quota.SubmittedResourceRequestStatusData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.SubmittedResourceRequestStatusData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.SubmittedResourceRequestStatusData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.SubmittedResourceRequestStatusData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.SubmittedResourceRequestStatusData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.SubmittedResourceRequestStatusData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.SubmittedResourceRequestStatusData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubmittedResourceRequestStatusResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.SubmittedResourceRequestStatusData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.SubmittedResourceRequestStatusData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SubmittedResourceRequestStatusResource() { }
        public virtual Azure.ResourceManager.Quota.SubmittedResourceRequestStatusData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string managementGroupId, string groupQuotaName, string requestId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.SubmittedResourceRequestStatusResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.SubmittedResourceRequestStatusResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Quota.SubmittedResourceRequestStatusData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.SubmittedResourceRequestStatusData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.SubmittedResourceRequestStatusData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.SubmittedResourceRequestStatusData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.SubmittedResourceRequestStatusData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.SubmittedResourceRequestStatusData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.SubmittedResourceRequestStatusData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubscriptionQuotaAllocationCollection : Azure.ResourceManager.ArmCollection
    {
        protected SubscriptionQuotaAllocationCollection() { }
        public virtual Azure.Response<bool> Exists(string resourceName, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationResource> Get(string resourceName, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationResource> GetAll(string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationResource> GetAllAsync(string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationResource>> GetAsync(string resourceName, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationResource> GetIfExists(string resourceName, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationResource>> GetIfExistsAsync(string resourceName, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionQuotaAllocationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationData>
    {
        public SubscriptionQuotaAllocationData() { }
        public Azure.ResourceManager.Quota.Models.SubscriptionQuotaDetails Properties { get { throw null; } set { } }
        Azure.ResourceManager.Quota.SubscriptionQuotaAllocationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.SubscriptionQuotaAllocationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubscriptionQuotaAllocationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SubscriptionQuotaAllocationResource() { }
        public virtual Azure.ResourceManager.Quota.SubscriptionQuotaAllocationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string managementGroupId, string subscriptionId, string groupQuotaName, string resourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationResource> Get(string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationResource>> GetAsync(string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Quota.SubscriptionQuotaAllocationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.SubscriptionQuotaAllocationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.ResourceManager.Quota.GroupQuotaLimitResource GetGroupQuotaLimitResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseResource GetGroupQuotasEnforcementResponseResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Quota.GroupQuotasEntityResource GetGroupQuotasEntityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdResource GetGroupQuotaSubscriptionIdResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusResource GetGroupQuotaSubscriptionRequestStatusResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource GetQuotaAllocationRequestStatusResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.QuotaRequestDetailResource> GetQuotaRequestDetail(Azure.Core.ResourceIdentifier scope, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.QuotaRequestDetailResource>> GetQuotaRequestDetailAsync(Azure.Core.ResourceIdentifier scope, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Quota.QuotaRequestDetailResource GetQuotaRequestDetailResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Quota.QuotaRequestDetailCollection GetQuotaRequestDetails(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Quota.SubmittedResourceRequestStatusResource GetSubmittedResourceRequestStatusResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Quota.SubscriptionQuotaAllocationResource GetSubscriptionQuotaAllocationResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableQuotaManagementGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableQuotaManagementGroupResource() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource> CreateOrUpdateGroupQuotaSubscriptionAllocationRequest(Azure.WaitUntil waitUntil, string subscriptionId, string groupQuotaName, string resourceProviderName, string resourceName, Azure.ResourceManager.Quota.QuotaAllocationRequestStatusData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource>> CreateOrUpdateGroupQuotaSubscriptionAllocationRequestAsync(Azure.WaitUntil waitUntil, string subscriptionId, string groupQuotaName, string resourceProviderName, string resourceName, Azure.ResourceManager.Quota.QuotaAllocationRequestStatusData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Quota.GroupQuotasEntityCollection GetGroupQuotasEntities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.GroupQuotasEntityResource> GetGroupQuotasEntity(string groupQuotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.GroupQuotasEntityResource>> GetGroupQuotasEntityAsync(string groupQuotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource> GetQuotaAllocationRequestStatus(string subscriptionId, string groupQuotaName, string allocationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource>> GetQuotaAllocationRequestStatusAsync(string subscriptionId, string groupQuotaName, string allocationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Quota.QuotaAllocationRequestStatusCollection GetQuotaAllocationRequestStatuses() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource> GetQuotaAllocationRequestStatusesByResourceProvider(string subscriptionId, string groupQuotaName, string resourceProviderName, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource> GetQuotaAllocationRequestStatusesByResourceProviderAsync(string subscriptionId, string groupQuotaName, string resourceProviderName, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationResource> GetSubscriptionQuotaAllocation(string subscriptionId, string groupQuotaName, string resourceName, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.SubscriptionQuotaAllocationResource>> GetSubscriptionQuotaAllocationAsync(string subscriptionId, string groupQuotaName, string resourceName, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Quota.SubscriptionQuotaAllocationCollection GetSubscriptionQuotaAllocations(string subscriptionId, string groupQuotaName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource> UpdateGroupQuotaSubscriptionAllocationRequest(Azure.WaitUntil waitUntil, string subscriptionId, string groupQuotaName, string resourceProviderName, string resourceName, Azure.ResourceManager.Quota.QuotaAllocationRequestStatusData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.QuotaAllocationRequestStatusResource>> UpdateGroupQuotaSubscriptionAllocationRequestAsync(Azure.WaitUntil waitUntil, string subscriptionId, string groupQuotaName, string resourceProviderName, string resourceName, Azure.ResourceManager.Quota.QuotaAllocationRequestStatusData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class AdditionalAttributes : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.AdditionalAttributes>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.AdditionalAttributes>
    {
        public AdditionalAttributes(Azure.ResourceManager.Quota.Models.GroupingId groupId) { }
        public Azure.ResourceManager.Quota.Models.EnvironmentType? Environment { get { throw null; } set { } }
        public Azure.ResourceManager.Quota.Models.GroupingId GroupId { get { throw null; } set { } }
        Azure.ResourceManager.Quota.Models.AdditionalAttributes System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.AdditionalAttributes>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.AdditionalAttributes>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.AdditionalAttributes System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.AdditionalAttributes>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.AdditionalAttributes>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.AdditionalAttributes>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdditionalAttributesPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.AdditionalAttributesPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.AdditionalAttributesPatch>
    {
        public AdditionalAttributesPatch() { }
        public Azure.ResourceManager.Quota.Models.EnvironmentType? Environment { get { throw null; } set { } }
        public Azure.ResourceManager.Quota.Models.GroupingId GroupId { get { throw null; } set { } }
        Azure.ResourceManager.Quota.Models.AdditionalAttributesPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.AdditionalAttributesPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.AdditionalAttributesPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.AdditionalAttributesPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.AdditionalAttributesPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.AdditionalAttributesPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.AdditionalAttributesPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AllocatedToSubscription : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.AllocatedToSubscription>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.AllocatedToSubscription>
    {
        internal AllocatedToSubscription() { }
        public long? QuotaAllocated { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        Azure.ResourceManager.Quota.Models.AllocatedToSubscription System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.AllocatedToSubscription>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.AllocatedToSubscription>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.AllocatedToSubscription System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.AllocatedToSubscription>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.AllocatedToSubscription>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.AllocatedToSubscription>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmQuotaModelFactory
    {
        public static Azure.ResourceManager.Quota.Models.AllocatedToSubscription AllocatedToSubscription(string subscriptionId = null, long? quotaAllocated = default(long?)) { throw null; }
        public static Azure.ResourceManager.Quota.CurrentQuotaLimitBaseData CurrentQuotaLimitBaseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Quota.Models.QuotaProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Quota.CurrentUsagesBaseData CurrentUsagesBaseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Quota.Models.QuotaUsagesProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.GroupQuotaDetails GroupQuotaDetails(string region = null, long? limit = default(long?), string comment = null, string unit = null, long? availableLimit = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.Models.AllocatedToSubscription> allocatedToSubscriptionsValue = null, string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.Quota.GroupQuotaLimitData GroupQuotaLimitData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Quota.Models.GroupQuotaDetails properties = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.GroupQuotaRequestBase GroupQuotaRequestBase(long? limit = default(long?), string region = null, string comments = null, string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.Quota.GroupQuotasEnforcementResponseData GroupQuotasEnforcementResponseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Quota.Models.GroupQuotasEnforcementResponseProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.GroupQuotasEnforcementResponseProperties GroupQuotasEnforcementResponseProperties(Azure.ResourceManager.Quota.Models.EnforcementState? enforcementEnabled = default(Azure.ResourceManager.Quota.Models.EnforcementState?), Azure.ResourceManager.Quota.Models.RequestState? provisioningState = default(Azure.ResourceManager.Quota.Models.RequestState?), string faultCode = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.GroupQuotasEntityBase GroupQuotasEntityBase(string displayName = null, Azure.ResourceManager.Quota.Models.AdditionalAttributes additionalAttributes = null, Azure.ResourceManager.Quota.Models.RequestState? provisioningState = default(Azure.ResourceManager.Quota.Models.RequestState?)) { throw null; }
        public static Azure.ResourceManager.Quota.Models.GroupQuotasEntityBasePatch GroupQuotasEntityBasePatch(string displayName = null, Azure.ResourceManager.Quota.Models.AdditionalAttributesPatch additionalAttributes = null, Azure.ResourceManager.Quota.Models.RequestState? provisioningState = default(Azure.ResourceManager.Quota.Models.RequestState?)) { throw null; }
        public static Azure.ResourceManager.Quota.GroupQuotasEntityData GroupQuotasEntityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Quota.Models.GroupQuotasEntityBase properties = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.GroupQuotasEntityPatch GroupQuotasEntityPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Quota.Models.GroupQuotasEntityBasePatch properties = null) { throw null; }
        public static Azure.ResourceManager.Quota.GroupQuotaSubscriptionIdData GroupQuotaSubscriptionIdData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionIdProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionIdProperties GroupQuotaSubscriptionIdProperties(string subscriptionId = null, Azure.ResourceManager.Quota.Models.RequestState? provisioningState = default(Azure.ResourceManager.Quota.Models.RequestState?)) { throw null; }
        public static Azure.ResourceManager.Quota.GroupQuotaSubscriptionRequestStatusData GroupQuotaSubscriptionRequestStatusData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionRequestStatusProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionRequestStatusProperties GroupQuotaSubscriptionRequestStatusProperties(string subscriptionId = null, System.DateTimeOffset? requestSubmitOn = default(System.DateTimeOffset?), Azure.ResourceManager.Quota.Models.RequestState? provisioningState = default(Azure.ResourceManager.Quota.Models.RequestState?)) { throw null; }
        public static Azure.ResourceManager.Quota.Models.GroupQuotaUsagesBase GroupQuotaUsagesBase(long? limit = default(long?), long? usages = default(long?), string unit = null, string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.QuotaAllocationRequestBase QuotaAllocationRequestBase(long? limit = default(long?), string region = null, string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.Quota.QuotaAllocationRequestStatusData QuotaAllocationRequestStatusData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Quota.Models.QuotaAllocationRequestBase requestedResource = null, System.DateTimeOffset? requestSubmitOn = default(System.DateTimeOffset?), Azure.ResourceManager.Quota.Models.RequestState? provisioningState = default(Azure.ResourceManager.Quota.Models.RequestState?), string faultCode = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.QuotaOperationDisplay QuotaOperationDisplay(string provider = null, string resource = null, string operation = null, string description = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.QuotaOperationResult QuotaOperationResult(string name = null, Azure.ResourceManager.Quota.Models.QuotaOperationDisplay display = null, string origin = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.QuotaProperties QuotaProperties(Azure.ResourceManager.Quota.Models.QuotaLimitJsonObject limit = null, string unit = null, Azure.ResourceManager.Quota.Models.QuotaRequestResourceName name = null, string resourceTypeName = null, System.TimeSpan? quotaPeriod = default(System.TimeSpan?), bool? isQuotaApplicable = default(bool?), System.BinaryData properties = null) { throw null; }
        public static Azure.ResourceManager.Quota.QuotaRequestDetailData QuotaRequestDetailData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Quota.Models.QuotaRequestState? provisioningState = default(Azure.ResourceManager.Quota.Models.QuotaRequestState?), string message = null, Azure.ResourceManager.Quota.Models.ServiceErrorDetail error = null, System.DateTimeOffset? requestSubmitOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.Models.QuotaSubRequestDetail> value = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.QuotaRequestResourceName QuotaRequestResourceName(string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.QuotaSubRequestDetail QuotaSubRequestDetail(Azure.ResourceManager.Quota.Models.QuotaRequestResourceName name = null, string resourceTypeName = null, string unit = null, Azure.ResourceManager.Quota.Models.QuotaRequestState? provisioningState = default(Azure.ResourceManager.Quota.Models.QuotaRequestState?), string message = null, System.Guid? subRequestId = default(System.Guid?), Azure.ResourceManager.Quota.Models.QuotaLimitJsonObject limit = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.QuotaUsagesObject QuotaUsagesObject(int value = 0, Azure.ResourceManager.Quota.Models.QuotaUsagesType? usagesType = default(Azure.ResourceManager.Quota.Models.QuotaUsagesType?)) { throw null; }
        public static Azure.ResourceManager.Quota.Models.QuotaUsagesProperties QuotaUsagesProperties(Azure.ResourceManager.Quota.Models.QuotaUsagesObject usages = null, string unit = null, Azure.ResourceManager.Quota.Models.QuotaRequestResourceName name = null, string resourceTypeName = null, System.TimeSpan? quotaPeriod = default(System.TimeSpan?), bool? isQuotaApplicable = default(bool?), System.BinaryData properties = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.ResourceUsages ResourceUsages(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Quota.Models.GroupQuotaUsagesBase properties = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.ServiceErrorDetail ServiceErrorDetail(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Quota.SubmittedResourceRequestStatusData SubmittedResourceRequestStatusData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Quota.Models.SubmittedResourceRequestStatusProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.SubmittedResourceRequestStatusProperties SubmittedResourceRequestStatusProperties(Azure.ResourceManager.Quota.Models.GroupQuotaRequestBase requestedResource = null, System.DateTimeOffset? requestSubmitOn = default(System.DateTimeOffset?), Azure.ResourceManager.Quota.Models.RequestState? provisioningState = default(Azure.ResourceManager.Quota.Models.RequestState?), string faultCode = null) { throw null; }
        public static Azure.ResourceManager.Quota.SubscriptionQuotaAllocationData SubscriptionQuotaAllocationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Quota.Models.SubscriptionQuotaDetails properties = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.SubscriptionQuotaDetails SubscriptionQuotaDetails(string region = null, long? limit = default(long?), long? shareableQuota = default(long?), string value = null, string localizedValue = null) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnvironmentType : System.IEquatable<Azure.ResourceManager.Quota.Models.EnvironmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnvironmentType(string value) { throw null; }
        public static Azure.ResourceManager.Quota.Models.EnvironmentType NonProduction { get { throw null; } }
        public static Azure.ResourceManager.Quota.Models.EnvironmentType Production { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Quota.Models.EnvironmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Quota.Models.EnvironmentType left, Azure.ResourceManager.Quota.Models.EnvironmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Quota.Models.EnvironmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Quota.Models.EnvironmentType left, Azure.ResourceManager.Quota.Models.EnvironmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GroupingId : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupingId>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupingId>
    {
        public GroupingId() { }
        public Azure.ResourceManager.Quota.Models.GroupingIdType? GroupingIdType { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.ResourceManager.Quota.Models.GroupingId System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupingId>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupingId>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupingId System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupingId>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupingId>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupingId>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GroupingIdType : System.IEquatable<Azure.ResourceManager.Quota.Models.GroupingIdType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GroupingIdType(string value) { throw null; }
        public static Azure.ResourceManager.Quota.Models.GroupingIdType BillingId { get { throw null; } }
        public static Azure.ResourceManager.Quota.Models.GroupingIdType ServiceTreeId { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Quota.Models.GroupingIdType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Quota.Models.GroupingIdType left, Azure.ResourceManager.Quota.Models.GroupingIdType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Quota.Models.GroupingIdType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Quota.Models.GroupingIdType left, Azure.ResourceManager.Quota.Models.GroupingIdType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GroupQuotaDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaDetails>
    {
        public GroupQuotaDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Quota.Models.AllocatedToSubscription> AllocatedToSubscriptionsValue { get { throw null; } }
        public long? AvailableLimit { get { throw null; } }
        public string Comment { get { throw null; } set { } }
        public long? Limit { get { throw null; } set { } }
        public string LocalizedValue { get { throw null; } }
        public string Region { get { throw null; } set { } }
        public string Unit { get { throw null; } }
        public string Value { get { throw null; } }
        Azure.ResourceManager.Quota.Models.GroupQuotaDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotaDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotaRequestBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaRequestBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaRequestBase>
    {
        public GroupQuotaRequestBase() { }
        public string Comments { get { throw null; } set { } }
        public long? Limit { get { throw null; } set { } }
        public string LocalizedValue { get { throw null; } }
        public string Region { get { throw null; } set { } }
        public string Value { get { throw null; } }
        Azure.ResourceManager.Quota.Models.GroupQuotaRequestBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaRequestBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaRequestBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotaRequestBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaRequestBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaRequestBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaRequestBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotasEnforcementResponseProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotasEnforcementResponseProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotasEnforcementResponseProperties>
    {
        public GroupQuotasEnforcementResponseProperties() { }
        public Azure.ResourceManager.Quota.Models.EnforcementState? EnforcementEnabled { get { throw null; } set { } }
        public string FaultCode { get { throw null; } }
        public Azure.ResourceManager.Quota.Models.RequestState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.Quota.Models.GroupQuotasEnforcementResponseProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotasEnforcementResponseProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotasEnforcementResponseProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotasEnforcementResponseProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotasEnforcementResponseProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotasEnforcementResponseProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotasEnforcementResponseProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotasEntityBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityBase>
    {
        public GroupQuotasEntityBase() { }
        public Azure.ResourceManager.Quota.Models.AdditionalAttributes AdditionalAttributes { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Quota.Models.RequestState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.Quota.Models.GroupQuotasEntityBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotasEntityBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotasEntityBasePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityBasePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityBasePatch>
    {
        public GroupQuotasEntityBasePatch() { }
        public Azure.ResourceManager.Quota.Models.AdditionalAttributesPatch AdditionalAttributes { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Quota.Models.RequestState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.Quota.Models.GroupQuotasEntityBasePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityBasePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityBasePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotasEntityBasePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityBasePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityBasePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityBasePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotasEntityPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityPatch>
    {
        public GroupQuotasEntityPatch() { }
        public Azure.ResourceManager.Quota.Models.GroupQuotasEntityBasePatch Properties { get { throw null; } set { } }
        Azure.ResourceManager.Quota.Models.GroupQuotasEntityPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotasEntityPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotasEntityPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotaSubscriptionIdProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionIdProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionIdProperties>
    {
        public GroupQuotaSubscriptionIdProperties() { }
        public Azure.ResourceManager.Quota.Models.RequestState? ProvisioningState { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionIdProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionIdProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionIdProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionIdProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionIdProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionIdProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionIdProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotaSubscriptionRequestStatusProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionRequestStatusProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionRequestStatusProperties>
    {
        public GroupQuotaSubscriptionRequestStatusProperties() { }
        public Azure.ResourceManager.Quota.Models.RequestState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? RequestSubmitOn { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionRequestStatusProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionRequestStatusProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionRequestStatusProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionRequestStatusProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionRequestStatusProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionRequestStatusProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaSubscriptionRequestStatusProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupQuotaUsagesBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaUsagesBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaUsagesBase>
    {
        public GroupQuotaUsagesBase() { }
        public long? Limit { get { throw null; } set { } }
        public string LocalizedValue { get { throw null; } }
        public string Unit { get { throw null; } }
        public long? Usages { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.ResourceManager.Quota.Models.GroupQuotaUsagesBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaUsagesBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.GroupQuotaUsagesBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.GroupQuotaUsagesBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaUsagesBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaUsagesBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.GroupQuotaUsagesBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuotaAllocationRequestBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaAllocationRequestBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaAllocationRequestBase>
    {
        public QuotaAllocationRequestBase() { }
        public long? Limit { get { throw null; } set { } }
        public string LocalizedValue { get { throw null; } }
        public string Region { get { throw null; } set { } }
        public string Value { get { throw null; } }
        Azure.ResourceManager.Quota.Models.QuotaAllocationRequestBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaAllocationRequestBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaAllocationRequestBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.QuotaAllocationRequestBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaAllocationRequestBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaAllocationRequestBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaAllocationRequestBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class QuotaLimitJsonObject : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.QuotaLimitJsonObject>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.QuotaLimitJsonObject>
    {
        protected QuotaLimitJsonObject() { }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequestState : System.IEquatable<Azure.ResourceManager.Quota.Models.RequestState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequestState(string value) { throw null; }
        public static Azure.ResourceManager.Quota.Models.RequestState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Quota.Models.RequestState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Quota.Models.RequestState Created { get { throw null; } }
        public static Azure.ResourceManager.Quota.Models.RequestState Failed { get { throw null; } }
        public static Azure.ResourceManager.Quota.Models.RequestState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Quota.Models.RequestState Invalid { get { throw null; } }
        public static Azure.ResourceManager.Quota.Models.RequestState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Quota.Models.RequestState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Quota.Models.RequestState left, Azure.ResourceManager.Quota.Models.RequestState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Quota.Models.RequestState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Quota.Models.RequestState left, Azure.ResourceManager.Quota.Models.RequestState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceUsages : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.ResourceUsages>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.ResourceUsages>
    {
        public ResourceUsages() { }
        public Azure.ResourceManager.Quota.Models.GroupQuotaUsagesBase Properties { get { throw null; } set { } }
        Azure.ResourceManager.Quota.Models.ResourceUsages System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.ResourceUsages>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.ResourceUsages>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.ResourceUsages System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.ResourceUsages>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.ResourceUsages>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.ResourceUsages>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceErrorDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.ServiceErrorDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.ServiceErrorDetail>
    {
        internal ServiceErrorDetail() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        Azure.ResourceManager.Quota.Models.ServiceErrorDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.ServiceErrorDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.ServiceErrorDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.ServiceErrorDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.ServiceErrorDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.ServiceErrorDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.ServiceErrorDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubmittedResourceRequestStatusProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.SubmittedResourceRequestStatusProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.SubmittedResourceRequestStatusProperties>
    {
        public SubmittedResourceRequestStatusProperties() { }
        public string FaultCode { get { throw null; } }
        public Azure.ResourceManager.Quota.Models.RequestState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Quota.Models.GroupQuotaRequestBase RequestedResource { get { throw null; } set { } }
        public System.DateTimeOffset? RequestSubmitOn { get { throw null; } }
        Azure.ResourceManager.Quota.Models.SubmittedResourceRequestStatusProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.SubmittedResourceRequestStatusProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.SubmittedResourceRequestStatusProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.SubmittedResourceRequestStatusProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.SubmittedResourceRequestStatusProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.SubmittedResourceRequestStatusProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.SubmittedResourceRequestStatusProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubscriptionQuotaDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaDetails>
    {
        public SubscriptionQuotaDetails() { }
        public long? Limit { get { throw null; } set { } }
        public string LocalizedValue { get { throw null; } }
        public string Region { get { throw null; } set { } }
        public long? ShareableQuota { get { throw null; } }
        public string Value { get { throw null; } }
        Azure.ResourceManager.Quota.Models.SubscriptionQuotaDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Quota.Models.SubscriptionQuotaDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Quota.Models.SubscriptionQuotaDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
