namespace Azure.ResourceManager.Marketplace
{
    public partial class AzureResourceManagerMarketplaceContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerMarketplaceContext() { }
        public static Azure.ResourceManager.Marketplace.AzureResourceManagerMarketplaceContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class MarketplaceAdminApprovalRequestCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestResource>, System.Collections.IEnumerable
    {
        protected MarketplaceAdminApprovalRequestCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string adminRequestApprovalId, Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string adminRequestApprovalId, Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string adminRequestApprovalId, string publisherId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string adminRequestApprovalId, string publisherId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestResource> Get(string adminRequestApprovalId, string publisherId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestResource>> GetAsync(string adminRequestApprovalId, string publisherId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestResource> GetIfExists(string adminRequestApprovalId, string publisherId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestResource>> GetIfExistsAsync(string adminRequestApprovalId, string publisherId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MarketplaceAdminApprovalRequestData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestData>
    {
        public MarketplaceAdminApprovalRequestData() { }
        public Azure.ResourceManager.Marketplace.Models.MarketplaceAdminAction? AdminAction { get { throw null; } set { } }
        public string Administrator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ApprovedPlans { get { throw null; } }
        public System.Collections.Generic.IList<System.Guid> CollectionIds { get { throw null; } }
        public string Comment { get { throw null; } set { } }
        public string DisplayName { get { throw null; } }
        public System.Uri IconUri { get { throw null; } }
        public string OfferId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.PlanRequesterDetails> Plans { get { throw null; } }
        public string PublisherId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MarketplaceAdminApprovalRequestResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MarketplaceAdminApprovalRequestResource() { }
        public virtual Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(System.Guid privateStoreId, string adminRequestApprovalId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestResource> Get(string publisherId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestResource>> GetAsync(string publisherId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MarketplaceApprovalRequestCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestResource>, System.Collections.IEnumerable
    {
        protected MarketplaceApprovalRequestCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string requestApprovalId, Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string requestApprovalId, Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string requestApprovalId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string requestApprovalId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestResource> Get(string requestApprovalId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestResource>> GetAsync(string requestApprovalId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestResource> GetIfExists(string requestApprovalId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestResource>> GetIfExistsAsync(string requestApprovalId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MarketplaceApprovalRequestData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestData>
    {
        public MarketplaceApprovalRequestData() { }
        public bool? IsClosed { get { throw null; } }
        public long? MessageCode { get { throw null; } set { } }
        public string OfferDisplayName { get { throw null; } }
        public string OfferId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Marketplace.Models.PrivateStorePlanDetails> PlansDetails { get { throw null; } }
        public string PublisherId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MarketplaceApprovalRequestResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MarketplaceApprovalRequestResource() { }
        public virtual Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(System.Guid privateStoreId, string requestApprovalId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.Models.QueryApprovalRequestResult> QueryApprovalRequest(Azure.ResourceManager.Marketplace.Models.QueryApprovalRequestContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.Models.QueryApprovalRequestResult>> QueryApprovalRequestAsync(Azure.ResourceManager.Marketplace.Models.QueryApprovalRequestContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response WithdrawPlan(Azure.ResourceManager.Marketplace.Models.WithdrawPlanContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> WithdrawPlanAsync(Azure.ResourceManager.Marketplace.Models.WithdrawPlanContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class MarketplaceExtensions
    {
        public static Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestResource GetMarketplaceAdminApprovalRequestResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestResource GetMarketplaceApprovalRequestResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Marketplace.PrivateStoreResource> GetPrivateStore(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid privateStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.PrivateStoreResource>> GetPrivateStoreAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid privateStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoResource GetPrivateStoreCollectionInfoResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Marketplace.PrivateStoreOfferResource GetPrivateStoreOfferResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Marketplace.PrivateStoreResource GetPrivateStoreResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Marketplace.PrivateStoreCollection GetPrivateStores(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
    }
    public partial class PrivateStoreCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Marketplace.PrivateStoreResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.PrivateStoreResource>, System.Collections.IEnumerable
    {
        protected PrivateStoreCollection() { }
        public virtual Azure.ResourceManager.ArmOperation CreateOrUpdate(Azure.WaitUntil waitUntil, System.Guid privateStoreId, Azure.ResourceManager.Marketplace.PrivateStoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, System.Guid privateStoreId, Azure.ResourceManager.Marketplace.PrivateStoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(System.Guid privateStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Guid privateStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.PrivateStoreResource> Get(System.Guid privateStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Marketplace.PrivateStoreResource> GetAll(string useCache = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Marketplace.PrivateStoreResource> GetAllAsync(string useCache = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.PrivateStoreResource>> GetAsync(System.Guid privateStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Marketplace.PrivateStoreResource> GetIfExists(System.Guid privateStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Marketplace.PrivateStoreResource>> GetIfExistsAsync(System.Guid privateStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Marketplace.PrivateStoreResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Marketplace.PrivateStoreResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Marketplace.PrivateStoreResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.PrivateStoreResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateStoreCollectionInfoCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoResource>, System.Collections.IEnumerable
    {
        protected PrivateStoreCollectionInfoCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoResource> CreateOrUpdate(Azure.WaitUntil waitUntil, System.Guid collectionId, Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, System.Guid collectionId, Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(System.Guid collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Guid collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoResource> Get(System.Guid collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoResource>> GetAsync(System.Guid collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoResource> GetIfExists(System.Guid collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoResource>> GetIfExistsAsync(System.Guid collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateStoreCollectionInfoData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoData>
    {
        public PrivateStoreCollectionInfoData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.MarketplaceRule> AppliedRules { get { throw null; } }
        public System.DateTimeOffset? ApproveAllItemsModifiedOn { get { throw null; } }
        public bool? AreAllItemsApproved { get { throw null; } }
        public bool? AreAllSubscriptionsSelected { get { throw null; } set { } }
        public string Claim { get { throw null; } set { } }
        public System.Guid? CollectionId { get { throw null; } }
        public string CollectionName { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public long? NumberOfOffers { get { throw null; } }
        public System.Collections.Generic.IList<string> SubscriptionsList { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateStoreCollectionInfoResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateStoreCollectionInfoResource() { }
        public virtual Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoResource> ApproveAllItems(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoResource>> ApproveAllItemsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(System.Guid privateStoreId, System.Guid collectionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(Azure.ResourceManager.Marketplace.Models.PrivateStoreOperation? payload = default(Azure.ResourceManager.Marketplace.Models.PrivateStoreOperation?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(Azure.ResourceManager.Marketplace.Models.PrivateStoreOperation? payload = default(Azure.ResourceManager.Marketplace.Models.PrivateStoreOperation?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoResource> DisableApproveAllItems(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoResource>> DisableApproveAllItemsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Marketplace.Models.CollectionOffersByContext> GetPrivateStoreCollectionOffersByContexts(Azure.ResourceManager.Marketplace.Models.CollectionOffersByAllContextsPayload payload = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Marketplace.Models.CollectionOffersByContext> GetPrivateStoreCollectionOffersByContextsAsync(Azure.ResourceManager.Marketplace.Models.CollectionOffersByAllContextsPayload payload = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.PrivateStoreOfferResource> GetPrivateStoreOffer(string offerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.PrivateStoreOfferResource>> GetPrivateStoreOfferAsync(string offerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Marketplace.PrivateStoreOfferCollection GetPrivateStoreOffers() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Marketplace.Models.MarketplaceRule> QueryRules(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Marketplace.Models.MarketplaceRule> QueryRulesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetCollectionRules(Azure.ResourceManager.Marketplace.Models.SetRulesContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetCollectionRulesAsync(Azure.ResourceManager.Marketplace.Models.SetRulesContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.Models.TransferOffersResult> TransferOffers(Azure.ResourceManager.Marketplace.Models.TransferOffersContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.Models.TransferOffersResult>> TransferOffersAsync(Azure.ResourceManager.Marketplace.Models.TransferOffersContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateStoreData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.PrivateStoreData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.PrivateStoreData>
    {
        public PrivateStoreData() { }
        public Azure.ResourceManager.Marketplace.Models.PrivateStoreAvailability? Availability { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Branding { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Guid> CollectionIds { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public bool? IsGov { get { throw null; } set { } }
        public System.Guid? PrivateStoreId { get { throw null; } }
        public string PrivateStoreName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Marketplace.Models.NotificationRecipient> Recipients { get { throw null; } }
        public bool? SendToAllMarketplaceAdmins { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.PrivateStoreData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.PrivateStoreData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.PrivateStoreData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.PrivateStoreData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.PrivateStoreData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.PrivateStoreData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.PrivateStoreData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateStoreOfferCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Marketplace.PrivateStoreOfferResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.PrivateStoreOfferResource>, System.Collections.IEnumerable
    {
        protected PrivateStoreOfferCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Marketplace.PrivateStoreOfferResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string offerId, Azure.ResourceManager.Marketplace.PrivateStoreOfferData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Marketplace.PrivateStoreOfferResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string offerId, Azure.ResourceManager.Marketplace.PrivateStoreOfferData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string offerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string offerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.PrivateStoreOfferResource> Get(string offerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Marketplace.PrivateStoreOfferResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Marketplace.PrivateStoreOfferResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.PrivateStoreOfferResource>> GetAsync(string offerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Marketplace.PrivateStoreOfferResource> GetIfExists(string offerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Marketplace.PrivateStoreOfferResource>> GetIfExistsAsync(string offerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Marketplace.PrivateStoreOfferResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Marketplace.PrivateStoreOfferResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Marketplace.PrivateStoreOfferResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.PrivateStoreOfferResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateStoreOfferData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.PrivateStoreOfferData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.PrivateStoreOfferData>
    {
        public PrivateStoreOfferData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.Uri> IconFileUris { get { throw null; } }
        public bool? IsUpdateSuppressedDueToIdempotence { get { throw null; } set { } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public string OfferDisplayName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Marketplace.Models.PrivateStorePlan> Plans { get { throw null; } }
        public System.Guid? PrivateStoreId { get { throw null; } }
        public string PublisherDisplayName { get { throw null; } }
        public System.Collections.Generic.IList<string> SpecificPlanIdsLimitation { get { throw null; } }
        public string UniqueOfferId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.PrivateStoreOfferData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.PrivateStoreOfferData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.PrivateStoreOfferData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.PrivateStoreOfferData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.PrivateStoreOfferData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.PrivateStoreOfferData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.PrivateStoreOfferData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateStoreOfferResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.PrivateStoreOfferData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.PrivateStoreOfferData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateStoreOfferResource() { }
        public virtual Azure.ResourceManager.Marketplace.PrivateStoreOfferData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(System.Guid privateStoreId, System.Guid collectionId, string offerId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(Azure.ResourceManager.Marketplace.Models.PrivateStoreOperation? payload = default(Azure.ResourceManager.Marketplace.Models.PrivateStoreOperation?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(Azure.ResourceManager.Marketplace.Models.PrivateStoreOperation? payload = default(Azure.ResourceManager.Marketplace.Models.PrivateStoreOperation?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.PrivateStoreOfferResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.PrivateStoreOfferResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Marketplace.PrivateStoreOfferData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.PrivateStoreOfferData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.PrivateStoreOfferData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.PrivateStoreOfferData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.PrivateStoreOfferData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.PrivateStoreOfferData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.PrivateStoreOfferData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Marketplace.PrivateStoreOfferResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Marketplace.PrivateStoreOfferData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Marketplace.PrivateStoreOfferResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Marketplace.PrivateStoreOfferData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.PrivateStoreOfferResource> UpsertOfferWithMultiContext(Azure.ResourceManager.Marketplace.Models.MultiContextAndPlansContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.PrivateStoreOfferResource>> UpsertOfferWithMultiContextAsync(Azure.ResourceManager.Marketplace.Models.MultiContextAndPlansContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateStoreResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.PrivateStoreData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.PrivateStoreData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateStoreResource() { }
        public virtual Azure.ResourceManager.Marketplace.PrivateStoreData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response AcknowledgeOfferNotification(string offerId, Azure.ResourceManager.Marketplace.Models.AcknowledgeOfferNotificationContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AcknowledgeOfferNotificationAsync(string offerId, Azure.ResourceManager.Marketplace.Models.AcknowledgeOfferNotificationContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.Models.AnyExistingOffersInTheCollectionsResult> AnyExistingOffersInTheCollections(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.Models.AnyExistingOffersInTheCollectionsResult>> AnyExistingOffersInTheCollectionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(System.Guid privateStoreId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Marketplace.Models.MarketplaceSubscription> FetchAllMarketplaceSubscriptions(string nextPageToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Marketplace.Models.MarketplaceSubscription> FetchAllMarketplaceSubscriptionsAsync(string nextPageToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.Models.PrivateStoreBillingAccountsResult> FetchBillingAccounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.Models.PrivateStoreBillingAccountsResult>> FetchBillingAccountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.Models.CollectionsToSubscriptionsMappingResult> FetchCollectionsToSubscriptionsMapping(Azure.ResourceManager.Marketplace.Models.CollectionsToSubscriptionsMappingContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.Models.CollectionsToSubscriptionsMappingResult>> FetchCollectionsToSubscriptionsMappingAsync(Azure.ResourceManager.Marketplace.Models.CollectionsToSubscriptionsMappingContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.PrivateStoreResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.PrivateStoreResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestResource> GetMarketplaceAdminApprovalRequest(string adminRequestApprovalId, string publisherId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestResource>> GetMarketplaceAdminApprovalRequestAsync(string adminRequestApprovalId, string publisherId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestCollection GetMarketplaceAdminApprovalRequests() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestResource> GetMarketplaceApprovalRequest(string requestApprovalId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestResource>> GetMarketplaceApprovalRequestAsync(string requestApprovalId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestCollection GetMarketplaceApprovalRequests() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.Models.NewPlanNotificationListResult> GetNewPlansNotifications(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.Models.NewPlanNotificationListResult>> GetNewPlansNotificationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoResource> GetPrivateStoreCollectionInfo(System.Guid collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoResource>> GetPrivateStoreCollectionInfoAsync(System.Guid collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoCollection GetPrivateStoreCollectionInfos() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.Models.StopSellOffersPlansNotificationsList> GetStopSellOffersPlansNotifications(Azure.ResourceManager.Marketplace.Models.StopSellSubscriptions stopSellSubscriptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.Models.StopSellOffersPlansNotificationsList>> GetStopSellOffersPlansNotificationsAsync(Azure.ResourceManager.Marketplace.Models.StopSellSubscriptions stopSellSubscriptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.Models.SubscriptionsContextList> GetSubscriptionsContext(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.Models.SubscriptionsContextList>> GetSubscriptionsContextAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.Models.BulkCollectionsActionResult> PerformActionOnBulkCollections(Azure.ResourceManager.Marketplace.Models.BulkCollectionsActionContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.Models.BulkCollectionsActionResult>> PerformActionOnBulkCollectionsAsync(Azure.ResourceManager.Marketplace.Models.BulkCollectionsActionContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansResult> QueryApprovedPlans(Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansResult>> QueryApprovedPlansAsync(Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.Models.PrivateStoreNotificationsState> QueryNotificationsState(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.Models.PrivateStoreNotificationsState>> QueryNotificationsStateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Marketplace.Models.PrivateStoreOfferResult> QueryOffers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Marketplace.Models.PrivateStoreOfferResult> QueryOffersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Marketplace.Models.PrivateStoreOfferResult> QueryUserOffers(Azure.ResourceManager.Marketplace.Models.QueryUserOffersContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Marketplace.Models.PrivateStoreOfferResult> QueryUserOffersAsync(Azure.ResourceManager.Marketplace.Models.QueryUserOffersContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Marketplace.Models.MarketplaceRule> QueryUserRules(Azure.ResourceManager.Marketplace.Models.QueryUserRulesContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Marketplace.Models.MarketplaceRule> QueryUserRulesAsync(Azure.ResourceManager.Marketplace.Models.QueryUserRulesContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Marketplace.PrivateStoreData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.PrivateStoreData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.PrivateStoreData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.PrivateStoreData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.PrivateStoreData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.PrivateStoreData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.PrivateStoreData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Marketplace.PrivateStoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Marketplace.PrivateStoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Marketplace.Mocking
{
    public partial class MockableMarketplaceArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableMarketplaceArmClient() { }
        public virtual Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestResource GetMarketplaceAdminApprovalRequestResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestResource GetMarketplaceApprovalRequestResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoResource GetPrivateStoreCollectionInfoResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Marketplace.PrivateStoreOfferResource GetPrivateStoreOfferResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Marketplace.PrivateStoreResource GetPrivateStoreResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableMarketplaceTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMarketplaceTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.PrivateStoreResource> GetPrivateStore(System.Guid privateStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.PrivateStoreResource>> GetPrivateStoreAsync(System.Guid privateStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Marketplace.PrivateStoreCollection GetPrivateStores() { throw null; }
    }
}
namespace Azure.ResourceManager.Marketplace.Models
{
    public partial class AcknowledgeOfferNotificationContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.AcknowledgeOfferNotificationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.AcknowledgeOfferNotificationContent>
    {
        public AcknowledgeOfferNotificationContent() { }
        public System.Collections.Generic.IList<string> AddPlans { get { throw null; } }
        public bool? IsAcknowledgeActionFlagEnabled { get { throw null; } set { } }
        public bool? IsDismissActionFlagEnabled { get { throw null; } set { } }
        public bool? IsRemoveOfferActionFlagEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RemovePlans { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.AcknowledgeOfferNotificationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.AcknowledgeOfferNotificationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.AcknowledgeOfferNotificationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.AcknowledgeOfferNotificationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.AcknowledgeOfferNotificationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.AcknowledgeOfferNotificationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.AcknowledgeOfferNotificationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnyExistingOffersInTheCollectionsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.AnyExistingOffersInTheCollectionsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.AnyExistingOffersInTheCollectionsResult>
    {
        internal AnyExistingOffersInTheCollectionsResult() { }
        public bool? Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.AnyExistingOffersInTheCollectionsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.AnyExistingOffersInTheCollectionsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.AnyExistingOffersInTheCollectionsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.AnyExistingOffersInTheCollectionsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.AnyExistingOffersInTheCollectionsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.AnyExistingOffersInTheCollectionsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.AnyExistingOffersInTheCollectionsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmMarketplaceModelFactory
    {
        public static Azure.ResourceManager.Marketplace.Models.AnyExistingOffersInTheCollectionsResult AnyExistingOffersInTheCollectionsResult(bool? value = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.BulkCollectionsActionResult BulkCollectionsActionResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.Models.PrivateStoreCollectionDetails> succeeded = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.Models.PrivateStoreCollectionDetails> failed = null) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.CollectionOffersByContext CollectionOffersByContext(string context = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.Models.PrivateStoreOfferResult> value = null) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.CollectionsSubscriptionsMappingDetails CollectionsSubscriptionsMappingDetails(string collectionName = null, System.Collections.Generic.IEnumerable<string> subscriptions = null) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.CollectionsToSubscriptionsMappingResult CollectionsToSubscriptionsMappingResult(System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Marketplace.Models.CollectionsSubscriptionsMappingDetails> details = null) { throw null; }
        public static Azure.ResourceManager.Marketplace.MarketplaceAdminApprovalRequestData MarketplaceAdminApprovalRequestData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string offerId = null, string displayName = null, string publisherId = null, Azure.ResourceManager.Marketplace.Models.MarketplaceAdminAction? adminAction = default(Azure.ResourceManager.Marketplace.Models.MarketplaceAdminAction?), System.Collections.Generic.IEnumerable<string> approvedPlans = null, string comment = null, string administrator = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.Models.PlanRequesterDetails> plans = null, System.Collections.Generic.IEnumerable<System.Guid> collectionIds = null, System.Uri iconUri = null) { throw null; }
        public static Azure.ResourceManager.Marketplace.MarketplaceApprovalRequestData MarketplaceApprovalRequestData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string offerId = null, string offerDisplayName = null, string publisherId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.Models.PrivateStorePlanDetails> plansDetails = null, bool? isClosed = default(bool?), long? messageCode = default(long?)) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.MarketplaceSubscription MarketplaceSubscription(string id = null, string subscriptionId = null, string displayName = null, Azure.ResourceManager.Marketplace.Models.MarketplaceSubscriptionState? state = default(Azure.ResourceManager.Marketplace.Models.MarketplaceSubscriptionState?)) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.NewPlanNotification NewPlanNotification(string offerId = null, string displayName = null, bool? isFuturePlansEnabled = default(bool?), long? messageCode = default(long?), System.Uri iconUri = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.Models.PlanNotificationDetails> plans = null) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.NewPlanNotificationListResult NewPlanNotificationListResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.Models.NewPlanNotification> newPlansNotifications = null) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.NotificationRecipient NotificationRecipient(System.Guid? principalId = default(System.Guid?), string emailAddress = null, string displayName = null) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.PlanNotificationDetails PlanNotificationDetails(string planId = null, string planDisplayName = null) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.PlanRequesterDetails PlanRequesterDetails(string planId = null, string planDisplayName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.Models.PlanRequesterInfo> requesters = null) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.PlanRequesterInfo PlanRequesterInfo(string user = null, string date = null, string justification = null, string subscriptionId = null, string subscriptionName = null) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.PrivateStoreBillingAccountsResult PrivateStoreBillingAccountsResult(System.Collections.Generic.IEnumerable<string> billingAccounts = null) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.PrivateStoreCollectionDetails PrivateStoreCollectionDetails(string collectionName = null, System.Guid? collectionId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.Marketplace.PrivateStoreCollectionInfoData PrivateStoreCollectionInfoData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid? collectionId = default(System.Guid?), string collectionName = null, string claim = null, bool? areAllSubscriptionsSelected = default(bool?), bool? areAllItemsApproved = default(bool?), System.DateTimeOffset? approveAllItemsModifiedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> subscriptionsList = null, bool? isEnabled = default(bool?), long? numberOfOffers = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.Models.MarketplaceRule> appliedRules = null) { throw null; }
        public static Azure.ResourceManager.Marketplace.PrivateStoreData PrivateStoreData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Marketplace.Models.PrivateStoreAvailability? availability = default(Azure.ResourceManager.Marketplace.Models.PrivateStoreAvailability?), System.Guid? privateStoreId = default(System.Guid?), Azure.ETag? eTag = default(Azure.ETag?), string privateStoreName = null, System.Guid? tenantId = default(System.Guid?), bool? isGov = default(bool?), System.Collections.Generic.IEnumerable<System.Guid> collectionIds = null, System.Collections.Generic.IDictionary<string, string> branding = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.Models.NotificationRecipient> recipients = null, bool? sendToAllMarketplaceAdmins = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.PrivateStoreNotificationsState PrivateStoreNotificationsState(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.Models.StopSellNotifications> stopSellNotifications = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.Models.NewPlanNotification> newNotifications = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.Models.RequestApprovalsDetails> approvalRequests = null) { throw null; }
        public static Azure.ResourceManager.Marketplace.PrivateStoreOfferData PrivateStoreOfferData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string uniqueOfferId = null, string offerDisplayName = null, string publisherDisplayName = null, Azure.ETag? eTag = default(Azure.ETag?), System.Guid? privateStoreId = default(System.Guid?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? modifiedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> specificPlanIdsLimitation = null, bool? isUpdateSuppressedDueToIdempotence = default(bool?), System.Collections.Generic.IDictionary<string, System.Uri> iconFileUris = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.Models.PrivateStorePlan> plans = null) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.PrivateStoreOfferResult PrivateStoreOfferResult(string uniqueOfferId = null, string offerDisplayName = null, string publisherDisplayName = null, Azure.ETag? eTag = default(Azure.ETag?), System.Guid? privateStoreId = default(System.Guid?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? modifiedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> specificPlanIdsLimitation = null, bool? isUpdateSuppressedDueToIdempotence = default(bool?), System.Collections.Generic.IReadOnlyDictionary<string, System.Uri> iconFileUris = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.Models.PrivateStorePlan> plans = null) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.PrivateStorePlan PrivateStorePlan(string skuId = null, string planId = null, string planDisplayName = null, Azure.ResourceManager.Marketplace.Models.PrivateStorePlanAccessibility? accessibility = default(Azure.ResourceManager.Marketplace.Models.PrivateStorePlanAccessibility?), string altStackReference = null, string stackType = null) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.PrivateStorePlanDetails PrivateStorePlanDetails(string planId = null, Azure.ResourceManager.Marketplace.Models.PrivateStorePlanStatus? status = default(Azure.ResourceManager.Marketplace.Models.PrivateStorePlanStatus?), System.BinaryData requestDate = null, string justification = null, string subscriptionId = null, string subscriptionName = null) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.QueryApprovalRequestResult QueryApprovalRequestResult(string uniqueOfferId = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Marketplace.Models.PrivateStorePlanDetails> plansDetails = null, Azure.ETag? eTag = default(Azure.ETag?), long? messageCode = default(long?)) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansDetails QueryApprovedPlansDetails(string planId = null, System.Collections.Generic.IEnumerable<string> subscriptionIds = null, bool? allSubscriptions = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansResult QueryApprovedPlansResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansDetails> details = null) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.RequestApprovalsDetails RequestApprovalsDetails(string offerId = null, string displayName = null, string publisherId = null, long? messageCode = default(long?), System.Uri iconUri = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.Models.PlanNotificationDetails> plans = null) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.StopSellNotifications StopSellNotifications(string offerId = null, string displayName = null, bool? isEntire = default(bool?), long? messageCode = default(long?), System.Uri iconUri = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.Models.PlanNotificationDetails> plans = null) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.StopSellOffersPlansNotificationsList StopSellOffersPlansNotificationsList(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.Models.StopSellOffersPlansNotificationsResult> stopSellNotifications = null) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.StopSellOffersPlansNotificationsResult StopSellOffersPlansNotificationsResult(string offerId = null, string displayName = null, bool? isEntireInStopSell = default(bool?), long? messageCode = default(long?), System.Uri iconUri = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.Models.PlanNotificationDetails> plans = null, bool? hasPublicContext = default(bool?), System.Collections.Generic.IEnumerable<string> subscriptionsIds = null) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.SubscriptionsContextList SubscriptionsContextList(System.Collections.Generic.IEnumerable<string> subscriptionsIds = null) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.TransferOffersResult TransferOffersResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.Models.PrivateStoreCollectionDetails> succeeded = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.Models.PrivateStoreCollectionDetails> failed = null) { throw null; }
    }
    public partial class BulkCollectionsActionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.BulkCollectionsActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.BulkCollectionsActionContent>
    {
        public BulkCollectionsActionContent() { }
        public string Action { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Guid> CollectionIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.BulkCollectionsActionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.BulkCollectionsActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.BulkCollectionsActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.BulkCollectionsActionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.BulkCollectionsActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.BulkCollectionsActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.BulkCollectionsActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkCollectionsActionResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.BulkCollectionsActionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.BulkCollectionsActionResult>
    {
        internal BulkCollectionsActionResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.PrivateStoreCollectionDetails> Failed { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.PrivateStoreCollectionDetails> Succeeded { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.BulkCollectionsActionResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.BulkCollectionsActionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.BulkCollectionsActionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.BulkCollectionsActionResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.BulkCollectionsActionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.BulkCollectionsActionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.BulkCollectionsActionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CollectionOffersByAllContextsPayload : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.CollectionOffersByAllContextsPayload>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.CollectionOffersByAllContextsPayload>
    {
        public CollectionOffersByAllContextsPayload() { }
        public System.Collections.Generic.IList<string> SubscriptionIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.CollectionOffersByAllContextsPayload System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.CollectionOffersByAllContextsPayload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.CollectionOffersByAllContextsPayload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.CollectionOffersByAllContextsPayload System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.CollectionOffersByAllContextsPayload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.CollectionOffersByAllContextsPayload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.CollectionOffersByAllContextsPayload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CollectionOffersByContext : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.CollectionOffersByContext>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.CollectionOffersByContext>
    {
        internal CollectionOffersByContext() { }
        public string Context { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.PrivateStoreOfferResult> Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.CollectionOffersByContext System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.CollectionOffersByContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.CollectionOffersByContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.CollectionOffersByContext System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.CollectionOffersByContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.CollectionOffersByContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.CollectionOffersByContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CollectionsSubscriptionsMappingDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.CollectionsSubscriptionsMappingDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.CollectionsSubscriptionsMappingDetails>
    {
        internal CollectionsSubscriptionsMappingDetails() { }
        public string CollectionName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Subscriptions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.CollectionsSubscriptionsMappingDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.CollectionsSubscriptionsMappingDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.CollectionsSubscriptionsMappingDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.CollectionsSubscriptionsMappingDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.CollectionsSubscriptionsMappingDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.CollectionsSubscriptionsMappingDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.CollectionsSubscriptionsMappingDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CollectionsToSubscriptionsMappingContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.CollectionsToSubscriptionsMappingContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.CollectionsToSubscriptionsMappingContent>
    {
        public CollectionsToSubscriptionsMappingContent() { }
        public System.Collections.Generic.IList<string> CollectionsToSubscriptionsMappingSubscriptionIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.CollectionsToSubscriptionsMappingContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.CollectionsToSubscriptionsMappingContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.CollectionsToSubscriptionsMappingContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.CollectionsToSubscriptionsMappingContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.CollectionsToSubscriptionsMappingContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.CollectionsToSubscriptionsMappingContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.CollectionsToSubscriptionsMappingContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CollectionsToSubscriptionsMappingResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.CollectionsToSubscriptionsMappingResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.CollectionsToSubscriptionsMappingResult>
    {
        internal CollectionsToSubscriptionsMappingResult() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Marketplace.Models.CollectionsSubscriptionsMappingDetails> Details { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.CollectionsToSubscriptionsMappingResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.CollectionsToSubscriptionsMappingResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.CollectionsToSubscriptionsMappingResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.CollectionsToSubscriptionsMappingResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.CollectionsToSubscriptionsMappingResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.CollectionsToSubscriptionsMappingResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.CollectionsToSubscriptionsMappingResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContextAndPlansDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.ContextAndPlansDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.ContextAndPlansDetails>
    {
        public ContextAndPlansDetails() { }
        public string Context { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PlanIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.ContextAndPlansDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.ContextAndPlansDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.ContextAndPlansDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.ContextAndPlansDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.ContextAndPlansDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.ContextAndPlansDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.ContextAndPlansDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MarketplaceAdminAction : System.IEquatable<Azure.ResourceManager.Marketplace.Models.MarketplaceAdminAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MarketplaceAdminAction(string value) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.MarketplaceAdminAction Approved { get { throw null; } }
        public static Azure.ResourceManager.Marketplace.Models.MarketplaceAdminAction Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Marketplace.Models.MarketplaceAdminAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Marketplace.Models.MarketplaceAdminAction left, Azure.ResourceManager.Marketplace.Models.MarketplaceAdminAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Marketplace.Models.MarketplaceAdminAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Marketplace.Models.MarketplaceAdminAction left, Azure.ResourceManager.Marketplace.Models.MarketplaceAdminAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MarketplaceRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.MarketplaceRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.MarketplaceRule>
    {
        public MarketplaceRule() { }
        public Azure.ResourceManager.Marketplace.Models.MarketplaceRuleType? RuleType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.MarketplaceRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.MarketplaceRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.MarketplaceRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.MarketplaceRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.MarketplaceRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.MarketplaceRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.MarketplaceRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MarketplaceRuleType : System.IEquatable<Azure.ResourceManager.Marketplace.Models.MarketplaceRuleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MarketplaceRuleType(string value) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.MarketplaceRuleType PrivateProducts { get { throw null; } }
        public static Azure.ResourceManager.Marketplace.Models.MarketplaceRuleType TermsAndCondition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Marketplace.Models.MarketplaceRuleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Marketplace.Models.MarketplaceRuleType left, Azure.ResourceManager.Marketplace.Models.MarketplaceRuleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Marketplace.Models.MarketplaceRuleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Marketplace.Models.MarketplaceRuleType left, Azure.ResourceManager.Marketplace.Models.MarketplaceRuleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MarketplaceSubscription : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.MarketplaceSubscription>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.MarketplaceSubscription>
    {
        internal MarketplaceSubscription() { }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Marketplace.Models.MarketplaceSubscriptionState? State { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.MarketplaceSubscription System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.MarketplaceSubscription>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.MarketplaceSubscription>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.MarketplaceSubscription System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.MarketplaceSubscription>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.MarketplaceSubscription>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.MarketplaceSubscription>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MarketplaceSubscriptionState : System.IEquatable<Azure.ResourceManager.Marketplace.Models.MarketplaceSubscriptionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MarketplaceSubscriptionState(string value) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.MarketplaceSubscriptionState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Marketplace.Models.MarketplaceSubscriptionState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Marketplace.Models.MarketplaceSubscriptionState Enabled { get { throw null; } }
        public static Azure.ResourceManager.Marketplace.Models.MarketplaceSubscriptionState PastDue { get { throw null; } }
        public static Azure.ResourceManager.Marketplace.Models.MarketplaceSubscriptionState Warned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Marketplace.Models.MarketplaceSubscriptionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Marketplace.Models.MarketplaceSubscriptionState left, Azure.ResourceManager.Marketplace.Models.MarketplaceSubscriptionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Marketplace.Models.MarketplaceSubscriptionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Marketplace.Models.MarketplaceSubscriptionState left, Azure.ResourceManager.Marketplace.Models.MarketplaceSubscriptionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MultiContextAndPlansContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.MultiContextAndPlansContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.MultiContextAndPlansContent>
    {
        public MultiContextAndPlansContent() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string OfferId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Marketplace.Models.ContextAndPlansDetails> PlansContext { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.MultiContextAndPlansContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.MultiContextAndPlansContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.MultiContextAndPlansContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.MultiContextAndPlansContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.MultiContextAndPlansContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.MultiContextAndPlansContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.MultiContextAndPlansContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NewPlanNotification : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.NewPlanNotification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.NewPlanNotification>
    {
        internal NewPlanNotification() { }
        public string DisplayName { get { throw null; } }
        public System.Uri IconUri { get { throw null; } }
        public bool? IsFuturePlansEnabled { get { throw null; } }
        public long? MessageCode { get { throw null; } }
        public string OfferId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.PlanNotificationDetails> Plans { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.NewPlanNotification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.NewPlanNotification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.NewPlanNotification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.NewPlanNotification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.NewPlanNotification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.NewPlanNotification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.NewPlanNotification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NewPlanNotificationListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.NewPlanNotificationListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.NewPlanNotificationListResult>
    {
        internal NewPlanNotificationListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.NewPlanNotification> NewPlansNotifications { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.NewPlanNotificationListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.NewPlanNotificationListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.NewPlanNotificationListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.NewPlanNotificationListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.NewPlanNotificationListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.NewPlanNotificationListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.NewPlanNotificationListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationRecipient : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.NotificationRecipient>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.NotificationRecipient>
    {
        public NotificationRecipient() { }
        public string DisplayName { get { throw null; } }
        public string EmailAddress { get { throw null; } }
        public System.Guid? PrincipalId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.NotificationRecipient System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.NotificationRecipient>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.NotificationRecipient>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.NotificationRecipient System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.NotificationRecipient>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.NotificationRecipient>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.NotificationRecipient>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlanNotificationDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.PlanNotificationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PlanNotificationDetails>
    {
        internal PlanNotificationDetails() { }
        public string PlanDisplayName { get { throw null; } }
        public string PlanId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.PlanNotificationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.PlanNotificationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.PlanNotificationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.PlanNotificationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PlanNotificationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PlanNotificationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PlanNotificationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlanRequesterDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.PlanRequesterDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PlanRequesterDetails>
    {
        internal PlanRequesterDetails() { }
        public string PlanDisplayName { get { throw null; } }
        public string PlanId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.PlanRequesterInfo> Requesters { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.PlanRequesterDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.PlanRequesterDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.PlanRequesterDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.PlanRequesterDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PlanRequesterDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PlanRequesterDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PlanRequesterDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlanRequesterInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.PlanRequesterInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PlanRequesterInfo>
    {
        internal PlanRequesterInfo() { }
        public string Date { get { throw null; } }
        public string Justification { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string SubscriptionName { get { throw null; } }
        public string User { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.PlanRequesterInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.PlanRequesterInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.PlanRequesterInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.PlanRequesterInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PlanRequesterInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PlanRequesterInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PlanRequesterInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateStoreAvailability : System.IEquatable<Azure.ResourceManager.Marketplace.Models.PrivateStoreAvailability>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateStoreAvailability(string value) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.PrivateStoreAvailability Disabled { get { throw null; } }
        public static Azure.ResourceManager.Marketplace.Models.PrivateStoreAvailability Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Marketplace.Models.PrivateStoreAvailability other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Marketplace.Models.PrivateStoreAvailability left, Azure.ResourceManager.Marketplace.Models.PrivateStoreAvailability right) { throw null; }
        public static implicit operator Azure.ResourceManager.Marketplace.Models.PrivateStoreAvailability (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Marketplace.Models.PrivateStoreAvailability left, Azure.ResourceManager.Marketplace.Models.PrivateStoreAvailability right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateStoreBillingAccountsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.PrivateStoreBillingAccountsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PrivateStoreBillingAccountsResult>
    {
        internal PrivateStoreBillingAccountsResult() { }
        public System.Collections.Generic.IReadOnlyList<string> BillingAccounts { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.PrivateStoreBillingAccountsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.PrivateStoreBillingAccountsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.PrivateStoreBillingAccountsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.PrivateStoreBillingAccountsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PrivateStoreBillingAccountsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PrivateStoreBillingAccountsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PrivateStoreBillingAccountsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateStoreCollectionDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.PrivateStoreCollectionDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PrivateStoreCollectionDetails>
    {
        internal PrivateStoreCollectionDetails() { }
        public System.Guid? CollectionId { get { throw null; } }
        public string CollectionName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.PrivateStoreCollectionDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.PrivateStoreCollectionDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.PrivateStoreCollectionDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.PrivateStoreCollectionDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PrivateStoreCollectionDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PrivateStoreCollectionDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PrivateStoreCollectionDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateStoreNotificationsState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.PrivateStoreNotificationsState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PrivateStoreNotificationsState>
    {
        internal PrivateStoreNotificationsState() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.RequestApprovalsDetails> ApprovalRequests { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.NewPlanNotification> NewNotifications { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.StopSellNotifications> StopSellNotifications { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.PrivateStoreNotificationsState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.PrivateStoreNotificationsState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.PrivateStoreNotificationsState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.PrivateStoreNotificationsState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PrivateStoreNotificationsState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PrivateStoreNotificationsState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PrivateStoreNotificationsState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateStoreOfferResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.PrivateStoreOfferResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PrivateStoreOfferResult>
    {
        internal PrivateStoreOfferResult() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.Uri> IconFileUris { get { throw null; } }
        public bool? IsUpdateSuppressedDueToIdempotence { get { throw null; } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public string OfferDisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.PrivateStorePlan> Plans { get { throw null; } }
        public System.Guid? PrivateStoreId { get { throw null; } }
        public string PublisherDisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SpecificPlanIdsLimitation { get { throw null; } }
        public string UniqueOfferId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.PrivateStoreOfferResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.PrivateStoreOfferResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.PrivateStoreOfferResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.PrivateStoreOfferResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PrivateStoreOfferResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PrivateStoreOfferResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PrivateStoreOfferResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateStoreOperation : System.IEquatable<Azure.ResourceManager.Marketplace.Models.PrivateStoreOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateStoreOperation(string value) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.PrivateStoreOperation DeletePrivateStoreCollection { get { throw null; } }
        public static Azure.ResourceManager.Marketplace.Models.PrivateStoreOperation DeletePrivateStoreCollectionOffer { get { throw null; } }
        public static Azure.ResourceManager.Marketplace.Models.PrivateStoreOperation DeletePrivateStoreOffer { get { throw null; } }
        public static Azure.ResourceManager.Marketplace.Models.PrivateStoreOperation Ping { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Marketplace.Models.PrivateStoreOperation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Marketplace.Models.PrivateStoreOperation left, Azure.ResourceManager.Marketplace.Models.PrivateStoreOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Marketplace.Models.PrivateStoreOperation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Marketplace.Models.PrivateStoreOperation left, Azure.ResourceManager.Marketplace.Models.PrivateStoreOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateStorePlan : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.PrivateStorePlan>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PrivateStorePlan>
    {
        public PrivateStorePlan() { }
        public Azure.ResourceManager.Marketplace.Models.PrivateStorePlanAccessibility? Accessibility { get { throw null; } set { } }
        public string AltStackReference { get { throw null; } }
        public string PlanDisplayName { get { throw null; } }
        public string PlanId { get { throw null; } }
        public string SkuId { get { throw null; } }
        public string StackType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.PrivateStorePlan System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.PrivateStorePlan>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.PrivateStorePlan>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.PrivateStorePlan System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PrivateStorePlan>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PrivateStorePlan>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PrivateStorePlan>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateStorePlanAccessibility : System.IEquatable<Azure.ResourceManager.Marketplace.Models.PrivateStorePlanAccessibility>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateStorePlanAccessibility(string value) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.PrivateStorePlanAccessibility PrivateSubscriptionOnLevel { get { throw null; } }
        public static Azure.ResourceManager.Marketplace.Models.PrivateStorePlanAccessibility PrivateTenantOnLevel { get { throw null; } }
        public static Azure.ResourceManager.Marketplace.Models.PrivateStorePlanAccessibility Public { get { throw null; } }
        public static Azure.ResourceManager.Marketplace.Models.PrivateStorePlanAccessibility Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Marketplace.Models.PrivateStorePlanAccessibility other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Marketplace.Models.PrivateStorePlanAccessibility left, Azure.ResourceManager.Marketplace.Models.PrivateStorePlanAccessibility right) { throw null; }
        public static implicit operator Azure.ResourceManager.Marketplace.Models.PrivateStorePlanAccessibility (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Marketplace.Models.PrivateStorePlanAccessibility left, Azure.ResourceManager.Marketplace.Models.PrivateStorePlanAccessibility right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateStorePlanDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.PrivateStorePlanDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PrivateStorePlanDetails>
    {
        public PrivateStorePlanDetails() { }
        public string Justification { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public System.BinaryData RequestDate { get { throw null; } }
        public Azure.ResourceManager.Marketplace.Models.PrivateStorePlanStatus? Status { get { throw null; } }
        public string SubscriptionId { get { throw null; } set { } }
        public string SubscriptionName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.PrivateStorePlanDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.PrivateStorePlanDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.PrivateStorePlanDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.PrivateStorePlanDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PrivateStorePlanDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PrivateStorePlanDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.PrivateStorePlanDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateStorePlanStatus : System.IEquatable<Azure.ResourceManager.Marketplace.Models.PrivateStorePlanStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateStorePlanStatus(string value) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.PrivateStorePlanStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Marketplace.Models.PrivateStorePlanStatus None { get { throw null; } }
        public static Azure.ResourceManager.Marketplace.Models.PrivateStorePlanStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Marketplace.Models.PrivateStorePlanStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Marketplace.Models.PrivateStorePlanStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Marketplace.Models.PrivateStorePlanStatus left, Azure.ResourceManager.Marketplace.Models.PrivateStorePlanStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Marketplace.Models.PrivateStorePlanStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Marketplace.Models.PrivateStorePlanStatus left, Azure.ResourceManager.Marketplace.Models.PrivateStorePlanStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QueryApprovalRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.QueryApprovalRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.QueryApprovalRequestContent>
    {
        public QueryApprovalRequestContent() { }
        public System.Collections.Generic.IList<string> PlanIds { get { throw null; } }
        public string PublisherId { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.QueryApprovalRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.QueryApprovalRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.QueryApprovalRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.QueryApprovalRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.QueryApprovalRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.QueryApprovalRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.QueryApprovalRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryApprovalRequestResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.QueryApprovalRequestResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.QueryApprovalRequestResult>
    {
        internal QueryApprovalRequestResult() { }
        public Azure.ETag? ETag { get { throw null; } }
        public long? MessageCode { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Marketplace.Models.PrivateStorePlanDetails> PlansDetails { get { throw null; } }
        public string UniqueOfferId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.QueryApprovalRequestResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.QueryApprovalRequestResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.QueryApprovalRequestResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.QueryApprovalRequestResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.QueryApprovalRequestResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.QueryApprovalRequestResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.QueryApprovalRequestResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryApprovedPlansContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansContent>
    {
        public QueryApprovedPlansContent() { }
        public string OfferId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PlanIds { get { throw null; } }
        public System.Collections.Generic.IList<string> SubscriptionIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryApprovedPlansDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansDetails>
    {
        internal QueryApprovedPlansDetails() { }
        public bool? AllSubscriptions { get { throw null; } }
        public string PlanId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SubscriptionIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryApprovedPlansResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansResult>
    {
        internal QueryApprovedPlansResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansDetails> Details { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryUserOffersContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.QueryUserOffersContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.QueryUserOffersContent>
    {
        public QueryUserOffersContent() { }
        public System.Collections.Generic.IList<string> OfferIds { get { throw null; } }
        public System.Collections.Generic.IList<string> SubscriptionIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.QueryUserOffersContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.QueryUserOffersContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.QueryUserOffersContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.QueryUserOffersContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.QueryUserOffersContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.QueryUserOffersContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.QueryUserOffersContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryUserRulesContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.QueryUserRulesContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.QueryUserRulesContent>
    {
        public QueryUserRulesContent() { }
        public System.Collections.Generic.IList<string> SubscriptionIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.QueryUserRulesContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.QueryUserRulesContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.QueryUserRulesContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.QueryUserRulesContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.QueryUserRulesContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.QueryUserRulesContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.QueryUserRulesContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RequestApprovalsDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.RequestApprovalsDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.RequestApprovalsDetails>
    {
        internal RequestApprovalsDetails() { }
        public string DisplayName { get { throw null; } }
        public System.Uri IconUri { get { throw null; } }
        public long? MessageCode { get { throw null; } }
        public string OfferId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.PlanNotificationDetails> Plans { get { throw null; } }
        public string PublisherId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.RequestApprovalsDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.RequestApprovalsDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.RequestApprovalsDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.RequestApprovalsDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.RequestApprovalsDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.RequestApprovalsDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.RequestApprovalsDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SetRulesContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.SetRulesContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.SetRulesContent>
    {
        public SetRulesContent() { }
        public string NextLink { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Marketplace.Models.MarketplaceRule> Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.SetRulesContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.SetRulesContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.SetRulesContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.SetRulesContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.SetRulesContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.SetRulesContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.SetRulesContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StopSellNotifications : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.StopSellNotifications>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.StopSellNotifications>
    {
        internal StopSellNotifications() { }
        public string DisplayName { get { throw null; } }
        public System.Uri IconUri { get { throw null; } }
        public bool? IsEntire { get { throw null; } }
        public long? MessageCode { get { throw null; } }
        public string OfferId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.PlanNotificationDetails> Plans { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.StopSellNotifications System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.StopSellNotifications>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.StopSellNotifications>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.StopSellNotifications System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.StopSellNotifications>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.StopSellNotifications>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.StopSellNotifications>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StopSellOffersPlansNotificationsList : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.StopSellOffersPlansNotificationsList>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.StopSellOffersPlansNotificationsList>
    {
        internal StopSellOffersPlansNotificationsList() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.StopSellOffersPlansNotificationsResult> StopSellNotifications { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.StopSellOffersPlansNotificationsList System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.StopSellOffersPlansNotificationsList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.StopSellOffersPlansNotificationsList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.StopSellOffersPlansNotificationsList System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.StopSellOffersPlansNotificationsList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.StopSellOffersPlansNotificationsList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.StopSellOffersPlansNotificationsList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StopSellOffersPlansNotificationsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.StopSellOffersPlansNotificationsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.StopSellOffersPlansNotificationsResult>
    {
        internal StopSellOffersPlansNotificationsResult() { }
        public string DisplayName { get { throw null; } }
        public bool? HasPublicContext { get { throw null; } }
        public System.Uri IconUri { get { throw null; } }
        public bool? IsEntireInStopSell { get { throw null; } }
        public long? MessageCode { get { throw null; } }
        public string OfferId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.PlanNotificationDetails> Plans { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SubscriptionsIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.StopSellOffersPlansNotificationsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.StopSellOffersPlansNotificationsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.StopSellOffersPlansNotificationsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.StopSellOffersPlansNotificationsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.StopSellOffersPlansNotificationsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.StopSellOffersPlansNotificationsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.StopSellOffersPlansNotificationsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StopSellSubscriptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.StopSellSubscriptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.StopSellSubscriptions>
    {
        public StopSellSubscriptions() { }
        public System.Collections.Generic.IList<string> Subscriptions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.StopSellSubscriptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.StopSellSubscriptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.StopSellSubscriptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.StopSellSubscriptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.StopSellSubscriptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.StopSellSubscriptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.StopSellSubscriptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubscriptionsContextList : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.SubscriptionsContextList>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.SubscriptionsContextList>
    {
        internal SubscriptionsContextList() { }
        public System.Collections.Generic.IReadOnlyList<string> SubscriptionsIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.SubscriptionsContextList System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.SubscriptionsContextList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.SubscriptionsContextList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.SubscriptionsContextList System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.SubscriptionsContextList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.SubscriptionsContextList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.SubscriptionsContextList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TransferOffersContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.TransferOffersContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.TransferOffersContent>
    {
        public TransferOffersContent() { }
        public System.Collections.Generic.IList<string> OfferIdsList { get { throw null; } }
        public string Operation { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TargetCollections { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.TransferOffersContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.TransferOffersContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.TransferOffersContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.TransferOffersContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.TransferOffersContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.TransferOffersContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.TransferOffersContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TransferOffersResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.TransferOffersResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.TransferOffersResult>
    {
        internal TransferOffersResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.PrivateStoreCollectionDetails> Failed { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.PrivateStoreCollectionDetails> Succeeded { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.TransferOffersResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.TransferOffersResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.TransferOffersResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.TransferOffersResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.TransferOffersResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.TransferOffersResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.TransferOffersResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WithdrawPlanContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.WithdrawPlanContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.WithdrawPlanContent>
    {
        public WithdrawPlanContent() { }
        public string PlanId { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.WithdrawPlanContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.WithdrawPlanContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Models.WithdrawPlanContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Models.WithdrawPlanContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.WithdrawPlanContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.WithdrawPlanContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Models.WithdrawPlanContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
