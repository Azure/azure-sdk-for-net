namespace Azure.ResourceManager.Reservations
{
    public partial class CurrentQuotaLimitBaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Reservations.CurrentQuotaLimitBaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Reservations.CurrentQuotaLimitBaseResource>, System.Collections.IEnumerable
    {
        protected CurrentQuotaLimitBaseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.CurrentQuotaLimitBaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.Reservations.CurrentQuotaLimitBaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.CurrentQuotaLimitBaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.Reservations.CurrentQuotaLimitBaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Reservations.CurrentQuotaLimitBaseResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Reservations.CurrentQuotaLimitBaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Reservations.CurrentQuotaLimitBaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.CurrentQuotaLimitBaseResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Reservations.CurrentQuotaLimitBaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Reservations.CurrentQuotaLimitBaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Reservations.CurrentQuotaLimitBaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Reservations.CurrentQuotaLimitBaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CurrentQuotaLimitBaseData : Azure.ResourceManager.Models.ResourceData
    {
        public CurrentQuotaLimitBaseData() { }
        public Azure.ResourceManager.Reservations.Models.QuotaProperties Properties { get { throw null; } set { } }
    }
    public partial class CurrentQuotaLimitBaseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CurrentQuotaLimitBaseResource() { }
        public virtual Azure.ResourceManager.Reservations.CurrentQuotaLimitBaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string providerId, Azure.Core.AzureLocation location, string resourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Reservations.CurrentQuotaLimitBaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.CurrentQuotaLimitBaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.CurrentQuotaLimitBaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.CurrentQuotaLimitBaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.CurrentQuotaLimitBaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.CurrentQuotaLimitBaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QuotaRequestDetailsCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Reservations.QuotaRequestDetailsResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Reservations.QuotaRequestDetailsResource>, System.Collections.IEnumerable
    {
        protected QuotaRequestDetailsCollection() { }
        public virtual Azure.Response<bool> Exists(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Reservations.QuotaRequestDetailsResource> Get(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Reservations.QuotaRequestDetailsResource> GetAll(string filter = null, int? top = default(int?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Reservations.QuotaRequestDetailsResource> GetAllAsync(string filter = null, int? top = default(int?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.QuotaRequestDetailsResource>> GetAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Reservations.QuotaRequestDetailsResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Reservations.QuotaRequestDetailsResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Reservations.QuotaRequestDetailsResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Reservations.QuotaRequestDetailsResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class QuotaRequestDetailsData : Azure.ResourceManager.Models.ResourceData
    {
        internal QuotaRequestDetailsData() { }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.QuotaRequestState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.Models.SubRequest> QuotaRequestValue { get { throw null; } }
        public System.DateTimeOffset? RequestSubmitOn { get { throw null; } }
    }
    public partial class QuotaRequestDetailsResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected QuotaRequestDetailsResource() { }
        public virtual Azure.ResourceManager.Reservations.QuotaRequestDetailsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string providerId, Azure.Core.AzureLocation location, string id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Reservations.QuotaRequestDetailsResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.QuotaRequestDetailsResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ReservationOrderResponseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Reservations.ReservationOrderResponseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Reservations.ReservationOrderResponseResource>, System.Collections.IEnumerable
    {
        protected ReservationOrderResponseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.ReservationOrderResponseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string reservationOrderId, Azure.ResourceManager.Reservations.Models.PurchaseRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.ReservationOrderResponseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string reservationOrderId, Azure.ResourceManager.Reservations.Models.PurchaseRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string reservationOrderId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string reservationOrderId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Reservations.ReservationOrderResponseResource> Get(string reservationOrderId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Reservations.ReservationOrderResponseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Reservations.ReservationOrderResponseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.ReservationOrderResponseResource>> GetAsync(string reservationOrderId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Reservations.ReservationOrderResponseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Reservations.ReservationOrderResponseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Reservations.ReservationOrderResponseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Reservations.ReservationOrderResponseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ReservationOrderResponseData : Azure.ResourceManager.Models.ResourceData
    {
        internal ReservationOrderResponseData() { }
        public System.DateTimeOffset? BenefitStartOn { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservationBillingPlan? BillingPlan { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.DateTimeOffset? ExpiryOn { get { throw null; } }
        public int? OriginalQuantity { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservationOrderBillingPlanInformation PlanInformation { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? RequestOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.ReservationResponseData> Reservations { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservationTerm? Term { get { throw null; } }
        public int? Version { get { throw null; } }
    }
    public partial class ReservationOrderResponseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ReservationOrderResponseResource() { }
        public virtual Azure.ResourceManager.Reservations.ReservationOrderResponseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Reservations.Models.ChangeDirectoryResponse> ChangeDirectory(Azure.ResourceManager.Reservations.Models.ChangeDirectoryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.Models.ChangeDirectoryResponse>> ChangeDirectoryAsync(Azure.ResourceManager.Reservations.Models.ChangeDirectoryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string reservationOrderId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Reservations.ReservationOrderResponseResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.ReservationOrderResponseResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Reservations.ReservationResponseResource> GetReservationResponse(string reservationId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.ReservationResponseResource>> GetReservationResponseAsync(string reservationId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Reservations.ReservationResponseCollection GetReservationResponses() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<System.Collections.Generic.IList<Azure.ResourceManager.Reservations.ReservationResponseData>> MergeReservation(Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.Models.MergeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<System.Collections.Generic.IList<Azure.ResourceManager.Reservations.ReservationResponseData>>> MergeReservationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.Models.MergeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<System.Collections.Generic.IList<Azure.ResourceManager.Reservations.ReservationResponseData>> SplitReservation(Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.Models.SplitContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<System.Collections.Generic.IList<Azure.ResourceManager.Reservations.ReservationResponseData>>> SplitReservationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.Models.SplitContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.ReservationOrderResponseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.Models.PurchaseRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.ReservationOrderResponseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.Models.PurchaseRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ReservationResponseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Reservations.ReservationResponseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Reservations.ReservationResponseResource>, System.Collections.IEnumerable
    {
        protected ReservationResponseCollection() { }
        public virtual Azure.Response<bool> Exists(string reservationId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string reservationId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Reservations.ReservationResponseResource> Get(string reservationId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Reservations.ReservationResponseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Reservations.ReservationResponseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.ReservationResponseResource>> GetAsync(string reservationId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Reservations.ReservationResponseResource> GetRevisions(string reservationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Reservations.ReservationResponseResource> GetRevisionsAsync(string reservationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Reservations.ReservationResponseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Reservations.ReservationResponseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Reservations.ReservationResponseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Reservations.ReservationResponseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ReservationResponseData : Azure.ResourceManager.Models.ResourceData
    {
        internal ReservationResponseData() { }
        public string Kind { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservationsProperties Properties { get { throw null; } }
        public string SkuName { get { throw null; } }
        public int? Version { get { throw null; } }
    }
    public partial class ReservationResponseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ReservationResponseResource() { }
        public virtual Azure.ResourceManager.Reservations.ReservationResponseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.Models.AvailableScopeProperties> AvailableScopes(Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.Models.AvailableScopeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.Models.AvailableScopeProperties>> AvailableScopesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.Models.AvailableScopeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string reservationOrderId, string reservationId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Reservations.ReservationResponseResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.ReservationResponseResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.ReservationResponseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.Models.ReservationResponsePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.ReservationResponseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.Models.ReservationResponsePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ReservationsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Reservations.Models.CalculatePriceResponse> CalculateReservationOrder(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.Reservations.Models.PurchaseRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.Models.CalculatePriceResponse>> CalculateReservationOrderAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.Reservations.Models.PurchaseRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Reservations.Models.AppliedReservations> GetAppliedReservationList(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.Models.AppliedReservations>> GetAppliedReservationListAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Reservations.Models.ReservationCatalog> GetCatalog(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string reservedResourceType = null, string location = null, string publisherId = null, string offerId = null, string planId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Reservations.Models.ReservationCatalog> GetCatalogAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string reservedResourceType = null, string location = null, string publisherId = null, string offerId = null, string planId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Reservations.CurrentQuotaLimitBaseResource> GetCurrentQuotaLimitBase(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string providerId, string location, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.CurrentQuotaLimitBaseResource>> GetCurrentQuotaLimitBaseAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string providerId, string location, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Reservations.CurrentQuotaLimitBaseResource GetCurrentQuotaLimitBaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Reservations.CurrentQuotaLimitBaseCollection GetCurrentQuotaLimitBases(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string providerId, string location) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Reservations.Models.OperationResponse> GetOperations(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Reservations.Models.OperationResponse> GetOperationsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Reservations.QuotaRequestDetailsCollection GetQuotaRequestDetails(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string providerId, string location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Reservations.QuotaRequestDetailsResource> GetQuotaRequestDetails(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string providerId, string location, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.QuotaRequestDetailsResource>> GetQuotaRequestDetailsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string providerId, string location, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Reservations.QuotaRequestDetailsResource GetQuotaRequestDetailsResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Reservations.ReservationOrderResponseResource> GetReservationOrderResponse(this Azure.ResourceManager.Resources.TenantResource tenantResource, string reservationOrderId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.ReservationOrderResponseResource>> GetReservationOrderResponseAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string reservationOrderId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Reservations.ReservationOrderResponseResource GetReservationOrderResponseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Reservations.ReservationOrderResponseCollection GetReservationOrderResponses(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.ResourceManager.Reservations.ReservationResponseResource GetReservationResponseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Reservations.ReservationResponseResource> GetReservationResponses(this Azure.ResourceManager.Resources.TenantResource tenantResource, string filter = null, string orderby = null, string refreshSummary = null, float? skiptoken = default(float?), string selectedState = null, float? take = default(float?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Reservations.ReservationResponseResource> GetReservationResponsesAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string filter = null, string orderby = null, string refreshSummary = null, float? skiptoken = default(float?), string selectedState = null, float? take = default(float?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.Models.CalculateExchangeOperationResultResponse> PostCalculateExchange(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.Models.CalculateExchangeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.Models.CalculateExchangeOperationResultResponse>> PostCalculateExchangeAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.Models.CalculateExchangeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.Models.ExchangeOperationResultResponse> PostExchange(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.Models.ExchangeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.Models.ExchangeOperationResultResponse>> PostExchangeAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.Models.ExchangeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Reservations.Models
{
    public partial class AppliedReservationList
    {
        internal AppliedReservationList() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Value { get { throw null; } }
    }
    public partial class AppliedReservations : Azure.ResourceManager.Models.ResourceData
    {
        internal AppliedReservations() { }
        public Azure.ResourceManager.Reservations.Models.AppliedReservationList ReservationOrderIds { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppliedScopeType : System.IEquatable<Azure.ResourceManager.Reservations.Models.AppliedScopeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppliedScopeType(string value) { throw null; }
        public static Azure.ResourceManager.Reservations.Models.AppliedScopeType Shared { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.AppliedScopeType Single { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Reservations.Models.AppliedScopeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Reservations.Models.AppliedScopeType left, Azure.ResourceManager.Reservations.Models.AppliedScopeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Reservations.Models.AppliedScopeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Reservations.Models.AppliedScopeType left, Azure.ResourceManager.Reservations.Models.AppliedScopeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvailableScopeContent
    {
        public AvailableScopeContent() { }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
    }
    public partial class AvailableScopeProperties
    {
        internal AvailableScopeProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.Models.ScopeProperties> Scopes { get { throw null; } }
    }
    public partial class BillingInformation
    {
        internal BillingInformation() { }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice BillingCurrencyProratedAmount { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice BillingCurrencyRemainingCommitmentAmount { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice BillingCurrencyTotalPaidAmount { get { throw null; } }
    }
    public partial class CalculateExchangeContent
    {
        public CalculateExchangeContent() { }
        public Azure.ResourceManager.Reservations.Models.CalculateExchangeRequestProperties Properties { get { throw null; } set { } }
    }
    public partial class CalculateExchangeOperationResultResponse
    {
        internal CalculateExchangeOperationResultResponse() { }
        public Azure.ResourceManager.Reservations.Models.OperationResultError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.CalculateExchangeResponseProperties Properties { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.CalculateExchangeOperationResultStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CalculateExchangeOperationResultStatus : System.IEquatable<Azure.ResourceManager.Reservations.Models.CalculateExchangeOperationResultStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CalculateExchangeOperationResultStatus(string value) { throw null; }
        public static Azure.ResourceManager.Reservations.Models.CalculateExchangeOperationResultStatus Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.CalculateExchangeOperationResultStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.CalculateExchangeOperationResultStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.CalculateExchangeOperationResultStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Reservations.Models.CalculateExchangeOperationResultStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Reservations.Models.CalculateExchangeOperationResultStatus left, Azure.ResourceManager.Reservations.Models.CalculateExchangeOperationResultStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Reservations.Models.CalculateExchangeOperationResultStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Reservations.Models.CalculateExchangeOperationResultStatus left, Azure.ResourceManager.Reservations.Models.CalculateExchangeOperationResultStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CalculateExchangeRequestProperties
    {
        public CalculateExchangeRequestProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Reservations.Models.ReservationToReturn> ReservationsToExchange { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Reservations.Models.PurchaseRequestContent> ReservationsToPurchase { get { throw null; } }
    }
    public partial class CalculateExchangeResponseProperties
    {
        internal CalculateExchangeResponseProperties() { }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice NetPayable { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.Models.ExchangePolicyError> PolicyErrors { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice PurchasesTotal { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice RefundsTotal { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.Models.ReservationToExchange> ReservationsToExchange { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.Models.ReservationToPurchaseCalculateExchange> ReservationsToPurchase { get { throw null; } }
        public string SessionId { get { throw null; } }
    }
    public partial class CalculatePriceResponse
    {
        internal CalculatePriceResponse() { }
        public Azure.ResourceManager.Reservations.Models.CalculatePriceResponseProperties Properties { get { throw null; } }
    }
    public partial class CalculatePriceResponseProperties
    {
        internal CalculatePriceResponseProperties() { }
        public Azure.ResourceManager.Reservations.Models.CalculatePriceResponsePropertiesBillingCurrencyTotal BillingCurrencyTotal { get { throw null; } }
        public double? GrandTotal { get { throw null; } }
        public bool? IsBillingPartnerManaged { get { throw null; } }
        public bool? IsTaxIncluded { get { throw null; } }
        public double? NetTotal { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.Models.PaymentDetail> PaymentSchedule { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.CalculatePriceResponsePropertiesPricingCurrencyTotal PricingCurrencyTotal { get { throw null; } }
        public string ReservationOrderId { get { throw null; } }
        public string SkuDescription { get { throw null; } }
        public string SkuTitle { get { throw null; } }
        public double? TaxTotal { get { throw null; } }
    }
    public partial class CalculatePriceResponsePropertiesBillingCurrencyTotal
    {
        internal CalculatePriceResponsePropertiesBillingCurrencyTotal() { }
        public double? Amount { get { throw null; } }
        public string CurrencyCode { get { throw null; } }
    }
    public partial class CalculatePriceResponsePropertiesPricingCurrencyTotal
    {
        internal CalculatePriceResponsePropertiesPricingCurrencyTotal() { }
        public float? Amount { get { throw null; } }
        public string CurrencyCode { get { throw null; } }
    }
    public partial class ChangeDirectoryContent
    {
        public ChangeDirectoryContent() { }
        public string DestinationTenantId { get { throw null; } set { } }
    }
    public partial class ChangeDirectoryResponse
    {
        internal ChangeDirectoryResponse() { }
        public Azure.ResourceManager.Reservations.Models.ChangeDirectoryResult ReservationOrder { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.Models.ChangeDirectoryResult> Reservations { get { throw null; } }
    }
    public partial class ChangeDirectoryResult
    {
        internal ChangeDirectoryResult() { }
        public string Error { get { throw null; } }
        public string Id { get { throw null; } }
        public bool? IsSucceeded { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class ExchangeContent
    {
        public ExchangeContent() { }
        public string ExchangeRequestSessionId { get { throw null; } set { } }
    }
    public partial class ExchangeOperationResultResponse
    {
        internal ExchangeOperationResultResponse() { }
        public Azure.ResourceManager.Reservations.Models.OperationResultError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ExchangeResponseProperties Properties { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ExchangeOperationResultStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExchangeOperationResultStatus : System.IEquatable<Azure.ResourceManager.Reservations.Models.ExchangeOperationResultStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExchangeOperationResultStatus(string value) { throw null; }
        public static Azure.ResourceManager.Reservations.Models.ExchangeOperationResultStatus Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ExchangeOperationResultStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ExchangeOperationResultStatus PendingPurchases { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ExchangeOperationResultStatus PendingRefunds { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ExchangeOperationResultStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Reservations.Models.ExchangeOperationResultStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Reservations.Models.ExchangeOperationResultStatus left, Azure.ResourceManager.Reservations.Models.ExchangeOperationResultStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Reservations.Models.ExchangeOperationResultStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Reservations.Models.ExchangeOperationResultStatus left, Azure.ResourceManager.Reservations.Models.ExchangeOperationResultStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExchangePolicyError
    {
        internal ExchangePolicyError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class ExchangeResponseProperties
    {
        internal ExchangeResponseProperties() { }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice NetPayable { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.Models.ExchangePolicyError> PolicyErrors { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice PurchasesTotal { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice RefundsTotal { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.Models.ReservationToReturnForExchange> ReservationsToExchange { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.Models.ReservationToPurchaseExchange> ReservationsToPurchase { get { throw null; } }
        public string SessionId { get { throw null; } }
    }
    public partial class ExtendedStatusInfo
    {
        internal ExtendedStatusInfo() { }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservationStatusCode? StatusCode { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InstanceFlexibility : System.IEquatable<Azure.ResourceManager.Reservations.Models.InstanceFlexibility>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InstanceFlexibility(string value) { throw null; }
        public static Azure.ResourceManager.Reservations.Models.InstanceFlexibility Off { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.InstanceFlexibility On { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Reservations.Models.InstanceFlexibility other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Reservations.Models.InstanceFlexibility left, Azure.ResourceManager.Reservations.Models.InstanceFlexibility right) { throw null; }
        public static implicit operator Azure.ResourceManager.Reservations.Models.InstanceFlexibility (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Reservations.Models.InstanceFlexibility left, Azure.ResourceManager.Reservations.Models.InstanceFlexibility right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MergeContent
    {
        public MergeContent() { }
        public System.Collections.Generic.IList<string> Sources { get { throw null; } }
    }
    public partial class OperationDisplay
    {
        internal OperationDisplay() { }
        public string Description { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
    }
    public partial class OperationResponse
    {
        internal OperationResponse() { }
        public Azure.ResourceManager.Reservations.Models.OperationDisplay Display { get { throw null; } }
        public bool? IsDataAction { get { throw null; } }
        public string Name { get { throw null; } }
        public string Origin { get { throw null; } }
        public System.BinaryData Properties { get { throw null; } }
    }
    public partial class OperationResultError
    {
        internal OperationResultError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationStatus : System.IEquatable<Azure.ResourceManager.Reservations.Models.OperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationStatus(string value) { throw null; }
        public static Azure.ResourceManager.Reservations.Models.OperationStatus Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.OperationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.OperationStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.OperationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Reservations.Models.OperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Reservations.Models.OperationStatus left, Azure.ResourceManager.Reservations.Models.OperationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Reservations.Models.OperationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Reservations.Models.OperationStatus left, Azure.ResourceManager.Reservations.Models.OperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PaymentDetail
    {
        internal PaymentDetail() { }
        public string BillingAccount { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice BillingCurrencyTotal { get { throw null; } }
        public System.DateTimeOffset? DueOn { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ExtendedStatusInfo ExtendedStatusInfo { get { throw null; } }
        public System.DateTimeOffset? PaymentOn { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice PricingCurrencyTotal { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.PaymentStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PaymentStatus : System.IEquatable<Azure.ResourceManager.Reservations.Models.PaymentStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PaymentStatus(string value) { throw null; }
        public static Azure.ResourceManager.Reservations.Models.PaymentStatus Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.PaymentStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.PaymentStatus Scheduled { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.PaymentStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Reservations.Models.PaymentStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Reservations.Models.PaymentStatus left, Azure.ResourceManager.Reservations.Models.PaymentStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Reservations.Models.PaymentStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Reservations.Models.PaymentStatus left, Azure.ResourceManager.Reservations.Models.PaymentStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Reservations.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Reservations.Models.ProvisioningState BillingFailed { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ProvisioningState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ProvisioningState ConfirmedBilling { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ProvisioningState ConfirmedResourceHold { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ProvisioningState Expired { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ProvisioningState Merged { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ProvisioningState PendingBilling { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ProvisioningState PendingResourceHold { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ProvisioningState Split { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Reservations.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Reservations.Models.ProvisioningState left, Azure.ResourceManager.Reservations.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Reservations.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Reservations.Models.ProvisioningState left, Azure.ResourceManager.Reservations.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PurchasePrice
    {
        internal PurchasePrice() { }
        public double? Amount { get { throw null; } }
        public string CurrencyCode { get { throw null; } }
    }
    public partial class PurchaseRequestContent
    {
        public PurchaseRequestContent() { }
        public System.Collections.Generic.IList<string> AppliedScopes { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.AppliedScopeType? AppliedScopeType { get { throw null; } set { } }
        public Azure.ResourceManager.Reservations.Models.ReservationBillingPlan? BillingPlan { get { throw null; } set { } }
        public string BillingScopeId { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public int? Quantity { get { throw null; } set { } }
        public bool? Renew { get { throw null; } set { } }
        public Azure.ResourceManager.Reservations.Models.InstanceFlexibility? ReservedResourceInstanceFlexibility { get { throw null; } set { } }
        public Azure.ResourceManager.Reservations.Models.ReservedResourceType? ReservedResourceType { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.Reservations.Models.ReservationTerm? Term { get { throw null; } set { } }
    }
    public partial class QuotaProperties
    {
        public QuotaProperties() { }
        public int? CurrentValue { get { throw null; } }
        public int? Limit { get { throw null; } set { } }
        public System.BinaryData Properties { get { throw null; } set { } }
        public string QuotaPeriod { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ResourceName ResourceName { get { throw null; } set { } }
        public Azure.ResourceManager.Reservations.Models.ResourceTypeName? ResourceTypeName { get { throw null; } set { } }
        public string Unit { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QuotaRequestState : System.IEquatable<Azure.ResourceManager.Reservations.Models.QuotaRequestState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QuotaRequestState(string value) { throw null; }
        public static Azure.ResourceManager.Reservations.Models.QuotaRequestState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.QuotaRequestState Failed { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.QuotaRequestState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.QuotaRequestState Invalid { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.QuotaRequestState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Reservations.Models.QuotaRequestState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Reservations.Models.QuotaRequestState left, Azure.ResourceManager.Reservations.Models.QuotaRequestState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Reservations.Models.QuotaRequestState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Reservations.Models.QuotaRequestState left, Azure.ResourceManager.Reservations.Models.QuotaRequestState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RenewPropertiesResponse
    {
        internal RenewPropertiesResponse() { }
        public Azure.ResourceManager.Reservations.Models.RenewPropertiesResponseBillingCurrencyTotal BillingCurrencyTotal { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.RenewPropertiesResponsePricingCurrencyTotal PricingCurrencyTotal { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.PurchaseRequestContent PurchaseProperties { get { throw null; } }
    }
    public partial class RenewPropertiesResponseBillingCurrencyTotal
    {
        internal RenewPropertiesResponseBillingCurrencyTotal() { }
        public float? Amount { get { throw null; } }
        public string CurrencyCode { get { throw null; } }
    }
    public partial class RenewPropertiesResponsePricingCurrencyTotal
    {
        internal RenewPropertiesResponsePricingCurrencyTotal() { }
        public float? Amount { get { throw null; } }
        public string CurrencyCode { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReservationBillingPlan : System.IEquatable<Azure.ResourceManager.Reservations.Models.ReservationBillingPlan>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReservationBillingPlan(string value) { throw null; }
        public static Azure.ResourceManager.Reservations.Models.ReservationBillingPlan Monthly { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationBillingPlan Upfront { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Reservations.Models.ReservationBillingPlan other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Reservations.Models.ReservationBillingPlan left, Azure.ResourceManager.Reservations.Models.ReservationBillingPlan right) { throw null; }
        public static implicit operator Azure.ResourceManager.Reservations.Models.ReservationBillingPlan (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Reservations.Models.ReservationBillingPlan left, Azure.ResourceManager.Reservations.Models.ReservationBillingPlan right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReservationCatalog
    {
        internal ReservationCatalog() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IList<Azure.ResourceManager.Reservations.Models.ReservationBillingPlan>> BillingPlans { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.Models.SkuCapability> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice MsrpP1Y { get { throw null; } }
        public string ReservedResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.Models.SkuRestriction> Restrictions { get { throw null; } }
        public string Size { get { throw null; } }
        public string SkuName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.Models.SkuProperty> SkuProperties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.Models.ReservationTerm> Terms { get { throw null; } }
        public string Tier { get { throw null; } }
    }
    public partial class ReservationMergeProperties
    {
        internal ReservationMergeProperties() { }
        public string MergeDestination { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> MergeSources { get { throw null; } }
    }
    public partial class ReservationOrderBillingPlanInformation
    {
        internal ReservationOrderBillingPlanInformation() { }
        public System.DateTimeOffset? NextPaymentDueOn { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice PricingCurrencyTotal { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.Models.PaymentDetail> Transactions { get { throw null; } }
    }
    public partial class ReservationResponsePatch
    {
        public ReservationResponsePatch() { }
        public System.Collections.Generic.IList<string> AppliedScopes { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.AppliedScopeType? AppliedScopeType { get { throw null; } set { } }
        public Azure.ResourceManager.Reservations.Models.InstanceFlexibility? InstanceFlexibility { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? Renew { get { throw null; } set { } }
        public Azure.ResourceManager.Reservations.Models.PurchaseRequestContent RenewPurchaseProperties { get { throw null; } set { } }
    }
    public partial class ReservationSplitProperties
    {
        internal ReservationSplitProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> SplitDestinations { get { throw null; } }
        public string SplitSource { get { throw null; } }
    }
    public partial class ReservationsProperties
    {
        internal ReservationsProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> AppliedScopes { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.AppliedScopeType? AppliedScopeType { get { throw null; } }
        public bool? Archived { get { throw null; } }
        public System.DateTimeOffset? BenefitStartOn { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservationBillingPlan? BillingPlan { get { throw null; } }
        public string BillingScopeId { get { throw null; } }
        public string Capabilities { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string DisplayProvisioningState { get { throw null; } }
        public System.DateTimeOffset? EffectiveOn { get { throw null; } }
        public System.DateTimeOffset? ExpiryOn { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ExtendedStatusInfo ExtendedStatusInfo { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.InstanceFlexibility? InstanceFlexibility { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservationMergeProperties MergeProperties { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ProvisioningSubState { get { throw null; } }
        public System.DateTimeOffset? PurchaseOn { get { throw null; } }
        public int? Quantity { get { throw null; } }
        public bool? Renew { get { throw null; } }
        public string RenewDestination { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.RenewPropertiesResponse RenewProperties { get { throw null; } }
        public string RenewSource { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservedResourceType? ReservedResourceType { get { throw null; } }
        public string SkuDescription { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservationSplitProperties SplitProperties { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservationTerm? Term { get { throw null; } }
        public string UserFriendlyAppliedScopeType { get { throw null; } }
        public string UserFriendlyRenewState { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservationsPropertiesUtilization Utilization { get { throw null; } }
    }
    public partial class ReservationsPropertiesUtilization
    {
        internal ReservationsPropertiesUtilization() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.Models.ReservationUtilizationAggregates> Aggregates { get { throw null; } }
        public string Trend { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReservationStatusCode : System.IEquatable<Azure.ResourceManager.Reservations.Models.ReservationStatusCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReservationStatusCode(string value) { throw null; }
        public static Azure.ResourceManager.Reservations.Models.ReservationStatusCode Active { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationStatusCode Expired { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationStatusCode Merged { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationStatusCode None { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationStatusCode PaymentInstrumentError { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationStatusCode Pending { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationStatusCode Processing { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationStatusCode PurchaseError { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationStatusCode Split { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationStatusCode Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Reservations.Models.ReservationStatusCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Reservations.Models.ReservationStatusCode left, Azure.ResourceManager.Reservations.Models.ReservationStatusCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Reservations.Models.ReservationStatusCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Reservations.Models.ReservationStatusCode left, Azure.ResourceManager.Reservations.Models.ReservationStatusCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReservationTerm : System.IEquatable<Azure.ResourceManager.Reservations.Models.ReservationTerm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReservationTerm(string value) { throw null; }
        public static Azure.ResourceManager.Reservations.Models.ReservationTerm P1Y { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationTerm P3Y { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationTerm P5Y { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Reservations.Models.ReservationTerm other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Reservations.Models.ReservationTerm left, Azure.ResourceManager.Reservations.Models.ReservationTerm right) { throw null; }
        public static implicit operator Azure.ResourceManager.Reservations.Models.ReservationTerm (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Reservations.Models.ReservationTerm left, Azure.ResourceManager.Reservations.Models.ReservationTerm right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReservationToExchange
    {
        internal ReservationToExchange() { }
        public Azure.ResourceManager.Reservations.Models.BillingInformation BillingInformation { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice BillingRefundAmount { get { throw null; } }
        public int? Quantity { get { throw null; } }
        public string ReservationId { get { throw null; } }
    }
    public partial class ReservationToPurchaseCalculateExchange
    {
        internal ReservationToPurchaseCalculateExchange() { }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice BillingCurrencyTotal { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.PurchaseRequestContent Properties { get { throw null; } }
    }
    public partial class ReservationToPurchaseExchange
    {
        internal ReservationToPurchaseExchange() { }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice BillingCurrencyTotal { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.PurchaseRequestContent Properties { get { throw null; } }
        public string ReservationId { get { throw null; } }
        public string ReservationOrderId { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.OperationStatus? Status { get { throw null; } }
    }
    public partial class ReservationToReturn
    {
        public ReservationToReturn() { }
        public int? Quantity { get { throw null; } set { } }
        public string ReservationId { get { throw null; } set { } }
    }
    public partial class ReservationToReturnForExchange
    {
        internal ReservationToReturnForExchange() { }
        public Azure.ResourceManager.Reservations.Models.BillingInformation BillingInformation { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice BillingRefundAmount { get { throw null; } }
        public int? Quantity { get { throw null; } }
        public string ReservationId { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.OperationStatus? Status { get { throw null; } }
    }
    public partial class ReservationUtilizationAggregates
    {
        internal ReservationUtilizationAggregates() { }
        public float? Grain { get { throw null; } }
        public string GrainUnit { get { throw null; } }
        public float? Value { get { throw null; } }
        public string ValueUnit { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReservedResourceType : System.IEquatable<Azure.ResourceManager.Reservations.Models.ReservedResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReservedResourceType(string value) { throw null; }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType AppService { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType AVS { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType AzureDataExplorer { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType AzureFiles { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType BlockBlob { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType CosmosDb { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType Databricks { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType DataFactory { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType DedicatedHost { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType ManagedDisk { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType MariaDb { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType MySql { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType NetAppStorage { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType PostgreSql { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType RedHat { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType RedHatOsa { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType RedisCache { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType SapHana { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType SqlAzureHybridBenefit { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType SqlDatabases { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType SqlDataWarehouse { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType SqlEdge { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType SuseLinux { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType VirtualMachines { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType VirtualMachineSoftware { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType VMwareCloudSimple { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Reservations.Models.ReservedResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Reservations.Models.ReservedResourceType left, Azure.ResourceManager.Reservations.Models.ReservedResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Reservations.Models.ReservedResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Reservations.Models.ReservedResourceType left, Azure.ResourceManager.Reservations.Models.ReservedResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceName
    {
        public ResourceName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceTypeName : System.IEquatable<Azure.ResourceManager.Reservations.Models.ResourceTypeName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceTypeName(string value) { throw null; }
        public static Azure.ResourceManager.Reservations.Models.ResourceTypeName Dedicated { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ResourceTypeName LowPriority { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ResourceTypeName ServiceSpecific { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ResourceTypeName Shared { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ResourceTypeName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Reservations.Models.ResourceTypeName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Reservations.Models.ResourceTypeName left, Azure.ResourceManager.Reservations.Models.ResourceTypeName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Reservations.Models.ResourceTypeName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Reservations.Models.ResourceTypeName left, Azure.ResourceManager.Reservations.Models.ResourceTypeName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScopeProperties
    {
        internal ScopeProperties() { }
        public string Scope { get { throw null; } }
        public bool? Valid { get { throw null; } }
    }
    public partial class SkuCapability
    {
        internal SkuCapability() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class SkuProperty
    {
        internal SkuProperty() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class SkuRestriction
    {
        internal SkuRestriction() { }
        public string ReasonCode { get { throw null; } }
        public string SkuRestrictionType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
    }
    public partial class SplitContent
    {
        public SplitContent() { }
        public System.Collections.Generic.IList<int> Quantities { get { throw null; } }
        public string ReservationId { get { throw null; } set { } }
    }
    public partial class SubRequest
    {
        internal SubRequest() { }
        public int? Limit { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ResourceName Name { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.QuotaRequestState? ProvisioningState { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public string SubRequestId { get { throw null; } }
        public string Unit { get { throw null; } }
    }
}
