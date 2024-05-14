namespace Azure.ResourceManager.AppComplianceAutomation
{
    public static partial class AppComplianceAutomationExtensions
    {
        public static Azure.ResourceManager.AppComplianceAutomation.ReportResource GetReportResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppComplianceAutomation.ReportResource> GetReportResource(this Azure.ResourceManager.Resources.TenantResource tenantResource, string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.ReportResource>> GetReportResourceAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.ReportResourceCollection GetReportResources(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.SnapshotResource GetSnapshotResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class ReportResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ReportResource() { }
        public virtual Azure.ResourceManager.AppComplianceAutomation.ReportResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string reportName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.ReportResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.ReportResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.SnapshotResource> GetSnapshotResource(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.SnapshotResource>> GetSnapshotResourceAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppComplianceAutomation.SnapshotResourceCollection GetSnapshotResources() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.ReportResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.ReportResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ReportResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppComplianceAutomation.ReportResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.ReportResource>, System.Collections.IEnumerable
    {
        protected ReportResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.ReportResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string reportName, Azure.ResourceManager.AppComplianceAutomation.ReportResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppComplianceAutomation.ReportResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string reportName, Azure.ResourceManager.AppComplianceAutomation.ReportResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.ReportResource> Get(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppComplianceAutomation.ReportResource> GetAll(string skipToken = null, int? top = default(int?), string select = null, string offerGuid = null, string reportCreatorTenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppComplianceAutomation.ReportResource> GetAllAsync(string skipToken = null, int? top = default(int?), string select = null, string offerGuid = null, string reportCreatorTenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.ReportResource>> GetAsync(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.AppComplianceAutomation.ReportResource> GetIfExists(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AppComplianceAutomation.ReportResource>> GetIfExistsAsync(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppComplianceAutomation.ReportResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppComplianceAutomation.ReportResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppComplianceAutomation.ReportResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.ReportResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ReportResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.ReportResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.ReportResourceData>
    {
        public ReportResourceData(Azure.ResourceManager.AppComplianceAutomation.Models.ReportProperties properties) { }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ReportProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.AppComplianceAutomation.ReportResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.ReportResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.ReportResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.ReportResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.ReportResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.ReportResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.ReportResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SnapshotResource : Azure.ResourceManager.ArmResource
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
    }
    public partial class SnapshotResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppComplianceAutomation.SnapshotResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.SnapshotResource>, System.Collections.IEnumerable
    {
        protected SnapshotResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.SnapshotResource> Get(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppComplianceAutomation.SnapshotResource> GetAll(string skipToken = null, int? top = default(int?), string select = null, string reportCreatorTenantId = null, string offerGuid = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppComplianceAutomation.SnapshotResource> GetAllAsync(string skipToken = null, int? top = default(int?), string select = null, string reportCreatorTenantId = null, string offerGuid = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotProperties Properties { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.SnapshotResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.SnapshotResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.SnapshotResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.SnapshotResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.SnapshotResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.SnapshotResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.SnapshotResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.AppComplianceAutomation.Mocking
{
    public partial class MockableAppComplianceAutomationArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableAppComplianceAutomationArmClient() { }
        public virtual Azure.ResourceManager.AppComplianceAutomation.ReportResource GetReportResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.AppComplianceAutomation.SnapshotResource GetSnapshotResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableAppComplianceAutomationTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAppComplianceAutomationTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.AppComplianceAutomation.ReportResource> GetReportResource(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppComplianceAutomation.ReportResource>> GetReportResourceAsync(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppComplianceAutomation.ReportResourceCollection GetReportResources() { throw null; }
    }
}
namespace Azure.ResourceManager.AppComplianceAutomation.Models
{
    public static partial class ArmAppComplianceAutomationModelFactory
    {
        public static Azure.ResourceManager.AppComplianceAutomation.Models.Assessment Assessment(string name = null, Azure.ResourceManager.AppComplianceAutomation.Models.AssessmentSeverity? severity = default(Azure.ResourceManager.AppComplianceAutomation.Models.AssessmentSeverity?), string description = null, string remediation = null, Azure.ResourceManager.AppComplianceAutomation.Models.IsPass? isPass = default(Azure.ResourceManager.AppComplianceAutomation.Models.IsPass?), string policyId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.AssessmentResourceContent> resourceList = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AssessmentResourceContent AssessmentResourceContent(string resourceId = null, Azure.ResourceManager.AppComplianceAutomation.Models.ResourceStatus? resourceStatus = default(Azure.ResourceManager.AppComplianceAutomation.Models.ResourceStatus?), string reason = null, string statusChangeDate = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.Category Category(string categoryName = null, Azure.ResourceManager.AppComplianceAutomation.Models.CategoryType? categoryType = default(Azure.ResourceManager.AppComplianceAutomation.Models.CategoryType?), Azure.ResourceManager.AppComplianceAutomation.Models.CategoryStatus? categoryStatus = default(Azure.ResourceManager.AppComplianceAutomation.Models.CategoryStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamily> controlFamilies = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceReportItem ComplianceReportItem(string categoryName = null, string controlId = null, string controlName = null, Azure.ResourceManager.AppComplianceAutomation.Models.ControlType? controlType = default(Azure.ResourceManager.AppComplianceAutomation.Models.ControlType?), Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceState? complianceState = default(Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceState?), string policyId = null, string policyDisplayName = null, string policyDescription = null, string subscriptionId = null, string resourceGroup = null, string resourceType = null, string resourceId = null, string statusChangeDate = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceResult ComplianceResult(string complianceName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.Category> categories = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.Control Control(string controlId = null, string controlShortName = null, string controlFullName = null, Azure.ResourceManager.AppComplianceAutomation.Models.ControlType? controlType = default(Azure.ResourceManager.AppComplianceAutomation.Models.ControlType?), string controlDescription = null, string controlDescriptionHyperLink = null, Azure.ResourceManager.AppComplianceAutomation.Models.ControlStatus? controlStatus = default(Azure.ResourceManager.AppComplianceAutomation.Models.ControlStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.Assessment> assessments = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamily ControlFamily(string familyName = null, Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyType? familyType = default(Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyType?), Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyStatus? familyStatus = default(Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.Control> controls = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.DownloadResponse DownloadResponse(System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceItem> resourceList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceReportItem> complianceReport = null, System.Uri compliancePdfReportSasUri = null, System.Uri complianceDetailedPdfReportSasUri = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.OverviewStatus OverviewStatus(int? passedCount = default(int?), int? failedCount = default(int?), int? manualCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ReportProperties ReportProperties(string id = null, Azure.ResourceManager.AppComplianceAutomation.Models.ReportStatus? status = default(Azure.ResourceManager.AppComplianceAutomation.Models.ReportStatus?), System.Guid? tenantId = default(System.Guid?), string reportName = null, string offerGuid = null, string timeZone = null, System.DateTimeOffset triggerOn = default(System.DateTimeOffset), System.DateTimeOffset? nextTriggerOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastTriggerOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> subscriptions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceMetadata> resources = null, Azure.ResourceManager.AppComplianceAutomation.Models.OverviewStatus complianceStatusM365 = null, Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.ReportResourceData ReportResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.AppComplianceAutomation.Models.ReportProperties properties = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ResourceItem ResourceItem(string subscriptionId = null, string resourceGroup = null, string resourceType = null, string resourceId = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotDownloadContent SnapshotDownloadContent(string reportCreatorTenantId = null, Azure.ResourceManager.AppComplianceAutomation.Models.DownloadType downloadType = default(Azure.ResourceManager.AppComplianceAutomation.Models.DownloadType), string offerGuid = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotProperties SnapshotProperties(string id = null, string snapshotName = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState?), Azure.ResourceManager.AppComplianceAutomation.Models.ReportProperties reportProperties = null, Azure.ResourceManager.Models.SystemData reportSystemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceResult> complianceResults = null) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.SnapshotResourceData SnapshotResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotProperties properties = null) { throw null; }
    }
    public partial class Assessment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.Assessment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.Assessment>
    {
        internal Assessment() { }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.IsPass? IsPass { get { throw null; } }
        public string Name { get { throw null; } }
        public string PolicyId { get { throw null; } }
        public string Remediation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.AssessmentResourceContent> ResourceList { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.AssessmentSeverity? Severity { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.Assessment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.Assessment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.Assessment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.Assessment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.Assessment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.Assessment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.Assessment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssessmentResourceContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AssessmentResourceContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AssessmentResourceContent>
    {
        internal AssessmentResourceContent() { }
        public string Reason { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ResourceStatus? ResourceStatus { get { throw null; } }
        public string StatusChangeDate { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.AssessmentResourceContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AssessmentResourceContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.AssessmentResourceContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.AssessmentResourceContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AssessmentResourceContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AssessmentResourceContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.AssessmentResourceContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentSeverity : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.AssessmentSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentSeverity(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AssessmentSeverity High { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AssessmentSeverity Low { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.AssessmentSeverity Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.AssessmentSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.AssessmentSeverity left, Azure.ResourceManager.AppComplianceAutomation.Models.AssessmentSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.AssessmentSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.AssessmentSeverity left, Azure.ResourceManager.AppComplianceAutomation.Models.AssessmentSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Category : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.Category>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.Category>
    {
        internal Category() { }
        public string CategoryName { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.CategoryStatus? CategoryStatus { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.CategoryType? CategoryType { get { throw null; } }
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
        public static Azure.ResourceManager.AppComplianceAutomation.Models.CategoryStatus Healthy { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.CategoryStatus Unhealthy { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CategoryType : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.CategoryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CategoryType(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.CategoryType FullyAutomated { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.CategoryType Manual { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.CategoryType PartiallyAutomated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.CategoryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.CategoryType left, Azure.ResourceManager.AppComplianceAutomation.Models.CategoryType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.CategoryType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.CategoryType left, Azure.ResourceManager.AppComplianceAutomation.Models.CategoryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComplianceReportItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceReportItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceReportItem>
    {
        internal ComplianceReportItem() { }
        public string CategoryName { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceState? ComplianceState { get { throw null; } }
        public string ControlId { get { throw null; } }
        public string ControlName { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ControlType? ControlType { get { throw null; } }
        public string PolicyDescription { get { throw null; } }
        public string PolicyDisplayName { get { throw null; } }
        public string PolicyId { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public string StatusChangeDate { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
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
    public readonly partial struct ComplianceState : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComplianceState(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceState Healthy { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceState Unhealthy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceState left, Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceState left, Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Control : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.Control>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.Control>
    {
        internal Control() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.Assessment> Assessments { get { throw null; } }
        public string ControlDescription { get { throw null; } }
        public string ControlDescriptionHyperLink { get { throw null; } }
        public string ControlFullName { get { throw null; } }
        public string ControlId { get { throw null; } }
        public string ControlShortName { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ControlStatus? ControlStatus { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ControlType? ControlType { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.Control System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.Control>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.Control>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.Control System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.Control>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.Control>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.Control>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ControlFamily : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamily>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamily>
    {
        internal ControlFamily() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.Control> Controls { get { throw null; } }
        public string FamilyName { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyStatus? FamilyStatus { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyType? FamilyType { get { throw null; } }
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
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyStatus Healthy { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyStatus Unhealthy { get { throw null; } }
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
    public readonly partial struct ControlFamilyType : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ControlFamilyType(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyType FullyAutomated { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyType Manual { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyType PartiallyAutomated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyType left, Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyType left, Azure.ResourceManager.AppComplianceAutomation.Models.ControlFamilyType right) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ControlType : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.ControlType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ControlType(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ControlType FullyAutomated { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ControlType Manual { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ControlType PartiallyAutomated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.ControlType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.ControlType left, Azure.ResourceManager.AppComplianceAutomation.Models.ControlType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.ControlType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.ControlType left, Azure.ResourceManager.AppComplianceAutomation.Models.ControlType right) { throw null; }
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
    public readonly partial struct IsPass : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.IsPass>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsPass(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.IsPass False { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.IsPass True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppComplianceAutomation.Models.IsPass other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppComplianceAutomation.Models.IsPass left, Azure.ResourceManager.AppComplianceAutomation.Models.IsPass right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppComplianceAutomation.Models.IsPass (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppComplianceAutomation.Models.IsPass left, Azure.ResourceManager.AppComplianceAutomation.Models.IsPass right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OverviewStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.OverviewStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.OverviewStatus>
    {
        internal OverviewStatus() { }
        public int? FailedCount { get { throw null; } }
        public int? ManualCount { get { throw null; } }
        public int? PassedCount { get { throw null; } }
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
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState Updating { get { throw null; } }
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
    public partial class ReportProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportProperties>
    {
        public ReportProperties(string timeZone, System.DateTimeOffset triggerOn, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceMetadata> resources) { }
        public Azure.ResourceManager.AppComplianceAutomation.Models.OverviewStatus ComplianceStatusM365 { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastTriggerOn { get { throw null; } }
        public System.DateTimeOffset? NextTriggerOn { get { throw null; } }
        public string OfferGuid { get { throw null; } set { } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ReportName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceMetadata> Resources { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ReportStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Subscriptions { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
        public System.DateTimeOffset TriggerOn { get { throw null; } set { } }
        Azure.ResourceManager.AppComplianceAutomation.Models.ReportProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ReportProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReportResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ReportResourcePatch>
    {
        public ReportResourcePatch() { }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ReportProperties Properties { get { throw null; } set { } }
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
        public string ResourceId { get { throw null; } set { } }
        public string ResourceKind { get { throw null; } set { } }
        public string ResourceName { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.ResourceMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.ResourceMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceStatus : System.IEquatable<Azure.ResourceManager.AppComplianceAutomation.Models.ResourceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceStatus(string value) { throw null; }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ResourceStatus Healthy { get { throw null; } }
        public static Azure.ResourceManager.AppComplianceAutomation.Models.ResourceStatus NotApplicable { get { throw null; } }
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
    public partial class SnapshotProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotProperties>
    {
        internal SnapshotProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppComplianceAutomation.Models.ComplianceResult> ComplianceResults { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.AppComplianceAutomation.Models.ReportProperties ReportProperties { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData ReportSystemData { get { throw null; } }
        public string SnapshotName { get { throw null; } }
        Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppComplianceAutomation.Models.SnapshotProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
