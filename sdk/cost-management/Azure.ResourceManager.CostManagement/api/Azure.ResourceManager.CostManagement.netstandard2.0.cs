namespace Azure.ResourceManager.CostManagement
{
    public partial class CostManagementAlertCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CostManagement.CostManagementAlertResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.CostManagementAlertResource>, System.Collections.IEnumerable
    {
        protected CostManagementAlertCollection() { }
        public virtual Azure.Response<bool> Exists(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.CostManagementAlertResource> Get(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CostManagement.CostManagementAlertResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CostManagement.CostManagementAlertResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.CostManagementAlertResource>> GetAsync(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CostManagement.CostManagementAlertResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CostManagement.CostManagementAlertResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CostManagement.CostManagementAlertResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.CostManagementAlertResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CostManagementAlertData : Azure.ResourceManager.Models.ResourceData
    {
        public CostManagementAlertData() { }
        public string CloseTime { get { throw null; } set { } }
        public string CostEntityId { get { throw null; } set { } }
        public string CreationTime { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.AlertPropertiesDefinition Definition { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.AlertPropertiesDetails Details { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string ModificationTime { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.AlertSource? Source { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.AlertStatus? Status { get { throw null; } set { } }
        public string StatusModificationTime { get { throw null; } set { } }
        public string StatusModificationUserName { get { throw null; } set { } }
    }
    public partial class CostManagementAlertResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CostManagementAlertResource() { }
        public virtual Azure.ResourceManager.CostManagement.CostManagementAlertData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string alertId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.CostManagementAlertResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.CostManagementAlertResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.CostManagementAlertResource> Update(Azure.ResourceManager.CostManagement.Models.CostManagementAlertPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.CostManagementAlertResource>> UpdateAsync(Azure.ResourceManager.CostManagement.Models.CostManagementAlertPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CostManagementExportCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CostManagement.CostManagementExportResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.CostManagementExportResource>, System.Collections.IEnumerable
    {
        protected CostManagementExportCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.CostManagementExportResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string exportName, Azure.ResourceManager.CostManagement.CostManagementExportData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.CostManagementExportResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string exportName, Azure.ResourceManager.CostManagement.CostManagementExportData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string exportName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string exportName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.CostManagementExportResource> Get(string exportName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CostManagement.CostManagementExportResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CostManagement.CostManagementExportResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.CostManagementExportResource>> GetAsync(string exportName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CostManagement.CostManagementExportResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CostManagement.CostManagementExportResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CostManagement.CostManagementExportResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.CostManagementExportResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CostManagementExportData : Azure.ResourceManager.Models.ResourceData
    {
        public CostManagementExportData() { }
        public Azure.ResourceManager.CostManagement.Models.ExportDefinition Definition { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ExportDeliveryDestination DeliveryInfoDestination { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.FormatType? Format { get { throw null; } set { } }
        public System.DateTimeOffset? NextRunTimeEstimate { get { throw null; } }
        public bool? PartitionData { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CostManagement.Models.ExportRun> RunHistoryValue { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.ExportSchedule Schedule { get { throw null; } set { } }
    }
    public partial class CostManagementExportResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CostManagementExportResource() { }
        public virtual Azure.ResourceManager.CostManagement.CostManagementExportData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string exportName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Execute(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ExecuteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.CostManagementExportResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.CostManagementExportResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CostManagement.Models.ExportRun> GetExecutionHistory(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CostManagement.Models.ExportRun> GetExecutionHistoryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.CostManagementExportResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement.CostManagementExportData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.CostManagementExportResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement.CostManagementExportData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class CostManagementExtensions
    {
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.OperationStatus> ByBillingAccountIdGenerateReservationDetailsReport(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string billingAccountId, string startDate, string endDate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.OperationStatus>> ByBillingAccountIdGenerateReservationDetailsReportAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string billingAccountId, string startDate, string endDate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.OperationStatus> ByBillingProfileIdGenerateReservationDetailsReport(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string billingAccountId, string billingProfileId, string startDate, string endDate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.OperationStatus>> ByBillingProfileIdGenerateReservationDetailsReportAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string billingAccountId, string billingProfileId, string startDate, string endDate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CostManagement.Models.CheckNameAvailabilityResponse> CheckNameAvailabilityScheduledAction(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.CostManagement.Models.CheckNameAvailabilityRequest checkNameAvailabilityRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.Models.CheckNameAvailabilityResponse>> CheckNameAvailabilityScheduledActionAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.CostManagement.Models.CheckNameAvailabilityRequest checkNameAvailabilityRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.DownloadURL> DownloadByBillingProfilePriceSheet(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string billingAccountName, string billingProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.DownloadURL>> DownloadByBillingProfilePriceSheetAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string billingAccountName, string billingProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.DownloadURL> DownloadPriceSheet(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string billingAccountName, string billingProfileName, string invoiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.DownloadURL>> DownloadPriceSheetAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string billingAccountName, string billingProfileName, string invoiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CostManagement.CostManagementViewsCollection GetAllCostManagementViews(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.CostManagement.TenantsCostManagementViewsCollection GetAllTenantsCostManagementViews(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesByBillingAccountId(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, Azure.ResourceManager.CostManagement.Models.GrainParameter? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainParameter?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesByBillingAccountIdAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, Azure.ResourceManager.CostManagement.Models.GrainParameter? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainParameter?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesByBillingProfileId(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, string billingProfileId, Azure.ResourceManager.CostManagement.Models.GrainParameter? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainParameter?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesByBillingProfileIdAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, string billingProfileId, Azure.ResourceManager.CostManagement.Models.GrainParameter? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainParameter?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesBySavingsPlanId(this Azure.ResourceManager.Resources.TenantResource tenantResource, string savingsPlanOrderId, string savingsPlanId, string filter = null, Azure.ResourceManager.CostManagement.Models.GrainParameter? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainParameter?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesBySavingsPlanIdAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string savingsPlanOrderId, string savingsPlanId, string filter = null, Azure.ResourceManager.CostManagement.Models.GrainParameter? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainParameter?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesBySavingsPlanOrder(this Azure.ResourceManager.Resources.TenantResource tenantResource, string savingsPlanOrderId, string filter = null, Azure.ResourceManager.CostManagement.Models.GrainParameter? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainParameter?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesBySavingsPlanOrderAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string savingsPlanOrderId, string filter = null, Azure.ResourceManager.CostManagement.Models.GrainParameter? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainParameter?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CostManagement.CostManagementAlertResource> GetCostManagementAlert(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.CostManagementAlertResource>> GetCostManagementAlertAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CostManagement.CostManagementAlertResource GetCostManagementAlertResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CostManagement.CostManagementAlertCollection GetCostManagementAlerts(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CostManagement.CostManagementExportResource> GetCostManagementExport(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string exportName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.CostManagementExportResource>> GetCostManagementExportAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string exportName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CostManagement.CostManagementExportResource GetCostManagementExportResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CostManagement.CostManagementExportCollection GetCostManagementExports(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CostManagement.CostManagementViewsResource> GetCostManagementViews(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.CostManagementViewsResource>> GetCostManagementViewsAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CostManagement.CostManagementViewsResource GetCostManagementViewsResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CostManagement.ScheduledActionResource> GetScheduledAction(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.ScheduledActionResource>> GetScheduledActionAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CostManagement.ScheduledActionResource GetScheduledActionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CostManagement.ScheduledActionCollection GetScheduledActions(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CostManagement.TenantScheduledActionResource> GetTenantScheduledAction(this Azure.ResourceManager.Resources.TenantResource tenantResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.TenantScheduledActionResource>> GetTenantScheduledActionAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CostManagement.TenantScheduledActionResource GetTenantScheduledActionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CostManagement.TenantScheduledActionCollection GetTenantScheduledActions(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource> GetTenantsCostManagementViews(this Azure.ResourceManager.Resources.TenantResource tenantResource, string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource>> GetTenantsCostManagementViewsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource GetTenantsCostManagementViewsResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class CostManagementViewData : Azure.ResourceManager.Models.ResourceData
    {
        public CostManagementViewData() { }
        public Azure.ResourceManager.CostManagement.Models.AccumulatedType? Accumulated { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ChartType? Chart { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Currency { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.ReportConfigDataset DataSet { get { throw null; } set { } }
        public string DateRange { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public bool? IncludeMonetaryCommitment { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CostManagement.Models.KpiProperties> Kpis { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.MetricType? Metric { get { throw null; } set { } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CostManagement.Models.PivotProperties> Pivots { get { throw null; } }
        public string Scope { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ReportTimeframeType? Timeframe { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ReportConfigTimePeriod TimePeriod { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ReportType? TypePropertiesQueryType { get { throw null; } set { } }
    }
    public partial class CostManagementViewsCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CostManagement.CostManagementViewsResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.CostManagementViewsResource>, System.Collections.IEnumerable
    {
        protected CostManagementViewsCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.CostManagementViewsResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string viewName, Azure.ResourceManager.CostManagement.CostManagementViewData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.CostManagementViewsResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string viewName, Azure.ResourceManager.CostManagement.CostManagementViewData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.CostManagementViewsResource> Get(string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CostManagement.CostManagementViewsResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CostManagement.CostManagementViewsResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.CostManagementViewsResource>> GetAsync(string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CostManagement.CostManagementViewsResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CostManagement.CostManagementViewsResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CostManagement.CostManagementViewsResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.CostManagementViewsResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CostManagementViewsResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CostManagementViewsResource() { }
        public virtual Azure.ResourceManager.CostManagement.CostManagementViewData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string viewName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.CostManagementViewsResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.CostManagementViewsResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.CostManagementViewsResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement.CostManagementViewData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.CostManagementViewsResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement.CostManagementViewData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScheduledActionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CostManagement.ScheduledActionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.ScheduledActionResource>, System.Collections.IEnumerable
    {
        protected ScheduledActionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.ScheduledActionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.CostManagement.ScheduledActionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.ScheduledActionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.CostManagement.ScheduledActionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.ScheduledActionResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CostManagement.ScheduledActionResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CostManagement.ScheduledActionResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.ScheduledActionResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CostManagement.ScheduledActionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CostManagement.ScheduledActionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CostManagement.ScheduledActionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.ScheduledActionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScheduledActionData : Azure.ResourceManager.Models.ResourceData
    {
        public ScheduledActionData() { }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CostManagement.Models.FileFormat> FileFormats { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.ScheduledActionKind? Kind { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.NotificationProperties Notification { get { throw null; } set { } }
        public string NotificationEmail { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ScheduleProperties Schedule { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ScheduledActionStatus? Status { get { throw null; } set { } }
        public string ViewId { get { throw null; } set { } }
    }
    public partial class ScheduledActionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScheduledActionResource() { }
        public virtual Azure.ResourceManager.CostManagement.ScheduledActionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.ScheduledActionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.ScheduledActionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RunByScope(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RunByScopeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.ScheduledActionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement.ScheduledActionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.ScheduledActionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement.ScheduledActionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantScheduledActionCollection : Azure.ResourceManager.ArmCollection
    {
        protected TenantScheduledActionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.TenantScheduledActionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.CostManagement.ScheduledActionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.TenantScheduledActionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.CostManagement.ScheduledActionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.TenantScheduledActionResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.TenantScheduledActionResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantScheduledActionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TenantScheduledActionResource() { }
        public virtual Azure.ResourceManager.CostManagement.ScheduledActionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.TenantScheduledActionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.TenantScheduledActionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Run(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RunAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.TenantScheduledActionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement.ScheduledActionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.TenantScheduledActionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement.ScheduledActionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantsCostManagementViewsCollection : Azure.ResourceManager.ArmCollection
    {
        protected TenantsCostManagementViewsCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string viewName, Azure.ResourceManager.CostManagement.CostManagementViewData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string viewName, Azure.ResourceManager.CostManagement.CostManagementViewData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource> Get(string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource>> GetAsync(string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantsCostManagementViewsResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TenantsCostManagementViewsResource() { }
        public virtual Azure.ResourceManager.CostManagement.CostManagementViewData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string viewName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement.CostManagementViewData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement.CostManagementViewData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.CostManagement.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccumulatedType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.AccumulatedType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccumulatedType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.AccumulatedType False { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AccumulatedType True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.AccumulatedType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.AccumulatedType left, Azure.ResourceManager.CostManagement.Models.AccumulatedType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.AccumulatedType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.AccumulatedType left, Azure.ResourceManager.CostManagement.Models.AccumulatedType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertCategory : System.IEquatable<Azure.ResourceManager.CostManagement.Models.AlertCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertCategory(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.AlertCategory Billing { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertCategory Cost { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertCategory System { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertCategory Usage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.AlertCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.AlertCategory left, Azure.ResourceManager.CostManagement.Models.AlertCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.AlertCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.AlertCategory left, Azure.ResourceManager.CostManagement.Models.AlertCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertCriterion : System.IEquatable<Azure.ResourceManager.CostManagement.Models.AlertCriterion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertCriterion(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.AlertCriterion CostThresholdExceeded { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertCriterion CreditThresholdApproaching { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertCriterion CreditThresholdReached { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertCriterion CrossCloudCollectionError { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertCriterion CrossCloudNewDataAvailable { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertCriterion ForecastCostThresholdExceeded { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertCriterion ForecastUsageThresholdExceeded { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertCriterion GeneralThresholdError { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertCriterion InvoiceDueDateApproaching { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertCriterion InvoiceDueDateReached { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertCriterion MultiCurrency { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertCriterion QuotaThresholdApproaching { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertCriterion QuotaThresholdReached { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertCriterion UsageThresholdExceeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.AlertCriterion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.AlertCriterion left, Azure.ResourceManager.CostManagement.Models.AlertCriterion right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.AlertCriterion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.AlertCriterion left, Azure.ResourceManager.CostManagement.Models.AlertCriterion right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertOperator : System.IEquatable<Azure.ResourceManager.CostManagement.Models.AlertOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertOperator(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.AlertOperator EqualTo { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertOperator GreaterThanOrEqualTo { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertOperator LessThanOrEqualTo { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertOperator None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.AlertOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.AlertOperator left, Azure.ResourceManager.CostManagement.Models.AlertOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.AlertOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.AlertOperator left, Azure.ResourceManager.CostManagement.Models.AlertOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AlertPropertiesDefinition
    {
        public AlertPropertiesDefinition() { }
        public Azure.ResourceManager.CostManagement.Models.AlertType? AlertType { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.AlertCategory? Category { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.AlertCriterion? Criteria { get { throw null; } set { } }
    }
    public partial class AlertPropertiesDetails
    {
        public AlertPropertiesDetails() { }
        public decimal? Amount { get { throw null; } set { } }
        public string CompanyName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ContactEmails { get { throw null; } }
        public System.Collections.Generic.IList<string> ContactGroups { get { throw null; } }
        public System.Collections.Generic.IList<string> ContactRoles { get { throw null; } }
        public decimal? CurrentSpend { get { throw null; } set { } }
        public string DepartmentName { get { throw null; } set { } }
        public string EnrollmentEndDate { get { throw null; } set { } }
        public string EnrollmentNumber { get { throw null; } set { } }
        public string EnrollmentStartDate { get { throw null; } set { } }
        public decimal? InvoicingThreshold { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> MeterFilter { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.AlertOperator? Operator { get { throw null; } set { } }
        public string OverridingAlert { get { throw null; } set { } }
        public string PeriodStartDate { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> ResourceFilter { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> ResourceGroupFilter { get { throw null; } }
        public System.BinaryData TagFilter { get { throw null; } set { } }
        public decimal? Threshold { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.AlertTimeGrainType? TimeGrainType { get { throw null; } set { } }
        public string TriggeredBy { get { throw null; } set { } }
        public string Unit { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertSource : System.IEquatable<Azure.ResourceManager.CostManagement.Models.AlertSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertSource(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.AlertSource Preset { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertSource User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.AlertSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.AlertSource left, Azure.ResourceManager.CostManagement.Models.AlertSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.AlertSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.AlertSource left, Azure.ResourceManager.CostManagement.Models.AlertSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertStatus : System.IEquatable<Azure.ResourceManager.CostManagement.Models.AlertStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertStatus(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.AlertStatus Active { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertStatus Dismissed { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertStatus None { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertStatus Overridden { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertStatus Resolved { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.AlertStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.AlertStatus left, Azure.ResourceManager.CostManagement.Models.AlertStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.AlertStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.AlertStatus left, Azure.ResourceManager.CostManagement.Models.AlertStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertTimeGrainType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.AlertTimeGrainType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertTimeGrainType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.AlertTimeGrainType Annually { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertTimeGrainType BillingAnnual { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertTimeGrainType BillingMonth { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertTimeGrainType BillingQuarter { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertTimeGrainType Monthly { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertTimeGrainType None { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertTimeGrainType Quarterly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.AlertTimeGrainType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.AlertTimeGrainType left, Azure.ResourceManager.CostManagement.Models.AlertTimeGrainType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.AlertTimeGrainType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.AlertTimeGrainType left, Azure.ResourceManager.CostManagement.Models.AlertTimeGrainType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.AlertType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.AlertType Budget { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertType BudgetForecast { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertType Credit { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertType General { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertType Invoice { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertType Quota { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertType XCloud { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.AlertType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.AlertType left, Azure.ResourceManager.CostManagement.Models.AlertType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.AlertType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.AlertType left, Azure.ResourceManager.CostManagement.Models.AlertType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BenefitKind : System.IEquatable<Azure.ResourceManager.CostManagement.Models.BenefitKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BenefitKind(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.BenefitKind IncludedQuantity { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.BenefitKind Reservation { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.BenefitKind SavingsPlan { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.BenefitKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.BenefitKind left, Azure.ResourceManager.CostManagement.Models.BenefitKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.BenefitKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.BenefitKind left, Azure.ResourceManager.CostManagement.Models.BenefitKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BenefitUtilizationSummary : Azure.ResourceManager.Models.ResourceData
    {
        public BenefitUtilizationSummary() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChartType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ChartType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChartType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ChartType Area { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ChartType GroupedColumn { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ChartType Line { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ChartType StackedColumn { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ChartType Table { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ChartType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ChartType left, Azure.ResourceManager.CostManagement.Models.ChartType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ChartType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ChartType left, Azure.ResourceManager.CostManagement.Models.ChartType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CheckNameAvailabilityReason : System.IEquatable<Azure.ResourceManager.CostManagement.Models.CheckNameAvailabilityReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CheckNameAvailabilityReason(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.CheckNameAvailabilityReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CheckNameAvailabilityReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.CheckNameAvailabilityReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.CheckNameAvailabilityReason left, Azure.ResourceManager.CostManagement.Models.CheckNameAvailabilityReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.CheckNameAvailabilityReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.CheckNameAvailabilityReason left, Azure.ResourceManager.CostManagement.Models.CheckNameAvailabilityReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CheckNameAvailabilityRequest
    {
        public CheckNameAvailabilityRequest() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
    }
    public partial class CheckNameAvailabilityResponse
    {
        internal CheckNameAvailabilityResponse() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.CheckNameAvailabilityReason? Reason { get { throw null; } }
    }
    public partial class CommonExportProperties
    {
        public CommonExportProperties(Azure.ResourceManager.CostManagement.Models.ExportDeliveryInfo deliveryInfo, Azure.ResourceManager.CostManagement.Models.ExportDefinition definition) { }
        public Azure.ResourceManager.CostManagement.Models.ExportDefinition Definition { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ExportDeliveryDestination DeliveryInfoDestination { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.FormatType? Format { get { throw null; } set { } }
        public System.DateTimeOffset? NextRunTimeEstimate { get { throw null; } }
        public bool? PartitionData { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CostManagement.Models.ExportRun> RunHistoryValue { get { throw null; } }
    }
    public partial class CostManagementAlertPatch
    {
        public CostManagementAlertPatch() { }
        public string CloseTime { get { throw null; } set { } }
        public string CostEntityId { get { throw null; } set { } }
        public string CreationTime { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.AlertPropertiesDefinition Definition { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.AlertPropertiesDetails Details { get { throw null; } set { } }
        public string ModificationTime { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.AlertSource? Source { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.AlertStatus? Status { get { throw null; } set { } }
        public string StatusModificationTime { get { throw null; } set { } }
        public string StatusModificationUserName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DaysOfWeek : System.IEquatable<Azure.ResourceManager.CostManagement.Models.DaysOfWeek>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DaysOfWeek(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.DaysOfWeek Friday { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.DaysOfWeek Monday { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.DaysOfWeek Saturday { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.DaysOfWeek Sunday { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.DaysOfWeek Thursday { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.DaysOfWeek Tuesday { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.DaysOfWeek Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.DaysOfWeek other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.DaysOfWeek left, Azure.ResourceManager.CostManagement.Models.DaysOfWeek right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.DaysOfWeek (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.DaysOfWeek left, Azure.ResourceManager.CostManagement.Models.DaysOfWeek right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DownloadURL
    {
        internal DownloadURL() { }
        public System.Uri DownloadUri { get { throw null; } }
        public System.DateTimeOffset? ExpiryOn { get { throw null; } }
        public System.DateTimeOffset? ValidTill { get { throw null; } }
    }
    public partial class ErrorDetails
    {
        public ErrorDetails() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExecutionStatus : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ExecutionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExecutionStatus(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ExecutionStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ExecutionStatus DataNotAvailable { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ExecutionStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ExecutionStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ExecutionStatus NewDataNotAvailable { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ExecutionStatus Queued { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ExecutionStatus Timeout { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ExecutionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ExecutionStatus left, Azure.ResourceManager.CostManagement.Models.ExecutionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ExecutionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ExecutionStatus left, Azure.ResourceManager.CostManagement.Models.ExecutionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExecutionType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ExecutionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExecutionType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ExecutionType OnDemand { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ExecutionType Scheduled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ExecutionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ExecutionType left, Azure.ResourceManager.CostManagement.Models.ExecutionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ExecutionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ExecutionType left, Azure.ResourceManager.CostManagement.Models.ExecutionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExportDataset
    {
        public ExportDataset() { }
        public System.Collections.Generic.IList<string> Columns { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.GranularityType? Granularity { get { throw null; } set { } }
    }
    public partial class ExportDefinition
    {
        public ExportDefinition(Azure.ResourceManager.CostManagement.Models.ExportType exportType, Azure.ResourceManager.CostManagement.Models.TimeframeType timeframe) { }
        public Azure.ResourceManager.CostManagement.Models.ExportDataset DataSet { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ExportType ExportType { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.TimeframeType Timeframe { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ExportTimePeriod TimePeriod { get { throw null; } set { } }
    }
    public partial class ExportDeliveryDestination
    {
        public ExportDeliveryDestination(string container) { }
        public string Container { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public string RootFolderPath { get { throw null; } set { } }
        public string SasToken { get { throw null; } set { } }
        public string StorageAccount { get { throw null; } set { } }
    }
    public partial class ExportDeliveryInfo
    {
        public ExportDeliveryInfo(Azure.ResourceManager.CostManagement.Models.ExportDeliveryDestination destination) { }
        public Azure.ResourceManager.CostManagement.Models.ExportDeliveryDestination Destination { get { throw null; } set { } }
    }
    public partial class ExportRecurrencePeriod
    {
        public ExportRecurrencePeriod(System.DateTimeOffset from) { }
        public System.DateTimeOffset From { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
    }
    public partial class ExportRun : Azure.ResourceManager.Models.ResourceData
    {
        public ExportRun() { }
        public Azure.ResourceManager.CostManagement.Models.ErrorDetails Error { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ExecutionType? ExecutionType { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public System.DateTimeOffset? ProcessingEndOn { get { throw null; } set { } }
        public System.DateTimeOffset? ProcessingStartOn { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.CommonExportProperties RunSettings { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ExecutionStatus? Status { get { throw null; } set { } }
        public string SubmittedBy { get { throw null; } set { } }
        public System.DateTimeOffset? SubmittedOn { get { throw null; } set { } }
    }
    public partial class ExportSchedule
    {
        public ExportSchedule() { }
        public Azure.ResourceManager.CostManagement.Models.RecurrenceType? Recurrence { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ExportRecurrencePeriod RecurrencePeriod { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.StatusType? Status { get { throw null; } set { } }
    }
    public partial class ExportTimePeriod
    {
        public ExportTimePeriod(System.DateTimeOffset from, System.DateTimeOffset to) { }
        public System.DateTimeOffset From { get { throw null; } set { } }
        public System.DateTimeOffset To { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExportType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ExportType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExportType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ExportType ActualCost { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ExportType AmortizedCost { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ExportType Usage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ExportType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ExportType left, Azure.ResourceManager.CostManagement.Models.ExportType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ExportType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ExportType left, Azure.ResourceManager.CostManagement.Models.ExportType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileFormat : System.IEquatable<Azure.ResourceManager.CostManagement.Models.FileFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileFormat(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.FileFormat Csv { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.FileFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.FileFormat left, Azure.ResourceManager.CostManagement.Models.FileFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.FileFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.FileFormat left, Azure.ResourceManager.CostManagement.Models.FileFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FormatType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.FormatType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FormatType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.FormatType Csv { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.FormatType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.FormatType left, Azure.ResourceManager.CostManagement.Models.FormatType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.FormatType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.FormatType left, Azure.ResourceManager.CostManagement.Models.FormatType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FunctionType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.FunctionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FunctionType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.FunctionType Sum { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.FunctionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.FunctionType left, Azure.ResourceManager.CostManagement.Models.FunctionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.FunctionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.FunctionType left, Azure.ResourceManager.CostManagement.Models.FunctionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GrainParameter : System.IEquatable<Azure.ResourceManager.CostManagement.Models.GrainParameter>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GrainParameter(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.GrainParameter Daily { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.GrainParameter Hourly { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.GrainParameter Monthly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.GrainParameter other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.GrainParameter left, Azure.ResourceManager.CostManagement.Models.GrainParameter right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.GrainParameter (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.GrainParameter left, Azure.ResourceManager.CostManagement.Models.GrainParameter right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GranularityType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.GranularityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GranularityType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.GranularityType Daily { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.GranularityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.GranularityType left, Azure.ResourceManager.CostManagement.Models.GranularityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.GranularityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.GranularityType left, Azure.ResourceManager.CostManagement.Models.GranularityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IncludedQuantityUtilizationSummary : Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary
    {
        public IncludedQuantityUtilizationSummary() { }
        public string ArmSkuName { get { throw null; } }
        public string BenefitId { get { throw null; } }
        public string BenefitOrderId { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.BenefitKind? BenefitType { get { throw null; } set { } }
        public System.DateTimeOffset? UsageOn { get { throw null; } }
        public decimal? UtilizationPercentage { get { throw null; } }
    }
    public partial class KpiProperties
    {
        public KpiProperties() { }
        public bool? Enabled { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.KpiType? KpiType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KpiType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.KpiType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KpiType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.KpiType Budget { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.KpiType Forecast { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.KpiType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.KpiType left, Azure.ResourceManager.CostManagement.Models.KpiType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.KpiType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.KpiType left, Azure.ResourceManager.CostManagement.Models.KpiType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MetricType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.MetricType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MetricType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.MetricType ActualCost { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.MetricType Ahub { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.MetricType AmortizedCost { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.MetricType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.MetricType left, Azure.ResourceManager.CostManagement.Models.MetricType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.MetricType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.MetricType left, Azure.ResourceManager.CostManagement.Models.MetricType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NotificationProperties
    {
        public NotificationProperties(System.Collections.Generic.IEnumerable<string> to, string subject) { }
        public string Language { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public string RegionalFormat { get { throw null; } set { } }
        public string Subject { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> To { get { throw null; } }
    }
    public partial class OperationStatus
    {
        internal OperationStatus() { }
        public Azure.ResourceManager.CostManagement.Models.ReservationReportSchema? ReportUri { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.OperationStatusType? Status { get { throw null; } }
        public System.DateTimeOffset? ValidUntil { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationStatusType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.OperationStatusType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationStatusType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.OperationStatusType Completed { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.OperationStatusType Failed { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.OperationStatusType Running { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.OperationStatusType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.OperationStatusType left, Azure.ResourceManager.CostManagement.Models.OperationStatusType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.OperationStatusType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.OperationStatusType left, Azure.ResourceManager.CostManagement.Models.OperationStatusType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperatorType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.OperatorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperatorType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.OperatorType Contains { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.OperatorType In { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.OperatorType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.OperatorType left, Azure.ResourceManager.CostManagement.Models.OperatorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.OperatorType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.OperatorType left, Azure.ResourceManager.CostManagement.Models.OperatorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PivotProperties
    {
        public PivotProperties() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.PivotType? PivotType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PivotType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.PivotType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PivotType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.PivotType Dimension { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.PivotType TagKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.PivotType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.PivotType left, Azure.ResourceManager.CostManagement.Models.PivotType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.PivotType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.PivotType left, Azure.ResourceManager.CostManagement.Models.PivotType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QueryColumnType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.QueryColumnType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QueryColumnType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.QueryColumnType Dimension { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.QueryColumnType TagKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.QueryColumnType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.QueryColumnType left, Azure.ResourceManager.CostManagement.Models.QueryColumnType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.QueryColumnType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.QueryColumnType left, Azure.ResourceManager.CostManagement.Models.QueryColumnType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecurrenceType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.RecurrenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecurrenceType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.RecurrenceType Annually { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.RecurrenceType Daily { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.RecurrenceType Monthly { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.RecurrenceType Weekly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.RecurrenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.RecurrenceType left, Azure.ResourceManager.CostManagement.Models.RecurrenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.RecurrenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.RecurrenceType left, Azure.ResourceManager.CostManagement.Models.RecurrenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReportConfigAggregation
    {
        public ReportConfigAggregation(string name, Azure.ResourceManager.CostManagement.Models.FunctionType function) { }
        public Azure.ResourceManager.CostManagement.Models.FunctionType Function { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class ReportConfigComparisonExpression
    {
        public ReportConfigComparisonExpression(string name, Azure.ResourceManager.CostManagement.Models.OperatorType @operator, System.Collections.Generic.IEnumerable<string> values) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.OperatorType Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
    }
    public partial class ReportConfigDataset
    {
        public ReportConfigDataset() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.CostManagement.Models.ReportConfigAggregation> Aggregation { get { throw null; } }
        public System.Collections.Generic.IList<string> Columns { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.ReportConfigFilter Filter { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ReportGranularityType? Granularity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CostManagement.Models.ReportConfigGrouping> Grouping { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CostManagement.Models.ReportConfigSorting> Sorting { get { throw null; } }
    }
    public partial class ReportConfigFilter
    {
        public ReportConfigFilter() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CostManagement.Models.ReportConfigFilter> And { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.ReportConfigComparisonExpression Dimensions { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CostManagement.Models.ReportConfigFilter> Or { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.ReportConfigComparisonExpression Tags { get { throw null; } set { } }
    }
    public partial class ReportConfigGrouping
    {
        public ReportConfigGrouping(Azure.ResourceManager.CostManagement.Models.QueryColumnType queryColumnType, string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.QueryColumnType QueryColumnType { get { throw null; } set { } }
    }
    public partial class ReportConfigSorting
    {
        public ReportConfigSorting(string name) { }
        public Azure.ResourceManager.CostManagement.Models.ReportConfigSortingType? Direction { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReportConfigSortingType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ReportConfigSortingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReportConfigSortingType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ReportConfigSortingType Ascending { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReportConfigSortingType Descending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ReportConfigSortingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ReportConfigSortingType left, Azure.ResourceManager.CostManagement.Models.ReportConfigSortingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ReportConfigSortingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ReportConfigSortingType left, Azure.ResourceManager.CostManagement.Models.ReportConfigSortingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReportConfigTimePeriod
    {
        public ReportConfigTimePeriod(System.DateTimeOffset from, System.DateTimeOffset to) { }
        public System.DateTimeOffset From { get { throw null; } set { } }
        public System.DateTimeOffset To { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReportGranularityType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ReportGranularityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReportGranularityType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ReportGranularityType Daily { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReportGranularityType Monthly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ReportGranularityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ReportGranularityType left, Azure.ResourceManager.CostManagement.Models.ReportGranularityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ReportGranularityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ReportGranularityType left, Azure.ResourceManager.CostManagement.Models.ReportGranularityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReportTimeframeType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ReportTimeframeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReportTimeframeType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ReportTimeframeType Custom { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReportTimeframeType MonthToDate { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReportTimeframeType WeekToDate { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReportTimeframeType YearToDate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ReportTimeframeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ReportTimeframeType left, Azure.ResourceManager.CostManagement.Models.ReportTimeframeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ReportTimeframeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ReportTimeframeType left, Azure.ResourceManager.CostManagement.Models.ReportTimeframeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReportType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ReportType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReportType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ReportType Usage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ReportType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ReportType left, Azure.ResourceManager.CostManagement.Models.ReportType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ReportType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ReportType left, Azure.ResourceManager.CostManagement.Models.ReportType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReservationReportSchema : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ReservationReportSchema>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReservationReportSchema(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ReservationReportSchema InstanceFlexibilityGroup { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReservationReportSchema InstanceFlexibilityRatio { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReservationReportSchema InstanceId { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReservationReportSchema Kind { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReservationReportSchema ReservationId { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReservationReportSchema ReservationOrderId { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReservationReportSchema ReservedHours { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReservationReportSchema SkuName { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReservationReportSchema TotalReservedQuantity { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReservationReportSchema UsageDate { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReservationReportSchema UsedHours { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ReservationReportSchema other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ReservationReportSchema left, Azure.ResourceManager.CostManagement.Models.ReservationReportSchema right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ReservationReportSchema (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ReservationReportSchema left, Azure.ResourceManager.CostManagement.Models.ReservationReportSchema right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SavingsPlanUtilizationSummary : Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary
    {
        public SavingsPlanUtilizationSummary() { }
        public string ArmSkuName { get { throw null; } }
        public decimal? AvgUtilizationPercentage { get { throw null; } }
        public string BenefitId { get { throw null; } }
        public string BenefitOrderId { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.BenefitKind? BenefitType { get { throw null; } set { } }
        public decimal? MaxUtilizationPercentage { get { throw null; } }
        public decimal? MinUtilizationPercentage { get { throw null; } }
        public System.DateTimeOffset? UsageOn { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduledActionKind : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ScheduledActionKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduledActionKind(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ScheduledActionKind Email { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ScheduledActionKind InsightAlert { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ScheduledActionKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ScheduledActionKind left, Azure.ResourceManager.CostManagement.Models.ScheduledActionKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ScheduledActionKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ScheduledActionKind left, Azure.ResourceManager.CostManagement.Models.ScheduledActionKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduledActionStatus : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ScheduledActionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduledActionStatus(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ScheduledActionStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ScheduledActionStatus Enabled { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ScheduledActionStatus Expired { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ScheduledActionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ScheduledActionStatus left, Azure.ResourceManager.CostManagement.Models.ScheduledActionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ScheduledActionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ScheduledActionStatus left, Azure.ResourceManager.CostManagement.Models.ScheduledActionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduleFrequency : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ScheduleFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduleFrequency(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ScheduleFrequency Daily { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ScheduleFrequency Monthly { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ScheduleFrequency Weekly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ScheduleFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ScheduleFrequency left, Azure.ResourceManager.CostManagement.Models.ScheduleFrequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ScheduleFrequency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ScheduleFrequency left, Azure.ResourceManager.CostManagement.Models.ScheduleFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScheduleProperties
    {
        public ScheduleProperties(Azure.ResourceManager.CostManagement.Models.ScheduleFrequency frequency, System.DateTimeOffset startOn, System.DateTimeOffset endOn) { }
        public int? DayOfMonth { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CostManagement.Models.DaysOfWeek> DaysOfWeek { get { throw null; } }
        public System.DateTimeOffset EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ScheduleFrequency Frequency { get { throw null; } set { } }
        public int? HourOfDay { get { throw null; } set { } }
        public System.DateTimeOffset StartOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CostManagement.Models.WeeksOfMonth> WeeksOfMonth { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StatusType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.StatusType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StatusType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.StatusType Active { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.StatusType Inactive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.StatusType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.StatusType left, Azure.ResourceManager.CostManagement.Models.StatusType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.StatusType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.StatusType left, Azure.ResourceManager.CostManagement.Models.StatusType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TimeframeType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.TimeframeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TimeframeType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.TimeframeType BillingMonthToDate { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.TimeframeType Custom { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.TimeframeType MonthToDate { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.TimeframeType TheLastBillingMonth { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.TimeframeType TheLastMonth { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.TimeframeType WeekToDate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.TimeframeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.TimeframeType left, Azure.ResourceManager.CostManagement.Models.TimeframeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.TimeframeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.TimeframeType left, Azure.ResourceManager.CostManagement.Models.TimeframeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WeeksOfMonth : System.IEquatable<Azure.ResourceManager.CostManagement.Models.WeeksOfMonth>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WeeksOfMonth(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.WeeksOfMonth First { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.WeeksOfMonth Fourth { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.WeeksOfMonth Last { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.WeeksOfMonth Second { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.WeeksOfMonth Third { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.WeeksOfMonth other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.WeeksOfMonth left, Azure.ResourceManager.CostManagement.Models.WeeksOfMonth right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.WeeksOfMonth (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.WeeksOfMonth left, Azure.ResourceManager.CostManagement.Models.WeeksOfMonth right) { throw null; }
        public override string ToString() { throw null; }
    }
}
