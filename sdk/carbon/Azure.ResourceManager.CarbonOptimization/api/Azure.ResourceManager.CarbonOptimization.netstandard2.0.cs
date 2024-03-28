namespace Azure.ResourceManager.CarbonOptimization
{
    public static partial class CarbonOptimizationExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionData> GetCarbonEmissionReportsCarbonServices(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.CarbonOptimization.Models.QueryFilter queryParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionData> GetCarbonEmissionReportsCarbonServicesAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.CarbonOptimization.Models.QueryFilter queryParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionDataAvailableDateRange> QueryCarbonEmissionDataAvailableDateRangeCarbonService(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionDataAvailableDateRange>> QueryCarbonEmissionDataAvailableDateRangeCarbonServiceAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.CarbonOptimization.Mocking
{
    public partial class MockableCarbonOptimizationTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableCarbonOptimizationTenantResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionData> GetCarbonEmissionReportsCarbonServices(Azure.ResourceManager.CarbonOptimization.Models.QueryFilter queryParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionData> GetCarbonEmissionReportsCarbonServicesAsync(Azure.ResourceManager.CarbonOptimization.Models.QueryFilter queryParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionDataAvailableDateRange> QueryCarbonEmissionDataAvailableDateRangeCarbonService(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionDataAvailableDateRange>> QueryCarbonEmissionDataAvailableDateRangeCarbonServiceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.CarbonOptimization.Models
{
    public static partial class ArmCarbonOptimizationModelFactory
    {
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionData CarbonEmissionData(string dataType = null, double totalCarbonEmission = 0, double totalCarbonEmissionLastMonth = 0, double changeRatioForLastMonth = 0, double totalCarbonEmission12MonthsAgo = 0, double changeRatioFor12Months = 0, double? changeValueMonthOverMonth = default(double?)) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionDataAvailableDateRange CarbonEmissionDataAvailableDateRange(string startDate = null, string endDate = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionItemDetailData CarbonEmissionItemDetailData(double totalCarbonEmission = 0, double totalCarbonEmissionLastMonth = 0, double changeRatioForLastMonth = 0, double totalCarbonEmission12MonthsAgo = 0, double changeRatioFor12Months = 0, double? changeValueMonthOverMonth = default(double?), string itemName = null, string groupName = null, Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum)) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionMonthlySummaryData CarbonEmissionMonthlySummaryData(double totalCarbonEmission = 0, double totalCarbonEmissionLastMonth = 0, double changeRatioForLastMonth = 0, double totalCarbonEmission12MonthsAgo = 0, double changeRatioFor12Months = 0, double? changeValueMonthOverMonth = default(double?), string date = null, double carbonIntensity = 0) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionOverallSummaryData CarbonEmissionOverallSummaryData(double totalCarbonEmission = 0, double totalCarbonEmissionLastMonth = 0, double changeRatioForLastMonth = 0, double totalCarbonEmission12MonthsAgo = 0, double changeRatioFor12Months = 0, double? changeValueMonthOverMonth = default(double?)) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemMonthlySummaryData CarbonEmissionTopItemMonthlySummaryData(double totalCarbonEmission = 0, double totalCarbonEmissionLastMonth = 0, double changeRatioForLastMonth = 0, double totalCarbonEmission12MonthsAgo = 0, double changeRatioFor12Months = 0, double? changeValueMonthOverMonth = default(double?), string itemName = null, Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum), string date = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemsSummaryData CarbonEmissionTopItemsSummaryData(double totalCarbonEmission = 0, double totalCarbonEmissionLastMonth = 0, double changeRatioForLastMonth = 0, double totalCarbonEmission12MonthsAgo = 0, double changeRatioFor12Months = 0, double? changeValueMonthOverMonth = default(double?), string itemName = null, Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum)) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.ItemDetailsQueryFilter ItemDetailsQueryFilter(Azure.ResourceManager.CarbonOptimization.Models.DateRange dateRange = null, System.Collections.Generic.IEnumerable<string> subscriptionList = null, System.Collections.Generic.IEnumerable<string> resourceGroupUrlList = null, System.Collections.Generic.IEnumerable<string> resourceTypeList = null, System.Collections.Generic.IEnumerable<string> locationList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum> carbonScopeList = null, Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum), string orderBy = null, string sortDirection = null, string groupCategory = null, int pageSize = 0, string skipToken = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.MonthlySummaryReportQueryFilter MonthlySummaryReportQueryFilter(Azure.ResourceManager.CarbonOptimization.Models.DateRange dateRange = null, System.Collections.Generic.IEnumerable<string> subscriptionList = null, System.Collections.Generic.IEnumerable<string> resourceGroupUrlList = null, System.Collections.Generic.IEnumerable<string> resourceTypeList = null, System.Collections.Generic.IEnumerable<string> locationList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum> carbonScopeList = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.OverallSummaryReportQueryFilter OverallSummaryReportQueryFilter(Azure.ResourceManager.CarbonOptimization.Models.DateRange dateRange = null, System.Collections.Generic.IEnumerable<string> subscriptionList = null, System.Collections.Generic.IEnumerable<string> resourceGroupUrlList = null, System.Collections.Generic.IEnumerable<string> resourceTypeList = null, System.Collections.Generic.IEnumerable<string> locationList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum> carbonScopeList = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.QueryFilter QueryFilter(string reportType = null, Azure.ResourceManager.CarbonOptimization.Models.DateRange dateRange = null, System.Collections.Generic.IEnumerable<string> subscriptionList = null, System.Collections.Generic.IEnumerable<string> resourceGroupUrlList = null, System.Collections.Generic.IEnumerable<string> resourceTypeList = null, System.Collections.Generic.IEnumerable<string> locationList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum> carbonScopeList = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionItemDetailData ResourceCarbonEmissionItemDetailData(double totalCarbonEmission = 0, double totalCarbonEmissionLastMonth = 0, double changeRatioForLastMonth = 0, double totalCarbonEmission12MonthsAgo = 0, double changeRatioFor12Months = 0, double? changeValueMonthOverMonth = default(double?), string itemName = null, string groupName = null, Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum), string subscriptionId = null, string resourceGroup = null, string resourceId = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string resourceType = null, string resourceTypeFriendlyName = null, string resourceProvider = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemMonthlySummaryData ResourceCarbonEmissionTopItemMonthlySummaryData(double totalCarbonEmission = 0, double totalCarbonEmissionLastMonth = 0, double changeRatioForLastMonth = 0, double totalCarbonEmission12MonthsAgo = 0, double changeRatioFor12Months = 0, double? changeValueMonthOverMonth = default(double?), string itemName = null, Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum), string date = null, string subscriptionId = null, string resourceGroup = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemsSummaryData ResourceCarbonEmissionTopItemsSummaryData(double totalCarbonEmission = 0, double totalCarbonEmissionLastMonth = 0, double changeRatioForLastMonth = 0, double totalCarbonEmission12MonthsAgo = 0, double changeRatioFor12Months = 0, double? changeValueMonthOverMonth = default(double?), string itemName = null, Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum), string subscriptionId = null, string resourceGroup = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionItemDetailData ResourceGroupCarbonEmissionItemDetailData(double totalCarbonEmission = 0, double totalCarbonEmissionLastMonth = 0, double changeRatioForLastMonth = 0, double totalCarbonEmission12MonthsAgo = 0, double changeRatioFor12Months = 0, double? changeValueMonthOverMonth = default(double?), string itemName = null, string groupName = null, Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum), string subscriptionId = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemMonthlySummaryData ResourceGroupCarbonEmissionTopItemMonthlySummaryData(double totalCarbonEmission = 0, double totalCarbonEmissionLastMonth = 0, double changeRatioForLastMonth = 0, double totalCarbonEmission12MonthsAgo = 0, double changeRatioFor12Months = 0, double? changeValueMonthOverMonth = default(double?), string itemName = null, Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum), string date = null, string subscriptionId = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemsSummaryData ResourceGroupCarbonEmissionTopItemsSummaryData(double totalCarbonEmission = 0, double totalCarbonEmissionLastMonth = 0, double changeRatioForLastMonth = 0, double totalCarbonEmission12MonthsAgo = 0, double changeRatioFor12Months = 0, double? changeValueMonthOverMonth = default(double?), string itemName = null, Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum), string subscriptionId = null) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.ResourceTypeCarbonEmissionItemDetailData ResourceTypeCarbonEmissionItemDetailData(double totalCarbonEmission = 0, double totalCarbonEmissionLastMonth = 0, double changeRatioForLastMonth = 0, double totalCarbonEmission12MonthsAgo = 0, double changeRatioFor12Months = 0, double? changeValueMonthOverMonth = default(double?), string itemName = null, string resourceTypeFriendlyName = null, Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum)) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.TopItemsMonthlySummaryReportQueryFilter TopItemsMonthlySummaryReportQueryFilter(Azure.ResourceManager.CarbonOptimization.Models.DateRange dateRange = null, System.Collections.Generic.IEnumerable<string> subscriptionList = null, System.Collections.Generic.IEnumerable<string> resourceGroupUrlList = null, System.Collections.Generic.IEnumerable<string> resourceTypeList = null, System.Collections.Generic.IEnumerable<string> locationList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum> carbonScopeList = null, Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum), int topItems = 0) { throw null; }
        public static Azure.ResourceManager.CarbonOptimization.Models.TopItemsSummaryReportQueryFilter TopItemsSummaryReportQueryFilter(Azure.ResourceManager.CarbonOptimization.Models.DateRange dateRange = null, System.Collections.Generic.IEnumerable<string> subscriptionList = null, System.Collections.Generic.IEnumerable<string> resourceGroupUrlList = null, System.Collections.Generic.IEnumerable<string> resourceTypeList = null, System.Collections.Generic.IEnumerable<string> locationList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum> carbonScopeList = null, Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum categoryType = default(Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum), int topItems = 0) { throw null; }
    }
    public abstract partial class CarbonEmissionData : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionData>
    {
        protected CarbonEmissionData(double totalCarbonEmission, double totalCarbonEmissionLastMonth, double changeRatioForLastMonth, double totalCarbonEmission12MonthsAgo, double changeRatioFor12Months) { }
        public double ChangeRatioFor12Months { get { throw null; } }
        public double ChangeRatioForLastMonth { get { throw null; } }
        public double? ChangeValueMonthOverMonth { get { throw null; } }
        public double TotalCarbonEmission { get { throw null; } }
        public double TotalCarbonEmission12MonthsAgo { get { throw null; } }
        public double TotalCarbonEmissionLastMonth { get { throw null; } }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CarbonEmissionDataAvailableDateRange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionDataAvailableDateRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionDataAvailableDateRange>
    {
        internal CarbonEmissionDataAvailableDateRange() { }
        public string EndDate { get { throw null; } }
        public string StartDate { get { throw null; } }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionDataAvailableDateRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionDataAvailableDateRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionDataAvailableDateRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionDataAvailableDateRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionDataAvailableDateRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionDataAvailableDateRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionDataAvailableDateRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CarbonEmissionItemDetailData : Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionItemDetailData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionItemDetailData>
    {
        internal CarbonEmissionItemDetailData() : base (default(double), default(double), default(double), default(double), default(double)) { }
        public Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum CategoryType { get { throw null; } }
        public string GroupName { get { throw null; } }
        public string ItemName { get { throw null; } }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionItemDetailData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionItemDetailData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionItemDetailData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionItemDetailData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionItemDetailData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionItemDetailData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionItemDetailData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CarbonEmissionMonthlySummaryData : Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionMonthlySummaryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionMonthlySummaryData>
    {
        internal CarbonEmissionMonthlySummaryData() : base (default(double), default(double), default(double), default(double), default(double)) { }
        public double CarbonIntensity { get { throw null; } }
        public string Date { get { throw null; } }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionMonthlySummaryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionMonthlySummaryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionMonthlySummaryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionMonthlySummaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionMonthlySummaryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionMonthlySummaryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionMonthlySummaryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CarbonEmissionOverallSummaryData : Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionOverallSummaryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionOverallSummaryData>
    {
        internal CarbonEmissionOverallSummaryData() : base (default(double), default(double), default(double), default(double), default(double)) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionOverallSummaryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionOverallSummaryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionOverallSummaryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionOverallSummaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionOverallSummaryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionOverallSummaryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionOverallSummaryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CarbonEmissionTopItemMonthlySummaryData : Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemMonthlySummaryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemMonthlySummaryData>
    {
        internal CarbonEmissionTopItemMonthlySummaryData() : base (default(double), default(double), default(double), default(double), default(double)) { }
        public Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum CategoryType { get { throw null; } }
        public string Date { get { throw null; } }
        public string ItemName { get { throw null; } }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemMonthlySummaryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemMonthlySummaryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemMonthlySummaryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemMonthlySummaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemMonthlySummaryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemMonthlySummaryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemMonthlySummaryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CarbonEmissionTopItemsSummaryData : Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemsSummaryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemsSummaryData>
    {
        internal CarbonEmissionTopItemsSummaryData() : base (default(double), default(double), default(double), default(double), default(double)) { }
        public Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum CategoryType { get { throw null; } }
        public string ItemName { get { throw null; } }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemsSummaryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemsSummaryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemsSummaryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemsSummaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemsSummaryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemsSummaryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionTopItemsSummaryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum ServiceType { get { throw null; } }
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
        public ItemDetailsQueryFilter(Azure.ResourceManager.CarbonOptimization.Models.DateRange dateRange, System.Collections.Generic.IEnumerable<string> subscriptionList, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum> carbonScopeList, Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum categoryType, string orderBy, string sortDirection, string groupCategory, int pageSize) : base (default(Azure.ResourceManager.CarbonOptimization.Models.DateRange), default(System.Collections.Generic.IEnumerable<string>), default(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum>)) { }
        public Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum CategoryType { get { throw null; } }
        public string GroupCategory { get { throw null; } }
        public string OrderBy { get { throw null; } }
        public int PageSize { get { throw null; } }
        public string SkipToken { get { throw null; } set { } }
        public string SortDirection { get { throw null; } }
        Azure.ResourceManager.CarbonOptimization.Models.ItemDetailsQueryFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ItemDetailsQueryFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ItemDetailsQueryFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.ItemDetailsQueryFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ItemDetailsQueryFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ItemDetailsQueryFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ItemDetailsQueryFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonthlySummaryReportQueryFilter : Azure.ResourceManager.CarbonOptimization.Models.QueryFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.MonthlySummaryReportQueryFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.MonthlySummaryReportQueryFilter>
    {
        public MonthlySummaryReportQueryFilter(Azure.ResourceManager.CarbonOptimization.Models.DateRange dateRange, System.Collections.Generic.IEnumerable<string> subscriptionList, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum> carbonScopeList) : base (default(Azure.ResourceManager.CarbonOptimization.Models.DateRange), default(System.Collections.Generic.IEnumerable<string>), default(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum>)) { }
        Azure.ResourceManager.CarbonOptimization.Models.MonthlySummaryReportQueryFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.MonthlySummaryReportQueryFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.MonthlySummaryReportQueryFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.MonthlySummaryReportQueryFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.MonthlySummaryReportQueryFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.MonthlySummaryReportQueryFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.MonthlySummaryReportQueryFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OverallSummaryReportQueryFilter : Azure.ResourceManager.CarbonOptimization.Models.QueryFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.OverallSummaryReportQueryFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.OverallSummaryReportQueryFilter>
    {
        public OverallSummaryReportQueryFilter(Azure.ResourceManager.CarbonOptimization.Models.DateRange dateRange, System.Collections.Generic.IEnumerable<string> subscriptionList, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum> carbonScopeList) : base (default(Azure.ResourceManager.CarbonOptimization.Models.DateRange), default(System.Collections.Generic.IEnumerable<string>), default(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum>)) { }
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
        Azure.ResourceManager.CarbonOptimization.Models.QueryFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.QueryFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.QueryFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.QueryFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.QueryFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.QueryFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.QueryFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceCarbonEmissionItemDetailData : Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionItemDetailData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionItemDetailData>
    {
        internal ResourceCarbonEmissionItemDetailData() : base (default(double), default(double), default(double), default(double), default(double)) { }
        public Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum CategoryType { get { throw null; } }
        public string GroupName { get { throw null; } }
        public string ItemName { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public string ResourceProvider { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public string ResourceTypeFriendlyName { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionItemDetailData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionItemDetailData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionItemDetailData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionItemDetailData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionItemDetailData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionItemDetailData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionItemDetailData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceCarbonEmissionTopItemMonthlySummaryData : Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemMonthlySummaryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemMonthlySummaryData>
    {
        internal ResourceCarbonEmissionTopItemMonthlySummaryData() : base (default(double), default(double), default(double), default(double), default(double)) { }
        public Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum CategoryType { get { throw null; } }
        public string Date { get { throw null; } }
        public string ItemName { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemMonthlySummaryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemMonthlySummaryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemMonthlySummaryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemMonthlySummaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemMonthlySummaryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemMonthlySummaryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemMonthlySummaryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceCarbonEmissionTopItemsSummaryData : Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemsSummaryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemsSummaryData>
    {
        internal ResourceCarbonEmissionTopItemsSummaryData() : base (default(double), default(double), default(double), default(double), default(double)) { }
        public Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum CategoryType { get { throw null; } }
        public string ItemName { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemsSummaryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemsSummaryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemsSummaryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemsSummaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemsSummaryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemsSummaryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceCarbonEmissionTopItemsSummaryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceGroupCarbonEmissionItemDetailData : Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionItemDetailData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionItemDetailData>
    {
        internal ResourceGroupCarbonEmissionItemDetailData() : base (default(double), default(double), default(double), default(double), default(double)) { }
        public Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum CategoryType { get { throw null; } }
        public string GroupName { get { throw null; } }
        public string ItemName { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionItemDetailData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionItemDetailData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionItemDetailData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionItemDetailData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionItemDetailData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionItemDetailData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionItemDetailData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceGroupCarbonEmissionTopItemMonthlySummaryData : Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemMonthlySummaryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemMonthlySummaryData>
    {
        internal ResourceGroupCarbonEmissionTopItemMonthlySummaryData() : base (default(double), default(double), default(double), default(double), default(double)) { }
        public Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum CategoryType { get { throw null; } }
        public string Date { get { throw null; } }
        public string ItemName { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemMonthlySummaryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemMonthlySummaryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemMonthlySummaryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemMonthlySummaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemMonthlySummaryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemMonthlySummaryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemMonthlySummaryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceGroupCarbonEmissionTopItemsSummaryData : Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemsSummaryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemsSummaryData>
    {
        internal ResourceGroupCarbonEmissionTopItemsSummaryData() : base (default(double), default(double), default(double), default(double), default(double)) { }
        public Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum CategoryType { get { throw null; } }
        public string ItemName { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemsSummaryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemsSummaryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemsSummaryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemsSummaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemsSummaryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemsSummaryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceGroupCarbonEmissionTopItemsSummaryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceTypeCarbonEmissionItemDetailData : Azure.ResourceManager.CarbonOptimization.Models.CarbonEmissionData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceTypeCarbonEmissionItemDetailData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceTypeCarbonEmissionItemDetailData>
    {
        internal ResourceTypeCarbonEmissionItemDetailData() : base (default(double), default(double), default(double), default(double), default(double)) { }
        public Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum CategoryType { get { throw null; } }
        public string ItemName { get { throw null; } }
        public string ResourceTypeFriendlyName { get { throw null; } }
        Azure.ResourceManager.CarbonOptimization.Models.ResourceTypeCarbonEmissionItemDetailData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceTypeCarbonEmissionItemDetailData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceTypeCarbonEmissionItemDetailData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.ResourceTypeCarbonEmissionItemDetailData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceTypeCarbonEmissionItemDetailData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceTypeCarbonEmissionItemDetailData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.ResourceTypeCarbonEmissionItemDetailData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TopItemsMonthlySummaryReportQueryFilter : Azure.ResourceManager.CarbonOptimization.Models.QueryFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsMonthlySummaryReportQueryFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsMonthlySummaryReportQueryFilter>
    {
        public TopItemsMonthlySummaryReportQueryFilter(Azure.ResourceManager.CarbonOptimization.Models.DateRange dateRange, System.Collections.Generic.IEnumerable<string> subscriptionList, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum> carbonScopeList, Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum categoryType, int topItems) : base (default(Azure.ResourceManager.CarbonOptimization.Models.DateRange), default(System.Collections.Generic.IEnumerable<string>), default(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CarbonOptimization.Models.EmissionScopeEnum>)) { }
        public Azure.ResourceManager.CarbonOptimization.Models.CategoryTypeEnum CategoryType { get { throw null; } }
        public int TopItems { get { throw null; } }
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
        Azure.ResourceManager.CarbonOptimization.Models.TopItemsSummaryReportQueryFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsSummaryReportQueryFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsSummaryReportQueryFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CarbonOptimization.Models.TopItemsSummaryReportQueryFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsSummaryReportQueryFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsSummaryReportQueryFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CarbonOptimization.Models.TopItemsSummaryReportQueryFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
