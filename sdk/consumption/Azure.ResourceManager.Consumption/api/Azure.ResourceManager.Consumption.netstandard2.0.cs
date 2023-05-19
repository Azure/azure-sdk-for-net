namespace Azure.ResourceManager.Consumption
{
    public partial class BillingAccountConsumptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BillingAccountConsumptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceResult> GetBalance(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceResult>> GetBalanceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Consumption.Models.ConsumptionEventSummary> GetEvents(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.ConsumptionEventSummary> GetEventsAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Consumption.Models.ConsumptionLotSummary> GetLots(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.ConsumptionLotSummary> GetLotsAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Consumption.Models.ConsumptionReservationTransaction> GetReservationTransactions(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.ConsumptionReservationTransaction> GetReservationTransactionsAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BillingCustomerConsumptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BillingCustomerConsumptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Consumption.Models.ConsumptionLotSummary> GetLots(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.ConsumptionLotSummary> GetLotsAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BillingProfileConsumptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BillingProfileConsumptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Consumption.Models.ConsumptionCreditSummary> GetCredit(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Consumption.Models.ConsumptionCreditSummary>> GetCreditAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Consumption.Models.ConsumptionEventSummary> GetEvents(string startDate, string endDate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.ConsumptionEventSummary> GetEventsAsync(string startDate, string endDate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Consumption.Models.ConsumptionLotSummary> GetLots(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.ConsumptionLotSummary> GetLotsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Consumption.Models.ConsumptionModernReservationTransaction> GetReservationTransactions(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.ConsumptionModernReservationTransaction> GetReservationTransactionsAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConsumptionBudgetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Consumption.ConsumptionBudgetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Consumption.ConsumptionBudgetResource>, System.Collections.IEnumerable
    {
        protected ConsumptionBudgetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Consumption.ConsumptionBudgetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string budgetName, Azure.ResourceManager.Consumption.ConsumptionBudgetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Consumption.ConsumptionBudgetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string budgetName, Azure.ResourceManager.Consumption.ConsumptionBudgetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string budgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string budgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Consumption.ConsumptionBudgetResource> Get(string budgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Consumption.ConsumptionBudgetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Consumption.ConsumptionBudgetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Consumption.ConsumptionBudgetResource>> GetAsync(string budgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Consumption.ConsumptionBudgetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Consumption.ConsumptionBudgetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Consumption.ConsumptionBudgetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Consumption.ConsumptionBudgetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConsumptionBudgetData : Azure.ResourceManager.Models.ResourceData
    {
        public ConsumptionBudgetData() { }
        public decimal? Amount { get { throw null; } set { } }
        public Azure.ResourceManager.Consumption.Models.BudgetCategory? Category { get { throw null; } set { } }
        public Azure.ResourceManager.Consumption.Models.BudgetCurrentSpend CurrentSpend { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionBudgetFilter Filter { get { throw null; } set { } }
        public Azure.ResourceManager.Consumption.Models.BudgetForecastSpend ForecastSpend { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Consumption.Models.BudgetAssociatedNotification> Notifications { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.BudgetTimeGrainType? TimeGrain { get { throw null; } set { } }
        public Azure.ResourceManager.Consumption.Models.BudgetTimePeriod TimePeriod { get { throw null; } set { } }
    }
    public partial class ConsumptionBudgetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConsumptionBudgetResource() { }
        public virtual Azure.ResourceManager.Consumption.ConsumptionBudgetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string budgetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Consumption.ConsumptionBudgetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Consumption.ConsumptionBudgetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Consumption.ConsumptionBudgetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Consumption.ConsumptionBudgetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Consumption.ConsumptionBudgetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Consumption.ConsumptionBudgetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ConsumptionExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Consumption.Models.ConsumptionAggregatedCostResult> GetAggregatedCost(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Consumption.Models.ConsumptionAggregatedCostResult>> GetAggregatedCostAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Consumption.BillingAccountConsumptionResource GetBillingAccountConsumptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Consumption.BillingCustomerConsumptionResource GetBillingCustomerConsumptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Consumption.BillingProfileConsumptionResource GetBillingProfileConsumptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Consumption.ConsumptionBudgetResource> GetConsumptionBudget(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string budgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Consumption.ConsumptionBudgetResource>> GetConsumptionBudgetAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string budgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Consumption.ConsumptionBudgetResource GetConsumptionBudgetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Consumption.ConsumptionBudgetCollection GetConsumptionBudgets(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Consumption.Models.ConsumptionChargeSummary> GetConsumptionCharges(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string startDate = null, string endDate = null, string filter = null, string apply = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.ConsumptionChargeSummary> GetConsumptionChargesAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string startDate = null, string endDate = null, string filter = null, string apply = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Consumption.Models.ConsumptionMarketplace> GetConsumptionMarketPlaces(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.ConsumptionMarketplace> GetConsumptionMarketPlacesAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationDetails> GetConsumptionReservationRecommendationDetails(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationScope reservationScope, string region, Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationTerm term, Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationLookBackPeriod lookBackPeriod, string product, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationDetails>> GetConsumptionReservationRecommendationDetailsAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationScope reservationScope, string region, Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationTerm term, Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationLookBackPeriod lookBackPeriod, string product, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendation> GetConsumptionReservationRecommendations(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendation> GetConsumptionReservationRecommendationsAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Consumption.Models.ConsumptionReservationDetail> GetConsumptionReservationsDetails(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string startDate = null, string endDate = null, string filter = null, string reservationId = null, string reservationOrderId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.ConsumptionReservationDetail> GetConsumptionReservationsDetailsAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string startDate = null, string endDate = null, string filter = null, string reservationId = null, string reservationOrderId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Consumption.Models.ConsumptionReservationSummary> GetConsumptionReservationsSummaries(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.Consumption.Models.ArmResourceGetConsumptionReservationsSummariesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.ConsumptionReservationSummary> GetConsumptionReservationsSummariesAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.Consumption.Models.ArmResourceGetConsumptionReservationsSummariesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Consumption.Models.ConsumptionTagsResult> GetConsumptionTags(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Consumption.Models.ConsumptionTagsResult>> GetConsumptionTagsAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Consumption.Models.ConsumptionUsageDetail> GetConsumptionUsageDetails(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string expand = null, string filter = null, string skipToken = null, int? top = default(int?), Azure.ResourceManager.Consumption.Models.ConsumptionMetricType? metric = default(Azure.ResourceManager.Consumption.Models.ConsumptionMetricType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.ConsumptionUsageDetail> GetConsumptionUsageDetailsAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string expand = null, string filter = null, string skipToken = null, int? top = default(int?), Azure.ResourceManager.Consumption.Models.ConsumptionMetricType? metric = default(Azure.ResourceManager.Consumption.Models.ConsumptionMetricType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Consumption.ManagementGroupBillingPeriodConsumptionResource GetManagementGroupBillingPeriodConsumptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Consumption.Models.PriceSheetResult> GetPriceSheet(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string expand = null, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Consumption.Models.PriceSheetResult>> GetPriceSheetAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string expand = null, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Consumption.ReservationConsumptionResource GetReservationConsumptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Consumption.ReservationOrderConsumptionResource GetReservationOrderConsumptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Consumption.SubscriptionBillingPeriodConsumptionResource GetSubscriptionBillingPeriodConsumptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Consumption.TenantBillingPeriodConsumptionResource GetTenantBillingPeriodConsumptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class ManagementGroupBillingPeriodConsumptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagementGroupBillingPeriodConsumptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Consumption.Models.ConsumptionAggregatedCostResult> GetAggregatedCost(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Consumption.Models.ConsumptionAggregatedCostResult>> GetAggregatedCostAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ReservationConsumptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ReservationConsumptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Consumption.Models.ConsumptionReservationDetail> GetReservationDetails(string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.ConsumptionReservationDetail> GetReservationDetailsAsync(string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Consumption.Models.ConsumptionReservationSummary> GetReservationSummaries(Azure.ResourceManager.Consumption.Models.ReservationSummaryDataGrain grain, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.ConsumptionReservationSummary> GetReservationSummariesAsync(Azure.ResourceManager.Consumption.Models.ReservationSummaryDataGrain grain, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ReservationOrderConsumptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ReservationOrderConsumptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Consumption.Models.ConsumptionReservationDetail> GetReservationDetails(string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.ConsumptionReservationDetail> GetReservationDetailsAsync(string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Consumption.Models.ConsumptionReservationSummary> GetReservationSummaries(Azure.ResourceManager.Consumption.Models.ReservationSummaryDataGrain grain, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.ConsumptionReservationSummary> GetReservationSummariesAsync(Azure.ResourceManager.Consumption.Models.ReservationSummaryDataGrain grain, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionBillingPeriodConsumptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SubscriptionBillingPeriodConsumptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Consumption.Models.PriceSheetResult> GetPriceSheet(string expand = null, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Consumption.Models.PriceSheetResult>> GetPriceSheetAsync(string expand = null, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantBillingPeriodConsumptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TenantBillingPeriodConsumptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceResult> GetBalance(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceResult>> GetBalanceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Consumption.Models
{
    public partial class ArmResourceGetConsumptionReservationsSummariesOptions
    {
        public ArmResourceGetConsumptionReservationsSummariesOptions(Azure.ResourceManager.Consumption.Models.ReservationSummaryDataGrain grain) { }
        public string EndDate { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public Azure.ResourceManager.Consumption.Models.ReservationSummaryDataGrain Grain { get { throw null; } }
        public string ReservationId { get { throw null; } set { } }
        public string ReservationOrderId { get { throw null; } set { } }
        public string StartDate { get { throw null; } set { } }
    }
    public partial class BudgetAssociatedNotification
    {
        public BudgetAssociatedNotification(bool isEnabled, Azure.ResourceManager.Consumption.Models.NotificationAlertTriggerType @operator, decimal threshold, System.Collections.Generic.IEnumerable<string> contactEmails) { }
        public System.Collections.Generic.IList<string> ContactEmails { get { throw null; } }
        public System.Collections.Generic.IList<string> ContactGroups { get { throw null; } }
        public System.Collections.Generic.IList<string> ContactRoles { get { throw null; } }
        public bool IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Consumption.Models.RecipientNotificationLanguageCode? Locale { get { throw null; } set { } }
        public Azure.ResourceManager.Consumption.Models.NotificationAlertTriggerType Operator { get { throw null; } set { } }
        public decimal Threshold { get { throw null; } set { } }
        public Azure.ResourceManager.Consumption.Models.NotificationThresholdType? ThresholdType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BudgetCategory : System.IEquatable<Azure.ResourceManager.Consumption.Models.BudgetCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BudgetCategory(string value) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.BudgetCategory Cost { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Consumption.Models.BudgetCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Consumption.Models.BudgetCategory left, Azure.ResourceManager.Consumption.Models.BudgetCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.Consumption.Models.BudgetCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Consumption.Models.BudgetCategory left, Azure.ResourceManager.Consumption.Models.BudgetCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BudgetComparisonExpression
    {
        public BudgetComparisonExpression(string name, Azure.ResourceManager.Consumption.Models.BudgetOperatorType @operator, System.Collections.Generic.IEnumerable<string> values) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Consumption.Models.BudgetOperatorType Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
    }
    public partial class BudgetCurrentSpend
    {
        internal BudgetCurrentSpend() { }
        public decimal? Amount { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class BudgetFilterProperties
    {
        public BudgetFilterProperties() { }
        public Azure.ResourceManager.Consumption.Models.BudgetComparisonExpression Dimensions { get { throw null; } set { } }
        public Azure.ResourceManager.Consumption.Models.BudgetComparisonExpression Tags { get { throw null; } set { } }
    }
    public partial class BudgetForecastSpend
    {
        internal BudgetForecastSpend() { }
        public decimal? Amount { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BudgetOperatorType : System.IEquatable<Azure.ResourceManager.Consumption.Models.BudgetOperatorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BudgetOperatorType(string value) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.BudgetOperatorType In { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Consumption.Models.BudgetOperatorType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Consumption.Models.BudgetOperatorType left, Azure.ResourceManager.Consumption.Models.BudgetOperatorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Consumption.Models.BudgetOperatorType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Consumption.Models.BudgetOperatorType left, Azure.ResourceManager.Consumption.Models.BudgetOperatorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BudgetTimeGrainType : System.IEquatable<Azure.ResourceManager.Consumption.Models.BudgetTimeGrainType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BudgetTimeGrainType(string value) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.BudgetTimeGrainType Annually { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.BudgetTimeGrainType BillingAnnual { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.BudgetTimeGrainType BillingMonth { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.BudgetTimeGrainType BillingQuarter { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.BudgetTimeGrainType Monthly { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.BudgetTimeGrainType Quarterly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Consumption.Models.BudgetTimeGrainType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Consumption.Models.BudgetTimeGrainType left, Azure.ResourceManager.Consumption.Models.BudgetTimeGrainType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Consumption.Models.BudgetTimeGrainType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Consumption.Models.BudgetTimeGrainType left, Azure.ResourceManager.Consumption.Models.BudgetTimeGrainType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BudgetTimePeriod
    {
        public BudgetTimePeriod(System.DateTimeOffset startOn) { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.DateTimeOffset StartOn { get { throw null; } set { } }
    }
    public partial class ConsumptionAggregatedCostResult : Azure.ResourceManager.Models.ResourceData
    {
        internal ConsumptionAggregatedCostResult() { }
        public decimal? AzureCharges { get { throw null; } }
        public string BillingPeriodId { get { throw null; } }
        public decimal? ChargesBilledSeparately { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Consumption.Models.ConsumptionAggregatedCostResult> Children { get { throw null; } }
        public string Currency { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ExcludedSubscriptions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IncludedSubscriptions { get { throw null; } }
        public decimal? MarketplaceCharges { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public System.DateTimeOffset? UsageEndOn { get { throw null; } }
        public System.DateTimeOffset? UsageStartOn { get { throw null; } }
    }
    public partial class ConsumptionAmount
    {
        internal ConsumptionAmount() { }
        public string Currency { get { throw null; } }
        public decimal? Value { get { throw null; } }
    }
    public partial class ConsumptionAmountWithExchangeRate : Azure.ResourceManager.Consumption.Models.ConsumptionAmount
    {
        internal ConsumptionAmountWithExchangeRate() { }
        public decimal? ExchangeRate { get { throw null; } }
        public int? ExchangeRateMonth { get { throw null; } }
    }
    public partial class ConsumptionBalanceAdjustmentDetail
    {
        internal ConsumptionBalanceAdjustmentDetail() { }
        public string Name { get { throw null; } }
        public decimal? Value { get { throw null; } }
    }
    public partial class ConsumptionBalanceNewPurchasesDetail
    {
        internal ConsumptionBalanceNewPurchasesDetail() { }
        public string Name { get { throw null; } }
        public decimal? Value { get { throw null; } }
    }
    public partial class ConsumptionBalanceResult : Azure.ResourceManager.Models.ResourceData
    {
        internal ConsumptionBalanceResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceAdjustmentDetail> AdjustmentDetails { get { throw null; } }
        public decimal? Adjustments { get { throw null; } }
        public decimal? AzureMarketplaceServiceCharges { get { throw null; } }
        public decimal? BeginningBalance { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionBillingFrequency? BillingFrequency { get { throw null; } }
        public decimal? ChargesBilledSeparately { get { throw null; } }
        public string Currency { get { throw null; } }
        public decimal? EndingBalance { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public bool? IsPriceHidden { get { throw null; } }
        public decimal? NewPurchases { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceNewPurchasesDetail> NewPurchasesDetails { get { throw null; } }
        public decimal? ServiceOverage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public decimal? TotalOverage { get { throw null; } }
        public decimal? TotalUsage { get { throw null; } }
        public decimal? Utilized { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConsumptionBillingFrequency : System.IEquatable<Azure.ResourceManager.Consumption.Models.ConsumptionBillingFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConsumptionBillingFrequency(string value) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionBillingFrequency Month { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionBillingFrequency Quarter { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionBillingFrequency Year { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Consumption.Models.ConsumptionBillingFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Consumption.Models.ConsumptionBillingFrequency left, Azure.ResourceManager.Consumption.Models.ConsumptionBillingFrequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.Consumption.Models.ConsumptionBillingFrequency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Consumption.Models.ConsumptionBillingFrequency left, Azure.ResourceManager.Consumption.Models.ConsumptionBillingFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConsumptionBudgetFilter
    {
        public ConsumptionBudgetFilter() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Consumption.Models.BudgetFilterProperties> And { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.BudgetComparisonExpression Dimensions { get { throw null; } set { } }
        public Azure.ResourceManager.Consumption.Models.BudgetComparisonExpression Tags { get { throw null; } set { } }
    }
    public partial class ConsumptionCalculatedSavingsProperties
    {
        internal ConsumptionCalculatedSavingsProperties() { }
        public float? OnDemandCost { get { throw null; } }
        public float? OverageCost { get { throw null; } }
        public float? Quantity { get { throw null; } }
        public float? ReservationCost { get { throw null; } }
        public float? ReservedUnitCount { get { throw null; } }
        public float? Savings { get { throw null; } }
        public float? TotalReservationCost { get { throw null; } }
    }
    public partial class ConsumptionChargeSummary : Azure.ResourceManager.Models.ResourceData
    {
        public ConsumptionChargeSummary() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
    }
    public partial class ConsumptionCreditSummary : Azure.ResourceManager.Models.ResourceData
    {
        public ConsumptionCreditSummary() { }
        public Azure.ResourceManager.Consumption.Models.CreditBalanceSummary BalanceSummary { get { throw null; } }
        public string BillingCurrency { get { throw null; } }
        public string CreditCurrency { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmount ExpiredCredit { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmount PendingCreditAdjustments { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmount PendingEligibleCharges { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionReseller Reseller { get { throw null; } }
    }
    public partial class ConsumptionEventSummary : Azure.ResourceManager.Models.ResourceData
    {
        public ConsumptionEventSummary() { }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmount Adjustments { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate AdjustmentsInBillingCurrency { get { throw null; } }
        public string BillingCurrency { get { throw null; } }
        public string BillingProfileDisplayName { get { throw null; } }
        public Azure.Core.ResourceIdentifier BillingProfileId { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmount CanceledCredit { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmount Charges { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate ChargesInBillingCurrency { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmount ClosedBalance { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate ClosedBalanceInBillingCurrency { get { throw null; } }
        public string CreditCurrency { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmount CreditExpired { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate CreditExpiredInBillingCurrency { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionEventType? EventType { get { throw null; } set { } }
        public string InvoiceNumber { get { throw null; } }
        public Azure.Core.ResourceIdentifier LotId { get { throw null; } }
        public string LotSource { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmount NewCredit { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate NewCreditInBillingCurrency { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionReseller Reseller { get { throw null; } }
        public System.DateTimeOffset? TransactOn { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConsumptionEventType : System.IEquatable<Azure.ResourceManager.Consumption.Models.ConsumptionEventType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConsumptionEventType(string value) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionEventType CreditExpired { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionEventType NewCredit { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionEventType PendingAdjustments { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionEventType PendingCharges { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionEventType PendingExpiredCredit { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionEventType PendingNewCredit { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionEventType SettledCharges { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionEventType UnKnown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Consumption.Models.ConsumptionEventType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Consumption.Models.ConsumptionEventType left, Azure.ResourceManager.Consumption.Models.ConsumptionEventType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Consumption.Models.ConsumptionEventType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Consumption.Models.ConsumptionEventType left, Azure.ResourceManager.Consumption.Models.ConsumptionEventType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConsumptionLegacyChargeSummary : Azure.ResourceManager.Consumption.Models.ConsumptionChargeSummary
    {
        public ConsumptionLegacyChargeSummary() { }
        public decimal? AzureCharges { get { throw null; } }
        public string BillingPeriodId { get { throw null; } }
        public decimal? ChargesBilledSeparately { get { throw null; } }
        public string Currency { get { throw null; } }
        public decimal? MarketplaceCharges { get { throw null; } }
        public string UsageEnd { get { throw null; } }
        public string UsageStart { get { throw null; } }
    }
    public partial class ConsumptionLegacyReservationRecommendation : Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendation
    {
        internal ConsumptionLegacyReservationRecommendation() { }
        public decimal? CostWithNoReservedInstances { get { throw null; } }
        public System.DateTimeOffset? FirstUsageOn { get { throw null; } }
        public string InstanceFlexibilityGroup { get { throw null; } }
        public float? InstanceFlexibilityRatio { get { throw null; } }
        public string LookBackPeriod { get { throw null; } }
        public System.Guid? MeterId { get { throw null; } }
        public decimal? NetSavings { get { throw null; } }
        public string NormalizedSize { get { throw null; } }
        public decimal? RecommendedQuantity { get { throw null; } }
        public float? RecommendedQuantityNormalized { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Consumption.Models.ConsumptionSkuProperty> SkuProperties { get { throw null; } }
        public string Term { get { throw null; } }
        public decimal? TotalCostWithReservedInstances { get { throw null; } }
    }
    public partial class ConsumptionLegacyUsageDetail : Azure.ResourceManager.Consumption.Models.ConsumptionUsageDetail
    {
        internal ConsumptionLegacyUsageDetail() { }
        public string AccountName { get { throw null; } }
        public string AccountOwnerId { get { throw null; } }
        public string AdditionalInfo { get { throw null; } }
        public string BenefitId { get { throw null; } }
        public string BenefitName { get { throw null; } }
        public string BillingAccountId { get { throw null; } }
        public string BillingAccountName { get { throw null; } }
        public string BillingCurrency { get { throw null; } }
        public System.DateTimeOffset? BillingPeriodEndOn { get { throw null; } }
        public System.DateTimeOffset? BillingPeriodStartOn { get { throw null; } }
        public string BillingProfileId { get { throw null; } }
        public string BillingProfileName { get { throw null; } }
        public string ChargeType { get { throw null; } }
        public string ConsumedService { get { throw null; } }
        public decimal? Cost { get { throw null; } }
        public string CostCenter { get { throw null; } }
        public decimal? EffectivePrice { get { throw null; } }
        public string Frequency { get { throw null; } }
        public string InvoiceSection { get { throw null; } }
        public bool? IsAzureCreditEligible { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionMeterDetailsInfo MeterDetails { get { throw null; } }
        public System.Guid? MeterId { get { throw null; } }
        public string OfferId { get { throw null; } }
        public System.DateTimeOffset? On { get { throw null; } }
        public string PartNumber { get { throw null; } }
        public decimal? PayGPrice { get { throw null; } }
        public string PlanName { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionPricingModelType? PricingModel { get { throw null; } }
        public string Product { get { throw null; } }
        public string ProductOrderId { get { throw null; } }
        public string ProductOrderName { get { throw null; } }
        public string PublisherName { get { throw null; } }
        public string PublisherType { get { throw null; } }
        public decimal? Quantity { get { throw null; } }
        public string ReservationId { get { throw null; } }
        public string ReservationName { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public string ResourceLocation { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string ServiceInfo1 { get { throw null; } }
        public string ServiceInfo2 { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string SubscriptionName { get { throw null; } }
        public string Term { get { throw null; } }
        public decimal? UnitPrice { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConsumptionLotSource : System.IEquatable<Azure.ResourceManager.Consumption.Models.ConsumptionLotSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConsumptionLotSource(string value) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionLotSource ConsumptionCommitment { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionLotSource PromotionalCredit { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionLotSource PurchasedCredit { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Consumption.Models.ConsumptionLotSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Consumption.Models.ConsumptionLotSource left, Azure.ResourceManager.Consumption.Models.ConsumptionLotSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.Consumption.Models.ConsumptionLotSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Consumption.Models.ConsumptionLotSource left, Azure.ResourceManager.Consumption.Models.ConsumptionLotSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConsumptionLotStatus : System.IEquatable<Azure.ResourceManager.Consumption.Models.ConsumptionLotStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConsumptionLotStatus(string value) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionLotStatus Active { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionLotStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionLotStatus Complete { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionLotStatus Expired { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionLotStatus Inactive { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionLotStatus None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Consumption.Models.ConsumptionLotStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Consumption.Models.ConsumptionLotStatus left, Azure.ResourceManager.Consumption.Models.ConsumptionLotStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Consumption.Models.ConsumptionLotStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Consumption.Models.ConsumptionLotStatus left, Azure.ResourceManager.Consumption.Models.ConsumptionLotStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConsumptionLotSummary : Azure.ResourceManager.Models.ResourceData
    {
        public ConsumptionLotSummary() { }
        public string BillingCurrency { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmount ClosedBalance { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate ClosedBalanceInBillingCurrency { get { throw null; } }
        public string CreditCurrency { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmount OriginalAmount { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate OriginalAmountInBillingCurrency { get { throw null; } }
        public string PoNumber { get { throw null; } }
        public System.DateTimeOffset? PurchasedOn { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionReseller Reseller { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionLotSource? Source { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionLotStatus? Status { get { throw null; } }
    }
    public partial class ConsumptionMarketplace : Azure.ResourceManager.Models.ResourceData
    {
        internal ConsumptionMarketplace() { }
        public string AccountName { get { throw null; } }
        public string AdditionalInfo { get { throw null; } }
        public string AdditionalProperties { get { throw null; } }
        public string BillingPeriodId { get { throw null; } }
        public decimal? ConsumedQuantity { get { throw null; } }
        public string ConsumedService { get { throw null; } }
        public string CostCenter { get { throw null; } }
        public string Currency { get { throw null; } }
        public string DepartmentName { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public string InstanceId { get { throw null; } }
        public string InstanceName { get { throw null; } }
        public bool? IsEstimated { get { throw null; } }
        public bool? IsRecurringCharge { get { throw null; } }
        public System.Guid? MeterId { get { throw null; } }
        public string OfferName { get { throw null; } }
        public string OrderNumber { get { throw null; } }
        public string PlanName { get { throw null; } }
        public decimal? PretaxCost { get { throw null; } }
        public string PublisherName { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public decimal? ResourceRate { get { throw null; } }
        public System.Guid? SubscriptionGuid { get { throw null; } }
        public string SubscriptionName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public string UnitOfMeasure { get { throw null; } }
        public System.DateTimeOffset? UsageEndOn { get { throw null; } }
        public System.DateTimeOffset? UsageStartOn { get { throw null; } }
    }
    public partial class ConsumptionMeterDetails
    {
        internal ConsumptionMeterDetails() { }
        public string MeterCategory { get { throw null; } }
        public string MeterLocation { get { throw null; } }
        public string MeterName { get { throw null; } }
        public string MeterSubCategory { get { throw null; } }
        public decimal? PretaxStandardRate { get { throw null; } }
        public string ServiceName { get { throw null; } }
        public string ServiceTier { get { throw null; } }
        public decimal? TotalIncludedQuantity { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class ConsumptionMeterDetailsInfo
    {
        internal ConsumptionMeterDetailsInfo() { }
        public string MeterCategory { get { throw null; } }
        public string MeterName { get { throw null; } }
        public string MeterSubCategory { get { throw null; } }
        public string ServiceFamily { get { throw null; } }
        public string UnitOfMeasure { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConsumptionMetricType : System.IEquatable<Azure.ResourceManager.Consumption.Models.ConsumptionMetricType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConsumptionMetricType(string value) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionMetricType ActualCostMetricType { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionMetricType AmortizedCostMetricType { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionMetricType UsageMetricType { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Consumption.Models.ConsumptionMetricType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Consumption.Models.ConsumptionMetricType left, Azure.ResourceManager.Consumption.Models.ConsumptionMetricType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Consumption.Models.ConsumptionMetricType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Consumption.Models.ConsumptionMetricType left, Azure.ResourceManager.Consumption.Models.ConsumptionMetricType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConsumptionModernChargeSummary : Azure.ResourceManager.Consumption.Models.ConsumptionChargeSummary
    {
        public ConsumptionModernChargeSummary() { }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmount AzureCharges { get { throw null; } }
        public string BillingAccountId { get { throw null; } }
        public string BillingPeriodId { get { throw null; } }
        public string BillingProfileId { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmount ChargesBilledSeparately { get { throw null; } }
        public string CustomerId { get { throw null; } }
        public string InvoiceSectionId { get { throw null; } }
        public bool? IsInvoiced { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmount MarketplaceCharges { get { throw null; } }
        public string UsageEnd { get { throw null; } }
        public string UsageStart { get { throw null; } }
    }
    public partial class ConsumptionModernReservationRecommendation : Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendation
    {
        internal ConsumptionModernReservationRecommendation() { }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmount CostWithNoReservedInstances { get { throw null; } }
        public System.DateTimeOffset? FirstUsageOn { get { throw null; } }
        public string InstanceFlexibilityGroup { get { throw null; } }
        public float? InstanceFlexibilityRatio { get { throw null; } }
        public string LocationPropertiesLocation { get { throw null; } }
        public int? LookBackPeriod { get { throw null; } }
        public System.Guid? MeterId { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmount NetSavings { get { throw null; } }
        public string NormalizedSize { get { throw null; } }
        public decimal? RecommendedQuantity { get { throw null; } }
        public float? RecommendedQuantityNormalized { get { throw null; } }
        public string Scope { get { throw null; } }
        public string SkuName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Consumption.Models.ConsumptionSkuProperty> SkuProperties { get { throw null; } }
        public string Term { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmount TotalCostWithReservedInstances { get { throw null; } }
    }
    public partial class ConsumptionModernReservationTransaction : Azure.ResourceManager.Models.ResourceData
    {
        internal ConsumptionModernReservationTransaction() { }
        public decimal? Amount { get { throw null; } }
        public string ArmSkuName { get { throw null; } }
        public string BillingFrequency { get { throw null; } }
        public Azure.Core.ResourceIdentifier BillingProfileId { get { throw null; } }
        public string BillingProfileName { get { throw null; } }
        public string Currency { get { throw null; } }
        public string Description { get { throw null; } }
        public string EventType { get { throw null; } }
        public string Invoice { get { throw null; } }
        public Azure.Core.ResourceIdentifier InvoiceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier InvoiceSectionId { get { throw null; } }
        public string InvoiceSectionName { get { throw null; } }
        public System.Guid? PurchasingSubscriptionGuid { get { throw null; } }
        public string PurchasingSubscriptionName { get { throw null; } }
        public decimal? Quantity { get { throw null; } }
        public string Region { get { throw null; } }
        public string ReservationOrderId { get { throw null; } }
        public string ReservationOrderName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Tags { get { throw null; } }
        public string Term { get { throw null; } }
        public System.DateTimeOffset? TransactOn { get { throw null; } }
    }
    public partial class ConsumptionModernUsageDetail : Azure.ResourceManager.Consumption.Models.ConsumptionUsageDetail
    {
        internal ConsumptionModernUsageDetail() { }
        public string AdditionalInfo { get { throw null; } }
        public string BenefitId { get { throw null; } }
        public string BenefitName { get { throw null; } }
        public string BillingAccountId { get { throw null; } }
        public string BillingAccountName { get { throw null; } }
        public string BillingCurrencyCode { get { throw null; } }
        public System.DateTimeOffset? BillingPeriodEndOn { get { throw null; } }
        public System.DateTimeOffset? BillingPeriodStartOn { get { throw null; } }
        public string BillingProfileId { get { throw null; } }
        public string BillingProfileName { get { throw null; } }
        public string ChargeType { get { throw null; } }
        public string ConsumedService { get { throw null; } }
        public string CostAllocationRuleName { get { throw null; } }
        public string CostCenter { get { throw null; } }
        public decimal? CostInBillingCurrency { get { throw null; } }
        public decimal? CostInPricingCurrency { get { throw null; } }
        public decimal? CostInUSD { get { throw null; } }
        public string CustomerName { get { throw null; } }
        public string CustomerTenantId { get { throw null; } }
        public decimal? EffectivePrice { get { throw null; } }
        public string ExchangeRate { get { throw null; } }
        public System.DateTimeOffset? ExchangeRateOn { get { throw null; } }
        public decimal? ExchangeRatePricingToBilling { get { throw null; } }
        public string Frequency { get { throw null; } }
        public string InstanceName { get { throw null; } }
        public string InvoiceId { get { throw null; } }
        public string InvoiceSectionId { get { throw null; } }
        public string InvoiceSectionName { get { throw null; } }
        public bool? IsAzureCreditEligible { get { throw null; } }
        public decimal? MarketPrice { get { throw null; } }
        public string MeterCategory { get { throw null; } }
        public System.Guid? MeterId { get { throw null; } }
        public string MeterName { get { throw null; } }
        public string MeterRegion { get { throw null; } }
        public string MeterSubCategory { get { throw null; } }
        public System.DateTimeOffset? On { get { throw null; } }
        public string PartnerEarnedCreditApplied { get { throw null; } }
        public decimal? PartnerEarnedCreditRate { get { throw null; } }
        public string PartnerName { get { throw null; } }
        public string PartnerTenantId { get { throw null; } }
        public decimal? PaygCostInBillingCurrency { get { throw null; } }
        public decimal? PaygCostInUSD { get { throw null; } }
        public decimal? PayGPrice { get { throw null; } }
        public string PreviousInvoiceId { get { throw null; } }
        public string PricingCurrencyCode { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionPricingModelType? PricingModel { get { throw null; } }
        public string Product { get { throw null; } }
        public string ProductIdentifier { get { throw null; } }
        public string ProductOrderId { get { throw null; } }
        public string ProductOrderName { get { throw null; } }
        public string Provider { get { throw null; } }
        public string PublisherId { get { throw null; } }
        public string PublisherName { get { throw null; } }
        public string PublisherType { get { throw null; } }
        public decimal? Quantity { get { throw null; } }
        public string ResellerMpnId { get { throw null; } }
        public string ResellerName { get { throw null; } }
        public string ReservationId { get { throw null; } }
        public string ReservationName { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string ResourceLocation { get { throw null; } }
        public string ResourceLocationNormalized { get { throw null; } }
        public string ServiceFamily { get { throw null; } }
        public string ServiceInfo1 { get { throw null; } }
        public string ServiceInfo2 { get { throw null; } }
        public System.DateTimeOffset? ServicePeriodEndOn { get { throw null; } }
        public System.DateTimeOffset? ServicePeriodStartOn { get { throw null; } }
        public string SubscriptionGuid { get { throw null; } }
        public string SubscriptionName { get { throw null; } }
        public string Term { get { throw null; } }
        public string UnitOfMeasure { get { throw null; } }
        public decimal? UnitPrice { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConsumptionPricingModelType : System.IEquatable<Azure.ResourceManager.Consumption.Models.ConsumptionPricingModelType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConsumptionPricingModelType(string value) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionPricingModelType OnDemand { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionPricingModelType Reservation { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionPricingModelType Spot { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Consumption.Models.ConsumptionPricingModelType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Consumption.Models.ConsumptionPricingModelType left, Azure.ResourceManager.Consumption.Models.ConsumptionPricingModelType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Consumption.Models.ConsumptionPricingModelType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Consumption.Models.ConsumptionPricingModelType left, Azure.ResourceManager.Consumption.Models.ConsumptionPricingModelType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConsumptionReseller
    {
        internal ConsumptionReseller() { }
        public string ResellerDescription { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResellerId { get { throw null; } }
    }
    public partial class ConsumptionReservationDetail : Azure.ResourceManager.Models.ResourceData
    {
        internal ConsumptionReservationDetail() { }
        public System.DateTimeOffset? ConsumptionOccurredOn { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public string InstanceFlexibilityGroup { get { throw null; } }
        public string InstanceFlexibilityRatio { get { throw null; } }
        public Azure.Core.ResourceIdentifier InstanceId { get { throw null; } }
        public string Kind { get { throw null; } }
        public string ReservationId { get { throw null; } }
        public string ReservationOrderId { get { throw null; } }
        public decimal? ReservedHours { get { throw null; } }
        public string SkuName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public decimal? TotalReservedQuantity { get { throw null; } }
        public decimal? UsedHours { get { throw null; } }
    }
    public partial class ConsumptionReservationRecommendation : Azure.ResourceManager.Models.ResourceData
    {
        internal ConsumptionReservationRecommendation() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string Sku { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ConsumptionReservationRecommendationDetails : Azure.ResourceManager.Models.ResourceData
    {
        internal ConsumptionReservationRecommendationDetails() { }
        public string Currency { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionResourceProperties Properties { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionSavingsProperties Savings { get { throw null; } }
        public string Scope { get { throw null; } }
        public string Sku { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionUsageProperties Usage { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConsumptionReservationRecommendationLookBackPeriod : System.IEquatable<Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationLookBackPeriod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConsumptionReservationRecommendationLookBackPeriod(string value) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationLookBackPeriod Last07Days { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationLookBackPeriod Last30Days { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationLookBackPeriod Last60Days { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationLookBackPeriod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationLookBackPeriod left, Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationLookBackPeriod right) { throw null; }
        public static implicit operator Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationLookBackPeriod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationLookBackPeriod left, Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationLookBackPeriod right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConsumptionReservationRecommendationScope : System.IEquatable<Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConsumptionReservationRecommendationScope(string value) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationScope Shared { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationScope Single { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationScope left, Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationScope left, Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConsumptionReservationRecommendationTerm : System.IEquatable<Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationTerm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConsumptionReservationRecommendationTerm(string value) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationTerm P1Y { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationTerm P3Y { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationTerm other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationTerm left, Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationTerm right) { throw null; }
        public static implicit operator Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationTerm (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationTerm left, Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationTerm right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConsumptionReservationSummary : Azure.ResourceManager.Models.ResourceData
    {
        internal ConsumptionReservationSummary() { }
        public decimal? AvgUtilizationPercentage { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public string Kind { get { throw null; } }
        public decimal? MaxUtilizationPercentage { get { throw null; } }
        public decimal? MinUtilizationPercentage { get { throw null; } }
        public decimal? PurchasedQuantity { get { throw null; } }
        public decimal? RemainingQuantity { get { throw null; } }
        public string ReservationId { get { throw null; } }
        public string ReservationOrderId { get { throw null; } }
        public decimal? ReservedHours { get { throw null; } }
        public string SkuName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public decimal? TotalReservedQuantity { get { throw null; } }
        public decimal? UsedHours { get { throw null; } }
        public decimal? UsedQuantity { get { throw null; } }
        public System.DateTimeOffset? UseOn { get { throw null; } }
        public decimal? UtilizedPercentage { get { throw null; } }
    }
    public partial class ConsumptionReservationTransaction : Azure.ResourceManager.Models.ResourceData
    {
        internal ConsumptionReservationTransaction() { }
        public string AccountName { get { throw null; } }
        public string AccountOwnerEmail { get { throw null; } }
        public decimal? Amount { get { throw null; } }
        public string ArmSkuName { get { throw null; } }
        public string BillingFrequency { get { throw null; } }
        public int? BillingMonth { get { throw null; } }
        public string CostCenter { get { throw null; } }
        public string Currency { get { throw null; } }
        public string CurrentEnrollment { get { throw null; } }
        public string DepartmentName { get { throw null; } }
        public string Description { get { throw null; } }
        public string EventType { get { throw null; } }
        public decimal? MonetaryCommitment { get { throw null; } }
        public decimal? Overage { get { throw null; } }
        public string PurchasingEnrollment { get { throw null; } }
        public System.Guid? PurchasingSubscriptionGuid { get { throw null; } }
        public string PurchasingSubscriptionName { get { throw null; } }
        public decimal? Quantity { get { throw null; } }
        public string Region { get { throw null; } }
        public string ReservationOrderId { get { throw null; } }
        public string ReservationOrderName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Tags { get { throw null; } }
        public string Term { get { throw null; } }
        public System.DateTimeOffset? TransactOn { get { throw null; } }
    }
    public partial class ConsumptionResourceProperties
    {
        internal ConsumptionResourceProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> AppliedScopes { get { throw null; } }
        public float? OnDemandRate { get { throw null; } }
        public string Product { get { throw null; } }
        public string Region { get { throw null; } }
        public float? ReservationRate { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public partial class ConsumptionSavingsProperties
    {
        internal ConsumptionSavingsProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Consumption.Models.ConsumptionCalculatedSavingsProperties> CalculatedSavings { get { throw null; } }
        public int? LookBackPeriod { get { throw null; } }
        public float? RecommendedQuantity { get { throw null; } }
        public string ReservationOrderTerm { get { throw null; } }
        public string SavingsType { get { throw null; } }
        public string UnitOfMeasure { get { throw null; } }
    }
    public partial class ConsumptionSkuProperty
    {
        internal ConsumptionSkuProperty() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class ConsumptionTag
    {
        public ConsumptionTag() { }
        public string Key { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Value { get { throw null; } }
    }
    public partial class ConsumptionTagsResult : Azure.ResourceManager.Models.ResourceData
    {
        public ConsumptionTagsResult() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string NextLink { get { throw null; } }
        public string PreviousLink { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Consumption.Models.ConsumptionTag> Tags { get { throw null; } }
    }
    public partial class ConsumptionUsageDetail : Azure.ResourceManager.Models.ResourceData
    {
        internal ConsumptionUsageDetail() { }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ConsumptionUsageProperties
    {
        internal ConsumptionUsageProperties() { }
        public string FirstConsumptionDate { get { throw null; } }
        public string LastConsumptionDate { get { throw null; } }
        public string LookBackUnitType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<float> UsageData { get { throw null; } }
        public string UsageGrain { get { throw null; } }
    }
    public partial class CreditBalanceSummary
    {
        internal CreditBalanceSummary() { }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmount CurrentBalance { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmount EstimatedBalance { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate EstimatedBalanceInBillingCurrency { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NotificationAlertTriggerType : System.IEquatable<Azure.ResourceManager.Consumption.Models.NotificationAlertTriggerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NotificationAlertTriggerType(string value) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.NotificationAlertTriggerType EqualTo { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.NotificationAlertTriggerType GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.NotificationAlertTriggerType GreaterThanOrEqualTo { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Consumption.Models.NotificationAlertTriggerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Consumption.Models.NotificationAlertTriggerType left, Azure.ResourceManager.Consumption.Models.NotificationAlertTriggerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Consumption.Models.NotificationAlertTriggerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Consumption.Models.NotificationAlertTriggerType left, Azure.ResourceManager.Consumption.Models.NotificationAlertTriggerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NotificationThresholdType : System.IEquatable<Azure.ResourceManager.Consumption.Models.NotificationThresholdType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NotificationThresholdType(string value) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.NotificationThresholdType Actual { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.NotificationThresholdType Forecasted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Consumption.Models.NotificationThresholdType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Consumption.Models.NotificationThresholdType left, Azure.ResourceManager.Consumption.Models.NotificationThresholdType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Consumption.Models.NotificationThresholdType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Consumption.Models.NotificationThresholdType left, Azure.ResourceManager.Consumption.Models.NotificationThresholdType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PriceSheetProperties
    {
        internal PriceSheetProperties() { }
        public Azure.Core.ResourceIdentifier BillingPeriodId { get { throw null; } }
        public string CurrencyCode { get { throw null; } }
        public decimal? IncludedQuantity { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionMeterDetails MeterDetails { get { throw null; } }
        public System.Guid? MeterId { get { throw null; } }
        public string OfferId { get { throw null; } }
        public string PartNumber { get { throw null; } }
        public string UnitOfMeasure { get { throw null; } }
        public decimal? UnitPrice { get { throw null; } }
    }
    public partial class PriceSheetResult : Azure.ResourceManager.Models.ResourceData
    {
        internal PriceSheetResult() { }
        public Azure.ResourceManager.Consumption.Models.ConsumptionMeterDetails Download { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Consumption.Models.PriceSheetProperties> Pricesheets { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecipientNotificationLanguageCode : System.IEquatable<Azure.ResourceManager.Consumption.Models.RecipientNotificationLanguageCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecipientNotificationLanguageCode(string value) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.RecipientNotificationLanguageCode ChinesePrc { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.RecipientNotificationLanguageCode ChineseTaiwan { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.RecipientNotificationLanguageCode CzechCzechRepublic { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.RecipientNotificationLanguageCode DanishDenmark { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.RecipientNotificationLanguageCode DutchNetherlands { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.RecipientNotificationLanguageCode EnglishUnitedKingdom { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.RecipientNotificationLanguageCode EnglishUnitedStates { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.RecipientNotificationLanguageCode FrenchFrance { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.RecipientNotificationLanguageCode GermanGermany { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.RecipientNotificationLanguageCode HungarianHungary { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.RecipientNotificationLanguageCode ItalianItaly { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.RecipientNotificationLanguageCode JapaneseJapan { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.RecipientNotificationLanguageCode KoreanKorea { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.RecipientNotificationLanguageCode NorwegianNorway { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.RecipientNotificationLanguageCode PolishPoland { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.RecipientNotificationLanguageCode PortugueseBrazil { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.RecipientNotificationLanguageCode PortuguesePortugal { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.RecipientNotificationLanguageCode RussianRussia { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.RecipientNotificationLanguageCode SpanishSpain { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.RecipientNotificationLanguageCode SwedishSweden { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.RecipientNotificationLanguageCode TurkishTurkey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Consumption.Models.RecipientNotificationLanguageCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Consumption.Models.RecipientNotificationLanguageCode left, Azure.ResourceManager.Consumption.Models.RecipientNotificationLanguageCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Consumption.Models.RecipientNotificationLanguageCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Consumption.Models.RecipientNotificationLanguageCode left, Azure.ResourceManager.Consumption.Models.RecipientNotificationLanguageCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReservationSummaryDataGrain : System.IEquatable<Azure.ResourceManager.Consumption.Models.ReservationSummaryDataGrain>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReservationSummaryDataGrain(string value) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ReservationSummaryDataGrain DailyGrain { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.ReservationSummaryDataGrain MonthlyGrain { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Consumption.Models.ReservationSummaryDataGrain other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Consumption.Models.ReservationSummaryDataGrain left, Azure.ResourceManager.Consumption.Models.ReservationSummaryDataGrain right) { throw null; }
        public static implicit operator Azure.ResourceManager.Consumption.Models.ReservationSummaryDataGrain (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Consumption.Models.ReservationSummaryDataGrain left, Azure.ResourceManager.Consumption.Models.ReservationSummaryDataGrain right) { throw null; }
        public override string ToString() { throw null; }
    }
}
