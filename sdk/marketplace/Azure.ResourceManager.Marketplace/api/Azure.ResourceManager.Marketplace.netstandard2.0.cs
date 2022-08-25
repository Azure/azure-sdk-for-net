namespace Azure.ResourceManager.Marketplace
{
    public partial class AdminRequestApprovalsResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AdminRequestApprovalsResource() { }
        public virtual Azure.ResourceManager.Marketplace.AdminRequestApprovalsResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string privateStoreId, string adminRequestApprovalId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.AdminRequestApprovalsResource> Get(string publisherId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.AdminRequestApprovalsResource>> GetAsync(string publisherId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Marketplace.AdminRequestApprovalsResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Marketplace.AdminRequestApprovalsResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Marketplace.AdminRequestApprovalsResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Marketplace.AdminRequestApprovalsResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AdminRequestApprovalsResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Marketplace.AdminRequestApprovalsResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.AdminRequestApprovalsResource>, System.Collections.IEnumerable
    {
        protected AdminRequestApprovalsResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Marketplace.AdminRequestApprovalsResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string adminRequestApprovalId, Azure.ResourceManager.Marketplace.AdminRequestApprovalsResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Marketplace.AdminRequestApprovalsResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string adminRequestApprovalId, Azure.ResourceManager.Marketplace.AdminRequestApprovalsResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string adminRequestApprovalId, string publisherId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string adminRequestApprovalId, string publisherId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.AdminRequestApprovalsResource> Get(string adminRequestApprovalId, string publisherId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Marketplace.AdminRequestApprovalsResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Marketplace.AdminRequestApprovalsResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.AdminRequestApprovalsResource>> GetAsync(string adminRequestApprovalId, string publisherId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Marketplace.AdminRequestApprovalsResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Marketplace.AdminRequestApprovalsResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Marketplace.AdminRequestApprovalsResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.AdminRequestApprovalsResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AdminRequestApprovalsResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public AdminRequestApprovalsResourceData() { }
        public Azure.ResourceManager.Marketplace.Models.AdminAction? AdminAction { get { throw null; } set { } }
        public string Administrator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ApprovedPlans { get { throw null; } }
        public System.Collections.Generic.IList<string> CollectionIds { get { throw null; } }
        public string Comment { get { throw null; } set { } }
        public string DisplayName { get { throw null; } }
        public string Icon { get { throw null; } }
        public string OfferId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.PlanRequesterDetails> Plans { get { throw null; } }
        public string PublisherId { get { throw null; } set { } }
    }
    public partial class CollectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Marketplace.CollectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.CollectionResource>, System.Collections.IEnumerable
    {
        protected CollectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Marketplace.CollectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string collectionId, Azure.ResourceManager.Marketplace.CollectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Marketplace.CollectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string collectionId, Azure.ResourceManager.Marketplace.CollectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.CollectionResource> Get(string collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Marketplace.CollectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Marketplace.CollectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.CollectionResource>> GetAsync(string collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Marketplace.CollectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Marketplace.CollectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Marketplace.CollectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.CollectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CollectionData : Azure.ResourceManager.Models.ResourceData
    {
        public CollectionData() { }
        public bool? AllSubscriptions { get { throw null; } set { } }
        public bool? ApproveAllItems { get { throw null; } }
        public System.DateTimeOffset? ApproveAllItemsModifiedOn { get { throw null; } }
        public string Claim { get { throw null; } set { } }
        public string CollectionId { get { throw null; } }
        public string CollectionName { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public long? NumberOfOffers { get { throw null; } }
        public System.Collections.Generic.IList<string> SubscriptionsList { get { throw null; } }
    }
    public partial class CollectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CollectionResource() { }
        public virtual Azure.ResourceManager.Marketplace.CollectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.CollectionResource> ApproveAllItems(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.CollectionResource>> ApproveAllItemsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string privateStoreId, string collectionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.CollectionResource> DisableApproveAllItems(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.CollectionResource>> DisableApproveAllItemsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.CollectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.CollectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.OfferResource> GetOffer(string offerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.OfferResource>> GetOfferAsync(string offerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Marketplace.OfferCollection GetOffers() { throw null; }
        public virtual Azure.Response Post(Azure.ResourceManager.Marketplace.Models.Operation? payload = default(Azure.ResourceManager.Marketplace.Models.Operation?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PostAsync(Azure.ResourceManager.Marketplace.Models.Operation? payload = default(Azure.ResourceManager.Marketplace.Models.Operation?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.Models.TransferOffersResponse> TransferOffers(Azure.ResourceManager.Marketplace.Models.TransferOffersProperties payload = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.Models.TransferOffersResponse>> TransferOffersAsync(Azure.ResourceManager.Marketplace.Models.TransferOffersProperties payload = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Marketplace.CollectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Marketplace.CollectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Marketplace.CollectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Marketplace.CollectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class MarketplaceExtensions
    {
        public static Azure.ResourceManager.Marketplace.AdminRequestApprovalsResource GetAdminRequestApprovalsResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Marketplace.CollectionResource GetCollectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Marketplace.OfferResource GetOfferResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Marketplace.PrivateStoreResource> GetPrivateStore(this Azure.ResourceManager.Resources.TenantResource tenantResource, string privateStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.PrivateStoreResource>> GetPrivateStoreAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string privateStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Marketplace.PrivateStoreResource GetPrivateStoreResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Marketplace.PrivateStoreCollection GetPrivateStores(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.ResourceManager.Marketplace.RequestApprovalResource GetRequestApprovalResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class OfferCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Marketplace.OfferResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.OfferResource>, System.Collections.IEnumerable
    {
        protected OfferCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Marketplace.OfferResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string offerId, Azure.ResourceManager.Marketplace.OfferData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Marketplace.OfferResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string offerId, Azure.ResourceManager.Marketplace.OfferData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string offerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string offerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.OfferResource> Get(string offerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Marketplace.OfferResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Marketplace.OfferResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.OfferResource>> GetAsync(string offerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Marketplace.OfferResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Marketplace.OfferResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Marketplace.OfferResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.OfferResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OfferData : Azure.ResourceManager.Models.ResourceData
    {
        public OfferData() { }
        public string CreatedAt { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> IconFileUris { get { throw null; } }
        public string ModifiedAt { get { throw null; } }
        public string OfferDisplayName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Marketplace.Models.MarketplacePlan> Plans { get { throw null; } }
        public string PrivateStoreId { get { throw null; } }
        public string PublisherDisplayName { get { throw null; } }
        public System.Collections.Generic.IList<string> SpecificPlanIdsLimitation { get { throw null; } }
        public string UniqueOfferId { get { throw null; } }
        public bool? UpdateSuppressedDueIdempotence { get { throw null; } set { } }
    }
    public partial class OfferResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OfferResource() { }
        public virtual Azure.ResourceManager.Marketplace.OfferData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string privateStoreId, string collectionId, string offerId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.OfferResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.OfferResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Post(Azure.ResourceManager.Marketplace.Models.Operation? payload = default(Azure.ResourceManager.Marketplace.Models.Operation?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PostAsync(Azure.ResourceManager.Marketplace.Models.Operation? payload = default(Azure.ResourceManager.Marketplace.Models.Operation?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Marketplace.OfferResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Marketplace.OfferData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Marketplace.OfferResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Marketplace.OfferData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.OfferResource> UpsertOfferWithMultiContext(Azure.ResourceManager.Marketplace.Models.MultiContextAndPlansPayload payload = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.OfferResource>> UpsertOfferWithMultiContextAsync(Azure.ResourceManager.Marketplace.Models.MultiContextAndPlansPayload payload = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateStoreCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Marketplace.PrivateStoreResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.PrivateStoreResource>, System.Collections.IEnumerable
    {
        protected PrivateStoreCollection() { }
        public virtual Azure.ResourceManager.ArmOperation CreateOrUpdate(Azure.WaitUntil waitUntil, string privateStoreId, Azure.ResourceManager.Marketplace.PrivateStoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateStoreId, Azure.ResourceManager.Marketplace.PrivateStoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.PrivateStoreResource> Get(string privateStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Marketplace.PrivateStoreResource> GetAll(string useCache = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Marketplace.PrivateStoreResource> GetAllAsync(string useCache = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.PrivateStoreResource>> GetAsync(string privateStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Marketplace.PrivateStoreResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Marketplace.PrivateStoreResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Marketplace.PrivateStoreResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.PrivateStoreResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateStoreData : Azure.ResourceManager.Models.ResourceData
    {
        public PrivateStoreData() { }
        public Azure.ResourceManager.Marketplace.Models.Availability? Availability { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Branding { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> CollectionIds { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public bool? IsGov { get { throw null; } set { } }
        public string PrivateStoreId { get { throw null; } }
        public string PrivateStoreName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Marketplace.Models.Recipient> Recipients { get { throw null; } }
        public bool? SendToAllMarketplaceAdmins { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class PrivateStoreResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateStoreResource() { }
        public virtual Azure.ResourceManager.Marketplace.PrivateStoreData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response AcknowledgeOfferNotification(string offerId, Azure.ResourceManager.Marketplace.Models.AcknowledgeOfferNotificationProperties payload = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AcknowledgeOfferNotificationAsync(string offerId, Azure.ResourceManager.Marketplace.Models.AcknowledgeOfferNotificationProperties payload = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.Models.AnyExistingOffersInTheCollectionsResponse> AnyExistingOffersInTheCollections(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.Models.AnyExistingOffersInTheCollectionsResponse>> AnyExistingOffersInTheCollectionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.Models.BillingAccountsResponse> BillingAccounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.Models.BillingAccountsResponse>> BillingAccountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.Models.BulkCollectionsResponse> BulkCollectionsAction(Azure.ResourceManager.Marketplace.Models.BulkCollectionsPayload payload = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.Models.BulkCollectionsResponse>> BulkCollectionsActionAsync(Azure.ResourceManager.Marketplace.Models.BulkCollectionsPayload payload = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.Models.CollectionsToSubscriptionsMappingResponse> CollectionsToSubscriptionsMapping(Azure.ResourceManager.Marketplace.Models.CollectionsToSubscriptionsMappingPayload payload = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.Models.CollectionsToSubscriptionsMappingResponse>> CollectionsToSubscriptionsMappingAsync(Azure.ResourceManager.Marketplace.Models.CollectionsToSubscriptionsMappingPayload payload = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string privateStoreId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Marketplace.Models.Subscription> FetchAllSubscriptionsInTenant(string nextPageToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Marketplace.Models.Subscription> FetchAllSubscriptionsInTenantAsync(string nextPageToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.PrivateStoreResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.AdminRequestApprovalsResource> GetAdminRequestApprovalsResource(string adminRequestApprovalId, string publisherId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.AdminRequestApprovalsResource>> GetAdminRequestApprovalsResourceAsync(string adminRequestApprovalId, string publisherId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Marketplace.AdminRequestApprovalsResourceCollection GetAdminRequestApprovalsResources() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.PrivateStoreResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.CollectionResource> GetCollection(string collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.CollectionResource>> GetCollectionAsync(string collectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Marketplace.CollectionCollection GetCollections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.Models.NewPlansNotificationsList> GetNewPlansNotifications(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.Models.NewPlansNotificationsList>> GetNewPlansNotificationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.RequestApprovalResource> GetRequestApprovalResource(string requestApprovalId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.RequestApprovalResource>> GetRequestApprovalResourceAsync(string requestApprovalId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Marketplace.RequestApprovalResourceCollection GetRequestApprovalResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.Models.StopSellOffersPlansNotificationsList> GetStopSellOffersPlansNotifications(Azure.ResourceManager.Marketplace.Models.StopSellSubscriptions stopSellSubscriptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.Models.StopSellOffersPlansNotificationsList>> GetStopSellOffersPlansNotificationsAsync(Azure.ResourceManager.Marketplace.Models.StopSellSubscriptions stopSellSubscriptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.Models.SubscriptionsContextList> GetSubscriptionsContext(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.Models.SubscriptionsContextList>> GetSubscriptionsContextAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansResponse> QueryApprovedPlans(Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansPayload payload = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansResponse>> QueryApprovedPlansAsync(Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansPayload payload = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.Models.PrivateStoreNotificationsState> QueryNotificationsState(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.Models.PrivateStoreNotificationsState>> QueryNotificationsStateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Marketplace.Models.OfferProperties> QueryOffers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Marketplace.Models.OfferProperties> QueryOffersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Marketplace.Models.OfferProperties> QueryUserOffers(Azure.ResourceManager.Marketplace.Models.QueryUserOffersProperties payload = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Marketplace.Models.OfferProperties> QueryUserOffersAsync(Azure.ResourceManager.Marketplace.Models.QueryUserOffersProperties payload = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Marketplace.PrivateStoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Marketplace.PrivateStoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RequestApprovalResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RequestApprovalResource() { }
        public virtual Azure.ResourceManager.Marketplace.RequestApprovalResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string privateStoreId, string requestApprovalId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.RequestApprovalResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.RequestApprovalResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.Models.QueryRequestApproval> QueryRequestApproval(Azure.ResourceManager.Marketplace.Models.QueryRequestApprovalProperties payload = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.Models.QueryRequestApproval>> QueryRequestApprovalAsync(Azure.ResourceManager.Marketplace.Models.QueryRequestApprovalProperties payload = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Marketplace.RequestApprovalResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Marketplace.RequestApprovalResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Marketplace.RequestApprovalResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Marketplace.RequestApprovalResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response WithdrawPlan(Azure.ResourceManager.Marketplace.Models.WithdrawProperties payload = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> WithdrawPlanAsync(Azure.ResourceManager.Marketplace.Models.WithdrawProperties payload = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RequestApprovalResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Marketplace.RequestApprovalResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.RequestApprovalResource>, System.Collections.IEnumerable
    {
        protected RequestApprovalResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Marketplace.RequestApprovalResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string requestApprovalId, Azure.ResourceManager.Marketplace.RequestApprovalResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Marketplace.RequestApprovalResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string requestApprovalId, Azure.ResourceManager.Marketplace.RequestApprovalResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string requestApprovalId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string requestApprovalId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.RequestApprovalResource> Get(string requestApprovalId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Marketplace.RequestApprovalResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Marketplace.RequestApprovalResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.RequestApprovalResource>> GetAsync(string requestApprovalId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Marketplace.RequestApprovalResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Marketplace.RequestApprovalResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Marketplace.RequestApprovalResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Marketplace.RequestApprovalResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RequestApprovalResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public RequestApprovalResourceData() { }
        public bool? IsClosed { get { throw null; } }
        public long? MessageCode { get { throw null; } set { } }
        public string OfferDisplayName { get { throw null; } }
        public string OfferId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Marketplace.Models.PlanDetails> PlansDetails { get { throw null; } }
        public string PublisherId { get { throw null; } set { } }
    }
}
namespace Azure.ResourceManager.Marketplace.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Accessibility : System.IEquatable<Azure.ResourceManager.Marketplace.Models.Accessibility>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Accessibility(string value) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.Accessibility PrivateSubscriptionOnLevel { get { throw null; } }
        public static Azure.ResourceManager.Marketplace.Models.Accessibility PrivateTenantOnLevel { get { throw null; } }
        public static Azure.ResourceManager.Marketplace.Models.Accessibility Public { get { throw null; } }
        public static Azure.ResourceManager.Marketplace.Models.Accessibility Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Marketplace.Models.Accessibility other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Marketplace.Models.Accessibility left, Azure.ResourceManager.Marketplace.Models.Accessibility right) { throw null; }
        public static implicit operator Azure.ResourceManager.Marketplace.Models.Accessibility (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Marketplace.Models.Accessibility left, Azure.ResourceManager.Marketplace.Models.Accessibility right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AcknowledgeOfferNotificationProperties
    {
        public AcknowledgeOfferNotificationProperties() { }
        public bool? Acknowledge { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AddPlans { get { throw null; } }
        public bool? Dismiss { get { throw null; } set { } }
        public bool? RemoveOffer { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RemovePlans { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdminAction : System.IEquatable<Azure.ResourceManager.Marketplace.Models.AdminAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdminAction(string value) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.AdminAction Approved { get { throw null; } }
        public static Azure.ResourceManager.Marketplace.Models.AdminAction Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Marketplace.Models.AdminAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Marketplace.Models.AdminAction left, Azure.ResourceManager.Marketplace.Models.AdminAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Marketplace.Models.AdminAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Marketplace.Models.AdminAction left, Azure.ResourceManager.Marketplace.Models.AdminAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AnyExistingOffersInTheCollectionsResponse
    {
        internal AnyExistingOffersInTheCollectionsResponse() { }
        public bool? Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Availability : System.IEquatable<Azure.ResourceManager.Marketplace.Models.Availability>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Availability(string value) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.Availability Disabled { get { throw null; } }
        public static Azure.ResourceManager.Marketplace.Models.Availability Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Marketplace.Models.Availability other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Marketplace.Models.Availability left, Azure.ResourceManager.Marketplace.Models.Availability right) { throw null; }
        public static implicit operator Azure.ResourceManager.Marketplace.Models.Availability (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Marketplace.Models.Availability left, Azure.ResourceManager.Marketplace.Models.Availability right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BillingAccountsResponse
    {
        internal BillingAccountsResponse() { }
        public System.Collections.Generic.IReadOnlyList<string> BillingAccounts { get { throw null; } }
    }
    public partial class BulkCollectionsPayload
    {
        public BulkCollectionsPayload() { }
        public string Action { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> CollectionIds { get { throw null; } }
    }
    public partial class BulkCollectionsResponse
    {
        internal BulkCollectionsResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.CollectionsDetails> Failed { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.CollectionsDetails> Succeeded { get { throw null; } }
    }
    public partial class CollectionsDetails
    {
        internal CollectionsDetails() { }
        public string CollectionId { get { throw null; } }
        public string CollectionName { get { throw null; } }
    }
    public partial class CollectionsSubscriptionsMappingDetails
    {
        internal CollectionsSubscriptionsMappingDetails() { }
        public string CollectionName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Subscriptions { get { throw null; } }
    }
    public partial class CollectionsToSubscriptionsMappingPayload
    {
        public CollectionsToSubscriptionsMappingPayload() { }
        public System.Collections.Generic.IList<string> CollectionsToSubscriptionsMappingSubscriptionIds { get { throw null; } }
    }
    public partial class CollectionsToSubscriptionsMappingResponse
    {
        internal CollectionsToSubscriptionsMappingResponse() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Marketplace.Models.CollectionsSubscriptionsMappingDetails> Details { get { throw null; } }
    }
    public partial class ContextAndPlansDetails
    {
        public ContextAndPlansDetails() { }
        public string Context { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PlanIds { get { throw null; } }
    }
    public partial class MarketplacePlan
    {
        public MarketplacePlan() { }
        public Azure.ResourceManager.Marketplace.Models.Accessibility? Accessibility { get { throw null; } set { } }
        public string AltStackReference { get { throw null; } }
        public string PlanDisplayName { get { throw null; } }
        public string PlanId { get { throw null; } }
        public string SkuId { get { throw null; } }
        public string StackType { get { throw null; } }
    }
    public partial class MultiContextAndPlansPayload
    {
        public MultiContextAndPlansPayload() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string OfferId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Marketplace.Models.ContextAndPlansDetails> PlansContext { get { throw null; } }
    }
    public partial class NewNotifications
    {
        internal NewNotifications() { }
        public string DisplayName { get { throw null; } }
        public string Icon { get { throw null; } }
        public bool? IsFuturePlansEnabled { get { throw null; } }
        public long? MessageCode { get { throw null; } }
        public string OfferId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.PlanNotificationDetails> Plans { get { throw null; } }
    }
    public partial class NewPlansNotificationsList
    {
        internal NewPlansNotificationsList() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.NewNotifications> NewPlansNotifications { get { throw null; } }
    }
    public partial class OfferProperties
    {
        internal OfferProperties() { }
        public string CreatedAt { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> IconFileUris { get { throw null; } }
        public string ModifiedAt { get { throw null; } }
        public string OfferDisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.MarketplacePlan> Plans { get { throw null; } }
        public string PrivateStoreId { get { throw null; } }
        public string PublisherDisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SpecificPlanIdsLimitation { get { throw null; } }
        public string UniqueOfferId { get { throw null; } }
        public bool? UpdateSuppressedDueIdempotence { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Operation : System.IEquatable<Azure.ResourceManager.Marketplace.Models.Operation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Operation(string value) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.Operation DeletePrivateStoreCollection { get { throw null; } }
        public static Azure.ResourceManager.Marketplace.Models.Operation DeletePrivateStoreCollectionOffer { get { throw null; } }
        public static Azure.ResourceManager.Marketplace.Models.Operation DeletePrivateStoreOffer { get { throw null; } }
        public static Azure.ResourceManager.Marketplace.Models.Operation Ping { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Marketplace.Models.Operation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Marketplace.Models.Operation left, Azure.ResourceManager.Marketplace.Models.Operation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Marketplace.Models.Operation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Marketplace.Models.Operation left, Azure.ResourceManager.Marketplace.Models.Operation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PlanDetails
    {
        public PlanDetails() { }
        public string Justification { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public System.BinaryData RequestDate { get { throw null; } }
        public Azure.ResourceManager.Marketplace.Models.Status? Status { get { throw null; } }
        public string SubscriptionId { get { throw null; } set { } }
        public string SubscriptionName { get { throw null; } set { } }
    }
    public partial class PlanNotificationDetails
    {
        internal PlanNotificationDetails() { }
        public string PlanDisplayName { get { throw null; } }
        public string PlanId { get { throw null; } }
    }
    public partial class PlanRequesterDetails
    {
        internal PlanRequesterDetails() { }
        public string PlanDisplayName { get { throw null; } }
        public string PlanId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.UserRequestDetails> Requesters { get { throw null; } }
    }
    public partial class PrivateStoreNotificationsState
    {
        internal PrivateStoreNotificationsState() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.RequestApprovalsDetails> ApprovalRequests { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.NewNotifications> NewNotifications { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.StopSellNotifications> StopSellNotifications { get { throw null; } }
    }
    public partial class QueryApprovedPlansDetails
    {
        internal QueryApprovedPlansDetails() { }
        public bool? AllSubscriptions { get { throw null; } }
        public string PlanId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SubscriptionIds { get { throw null; } }
    }
    public partial class QueryApprovedPlansPayload
    {
        public QueryApprovedPlansPayload() { }
        public string OfferId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PlanIds { get { throw null; } }
        public System.Collections.Generic.IList<string> SubscriptionIds { get { throw null; } }
    }
    public partial class QueryApprovedPlansResponse
    {
        internal QueryApprovedPlansResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.QueryApprovedPlansDetails> Details { get { throw null; } }
    }
    public partial class QueryRequestApproval
    {
        internal QueryRequestApproval() { }
        public Azure.ETag? ETag { get { throw null; } }
        public long? MessageCode { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Marketplace.Models.PlanDetails> PlansDetails { get { throw null; } }
        public string UniqueOfferId { get { throw null; } }
    }
    public partial class QueryRequestApprovalProperties
    {
        public QueryRequestApprovalProperties() { }
        public Azure.ResourceManager.Marketplace.Models.RequestDetails Properties { get { throw null; } set { } }
    }
    public partial class QueryUserOffersProperties
    {
        public QueryUserOffersProperties() { }
        public System.Collections.Generic.IList<string> OfferIds { get { throw null; } }
        public System.Collections.Generic.IList<string> SubscriptionIds { get { throw null; } }
    }
    public partial class Recipient
    {
        public Recipient() { }
        public string DisplayName { get { throw null; } }
        public string EmailAddress { get { throw null; } }
        public string PrincipalId { get { throw null; } set { } }
    }
    public partial class RequestApprovalsDetails
    {
        internal RequestApprovalsDetails() { }
        public string DisplayName { get { throw null; } }
        public string Icon { get { throw null; } }
        public long? MessageCode { get { throw null; } }
        public string OfferId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.PlanNotificationDetails> Plans { get { throw null; } }
        public string PublisherId { get { throw null; } }
    }
    public partial class RequestDetails
    {
        public RequestDetails() { }
        public System.Collections.Generic.IList<string> PlanIds { get { throw null; } }
        public string PublisherId { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Status : System.IEquatable<Azure.ResourceManager.Marketplace.Models.Status>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Status(string value) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.Status Approved { get { throw null; } }
        public static Azure.ResourceManager.Marketplace.Models.Status None { get { throw null; } }
        public static Azure.ResourceManager.Marketplace.Models.Status Pending { get { throw null; } }
        public static Azure.ResourceManager.Marketplace.Models.Status Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Marketplace.Models.Status other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Marketplace.Models.Status left, Azure.ResourceManager.Marketplace.Models.Status right) { throw null; }
        public static implicit operator Azure.ResourceManager.Marketplace.Models.Status (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Marketplace.Models.Status left, Azure.ResourceManager.Marketplace.Models.Status right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StopSellNotifications
    {
        internal StopSellNotifications() { }
        public string DisplayName { get { throw null; } }
        public string Icon { get { throw null; } }
        public bool? IsEntire { get { throw null; } }
        public long? MessageCode { get { throw null; } }
        public string OfferId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.PlanNotificationDetails> Plans { get { throw null; } }
    }
    public partial class StopSellOffersPlansNotificationsList
    {
        internal StopSellOffersPlansNotificationsList() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.StopSellOffersPlansNotificationsListProperties> StopSellNotifications { get { throw null; } }
    }
    public partial class StopSellOffersPlansNotificationsListProperties
    {
        internal StopSellOffersPlansNotificationsListProperties() { }
        public string DisplayName { get { throw null; } }
        public string Icon { get { throw null; } }
        public bool? IsEntire { get { throw null; } }
        public long? MessageCode { get { throw null; } }
        public string OfferId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.PlanNotificationDetails> Plans { get { throw null; } }
        public bool? PublicContext { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SubscriptionsIds { get { throw null; } }
    }
    public partial class StopSellSubscriptions
    {
        public StopSellSubscriptions() { }
        public System.Collections.Generic.IList<string> Subscriptions { get { throw null; } }
    }
    public partial class Subscription
    {
        internal Subscription() { }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Marketplace.Models.SubscriptionState? State { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
    }
    public partial class SubscriptionsContextList
    {
        internal SubscriptionsContextList() { }
        public System.Collections.Generic.IReadOnlyList<string> SubscriptionsIds { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SubscriptionState : System.IEquatable<Azure.ResourceManager.Marketplace.Models.SubscriptionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SubscriptionState(string value) { throw null; }
        public static Azure.ResourceManager.Marketplace.Models.SubscriptionState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Marketplace.Models.SubscriptionState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Marketplace.Models.SubscriptionState Enabled { get { throw null; } }
        public static Azure.ResourceManager.Marketplace.Models.SubscriptionState PastDue { get { throw null; } }
        public static Azure.ResourceManager.Marketplace.Models.SubscriptionState Warned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Marketplace.Models.SubscriptionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Marketplace.Models.SubscriptionState left, Azure.ResourceManager.Marketplace.Models.SubscriptionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Marketplace.Models.SubscriptionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Marketplace.Models.SubscriptionState left, Azure.ResourceManager.Marketplace.Models.SubscriptionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TransferOffersProperties
    {
        public TransferOffersProperties() { }
        public System.Collections.Generic.IList<string> OfferIdsList { get { throw null; } }
        public string Operation { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TargetCollections { get { throw null; } }
    }
    public partial class TransferOffersResponse
    {
        internal TransferOffersResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.CollectionsDetails> Failed { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Marketplace.Models.CollectionsDetails> Succeeded { get { throw null; } }
    }
    public partial class UserRequestDetails
    {
        internal UserRequestDetails() { }
        public string Date { get { throw null; } }
        public string Justification { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string SubscriptionName { get { throw null; } }
        public string User { get { throw null; } }
    }
    public partial class WithdrawProperties
    {
        public WithdrawProperties() { }
        public string PlanId { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
    }
}
