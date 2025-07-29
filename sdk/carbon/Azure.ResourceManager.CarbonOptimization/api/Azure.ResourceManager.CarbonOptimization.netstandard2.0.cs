namespace Azure.ResourceManager.CarbonOptimization
{
    public partial class AzureResourceManagerCarbonOptimizationContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerCarbonOptimizationContext() { }
        public static Azure.ResourceManager.CarbonOptimization.AzureResourceManagerCarbonOptimizationContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class CarbonOptimizationExtensions
    {
        public static Azure.Response<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionAvailableDateRange> QueryCarbonEmissionAvailableDateRange(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionAvailableDateRange>> QueryCarbonEmissionAvailableDateRangeAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionListResult> QueryCarbonEmissionReports(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryFilter queryParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionListResult>> QueryCarbonEmissionReportsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryFilter queryParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.CarbonOptimization.Mocking
{
    public partial class MockableCarbonOptimizationTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableCarbonOptimizationTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionAvailableDateRange> QueryCarbonEmissionAvailableDateRange(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionAvailableDateRange>> QueryCarbonEmissionAvailableDateRangeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionListResult> QueryCarbonEmissionReports(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryFilter queryParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionListResult>> QueryCarbonEmissionReportsAsync(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryFilter queryParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.CarbonOptimization.Models
{
    public static partial class ArmCarbonOptimizationModelFactory
    {
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmission CarbonEmission(string dataType = null, double latestMonthEmissions = 0, double previousMonthEmissions = 0, double? monthOverMonthEmissionsChangeRatio = default(double?), double? monthlyEmissionsChangeValue = default(double?)) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionAvailableDateRange CarbonEmissionAvailableDateRange(System.DateTimeOffset startOn = default(System.DateTimeOffset), System.DateTimeOffset endOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionItemDetail CarbonEmissionItemDetail(double latestMonthEmissions = 0, double previousMonthEmissions = 0, double? monthOverMonthEmissionsChangeRatio = default(double?), double? monthlyEmissionsChangeValue = default(double?), string itemName = null, Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType)) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionListResult CarbonEmissionListResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmission> value = null, string skipToken = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.SubscriptionAccessDecision> subscriptionAccessDecisionList = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionMonthlySummary CarbonEmissionMonthlySummary(double latestMonthEmissions = 0, double previousMonthEmissions = 0, double? monthOverMonthEmissionsChangeRatio = default(double?), double? monthlyEmissionsChangeValue = default(double?), string date = null, double carbonIntensity = 0) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionOverallSummary CarbonEmissionOverallSummary(double latestMonthEmissions = 0, double previousMonthEmissions = 0, double? monthOverMonthEmissionsChangeRatio = default(double?), double? monthlyEmissionsChangeValue = default(double?)) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryFilter CarbonEmissionQueryFilter(string reportType = null, Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryDateRange dateRange = null, System.Collections.Generic.IEnumerable<string> subscriptionList = null, System.Collections.Generic.IEnumerable<string> resourceGroupUrlList = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceType> resourceTypeList = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> locationList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionScope> carbonScopeList = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemMonthlySummary CarbonEmissionTopItemMonthlySummary(double latestMonthEmissions = 0, double previousMonthEmissions = 0, double? monthOverMonthEmissionsChangeRatio = default(double?), double? monthlyEmissionsChangeValue = default(double?), string itemName = null, Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType), string date = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemsSummary CarbonEmissionTopItemsSummary(double latestMonthEmissions = 0, double previousMonthEmissions = 0, double? monthOverMonthEmissionsChangeRatio = default(double?), double? monthlyEmissionsChangeValue = default(double?), string itemName = null, Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType)) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.ItemDetailsQueryFilter ItemDetailsQueryFilter(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryDateRange dateRange = null, System.Collections.Generic.IEnumerable<string> subscriptionList = null, System.Collections.Generic.IEnumerable<string> resourceGroupUrlList = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceType> resourceTypeList = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> locationList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionScope> carbonScopeList = null, Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType), Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryOrderByColumn orderBy = default(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryOrderByColumn), Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQuerySortDirection sortDirection = default(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQuerySortDirection), int pageSize = 0, string skipToken = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.MonthlySummaryReportQueryFilter MonthlySummaryReportQueryFilter(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryDateRange dateRange = null, System.Collections.Generic.IEnumerable<string> subscriptionList = null, System.Collections.Generic.IEnumerable<string> resourceGroupUrlList = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceType> resourceTypeList = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> locationList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionScope> carbonScopeList = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.OverallSummaryReportQueryFilter OverallSummaryReportQueryFilter(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryDateRange dateRange = null, System.Collections.Generic.IEnumerable<string> subscriptionList = null, System.Collections.Generic.IEnumerable<string> resourceGroupUrlList = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceType> resourceTypeList = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> locationList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionScope> carbonScopeList = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionItemDetail ResourceCarbonEmissionItemDetail(double latestMonthEmissions = 0, double previousMonthEmissions = 0, double? monthOverMonthEmissionsChangeRatio = default(double?), double? monthlyEmissionsChangeValue = default(double?), string itemName = null, Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType), string subscriptionId = null, string resourceGroup = null, Azure.Core.ResourceIdentifier resourceId = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?)) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemMonthlySummary ResourceCarbonEmissionTopItemMonthlySummary(double latestMonthEmissions = 0, double previousMonthEmissions = 0, double? monthOverMonthEmissionsChangeRatio = default(double?), double? monthlyEmissionsChangeValue = default(double?), string itemName = null, Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType), string date = null, string subscriptionId = null, string resourceGroup = null, Azure.Core.ResourceIdentifier resourceId = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemsSummary ResourceCarbonEmissionTopItemsSummary(double latestMonthEmissions = 0, double previousMonthEmissions = 0, double? monthOverMonthEmissionsChangeRatio = default(double?), double? monthlyEmissionsChangeValue = default(double?), string itemName = null, Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType), string subscriptionId = null, string resourceGroup = null, Azure.Core.ResourceIdentifier resourceId = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionItemDetail ResourceGroupCarbonEmissionItemDetail(double latestMonthEmissions = 0, double previousMonthEmissions = 0, double? monthOverMonthEmissionsChangeRatio = default(double?), double? monthlyEmissionsChangeValue = default(double?), string itemName = null, Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType), string subscriptionId = null, Azure.Core.ResourceIdentifier resourceGroupId = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemMonthlySummary ResourceGroupCarbonEmissionTopItemMonthlySummary(double latestMonthEmissions = 0, double previousMonthEmissions = 0, double? monthOverMonthEmissionsChangeRatio = default(double?), double? monthlyEmissionsChangeValue = default(double?), string itemName = null, Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType), string date = null, string subscriptionId = null, Azure.Core.ResourceIdentifier resourceGroupId = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemsSummary ResourceGroupCarbonEmissionTopItemsSummary(double latestMonthEmissions = 0, double previousMonthEmissions = 0, double? monthOverMonthEmissionsChangeRatio = default(double?), double? monthlyEmissionsChangeValue = default(double?), string itemName = null, Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType), string subscriptionId = null, Azure.Core.ResourceIdentifier resourceGroupId = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.SubscriptionAccessDecision SubscriptionAccessDecision(string subscriptionId = null, Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionAccessDecision decision = default(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionAccessDecision), string denialReason = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.TopItemsMonthlySummaryReportQueryFilter TopItemsMonthlySummaryReportQueryFilter(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryDateRange dateRange = null, System.Collections.Generic.IEnumerable<string> subscriptionList = null, System.Collections.Generic.IEnumerable<string> resourceGroupUrlList = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceType> resourceTypeList = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> locationList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionScope> carbonScopeList = null, Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType), int topItems = 0) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.TopItemsSummaryReportQueryFilter TopItemsSummaryReportQueryFilter(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryDateRange dateRange = null, System.Collections.Generic.IEnumerable<string> subscriptionList = null, System.Collections.Generic.IEnumerable<string> resourceGroupUrlList = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceType> resourceTypeList = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> locationList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionScope> carbonScopeList = null, Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType), int topItems = 0) { throw null; }
    }
    public abstract partial class CarbonEmission : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmission>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmission>
    {
        protected CarbonEmission(double latestMonthEmissions, double previousMonthEmissions) { }
        public double LatestMonthEmissions { get { throw null; } }
        public double? MonthlyEmissionsChangeValue { get { throw null; } }
        public double? MonthOverMonthEmissionsChangeRatio { get { throw null; } }
        public double PreviousMonthEmissions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmission System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmission>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmission>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmission System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmission>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmission>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmission>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CarbonEmissionAccessDecision : System.IEquatable<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionAccessDecision>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CarbonEmissionAccessDecision(string value) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionAccessDecision Allowed { get { throw null; } }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionAccessDecision Denied { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionAccessDecision other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionAccessDecision left, Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionAccessDecision right) { throw null; }
        public static implicit operator Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionAccessDecision (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionAccessDecision left, Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionAccessDecision right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CarbonEmissionAvailableDateRange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionAvailableDateRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionAvailableDateRange>
    {
        internal CarbonEmissionAvailableDateRange() { }
        public System.DateTimeOffset EndOn { get { throw null; } }
        public System.DateTimeOffset StartOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionAvailableDateRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionAvailableDateRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionAvailableDateRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionAvailableDateRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionAvailableDateRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionAvailableDateRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionAvailableDateRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CarbonEmissionCategoryType : System.IEquatable<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CarbonEmissionCategoryType(string value) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType Location { get { throw null; } }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType Resource { get { throw null; } }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType ResourceGroup { get { throw null; } }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType ResourceType { get { throw null; } }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType Subscription { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType left, Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType left, Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CarbonEmissionItemDetail : Azure.ResourceManager.CarbonOptimization.Models.CarbonEmission, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionItemDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionItemDetail>
    {
        internal CarbonEmissionItemDetail() : base (default(double), default(double)) { }
        public Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType CategoryType { get { throw null; } }
        public string ItemName { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionItemDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionItemDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionItemDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionItemDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionItemDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionItemDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionItemDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CarbonEmissionListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionListResult>
    {
        internal CarbonEmissionListResult() { }
        public string SkipToken { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CarbonOptimization.Models.SubscriptionAccessDecision> SubscriptionAccessDecisionList { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmission> Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CarbonEmissionMonthlySummary : Azure.ResourceManager.CarbonOptimization.Models.CarbonEmission, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionMonthlySummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionMonthlySummary>
    {
        internal CarbonEmissionMonthlySummary() : base (default(double), default(double)) { }
        public double CarbonIntensity { get { throw null; } }
        public string Date { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionMonthlySummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionMonthlySummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionMonthlySummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionMonthlySummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionMonthlySummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionMonthlySummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionMonthlySummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CarbonEmissionOverallSummary : Azure.ResourceManager.CarbonOptimization.Models.CarbonEmission, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionOverallSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionOverallSummary>
    {
        internal CarbonEmissionOverallSummary() : base (default(double), default(double)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionOverallSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionOverallSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionOverallSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionOverallSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionOverallSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionOverallSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionOverallSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CarbonEmissionQueryDateRange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryDateRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryDateRange>
    {
        public CarbonEmissionQueryDateRange(System.DateTimeOffset startOn, System.DateTimeOffset endOn) { }
        public System.DateTimeOffset EndOn { get { throw null; } }
        public System.DateTimeOffset StartOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryDateRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryDateRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryDateRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryDateRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryDateRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryDateRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryDateRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class CarbonEmissionQueryFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryFilter>
    {
        protected CarbonEmissionQueryFilter(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryDateRange dateRange, System.Collections.Generic.IEnumerable<string> subscriptionList, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionScope> carbonScopeList) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionScope> CarbonScopeList { get { throw null; } }
        public Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryDateRange DateRange { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> LocationList { get { throw null; } }
        public System.Collections.Generic.IList<string> ResourceGroupUrlList { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceType> ResourceTypeList { get { throw null; } }
        public System.Collections.Generic.IList<string> SubscriptionList { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CarbonEmissionQueryOrderByColumn : System.IEquatable<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryOrderByColumn>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CarbonEmissionQueryOrderByColumn(string value) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryOrderByColumn ItemName { get { throw null; } }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryOrderByColumn LatestMonthEmissions { get { throw null; } }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryOrderByColumn MonthlyEmissionsChangeValue { get { throw null; } }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryOrderByColumn MonthOverMonthEmissionsChangeRatio { get { throw null; } }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryOrderByColumn PreviousMonthEmissions { get { throw null; } }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryOrderByColumn ResourceGroup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryOrderByColumn other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryOrderByColumn left, Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryOrderByColumn right) { throw null; }
        public static implicit operator Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryOrderByColumn (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryOrderByColumn left, Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryOrderByColumn right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CarbonEmissionQuerySortDirection : System.IEquatable<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQuerySortDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CarbonEmissionQuerySortDirection(string value) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQuerySortDirection Asc { get { throw null; } }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQuerySortDirection Desc { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQuerySortDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQuerySortDirection left, Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQuerySortDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQuerySortDirection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQuerySortDirection left, Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQuerySortDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CarbonEmissionScope : System.IEquatable<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CarbonEmissionScope(string value) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionScope Scope1 { get { throw null; } }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionScope Scope2 { get { throw null; } }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionScope Scope3 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionScope left, Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionScope left, Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CarbonEmissionTopItemMonthlySummary : Azure.ResourceManager.CarbonOptimization.Models.CarbonEmission, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemMonthlySummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemMonthlySummary>
    {
        internal CarbonEmissionTopItemMonthlySummary() : base (default(double), default(double)) { }
        public Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType CategoryType { get { throw null; } }
        public string Date { get { throw null; } }
        public string ItemName { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemMonthlySummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemMonthlySummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemMonthlySummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemMonthlySummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemMonthlySummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemMonthlySummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemMonthlySummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CarbonEmissionTopItemsSummary : Azure.ResourceManager.CarbonOptimization.Models.CarbonEmission, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemsSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemsSummary>
    {
        internal CarbonEmissionTopItemsSummary() : base (default(double), default(double)) { }
        public Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType CategoryType { get { throw null; } }
        public string ItemName { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemsSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemsSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemsSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemsSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemsSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemsSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemsSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ItemDetailsQueryFilter : Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ItemDetailsQueryFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ItemDetailsQueryFilter>
    {
        public ItemDetailsQueryFilter(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryDateRange dateRange, System.Collections.Generic.IEnumerable<string> subscriptionList, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionScope> carbonScopeList, Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType categoryType, Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryOrderByColumn orderBy, Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQuerySortDirection sortDirection, int pageSize) : base (default(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryDateRange), default(System.Collections.Generic.IEnumerable<string>), default(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionScope>)) { }
        public Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType CategoryType { get { throw null; } }
        public Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryOrderByColumn OrderBy { get { throw null; } }
        public int PageSize { get { throw null; } }
        public string SkipToken { get { throw null; } set { } }
        public Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQuerySortDirection SortDirection { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.ItemDetailsQueryFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ItemDetailsQueryFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ItemDetailsQueryFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.ItemDetailsQueryFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ItemDetailsQueryFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ItemDetailsQueryFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ItemDetailsQueryFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonthlySummaryReportQueryFilter : Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.MonthlySummaryReportQueryFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.MonthlySummaryReportQueryFilter>
    {
        public MonthlySummaryReportQueryFilter(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryDateRange dateRange, System.Collections.Generic.IEnumerable<string> subscriptionList, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionScope> carbonScopeList) : base (default(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryDateRange), default(System.Collections.Generic.IEnumerable<string>), default(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionScope>)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.MonthlySummaryReportQueryFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.MonthlySummaryReportQueryFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.MonthlySummaryReportQueryFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.MonthlySummaryReportQueryFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.MonthlySummaryReportQueryFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.MonthlySummaryReportQueryFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.MonthlySummaryReportQueryFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OverallSummaryReportQueryFilter : Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.OverallSummaryReportQueryFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.OverallSummaryReportQueryFilter>
    {
        public OverallSummaryReportQueryFilter(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryDateRange dateRange, System.Collections.Generic.IEnumerable<string> subscriptionList, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionScope> carbonScopeList) : base (default(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryDateRange), default(System.Collections.Generic.IEnumerable<string>), default(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionScope>)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.OverallSummaryReportQueryFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.OverallSummaryReportQueryFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.OverallSummaryReportQueryFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.OverallSummaryReportQueryFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.OverallSummaryReportQueryFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.OverallSummaryReportQueryFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.OverallSummaryReportQueryFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceCarbonEmissionItemDetail : Azure.ResourceManager.CarbonOptimization.Models.CarbonEmission, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionItemDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionItemDetail>
    {
        internal ResourceCarbonEmissionItemDetail() : base (default(double), default(double)) { }
        public Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType CategoryType { get { throw null; } }
        public string ItemName { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionItemDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionItemDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionItemDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionItemDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionItemDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionItemDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionItemDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceCarbonEmissionTopItemMonthlySummary : Azure.ResourceManager.CarbonOptimization.Models.CarbonEmission, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemMonthlySummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemMonthlySummary>
    {
        internal ResourceCarbonEmissionTopItemMonthlySummary() : base (default(double), default(double)) { }
        public Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType CategoryType { get { throw null; } }
        public string Date { get { throw null; } }
        public string ItemName { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemMonthlySummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemMonthlySummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemMonthlySummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemMonthlySummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemMonthlySummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemMonthlySummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemMonthlySummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceCarbonEmissionTopItemsSummary : Azure.ResourceManager.CarbonOptimization.Models.CarbonEmission, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemsSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemsSummary>
    {
        internal ResourceCarbonEmissionTopItemsSummary() : base (default(double), default(double)) { }
        public Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType CategoryType { get { throw null; } }
        public string ItemName { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemsSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemsSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemsSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemsSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemsSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemsSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemsSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceGroupCarbonEmissionItemDetail : Azure.ResourceManager.CarbonOptimization.Models.CarbonEmission, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionItemDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionItemDetail>
    {
        internal ResourceGroupCarbonEmissionItemDetail() : base (default(double), default(double)) { }
        public Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType CategoryType { get { throw null; } }
        public string ItemName { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceGroupId { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionItemDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionItemDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionItemDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionItemDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionItemDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionItemDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionItemDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceGroupCarbonEmissionTopItemMonthlySummary : Azure.ResourceManager.CarbonOptimization.Models.CarbonEmission, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemMonthlySummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemMonthlySummary>
    {
        internal ResourceGroupCarbonEmissionTopItemMonthlySummary() : base (default(double), default(double)) { }
        public Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType CategoryType { get { throw null; } }
        public string Date { get { throw null; } }
        public string ItemName { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceGroupId { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemMonthlySummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemMonthlySummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemMonthlySummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemMonthlySummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemMonthlySummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemMonthlySummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemMonthlySummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceGroupCarbonEmissionTopItemsSummary : Azure.ResourceManager.CarbonOptimization.Models.CarbonEmission, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemsSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemsSummary>
    {
        internal ResourceGroupCarbonEmissionTopItemsSummary() : base (default(double), default(double)) { }
        public Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType CategoryType { get { throw null; } }
        public string ItemName { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceGroupId { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemsSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemsSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemsSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemsSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemsSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemsSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemsSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubscriptionAccessDecision : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.SubscriptionAccessDecision>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.SubscriptionAccessDecision>
    {
        internal SubscriptionAccessDecision() { }
        public Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionAccessDecision Decision { get { throw null; } }
        public string DenialReason { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.SubscriptionAccessDecision System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.SubscriptionAccessDecision>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.SubscriptionAccessDecision>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.SubscriptionAccessDecision System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.SubscriptionAccessDecision>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.SubscriptionAccessDecision>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.SubscriptionAccessDecision>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TopItemsMonthlySummaryReportQueryFilter : Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsMonthlySummaryReportQueryFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsMonthlySummaryReportQueryFilter>
    {
        public TopItemsMonthlySummaryReportQueryFilter(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryDateRange dateRange, System.Collections.Generic.IEnumerable<string> subscriptionList, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionScope> carbonScopeList, Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType categoryType, int topItems) : base (default(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryDateRange), default(System.Collections.Generic.IEnumerable<string>), default(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionScope>)) { }
        public Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType CategoryType { get { throw null; } }
        public int TopItems { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.TopItemsMonthlySummaryReportQueryFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsMonthlySummaryReportQueryFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsMonthlySummaryReportQueryFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.TopItemsMonthlySummaryReportQueryFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsMonthlySummaryReportQueryFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsMonthlySummaryReportQueryFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsMonthlySummaryReportQueryFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TopItemsSummaryReportQueryFilter : Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsSummaryReportQueryFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsSummaryReportQueryFilter>
    {
        public TopItemsSummaryReportQueryFilter(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryDateRange dateRange, System.Collections.Generic.IEnumerable<string> subscriptionList, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionScope> carbonScopeList, Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType categoryType, int topItems) : base (default(Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionQueryDateRange), default(System.Collections.Generic.IEnumerable<string>), default(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionScope>)) { }
        public Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionCategoryType CategoryType { get { throw null; } }
        public int TopItems { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.TopItemsSummaryReportQueryFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsSummaryReportQueryFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsSummaryReportQueryFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.TopItemsSummaryReportQueryFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsSummaryReportQueryFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsSummaryReportQueryFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsSummaryReportQueryFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
