namespace Azure.ResourceManager.Consumption
{
    public partial class BudgetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Consumption.BudgetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Consumption.BudgetResource>, System.Collections.IEnumerable
    {
        protected BudgetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Consumption.BudgetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string budgetName, Azure.ResourceManager.Consumption.BudgetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Consumption.BudgetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string budgetName, Azure.ResourceManager.Consumption.BudgetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string budgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string budgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Consumption.BudgetResource> Get(string budgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Consumption.BudgetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Consumption.BudgetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Consumption.BudgetResource>> GetAsync(string budgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Consumption.BudgetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Consumption.BudgetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Consumption.BudgetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Consumption.BudgetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BudgetData : Azure.ResourceManager.Models.ResourceData
    {
        public BudgetData() { }
        public decimal? Amount { get { throw null; } set { } }
        public Azure.ResourceManager.Consumption.Models.CategoryType? Category { get { throw null; } set { } }
        public Azure.ResourceManager.Consumption.Models.CurrentSpend CurrentSpend { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Consumption.Models.BudgetFilter Filter { get { throw null; } set { } }
        public Azure.ResourceManager.Consumption.Models.ForecastSpend ForecastSpend { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Consumption.Models.Notification> Notifications { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.TimeGrainType? TimeGrain { get { throw null; } set { } }
        public Azure.ResourceManager.Consumption.Models.BudgetTimePeriod TimePeriod { get { throw null; } set { } }
    }
    public partial class BudgetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BudgetResource() { }
        public virtual Azure.ResourceManager.Consumption.BudgetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string budgetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Consumption.BudgetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Consumption.BudgetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Consumption.BudgetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Consumption.BudgetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Consumption.BudgetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Consumption.BudgetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ConsumptionExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Consumption.BudgetResource> GetBudget(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string budgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Consumption.BudgetResource>> GetBudgetAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string budgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Consumption.BudgetResource GetBudgetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Consumption.BudgetCollection GetBudgets(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Consumption.Models.Balance> GetByBillingAccountBalance(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Consumption.Models.Balance>> GetByBillingAccountBalanceAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Consumption.Models.PriceSheetResult> GetByBillingPeriodPriceSheet(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string billingPeriodName, string expand = null, string skiptoken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Consumption.Models.PriceSheetResult>> GetByBillingPeriodPriceSheetAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string billingPeriodName, string expand = null, string skiptoken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Consumption.Models.ManagementGroupAggregatedCostResult> GetByManagementGroupAggregatedCost(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Consumption.Models.ManagementGroupAggregatedCostResult>> GetByManagementGroupAggregatedCostAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Consumption.Models.CreditSummary> GetCredit(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, string billingProfileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Consumption.Models.CreditSummary>> GetCreditAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, string billingProfileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Consumption.Models.EventSummary> GetEventsByBillingAccount(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.EventSummary> GetEventsByBillingAccountAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Consumption.Models.EventSummary> GetEventsByBillingProfile(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, string billingProfileId, string startDate, string endDate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.EventSummary> GetEventsByBillingProfileAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, string billingProfileId, string startDate, string endDate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Consumption.Models.Balance> GetForBillingPeriodByBillingAccountBalance(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, string billingPeriodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Consumption.Models.Balance>> GetForBillingPeriodByBillingAccountBalanceAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, string billingPeriodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Consumption.Models.ManagementGroupAggregatedCostResult> GetForBillingPeriodByManagementGroupAggregatedCost(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string billingPeriodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Consumption.Models.ManagementGroupAggregatedCostResult>> GetForBillingPeriodByManagementGroupAggregatedCostAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string billingPeriodName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Consumption.Models.LotSummary> GetLotsByBillingAccount(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.LotSummary> GetLotsByBillingAccountAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Consumption.Models.LotSummary> GetLotsByBillingProfile(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, string billingProfileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.LotSummary> GetLotsByBillingProfileAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, string billingProfileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Consumption.Models.LotSummary> GetLotsByCustomer(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, string customerId, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.LotSummary> GetLotsByCustomerAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, string customerId, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Consumption.Models.PriceSheetResult> GetPriceSheet(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string expand = null, string skiptoken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Consumption.Models.PriceSheetResult>> GetPriceSheetAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string expand = null, string skiptoken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Consumption.Models.ReservationDetail> GetReservationsDetailsByReservationOrder(this Azure.ResourceManager.Resources.TenantResource tenantResource, string reservationOrderId, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Consumption.Models.ReservationDetail> GetReservationsDetailsByReservationOrderAndReservation(this Azure.ResourceManager.Resources.TenantResource tenantResource, string reservationOrderId, string reservationId, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.ReservationDetail> GetReservationsDetailsByReservationOrderAndReservationAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string reservationOrderId, string reservationId, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.ReservationDetail> GetReservationsDetailsByReservationOrderAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string reservationOrderId, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Consumption.Models.ReservationSummary> GetReservationsSummariesByReservationOrder(this Azure.ResourceManager.Resources.TenantResource tenantResource, string reservationOrderId, Azure.ResourceManager.Consumption.Models.Datagrain grain, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Consumption.Models.ReservationSummary> GetReservationsSummariesByReservationOrderAndReservation(this Azure.ResourceManager.Resources.TenantResource tenantResource, string reservationOrderId, string reservationId, Azure.ResourceManager.Consumption.Models.Datagrain grain, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.ReservationSummary> GetReservationsSummariesByReservationOrderAndReservationAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string reservationOrderId, string reservationId, Azure.ResourceManager.Consumption.Models.Datagrain grain, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.ReservationSummary> GetReservationsSummariesByReservationOrderAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string reservationOrderId, Azure.ResourceManager.Consumption.Models.Datagrain grain, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Consumption.Models.ReservationTransaction> GetReservationTransactions(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.ReservationTransaction> GetReservationTransactionsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Consumption.Models.ModernReservationTransaction> GetReservationTransactionsByBillingProfile(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, string billingProfileId, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Consumption.Models.ModernReservationTransaction> GetReservationTransactionsByBillingProfileAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, string billingProfileId, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Consumption.Models
{
    public partial class Amount
    {
        internal Amount() { }
        public string Currency { get { throw null; } }
        public decimal? Value { get { throw null; } }
    }
    public partial class AmountWithExchangeRate : Azure.ResourceManager.Consumption.Models.Amount
    {
        internal AmountWithExchangeRate() { }
        public decimal? ExchangeRate { get { throw null; } }
        public int? ExchangeRateMonth { get { throw null; } }
    }
    public partial class Balance : Azure.ResourceManager.Models.ResourceData
    {
        internal Balance() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Consumption.Models.BalancePropertiesAdjustmentDetailsItem> AdjustmentDetails { get { throw null; } }
        public decimal? Adjustments { get { throw null; } }
        public decimal? AzureMarketplaceServiceCharges { get { throw null; } }
        public decimal? BeginningBalance { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.BillingFrequency? BillingFrequency { get { throw null; } }
        public decimal? ChargesBilledSeparately { get { throw null; } }
        public string Currency { get { throw null; } }
        public decimal? EndingBalance { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public decimal? NewPurchases { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Consumption.Models.BalancePropertiesNewPurchasesDetailsItem> NewPurchasesDetails { get { throw null; } }
        public bool? PriceHidden { get { throw null; } }
        public decimal? ServiceOverage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public decimal? TotalOverage { get { throw null; } }
        public decimal? TotalUsage { get { throw null; } }
        public decimal? Utilized { get { throw null; } }
    }
    public partial class BalancePropertiesAdjustmentDetailsItem
    {
        internal BalancePropertiesAdjustmentDetailsItem() { }
        public string Name { get { throw null; } }
        public decimal? Value { get { throw null; } }
    }
    public partial class BalancePropertiesNewPurchasesDetailsItem
    {
        internal BalancePropertiesNewPurchasesDetailsItem() { }
        public string Name { get { throw null; } }
        public decimal? Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingFrequency : System.IEquatable<Azure.ResourceManager.Consumption.Models.BillingFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingFrequency(string value) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.BillingFrequency Month { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.BillingFrequency Quarter { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.BillingFrequency Year { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Consumption.Models.BillingFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Consumption.Models.BillingFrequency left, Azure.ResourceManager.Consumption.Models.BillingFrequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.Consumption.Models.BillingFrequency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Consumption.Models.BillingFrequency left, Azure.ResourceManager.Consumption.Models.BillingFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BudgetComparisonExpression
    {
        public BudgetComparisonExpression(string name, Azure.ResourceManager.Consumption.Models.BudgetOperatorType @operator, System.Collections.Generic.IEnumerable<string> values) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Consumption.Models.BudgetOperatorType Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
    }
    public partial class BudgetFilter
    {
        public BudgetFilter() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Consumption.Models.BudgetFilterProperties> And { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.BudgetComparisonExpression Dimensions { get { throw null; } set { } }
        public Azure.ResourceManager.Consumption.Models.BudgetComparisonExpression Tags { get { throw null; } set { } }
    }
    public partial class BudgetFilterProperties
    {
        public BudgetFilterProperties() { }
        public Azure.ResourceManager.Consumption.Models.BudgetComparisonExpression Dimensions { get { throw null; } set { } }
        public Azure.ResourceManager.Consumption.Models.BudgetComparisonExpression Tags { get { throw null; } set { } }
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
    public partial class BudgetTimePeriod
    {
        public BudgetTimePeriod(System.DateTimeOffset startOn) { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.DateTimeOffset StartOn { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CategoryType : System.IEquatable<Azure.ResourceManager.Consumption.Models.CategoryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CategoryType(string value) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.CategoryType Cost { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Consumption.Models.CategoryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Consumption.Models.CategoryType left, Azure.ResourceManager.Consumption.Models.CategoryType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Consumption.Models.CategoryType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Consumption.Models.CategoryType left, Azure.ResourceManager.Consumption.Models.CategoryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CreditBalanceSummary
    {
        internal CreditBalanceSummary() { }
        public Azure.ResourceManager.Consumption.Models.Amount CurrentBalance { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.Amount EstimatedBalance { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.AmountWithExchangeRate EstimatedBalanceInBillingCurrency { get { throw null; } }
    }
    public partial class CreditSummary : Azure.ResourceManager.Models.ResourceData
    {
        public CreditSummary() { }
        public Azure.ResourceManager.Consumption.Models.CreditBalanceSummary BalanceSummary { get { throw null; } }
        public string BillingCurrency { get { throw null; } }
        public string CreditCurrency { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string ETagPropertiesETag { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.Amount ExpiredCredit { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.Amount PendingCreditAdjustments { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.Amount PendingEligibleCharges { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.Reseller Reseller { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CultureCode : System.IEquatable<Azure.ResourceManager.Consumption.Models.CultureCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CultureCode(string value) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.CultureCode CsCz { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.CultureCode DaDk { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.CultureCode DeDe { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.CultureCode EnGb { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.CultureCode EnUs { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.CultureCode EsEs { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.CultureCode FrFr { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.CultureCode HuHu { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.CultureCode ItIt { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.CultureCode JaJp { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.CultureCode KoKr { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.CultureCode NbNo { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.CultureCode NlNl { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.CultureCode PlPl { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.CultureCode PtBr { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.CultureCode PtPt { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.CultureCode RuRu { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.CultureCode SvSe { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.CultureCode TrTr { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.CultureCode ZhCn { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.CultureCode ZhTw { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Consumption.Models.CultureCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Consumption.Models.CultureCode left, Azure.ResourceManager.Consumption.Models.CultureCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Consumption.Models.CultureCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Consumption.Models.CultureCode left, Azure.ResourceManager.Consumption.Models.CultureCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CurrentSpend
    {
        internal CurrentSpend() { }
        public decimal? Amount { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Datagrain : System.IEquatable<Azure.ResourceManager.Consumption.Models.Datagrain>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Datagrain(string value) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.Datagrain DailyGrain { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.Datagrain MonthlyGrain { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Consumption.Models.Datagrain other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Consumption.Models.Datagrain left, Azure.ResourceManager.Consumption.Models.Datagrain right) { throw null; }
        public static implicit operator Azure.ResourceManager.Consumption.Models.Datagrain (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Consumption.Models.Datagrain left, Azure.ResourceManager.Consumption.Models.Datagrain right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventSummary : Azure.ResourceManager.Models.ResourceData
    {
        public EventSummary() { }
        public Azure.ResourceManager.Consumption.Models.Amount Adjustments { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.AmountWithExchangeRate AdjustmentsInBillingCurrency { get { throw null; } }
        public string BillingCurrency { get { throw null; } }
        public string BillingProfileDisplayName { get { throw null; } }
        public string BillingProfileId { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.Amount CanceledCredit { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.Amount Charges { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.AmountWithExchangeRate ChargesInBillingCurrency { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.Amount ClosedBalance { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.AmountWithExchangeRate ClosedBalanceInBillingCurrency { get { throw null; } }
        public string CreditCurrency { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.Amount CreditExpired { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.AmountWithExchangeRate CreditExpiredInBillingCurrency { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string ETagPropertiesETag { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.EventType? EventType { get { throw null; } set { } }
        public string InvoiceNumber { get { throw null; } }
        public string LotId { get { throw null; } }
        public string LotSource { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.Amount NewCredit { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.AmountWithExchangeRate NewCreditInBillingCurrency { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.Reseller Reseller { get { throw null; } }
        public System.DateTimeOffset? TransactionOn { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventType : System.IEquatable<Azure.ResourceManager.Consumption.Models.EventType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventType(string value) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.EventType CreditExpired { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.EventType NewCredit { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.EventType PendingAdjustments { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.EventType PendingCharges { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.EventType PendingExpiredCredit { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.EventType PendingNewCredit { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.EventType SettledCharges { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.EventType UnKnown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Consumption.Models.EventType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Consumption.Models.EventType left, Azure.ResourceManager.Consumption.Models.EventType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Consumption.Models.EventType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Consumption.Models.EventType left, Azure.ResourceManager.Consumption.Models.EventType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ForecastSpend
    {
        internal ForecastSpend() { }
        public decimal? Amount { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LotSource : System.IEquatable<Azure.ResourceManager.Consumption.Models.LotSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LotSource(string value) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.LotSource ConsumptionCommitment { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.LotSource PromotionalCredit { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.LotSource PurchasedCredit { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Consumption.Models.LotSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Consumption.Models.LotSource left, Azure.ResourceManager.Consumption.Models.LotSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.Consumption.Models.LotSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Consumption.Models.LotSource left, Azure.ResourceManager.Consumption.Models.LotSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LotSummary : Azure.ResourceManager.Models.ResourceData
    {
        public LotSummary() { }
        public string BillingCurrency { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.Amount ClosedBalance { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.AmountWithExchangeRate ClosedBalanceInBillingCurrency { get { throw null; } }
        public string CreditCurrency { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string ETagPropertiesETag { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.Amount OriginalAmount { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.AmountWithExchangeRate OriginalAmountInBillingCurrency { get { throw null; } }
        public string PoNumber { get { throw null; } }
        public System.DateTimeOffset? PurchasedOn { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.Reseller Reseller { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.LotSource? Source { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.Status? Status { get { throw null; } }
    }
    public partial class ManagementGroupAggregatedCostResult : Azure.ResourceManager.Models.ResourceData
    {
        internal ManagementGroupAggregatedCostResult() { }
        public decimal? AzureCharges { get { throw null; } }
        public string BillingPeriodId { get { throw null; } }
        public decimal? ChargesBilledSeparately { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Consumption.Models.ManagementGroupAggregatedCostResult> Children { get { throw null; } }
        public string Currency { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ExcludedSubscriptions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IncludedSubscriptions { get { throw null; } }
        public decimal? MarketplaceCharges { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public System.DateTimeOffset? UsageEnd { get { throw null; } }
        public System.DateTimeOffset? UsageStart { get { throw null; } }
    }
    public partial class MeterDetails
    {
        internal MeterDetails() { }
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
    public partial class ModernReservationTransaction : Azure.ResourceManager.Models.ResourceData
    {
        internal ModernReservationTransaction() { }
        public decimal? Amount { get { throw null; } }
        public string ArmSkuName { get { throw null; } }
        public string BillingFrequency { get { throw null; } }
        public string BillingProfileId { get { throw null; } }
        public string BillingProfileName { get { throw null; } }
        public string Currency { get { throw null; } }
        public string Description { get { throw null; } }
        public System.DateTimeOffset? EventOn { get { throw null; } }
        public string EventType { get { throw null; } }
        public string Invoice { get { throw null; } }
        public string InvoiceId { get { throw null; } }
        public string InvoiceSectionId { get { throw null; } }
        public string InvoiceSectionName { get { throw null; } }
        public System.Guid? PurchasingSubscriptionGuid { get { throw null; } }
        public string PurchasingSubscriptionName { get { throw null; } }
        public decimal? Quantity { get { throw null; } }
        public string Region { get { throw null; } }
        public string ReservationOrderId { get { throw null; } }
        public string ReservationOrderName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Tags { get { throw null; } }
        public string Term { get { throw null; } }
    }
    public partial class Notification
    {
        public Notification(bool enabled, Azure.ResourceManager.Consumption.Models.OperatorType @operator, decimal threshold, System.Collections.Generic.IEnumerable<string> contactEmails) { }
        public System.Collections.Generic.IList<string> ContactEmails { get { throw null; } }
        public System.Collections.Generic.IList<string> ContactGroups { get { throw null; } }
        public System.Collections.Generic.IList<string> ContactRoles { get { throw null; } }
        public bool Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.Consumption.Models.CultureCode? Locale { get { throw null; } set { } }
        public Azure.ResourceManager.Consumption.Models.OperatorType Operator { get { throw null; } set { } }
        public decimal Threshold { get { throw null; } set { } }
        public Azure.ResourceManager.Consumption.Models.ThresholdType? ThresholdType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperatorType : System.IEquatable<Azure.ResourceManager.Consumption.Models.OperatorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperatorType(string value) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.OperatorType EqualTo { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.OperatorType GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.OperatorType GreaterThanOrEqualTo { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Consumption.Models.OperatorType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Consumption.Models.OperatorType left, Azure.ResourceManager.Consumption.Models.OperatorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Consumption.Models.OperatorType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Consumption.Models.OperatorType left, Azure.ResourceManager.Consumption.Models.OperatorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PriceSheetProperties
    {
        internal PriceSheetProperties() { }
        public string BillingPeriodId { get { throw null; } }
        public string CurrencyCode { get { throw null; } }
        public decimal? IncludedQuantity { get { throw null; } }
        public Azure.ResourceManager.Consumption.Models.MeterDetails MeterDetails { get { throw null; } }
        public System.Guid? MeterId { get { throw null; } }
        public string OfferId { get { throw null; } }
        public string PartNumber { get { throw null; } }
        public string UnitOfMeasure { get { throw null; } }
        public decimal? UnitPrice { get { throw null; } }
    }
    public partial class PriceSheetResult : Azure.ResourceManager.Models.ResourceData
    {
        internal PriceSheetResult() { }
        public Azure.ResourceManager.Consumption.Models.MeterDetails Download { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Consumption.Models.PriceSheetProperties> Pricesheets { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class Reseller
    {
        internal Reseller() { }
        public string ResellerDescription { get { throw null; } }
        public string ResellerId { get { throw null; } }
    }
    public partial class ReservationDetail : Azure.ResourceManager.Models.ResourceData
    {
        internal ReservationDetail() { }
        public Azure.ETag? ETag { get { throw null; } }
        public string InstanceFlexibilityGroup { get { throw null; } }
        public string InstanceFlexibilityRatio { get { throw null; } }
        public string InstanceId { get { throw null; } }
        public string Kind { get { throw null; } }
        public string ReservationId { get { throw null; } }
        public string ReservationOrderId { get { throw null; } }
        public decimal? ReservedHours { get { throw null; } }
        public string SkuName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public decimal? TotalReservedQuantity { get { throw null; } }
        public System.DateTimeOffset? UsageOn { get { throw null; } }
        public decimal? UsedHours { get { throw null; } }
    }
    public partial class ReservationSummary : Azure.ResourceManager.Models.ResourceData
    {
        internal ReservationSummary() { }
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
        public System.DateTimeOffset? UsageOn { get { throw null; } }
        public decimal? UsedHours { get { throw null; } }
        public decimal? UsedQuantity { get { throw null; } }
        public decimal? UtilizedPercentage { get { throw null; } }
    }
    public partial class ReservationTransaction : Azure.ResourceManager.Models.ResourceData
    {
        internal ReservationTransaction() { }
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
        public System.DateTimeOffset? EventOn { get { throw null; } }
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
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Status : System.IEquatable<Azure.ResourceManager.Consumption.Models.Status>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Status(string value) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.Status Active { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.Status Canceled { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.Status Complete { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.Status Expired { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.Status Inactive { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.Status None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Consumption.Models.Status other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Consumption.Models.Status left, Azure.ResourceManager.Consumption.Models.Status right) { throw null; }
        public static implicit operator Azure.ResourceManager.Consumption.Models.Status (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Consumption.Models.Status left, Azure.ResourceManager.Consumption.Models.Status right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ThresholdType : System.IEquatable<Azure.ResourceManager.Consumption.Models.ThresholdType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ThresholdType(string value) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.ThresholdType Actual { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.ThresholdType Forecasted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Consumption.Models.ThresholdType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Consumption.Models.ThresholdType left, Azure.ResourceManager.Consumption.Models.ThresholdType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Consumption.Models.ThresholdType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Consumption.Models.ThresholdType left, Azure.ResourceManager.Consumption.Models.ThresholdType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TimeGrainType : System.IEquatable<Azure.ResourceManager.Consumption.Models.TimeGrainType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TimeGrainType(string value) { throw null; }
        public static Azure.ResourceManager.Consumption.Models.TimeGrainType Annually { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.TimeGrainType BillingAnnual { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.TimeGrainType BillingMonth { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.TimeGrainType BillingQuarter { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.TimeGrainType Monthly { get { throw null; } }
        public static Azure.ResourceManager.Consumption.Models.TimeGrainType Quarterly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Consumption.Models.TimeGrainType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Consumption.Models.TimeGrainType left, Azure.ResourceManager.Consumption.Models.TimeGrainType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Consumption.Models.TimeGrainType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Consumption.Models.TimeGrainType left, Azure.ResourceManager.Consumption.Models.TimeGrainType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
