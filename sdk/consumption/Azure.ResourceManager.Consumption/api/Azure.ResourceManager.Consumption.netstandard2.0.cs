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
    public static partial class ArmConsumptionModelFactory
    {
        public static Azure.ResourceManager.Consumption.Models.BudgetCurrentSpend BudgetCurrentSpend(decimal? amount = default(decimal?), string unit = null) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.BudgetForecastSpend BudgetForecastSpend(decimal? amount = default(decimal?), string unit = null) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionAggregatedCostResult ConsumptionAggregatedCostResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string billingPeriodId = null, System.DateTimeOffset? usageStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? usageEndOn = default(System.DateTimeOffset?), decimal? azureCharges = default(decimal?), decimal? marketplaceCharges = default(decimal?), decimal? chargesBilledSeparately = default(decimal?), string currency = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Consumption.Models.ConsumptionAggregatedCostResult> children = null, System.Collections.Generic.IEnumerable<string> includedSubscriptions = null, System.Collections.Generic.IEnumerable<string> excludedSubscriptions = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionAmount ConsumptionAmount(string currency = null, decimal? value = default(decimal?)) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate ConsumptionAmountWithExchangeRate(string currency = null, decimal? value = default(decimal?), decimal? exchangeRate = default(decimal?), int? exchangeRateMonth = default(int?)) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionBalanceAdjustmentDetail ConsumptionBalanceAdjustmentDetail(string name = null, decimal? value = default(decimal?)) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionBalanceNewPurchasesDetail ConsumptionBalanceNewPurchasesDetail(string name = null, decimal? value = default(decimal?)) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionBalanceResult ConsumptionBalanceResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string currency = null, decimal? beginningBalance = default(decimal?), decimal? endingBalance = default(decimal?), decimal? newPurchases = default(decimal?), decimal? adjustments = default(decimal?), decimal? utilized = default(decimal?), decimal? serviceOverage = default(decimal?), decimal? chargesBilledSeparately = default(decimal?), decimal? totalOverage = default(decimal?), decimal? totalUsage = default(decimal?), decimal? azureMarketplaceServiceCharges = default(decimal?), Azure.ResourceManager.Consumption.Models.ConsumptionBillingFrequency? billingFrequency = default(Azure.ResourceManager.Consumption.Models.ConsumptionBillingFrequency?), bool? isPriceHidden = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceNewPurchasesDetail> newPurchasesDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceAdjustmentDetail> adjustmentDetails = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Consumption.ConsumptionBudgetData ConsumptionBudgetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Consumption.Models.BudgetCategory? category = default(Azure.ResourceManager.Consumption.Models.BudgetCategory?), decimal? amount = default(decimal?), Azure.ResourceManager.Consumption.Models.BudgetTimeGrainType? timeGrain = default(Azure.ResourceManager.Consumption.Models.BudgetTimeGrainType?), Azure.ResourceManager.Consumption.Models.BudgetTimePeriod timePeriod = null, Azure.ResourceManager.Consumption.Models.ConsumptionBudgetFilter filter = null, Azure.ResourceManager.Consumption.Models.BudgetCurrentSpend currentSpend = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Consumption.Models.BudgetAssociatedNotification> notifications = null, Azure.ResourceManager.Consumption.Models.BudgetForecastSpend forecastSpend = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionCreditSummary ConsumptionCreditSummary(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Consumption.Models.CreditBalanceSummary balanceSummary = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmount pendingCreditAdjustments = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmount expiredCredit = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmount pendingEligibleCharges = null, string creditCurrency = null, string billingCurrency = null, Azure.ResourceManager.Consumption.Models.ConsumptionReseller reseller = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionEventSummary ConsumptionEventSummary(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? transactOn = default(System.DateTimeOffset?), string description = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmount newCredit = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmount adjustments = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmount creditExpired = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmount charges = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmount closedBalance = null, Azure.ResourceManager.Consumption.Models.ConsumptionEventType? eventType = default(Azure.ResourceManager.Consumption.Models.ConsumptionEventType?), string invoiceNumber = null, Azure.Core.ResourceIdentifier billingProfileId = null, string billingProfileDisplayName = null, Azure.Core.ResourceIdentifier lotId = null, string lotSource = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmount canceledCredit = null, string creditCurrency = null, string billingCurrency = null, Azure.ResourceManager.Consumption.Models.ConsumptionReseller reseller = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate creditExpiredInBillingCurrency = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate newCreditInBillingCurrency = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate adjustmentsInBillingCurrency = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate chargesInBillingCurrency = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate closedBalanceInBillingCurrency = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionLotSummary ConsumptionLotSummary(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmount originalAmount = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmount closedBalance = null, Azure.ResourceManager.Consumption.Models.ConsumptionLotSource? source = default(Azure.ResourceManager.Consumption.Models.ConsumptionLotSource?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), string poNumber = null, System.DateTimeOffset? purchasedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Consumption.Models.ConsumptionLotStatus? status = default(Azure.ResourceManager.Consumption.Models.ConsumptionLotStatus?), string creditCurrency = null, string billingCurrency = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate originalAmountInBillingCurrency = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate closedBalanceInBillingCurrency = null, Azure.ResourceManager.Consumption.Models.ConsumptionReseller reseller = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionMeterDetails ConsumptionMeterDetails(string meterName = null, string meterCategory = null, string meterSubCategory = null, string unit = null, string meterLocation = null, decimal? totalIncludedQuantity = default(decimal?), decimal? pretaxStandardRate = default(decimal?), string serviceName = null, string serviceTier = null) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionModernReservationTransaction ConsumptionModernReservationTransaction(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, decimal? amount = default(decimal?), string armSkuName = null, string billingFrequency = null, Azure.Core.ResourceIdentifier billingProfileId = null, string billingProfileName = null, string currency = null, string description = null, System.DateTimeOffset? transactOn = default(System.DateTimeOffset?), string eventType = null, string invoice = null, Azure.Core.ResourceIdentifier invoiceId = null, Azure.Core.ResourceIdentifier invoiceSectionId = null, string invoiceSectionName = null, System.Guid? purchasingSubscriptionGuid = default(System.Guid?), string purchasingSubscriptionName = null, decimal? quantity = default(decimal?), string region = null, string reservationOrderId = null, string reservationOrderName = null, string term = null, System.Collections.Generic.IEnumerable<string> tags = null) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionReseller ConsumptionReseller(Azure.Core.ResourceIdentifier resellerId = null, string resellerDescription = null) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionReservationDetail ConsumptionReservationDetail(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string reservationOrderId = null, string instanceFlexibilityRatio = null, string instanceFlexibilityGroup = null, string reservationId = null, string skuName = null, decimal? reservedHours = default(decimal?), System.DateTimeOffset? consumptionOccurredOn = default(System.DateTimeOffset?), decimal? usedHours = default(decimal?), Azure.Core.ResourceIdentifier instanceId = null, decimal? totalReservedQuantity = default(decimal?), string kind = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionReservationSummary ConsumptionReservationSummary(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string reservationOrderId = null, string reservationId = null, string skuName = null, decimal? reservedHours = default(decimal?), System.DateTimeOffset? useOn = default(System.DateTimeOffset?), decimal? usedHours = default(decimal?), decimal? minUtilizationPercentage = default(decimal?), decimal? avgUtilizationPercentage = default(decimal?), decimal? maxUtilizationPercentage = default(decimal?), string kind = null, decimal? purchasedQuantity = default(decimal?), decimal? remainingQuantity = default(decimal?), decimal? totalReservedQuantity = default(decimal?), decimal? usedQuantity = default(decimal?), decimal? utilizedPercentage = default(decimal?), Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionReservationTransaction ConsumptionReservationTransaction(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? transactOn = default(System.DateTimeOffset?), string reservationOrderId = null, string description = null, string eventType = null, decimal? quantity = default(decimal?), decimal? amount = default(decimal?), string currency = null, string reservationOrderName = null, string purchasingEnrollment = null, System.Guid? purchasingSubscriptionGuid = default(System.Guid?), string purchasingSubscriptionName = null, string armSkuName = null, string term = null, string region = null, string accountName = null, string accountOwnerEmail = null, string departmentName = null, string costCenter = null, string currentEnrollment = null, string billingFrequency = null, int? billingMonth = default(int?), decimal? monetaryCommitment = default(decimal?), decimal? overage = default(decimal?), System.Collections.Generic.IEnumerable<string> tags = null) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.CreditBalanceSummary CreditBalanceSummary(Azure.ResourceManager.Consumption.Models.ConsumptionAmount estimatedBalance = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmount currentBalance = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate estimatedBalanceInBillingCurrency = null) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.PriceSheetProperties PriceSheetProperties(Azure.Core.ResourceIdentifier billingPeriodId = null, System.Guid? meterId = default(System.Guid?), Azure.ResourceManager.Consumption.Models.ConsumptionMeterDetails meterDetails = null, string unitOfMeasure = null, decimal? includedQuantity = default(decimal?), string partNumber = null, decimal? unitPrice = default(decimal?), string currencyCode = null, string offerId = null) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.PriceSheetResult PriceSheetResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Consumption.Models.PriceSheetProperties> pricesheets = null, string nextLink = null, Azure.ResourceManager.Consumption.Models.ConsumptionMeterDetails download = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null) { throw null; }
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
