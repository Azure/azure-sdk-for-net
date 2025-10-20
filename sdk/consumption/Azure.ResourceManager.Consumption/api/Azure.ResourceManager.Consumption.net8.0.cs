namespace Azure.ResourceManager.Consumption
{
    public partial class AzureResourceManagerConsumptionContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerConsumptionContext() { }
        public static Azure.ResourceManager.Consumption.AzureResourceManagerConsumptionContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
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
        public virtual Azure.Pageable<Azure.ResourceManager.Consumption.Models.ConsumptionReservationTransaction> GetReservationTransactions(string filter = null, bool? useMarkupIfPartner = default(bool?), decimal? previewMarkupPercentage = default(decimal?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.Consumption.Models.ConsumptionReservationTransaction> GetReservationTransactions(string filter, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.ConsumptionReservationTransaction> GetReservationTransactionsAsync(string filter = null, bool? useMarkupIfPartner = default(bool?), decimal? previewMarkupPercentage = default(decimal?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.ConsumptionReservationTransaction> GetReservationTransactionsAsync(string filter, System.Threading.CancellationToken cancellationToken) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Consumption.ConsumptionBudgetResource> GetIfExists(string budgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Consumption.ConsumptionBudgetResource>> GetIfExistsAsync(string budgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Consumption.ConsumptionBudgetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Consumption.ConsumptionBudgetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Consumption.ConsumptionBudgetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Consumption.ConsumptionBudgetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConsumptionBudgetData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.ConsumptionBudgetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.ConsumptionBudgetData>
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.ConsumptionBudgetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.ConsumptionBudgetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.ConsumptionBudgetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.ConsumptionBudgetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.ConsumptionBudgetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.ConsumptionBudgetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.ConsumptionBudgetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsumptionBudgetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.ConsumptionBudgetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.ConsumptionBudgetData>
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
        Azure.ResourceManager.Consumption.ConsumptionBudgetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.ConsumptionBudgetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.ConsumptionBudgetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.ConsumptionBudgetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.ConsumptionBudgetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.ConsumptionBudgetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.ConsumptionBudgetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.Response<Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationDetails> GetConsumptionReservationRecommendationDetails(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.Consumption.Models.ArmResourceGetConsumptionReservationRecommendationDetailsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationDetails>> GetConsumptionReservationRecommendationDetailsAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.Consumption.Models.ArmResourceGetConsumptionReservationRecommendationDetailsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Consumption.Models.ConsumptionOperationStatus> DownloadByBillingAccountPeriodPriceSheet(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Consumption.Models.ConsumptionOperationStatus>> DownloadByBillingAccountPeriodPriceSheetAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceResult> GetBalance(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceResult>> GetBalanceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Consumption.Mocking
{
    public partial class MockableConsumptionArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableConsumptionArmClient() { }
        public virtual Azure.ResourceManager.Consumption.BillingAccountConsumptionResource GetBillingAccountConsumptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Consumption.BillingCustomerConsumptionResource GetBillingCustomerConsumptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Consumption.BillingProfileConsumptionResource GetBillingProfileConsumptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Consumption.ConsumptionBudgetResource> GetConsumptionBudget(Azure.Core.ResourceIdentifier scope, string budgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Consumption.ConsumptionBudgetResource>> GetConsumptionBudgetAsync(Azure.Core.ResourceIdentifier scope, string budgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Consumption.ConsumptionBudgetResource GetConsumptionBudgetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Consumption.ConsumptionBudgetCollection GetConsumptionBudgets(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Consumption.Models.ConsumptionChargeSummary> GetConsumptionCharges(Azure.Core.ResourceIdentifier scope, string startDate = null, string endDate = null, string filter = null, string apply = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.ConsumptionChargeSummary> GetConsumptionChargesAsync(Azure.Core.ResourceIdentifier scope, string startDate = null, string endDate = null, string filter = null, string apply = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Consumption.Models.ConsumptionMarketplace> GetConsumptionMarketPlaces(Azure.Core.ResourceIdentifier scope, string filter = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.ConsumptionMarketplace> GetConsumptionMarketPlacesAsync(Azure.Core.ResourceIdentifier scope, string filter = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationDetails> GetConsumptionReservationRecommendationDetails(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.Consumption.Models.ArmResourceGetConsumptionReservationRecommendationDetailsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationDetails>> GetConsumptionReservationRecommendationDetailsAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.Consumption.Models.ArmResourceGetConsumptionReservationRecommendationDetailsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendation> GetConsumptionReservationRecommendations(Azure.Core.ResourceIdentifier scope, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendation> GetConsumptionReservationRecommendationsAsync(Azure.Core.ResourceIdentifier scope, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Consumption.Models.ConsumptionReservationDetail> GetConsumptionReservationsDetails(Azure.Core.ResourceIdentifier scope, string startDate = null, string endDate = null, string filter = null, string reservationId = null, string reservationOrderId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.ConsumptionReservationDetail> GetConsumptionReservationsDetailsAsync(Azure.Core.ResourceIdentifier scope, string startDate = null, string endDate = null, string filter = null, string reservationId = null, string reservationOrderId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Consumption.Models.ConsumptionReservationSummary> GetConsumptionReservationsSummaries(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.Consumption.Models.ArmResourceGetConsumptionReservationsSummariesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.ConsumptionReservationSummary> GetConsumptionReservationsSummariesAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.Consumption.Models.ArmResourceGetConsumptionReservationsSummariesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Consumption.Models.ConsumptionTagsResult> GetConsumptionTags(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Consumption.Models.ConsumptionTagsResult>> GetConsumptionTagsAsync(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Consumption.Models.ConsumptionUsageDetail> GetConsumptionUsageDetails(Azure.Core.ResourceIdentifier scope, string expand = null, string filter = null, string skipToken = null, int? top = default(int?), Azure.ResourceManager.Consumption.Models.ConsumptionMetricType? metric = default(Azure.ResourceManager.Consumption.Models.ConsumptionMetricType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.ConsumptionUsageDetail> GetConsumptionUsageDetailsAsync(Azure.Core.ResourceIdentifier scope, string expand = null, string filter = null, string skipToken = null, int? top = default(int?), Azure.ResourceManager.Consumption.Models.ConsumptionMetricType? metric = default(Azure.ResourceManager.Consumption.Models.ConsumptionMetricType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Consumption.ManagementGroupBillingPeriodConsumptionResource GetManagementGroupBillingPeriodConsumptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Consumption.ReservationConsumptionResource GetReservationConsumptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Consumption.ReservationOrderConsumptionResource GetReservationOrderConsumptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Consumption.SubscriptionBillingPeriodConsumptionResource GetSubscriptionBillingPeriodConsumptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Consumption.TenantBillingPeriodConsumptionResource GetTenantBillingPeriodConsumptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableConsumptionManagementGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableConsumptionManagementGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Consumption.Models.ConsumptionAggregatedCostResult> GetAggregatedCost(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Consumption.Models.ConsumptionAggregatedCostResult>> GetAggregatedCostAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableConsumptionSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableConsumptionSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Consumption.Models.PriceSheetResult> GetPriceSheet(string expand = null, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Consumption.Models.PriceSheetResult>> GetPriceSheetAsync(string expand = null, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableConsumptionTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableConsumptionTenantResource() { }
    }
}
namespace Azure.ResourceManager.Consumption.Models
{
    public static partial class ArmConsumptionModelFactory
    {
        public static Azure.ResourceManager.Consumption.Models.BudgetCurrentSpend BudgetCurrentSpend(decimal? amount = default(decimal?), string unit = null) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.BudgetForecastSpend BudgetForecastSpend(decimal? amount = default(decimal?), string unit = null) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionAggregatedCostResult ConsumptionAggregatedCostResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, string billingPeriodId = null, System.DateTimeOffset? usageStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? usageEndOn = default(System.DateTimeOffset?), decimal? azureCharges = default(decimal?), decimal? marketplaceCharges = default(decimal?), decimal? chargesBilledSeparately = default(decimal?), string currency = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Consumption.Models.ConsumptionAggregatedCostResult> childResults = null, System.Collections.Generic.IEnumerable<string> includedSubscriptionIds = null, System.Collections.Generic.IEnumerable<string> excludedSubscriptionIds = null) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionAmount ConsumptionAmount(string currency = null, decimal? value = default(decimal?)) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate ConsumptionAmountWithExchangeRate(string currency = null, decimal? value = default(decimal?), decimal? exchangeRate = default(decimal?), int? exchangeRateMonth = default(int?)) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionBalanceAdjustmentDetail ConsumptionBalanceAdjustmentDetail(string name = null, decimal? value = default(decimal?)) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionBalanceNewPurchasesDetail ConsumptionBalanceNewPurchasesDetail(string name = null, decimal? value = default(decimal?)) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionBalanceResult ConsumptionBalanceResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, string currency = null, decimal? beginningBalance = default(decimal?), decimal? endingBalance = default(decimal?), decimal? newPurchases = default(decimal?), decimal? adjustments = default(decimal?), decimal? utilized = default(decimal?), decimal? serviceOverage = default(decimal?), decimal? chargesBilledSeparately = default(decimal?), decimal? totalOverage = default(decimal?), decimal? totalUsage = default(decimal?), decimal? azureMarketplaceServiceCharges = default(decimal?), Azure.ResourceManager.Consumption.Models.ConsumptionBillingFrequency? billingFrequency = default(Azure.ResourceManager.Consumption.Models.ConsumptionBillingFrequency?), bool? isPriceHidden = default(bool?), decimal? overageRefund = default(decimal?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceNewPurchasesDetail> newPurchasesDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceAdjustmentDetail> adjustmentDetails = null) { throw null; }
        public static Azure.ResourceManager.Consumption.ConsumptionBudgetData ConsumptionBudgetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.Consumption.Models.BudgetCategory? category = default(Azure.ResourceManager.Consumption.Models.BudgetCategory?), decimal? amount = default(decimal?), Azure.ResourceManager.Consumption.Models.BudgetTimeGrainType? timeGrain = default(Azure.ResourceManager.Consumption.Models.BudgetTimeGrainType?), Azure.ResourceManager.Consumption.Models.BudgetTimePeriod timePeriod = null, Azure.ResourceManager.Consumption.Models.ConsumptionBudgetFilter filter = null, Azure.ResourceManager.Consumption.Models.BudgetCurrentSpend currentSpend = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Consumption.Models.BudgetAssociatedNotification> notifications = null, Azure.ResourceManager.Consumption.Models.BudgetForecastSpend forecastSpend = null) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionCalculatedSavingsProperties ConsumptionCalculatedSavingsProperties(float? onDemandCost = default(float?), float? overageCost = default(float?), float? quantity = default(float?), float? reservationCost = default(float?), float? totalReservationCost = default(float?), float? reservedUnitCount = default(float?), float? savings = default(float?)) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionChargeSummary ConsumptionChargeSummary(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string kind = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionCreditSummary ConsumptionCreditSummary(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Consumption.Models.CreditBalanceSummary balanceSummary = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmount pendingCreditAdjustments = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmount expiredCredit = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmount pendingEligibleCharges = null, string creditCurrency = null, string billingCurrency = null, Azure.ResourceManager.Consumption.Models.ConsumptionReseller reseller = null, bool? isEstimatedBalance = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionEventSummary ConsumptionEventSummary(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), System.DateTimeOffset? transactOn = default(System.DateTimeOffset?), string description = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmount newCredit = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmount adjustments = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmount creditExpired = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmount charges = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmount closedBalance = null, string billingAccountId = null, string billingAccountDisplayName = null, Azure.ResourceManager.Consumption.Models.ConsumptionEventType? eventType = default(Azure.ResourceManager.Consumption.Models.ConsumptionEventType?), string invoiceNumber = null, Azure.Core.ResourceIdentifier billingProfileId = null, string billingProfileDisplayName = null, Azure.Core.ResourceIdentifier lotId = null, string lotSource = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmount canceledCredit = null, string creditCurrency = null, string billingCurrency = null, Azure.ResourceManager.Consumption.Models.ConsumptionReseller reseller = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate creditExpiredInBillingCurrency = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate newCreditInBillingCurrency = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate adjustmentsInBillingCurrency = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate chargesInBillingCurrency = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate closedBalanceInBillingCurrency = null, bool? isEstimatedBalance = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionLegacyChargeSummary ConsumptionLegacyChargeSummary(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), string billingPeriodId = null, string usageStart = null, string usageEnd = null, decimal? azureCharges = default(decimal?), decimal? chargesBilledSeparately = default(decimal?), decimal? azureMarketplaceCharges = default(decimal?), string currency = null) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionLegacyUsageDetail ConsumptionLegacyUsageDetail(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, string billingAccountId = null, string billingAccountName = null, System.DateTimeOffset? billingPeriodStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? billingPeriodEndOn = default(System.DateTimeOffset?), string billingProfileId = null, string billingProfileName = null, string accountOwnerId = null, string accountName = null, System.Guid? subscriptionId = default(System.Guid?), string subscriptionName = null, System.DateTimeOffset? on = default(System.DateTimeOffset?), string product = null, string partNumber = null, System.Guid? meterId = default(System.Guid?), Azure.ResourceManager.Consumption.Models.ConsumptionMeterDetailsInfo meterDetails = null, decimal? quantity = default(decimal?), decimal? effectivePrice = default(decimal?), decimal? cost = default(decimal?), decimal? unitPrice = default(decimal?), string billingCurrency = null, string resourceLocation = null, string consumedService = null, string resourceId = null, string resourceName = null, string serviceInfo1 = null, string serviceInfo2 = null, string additionalInfo = null, string invoiceSection = null, string costCenter = null, string resourceGroup = null, string reservationId = null, string reservationName = null, string productOrderId = null, string productOrderName = null, string offerId = null, bool? isAzureCreditEligible = default(bool?), string term = null, string publisherName = null, string publisherType = null, string planName = null, string chargeType = null, string frequency = null, decimal? payGPrice = default(decimal?), string benefitId = null, string benefitName = null, Azure.ResourceManager.Consumption.Models.ConsumptionPricingModelType? pricingModel = default(Azure.ResourceManager.Consumption.Models.ConsumptionPricingModelType?)) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionLotSummary ConsumptionLotSummary(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.Consumption.Models.ConsumptionAmount originalAmount = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmount closedBalance = null, Azure.ResourceManager.Consumption.Models.ConsumptionLotSource? source = default(Azure.ResourceManager.Consumption.Models.ConsumptionLotSource?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), string poNumber = null, System.DateTimeOffset? purchasedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Consumption.Models.ConsumptionLotStatus? status = default(Azure.ResourceManager.Consumption.Models.ConsumptionLotStatus?), string creditCurrency = null, string billingCurrency = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate originalAmountInBillingCurrency = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate closedBalanceInBillingCurrency = null, Azure.ResourceManager.Consumption.Models.ConsumptionReseller reseller = null, bool? isEstimatedBalance = default(bool?), Azure.ResourceManager.Consumption.Models.ConsumptionOrganizationType? organizationType = default(Azure.ResourceManager.Consumption.Models.ConsumptionOrganizationType?), Azure.ResourceManager.Consumption.Models.ConsumptionAmount usedAmount = null) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionMarketplace ConsumptionMarketplace(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, string billingPeriodId = null, System.DateTimeOffset? usageStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? usageEndOn = default(System.DateTimeOffset?), decimal? resourceRate = default(decimal?), string offerName = null, string resourceGroup = null, string additionalInfo = null, string orderNumber = null, string instanceName = null, string instanceId = null, string currency = null, decimal? consumedQuantity = default(decimal?), string unitOfMeasure = null, decimal? pretaxCost = default(decimal?), bool? isEstimated = default(bool?), System.Guid? meterId = default(System.Guid?), System.Guid? subscriptionGuid = default(System.Guid?), string subscriptionName = null, string accountName = null, string departmentName = null, string consumedService = null, string costCenter = null, string additionalProperties = null, string publisherName = null, string planName = null, bool? isRecurringCharge = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionMeterDetails ConsumptionMeterDetails(string meterName = null, string meterCategory = null, string meterSubCategory = null, string unit = null, string meterLocation = null, decimal? totalIncludedQuantity = default(decimal?), decimal? pretaxStandardRate = default(decimal?), string serviceName = null, string serviceTier = null) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionMeterDetailsInfo ConsumptionMeterDetailsInfo(string meterName = null, string meterCategory = null, string meterSubCategory = null, string unitOfMeasure = null, string serviceFamily = null) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionModernChargeSummary ConsumptionModernChargeSummary(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), string billingPeriodId = null, string usageStart = null, string usageEnd = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmount azureCharges = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmount chargesBilledSeparately = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmount marketplaceCharges = null, string billingAccountId = null, string billingProfileId = null, string invoiceSectionId = null, string customerId = null, bool? isInvoiced = default(bool?), System.Guid? subscriptionId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionModernReservationTransaction ConsumptionModernReservationTransaction(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<string> tags = null, decimal? amount = default(decimal?), string armSkuName = null, string billingFrequency = null, Azure.Core.ResourceIdentifier billingProfileId = null, string billingProfileName = null, string currency = null, string description = null, System.DateTimeOffset? transactOn = default(System.DateTimeOffset?), string eventType = null, string invoice = null, Azure.Core.ResourceIdentifier invoiceId = null, Azure.Core.ResourceIdentifier invoiceSectionId = null, string invoiceSectionName = null, System.Guid? purchasingSubscriptionGuid = default(System.Guid?), string purchasingSubscriptionName = null, decimal? quantity = default(decimal?), string region = null, string reservationOrderId = null, string reservationOrderName = null, string term = null) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionModernUsageDetail ConsumptionModernUsageDetail(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, string billingAccountId = null, decimal? effectivePrice = default(decimal?), Azure.ResourceManager.Consumption.Models.ConsumptionPricingModelType? pricingModel = default(Azure.ResourceManager.Consumption.Models.ConsumptionPricingModelType?), string billingAccountName = null, System.DateTimeOffset? billingPeriodStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? billingPeriodEndOn = default(System.DateTimeOffset?), string billingProfileId = null, string billingProfileName = null, string subscriptionGuid = null, string subscriptionName = null, System.DateTimeOffset? on = default(System.DateTimeOffset?), string product = null, System.Guid? meterId = default(System.Guid?), string meterName = null, string meterRegion = null, string meterCategory = null, string meterSubCategory = null, string serviceFamily = null, decimal? quantity = default(decimal?), string unitOfMeasure = null, string instanceName = null, decimal? costInUSD = default(decimal?), decimal? unitPrice = default(decimal?), string billingCurrencyCode = null, string resourceLocation = null, string consumedService = null, string serviceInfo1 = null, string serviceInfo2 = null, string additionalInfo = null, string invoiceSectionId = null, string invoiceSectionName = null, string costCenter = null, string resourceGroup = null, string reservationId = null, string reservationName = null, string productOrderId = null, string productOrderName = null, bool? isAzureCreditEligible = default(bool?), string term = null, string publisherName = null, string publisherType = null, string chargeType = null, string frequency = null, decimal? costInBillingCurrency = default(decimal?), decimal? costInPricingCurrency = default(decimal?), string exchangeRate = null, System.DateTimeOffset? exchangeRateOn = default(System.DateTimeOffset?), string invoiceId = null, string previousInvoiceId = null, string pricingCurrencyCode = null, string productIdentifier = null, string resourceLocationNormalized = null, System.DateTimeOffset? servicePeriodStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? servicePeriodEndOn = default(System.DateTimeOffset?), string customerTenantId = null, string customerName = null, string partnerTenantId = null, string partnerName = null, string resellerMpnId = null, string resellerName = null, string publisherId = null, decimal? marketPrice = default(decimal?), decimal? exchangeRatePricingToBilling = default(decimal?), decimal? paygCostInBillingCurrency = default(decimal?), decimal? paygCostInUSD = default(decimal?), decimal? partnerEarnedCreditRate = default(decimal?), string partnerEarnedCreditApplied = null, decimal? payGPrice = default(decimal?), string benefitId = null, string benefitName = null, string provider = null, string costAllocationRuleName = null) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionOperationStatus ConsumptionOperationStatus(Azure.ResourceManager.Consumption.Models.ConsumptionOperationStatusType? status = default(Azure.ResourceManager.Consumption.Models.ConsumptionOperationStatusType?), System.Uri downloadUri = null, System.DateTimeOffset? validTill = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionReseller ConsumptionReseller(Azure.Core.ResourceIdentifier resellerId = null, string resellerDescription = null) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionReservationDetail ConsumptionReservationDetail(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, string reservationOrderId = null, string instanceFlexibilityRatio = null, string instanceFlexibilityGroup = null, string reservationId = null, string skuName = null, decimal? reservedHours = default(decimal?), System.DateTimeOffset? consumptionOccurredOn = default(System.DateTimeOffset?), decimal? usedHours = default(decimal?), Azure.Core.ResourceIdentifier instanceId = null, decimal? totalReservedQuantity = default(decimal?), string kind = null) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendation ConsumptionReservationRecommendation(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string sku = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, string kind = null) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationDetails ConsumptionReservationRecommendationDetails(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string sku = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, string currency = null, Azure.ResourceManager.Consumption.Models.ConsumptionResourceProperties properties = null, string resourceGroup = null, Azure.ResourceManager.Consumption.Models.ConsumptionSavingsProperties savings = null, string scope = null, Azure.ResourceManager.Consumption.Models.ConsumptionUsageProperties usage = null) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionReservationSummary ConsumptionReservationSummary(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, string reservationOrderId = null, string reservationId = null, string skuName = null, decimal? reservedHours = default(decimal?), System.DateTimeOffset? useOn = default(System.DateTimeOffset?), decimal? usedHours = default(decimal?), decimal? minUtilizationPercentage = default(decimal?), decimal? avgUtilizationPercentage = default(decimal?), decimal? maxUtilizationPercentage = default(decimal?), string kind = null, decimal? purchasedQuantity = default(decimal?), decimal? remainingQuantity = default(decimal?), decimal? totalReservedQuantity = default(decimal?), decimal? usedQuantity = default(decimal?), decimal? utilizedPercentage = default(decimal?)) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionReservationTransaction ConsumptionReservationTransaction(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<string> tags = null, System.DateTimeOffset? transactOn = default(System.DateTimeOffset?), string reservationOrderId = null, string description = null, string eventType = null, decimal? quantity = default(decimal?), decimal? amount = default(decimal?), string currency = null, string reservationOrderName = null, string purchasingEnrollment = null, System.Guid? purchasingSubscriptionGuid = default(System.Guid?), string purchasingSubscriptionName = null, string armSkuName = null, string term = null, string region = null, string accountName = null, string accountOwnerEmail = null, string departmentName = null, string costCenter = null, string currentEnrollment = null, string billingFrequency = null, int? billingMonth = default(int?), decimal? monetaryCommitment = default(decimal?), decimal? overage = default(decimal?)) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionResourceProperties ConsumptionResourceProperties(System.Collections.Generic.IEnumerable<string> appliedScopes = null, float? onDemandRate = default(float?), string product = null, string region = null, float? reservationRate = default(float?), string resourceType = null) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionSavingsPlan ConsumptionSavingsPlan(string term = null, decimal? marketPrice = default(decimal?), decimal? effectivePrice = default(decimal?)) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionSavingsProperties ConsumptionSavingsProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Consumption.Models.ConsumptionCalculatedSavingsProperties> calculatedSavings = null, int? lookBackPeriod = default(int?), float? recommendedQuantity = default(float?), string reservationOrderTerm = null, string savingsType = null, string unitOfMeasure = null) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionSkuProperty ConsumptionSkuProperty(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionTagsResult ConsumptionTagsResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Consumption.Models.ConsumptionTag> tags = null, string nextLink = null, string previousLink = null) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionUsageDetail ConsumptionUsageDetail(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string kind = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionUsageProperties ConsumptionUsageProperties(string firstConsumptionDate = null, string lastConsumptionDate = null, string lookBackUnitType = null, System.Collections.Generic.IEnumerable<float> usageData = null, string usageGrain = null) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.CreditBalanceSummary CreditBalanceSummary(Azure.ResourceManager.Consumption.Models.ConsumptionAmount estimatedBalance = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmount currentBalance = null, Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate estimatedBalanceInBillingCurrency = null) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.PriceSheetProperties PriceSheetProperties(Azure.Core.ResourceIdentifier billingPeriodId = null, System.Guid? meterId = default(System.Guid?), Azure.ResourceManager.Consumption.Models.ConsumptionMeterDetails meterDetails = null, string unitOfMeasure = null, decimal? includedQuantity = default(decimal?), string partNumber = null, decimal? unitPrice = default(decimal?), string currencyCode = null, string offerId = null, Azure.ResourceManager.Consumption.Models.ConsumptionSavingsPlan savingsPlan = null) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.PriceSheetResult PriceSheetResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Consumption.Models.PriceSheetProperties> pricesheets = null, string nextLink = null, Azure.ResourceManager.Consumption.Models.ConsumptionMeterDetails download = null) { throw null; }
    }
    public partial class ArmResourceGetConsumptionReservationRecommendationDetailsOptions
    {
        public ArmResourceGetConsumptionReservationRecommendationDetailsOptions(Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationScope scope, string region, Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationTerm term, Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationLookBackPeriod lookBackPeriod, string product) { }
        public string Filter { get { throw null; } set { } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationLookBackPeriod LookBackPeriod { get { throw null; } }
        public string Product { get { throw null; } }
        public string Region { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationScope Scope { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationTerm Term { get { throw null; } }
    }
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
    public partial class BudgetAssociatedNotification : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.BudgetAssociatedNotification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.BudgetAssociatedNotification>
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.BudgetAssociatedNotification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.BudgetAssociatedNotification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.BudgetAssociatedNotification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.BudgetAssociatedNotification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.BudgetAssociatedNotification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.BudgetAssociatedNotification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.BudgetAssociatedNotification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class BudgetComparisonExpression : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.BudgetComparisonExpression>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.BudgetComparisonExpression>
    {
        public BudgetComparisonExpression(string name, Azure.ResourceManager.Consumption.Models.BudgetOperatorType @operator, System.Collections.Generic.IEnumerable<string> values) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Consumption.Models.BudgetOperatorType Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.BudgetComparisonExpression System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.BudgetComparisonExpression>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.BudgetComparisonExpression>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.BudgetComparisonExpression System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.BudgetComparisonExpression>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.BudgetComparisonExpression>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.BudgetComparisonExpression>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BudgetCurrentSpend : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.BudgetCurrentSpend>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.BudgetCurrentSpend>
    {
        internal BudgetCurrentSpend() { }
        public decimal? Amount { get { throw null; } }
        public string Unit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.BudgetCurrentSpend System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.BudgetCurrentSpend>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.BudgetCurrentSpend>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.BudgetCurrentSpend System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.BudgetCurrentSpend>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.BudgetCurrentSpend>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.BudgetCurrentSpend>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BudgetFilterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.BudgetFilterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.BudgetFilterProperties>
    {
        public BudgetFilterProperties() { }
        public Azure.ResourceManager.Consumption.Models.BudgetComparisonExpression Dimensions { get { throw null; } set { } }
        public Azure.ResourceManager.Consumption.Models.BudgetComparisonExpression Tags { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.BudgetFilterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.BudgetFilterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.BudgetFilterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.BudgetFilterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.BudgetFilterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.BudgetFilterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.BudgetFilterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BudgetForecastSpend : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.BudgetForecastSpend>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.BudgetForecastSpend>
    {
        internal BudgetForecastSpend() { }
        public decimal? Amount { get { throw null; } }
        public string Unit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.BudgetForecastSpend System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.BudgetForecastSpend>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.BudgetForecastSpend>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.BudgetForecastSpend System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.BudgetForecastSpend>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.BudgetForecastSpend>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.BudgetForecastSpend>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class BudgetTimePeriod : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.BudgetTimePeriod>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.BudgetTimePeriod>
    {
        public BudgetTimePeriod(System.DateTimeOffset startOn) { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.DateTimeOffset StartOn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.BudgetTimePeriod System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.BudgetTimePeriod>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.BudgetTimePeriod>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.BudgetTimePeriod System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.BudgetTimePeriod>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.BudgetTimePeriod>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.BudgetTimePeriod>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsumptionAggregatedCostResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionAggregatedCostResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionAggregatedCostResult>
    {
        public ConsumptionAggregatedCostResult() { }
        public decimal? AzureCharges { get { throw null; } }
        public string BillingPeriodId { get { throw null; } }
        public decimal? ChargesBilledSeparately { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Consumption.Models.ConsumptionAggregatedCostResult> Children { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Consumption.Models.ConsumptionAggregatedCostResult> ChildResults { get { throw null; } }
        public string Currency { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IList<string> ExcludedSubscriptionIds { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IReadOnlyList<string> ExcludedSubscriptions { get { throw null; } }
        public System.Collections.Generic.IList<string> IncludedSubscriptionIds { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IReadOnlyList<string> IncludedSubscriptions { get { throw null; } }
        public decimal? MarketplaceCharges { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public System.DateTimeOffset? UsageEndOn { get { throw null; } }
        public System.DateTimeOffset? UsageStartOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionAggregatedCostResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionAggregatedCostResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionAggregatedCostResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionAggregatedCostResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionAggregatedCostResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionAggregatedCostResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionAggregatedCostResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsumptionAmount : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionAmount>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionAmount>
    {
        internal ConsumptionAmount() { }
        public string Currency { get { throw null; } }
        public decimal? Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionAmount System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionAmount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionAmount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionAmount System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionAmount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionAmount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionAmount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsumptionAmountWithExchangeRate : Azure.ResourceManager.Consumption.Models.ConsumptionAmount, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate>
    {
        internal ConsumptionAmountWithExchangeRate() { }
        public decimal? ExchangeRate { get { throw null; } }
        public int? ExchangeRateMonth { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsumptionBalanceAdjustmentDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceAdjustmentDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceAdjustmentDetail>
    {
        internal ConsumptionBalanceAdjustmentDetail() { }
        public string Name { get { throw null; } }
        public decimal? Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionBalanceAdjustmentDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceAdjustmentDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceAdjustmentDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionBalanceAdjustmentDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceAdjustmentDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceAdjustmentDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceAdjustmentDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsumptionBalanceNewPurchasesDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceNewPurchasesDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceNewPurchasesDetail>
    {
        internal ConsumptionBalanceNewPurchasesDetail() { }
        public string Name { get { throw null; } }
        public decimal? Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionBalanceNewPurchasesDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceNewPurchasesDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceNewPurchasesDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionBalanceNewPurchasesDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceNewPurchasesDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceNewPurchasesDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceNewPurchasesDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsumptionBalanceResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceResult>
    {
        public ConsumptionBalanceResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceAdjustmentDetail> AdjustmentDetails { get { throw null; } }
        public decimal? Adjustments { get { throw null; } }
        public decimal? AzureMarketplaceServiceCharges { get { throw null; } }
        public decimal? BeginningBalance { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionBillingFrequency? BillingFrequency { get { throw null; } set { } }
        public decimal? ChargesBilledSeparately { get { throw null; } }
        public string Currency { get { throw null; } }
        public decimal? EndingBalance { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public bool? IsPriceHidden { get { throw null; } }
        public decimal? NewPurchases { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceNewPurchasesDetail> NewPurchasesDetails { get { throw null; } }
        public decimal? OverageRefund { get { throw null; } }
        public decimal? ServiceOverage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public decimal? TotalOverage { get { throw null; } }
        public decimal? TotalUsage { get { throw null; } }
        public decimal? Utilized { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionBalanceResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionBalanceResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionBalanceResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ConsumptionBudgetFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionBudgetFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionBudgetFilter>
    {
        public ConsumptionBudgetFilter() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Consumption.Models.BudgetFilterProperties> And { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.BudgetComparisonExpression Dimensions { get { throw null; } set { } }
        public Azure.ResourceManager.Consumption.Models.BudgetComparisonExpression Tags { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionBudgetFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionBudgetFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionBudgetFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionBudgetFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionBudgetFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionBudgetFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionBudgetFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsumptionCalculatedSavingsProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionCalculatedSavingsProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionCalculatedSavingsProperties>
    {
        internal ConsumptionCalculatedSavingsProperties() { }
        public float? OnDemandCost { get { throw null; } }
        public float? OverageCost { get { throw null; } }
        public float? Quantity { get { throw null; } }
        public float? ReservationCost { get { throw null; } }
        public float? ReservedUnitCount { get { throw null; } }
        public float? Savings { get { throw null; } }
        public float? TotalReservationCost { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionCalculatedSavingsProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionCalculatedSavingsProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionCalculatedSavingsProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionCalculatedSavingsProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionCalculatedSavingsProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionCalculatedSavingsProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionCalculatedSavingsProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ConsumptionChargeSummary : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionChargeSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionChargeSummary>
    {
        protected ConsumptionChargeSummary() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionChargeSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionChargeSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionChargeSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionChargeSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionChargeSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionChargeSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionChargeSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsumptionCreditSummary : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionCreditSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionCreditSummary>
    {
        public ConsumptionCreditSummary() { }
        public Azure.ResourceManager.Consumption.Models.CreditBalanceSummary BalanceSummary { get { throw null; } }
        public string BillingCurrency { get { throw null; } }
        public string CreditCurrency { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmount ExpiredCredit { get { throw null; } }
        public bool? IsEstimatedBalance { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmount PendingCreditAdjustments { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmount PendingEligibleCharges { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionReseller Reseller { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionCreditSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionCreditSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionCreditSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionCreditSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionCreditSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionCreditSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionCreditSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsumptionEventSummary : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionEventSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionEventSummary>
    {
        public ConsumptionEventSummary() { }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmount Adjustments { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate AdjustmentsInBillingCurrency { get { throw null; } }
        public string BillingAccountDisplayName { get { throw null; } }
        public string BillingAccountId { get { throw null; } }
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
        public bool? IsEstimatedBalance { get { throw null; } }
        public Azure.Core.ResourceIdentifier LotId { get { throw null; } }
        public string LotSource { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmount NewCredit { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate NewCreditInBillingCurrency { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionReseller Reseller { get { throw null; } }
        public System.DateTimeOffset? TransactOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionEventSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionEventSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionEventSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionEventSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionEventSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionEventSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionEventSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ConsumptionLegacyChargeSummary : Azure.ResourceManager.Consumption.Models.ConsumptionChargeSummary, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionLegacyChargeSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionLegacyChargeSummary>
    {
        public ConsumptionLegacyChargeSummary() { }
        public decimal? AzureCharges { get { throw null; } }
        public decimal? AzureMarketplaceCharges { get { throw null; } }
        public string BillingPeriodId { get { throw null; } }
        public decimal? ChargesBilledSeparately { get { throw null; } }
        public string Currency { get { throw null; } }
        public string UsageEnd { get { throw null; } }
        public string UsageStart { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionLegacyChargeSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionLegacyChargeSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionLegacyChargeSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionLegacyChargeSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionLegacyChargeSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionLegacyChargeSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionLegacyChargeSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsumptionLegacyReservationRecommendation : Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendation, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionLegacyReservationRecommendation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionLegacyReservationRecommendation>
    {
        internal ConsumptionLegacyReservationRecommendation() { }
        public decimal? CostWithNoReservedInstances { get { throw null; } }
        public System.DateTimeOffset? FirstUsageOn { get { throw null; } }
        public string InstanceFlexibilityGroup { get { throw null; } }
        public float? InstanceFlexibilityRatio { get { throw null; } }
        public System.DateTimeOffset? LastUsageOn { get { throw null; } }
        public string LookBackPeriod { get { throw null; } }
        public System.Guid? MeterId { get { throw null; } }
        public decimal? NetSavings { get { throw null; } }
        public string NormalizedSize { get { throw null; } }
        public decimal? RecommendedQuantity { get { throw null; } }
        public float? RecommendedQuantityNormalized { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Consumption.Models.ConsumptionSkuProperty> SkuProperties { get { throw null; } }
        public string Term { get { throw null; } }
        public decimal? TotalCostWithReservedInstances { get { throw null; } }
        public int? TotalHours { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionLegacyReservationRecommendation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionLegacyReservationRecommendation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionLegacyReservationRecommendation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionLegacyReservationRecommendation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionLegacyReservationRecommendation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionLegacyReservationRecommendation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionLegacyReservationRecommendation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsumptionLegacyUsageDetail : Azure.ResourceManager.Consumption.Models.ConsumptionUsageDetail, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionLegacyUsageDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionLegacyUsageDetail>
    {
        public ConsumptionLegacyUsageDetail() { }
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
        public System.Guid? SubscriptionId { get { throw null; } }
        public string SubscriptionName { get { throw null; } }
        public string Term { get { throw null; } }
        public decimal? UnitPrice { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionLegacyUsageDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionLegacyUsageDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionLegacyUsageDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionLegacyUsageDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionLegacyUsageDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionLegacyUsageDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionLegacyUsageDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ConsumptionLotSummary : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionLotSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionLotSummary>
    {
        public ConsumptionLotSummary() { }
        public string BillingCurrency { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmount ClosedBalance { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate ClosedBalanceInBillingCurrency { get { throw null; } }
        public string CreditCurrency { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public bool? IsEstimatedBalance { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionOrganizationType? OrganizationType { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmount OriginalAmount { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate OriginalAmountInBillingCurrency { get { throw null; } }
        public string PoNumber { get { throw null; } }
        public System.DateTimeOffset? PurchasedOn { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionReseller Reseller { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionLotSource? Source { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionLotStatus? Status { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmount UsedAmount { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionLotSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionLotSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionLotSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionLotSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionLotSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionLotSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionLotSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsumptionMarketplace : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionMarketplace>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionMarketplace>
    {
        public ConsumptionMarketplace() { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionMarketplace System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionMarketplace>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionMarketplace>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionMarketplace System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionMarketplace>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionMarketplace>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionMarketplace>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsumptionMeterDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionMeterDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionMeterDetails>
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionMeterDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionMeterDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionMeterDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionMeterDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionMeterDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionMeterDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionMeterDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsumptionMeterDetailsInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionMeterDetailsInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionMeterDetailsInfo>
    {
        internal ConsumptionMeterDetailsInfo() { }
        public string MeterCategory { get { throw null; } }
        public string MeterName { get { throw null; } }
        public string MeterSubCategory { get { throw null; } }
        public string ServiceFamily { get { throw null; } }
        public string UnitOfMeasure { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionMeterDetailsInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionMeterDetailsInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionMeterDetailsInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionMeterDetailsInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionMeterDetailsInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionMeterDetailsInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionMeterDetailsInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ConsumptionModernChargeSummary : Azure.ResourceManager.Consumption.Models.ConsumptionChargeSummary, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionModernChargeSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionModernChargeSummary>
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
        public System.Guid? SubscriptionId { get { throw null; } }
        public string UsageEnd { get { throw null; } }
        public string UsageStart { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionModernChargeSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionModernChargeSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionModernChargeSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionModernChargeSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionModernChargeSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionModernChargeSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionModernChargeSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsumptionModernReservationRecommendation : Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendation, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionModernReservationRecommendation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionModernReservationRecommendation>
    {
        internal ConsumptionModernReservationRecommendation() { }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmount CostWithNoReservedInstances { get { throw null; } }
        public System.DateTimeOffset? FirstUsageOn { get { throw null; } }
        public string InstanceFlexibilityGroup { get { throw null; } }
        public float? InstanceFlexibilityRatio { get { throw null; } }
        public System.DateTimeOffset? LastUsageOn { get { throw null; } }
        public string LocationPropertiesLocation { get { throw null; } }
        public int? LookBackPeriod { get { throw null; } }
        public System.Guid? MeterId { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmount NetSavings { get { throw null; } }
        public string NormalizedSize { get { throw null; } }
        public decimal? RecommendedQuantity { get { throw null; } }
        public float? RecommendedQuantityNormalized { get { throw null; } }
        public string SkuName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Consumption.Models.ConsumptionSkuProperty> SkuProperties { get { throw null; } }
        public string Term { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmount TotalCostWithReservedInstances { get { throw null; } }
        public int? TotalHours { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionModernReservationRecommendation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionModernReservationRecommendation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionModernReservationRecommendation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionModernReservationRecommendation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionModernReservationRecommendation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionModernReservationRecommendation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionModernReservationRecommendation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsumptionModernReservationTransaction : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionModernReservationTransaction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionModernReservationTransaction>
    {
        public ConsumptionModernReservationTransaction() { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionModernReservationTransaction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionModernReservationTransaction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionModernReservationTransaction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionModernReservationTransaction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionModernReservationTransaction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionModernReservationTransaction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionModernReservationTransaction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsumptionModernUsageDetail : Azure.ResourceManager.Consumption.Models.ConsumptionUsageDetail, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionModernUsageDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionModernUsageDetail>
    {
        public ConsumptionModernUsageDetail() { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionModernUsageDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionModernUsageDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionModernUsageDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionModernUsageDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionModernUsageDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionModernUsageDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionModernUsageDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsumptionOperationStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionOperationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionOperationStatus>
    {
        internal ConsumptionOperationStatus() { }
        public System.Uri DownloadUri { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionOperationStatusType? Status { get { throw null; } }
        public System.DateTimeOffset? ValidTill { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionOperationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionOperationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionOperationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionOperationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionOperationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionOperationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionOperationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConsumptionOperationStatusType : System.IEquatable<Azure.ResourceManager.Consumption.Models.ConsumptionOperationStatusType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConsumptionOperationStatusType(string value) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionOperationStatusType Completed { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionOperationStatusType Failed { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionOperationStatusType Running { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Consumption.Models.ConsumptionOperationStatusType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Consumption.Models.ConsumptionOperationStatusType left, Azure.ResourceManager.Consumption.Models.ConsumptionOperationStatusType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Consumption.Models.ConsumptionOperationStatusType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Consumption.Models.ConsumptionOperationStatusType left, Azure.ResourceManager.Consumption.Models.ConsumptionOperationStatusType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConsumptionOrganizationType : System.IEquatable<Azure.ResourceManager.Consumption.Models.ConsumptionOrganizationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConsumptionOrganizationType(string value) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionOrganizationType ContributorOrganizationType { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.ConsumptionOrganizationType PrimaryOrganizationType { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Consumption.Models.ConsumptionOrganizationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Consumption.Models.ConsumptionOrganizationType left, Azure.ResourceManager.Consumption.Models.ConsumptionOrganizationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Consumption.Models.ConsumptionOrganizationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Consumption.Models.ConsumptionOrganizationType left, Azure.ResourceManager.Consumption.Models.ConsumptionOrganizationType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class ConsumptionReseller : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionReseller>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionReseller>
    {
        internal ConsumptionReseller() { }
        public string ResellerDescription { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResellerId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionReseller System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionReseller>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionReseller>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionReseller System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionReseller>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionReseller>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionReseller>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsumptionReservationDetail : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationDetail>
    {
        public ConsumptionReservationDetail() { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionReservationDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionReservationDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ConsumptionReservationRecommendation : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendation>
    {
        protected ConsumptionReservationRecommendation() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string Sku { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsumptionReservationRecommendationDetails : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationDetails>
    {
        public ConsumptionReservationRecommendationDetails() { }
        public string Currency { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionResourceProperties Properties { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionSavingsProperties Savings { get { throw null; } }
        public string Scope { get { throw null; } }
        public string Sku { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionUsageProperties Usage { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.ResourceManager.Consumption.Models.ConsumptionReservationRecommendationTerm P1M { get { throw null; } }
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
    public partial class ConsumptionReservationSummary : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationSummary>
    {
        public ConsumptionReservationSummary() { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionReservationSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionReservationSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsumptionReservationTransaction : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationTransaction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationTransaction>
    {
        public ConsumptionReservationTransaction() { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionReservationTransaction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationTransaction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationTransaction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionReservationTransaction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationTransaction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationTransaction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionReservationTransaction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsumptionResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionResourceProperties>
    {
        internal ConsumptionResourceProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> AppliedScopes { get { throw null; } }
        public float? OnDemandRate { get { throw null; } }
        public string Product { get { throw null; } }
        public string Region { get { throw null; } }
        public float? ReservationRate { get { throw null; } }
        public string ResourceType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsumptionSavingsPlan : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionSavingsPlan>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionSavingsPlan>
    {
        internal ConsumptionSavingsPlan() { }
        public decimal? EffectivePrice { get { throw null; } }
        public decimal? MarketPrice { get { throw null; } }
        public string Term { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionSavingsPlan System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionSavingsPlan>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionSavingsPlan>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionSavingsPlan System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionSavingsPlan>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionSavingsPlan>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionSavingsPlan>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsumptionSavingsProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionSavingsProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionSavingsProperties>
    {
        internal ConsumptionSavingsProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Consumption.Models.ConsumptionCalculatedSavingsProperties> CalculatedSavings { get { throw null; } }
        public int? LookBackPeriod { get { throw null; } }
        public float? RecommendedQuantity { get { throw null; } }
        public string ReservationOrderTerm { get { throw null; } }
        public string SavingsType { get { throw null; } }
        public string UnitOfMeasure { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionSavingsProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionSavingsProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionSavingsProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionSavingsProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionSavingsProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionSavingsProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionSavingsProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsumptionSkuProperty : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionSkuProperty>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionSkuProperty>
    {
        internal ConsumptionSkuProperty() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionSkuProperty System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionSkuProperty>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionSkuProperty>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionSkuProperty System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionSkuProperty>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionSkuProperty>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionSkuProperty>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsumptionTag : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionTag>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionTag>
    {
        public ConsumptionTag() { }
        public string Key { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionTag System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionTag System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsumptionTagsResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionTagsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionTagsResult>
    {
        public ConsumptionTagsResult() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string NextLink { get { throw null; } }
        public string PreviousLink { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Consumption.Models.ConsumptionTag> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionTagsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionTagsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionTagsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionTagsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionTagsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionTagsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionTagsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ConsumptionUsageDetail : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionUsageDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionUsageDetail>
    {
        protected ConsumptionUsageDetail() { }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionUsageDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionUsageDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionUsageDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionUsageDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionUsageDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionUsageDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionUsageDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsumptionUsageProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionUsageProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionUsageProperties>
    {
        internal ConsumptionUsageProperties() { }
        public string FirstConsumptionDate { get { throw null; } }
        public string LastConsumptionDate { get { throw null; } }
        public string LookBackUnitType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<float> UsageData { get { throw null; } }
        public string UsageGrain { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionUsageProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionUsageProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.ConsumptionUsageProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.ConsumptionUsageProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionUsageProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionUsageProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.ConsumptionUsageProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreditBalanceSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.CreditBalanceSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.CreditBalanceSummary>
    {
        internal CreditBalanceSummary() { }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmount CurrentBalance { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmount EstimatedBalance { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionAmountWithExchangeRate EstimatedBalanceInBillingCurrency { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.CreditBalanceSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.CreditBalanceSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.CreditBalanceSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.CreditBalanceSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.CreditBalanceSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.CreditBalanceSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.CreditBalanceSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PriceSheetProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.PriceSheetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.PriceSheetProperties>
    {
        internal PriceSheetProperties() { }
        public Azure.Core.ResourceIdentifier BillingPeriodId { get { throw null; } }
        public string CurrencyCode { get { throw null; } }
        public decimal? IncludedQuantity { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionMeterDetails MeterDetails { get { throw null; } }
        public System.Guid? MeterId { get { throw null; } }
        public string OfferId { get { throw null; } }
        public string PartNumber { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.ConsumptionSavingsPlan SavingsPlan { get { throw null; } }
        public string UnitOfMeasure { get { throw null; } }
        public decimal? UnitPrice { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.PriceSheetProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.PriceSheetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.PriceSheetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.PriceSheetProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.PriceSheetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.PriceSheetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.PriceSheetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PriceSheetResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.PriceSheetResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.PriceSheetResult>
    {
        public PriceSheetResult() { }
        public Azure.ResourceManager.Consumption.Models.ConsumptionMeterDetails Download { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Consumption.Models.PriceSheetProperties> Pricesheets { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.PriceSheetResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.PriceSheetResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Consumption.Models.PriceSheetResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Consumption.Models.PriceSheetResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.PriceSheetResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.PriceSheetResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Consumption.Models.PriceSheetResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
