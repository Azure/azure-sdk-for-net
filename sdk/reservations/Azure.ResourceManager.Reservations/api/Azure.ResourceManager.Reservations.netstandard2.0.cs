namespace Azure.ResourceManager.Reservations
{
    public partial class QuotaRequestDetailCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Reservations.QuotaRequestDetailResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Reservations.QuotaRequestDetailResource>, System.Collections.IEnumerable
    {
        protected QuotaRequestDetailCollection() { }
        public virtual Azure.Response<bool> Exists(System.Guid id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Guid id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Reservations.QuotaRequestDetailResource> Get(System.Guid id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Reservations.QuotaRequestDetailResource> GetAll(string filter = null, int? top = default(int?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Reservations.QuotaRequestDetailResource> GetAllAsync(string filter = null, int? top = default(int?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.QuotaRequestDetailResource>> GetAsync(System.Guid id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Reservations.QuotaRequestDetailResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Reservations.QuotaRequestDetailResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Reservations.QuotaRequestDetailResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Reservations.QuotaRequestDetailResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class QuotaRequestDetailData : Azure.ResourceManager.Models.ResourceData
    {
        internal QuotaRequestDetailData() { }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.QuotaRequestState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.Models.SubContent> QuotaRequestValue { get { throw null; } }
        public System.DateTimeOffset? RequestSubmitOn { get { throw null; } }
    }
    public partial class QuotaRequestDetailResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected QuotaRequestDetailResource() { }
        public virtual Azure.ResourceManager.Reservations.QuotaRequestDetailData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string providerId, Azure.Core.AzureLocation location, System.Guid id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Reservations.QuotaRequestDetailResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.QuotaRequestDetailResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ReservationDetailCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Reservations.ReservationDetailResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Reservations.ReservationDetailResource>, System.Collections.IEnumerable
    {
        protected ReservationDetailCollection() { }
        public virtual Azure.Response<bool> Exists(System.Guid reservationId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Guid reservationId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Reservations.ReservationDetailResource> Get(System.Guid reservationId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Reservations.ReservationDetailResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Reservations.ReservationDetailResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.ReservationDetailResource>> GetAsync(System.Guid reservationId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Reservations.ReservationDetailResource> GetRevisions(System.Guid reservationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Reservations.ReservationDetailResource> GetRevisionsAsync(System.Guid reservationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Reservations.ReservationDetailResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Reservations.ReservationDetailResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Reservations.ReservationDetailResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Reservations.ReservationDetailResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ReservationDetailData : Azure.ResourceManager.Models.ResourceData
    {
        internal ReservationDetailData() { }
        public Azure.ResourceManager.Reservations.Models.ReservationKind? Kind { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservationProperties Properties { get { throw null; } }
        public string SkuName { get { throw null; } }
        public int? Version { get { throw null; } }
    }
    public partial class ReservationDetailResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ReservationDetailResource() { }
        public virtual Azure.ResourceManager.Reservations.ReservationDetailData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response Archive(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ArchiveAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(System.Guid reservationOrderId, System.Guid reservationId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Reservations.ReservationDetailResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.ReservationDetailResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.Models.AvailableScopesProperties> GetAvailableScopes(Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.Models.AvailableScopesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.Models.AvailableScopesProperties>> GetAvailableScopesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.Models.AvailableScopesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Unarchive(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UnarchiveAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.ReservationDetailResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.Models.ReservationDetailPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.ReservationDetailResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.Models.ReservationDetailPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ReservationOrderCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Reservations.ReservationOrderResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Reservations.ReservationOrderResource>, System.Collections.IEnumerable
    {
        protected ReservationOrderCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.ReservationOrderResource> CreateOrUpdate(Azure.WaitUntil waitUntil, System.Guid reservationOrderId, Azure.ResourceManager.Reservations.Models.ReservationPurchaseContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.ReservationOrderResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, System.Guid reservationOrderId, Azure.ResourceManager.Reservations.Models.ReservationPurchaseContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(System.Guid reservationOrderId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Guid reservationOrderId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Reservations.ReservationOrderResource> Get(System.Guid reservationOrderId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Reservations.ReservationOrderResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Reservations.ReservationOrderResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.ReservationOrderResource>> GetAsync(System.Guid reservationOrderId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Reservations.ReservationOrderResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Reservations.ReservationOrderResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Reservations.ReservationOrderResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Reservations.ReservationOrderResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ReservationOrderData : Azure.ResourceManager.Models.ResourceData
    {
        internal ReservationOrderData() { }
        public System.DateTimeOffset? BenefitStartOn { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservationBillingPlan? BillingPlan { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public int? OriginalQuantity { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservationOrderBillingPlanInformation PlanInformation { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservationProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? RequestOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.ReservationDetailData> Reservations { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservationTerm? Term { get { throw null; } }
        public int? Version { get { throw null; } }
    }
    public partial class ReservationOrderResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ReservationOrderResource() { }
        public virtual Azure.ResourceManager.Reservations.ReservationOrderData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Reservations.Models.ReservationCalculateRefundResult> CalculateRefund(Azure.ResourceManager.Reservations.Models.ReservationCalculateRefundContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.Models.ReservationCalculateRefundResult>> CalculateRefundAsync(Azure.ResourceManager.Reservations.Models.ReservationCalculateRefundContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Reservations.Models.ChangeDirectoryDetail> ChangeDirectory(Azure.ResourceManager.Reservations.Models.ChangeDirectoryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.Models.ChangeDirectoryDetail>> ChangeDirectoryAsync(Azure.ResourceManager.Reservations.Models.ChangeDirectoryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(System.Guid reservationOrderId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Reservations.ReservationOrderResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.ReservationOrderResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Reservations.ReservationDetailResource> GetReservationDetail(System.Guid reservationId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.ReservationDetailResource>> GetReservationDetailAsync(System.Guid reservationId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Reservations.ReservationDetailCollection GetReservationDetails() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<System.Collections.Generic.IList<Azure.ResourceManager.Reservations.ReservationDetailData>> MergeReservation(Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.Models.MergeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<System.Collections.Generic.IList<Azure.ResourceManager.Reservations.ReservationDetailData>>> MergeReservationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.Models.MergeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Reservations.Models.ReservationRefundResult> Return(Azure.ResourceManager.Reservations.Models.ReservationRefundContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.Models.ReservationRefundResult>> ReturnAsync(Azure.ResourceManager.Reservations.Models.ReservationRefundContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<System.Collections.Generic.IList<Azure.ResourceManager.Reservations.ReservationDetailData>> SplitReservation(Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.Models.SplitContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<System.Collections.Generic.IList<Azure.ResourceManager.Reservations.ReservationDetailData>>> SplitReservationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.Models.SplitContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.ReservationOrderResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.Models.ReservationPurchaseContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.ReservationOrderResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.Models.ReservationPurchaseContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ReservationQuotaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Reservations.ReservationQuotaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Reservations.ReservationQuotaResource>, System.Collections.IEnumerable
    {
        protected ReservationQuotaCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.ReservationQuotaResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.Reservations.ReservationQuotaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.ReservationQuotaResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.Reservations.ReservationQuotaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Reservations.ReservationQuotaResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Reservations.ReservationQuotaResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Reservations.ReservationQuotaResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.ReservationQuotaResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Reservations.ReservationQuotaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Reservations.ReservationQuotaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Reservations.ReservationQuotaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Reservations.ReservationQuotaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ReservationQuotaData : Azure.ResourceManager.Models.ResourceData
    {
        public ReservationQuotaData() { }
        public Azure.ResourceManager.Reservations.Models.QuotaProperties Properties { get { throw null; } set { } }
    }
    public partial class ReservationQuotaResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ReservationQuotaResource() { }
        public virtual Azure.ResourceManager.Reservations.ReservationQuotaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string providerId, Azure.Core.AzureLocation location, string resourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Reservations.ReservationQuotaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.ReservationQuotaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.ReservationQuotaResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.ReservationQuotaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.ReservationQuotaResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.ReservationQuotaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ReservationsExtensions
    {
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.Models.CalculateExchangeResult> CalculateReservationExchange(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.Models.CalculateExchangeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.Models.CalculateExchangeResult>> CalculateReservationExchangeAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.Models.CalculateExchangeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Reservations.Models.CalculatePriceResult> CalculateReservationOrder(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.Reservations.Models.ReservationPurchaseContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.Models.CalculatePriceResult>> CalculateReservationOrderAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.Reservations.Models.ReservationPurchaseContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.Models.ExchangeResult> Exchange(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.Models.ExchangeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.Models.ExchangeResult>> ExchangeAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.Models.ExchangeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Reservations.ReservationQuotaCollection GetAllReservationQuota(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string providerId, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Reservations.Models.AppliedReservationData> GetAppliedReservations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.Models.AppliedReservationData>> GetAppliedReservationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Reservations.Models.ReservationCatalog> GetCatalog(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string reservedResourceType = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string publisherId = null, string offerId = null, string planId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Reservations.Models.ReservationCatalog> GetCatalogAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string reservedResourceType = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string publisherId = null, string offerId = null, string planId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Reservations.QuotaRequestDetailResource> GetQuotaRequestDetail(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string providerId, Azure.Core.AzureLocation location, System.Guid id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.QuotaRequestDetailResource>> GetQuotaRequestDetailAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string providerId, Azure.Core.AzureLocation location, System.Guid id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Reservations.QuotaRequestDetailResource GetQuotaRequestDetailResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Reservations.QuotaRequestDetailCollection GetQuotaRequestDetails(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string providerId, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.ResourceManager.Reservations.ReservationDetailResource GetReservationDetailResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Reservations.ReservationDetailResource> GetReservationDetails(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.Reservations.Models.TenantResourceGetReservationDetailsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Reservations.ReservationDetailResource> GetReservationDetails(this Azure.ResourceManager.Resources.TenantResource tenantResource, string filter = null, string orderby = null, string refreshSummary = null, float? skiptoken = default(float?), string selectedState = null, float? take = default(float?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Reservations.ReservationDetailResource> GetReservationDetailsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.Reservations.Models.TenantResourceGetReservationDetailsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Reservations.ReservationDetailResource> GetReservationDetailsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string filter = null, string orderby = null, string refreshSummary = null, float? skiptoken = default(float?), string selectedState = null, float? take = default(float?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Reservations.ReservationOrderResource> GetReservationOrder(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid reservationOrderId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.ReservationOrderResource>> GetReservationOrderAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid reservationOrderId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Reservations.ReservationOrderResource GetReservationOrderResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Reservations.ReservationOrderCollection GetReservationOrders(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Reservations.ReservationQuotaResource> GetReservationQuota(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string providerId, Azure.Core.AzureLocation location, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.ReservationQuotaResource>> GetReservationQuotaAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string providerId, Azure.Core.AzureLocation location, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Reservations.ReservationQuotaResource GetReservationQuotaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
}
namespace Azure.ResourceManager.Reservations.Mock
{
    public partial class ReservationDetailResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected ReservationDetailResourceExtensionClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Reservations.ReservationDetailResource> GetReservationDetails(Azure.ResourceManager.Reservations.Models.TenantResourceGetReservationDetailsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Reservations.ReservationDetailResource> GetReservationDetailsAsync(Azure.ResourceManager.Reservations.Models.TenantResourceGetReservationDetailsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ReservationOrderResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected ReservationOrderResourceExtensionClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Reservations.Models.CalculatePriceResult> CalculateReservationOrder(Azure.ResourceManager.Reservations.Models.ReservationPurchaseContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.Models.CalculatePriceResult>> CalculateReservationOrderAsync(Azure.ResourceManager.Reservations.Models.ReservationPurchaseContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected SubscriptionResourceExtensionClient() { }
        public virtual Azure.ResourceManager.Reservations.ReservationQuotaCollection GetAllReservationQuota(string providerId, Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Reservations.Models.AppliedReservationData> GetAppliedReservations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Reservations.Models.AppliedReservationData>> GetAppliedReservationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Reservations.Models.ReservationCatalog> GetCatalog(string reservedResourceType = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string publisherId = null, string offerId = null, string planId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Reservations.Models.ReservationCatalog> GetCatalogAsync(string reservedResourceType = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string publisherId = null, string offerId = null, string planId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Reservations.QuotaRequestDetailCollection GetQuotaRequestDetails(string providerId, Azure.Core.AzureLocation location) { throw null; }
    }
    public partial class TenantResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected TenantResourceExtensionClient() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.Models.CalculateExchangeResult> CalculateReservationExchange(Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.Models.CalculateExchangeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.Models.CalculateExchangeResult>> CalculateReservationExchangeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.Models.CalculateExchangeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.Models.ExchangeResult> Exchange(Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.Models.ExchangeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Reservations.Models.ExchangeResult>> ExchangeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Reservations.Models.ExchangeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Reservations.ReservationOrderCollection GetReservationOrders() { throw null; }
    }
}
namespace Azure.ResourceManager.Reservations.Models
{
    public partial class AppliedReservationData : Azure.ResourceManager.Models.ResourceData
    {
        internal AppliedReservationData() { }
        public Azure.ResourceManager.Reservations.Models.AppliedReservationList ReservationOrderIds { get { throw null; } }
    }
    public partial class AppliedReservationList
    {
        internal AppliedReservationList() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Value { get { throw null; } }
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
    public partial class AvailableScopesContent
    {
        public AvailableScopesContent() { }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
    }
    public partial class AvailableScopesProperties
    {
        internal AvailableScopesProperties() { }
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
        public Azure.ResourceManager.Reservations.Models.CalculateExchangeContentProperties Properties { get { throw null; } set { } }
    }
    public partial class CalculateExchangeContentProperties
    {
        public CalculateExchangeContentProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Reservations.Models.ReservationToReturn> ReservationsToExchange { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Reservations.Models.ReservationPurchaseContent> ReservationsToPurchase { get { throw null; } }
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
    public partial class CalculateExchangeResult
    {
        internal CalculateExchangeResult() { }
        public Azure.ResourceManager.Reservations.Models.OperationResultError Error { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.CalculateExchangeResultProperties Properties { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.CalculateExchangeOperationResultStatus? Status { get { throw null; } }
    }
    public partial class CalculateExchangeResultProperties
    {
        internal CalculateExchangeResultProperties() { }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice NetPayable { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.Models.ExchangePolicyError> PolicyErrors { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice PurchasesTotal { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice RefundsTotal { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.Models.ReservationToExchange> ReservationsToExchange { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.Models.ReservationToPurchaseCalculateExchange> ReservationsToPurchase { get { throw null; } }
        public System.Guid? SessionId { get { throw null; } }
    }
    public partial class CalculatePriceResult
    {
        internal CalculatePriceResult() { }
        public Azure.ResourceManager.Reservations.Models.CalculatePriceResultProperties Properties { get { throw null; } }
    }
    public partial class CalculatePriceResultProperties
    {
        internal CalculatePriceResultProperties() { }
        public Azure.ResourceManager.Reservations.Models.CalculatePriceResultPropertiesBillingCurrencyTotal BillingCurrencyTotal { get { throw null; } }
        public double? GrandTotal { get { throw null; } }
        public bool? IsBillingPartnerManaged { get { throw null; } }
        public bool? IsTaxIncluded { get { throw null; } }
        public double? NetTotal { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.Models.PaymentDetail> PaymentSchedule { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.CalculatePriceResultPropertiesPricingCurrencyTotal PricingCurrencyTotal { get { throw null; } }
        public System.Guid? ReservationOrderId { get { throw null; } }
        public string SkuDescription { get { throw null; } }
        public string SkuTitle { get { throw null; } }
        public double? TaxTotal { get { throw null; } }
    }
    public partial class CalculatePriceResultPropertiesBillingCurrencyTotal
    {
        internal CalculatePriceResultPropertiesBillingCurrencyTotal() { }
        public double? Amount { get { throw null; } }
        public string CurrencyCode { get { throw null; } }
    }
    public partial class CalculatePriceResultPropertiesPricingCurrencyTotal
    {
        internal CalculatePriceResultPropertiesPricingCurrencyTotal() { }
        public float? Amount { get { throw null; } }
        public string CurrencyCode { get { throw null; } }
    }
    public partial class ChangeDirectoryContent
    {
        public ChangeDirectoryContent() { }
        public System.Guid? DestinationTenantId { get { throw null; } set { } }
    }
    public partial class ChangeDirectoryDetail
    {
        internal ChangeDirectoryDetail() { }
        public Azure.ResourceManager.Reservations.Models.ChangeDirectoryResult ReservationOrder { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.Models.ChangeDirectoryResult> Reservations { get { throw null; } }
    }
    public partial class ChangeDirectoryResult
    {
        internal ChangeDirectoryResult() { }
        public string Error { get { throw null; } }
        public System.Guid? Id { get { throw null; } }
        public bool? IsSucceeded { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class ExchangeContent
    {
        public ExchangeContent() { }
        public System.Guid? ExchangeRequestSessionId { get { throw null; } set { } }
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
    public partial class ExchangeResult
    {
        internal ExchangeResult() { }
        public Azure.ResourceManager.Reservations.Models.OperationResultError Error { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ExchangeResultProperties Properties { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ExchangeOperationResultStatus? Status { get { throw null; } }
    }
    public partial class ExchangeResultProperties
    {
        internal ExchangeResultProperties() { }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice NetPayable { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.Models.ExchangePolicyError> PolicyErrors { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice PurchasesTotal { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice RefundsTotal { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.Models.ReservationToReturnForExchange> ReservationsToExchange { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.Models.ReservationToPurchaseExchange> ReservationsToPurchase { get { throw null; } }
        public System.Guid? SessionId { get { throw null; } }
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
    public partial class OperationResultError
    {
        internal OperationResultError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class PaymentDetail
    {
        internal PaymentDetail() { }
        public string BillingAccount { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice BillingCurrencyTotal { get { throw null; } }
        public System.DateTimeOffset? DueOn { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ExtendedStatusInfo ExtendedStatusInfo { get { throw null; } }
        public System.DateTimeOffset? PayOn { get { throw null; } }
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
    public partial class PurchasePrice
    {
        internal PurchasePrice() { }
        public double? Amount { get { throw null; } }
        public string CurrencyCode { get { throw null; } }
    }
    public partial class QuotaProperties
    {
        public QuotaProperties() { }
        public int? CurrentValue { get { throw null; } }
        public int? Limit { get { throw null; } set { } }
        public System.BinaryData Properties { get { throw null; } set { } }
        public string QuotaPeriod { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservationResourceName ResourceName { get { throw null; } set { } }
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
    public partial class RenewProperties
    {
        internal RenewProperties() { }
        public Azure.ResourceManager.Reservations.Models.RenewPropertiesBillingCurrencyTotal BillingCurrencyTotal { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.RenewPropertiesPricingCurrencyTotal PricingCurrencyTotal { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservationPurchaseContent PurchaseProperties { get { throw null; } }
    }
    public partial class RenewPropertiesBillingCurrencyTotal
    {
        internal RenewPropertiesBillingCurrencyTotal() { }
        public float? Amount { get { throw null; } }
        public string CurrencyCode { get { throw null; } }
    }
    public partial class RenewPropertiesPricingCurrencyTotal
    {
        internal RenewPropertiesPricingCurrencyTotal() { }
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
    public partial class ReservationCalculateRefundContent
    {
        public ReservationCalculateRefundContent() { }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.Reservations.Models.ReservationCalculateRefundRequestProperties Properties { get { throw null; } set { } }
    }
    public partial class ReservationCalculateRefundRequestProperties
    {
        public ReservationCalculateRefundRequestProperties() { }
        public Azure.ResourceManager.Reservations.Models.ReservationToReturn ReservationToReturn { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
    }
    public partial class ReservationCalculateRefundResult
    {
        internal ReservationCalculateRefundResult() { }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservationRefundResponseProperties Properties { get { throw null; } }
    }
    public partial class ReservationCatalog
    {
        internal ReservationCatalog() { }
        public string AppliedResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IList<Azure.ResourceManager.Reservations.Models.ReservationBillingPlan>> BillingPlans { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.Models.SkuCapability> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice MsrpP1Y { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.Models.SkuRestriction> Restrictions { get { throw null; } }
        public string Size { get { throw null; } }
        public string SkuName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.Models.SkuProperty> SkuProperties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.Models.ReservationTerm> Terms { get { throw null; } }
        public string Tier { get { throw null; } }
    }
    public partial class ReservationDetailPatch
    {
        public ReservationDetailPatch() { }
        public System.Collections.Generic.IList<string> AppliedScopes { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.AppliedScopeType? AppliedScopeType { get { throw null; } set { } }
        public Azure.ResourceManager.Reservations.Models.InstanceFlexibility? InstanceFlexibility { get { throw null; } set { } }
        public bool? IsRenewEnabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Reservations.Models.ReservationPurchaseContent RenewPurchaseProperties { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReservationErrorResponseCode : System.IEquatable<Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReservationErrorResponseCode(string value) { throw null; }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode ActivateQuoteFailed { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode AppliedScopesNotAssociatedWithCommerceAccount { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode AppliedScopesSameAsExisting { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode AuthorizationFailed { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode BadRequest { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode BillingCustomerInputError { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode BillingError { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode BillingPaymentInstrumentHardError { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode BillingPaymentInstrumentSoftError { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode BillingScopeIdCannotBeChanged { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode BillingTransientError { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode CalculatePriceFailed { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode CapacityUpdateScopesFailed { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode ClientCertificateThumbprintNotSet { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode CreateQuoteFailed { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode Forbidden { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode FulfillmentConfigurationError { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode FulfillmentError { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode FulfillmentOutOfStockError { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode FulfillmentTransientError { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode HttpMethodNotSupported { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode InternalServerError { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode InvalidAccessToken { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode InvalidFulfillmentRequestParameters { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode InvalidHealthCheckType { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode InvalidLocationId { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode InvalidRefundQuantity { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode InvalidRequestContent { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode InvalidRequestUri { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode InvalidReservationId { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode InvalidReservationOrderId { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode InvalidSingleAppliedScopesCount { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode InvalidSubscriptionId { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode InvalidTenantId { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode MissingAppliedScopesForSingle { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode MissingTenantId { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode NonsupportedAccountId { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode NotSupportedCountry { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode NoValidReservationsToReRate { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode OperationCannotBePerformedInCurrentState { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode OperationFailed { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode PatchValuesSameAsExisting { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode PaymentInstrumentNotFound { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode PurchaseError { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode RefundLimitExceeded { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode ReRateOnlyAllowedForEA { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode ReservationIdNotInReservationOrder { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode ReservationOrderCreationFailed { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode ReservationOrderIdAlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode ReservationOrderNotEnabled { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode ReservationOrderNotFound { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode RiskCheckFailed { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode RoleAssignmentCreationFailed { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode SelfServiceRefundNotSupported { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode ServerTimeout { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode UnauthenticatedRequestsThrottled { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode UnsupportedReservationTerm { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode left, Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode left, Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReservationKind : System.IEquatable<Azure.ResourceManager.Reservations.Models.ReservationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReservationKind(string value) { throw null; }
        public static Azure.ResourceManager.Reservations.Models.ReservationKind MicrosoftCompute { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Reservations.Models.ReservationKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Reservations.Models.ReservationKind left, Azure.ResourceManager.Reservations.Models.ReservationKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Reservations.Models.ReservationKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Reservations.Models.ReservationKind left, Azure.ResourceManager.Reservations.Models.ReservationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReservationMergeProperties
    {
        internal ReservationMergeProperties() { }
        public string MergeDestination { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> MergeSources { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReservationOperationStatus : System.IEquatable<Azure.ResourceManager.Reservations.Models.ReservationOperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReservationOperationStatus(string value) { throw null; }
        public static Azure.ResourceManager.Reservations.Models.ReservationOperationStatus Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationOperationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationOperationStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationOperationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Reservations.Models.ReservationOperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Reservations.Models.ReservationOperationStatus left, Azure.ResourceManager.Reservations.Models.ReservationOperationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Reservations.Models.ReservationOperationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Reservations.Models.ReservationOperationStatus left, Azure.ResourceManager.Reservations.Models.ReservationOperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReservationOrderBillingPlanInformation
    {
        internal ReservationOrderBillingPlanInformation() { }
        public System.DateTimeOffset? NextPaymentDueOn { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice PricingCurrencyTotal { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.Models.PaymentDetail> Transactions { get { throw null; } }
    }
    public partial class ReservationProperties
    {
        internal ReservationProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> AppliedScopes { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.AppliedScopeType? AppliedScopeType { get { throw null; } }
        public System.DateTimeOffset? BenefitStartOn { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservationBillingPlan? BillingPlan { get { throw null; } }
        public Azure.Core.ResourceIdentifier BillingScopeId { get { throw null; } }
        public string Capabilities { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string DisplayProvisioningState { get { throw null; } }
        public System.DateTimeOffset? EffectOn { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ExtendedStatusInfo ExtendedStatusInfo { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.InstanceFlexibility? InstanceFlexibility { get { throw null; } }
        public bool? IsArchived { get { throw null; } }
        public bool? IsRenewEnabled { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservationMergeProperties MergeProperties { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservationProvisioningState? ProvisioningState { get { throw null; } }
        public string ProvisioningSubState { get { throw null; } }
        public System.DateTimeOffset? PurchaseOn { get { throw null; } }
        public int? Quantity { get { throw null; } }
        public string RenewDestination { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.RenewProperties RenewProperties { get { throw null; } }
        public string RenewSource { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservedResourceType? ReservedResourceType { get { throw null; } }
        public string SkuDescription { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservationSplitProperties SplitProperties { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservationTerm? Term { get { throw null; } }
        public string UserFriendlyAppliedScopeType { get { throw null; } }
        public string UserFriendlyRenewState { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservationPropertiesUtilization Utilization { get { throw null; } }
    }
    public partial class ReservationPropertiesUtilization
    {
        internal ReservationPropertiesUtilization() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.Models.ReservationUtilizationAggregates> Aggregates { get { throw null; } }
        public string Trend { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReservationProvisioningState : System.IEquatable<Azure.ResourceManager.Reservations.Models.ReservationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReservationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Reservations.Models.ReservationProvisioningState BillingFailed { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationProvisioningState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationProvisioningState ConfirmedBilling { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationProvisioningState ConfirmedResourceHold { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationProvisioningState Expired { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationProvisioningState Merged { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationProvisioningState PendingBilling { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationProvisioningState PendingResourceHold { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationProvisioningState Split { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservationProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Reservations.Models.ReservationProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Reservations.Models.ReservationProvisioningState left, Azure.ResourceManager.Reservations.Models.ReservationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Reservations.Models.ReservationProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Reservations.Models.ReservationProvisioningState left, Azure.ResourceManager.Reservations.Models.ReservationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReservationPurchaseContent
    {
        public ReservationPurchaseContent() { }
        public System.Collections.Generic.IList<string> AppliedScopes { get { throw null; } set { } }
        public Azure.ResourceManager.Reservations.Models.AppliedScopeType? AppliedScopeType { get { throw null; } set { } }
        public Azure.ResourceManager.Reservations.Models.ReservationBillingPlan? BillingPlan { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier BillingScopeId { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsRenewEnabled { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public int? Quantity { get { throw null; } set { } }
        public Azure.ResourceManager.Reservations.Models.InstanceFlexibility? ReservedResourceInstanceFlexibility { get { throw null; } set { } }
        public Azure.ResourceManager.Reservations.Models.ReservedResourceType? ReservedResourceType { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.Reservations.Models.ReservationTerm? Term { get { throw null; } set { } }
    }
    public partial class ReservationRefundBillingInformation
    {
        internal ReservationRefundBillingInformation() { }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice BillingCurrencyProratedAmount { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice BillingCurrencyRemainingCommitmentAmount { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice BillingCurrencyTotalPaidAmount { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservationBillingPlan? BillingPlan { get { throw null; } }
        public int? CompletedTransactions { get { throw null; } }
        public int? TotalTransactions { get { throw null; } }
    }
    public partial class ReservationRefundContent
    {
        public ReservationRefundContent() { }
        public Azure.ResourceManager.Reservations.Models.ReservationRefundRequestProperties Properties { get { throw null; } set { } }
    }
    public partial class ReservationRefundPolicyError
    {
        internal ReservationRefundPolicyError() { }
        public Azure.ResourceManager.Reservations.Models.ReservationErrorResponseCode? Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class ReservationRefundPolicyResultProperty
    {
        internal ReservationRefundPolicyResultProperty() { }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice ConsumedRefundsTotal { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice MaxRefundLimit { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Reservations.Models.ReservationRefundPolicyError> PolicyErrors { get { throw null; } }
    }
    public partial class ReservationRefundRequestProperties
    {
        public ReservationRefundRequestProperties() { }
        public Azure.ResourceManager.Reservations.Models.ReservationToReturn ReservationToReturn { get { throw null; } set { } }
        public string ReturnReason { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public System.Guid? SessionId { get { throw null; } set { } }
    }
    public partial class ReservationRefundResponseProperties
    {
        internal ReservationRefundResponseProperties() { }
        public Azure.ResourceManager.Reservations.Models.ReservationRefundBillingInformation BillingInformation { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice BillingRefundAmount { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservationRefundPolicyResultProperty PolicyResultProperties { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice PricingRefundAmount { get { throw null; } }
        public int? Quantity { get { throw null; } }
        public System.Guid? SessionId { get { throw null; } }
    }
    public partial class ReservationRefundResult
    {
        internal ReservationRefundResult() { }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservationRefundResponseProperties Properties { get { throw null; } }
    }
    public partial class ReservationResourceName
    {
        public ReservationResourceName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } set { } }
    }
    public partial class ReservationSplitProperties
    {
        internal ReservationSplitProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> SplitDestinations { get { throw null; } }
        public string SplitSource { get { throw null; } }
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
        public Azure.Core.ResourceIdentifier ReservationId { get { throw null; } }
    }
    public partial class ReservationToPurchaseCalculateExchange
    {
        internal ReservationToPurchaseCalculateExchange() { }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice BillingCurrencyTotal { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservationPurchaseContent Properties { get { throw null; } }
    }
    public partial class ReservationToPurchaseExchange
    {
        internal ReservationToPurchaseExchange() { }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice BillingCurrencyTotal { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservationPurchaseContent Properties { get { throw null; } }
        public Azure.Core.ResourceIdentifier ReservationId { get { throw null; } }
        public Azure.Core.ResourceIdentifier ReservationOrderId { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservationOperationStatus? Status { get { throw null; } }
    }
    public partial class ReservationToReturn
    {
        public ReservationToReturn() { }
        public int? Quantity { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ReservationId { get { throw null; } set { } }
    }
    public partial class ReservationToReturnForExchange
    {
        internal ReservationToReturnForExchange() { }
        public Azure.ResourceManager.Reservations.Models.BillingInformation BillingInformation { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.PurchasePrice BillingRefundAmount { get { throw null; } }
        public int? Quantity { get { throw null; } }
        public Azure.Core.ResourceIdentifier ReservationId { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservationOperationStatus? Status { get { throw null; } }
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
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType Avs { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType AzureDataExplorer { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType AzureFiles { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType BlockBlob { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType CosmosDB { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType Databricks { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType DataFactory { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType DedicatedHost { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType ManagedDisk { get { throw null; } }
        public static Azure.ResourceManager.Reservations.Models.ReservedResourceType MariaDB { get { throw null; } }
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
        public bool? IsValid { get { throw null; } }
        public string Scope { get { throw null; } }
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
        public Azure.Core.ResourceIdentifier ReservationId { get { throw null; } set { } }
    }
    public partial class SubContent
    {
        internal SubContent() { }
        public int? Limit { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.ReservationResourceName Name { get { throw null; } }
        public Azure.ResourceManager.Reservations.Models.QuotaRequestState? ProvisioningState { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Guid? SubRequestId { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class TenantResourceGetReservationDetailsOptions
    {
        public TenantResourceGetReservationDetailsOptions() { }
        public string Filter { get { throw null; } set { } }
        public string Orderby { get { throw null; } set { } }
        public string RefreshSummary { get { throw null; } set { } }
        public string SelectedState { get { throw null; } set { } }
        public float? Skiptoken { get { throw null; } set { } }
        public float? Take { get { throw null; } set { } }
    }
}
