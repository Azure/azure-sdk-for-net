namespace Azure.ResourceManager.CarbonOptimization
{
    public static partial class CarbonOptimizationExtensions
    {
        public static Azure.Response<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionDataAvailableDateRange> QueryCarbonEmissionDataAvailableDateRangeCarbonService(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionDataAvailableDateRange>> QueryCarbonEmissionDataAvailableDateRangeCarbonServiceAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmission> QueryCarbonEmissionReportsCarbonServices(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.CarbonOptimization.Models.QueryFilter queryParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmission> QueryCarbonEmissionReportsCarbonServicesAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.CarbonOptimization.Models.QueryFilter queryParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.CarbonOptimization.Mocking
{
    public partial class MockableCarbonOptimizationTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableCarbonOptimizationTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionDataAvailableDateRange> QueryCarbonEmissionDataAvailableDateRangeCarbonService(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionDataAvailableDateRange>> QueryCarbonEmissionDataAvailableDateRangeCarbonServiceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmission> QueryCarbonEmissionReportsCarbonServices(Azure.ResourceManager.CarbonOptimization.Models.QueryFilter queryParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmission> QueryCarbonEmissionReportsCarbonServicesAsync(Azure.ResourceManager.CarbonOptimization.Models.QueryFilter queryParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.CarbonOptimization.Models
{
    public static partial class ArmCarbonOptimizationModelFactory
    {
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmission CarbonEmission(string dataType = null, double latestMonthEmissions = 0, double previousMonthEmissions = 0, double? monthOverMonthEmissionsChangeRatio = default(double?), double? monthlyEmissionsChangeValue = default(double?)) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionDataAvailableDateRange CarbonEmissionDataAvailableDateRange(string startDate = null, string endDate = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionItemDetail CarbonEmissionItemDetail(double latestMonthEmissions = 0, double previousMonthEmissions = 0, double? monthOverMonthEmissionsChangeRatio = default(double?), double? monthlyEmissionsChangeValue = default(double?), string itemName = null, Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum)) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionMonthlySummary CarbonEmissionMonthlySummary(double latestMonthEmissions = 0, double previousMonthEmissions = 0, double? monthOverMonthEmissionsChangeRatio = default(double?), double? monthlyEmissionsChangeValue = default(double?), string date = null, double carbonIntensity = 0) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionOverallSummary CarbonEmissionOverallSummary(double latestMonthEmissions = 0, double previousMonthEmissions = 0, double? monthOverMonthEmissionsChangeRatio = default(double?), double? monthlyEmissionsChangeValue = default(double?)) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemMonthlySummary CarbonEmissionTopItemMonthlySummary(double latestMonthEmissions = 0, double previousMonthEmissions = 0, double? monthOverMonthEmissionsChangeRatio = default(double?), double? monthlyEmissionsChangeValue = default(double?), string itemName = null, string itemType = null, Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum), string date = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemsSummary CarbonEmissionTopItemsSummary(double latestMonthEmissions = 0, double previousMonthEmissions = 0, double? monthOverMonthEmissionsChangeRatio = default(double?), double? monthlyEmissionsChangeValue = default(double?), string itemName = null, Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum)) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.ItemDetailsQueryFilter ItemDetailsQueryFilter(Azure.ResourceManager.CarbonOptimization.Models.DateRange dateRange = null, System.Collections.Generic.IEnumerable<string> subscriptionList = null, System.Collections.Generic.IEnumerable<string> resourceGroupUrlList = null, System.Collections.Generic.IEnumerable<string> resourceTypeList = null, System.Collections.Generic.IEnumerable<string> locationList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum> carbonScopeList = null, Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum), Azure.ResourceManager.CarbonOptimization.Models.OrderByColumnEnum orderBy = default(Azure.ResourceManager.CarbonOptimization.Models.OrderByColumnEnum), Azure.ResourceManager.CarbonOptimization.Models.SortDirectionEnum sortDirection = default(Azure.ResourceManager.CarbonOptimization.Models.SortDirectionEnum), int pageSize = 0, string skipToken = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.MonthlySummaryReportQueryFilter MonthlySummaryReportQueryFilter(Azure.ResourceManager.CarbonOptimization.Models.DateRange dateRange = null, System.Collections.Generic.IEnumerable<string> subscriptionList = null, System.Collections.Generic.IEnumerable<string> resourceGroupUrlList = null, System.Collections.Generic.IEnumerable<string> resourceTypeList = null, System.Collections.Generic.IEnumerable<string> locationList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum> carbonScopeList = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.OverallSummaryReportQueryFilter OverallSummaryReportQueryFilter(Azure.ResourceManager.CarbonOptimization.Models.DateRange dateRange = null, System.Collections.Generic.IEnumerable<string> subscriptionList = null, System.Collections.Generic.IEnumerable<string> resourceGroupUrlList = null, System.Collections.Generic.IEnumerable<string> resourceTypeList = null, System.Collections.Generic.IEnumerable<string> locationList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum> carbonScopeList = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.QueryFilter QueryFilter(string reportType = null, Azure.ResourceManager.CarbonOptimization.Models.DateRange dateRange = null, System.Collections.Generic.IEnumerable<string> subscriptionList = null, System.Collections.Generic.IEnumerable<string> resourceGroupUrlList = null, System.Collections.Generic.IEnumerable<string> resourceTypeList = null, System.Collections.Generic.IEnumerable<string> locationList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum> carbonScopeList = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionItemDetail ResourceCarbonEmissionItemDetail(double latestMonthEmissions = 0, double previousMonthEmissions = 0, double? monthOverMonthEmissionsChangeRatio = default(double?), double? monthlyEmissionsChangeValue = default(double?), string itemName = null, Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum), string subscriptionId = null, string resourceGroup = null, string resourceId = null, string location = null, string resourceType = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemMonthlySummary ResourceCarbonEmissionTopItemMonthlySummary(double latestMonthEmissions = 0, double previousMonthEmissions = 0, double? monthOverMonthEmissionsChangeRatio = default(double?), double? monthlyEmissionsChangeValue = default(double?), string itemName = null, Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum), string date = null, string subscriptionId = null, string resourceGroup = null, string resourceId = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemsSummary ResourceCarbonEmissionTopItemsSummary(double latestMonthEmissions = 0, double previousMonthEmissions = 0, double? monthOverMonthEmissionsChangeRatio = default(double?), double? monthlyEmissionsChangeValue = default(double?), string itemName = null, Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum), string subscriptionId = null, string resourceGroup = null, string resourceId = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionItemDetail ResourceGroupCarbonEmissionItemDetail(double latestMonthEmissions = 0, double previousMonthEmissions = 0, double? monthOverMonthEmissionsChangeRatio = default(double?), double? monthlyEmissionsChangeValue = default(double?), string itemName = null, Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum), string subscriptionId = null, string resourceGroupUri = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemMonthlySummary ResourceGroupCarbonEmissionTopItemMonthlySummary(double latestMonthEmissions = 0, double previousMonthEmissions = 0, double? monthOverMonthEmissionsChangeRatio = default(double?), double? monthlyEmissionsChangeValue = default(double?), string itemName = null, Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum), string date = null, string subscriptionId = null, string resourceGroupUri = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemsSummary ResourceGroupCarbonEmissionTopItemsSummary(double latestMonthEmissions = 0, double previousMonthEmissions = 0, double? monthOverMonthEmissionsChangeRatio = default(double?), double? monthlyEmissionsChangeValue = default(double?), string itemName = null, Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum), string subscriptionId = null, string resourceGroupUri = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.TopItemsMonthlySummaryReportQueryFilter TopItemsMonthlySummaryReportQueryFilter(Azure.ResourceManager.CarbonOptimization.Models.DateRange dateRange = null, System.Collections.Generic.IEnumerable<string> subscriptionList = null, System.Collections.Generic.IEnumerable<string> resourceGroupUrlList = null, System.Collections.Generic.IEnumerable<string> resourceTypeList = null, System.Collections.Generic.IEnumerable<string> locationList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum> carbonScopeList = null, Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum), int topItems = 0) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.TopItemsSummaryReportQueryFilter TopItemsSummaryReportQueryFilter(Azure.ResourceManager.CarbonOptimization.Models.DateRange dateRange = null, System.Collections.Generic.IEnumerable<string> subscriptionList = null, System.Collections.Generic.IEnumerable<string> resourceGroupUrlList = null, System.Collections.Generic.IEnumerable<string> resourceTypeList = null, System.Collections.Generic.IEnumerable<string> locationList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum> carbonScopeList = null, Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum), int topItems = 0) { throw null; }
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
    public partial class CarbonEmissionDataAvailableDateRange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionDataAvailableDateRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionDataAvailableDateRange>
    {
        internal CarbonEmissionDataAvailableDateRange() { }
        public string EndDate { get { throw null; } }
        public string StartDate { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionDataAvailableDateRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionDataAvailableDateRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionDataAvailableDateRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionDataAvailableDateRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionDataAvailableDateRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionDataAvailableDateRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionDataAvailableDateRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CarbonEmissionItemDetail : Azure.ResourceManager.CarbonOptimization.Models.CarbonEmission, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionItemDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionItemDetail>
    {
        internal CarbonEmissionItemDetail() : base (default(double), default(double)) { }
        public Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum CategoryType { get { throw null; } }
        public string ItemName { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionItemDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionItemDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionItemDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionItemDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionItemDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionItemDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionItemDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class CarbonEmissionTopItemMonthlySummary : Azure.ResourceManager.CarbonOptimization.Models.CarbonEmission, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemMonthlySummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemMonthlySummary>
    {
        internal CarbonEmissionTopItemMonthlySummary() : base (default(double), default(double)) { }
        public Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum CategoryType { get { throw null; } }
        public string Date { get { throw null; } }
        public string ItemName { get { throw null; } }
        public string ItemType { get { throw null; } }
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
        public Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum CategoryType { get { throw null; } }
        public string ItemName { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemsSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemsSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemsSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemsSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemsSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemsSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemsSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CategoryTypeEnum : System.IEquatable<Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CategoryTypeEnum(string value) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum Location { get { throw null; } }
        public static Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum Resource { get { throw null; } }
        public static Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum ResourceGroup { get { throw null; } }
        public static Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum ResourceType { get { throw null; } }
        public static Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum Subscription { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum left, Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum left, Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DateRange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.DateRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.DateRange>
    {
        public DateRange(System.DateTimeOffset start, System.DateTimeOffset end) { }
        public System.DateTimeOffset End { get { throw null; } }
        public System.DateTimeOffset Start { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.DateRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.DateRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.DateRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.DateRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.DateRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.DateRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.DateRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EmissionScopeEnum : System.IEquatable<Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EmissionScopeEnum(string value) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum Scope1 { get { throw null; } }
        public static Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum Scope2 { get { throw null; } }
        public static Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum Scope3 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum left, Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum left, Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ItemDetailsQueryFilter : Azure.ResourceManager.CarbonOptimization.Models.QueryFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ItemDetailsQueryFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ItemDetailsQueryFilter>
    {
        public ItemDetailsQueryFilter(Azure.ResourceManager.CarbonOptimization.Models.DateRange dateRange, System.Collections.Generic.IEnumerable<string> subscriptionList, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum> carbonScopeList, Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum categoryType, Azure.ResourceManager.CarbonOptimization.Models.OrderByColumnEnum orderBy, Azure.ResourceManager.CarbonOptimization.Models.SortDirectionEnum sortDirection, int pageSize) : base (default(Azure.ResourceManager.CarbonOptimization.Models.DateRange), default(System.Collections.Generic.IEnumerable<string>), default(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum>)) { }
        public Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum CategoryType { get { throw null; } }
        public Azure.ResourceManager.CarbonOptimization.Models.OrderByColumnEnum OrderBy { get { throw null; } }
        public int PageSize { get { throw null; } }
        public string SkipToken { get { throw null; } set { } }
        public Azure.ResourceManager.CarbonOptimization.Models.SortDirectionEnum SortDirection { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.ItemDetailsQueryFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ItemDetailsQueryFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ItemDetailsQueryFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.ItemDetailsQueryFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ItemDetailsQueryFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ItemDetailsQueryFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ItemDetailsQueryFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonthlySummaryReportQueryFilter : Azure.ResourceManager.CarbonOptimization.Models.QueryFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.MonthlySummaryReportQueryFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.MonthlySummaryReportQueryFilter>
    {
        public MonthlySummaryReportQueryFilter(Azure.ResourceManager.CarbonOptimization.Models.DateRange dateRange, System.Collections.Generic.IEnumerable<string> subscriptionList, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum> carbonScopeList) : base (default(Azure.ResourceManager.CarbonOptimization.Models.DateRange), default(System.Collections.Generic.IEnumerable<string>), default(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum>)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.MonthlySummaryReportQueryFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.MonthlySummaryReportQueryFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.MonthlySummaryReportQueryFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.MonthlySummaryReportQueryFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.MonthlySummaryReportQueryFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.MonthlySummaryReportQueryFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.MonthlySummaryReportQueryFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OrderByColumnEnum : System.IEquatable<Azure.ResourceManager.CarbonOptimization.Models.OrderByColumnEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrderByColumnEnum(string value) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.OrderByColumnEnum ItemName { get { throw null; } }
        public static Azure.ResourceManager.CarbonOptimization.Models.OrderByColumnEnum LatestMonthEmissions { get { throw null; } }
        public static Azure.ResourceManager.CarbonOptimization.Models.OrderByColumnEnum MonthlyEmissionsChangeValue { get { throw null; } }
        public static Azure.ResourceManager.CarbonOptimization.Models.OrderByColumnEnum MonthOverMonthEmissionsChangeRatio { get { throw null; } }
        public static Azure.ResourceManager.CarbonOptimization.Models.OrderByColumnEnum PreviousMonthEmissions { get { throw null; } }
        public static Azure.ResourceManager.CarbonOptimization.Models.OrderByColumnEnum ResourceGroup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CarbonOptimization.Models.OrderByColumnEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CarbonOptimization.Models.OrderByColumnEnum left, Azure.ResourceManager.CarbonOptimization.Models.OrderByColumnEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.CarbonOptimization.Models.OrderByColumnEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CarbonOptimization.Models.OrderByColumnEnum left, Azure.ResourceManager.CarbonOptimization.Models.OrderByColumnEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OverallSummaryReportQueryFilter : Azure.ResourceManager.CarbonOptimization.Models.QueryFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.OverallSummaryReportQueryFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.OverallSummaryReportQueryFilter>
    {
        public OverallSummaryReportQueryFilter(Azure.ResourceManager.CarbonOptimization.Models.DateRange dateRange, System.Collections.Generic.IEnumerable<string> subscriptionList, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum> carbonScopeList) : base (default(Azure.ResourceManager.CarbonOptimization.Models.DateRange), default(System.Collections.Generic.IEnumerable<string>), default(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum>)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.OverallSummaryReportQueryFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.OverallSummaryReportQueryFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.OverallSummaryReportQueryFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.OverallSummaryReportQueryFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.OverallSummaryReportQueryFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.OverallSummaryReportQueryFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.OverallSummaryReportQueryFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class QueryFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.QueryFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.QueryFilter>
    {
        protected QueryFilter(Azure.ResourceManager.CarbonOptimization.Models.DateRange dateRange, System.Collections.Generic.IEnumerable<string> subscriptionList, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum> carbonScopeList) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum> CarbonScopeList { get { throw null; } }
        public Azure.ResourceManager.CarbonOptimization.Models.DateRange DateRange { get { throw null; } }
        public System.Collections.Generic.IList<string> LocationList { get { throw null; } }
        public System.Collections.Generic.IList<string> ResourceGroupUrlList { get { throw null; } }
        public System.Collections.Generic.IList<string> ResourceTypeList { get { throw null; } }
        public System.Collections.Generic.IList<string> SubscriptionList { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.QueryFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.QueryFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.QueryFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.QueryFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.QueryFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.QueryFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.QueryFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceCarbonEmissionItemDetail : Azure.ResourceManager.CarbonOptimization.Models.CarbonEmission, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionItemDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionItemDetail>
    {
        internal ResourceCarbonEmissionItemDetail() : base (default(double), default(double)) { }
        public Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum CategoryType { get { throw null; } }
        public string ItemName { get { throw null; } }
        public string Location { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public string ResourceType { get { throw null; } }
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
        public Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum CategoryType { get { throw null; } }
        public string Date { get { throw null; } }
        public string ItemName { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string ResourceId { get { throw null; } }
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
        public Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum CategoryType { get { throw null; } }
        public string ItemName { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string ResourceId { get { throw null; } }
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
        public Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum CategoryType { get { throw null; } }
        public string ItemName { get { throw null; } }
        public string ResourceGroupUri { get { throw null; } }
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
        public Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum CategoryType { get { throw null; } }
        public string Date { get { throw null; } }
        public string ItemName { get { throw null; } }
        public string ResourceGroupUri { get { throw null; } }
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
        public Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum CategoryType { get { throw null; } }
        public string ItemName { get { throw null; } }
        public string ResourceGroupUri { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemsSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemsSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemsSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemsSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemsSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemsSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemsSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SortDirectionEnum : System.IEquatable<Azure.ResourceManager.CarbonOptimization.Models.SortDirectionEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SortDirectionEnum(string value) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.SortDirectionEnum Asc { get { throw null; } }
        public static Azure.ResourceManager.CarbonOptimization.Models.SortDirectionEnum Desc { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CarbonOptimization.Models.SortDirectionEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CarbonOptimization.Models.SortDirectionEnum left, Azure.ResourceManager.CarbonOptimization.Models.SortDirectionEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.CarbonOptimization.Models.SortDirectionEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CarbonOptimization.Models.SortDirectionEnum left, Azure.ResourceManager.CarbonOptimization.Models.SortDirectionEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TopItemsMonthlySummaryReportQueryFilter : Azure.ResourceManager.CarbonOptimization.Models.QueryFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsMonthlySummaryReportQueryFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsMonthlySummaryReportQueryFilter>
    {
        public TopItemsMonthlySummaryReportQueryFilter(Azure.ResourceManager.CarbonOptimization.Models.DateRange dateRange, System.Collections.Generic.IEnumerable<string> subscriptionList, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum> carbonScopeList, Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum categoryType, int topItems) : base (default(Azure.ResourceManager.CarbonOptimization.Models.DateRange), default(System.Collections.Generic.IEnumerable<string>), default(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum>)) { }
        public Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum CategoryType { get { throw null; } }
        public int TopItems { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.TopItemsMonthlySummaryReportQueryFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsMonthlySummaryReportQueryFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsMonthlySummaryReportQueryFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.TopItemsMonthlySummaryReportQueryFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsMonthlySummaryReportQueryFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsMonthlySummaryReportQueryFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsMonthlySummaryReportQueryFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TopItemsSummaryReportQueryFilter : Azure.ResourceManager.CarbonOptimization.Models.QueryFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsSummaryReportQueryFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsSummaryReportQueryFilter>
    {
        public TopItemsSummaryReportQueryFilter(Azure.ResourceManager.CarbonOptimization.Models.DateRange dateRange, System.Collections.Generic.IEnumerable<string> subscriptionList, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum> carbonScopeList, Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum categoryType, int topItems) : base (default(Azure.ResourceManager.CarbonOptimization.Models.DateRange), default(System.Collections.Generic.IEnumerable<string>), default(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum>)) { }
        public Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum CategoryType { get { throw null; } }
        public int TopItems { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.TopItemsSummaryReportQueryFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsSummaryReportQueryFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsSummaryReportQueryFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.TopItemsSummaryReportQueryFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsSummaryReportQueryFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsSummaryReportQueryFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsSummaryReportQueryFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
