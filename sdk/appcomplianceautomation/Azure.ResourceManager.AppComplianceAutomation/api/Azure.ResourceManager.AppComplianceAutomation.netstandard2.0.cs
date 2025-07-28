namespace Azure.ResourceManager.AppComplianceAutomation
{
    public static partial class AppComplianceAutomationExtensions
    {
        public static Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameAvailabilityResult> CheckAppComplianceReportNameAvailability(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameAvailabilityResult>> CheckAppComplianceReportNameAvailabilityAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportResource> GetAppComplianceReport(this Azure.ResourceManager.Resources.TenantResource tenantResource, string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportResource>> GetAppComplianceReportAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceResource GetAppComplianceReportEvidenceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportResource GetAppComplianceReportResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportCollection GetAppComplianceReports(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationResource GetAppComplianceReportScopingConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotResource GetAppComplianceReportSnapshotResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookResource GetAppComplianceReportWebhookResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.ReportCollectionGetCountResult> GetCollectionCountProviderAction(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AppComplianceAutomation.Models.ReportCollectionGetCountContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.ReportCollectionGetCountResult>> GetCollectionCountProviderActionAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AppComplianceAutomation.Models.ReportCollectionGetCountContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.ReportListInUseStorageAccountsResult> GetInUseStorageAccountsProviderAction(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AppComplianceAutomation.Models.ReportListInUseStorageAccountsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.ReportListInUseStorageAccountsResult>> GetInUseStorageAccountsProviderActionAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AppComplianceAutomation.Models.ReportListInUseStorageAccountsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceGetOverviewStatusResult> GetOverviewStatusProviderAction(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceGetOverviewStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceGetOverviewStatusResult>> GetOverviewStatusProviderActionAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceGetOverviewStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceOnboardResult> OnboardProviderAction(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceOnboardContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceOnboardResult>> OnboardProviderActionAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceOnboardContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationResult> TriggerEvaluationProviderAction(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationResult>> TriggerEvaluationProviderActionAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppComplianceReportCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportResource>, System.Collections.IEnumerable
    {
        protected AppComplianceReportCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string reportName, Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string reportName, Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportResource> Get(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportResource> GetAll(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportResource> GetAllAsync(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportResource>> GetAsync(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportResource> GetIfExists(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportResource>> GetIfExistsAsync(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppComplianceReportData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportData>
    {
        public AppComplianceReportData(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportProperties properties) { }
        public Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppComplianceReportEvidenceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceResource>, System.Collections.IEnumerable
    {
        protected AppComplianceReportEvidenceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string evidenceName, Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceData data, string offerGuid = null, string reportCreatorTenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string evidenceName, Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceData data, string offerGuid = null, string reportCreatorTenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string evidenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string evidenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceResource> Get(string evidenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceResource> GetAll(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportEvidenceCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceResource> GetAllAsync(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportEvidenceCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceResource>> GetAsync(string evidenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceResource> GetIfExists(string evidenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceResource>> GetIfExistsAsync(string evidenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppComplianceReportEvidenceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceData>
    {
        public AppComplianceReportEvidenceData(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportEvidenceProperties properties) { }
        public Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportEvidenceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppComplianceReportEvidenceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppComplianceReportEvidenceResource() { }
        public virtual Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string reportName, string evidenceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadResult> Download(Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadResult>> DownloadAsync(Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceData data, string offerGuid = null, string reportCreatorTenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceData data, string offerGuid = null, string reportCreatorTenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppComplianceReportResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppComplianceReportResource() { }
        public virtual Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameAvailabilityResult> CheckAppComplianceReportNestedResourceNameAvailability(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameAvailabilityResult>> CheckAppComplianceReportNestedResourceNameAvailabilityAsync(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string reportName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.Models.ReportFixResult> Fix(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.Models.ReportFixResult>> FixAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceResource> GetAppComplianceReportEvidence(string evidenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceResource>> GetAppComplianceReportEvidenceAsync(string evidenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceCollection GetAppComplianceReportEvidences() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationResource> GetAppComplianceReportScopingConfiguration(string scopingConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationResource>> GetAppComplianceReportScopingConfigurationAsync(string scopingConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationCollection GetAppComplianceReportScopingConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotResource> GetAppComplianceReportSnapshot(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotResource>> GetAppComplianceReportSnapshotAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotCollection GetAppComplianceReportSnapshots() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookResource> GetAppComplianceReportWebhook(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookResource>> GetAppComplianceReportWebhookAsync(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookCollection GetAppComplianceReportWebhooks() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestions> GetScopingQuestions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestions>> GetScopingQuestionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordResult> SyncCertRecord(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordResult>> SyncCertRecordAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.Models.ReportVerificationResult> Verify(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.Models.ReportVerificationResult>> VerifyAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppComplianceReportScopingConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationResource>, System.Collections.IEnumerable
    {
        protected AppComplianceReportScopingConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string scopingConfigurationName, Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scopingConfigurationName, Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scopingConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scopingConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationResource> Get(string scopingConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationResource>> GetAsync(string scopingConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationResource> GetIfExists(string scopingConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationResource>> GetIfExistsAsync(string scopingConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppComplianceReportScopingConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationData>
    {
        public AppComplianceReportScopingConfigurationData(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportScopingConfigurationProperties properties) { }
        public Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportScopingConfigurationProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppComplianceReportScopingConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppComplianceReportScopingConfigurationResource() { }
        public virtual Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string reportName, string scopingConfigurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppComplianceReportSnapshotCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotResource>, System.Collections.IEnumerable
    {
        protected AppComplianceReportSnapshotCollection() { }
        public virtual Azure.Response<bool> Exists(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotResource> Get(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotResource> GetAll(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportSnapshotCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotResource> GetAllAsync(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportSnapshotCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotResource>> GetAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotResource> GetIfExists(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotResource>> GetIfExistsAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppComplianceReportSnapshotData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotData>
    {
        public AppComplianceReportSnapshotData() { }
        public Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportSnapshotProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppComplianceReportSnapshotResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppComplianceReportSnapshotResource() { }
        public virtual Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string reportName, string snapshotName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceDownloadResult> Download(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotDownloadRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceDownloadResult>> DownloadAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotDownloadRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppComplianceReportWebhookCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookResource>, System.Collections.IEnumerable
    {
        protected AppComplianceReportWebhookCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string webhookName, Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string webhookName, Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookResource> Get(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookResource> GetAll(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportWebhookCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookResource> GetAllAsync(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportWebhookCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookResource>> GetAsync(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookResource> GetIfExists(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookResource>> GetIfExistsAsync(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppComplianceReportWebhookData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookData>
    {
        public AppComplianceReportWebhookData(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportWebhookProperties properties) { }
        public Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportWebhookProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppComplianceReportWebhookResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppComplianceReportWebhookResource() { }
        public virtual Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string reportName, string webhookName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookResource> Update(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportWebhookPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookResource>> UpdateAsync(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportWebhookPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerAppComplianceAutomationContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerAppComplianceAutomationContext() { }
        public static Azure.ResourceManager.AppComplianceAutomation.AzureResourceManagerAppComplianceAutomationContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
}
namespace Azure.ResourceManager.AppComplianceAutomation.Mocking
{
    public partial class MockableAppComplianceAutomationArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableAppComplianceAutomationArmClient() { }
        public virtual Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceResource GetAppComplianceReportEvidenceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportResource GetAppComplianceReportResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationResource GetAppComplianceReportScopingConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotResource GetAppComplianceReportSnapshotResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookResource GetAppComplianceReportWebhookResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableAppComplianceAutomationTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAppComplianceAutomationTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameAvailabilityResult> CheckAppComplianceReportNameAvailability(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameAvailabilityResult>> CheckAppComplianceReportNameAvailabilityAsync(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportResource> GetAppComplianceReport(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportResource>> GetAppComplianceReportAsync(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportCollection GetAppComplianceReports() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.ReportCollectionGetCountResult> GetCollectionCountProviderAction(Azure.ResourceManager.AppComplianceAutomation.Models.ReportCollectionGetCountContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.ReportCollectionGetCountResult>> GetCollectionCountProviderActionAsync(Azure.ResourceManager.AppComplianceAutomation.Models.ReportCollectionGetCountContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.ReportListInUseStorageAccountsResult> GetInUseStorageAccountsProviderAction(Azure.ResourceManager.AppComplianceAutomation.Models.ReportListInUseStorageAccountsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.ReportListInUseStorageAccountsResult>> GetInUseStorageAccountsProviderActionAsync(Azure.ResourceManager.AppComplianceAutomation.Models.ReportListInUseStorageAccountsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceGetOverviewStatusResult> GetOverviewStatusProviderAction(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceGetOverviewStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceGetOverviewStatusResult>> GetOverviewStatusProviderActionAsync(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceGetOverviewStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceOnboardResult> OnboardProviderAction(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceOnboardContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceOnboardResult>> OnboardProviderActionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceOnboardContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationResult> TriggerEvaluationProviderAction(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationResult>> TriggerEvaluationProviderActionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.AppComplianceAutomation.Models
{
    public partial class AppComplianceCategory : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceCategory>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceCategory>
    {
        internal AppComplianceCategory() { }
        public string CategoryName { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceCategoryStatus? CategoryStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControlFamily> ControlFamilies { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceCategory System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceCategory>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceCategory>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceCategory System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceCategory>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceCategory>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceCategory>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppComplianceCategoryStatus : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceCategoryStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppComplianceCategoryStatus(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceCategoryStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceCategoryStatus NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceCategoryStatus Passed { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceCategoryStatus PendingApproval { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceCategoryStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceCategoryStatus left, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceCategoryStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceCategoryStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceCategoryStatus left, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceCategoryStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppComplianceControl : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControl>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControl>
    {
        internal AppComplianceControl() { }
        public string ControlDescription { get { throw null; } }
        public System.Uri ControlDescriptionHyperLink { get { throw null; } }
        public string ControlFullName { get { throw null; } }
        public string ControlId { get { throw null; } }
        public string ControlName { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControlStatus? ControlStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.CustomerResponsibility> Responsibilities { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControl System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControl>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControl>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControl System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControl>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControl>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControl>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppComplianceControlFamily : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControlFamily>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControlFamily>
    {
        internal AppComplianceControlFamily() { }
        public string ControlFamilyName { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyStatus? ControlFamilyStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControl> Controls { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControlFamily System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControlFamily>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControlFamily>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControlFamily System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControlFamily>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControlFamily>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControlFamily>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppComplianceControlStatus : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControlStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppComplianceControlStatus(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControlStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControlStatus NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControlStatus Passed { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControlStatus PendingApproval { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControlStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControlStatus left, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControlStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControlStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControlStatus left, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControlStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppComplianceDownloadResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceDownloadResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceDownloadResult>
    {
        internal AppComplianceDownloadResult() { }
        public System.Uri ComplianceDetailedPdfReportSasUri { get { throw null; } }
        public System.Uri CompliancePdfReportSasUri { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportItem> ComplianceReport { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceItem> ResourceList { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceDownloadResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceDownloadResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceDownloadResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceDownloadResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceDownloadResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceDownloadResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceDownloadResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppComplianceDownloadType : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceDownloadType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppComplianceDownloadType(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceDownloadType ComplianceDetailedPdfReport { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceDownloadType CompliancePdfReport { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceDownloadType ComplianceReport { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceDownloadType ResourceList { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceDownloadType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceDownloadType left, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceDownloadType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceDownloadType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceDownloadType left, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceDownloadType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppComplianceGetOverviewStatusContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceGetOverviewStatusContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceGetOverviewStatusContent>
    {
        public AppComplianceGetOverviewStatusContent() { }
        public string GetOverviewStatusRequestType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceGetOverviewStatusContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceGetOverviewStatusContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceGetOverviewStatusContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceGetOverviewStatusContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceGetOverviewStatusContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceGetOverviewStatusContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceGetOverviewStatusContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppComplianceGetOverviewStatusResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceGetOverviewStatusResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceGetOverviewStatusResult>
    {
        internal AppComplianceGetOverviewStatusResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.OverviewStatusItem> StatusList { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceGetOverviewStatusResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceGetOverviewStatusResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceGetOverviewStatusResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceGetOverviewStatusResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceGetOverviewStatusResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceGetOverviewStatusResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceGetOverviewStatusResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppComplianceOnboardContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceOnboardContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceOnboardContent>
    {
        public AppComplianceOnboardContent(System.Collections.Generic.IEnumerable<string> subscriptionIds) { }
        public System.Collections.Generic.IList<string> SubscriptionIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceOnboardContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceOnboardContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceOnboardContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceOnboardContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceOnboardContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceOnboardContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceOnboardContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppComplianceOnboardResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceOnboardResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceOnboardResult>
    {
        internal AppComplianceOnboardResult() { }
        public System.Collections.Generic.IReadOnlyList<string> SubscriptionIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceOnboardResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceOnboardResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceOnboardResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceOnboardResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceOnboardResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceOnboardResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceOnboardResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppComplianceProvisioningState : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppComplianceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceProvisioningState Fixing { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceProvisioningState Updating { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceProvisioningState Verifying { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceProvisioningState left, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceProvisioningState left, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppComplianceReportCollectionGetAllOptions
    {
        public AppComplianceReportCollectionGetAllOptions() { }
        public string Filter { get { throw null; } set { } }
        public string OfferGuid { get { throw null; } set { } }
        public string Orderby { get { throw null; } set { } }
        public string ReportCreatorTenantId { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
    }
    public partial class AppComplianceReportEvidenceCollectionGetAllOptions
    {
        public AppComplianceReportEvidenceCollectionGetAllOptions() { }
        public string Filter { get { throw null; } set { } }
        public string OfferGuid { get { throw null; } set { } }
        public string Orderby { get { throw null; } set { } }
        public string ReportCreatorTenantId { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
    }
    public partial class AppComplianceReportEvidenceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportEvidenceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportEvidenceProperties>
    {
        public AppComplianceReportEvidenceProperties(string filePath) { }
        public string ControlId { get { throw null; } set { } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportEvidenceType? EvidenceType { get { throw null; } set { } }
        public string ExtraData { get { throw null; } set { } }
        public string FilePath { get { throw null; } set { } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceProvisioningState? ProvisioningState { get { throw null; } }
        public string ResponsibilityId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportEvidenceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportEvidenceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportEvidenceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportEvidenceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportEvidenceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportEvidenceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportEvidenceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppComplianceReportEvidenceType : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportEvidenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppComplianceReportEvidenceType(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportEvidenceType AutoCollectedEvidence { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportEvidenceType Data { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportEvidenceType File { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportEvidenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportEvidenceType left, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportEvidenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportEvidenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportEvidenceType left, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportEvidenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppComplianceReportItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportItem>
    {
        internal AppComplianceReportItem() { }
        public string CategoryName { get { throw null; } }
        public string ControlFamilyName { get { throw null; } }
        public string ControlId { get { throw null; } }
        public string ControlName { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControlStatus? ControlStatus { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceOrigin? ResourceOrigin { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceStatus? ResourceStatus { get { throw null; } }
        public System.DateTimeOffset? ResourceStatusChangedOn { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public string ResponsibilityDescription { get { throw null; } }
        public string ResponsibilityTitle { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppComplianceReportNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameAvailabilityContent>
    {
        public AppComplianceReportNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppComplianceReportNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameAvailabilityResult>
    {
        internal AppComplianceReportNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameUnavailabilityReason? Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppComplianceReportNameUnavailabilityReason : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameUnavailabilityReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppComplianceReportNameUnavailabilityReason(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameUnavailabilityReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameUnavailabilityReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameUnavailabilityReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameUnavailabilityReason left, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameUnavailabilityReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameUnavailabilityReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameUnavailabilityReason left, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameUnavailabilityReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppComplianceReportPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportPatch>
    {
        public AppComplianceReportPatch() { }
        public Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportPatchProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppComplianceReportPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportPatchProperties>
    {
        public AppComplianceReportPatchProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord> CertRecords { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ReportOverviewStatus ComplianceStatusM365 { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Errors { get { throw null; } }
        public System.DateTimeOffset? LastTriggerOn { get { throw null; } }
        public System.DateTimeOffset? NextTriggerOn { get { throw null; } }
        public string OfferGuid { get { throw null; } set { } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceMetadata> Resources { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportStatus? Status { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ReportStorageInfo StorageInfo { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> Subscriptions { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
        public System.DateTimeOffset? TriggerOn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppComplianceReportProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportProperties>
    {
        public AppComplianceReportProperties(System.DateTimeOffset triggerOn, string timeZone, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceMetadata> resources) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord> CertRecords { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ReportOverviewStatus ComplianceStatusM365 { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Errors { get { throw null; } }
        public System.DateTimeOffset? LastTriggerOn { get { throw null; } }
        public System.DateTimeOffset? NextTriggerOn { get { throw null; } }
        public string OfferGuid { get { throw null; } set { } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceMetadata> Resources { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportStatus? Status { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ReportStorageInfo StorageInfo { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> Subscriptions { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
        public System.DateTimeOffset TriggerOn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppComplianceReportScopingConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportScopingConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportScopingConfigurationProperties>
    {
        public AppComplianceReportScopingConfigurationProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingAnswer> Answers { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportScopingConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportScopingConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportScopingConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportScopingConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportScopingConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportScopingConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportScopingConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppComplianceReportSnapshotCollectionGetAllOptions
    {
        public AppComplianceReportSnapshotCollectionGetAllOptions() { }
        public string Filter { get { throw null; } set { } }
        public string OfferGuid { get { throw null; } set { } }
        public string Orderby { get { throw null; } set { } }
        public string ReportCreatorTenantId { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
    }
    public partial class AppComplianceReportSnapshotProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportSnapshotProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportSnapshotProperties>
    {
        public AppComplianceReportSnapshotProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceResult> ComplianceResults { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportProperties ReportProperties { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData ReportSystemData { get { throw null; } }
        public string SnapshotName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportSnapshotProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportSnapshotProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportSnapshotProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportSnapshotProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportSnapshotProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportSnapshotProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportSnapshotProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppComplianceReportStatus : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppComplianceReportStatus(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportStatus Active { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportStatus Reviewing { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportStatus left, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportStatus left, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppComplianceReportWebhookCollectionGetAllOptions
    {
        public AppComplianceReportWebhookCollectionGetAllOptions() { }
        public string Filter { get { throw null; } set { } }
        public string OfferGuid { get { throw null; } set { } }
        public string Orderby { get { throw null; } set { } }
        public string ReportCreatorTenantId { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
    }
    public partial class AppComplianceReportWebhookPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportWebhookPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportWebhookPatch>
    {
        public AppComplianceReportWebhookPatch() { }
        public Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportWebhookProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportWebhookPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportWebhookPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportWebhookPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportWebhookPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportWebhookPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportWebhookPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportWebhookPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppComplianceReportWebhookProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportWebhookProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportWebhookProperties>
    {
        public AppComplianceReportWebhookProperties() { }
        public Azure.ResourceManager.AppComplianceAutomation.Models.WebhookContentType? ContentType { get { throw null; } set { } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.WebhookDeliveryStatus? DeliveryStatus { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.EnableSslVerification? EnableSslVerification { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppComplianceAutomation.Models.WebhookNotificationEvent> Events { get { throw null; } }
        public System.Uri PayloadUri { get { throw null; } set { } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.SendAllEvent? SendAllEvents { get { throw null; } set { } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.WebhookStatus? Status { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.UpdateWebhookKey? UpdateWebhookKey { get { throw null; } set { } }
        public string WebhookId { get { throw null; } }
        public string WebhookKey { get { throw null; } set { } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.WebhookKeyEnabled? WebhookKeyEnabled { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportWebhookProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportWebhookProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportWebhookProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportWebhookProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportWebhookProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportWebhookProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportWebhookProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppComplianceResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceResult>
    {
        internal AppComplianceResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceCategory> Categories { get { throw null; } }
        public string ComplianceName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmAppComplianceAutomationModelFactory
    {
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceCategory AppComplianceCategory(string categoryName = null, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceCategoryStatus? categoryStatus = default(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceCategoryStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControlFamily> controlFamilies = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControl AppComplianceControl(string controlId = null, string controlName = null, string controlFullName = null, string controlDescription = null, System.Uri controlDescriptionHyperLink = null, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControlStatus? controlStatus = default(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControlStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.CustomerResponsibility> responsibilities = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControlFamily AppComplianceControlFamily(string controlFamilyName = null, Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyStatus? controlFamilyStatus = default(Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControl> controls = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceDownloadResult AppComplianceDownloadResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceItem> resourceList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportItem> complianceReport = null, System.Uri compliancePdfReportSasUri = null, System.Uri complianceDetailedPdfReportSasUri = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceGetOverviewStatusResult AppComplianceGetOverviewStatusResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.OverviewStatusItem> statusList = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceOnboardResult AppComplianceOnboardResult(System.Collections.Generic.IEnumerable<string> subscriptionIds = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportData AppComplianceReportData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportProperties properties = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportEvidenceData AppComplianceReportEvidenceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportEvidenceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportEvidenceProperties AppComplianceReportEvidenceProperties(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportEvidenceType? evidenceType = default(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportEvidenceType?), string filePath = null, string extraData = null, string controlId = null, string responsibilityId = null, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceProvisioningState? provisioningState = default(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportItem AppComplianceReportItem(string categoryName = null, string controlFamilyName = null, string controlId = null, string controlName = null, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControlStatus? controlStatus = default(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceControlStatus?), string responsibilityTitle = null, string responsibilityDescription = null, Azure.Core.ResourceIdentifier resourceId = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceOrigin? resourceOrigin = default(Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceOrigin?), Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceStatus? resourceStatus = default(Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceStatus?), System.DateTimeOffset? resourceStatusChangedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameAvailabilityResult AppComplianceReportNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameUnavailabilityReason? reason = default(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportNameUnavailabilityReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportPatchProperties AppComplianceReportPatchProperties(System.DateTimeOffset? triggerOn = default(System.DateTimeOffset?), string timeZone = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceMetadata> resources = null, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportStatus? status = default(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportStatus?), System.Collections.Generic.IEnumerable<string> errors = null, System.Guid? tenantId = default(System.Guid?), string offerGuid = null, System.DateTimeOffset? nextTriggerOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastTriggerOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> subscriptions = null, Azure.ResourceManager.AppComplianceAutomation.Models.ReportOverviewStatus complianceStatusM365 = null, Azure.ResourceManager.AppComplianceAutomation.Models.ReportStorageInfo storageInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord> certRecords = null, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceProvisioningState? provisioningState = default(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportProperties AppComplianceReportProperties(System.DateTimeOffset triggerOn = default(System.DateTimeOffset), string timeZone = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceMetadata> resources = null, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportStatus? status = default(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportStatus?), System.Collections.Generic.IEnumerable<string> errors = null, System.Guid? tenantId = default(System.Guid?), string offerGuid = null, System.DateTimeOffset? nextTriggerOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastTriggerOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> subscriptions = null, Azure.ResourceManager.AppComplianceAutomation.Models.ReportOverviewStatus complianceStatusM365 = null, Azure.ResourceManager.AppComplianceAutomation.Models.ReportStorageInfo storageInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord> certRecords = null, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceProvisioningState? provisioningState = default(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportScopingConfigurationData AppComplianceReportScopingConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportScopingConfigurationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportScopingConfigurationProperties AppComplianceReportScopingConfigurationProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingAnswer> answers = null, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceProvisioningState? provisioningState = default(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportSnapshotData AppComplianceReportSnapshotData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportSnapshotProperties properties = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportSnapshotProperties AppComplianceReportSnapshotProperties(string snapshotName = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceProvisioningState? provisioningState = default(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceProvisioningState?), Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportProperties reportProperties = null, Azure.ResourceManager.Models.SystemData reportSystemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceResult> complianceResults = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.AppComplianceReportWebhookData AppComplianceReportWebhookData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportWebhookProperties properties = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportWebhookProperties AppComplianceReportWebhookProperties(string webhookId = null, Azure.ResourceManager.AppComplianceAutomation.Models.WebhookStatus? status = default(Azure.ResourceManager.AppComplianceAutomation.Models.WebhookStatus?), System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.AppComplianceAutomation.Models.SendAllEvent? sendAllEvents = default(Azure.ResourceManager.AppComplianceAutomation.Models.SendAllEvent?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.WebhookNotificationEvent> events = null, System.Uri payloadUri = null, Azure.ResourceManager.AppComplianceAutomation.Models.WebhookContentType? contentType = default(Azure.ResourceManager.AppComplianceAutomation.Models.WebhookContentType?), string webhookKey = null, Azure.ResourceManager.AppComplianceAutomation.Models.UpdateWebhookKey? updateWebhookKey = default(Azure.ResourceManager.AppComplianceAutomation.Models.UpdateWebhookKey?), Azure.ResourceManager.AppComplianceAutomation.Models.WebhookKeyEnabled? webhookKeyEnabled = default(Azure.ResourceManager.AppComplianceAutomation.Models.WebhookKeyEnabled?), Azure.ResourceManager.AppComplianceAutomation.Models.EnableSslVerification? enableSslVerification = default(Azure.ResourceManager.AppComplianceAutomation.Models.EnableSslVerification?), Azure.ResourceManager.AppComplianceAutomation.Models.WebhookDeliveryStatus? deliveryStatus = default(Azure.ResourceManager.AppComplianceAutomation.Models.WebhookDeliveryStatus?), Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceProvisioningState? provisioningState = default(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceResult AppComplianceResult(string complianceName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceCategory> categories = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.CustomerResponsibility CustomerResponsibility(string responsibilityId = null, string responsibilityTitle = null, string responsibilityDescription = null, Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityType? responsibilityType = default(Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityType?), Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilitySeverity? responsibilitySeverity = default(Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilitySeverity?), Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityStatus? responsibilityStatus = default(Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityStatus?), Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityEnvironment? responsibilityEnvironment = default(Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityEnvironment?), int? failedResourceCount = default(int?), int? totalResourceCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityResourceItem> resourceList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationDetails> recommendationList = null, string guidance = null, string justification = null, System.Collections.Generic.IEnumerable<string> evidenceFiles = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadResult EvidenceFileDownloadResult(System.Uri evidenceFileUri = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.OverviewStatusItem OverviewStatusItem(string statusName = null, string statusValue = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.QuickAssessment QuickAssessment(Azure.Core.ResourceIdentifier resourceId = null, string responsibilityId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceStatus? resourceStatus = default(Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceStatus?), string displayName = null, string description = null, string remediationLink = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationDetails RecommendationDetails(string recommendationId = null, string recommendationShortName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationSolution> recommendationSolutions = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationSolution RecommendationSolution(string recommendationSolutionIndex = null, string recommendationSolutionContent = null, Azure.ResourceManager.AppComplianceAutomation.Models.IsRecommendSolution? isRecommendSolution = default(Azure.ResourceManager.AppComplianceAutomation.Models.IsRecommendSolution?)) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ReportCollectionGetCountResult ReportCollectionGetCountResult(int? count = default(int?)) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ReportFixResult ReportFixResult(Azure.ResourceManager.AppComplianceAutomation.Models.ReportResult? result = default(Azure.ResourceManager.AppComplianceAutomation.Models.ReportResult?), string reason = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ReportListInUseStorageAccountsResult ReportListInUseStorageAccountsResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.ReportStorageInfo> storageAccountList = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ReportOverviewStatus ReportOverviewStatus(int? passedCount = default(int?), int? failedCount = default(int?), int? manualCount = default(int?), int? notApplicableCount = default(int?), int? pendingCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceItem ReportResourceItem(string subscriptionId = null, string resourceGroup = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), Azure.Core.ResourceIdentifier resourceId = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ReportVerificationResult ReportVerificationResult(Azure.ResourceManager.AppComplianceAutomation.Models.ReportResult? result = default(Azure.ResourceManager.AppComplianceAutomation.Models.ReportResult?), string reason = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityResourceItem ResponsibilityResourceItem(Azure.Core.ResourceIdentifier resourceId = null, string accountId = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceOrigin? resourceOrigin = default(Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceOrigin?), Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceStatus? resourceStatus = default(Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceStatus?), System.DateTimeOffset? resourceStatusChangedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> recommendationIds = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestion ScopingQuestion(string questionId = null, string superiorQuestionId = null, Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestionInputType inputType = default(Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestionInputType), System.Collections.Generic.IEnumerable<string> optionIds = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.QuestionRuleItem> rules = null, string showSubQuestionsValue = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestions ScopingQuestions(System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestion> questions = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotDownloadRequestContent SnapshotDownloadRequestContent(System.Guid? reportCreatorTenantId = default(System.Guid?), Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceDownloadType downloadType = default(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceDownloadType), string offerGuid = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordResult SyncCertRecordResult(Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord certRecord = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationProperty TriggerEvaluationProperty(System.DateTimeOffset? triggerOn = default(System.DateTimeOffset?), System.DateTimeOffset? evaluationEndOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> resourceIds = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.QuickAssessment> quickAssessments = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationResult TriggerEvaluationResult(Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationProperty properties = null) { throw null; }
    }
    public partial class CertSyncRecord : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord>
    {
        public CertSyncRecord() { }
        public string CertificationStatus { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppComplianceAutomation.Models.ControlSyncRecord> Controls { get { throw null; } }
        public string IngestionStatus { get { throw null; } set { } }
        public string OfferGuid { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ControlFamilyStatus : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ControlFamilyStatus(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyStatus NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyStatus Passed { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyStatus PendingApproval { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyStatus left, Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyStatus left, Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ControlSyncRecord : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ControlSyncRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ControlSyncRecord>
    {
        public ControlSyncRecord() { }
        public string ControlId { get { throw null; } set { } }
        public string ControlStatus { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ControlSyncRecord System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ControlSyncRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ControlSyncRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ControlSyncRecord System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ControlSyncRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ControlSyncRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ControlSyncRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomerResponsibility : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.CustomerResponsibility>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.CustomerResponsibility>
    {
        internal CustomerResponsibility() { }
        public System.Collections.Generic.IReadOnlyList<string> EvidenceFiles { get { throw null; } }
        public int? FailedResourceCount { get { throw null; } }
        public string Guidance { get { throw null; } }
        public string Justification { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationDetails> RecommendationList { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityResourceItem> ResourceList { get { throw null; } }
        public string ResponsibilityDescription { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityEnvironment? ResponsibilityEnvironment { get { throw null; } }
        public string ResponsibilityId { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilitySeverity? ResponsibilitySeverity { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityStatus? ResponsibilityStatus { get { throw null; } }
        public string ResponsibilityTitle { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityType? ResponsibilityType { get { throw null; } }
        public int? TotalResourceCount { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.CustomerResponsibility System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.CustomerResponsibility>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.CustomerResponsibility>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.CustomerResponsibility System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.CustomerResponsibility>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.CustomerResponsibility>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.CustomerResponsibility>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnableSslVerification : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.EnableSslVerification>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnableSslVerification(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.EnableSslVerification False { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.EnableSslVerification True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.EnableSslVerification other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.EnableSslVerification left, Azure.ResourceManager.AppComplianceAutomation.Models.EnableSslVerification right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.EnableSslVerification (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.EnableSslVerification left, Azure.ResourceManager.AppComplianceAutomation.Models.EnableSslVerification right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EvidenceFileDownloadRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadRequestContent>
    {
        public EvidenceFileDownloadRequestContent() { }
        public string OfferGuid { get { throw null; } set { } }
        public System.Guid? ReportCreatorTenantId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvidenceFileDownloadResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadResult>
    {
        internal EvidenceFileDownloadResult() { }
        public System.Uri EvidenceFileUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsRecommendSolution : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.IsRecommendSolution>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsRecommendSolution(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.IsRecommendSolution False { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.IsRecommendSolution True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.IsRecommendSolution other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.IsRecommendSolution left, Azure.ResourceManager.AppComplianceAutomation.Models.IsRecommendSolution right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.IsRecommendSolution (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.IsRecommendSolution left, Azure.ResourceManager.AppComplianceAutomation.Models.IsRecommendSolution right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OverviewStatusItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.OverviewStatusItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.OverviewStatusItem>
    {
        internal OverviewStatusItem() { }
        public string StatusName { get { throw null; } }
        public string StatusValue { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.OverviewStatusItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.OverviewStatusItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.OverviewStatusItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.OverviewStatusItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.OverviewStatusItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.OverviewStatusItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.OverviewStatusItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QuestionRuleItem : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.QuestionRuleItem>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QuestionRuleItem(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.QuestionRuleItem AzureApplication { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.QuestionRuleItem CharLength { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.QuestionRuleItem CreditCardPCI { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.QuestionRuleItem Domains { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.QuestionRuleItem DynamicDropdown { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.QuestionRuleItem PreventNonEnglishChar { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.QuestionRuleItem PublicSOX { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.QuestionRuleItem PublisherVerification { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.QuestionRuleItem Required { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.QuestionRuleItem Url { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.QuestionRuleItem Urls { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.QuestionRuleItem USPrivacyShield { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.QuestionRuleItem ValidEmail { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.QuestionRuleItem ValidGuid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.QuestionRuleItem other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.QuestionRuleItem left, Azure.ResourceManager.AppComplianceAutomation.Models.QuestionRuleItem right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.QuestionRuleItem (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.QuestionRuleItem left, Azure.ResourceManager.AppComplianceAutomation.Models.QuestionRuleItem right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuickAssessment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.QuickAssessment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.QuickAssessment>
    {
        internal QuickAssessment() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string RemediationLink { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceStatus? ResourceStatus { get { throw null; } }
        public string ResponsibilityId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.QuickAssessment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.QuickAssessment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.QuickAssessment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.QuickAssessment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.QuickAssessment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.QuickAssessment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.QuickAssessment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendationDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationDetails>
    {
        internal RecommendationDetails() { }
        public string RecommendationId { get { throw null; } }
        public string RecommendationShortName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationSolution> RecommendationSolutions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendationSolution : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationSolution>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationSolution>
    {
        internal RecommendationSolution() { }
        public Azure.ResourceManager.AppComplianceAutomation.Models.IsRecommendSolution? IsRecommendSolution { get { throw null; } }
        public string RecommendationSolutionContent { get { throw null; } }
        public string RecommendationSolutionIndex { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationSolution System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationSolution>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationSolution>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationSolution System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationSolution>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationSolution>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationSolution>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReportCollectionGetCountContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportCollectionGetCountContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportCollectionGetCountContent>
    {
        public ReportCollectionGetCountContent() { }
        public string GetCollectionCountRequestType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ReportCollectionGetCountContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportCollectionGetCountContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportCollectionGetCountContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ReportCollectionGetCountContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportCollectionGetCountContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportCollectionGetCountContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportCollectionGetCountContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReportCollectionGetCountResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportCollectionGetCountResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportCollectionGetCountResult>
    {
        internal ReportCollectionGetCountResult() { }
        public int? Count { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ReportCollectionGetCountResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportCollectionGetCountResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportCollectionGetCountResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ReportCollectionGetCountResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportCollectionGetCountResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportCollectionGetCountResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportCollectionGetCountResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReportFixResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportFixResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportFixResult>
    {
        internal ReportFixResult() { }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ReportResult? Result { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ReportFixResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportFixResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportFixResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ReportFixResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportFixResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportFixResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportFixResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReportListInUseStorageAccountsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportListInUseStorageAccountsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportListInUseStorageAccountsContent>
    {
        public ReportListInUseStorageAccountsContent() { }
        public System.Collections.Generic.IList<string> SubscriptionIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ReportListInUseStorageAccountsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportListInUseStorageAccountsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportListInUseStorageAccountsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ReportListInUseStorageAccountsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportListInUseStorageAccountsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportListInUseStorageAccountsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportListInUseStorageAccountsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReportListInUseStorageAccountsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportListInUseStorageAccountsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportListInUseStorageAccountsResult>
    {
        internal ReportListInUseStorageAccountsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.ReportStorageInfo> StorageAccountList { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ReportListInUseStorageAccountsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportListInUseStorageAccountsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportListInUseStorageAccountsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ReportListInUseStorageAccountsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportListInUseStorageAccountsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportListInUseStorageAccountsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportListInUseStorageAccountsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReportOverviewStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportOverviewStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportOverviewStatus>
    {
        internal ReportOverviewStatus() { }
        public int? FailedCount { get { throw null; } }
        public int? ManualCount { get { throw null; } }
        public int? NotApplicableCount { get { throw null; } }
        public int? PassedCount { get { throw null; } }
        public int? PendingCount { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ReportOverviewStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportOverviewStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportOverviewStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ReportOverviewStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportOverviewStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportOverviewStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportOverviewStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReportResourceItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceItem>
    {
        internal ReportResourceItem() { }
        public string ResourceGroup { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReportResourceMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceMetadata>
    {
        public ReportResourceMetadata(Azure.Core.ResourceIdentifier resourceId) { }
        public string AccountId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public string ResourceKind { get { throw null; } set { } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceOrigin? ResourceOrigin { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReportResourceOrigin : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceOrigin>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReportResourceOrigin(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceOrigin Aws { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceOrigin Azure { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceOrigin Gcp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceOrigin other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceOrigin left, Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceOrigin right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceOrigin (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceOrigin left, Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceOrigin right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReportResourceStatus : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReportResourceStatus(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceStatus Healthy { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceStatus Unhealthy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceStatus left, Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceStatus left, Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReportResult : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.ReportResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReportResult(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ReportResult Failed { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ReportResult Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.ReportResult other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.ReportResult left, Azure.ResourceManager.AppComplianceAutomation.Models.ReportResult right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.ReportResult (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.ReportResult left, Azure.ResourceManager.AppComplianceAutomation.Models.ReportResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReportStorageInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportStorageInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportStorageInfo>
    {
        public ReportStorageInfo() { }
        public string AccountName { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ReportStorageInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportStorageInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportStorageInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ReportStorageInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportStorageInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportStorageInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportStorageInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReportVerificationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportVerificationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportVerificationResult>
    {
        internal ReportVerificationResult() { }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ReportResult? Result { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ReportVerificationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportVerificationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportVerificationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ReportVerificationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportVerificationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportVerificationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportVerificationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResponsibilityEnvironment : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityEnvironment>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResponsibilityEnvironment(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityEnvironment Aws { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityEnvironment Azure { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityEnvironment Gcp { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityEnvironment General { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityEnvironment other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityEnvironment left, Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityEnvironment right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityEnvironment (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityEnvironment left, Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityEnvironment right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResponsibilityResourceItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityResourceItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityResourceItem>
    {
        internal ResponsibilityResourceItem() { }
        public string AccountId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RecommendationIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceOrigin? ResourceOrigin { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceStatus? ResourceStatus { get { throw null; } }
        public System.DateTimeOffset? ResourceStatusChangedOn { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityResourceItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityResourceItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityResourceItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityResourceItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityResourceItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityResourceItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityResourceItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResponsibilitySeverity : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilitySeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResponsibilitySeverity(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilitySeverity High { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilitySeverity Low { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilitySeverity Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilitySeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilitySeverity left, Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilitySeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilitySeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilitySeverity left, Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilitySeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResponsibilityStatus : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResponsibilityStatus(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityStatus NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityStatus Passed { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityStatus PendingApproval { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityStatus left, Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityStatus left, Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResponsibilityType : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResponsibilityType(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityType Automated { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityType Manual { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityType ScopedManual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityType left, Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityType left, Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScopingAnswer : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingAnswer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingAnswer>
    {
        public ScopingAnswer(string questionId, System.Collections.Generic.IEnumerable<string> answers) { }
        public System.Collections.Generic.IList<string> Answers { get { throw null; } }
        public string QuestionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ScopingAnswer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingAnswer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingAnswer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ScopingAnswer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingAnswer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingAnswer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingAnswer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScopingQuestion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestion>
    {
        internal ScopingQuestion() { }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestionInputType InputType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> OptionIds { get { throw null; } }
        public string QuestionId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.QuestionRuleItem> Rules { get { throw null; } }
        public string ShowSubQuestionsValue { get { throw null; } }
        public string SuperiorQuestionId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScopingQuestionInputType : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestionInputType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScopingQuestionInputType(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestionInputType Boolean { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestionInputType Date { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestionInputType Email { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestionInputType Group { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestionInputType MultilineText { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestionInputType MultiSelectCheckbox { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestionInputType MultiSelectDropdown { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestionInputType MultiSelectDropdownCustom { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestionInputType None { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestionInputType Number { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestionInputType SingleSelectDropdown { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestionInputType SingleSelection { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestionInputType Telephone { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestionInputType Text { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestionInputType Upload { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestionInputType Url { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestionInputType YearPicker { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestionInputType YesNoNa { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestionInputType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestionInputType left, Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestionInputType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestionInputType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestionInputType left, Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestionInputType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScopingQuestions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestions>
    {
        internal ScopingQuestions() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestion> Questions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SendAllEvent : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.SendAllEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SendAllEvent(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.SendAllEvent False { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.SendAllEvent True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.SendAllEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.SendAllEvent left, Azure.ResourceManager.AppComplianceAutomation.Models.SendAllEvent right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.SendAllEvent (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.SendAllEvent left, Azure.ResourceManager.AppComplianceAutomation.Models.SendAllEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SnapshotDownloadRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotDownloadRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotDownloadRequestContent>
    {
        public SnapshotDownloadRequestContent(Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceDownloadType downloadType) { }
        public Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceDownloadType DownloadType { get { throw null; } }
        public string OfferGuid { get { throw null; } set { } }
        public System.Guid? ReportCreatorTenantId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotDownloadRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotDownloadRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotDownloadRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotDownloadRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotDownloadRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotDownloadRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotDownloadRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SyncCertRecordContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordContent>
    {
        public SyncCertRecordContent(Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord certRecord) { }
        public Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord CertRecord { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SyncCertRecordResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordResult>
    {
        internal SyncCertRecordResult() { }
        public Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord CertRecord { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TriggerEvaluationContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationContent>
    {
        public TriggerEvaluationContent(System.Collections.Generic.IEnumerable<string> resourceIds) { }
        public System.Collections.Generic.IList<string> ResourceIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TriggerEvaluationProperty : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationProperty>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationProperty>
    {
        internal TriggerEvaluationProperty() { }
        public System.DateTimeOffset? EvaluationEndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.QuickAssessment> QuickAssessments { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ResourceIds { get { throw null; } }
        public System.DateTimeOffset? TriggerOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationProperty System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationProperty>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationProperty>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationProperty System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationProperty>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationProperty>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationProperty>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TriggerEvaluationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationResult>
    {
        internal TriggerEvaluationResult() { }
        public Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationProperty Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpdateWebhookKey : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.UpdateWebhookKey>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpdateWebhookKey(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.UpdateWebhookKey False { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.UpdateWebhookKey True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.UpdateWebhookKey other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.UpdateWebhookKey left, Azure.ResourceManager.AppComplianceAutomation.Models.UpdateWebhookKey right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.UpdateWebhookKey (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.UpdateWebhookKey left, Azure.ResourceManager.AppComplianceAutomation.Models.UpdateWebhookKey right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WebhookContentType : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.WebhookContentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WebhookContentType(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.WebhookContentType ApplicationJson { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.WebhookContentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.WebhookContentType left, Azure.ResourceManager.AppComplianceAutomation.Models.WebhookContentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.WebhookContentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.WebhookContentType left, Azure.ResourceManager.AppComplianceAutomation.Models.WebhookContentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WebhookDeliveryStatus : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.WebhookDeliveryStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WebhookDeliveryStatus(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.WebhookDeliveryStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.WebhookDeliveryStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.WebhookDeliveryStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.WebhookDeliveryStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.WebhookDeliveryStatus left, Azure.ResourceManager.AppComplianceAutomation.Models.WebhookDeliveryStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.WebhookDeliveryStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.WebhookDeliveryStatus left, Azure.ResourceManager.AppComplianceAutomation.Models.WebhookDeliveryStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WebhookKeyEnabled : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.WebhookKeyEnabled>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WebhookKeyEnabled(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.WebhookKeyEnabled False { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.WebhookKeyEnabled True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.WebhookKeyEnabled other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.WebhookKeyEnabled left, Azure.ResourceManager.AppComplianceAutomation.Models.WebhookKeyEnabled right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.WebhookKeyEnabled (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.WebhookKeyEnabled left, Azure.ResourceManager.AppComplianceAutomation.Models.WebhookKeyEnabled right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WebhookNotificationEvent : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.WebhookNotificationEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WebhookNotificationEvent(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.WebhookNotificationEvent AssessmentFailure { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.WebhookNotificationEvent GenerateSnapshotFailed { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.WebhookNotificationEvent GenerateSnapshotSuccess { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.WebhookNotificationEvent ReportConfigurationChanges { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.WebhookNotificationEvent ReportDeletion { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.WebhookNotificationEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.WebhookNotificationEvent left, Azure.ResourceManager.AppComplianceAutomation.Models.WebhookNotificationEvent right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.WebhookNotificationEvent (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.WebhookNotificationEvent left, Azure.ResourceManager.AppComplianceAutomation.Models.WebhookNotificationEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WebhookStatus : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.WebhookStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WebhookStatus(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.WebhookStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.WebhookStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.WebhookStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.WebhookStatus left, Azure.ResourceManager.AppComplianceAutomation.Models.WebhookStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.WebhookStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.WebhookStatus left, Azure.ResourceManager.AppComplianceAutomation.Models.WebhookStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
}
