namespace Azure.ResourceManager.AppComplianceAutomation
{
    public static partial class AppComplianceAutomationExtensions
    {
        public static Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityResponse> CheckNameAvailabilityProviderAction(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityResponse>> CheckNameAvailabilityProviderActionAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.GetCollectionCountResponse> GetCollectionCountProviderAction(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AppComplianceAutomation.Models.GetCollectionCountContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.GetCollectionCountResponse>> GetCollectionCountProviderActionAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AppComplianceAutomation.Models.GetCollectionCountContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.EvidenceResource GetEvidenceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.ListInUseStorageAccountsResponse> GetInUseStorageAccountsProviderAction(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AppComplianceAutomation.Models.ListInUseStorageAccountsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.ListInUseStorageAccountsResponse>> GetInUseStorageAccountsProviderActionAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AppComplianceAutomation.Models.ListInUseStorageAccountsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.GetOverviewStatusResponse> GetOverviewStatusProviderAction(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AppComplianceAutomation.Models.GetOverviewStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.GetOverviewStatusResponse>> GetOverviewStatusProviderActionAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.AppComplianceAutomation.Models.GetOverviewStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.ReportResource GetReportResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppComplianceAutomation.ReportResource> GetReportResource(this Azure.ResourceManager.Resources.TenantResource tenantResource, string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.ReportResource>> GetReportResourceAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.ReportResourceCollection GetReportResources(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResource GetScopingConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.SnapshotResource GetSnapshotResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.WebhookResource GetWebhookResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.Models.OnboardResponse> OnboardProviderAction(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.Models.OnboardContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.Models.OnboardResponse>> OnboardProviderActionAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.Models.OnboardContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationResponse> TriggerEvaluationProviderAction(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationResponse>> TriggerEvaluationProviderActionAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EvidenceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.EvidenceResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.EvidenceResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EvidenceResource() { }
        public virtual Azure.ResourceManager.AppComplianceAutomation.EvidenceResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string reportName, string evidenceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadResponse> Download(Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadResponse>> DownloadAsync(Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.EvidenceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.EvidenceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.AppComplianceAutomation.EvidenceResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.EvidenceResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.EvidenceResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.EvidenceResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.EvidenceResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.EvidenceResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.EvidenceResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.EvidenceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.EvidenceResourceData data, string offerGuid = null, string reportCreatorTenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.EvidenceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.EvidenceResourceData data, string offerGuid = null, string reportCreatorTenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EvidenceResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppComplianceAutomation.EvidenceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.EvidenceResource>, System.Collections.IEnumerable
    {
        protected EvidenceResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.EvidenceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string evidenceName, Azure.ResourceManager.AppComplianceAutomation.EvidenceResourceData data, string offerGuid = null, string reportCreatorTenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.EvidenceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string evidenceName, Azure.ResourceManager.AppComplianceAutomation.EvidenceResourceData data, string offerGuid = null, string reportCreatorTenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string evidenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string evidenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.EvidenceResource> Get(string evidenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppComplianceAutomation.EvidenceResource> GetAll(Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceResourceCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppComplianceAutomation.EvidenceResource> GetAllAsync(Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceResourceCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.EvidenceResource>> GetAsync(string evidenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.AppComplianceAutomation.EvidenceResource> GetIfExists(string evidenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AppComplianceAutomation.EvidenceResource>> GetIfExistsAsync(string evidenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppComplianceAutomation.EvidenceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppComplianceAutomation.EvidenceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppComplianceAutomation.EvidenceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.EvidenceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EvidenceResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.EvidenceResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.EvidenceResourceData>
    {
        public EvidenceResourceData(string filePath) { }
        public string ControlId { get { throw null; } set { } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceType? EvidenceType { get { throw null; } set { } }
        public string ExtraData { get { throw null; } set { } }
        public string FilePath { get { throw null; } set { } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ResponsibilityId { get { throw null; } set { } }
        Azure.ResourceManager.AppComplianceAutomation.EvidenceResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.EvidenceResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.EvidenceResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.EvidenceResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.EvidenceResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.EvidenceResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.EvidenceResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReportResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.ReportResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.ReportResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ReportResource() { }
        public virtual Azure.ResourceManager.AppComplianceAutomation.ReportResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string reportName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.Models.ReportFixResult> Fix(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.Models.ReportFixResult>> FixAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.ReportResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.ReportResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.EvidenceResource> GetEvidenceResource(string evidenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.EvidenceResource>> GetEvidenceResourceAsync(string evidenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppComplianceAutomation.EvidenceResourceCollection GetEvidenceResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResource> GetScopingConfigurationResource(string scopingConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResource>> GetScopingConfigurationResourceAsync(string scopingConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResourceCollection GetScopingConfigurationResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestions> GetScopingQuestions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestions>> GetScopingQuestionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.SnapshotResource> GetSnapshotResource(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.SnapshotResource>> GetSnapshotResourceAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppComplianceAutomation.SnapshotResourceCollection GetSnapshotResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.WebhookResource> GetWebhookResource(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.WebhookResource>> GetWebhookResourceAsync(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppComplianceAutomation.WebhookResourceCollection GetWebhookResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityResponse> NestedResourceCheckNameAvailability(Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityResponse>> NestedResourceCheckNameAvailabilityAsync(Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordResponse> SyncCertRecord(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordResponse>> SyncCertRecordAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.AppComplianceAutomation.ReportResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.ReportResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.ReportResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.ReportResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.ReportResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.ReportResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.ReportResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.ReportResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.ReportResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.Models.ReportVerificationResult> Verify(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.Models.ReportVerificationResult>> VerifyAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ReportResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppComplianceAutomation.ReportResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.ReportResource>, System.Collections.IEnumerable
    {
        protected ReportResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.ReportResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string reportName, Azure.ResourceManager.AppComplianceAutomation.ReportResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.ReportResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string reportName, Azure.ResourceManager.AppComplianceAutomation.ReportResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.ReportResource> Get(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppComplianceAutomation.ReportResource> GetAll(Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppComplianceAutomation.ReportResource> GetAllAsync(Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourceCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.ReportResource>> GetAsync(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.AppComplianceAutomation.ReportResource> GetIfExists(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AppComplianceAutomation.ReportResource>> GetIfExistsAsync(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppComplianceAutomation.ReportResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppComplianceAutomation.ReportResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppComplianceAutomation.ReportResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.ReportResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ReportResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.ReportResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.ReportResourceData>
    {
        public ReportResourceData(System.DateTimeOffset triggerOn, string timeZone, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceMetadata> resources) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord> CertRecords { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.OverviewStatus ComplianceStatusM365 { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Errors { get { throw null; } }
        public System.DateTimeOffset? LastTriggerOn { get { throw null; } }
        public System.DateTimeOffset? NextTriggerOn { get { throw null; } }
        public string OfferGuid { get { throw null; } set { } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceMetadata> Resources { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ReportStatus? Status { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.StorageInfo StorageInfo { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> Subscriptions { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
        public System.DateTimeOffset TriggerOn { get { throw null; } set { } }
        Azure.ResourceManager.AppComplianceAutomation.ReportResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.ReportResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.ReportResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.ReportResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.ReportResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.ReportResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.ReportResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScopingConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScopingConfigurationResource() { }
        public virtual Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string reportName, string scopingConfigurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScopingConfigurationResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResource>, System.Collections.IEnumerable
    {
        protected ScopingConfigurationResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string scopingConfigurationName, Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scopingConfigurationName, Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scopingConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scopingConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResource> Get(string scopingConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResource>> GetAsync(string scopingConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResource> GetIfExists(string scopingConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResource>> GetIfExistsAsync(string scopingConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScopingConfigurationResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResourceData>
    {
        public ScopingConfigurationResourceData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingAnswer> Answers { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SnapshotResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.SnapshotResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.SnapshotResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SnapshotResource() { }
        public virtual Azure.ResourceManager.AppComplianceAutomation.SnapshotResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string reportName, string snapshotName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.Models.DownloadResponse> Download(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotDownloadContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.Models.DownloadResponse>> DownloadAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotDownloadContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.SnapshotResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.SnapshotResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.AppComplianceAutomation.SnapshotResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.SnapshotResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.SnapshotResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.SnapshotResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.SnapshotResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.SnapshotResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.SnapshotResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SnapshotResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppComplianceAutomation.SnapshotResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.SnapshotResource>, System.Collections.IEnumerable
    {
        protected SnapshotResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.SnapshotResource> Get(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppComplianceAutomation.SnapshotResource> GetAll(Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotResourceCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppComplianceAutomation.SnapshotResource> GetAllAsync(Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotResourceCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.SnapshotResource>> GetAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.AppComplianceAutomation.SnapshotResource> GetIfExists(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AppComplianceAutomation.SnapshotResource>> GetIfExistsAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppComplianceAutomation.SnapshotResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppComplianceAutomation.SnapshotResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppComplianceAutomation.SnapshotResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.SnapshotResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SnapshotResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.SnapshotResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.SnapshotResourceData>
    {
        public SnapshotResourceData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceResult> ComplianceResults { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ReportProperties ReportProperties { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData ReportSystemData { get { throw null; } }
        public string SnapshotName { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.SnapshotResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.SnapshotResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.SnapshotResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.SnapshotResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.SnapshotResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.SnapshotResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.SnapshotResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebhookResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.WebhookResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.WebhookResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebhookResource() { }
        public virtual Azure.ResourceManager.AppComplianceAutomation.WebhookResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string reportName, string webhookName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.WebhookResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.WebhookResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.AppComplianceAutomation.WebhookResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.WebhookResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.WebhookResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.WebhookResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.WebhookResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.WebhookResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.WebhookResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.WebhookResource> Update(Azure.ResourceManager.AppComplianceAutomation.Models.WebhookResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.WebhookResource>> UpdateAsync(Azure.ResourceManager.AppComplianceAutomation.Models.WebhookResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebhookResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppComplianceAutomation.WebhookResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.WebhookResource>, System.Collections.IEnumerable
    {
        protected WebhookResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.WebhookResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string webhookName, Azure.ResourceManager.AppComplianceAutomation.WebhookResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.WebhookResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string webhookName, Azure.ResourceManager.AppComplianceAutomation.WebhookResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.WebhookResource> Get(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppComplianceAutomation.WebhookResource> GetAll(Azure.ResourceManager.AppComplianceAutomation.Models.WebhookResourceCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppComplianceAutomation.WebhookResource> GetAllAsync(Azure.ResourceManager.AppComplianceAutomation.Models.WebhookResourceCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.WebhookResource>> GetAsync(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.AppComplianceAutomation.WebhookResource> GetIfExists(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AppComplianceAutomation.WebhookResource>> GetIfExistsAsync(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppComplianceAutomation.WebhookResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppComplianceAutomation.WebhookResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppComplianceAutomation.WebhookResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.WebhookResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WebhookResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.WebhookResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.WebhookResourceData>
    {
        public WebhookResourceData() { }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ContentType? ContentType { get { throw null; } set { } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.DeliveryStatus? DeliveryStatus { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.EnableSslVerification? EnableSslVerification { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppComplianceAutomation.Models.NotificationEvent> Events { get { throw null; } }
        public System.Uri PayloadUri { get { throw null; } set { } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.SendAllEvent? SendAllEvents { get { throw null; } set { } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.WebhookStatus? Status { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.UpdateWebhookKey? UpdateWebhookKey { get { throw null; } set { } }
        public string WebhookId { get { throw null; } }
        public string WebhookKey { get { throw null; } set { } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.WebhookKeyEnabled? WebhookKeyEnabled { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.WebhookResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.WebhookResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.WebhookResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.WebhookResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.WebhookResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.WebhookResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.WebhookResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.AppComplianceAutomation.Mocking
{
    public partial class MockableAppComplianceAutomationArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableAppComplianceAutomationArmClient() { }
        public virtual Azure.ResourceManager.AppComplianceAutomation.EvidenceResource GetEvidenceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.AppComplianceAutomation.ReportResource GetReportResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResource GetScopingConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.AppComplianceAutomation.SnapshotResource GetSnapshotResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.AppComplianceAutomation.WebhookResource GetWebhookResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableAppComplianceAutomationTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAppComplianceAutomationTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityResponse> CheckNameAvailabilityProviderAction(Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityResponse>> CheckNameAvailabilityProviderActionAsync(Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.GetCollectionCountResponse> GetCollectionCountProviderAction(Azure.ResourceManager.AppComplianceAutomation.Models.GetCollectionCountContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.GetCollectionCountResponse>> GetCollectionCountProviderActionAsync(Azure.ResourceManager.AppComplianceAutomation.Models.GetCollectionCountContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.ListInUseStorageAccountsResponse> GetInUseStorageAccountsProviderAction(Azure.ResourceManager.AppComplianceAutomation.Models.ListInUseStorageAccountsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.ListInUseStorageAccountsResponse>> GetInUseStorageAccountsProviderActionAsync(Azure.ResourceManager.AppComplianceAutomation.Models.ListInUseStorageAccountsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.GetOverviewStatusResponse> GetOverviewStatusProviderAction(Azure.ResourceManager.AppComplianceAutomation.Models.GetOverviewStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.Models.GetOverviewStatusResponse>> GetOverviewStatusProviderActionAsync(Azure.ResourceManager.AppComplianceAutomation.Models.GetOverviewStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.ReportResource> GetReportResource(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.ReportResource>> GetReportResourceAsync(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppComplianceAutomation.ReportResourceCollection GetReportResources() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.Models.OnboardResponse> OnboardProviderAction(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.Models.OnboardContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.Models.OnboardResponse>> OnboardProviderActionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.Models.OnboardContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationResponse> TriggerEvaluationProviderAction(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationResponse>> TriggerEvaluationProviderActionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.AppComplianceAutomation.Models
{
    public static partial class ArmAppComplianceAutomationModelFactory
    {
        public static Azure.ResourceManager.AppComplianceAutomation.Models.Category Category(string categoryName = null, Azure.ResourceManager.AppComplianceAutomation.Models.CategoryStatus? categoryStatus = default(Azure.ResourceManager.AppComplianceAutomation.Models.CategoryStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamily> controlFamilies = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityResponse CheckNameAvailabilityResponse(bool? nameAvailable = default(bool?), Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityReason? reason = default(Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceReportItem ComplianceReportItem(string categoryName = null, string controlFamilyName = null, string controlId = null, string controlName = null, Azure.ResourceManager.AppComplianceAutomation.Models.ControlStatus? controlStatus = default(Azure.ResourceManager.AppComplianceAutomation.Models.ControlStatus?), string responsibilityTitle = null, string responsibilityDescription = null, string resourceId = null, string resourceType = null, Azure.ResourceManager.AppComplianceAutomation.Models.ResourceOrigin? resourceOrigin = default(Azure.ResourceManager.AppComplianceAutomation.Models.ResourceOrigin?), Azure.ResourceManager.AppComplianceAutomation.Models.ResourceStatus? resourceStatus = default(Azure.ResourceManager.AppComplianceAutomation.Models.ResourceStatus?), System.DateTimeOffset? resourceStatusChangeOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceResult ComplianceResult(string complianceName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.Category> categories = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.Control Control(string controlId = null, string controlName = null, string controlFullName = null, string controlDescription = null, string controlDescriptionHyperLink = null, Azure.ResourceManager.AppComplianceAutomation.Models.ControlStatus? controlStatus = default(Azure.ResourceManager.AppComplianceAutomation.Models.ControlStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.Responsibility> responsibilities = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamily ControlFamily(string controlFamilyName = null, Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyStatus? controlFamilyStatus = default(Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.Control> controls = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.DownloadResponse DownloadResponse(System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceItem> resourceList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceReportItem> complianceReport = null, System.Uri compliancePdfReportSasUri = null, System.Uri complianceDetailedPdfReportSasUri = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadResponse EvidenceFileDownloadResponse(System.Uri evidenceFileUri = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.EvidenceResourceData EvidenceResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceType? evidenceType = default(Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceType?), string filePath = null, string extraData = null, string controlId = null, string responsibilityId = null, Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.GetCollectionCountResponse GetCollectionCountResponse(int? count = default(int?)) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.GetOverviewStatusResponse GetOverviewStatusResponse(System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.StatusItem> statusList = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ListInUseStorageAccountsResponse ListInUseStorageAccountsResponse(System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.StorageInfo> storageAccountList = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.OnboardResponse OnboardResponse(System.Collections.Generic.IEnumerable<string> subscriptionIds = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.OverviewStatus OverviewStatus(int? passedCount = default(int?), int? failedCount = default(int?), int? manualCount = default(int?), int? notApplicableCount = default(int?), int? pendingCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.QuickAssessment QuickAssessment(string resourceId = null, string responsibilityId = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), Azure.ResourceManager.AppComplianceAutomation.Models.ResourceStatus? resourceStatus = default(Azure.ResourceManager.AppComplianceAutomation.Models.ResourceStatus?), string displayName = null, string description = null, string remediationLink = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.Recommendation Recommendation(string recommendationId = null, string recommendationShortName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationSolution> recommendationSolutions = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationSolution RecommendationSolution(string recommendationSolutionIndex = null, string recommendationSolutionContent = null, Azure.ResourceManager.AppComplianceAutomation.Models.IsRecommendSolution? isRecommendSolution = default(Azure.ResourceManager.AppComplianceAutomation.Models.IsRecommendSolution?)) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ReportFixResult ReportFixResult(Azure.ResourceManager.AppComplianceAutomation.Models.Result? result = default(Azure.ResourceManager.AppComplianceAutomation.Models.Result?), string reason = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ReportPatchProperties ReportPatchProperties(System.DateTimeOffset? triggerOn = default(System.DateTimeOffset?), string timeZone = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceMetadata> resources = null, Azure.ResourceManager.AppComplianceAutomation.Models.ReportStatus? status = default(Azure.ResourceManager.AppComplianceAutomation.Models.ReportStatus?), System.Collections.Generic.IEnumerable<string> errors = null, System.Guid? tenantId = default(System.Guid?), string offerGuid = null, System.DateTimeOffset? nextTriggerOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastTriggerOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> subscriptions = null, Azure.ResourceManager.AppComplianceAutomation.Models.OverviewStatus complianceStatusM365 = null, Azure.ResourceManager.AppComplianceAutomation.Models.StorageInfo storageInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord> certRecords = null, Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ReportProperties ReportProperties(System.DateTimeOffset triggerOn = default(System.DateTimeOffset), string timeZone = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceMetadata> resources = null, Azure.ResourceManager.AppComplianceAutomation.Models.ReportStatus? status = default(Azure.ResourceManager.AppComplianceAutomation.Models.ReportStatus?), System.Collections.Generic.IEnumerable<string> errors = null, System.Guid? tenantId = default(System.Guid?), string offerGuid = null, System.DateTimeOffset? nextTriggerOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastTriggerOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> subscriptions = null, Azure.ResourceManager.AppComplianceAutomation.Models.OverviewStatus complianceStatusM365 = null, Azure.ResourceManager.AppComplianceAutomation.Models.StorageInfo storageInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord> certRecords = null, Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.ReportResourceData ReportResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset triggerOn = default(System.DateTimeOffset), string timeZone = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceMetadata> resources = null, Azure.ResourceManager.AppComplianceAutomation.Models.ReportStatus? status = default(Azure.ResourceManager.AppComplianceAutomation.Models.ReportStatus?), System.Collections.Generic.IEnumerable<string> errors = null, System.Guid? tenantId = default(System.Guid?), string offerGuid = null, System.DateTimeOffset? nextTriggerOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastTriggerOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> subscriptions = null, Azure.ResourceManager.AppComplianceAutomation.Models.OverviewStatus complianceStatusM365 = null, Azure.ResourceManager.AppComplianceAutomation.Models.StorageInfo storageInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord> certRecords = null, Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ReportVerificationResult ReportVerificationResult(Azure.ResourceManager.AppComplianceAutomation.Models.Result? result = default(Azure.ResourceManager.AppComplianceAutomation.Models.Result?), string reason = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ResourceItem ResourceItem(string subscriptionId = null, string resourceGroup = null, string resourceType = null, string resourceId = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.Responsibility Responsibility(string responsibilityId = null, string responsibilityTitle = null, string responsibilityDescription = null, Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityType? responsibilityType = default(Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityType?), Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilitySeverity? responsibilitySeverity = default(Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilitySeverity?), Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityStatus? responsibilityStatus = default(Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityStatus?), Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityEnvironment? responsibilityEnvironment = default(Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityEnvironment?), int? failedResourceCount = default(int?), int? totalResourceCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityResource> resourceList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.Recommendation> recommendationList = null, string guidance = null, string justification = null, System.Collections.Generic.IEnumerable<string> evidenceFiles = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityResource ResponsibilityResource(string resourceId = null, string accountId = null, string resourceType = null, Azure.ResourceManager.AppComplianceAutomation.Models.ResourceOrigin? resourceOrigin = default(Azure.ResourceManager.AppComplianceAutomation.Models.ResourceOrigin?), Azure.ResourceManager.AppComplianceAutomation.Models.ResourceStatus? resourceStatus = default(Azure.ResourceManager.AppComplianceAutomation.Models.ResourceStatus?), System.DateTimeOffset? resourceStatusChangeOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> recommendationIds = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.ScopingConfigurationResourceData ScopingConfigurationResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingAnswer> answers = null, Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestion ScopingQuestion(string questionId = null, string superiorQuestionId = null, Azure.ResourceManager.AppComplianceAutomation.Models.InputType inputType = default(Azure.ResourceManager.AppComplianceAutomation.Models.InputType), System.Collections.Generic.IEnumerable<string> optionIds = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.Rule> rules = null, string showSubQuestionsValue = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestions ScopingQuestions(System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestion> questions = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotDownloadContent SnapshotDownloadContent(string reportCreatorTenantId = null, Azure.ResourceManager.AppComplianceAutomation.Models.DownloadType downloadType = default(Azure.ResourceManager.AppComplianceAutomation.Models.DownloadType), string offerGuid = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.SnapshotResourceData SnapshotResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string snapshotName = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState?), Azure.ResourceManager.AppComplianceAutomation.Models.ReportProperties reportProperties = null, Azure.ResourceManager.Models.SystemData reportSystemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceResult> complianceResults = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.StatusItem StatusItem(string statusName = null, string statusValue = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordResponse SyncCertRecordResponse(Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord certRecord = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationProperty TriggerEvaluationProperty(System.DateTimeOffset? triggerOn = default(System.DateTimeOffset?), System.DateTimeOffset? evaluationEndOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> resourceIds = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.QuickAssessment> quickAssessments = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationResponse TriggerEvaluationResponse(Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationProperty properties = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.WebhookProperties WebhookProperties(string webhookId = null, Azure.ResourceManager.AppComplianceAutomation.Models.WebhookStatus? status = default(Azure.ResourceManager.AppComplianceAutomation.Models.WebhookStatus?), System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.AppComplianceAutomation.Models.SendAllEvent? sendAllEvents = default(Azure.ResourceManager.AppComplianceAutomation.Models.SendAllEvent?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.NotificationEvent> events = null, System.Uri payloadUri = null, Azure.ResourceManager.AppComplianceAutomation.Models.ContentType? contentType = default(Azure.ResourceManager.AppComplianceAutomation.Models.ContentType?), string webhookKey = null, Azure.ResourceManager.AppComplianceAutomation.Models.UpdateWebhookKey? updateWebhookKey = default(Azure.ResourceManager.AppComplianceAutomation.Models.UpdateWebhookKey?), Azure.ResourceManager.AppComplianceAutomation.Models.WebhookKeyEnabled? webhookKeyEnabled = default(Azure.ResourceManager.AppComplianceAutomation.Models.WebhookKeyEnabled?), Azure.ResourceManager.AppComplianceAutomation.Models.EnableSslVerification? enableSslVerification = default(Azure.ResourceManager.AppComplianceAutomation.Models.EnableSslVerification?), Azure.ResourceManager.AppComplianceAutomation.Models.DeliveryStatus? deliveryStatus = default(Azure.ResourceManager.AppComplianceAutomation.Models.DeliveryStatus?), Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.WebhookResourceData WebhookResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string webhookId = null, Azure.ResourceManager.AppComplianceAutomation.Models.WebhookStatus? status = default(Azure.ResourceManager.AppComplianceAutomation.Models.WebhookStatus?), System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.AppComplianceAutomation.Models.SendAllEvent? sendAllEvents = default(Azure.ResourceManager.AppComplianceAutomation.Models.SendAllEvent?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.NotificationEvent> events = null, System.Uri payloadUri = null, Azure.ResourceManager.AppComplianceAutomation.Models.ContentType? contentType = default(Azure.ResourceManager.AppComplianceAutomation.Models.ContentType?), string webhookKey = null, Azure.ResourceManager.AppComplianceAutomation.Models.UpdateWebhookKey? updateWebhookKey = default(Azure.ResourceManager.AppComplianceAutomation.Models.UpdateWebhookKey?), Azure.ResourceManager.AppComplianceAutomation.Models.WebhookKeyEnabled? webhookKeyEnabled = default(Azure.ResourceManager.AppComplianceAutomation.Models.WebhookKeyEnabled?), Azure.ResourceManager.AppComplianceAutomation.Models.EnableSslVerification? enableSslVerification = default(Azure.ResourceManager.AppComplianceAutomation.Models.EnableSslVerification?), Azure.ResourceManager.AppComplianceAutomation.Models.DeliveryStatus? deliveryStatus = default(Azure.ResourceManager.AppComplianceAutomation.Models.DeliveryStatus?), Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState?)) { throw null; }
    }
    public partial class Category : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.Category>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.Category>
    {
        internal Category() { }
        public string CategoryName { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.CategoryStatus? CategoryStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamily> ControlFamilies { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.Category System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.Category>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.Category>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.Category System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.Category>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.Category>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.Category>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CategoryStatus : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.CategoryStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CategoryStatus(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.CategoryStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.CategoryStatus NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.CategoryStatus Passed { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.CategoryStatus PendingApproval { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.CategoryStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.CategoryStatus left, Azure.ResourceManager.AppComplianceAutomation.Models.CategoryStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.CategoryStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.CategoryStatus left, Azure.ResourceManager.AppComplianceAutomation.Models.CategoryStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CertSyncRecord : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord>
    {
        public CertSyncRecord() { }
        public string CertificationStatus { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppComplianceAutomation.Models.ControlSyncRecord> Controls { get { throw null; } }
        public string IngestionStatus { get { throw null; } set { } }
        public string OfferGuid { get { throw null; } set { } }
        Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CheckNameAvailabilityReason : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CheckNameAvailabilityReason(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityReason left, Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityReason left, Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CheckNameAvailabilityRequest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityRequest>
    {
        public CheckNameAvailabilityRequest() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
        Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityRequest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityRequest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CheckNameAvailabilityResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityResponse>
    {
        internal CheckNameAvailabilityResponse() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityReason? Reason { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.CheckNameAvailabilityResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComplianceReportItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceReportItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceReportItem>
    {
        internal ComplianceReportItem() { }
        public string CategoryName { get { throw null; } }
        public string ControlFamilyName { get { throw null; } }
        public string ControlId { get { throw null; } }
        public string ControlName { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ControlStatus? ControlStatus { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ResourceOrigin? ResourceOrigin { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ResourceStatus? ResourceStatus { get { throw null; } }
        public System.DateTimeOffset? ResourceStatusChangeOn { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public string ResponsibilityDescription { get { throw null; } }
        public string ResponsibilityTitle { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceReportItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceReportItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceReportItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceReportItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceReportItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceReportItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceReportItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComplianceResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceResult>
    {
        internal ComplianceResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.Category> Categories { get { throw null; } }
        public string ComplianceName { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentType : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.ContentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentType(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ContentType ApplicationJson { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.ContentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.ContentType left, Azure.ResourceManager.AppComplianceAutomation.Models.ContentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.ContentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.ContentType left, Azure.ResourceManager.AppComplianceAutomation.Models.ContentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Control : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.Control>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.Control>
    {
        internal Control() { }
        public string ControlDescription { get { throw null; } }
        public string ControlDescriptionHyperLink { get { throw null; } }
        public string ControlFullName { get { throw null; } }
        public string ControlId { get { throw null; } }
        public string ControlName { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ControlStatus? ControlStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.Responsibility> Responsibilities { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.Control System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.Control>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.Control>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.Control System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.Control>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.Control>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.Control>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ControlFamily : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamily>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamily>
    {
        internal ControlFamily() { }
        public string ControlFamilyName { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyStatus? ControlFamilyStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.Control> Controls { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamily System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamily>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamily>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamily System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamily>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamily>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamily>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ControlStatus : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.ControlStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ControlStatus(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ControlStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ControlStatus NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ControlStatus Passed { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ControlStatus PendingApproval { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.ControlStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.ControlStatus left, Azure.ResourceManager.AppComplianceAutomation.Models.ControlStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.ControlStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.ControlStatus left, Azure.ResourceManager.AppComplianceAutomation.Models.ControlStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ControlSyncRecord : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ControlSyncRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ControlSyncRecord>
    {
        public ControlSyncRecord() { }
        public string ControlId { get { throw null; } set { } }
        public string ControlStatus { get { throw null; } set { } }
        Azure.ResourceManager.AppComplianceAutomation.Models.ControlSyncRecord System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ControlSyncRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ControlSyncRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ControlSyncRecord System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ControlSyncRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ControlSyncRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ControlSyncRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeliveryStatus : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.DeliveryStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeliveryStatus(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.DeliveryStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.DeliveryStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.DeliveryStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.DeliveryStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.DeliveryStatus left, Azure.ResourceManager.AppComplianceAutomation.Models.DeliveryStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.DeliveryStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.DeliveryStatus left, Azure.ResourceManager.AppComplianceAutomation.Models.DeliveryStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DownloadResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.DownloadResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.DownloadResponse>
    {
        internal DownloadResponse() { }
        public System.Uri ComplianceDetailedPdfReportSasUri { get { throw null; } }
        public System.Uri CompliancePdfReportSasUri { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceReportItem> ComplianceReport { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceItem> ResourceList { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.DownloadResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.DownloadResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.DownloadResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.DownloadResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.DownloadResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.DownloadResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.DownloadResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DownloadType : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.DownloadType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DownloadType(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.DownloadType ComplianceDetailedPdfReport { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.DownloadType CompliancePdfReport { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.DownloadType ComplianceReport { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.DownloadType ResourceList { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.DownloadType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.DownloadType left, Azure.ResourceManager.AppComplianceAutomation.Models.DownloadType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.DownloadType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.DownloadType left, Azure.ResourceManager.AppComplianceAutomation.Models.DownloadType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class EvidenceFileDownloadContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadContent>
    {
        public EvidenceFileDownloadContent() { }
        public string OfferGuid { get { throw null; } set { } }
        public string ReportCreatorTenantId { get { throw null; } set { } }
        Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvidenceFileDownloadResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadResponse>
    {
        internal EvidenceFileDownloadResponse() { }
        public System.Uri EvidenceFileUri { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceFileDownloadResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvidenceResourceCollectionGetAllOptions
    {
        public EvidenceResourceCollectionGetAllOptions() { }
        public string Filter { get { throw null; } set { } }
        public string OfferGuid { get { throw null; } set { } }
        public string Orderby { get { throw null; } set { } }
        public string ReportCreatorTenantId { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvidenceType : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvidenceType(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceType AutoCollectedEvidence { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceType Data { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceType File { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceType left, Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceType left, Azure.ResourceManager.AppComplianceAutomation.Models.EvidenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GetCollectionCountContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.GetCollectionCountContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.GetCollectionCountContent>
    {
        public GetCollectionCountContent() { }
        public string GetCollectionCountRequestType { get { throw null; } set { } }
        Azure.ResourceManager.AppComplianceAutomation.Models.GetCollectionCountContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.GetCollectionCountContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.GetCollectionCountContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.GetCollectionCountContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.GetCollectionCountContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.GetCollectionCountContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.GetCollectionCountContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetCollectionCountResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.GetCollectionCountResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.GetCollectionCountResponse>
    {
        internal GetCollectionCountResponse() { }
        public int? Count { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.GetCollectionCountResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.GetCollectionCountResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.GetCollectionCountResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.GetCollectionCountResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.GetCollectionCountResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.GetCollectionCountResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.GetCollectionCountResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetOverviewStatusContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.GetOverviewStatusContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.GetOverviewStatusContent>
    {
        public GetOverviewStatusContent() { }
        public string GetOverviewStatusRequestType { get { throw null; } set { } }
        Azure.ResourceManager.AppComplianceAutomation.Models.GetOverviewStatusContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.GetOverviewStatusContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.GetOverviewStatusContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.GetOverviewStatusContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.GetOverviewStatusContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.GetOverviewStatusContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.GetOverviewStatusContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetOverviewStatusResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.GetOverviewStatusResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.GetOverviewStatusResponse>
    {
        internal GetOverviewStatusResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.StatusItem> StatusList { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.GetOverviewStatusResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.GetOverviewStatusResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.GetOverviewStatusResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.GetOverviewStatusResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.GetOverviewStatusResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.GetOverviewStatusResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.GetOverviewStatusResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InputType : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.InputType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InputType(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.InputType Boolean { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.InputType Date { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.InputType Email { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.InputType Group { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.InputType MultilineText { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.InputType MultiSelectCheckbox { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.InputType MultiSelectDropdown { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.InputType MultiSelectDropdownCustom { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.InputType None { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.InputType Number { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.InputType SingleSelectDropdown { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.InputType SingleSelection { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.InputType Telephone { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.InputType Text { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.InputType Upload { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.InputType Url { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.InputType YearPicker { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.InputType YesNoNa { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.InputType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.InputType left, Azure.ResourceManager.AppComplianceAutomation.Models.InputType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.InputType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.InputType left, Azure.ResourceManager.AppComplianceAutomation.Models.InputType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class ListInUseStorageAccountsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ListInUseStorageAccountsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ListInUseStorageAccountsContent>
    {
        public ListInUseStorageAccountsContent() { }
        public System.Collections.Generic.IList<string> SubscriptionIds { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.ListInUseStorageAccountsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ListInUseStorageAccountsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ListInUseStorageAccountsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ListInUseStorageAccountsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ListInUseStorageAccountsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ListInUseStorageAccountsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ListInUseStorageAccountsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ListInUseStorageAccountsResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ListInUseStorageAccountsResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ListInUseStorageAccountsResponse>
    {
        internal ListInUseStorageAccountsResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.StorageInfo> StorageAccountList { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.ListInUseStorageAccountsResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ListInUseStorageAccountsResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ListInUseStorageAccountsResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ListInUseStorageAccountsResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ListInUseStorageAccountsResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ListInUseStorageAccountsResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ListInUseStorageAccountsResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NotificationEvent : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.NotificationEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NotificationEvent(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.NotificationEvent AssessmentFailure { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.NotificationEvent GenerateSnapshotFailed { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.NotificationEvent GenerateSnapshotSuccess { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.NotificationEvent ReportConfigurationChanges { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.NotificationEvent ReportDeletion { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.NotificationEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.NotificationEvent left, Azure.ResourceManager.AppComplianceAutomation.Models.NotificationEvent right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.NotificationEvent (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.NotificationEvent left, Azure.ResourceManager.AppComplianceAutomation.Models.NotificationEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OnboardContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.OnboardContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.OnboardContent>
    {
        public OnboardContent(System.Collections.Generic.IEnumerable<string> subscriptionIds) { }
        public System.Collections.Generic.IList<string> SubscriptionIds { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.OnboardContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.OnboardContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.OnboardContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.OnboardContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.OnboardContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.OnboardContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.OnboardContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OnboardResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.OnboardResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.OnboardResponse>
    {
        internal OnboardResponse() { }
        public System.Collections.Generic.IReadOnlyList<string> SubscriptionIds { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.OnboardResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.OnboardResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.OnboardResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.OnboardResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.OnboardResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.OnboardResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.OnboardResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OverviewStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.OverviewStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.OverviewStatus>
    {
        internal OverviewStatus() { }
        public int? FailedCount { get { throw null; } }
        public int? ManualCount { get { throw null; } }
        public int? NotApplicableCount { get { throw null; } }
        public int? PassedCount { get { throw null; } }
        public int? PendingCount { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.OverviewStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.OverviewStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.OverviewStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.OverviewStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.OverviewStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.OverviewStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.OverviewStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState Fixing { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState Updating { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState Verifying { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState left, Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState left, Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuickAssessment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.QuickAssessment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.QuickAssessment>
    {
        internal QuickAssessment() { }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string RemediationLink { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ResourceStatus? ResourceStatus { get { throw null; } }
        public string ResponsibilityId { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.QuickAssessment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.QuickAssessment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.QuickAssessment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.QuickAssessment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.QuickAssessment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.QuickAssessment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.QuickAssessment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Recommendation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.Recommendation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.Recommendation>
    {
        internal Recommendation() { }
        public string RecommendationId { get { throw null; } }
        public string RecommendationShortName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationSolution> RecommendationSolutions { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.Recommendation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.Recommendation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.Recommendation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.Recommendation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.Recommendation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.Recommendation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.Recommendation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendationSolution : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationSolution>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationSolution>
    {
        internal RecommendationSolution() { }
        public Azure.ResourceManager.AppComplianceAutomation.Models.IsRecommendSolution? IsRecommendSolution { get { throw null; } }
        public string RecommendationSolutionContent { get { throw null; } }
        public string RecommendationSolutionIndex { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationSolution System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationSolution>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationSolution>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationSolution System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationSolution>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationSolution>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.RecommendationSolution>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReportFixResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportFixResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportFixResult>
    {
        internal ReportFixResult() { }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.Result? Result { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.ReportFixResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportFixResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportFixResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ReportFixResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportFixResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportFixResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportFixResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReportPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportPatchProperties>
    {
        public ReportPatchProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord> CertRecords { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.OverviewStatus ComplianceStatusM365 { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Errors { get { throw null; } }
        public System.DateTimeOffset? LastTriggerOn { get { throw null; } }
        public System.DateTimeOffset? NextTriggerOn { get { throw null; } }
        public string OfferGuid { get { throw null; } set { } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceMetadata> Resources { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ReportStatus? Status { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.StorageInfo StorageInfo { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> Subscriptions { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
        public System.DateTimeOffset? TriggerOn { get { throw null; } set { } }
        Azure.ResourceManager.AppComplianceAutomation.Models.ReportPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ReportPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReportProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportProperties>
    {
        internal ReportProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord> CertRecords { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.OverviewStatus ComplianceStatusM365 { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Errors { get { throw null; } }
        public System.DateTimeOffset? LastTriggerOn { get { throw null; } }
        public System.DateTimeOffset? NextTriggerOn { get { throw null; } }
        public string OfferGuid { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceMetadata> Resources { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ReportStatus? Status { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.StorageInfo StorageInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Subscriptions { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public string TimeZone { get { throw null; } }
        public System.DateTimeOffset TriggerOn { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.ReportProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ReportProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReportResourceCollectionGetAllOptions
    {
        public ReportResourceCollectionGetAllOptions() { }
        public string Filter { get { throw null; } set { } }
        public string OfferGuid { get { throw null; } set { } }
        public string Orderby { get { throw null; } set { } }
        public string ReportCreatorTenantId { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
    }
    public partial class ReportResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourcePatch>
    {
        public ReportResourcePatch() { }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ReportPatchProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReportStatus : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.ReportStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReportStatus(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ReportStatus Active { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ReportStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ReportStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ReportStatus Reviewing { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.ReportStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.ReportStatus left, Azure.ResourceManager.AppComplianceAutomation.Models.ReportStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.ReportStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.ReportStatus left, Azure.ResourceManager.AppComplianceAutomation.Models.ReportStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReportVerificationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportVerificationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportVerificationResult>
    {
        internal ReportVerificationResult() { }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.Result? Result { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.ReportVerificationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportVerificationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportVerificationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ReportVerificationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportVerificationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportVerificationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportVerificationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceItem>
    {
        internal ResourceItem() { }
        public string ResourceGroup { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.ResourceItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ResourceItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceMetadata>
    {
        public ResourceMetadata(string resourceId) { }
        public string AccountId { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public string ResourceKind { get { throw null; } set { } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ResourceOrigin? ResourceOrigin { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
        Azure.ResourceManager.AppComplianceAutomation.Models.ResourceMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ResourceMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceOrigin : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceOrigin>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceOrigin(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ResourceOrigin AWS { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ResourceOrigin Azure { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ResourceOrigin GCP { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.ResourceOrigin other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.ResourceOrigin left, Azure.ResourceManager.AppComplianceAutomation.Models.ResourceOrigin right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.ResourceOrigin (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.ResourceOrigin left, Azure.ResourceManager.AppComplianceAutomation.Models.ResourceOrigin right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceStatus : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceStatus(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ResourceStatus Healthy { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ResourceStatus Unhealthy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.ResourceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.ResourceStatus left, Azure.ResourceManager.AppComplianceAutomation.Models.ResourceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.ResourceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.ResourceStatus left, Azure.ResourceManager.AppComplianceAutomation.Models.ResourceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Responsibility : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.Responsibility>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.Responsibility>
    {
        internal Responsibility() { }
        public System.Collections.Generic.IReadOnlyList<string> EvidenceFiles { get { throw null; } }
        public int? FailedResourceCount { get { throw null; } }
        public string Guidance { get { throw null; } }
        public string Justification { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.Recommendation> RecommendationList { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityResource> ResourceList { get { throw null; } }
        public string ResponsibilityDescription { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityEnvironment? ResponsibilityEnvironment { get { throw null; } }
        public string ResponsibilityId { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilitySeverity? ResponsibilitySeverity { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityStatus? ResponsibilityStatus { get { throw null; } }
        public string ResponsibilityTitle { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityType? ResponsibilityType { get { throw null; } }
        public int? TotalResourceCount { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.Responsibility System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.Responsibility>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.Responsibility>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.Responsibility System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.Responsibility>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.Responsibility>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.Responsibility>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResponsibilityEnvironment : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityEnvironment>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResponsibilityEnvironment(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityEnvironment AWS { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityEnvironment Azure { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityEnvironment GCP { get { throw null; } }
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
    public partial class ResponsibilityResource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityResource>
    {
        internal ResponsibilityResource() { }
        public string AccountId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RecommendationIds { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ResourceOrigin? ResourceOrigin { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ResourceStatus? ResourceStatus { get { throw null; } }
        public System.DateTimeOffset? ResourceStatusChangeOn { get { throw null; } }
        public string ResourceType { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ResponsibilityResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Result : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.Result>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Result(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.Result Failed { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.Result Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.Result other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.Result left, Azure.ResourceManager.AppComplianceAutomation.Models.Result right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.Result (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.Result left, Azure.ResourceManager.AppComplianceAutomation.Models.Result right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Rule : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.Rule>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Rule(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.Rule AzureApplication { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.Rule CharLength { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.Rule CreditCardPCI { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.Rule Domains { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.Rule DynamicDropdown { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.Rule PreventNonEnglishChar { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.Rule PublicSOX { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.Rule PublisherVerification { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.Rule Required { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.Rule Url { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.Rule Urls { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.Rule USPrivacyShield { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.Rule ValidEmail { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.Rule ValidGuid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.Rule other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.Rule left, Azure.ResourceManager.AppComplianceAutomation.Models.Rule right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.Rule (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.Rule left, Azure.ResourceManager.AppComplianceAutomation.Models.Rule right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScopingAnswer : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingAnswer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingAnswer>
    {
        public ScopingAnswer(string questionId, System.Collections.Generic.IEnumerable<string> answers) { }
        public System.Collections.Generic.IList<string> Answers { get { throw null; } }
        public string QuestionId { get { throw null; } set { } }
        Azure.ResourceManager.AppComplianceAutomation.Models.ScopingAnswer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingAnswer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingAnswer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ScopingAnswer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingAnswer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingAnswer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingAnswer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScopingQuestion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestion>
    {
        internal ScopingQuestion() { }
        public Azure.ResourceManager.AppComplianceAutomation.Models.InputType InputType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> OptionIds { get { throw null; } }
        public string QuestionId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.Rule> Rules { get { throw null; } }
        public string ShowSubQuestionsValue { get { throw null; } }
        public string SuperiorQuestionId { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScopingQuestions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestions>
    {
        internal ScopingQuestions() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.ScopingQuestion> Questions { get { throw null; } }
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
    public partial class SnapshotDownloadContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotDownloadContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotDownloadContent>
    {
        public SnapshotDownloadContent(Azure.ResourceManager.AppComplianceAutomation.Models.DownloadType downloadType) { }
        public Azure.ResourceManager.AppComplianceAutomation.Models.DownloadType DownloadType { get { throw null; } }
        public string OfferGuid { get { throw null; } set { } }
        public string ReportCreatorTenantId { get { throw null; } set { } }
        Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotDownloadContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotDownloadContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotDownloadContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotDownloadContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotDownloadContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotDownloadContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotDownloadContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SnapshotResourceCollectionGetAllOptions
    {
        public SnapshotResourceCollectionGetAllOptions() { }
        public string Filter { get { throw null; } set { } }
        public string OfferGuid { get { throw null; } set { } }
        public string Orderby { get { throw null; } set { } }
        public string ReportCreatorTenantId { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
    }
    public partial class StatusItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.StatusItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.StatusItem>
    {
        internal StatusItem() { }
        public string StatusName { get { throw null; } }
        public string StatusValue { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.StatusItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.StatusItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.StatusItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.StatusItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.StatusItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.StatusItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.StatusItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.StorageInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.StorageInfo>
    {
        public StorageInfo() { }
        public string AccountName { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        Azure.ResourceManager.AppComplianceAutomation.Models.StorageInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.StorageInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.StorageInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.StorageInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.StorageInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.StorageInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.StorageInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SyncCertRecordContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordContent>
    {
        public SyncCertRecordContent(Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord certRecord) { }
        public Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord CertRecord { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SyncCertRecordResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordResponse>
    {
        internal SyncCertRecordResponse() { }
        public Azure.ResourceManager.AppComplianceAutomation.Models.CertSyncRecord CertRecord { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.SyncCertRecordResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TriggerEvaluationContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationContent>
    {
        public TriggerEvaluationContent(System.Collections.Generic.IEnumerable<string> resourceIds) { }
        public System.Collections.Generic.IList<string> ResourceIds { get { throw null; } }
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
        Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationProperty System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationProperty>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationProperty>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationProperty System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationProperty>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationProperty>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationProperty>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TriggerEvaluationResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationResponse>
    {
        internal TriggerEvaluationResponse() { }
        public Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationProperty Properties { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.TriggerEvaluationResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class WebhookProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.WebhookProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.WebhookProperties>
    {
        public WebhookProperties() { }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ContentType? ContentType { get { throw null; } set { } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.DeliveryStatus? DeliveryStatus { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.EnableSslVerification? EnableSslVerification { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppComplianceAutomation.Models.NotificationEvent> Events { get { throw null; } }
        public System.Uri PayloadUri { get { throw null; } set { } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.SendAllEvent? SendAllEvents { get { throw null; } set { } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.WebhookStatus? Status { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.UpdateWebhookKey? UpdateWebhookKey { get { throw null; } set { } }
        public string WebhookId { get { throw null; } }
        public string WebhookKey { get { throw null; } set { } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.WebhookKeyEnabled? WebhookKeyEnabled { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.WebhookProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.WebhookProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.WebhookProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.WebhookProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.WebhookProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.WebhookProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.WebhookProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebhookResourceCollectionGetAllOptions
    {
        public WebhookResourceCollectionGetAllOptions() { }
        public string Filter { get { throw null; } set { } }
        public string OfferGuid { get { throw null; } set { } }
        public string Orderby { get { throw null; } set { } }
        public string ReportCreatorTenantId { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
    }
    public partial class WebhookResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.WebhookResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.WebhookResourcePatch>
    {
        public WebhookResourcePatch() { }
        public Azure.ResourceManager.AppComplianceAutomation.Models.WebhookProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.AppComplianceAutomation.Models.WebhookResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.WebhookResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.WebhookResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.WebhookResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.WebhookResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.WebhookResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.WebhookResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
