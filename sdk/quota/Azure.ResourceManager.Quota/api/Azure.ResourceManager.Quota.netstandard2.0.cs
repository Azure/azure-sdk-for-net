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
    public partial class CurrentQuotaLimitBaseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CurrentQuotaLimitBaseResource() { }
        public virtual Azure.ResourceManager.Quota.CurrentQuotaLimitBaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string resourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class CurrentUsagesBaseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CurrentUsagesBaseResource() { }
        public virtual Azure.ResourceManager.Quota.CurrentUsagesBaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string resourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.CurrentUsagesBaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.CurrentUsagesBaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.Pageable<Azure.ResourceManager.Quota.Models.QuotaOperationResult> GetQuotaOperations(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Quota.Models.QuotaOperationResult> GetQuotaOperationsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Quota.QuotaRequestDetailResource> GetQuotaRequestDetail(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.QuotaRequestDetailResource>> GetQuotaRequestDetailAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Quota.QuotaRequestDetailResource GetQuotaRequestDetailResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Quota.QuotaRequestDetailCollection GetQuotaRequestDetails(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
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
    public partial class QuotaRequestDetailResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected QuotaRequestDetailResource() { }
        public virtual Azure.ResourceManager.Quota.QuotaRequestDetailData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.QuotaRequestDetailResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.QuotaRequestDetailResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.Quota.QuotaRequestDetailResource> GetQuotaRequestDetail(Azure.Core.ResourceIdentifier scope, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.QuotaRequestDetailResource>> GetQuotaRequestDetailAsync(Azure.Core.ResourceIdentifier scope, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Quota.QuotaRequestDetailResource GetQuotaRequestDetailResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Quota.QuotaRequestDetailCollection GetQuotaRequestDetails(Azure.Core.ResourceIdentifier scope) { throw null; }
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
        public static Azure.ResourceManager.Quota.Models.QuotaOperationDisplay QuotaOperationDisplay(string provider = null, string resource = null, string operation = null, string description = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.QuotaOperationResult QuotaOperationResult(string name = null, Azure.ResourceManager.Quota.Models.QuotaOperationDisplay display = null, string origin = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.QuotaProperties QuotaProperties(Azure.ResourceManager.Quota.Models.QuotaLimitJsonObject limit = null, string unit = null, Azure.ResourceManager.Quota.Models.QuotaRequestResourceName name = null, string resourceTypeName = null, System.TimeSpan? quotaPeriod = default(System.TimeSpan?), bool? isQuotaApplicable = default(bool?), System.BinaryData properties = null) { throw null; }
        public static Azure.ResourceManager.Quota.QuotaRequestDetailData QuotaRequestDetailData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Quota.Models.QuotaRequestState? provisioningState = default(Azure.ResourceManager.Quota.Models.QuotaRequestState?), string message = null, Azure.ResourceManager.Quota.Models.ServiceErrorDetail error = null, System.DateTimeOffset? requestSubmitOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.Models.QuotaSubRequestDetail> value = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.QuotaRequestResourceName QuotaRequestResourceName(string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.QuotaSubRequestDetail QuotaSubRequestDetail(Azure.ResourceManager.Quota.Models.QuotaRequestResourceName name = null, string resourceTypeName = null, string unit = null, Azure.ResourceManager.Quota.Models.QuotaRequestState? provisioningState = default(Azure.ResourceManager.Quota.Models.QuotaRequestState?), string message = null, System.Guid? subRequestId = default(System.Guid?), Azure.ResourceManager.Quota.Models.QuotaLimitJsonObject limit = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.QuotaUsagesObject QuotaUsagesObject(int value = 0, Azure.ResourceManager.Quota.Models.QuotaUsagesType? usagesType = default(Azure.ResourceManager.Quota.Models.QuotaUsagesType?)) { throw null; }
        public static Azure.ResourceManager.Quota.Models.QuotaUsagesProperties QuotaUsagesProperties(Azure.ResourceManager.Quota.Models.QuotaUsagesObject usages = null, string unit = null, Azure.ResourceManager.Quota.Models.QuotaRequestResourceName name = null, string resourceTypeName = null, System.TimeSpan? quotaPeriod = default(System.TimeSpan?), bool? isQuotaApplicable = default(bool?), System.BinaryData properties = null) { throw null; }
        public static Azure.ResourceManager.Quota.Models.ServiceErrorDetail ServiceErrorDetail(string code = null, string message = null) { throw null; }
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
}
