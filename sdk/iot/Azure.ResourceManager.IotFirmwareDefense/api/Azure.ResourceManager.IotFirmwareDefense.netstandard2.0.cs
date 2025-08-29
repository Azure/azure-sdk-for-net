namespace Azure.ResourceManager.IotFirmwareDefense
{
    public partial class AzureResourceManagerIotFirmwareDefenseContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerIotFirmwareDefenseContext() { }
        public static Azure.ResourceManager.IotFirmwareDefense.AzureResourceManagerIotFirmwareDefenseContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class FirmwareAnalysisSummaryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryResource>, System.Collections.IEnumerable
    {
        protected FirmwareAnalysisSummaryCollection() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryName summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryType summaryType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryName summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryType summaryType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryResource> Get(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryName summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryResource> Get(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryType summaryType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryResource>> GetAsync(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryName summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryResource>> GetAsync(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryType summaryType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.NullableResponse<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryResource> GetIfExists(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryName summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryResource> GetIfExists(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryType summaryType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryResource>> GetIfExistsAsync(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryName summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryResource>> GetIfExistsAsync(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryType summaryType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FirmwareAnalysisSummaryData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryData>
    {
        public FirmwareAnalysisSummaryData() { }
        public Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FirmwareAnalysisSummaryResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FirmwareAnalysisSummaryResource() { }
        public virtual Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string firmwareId, Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryName summaryName) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string firmwareId, Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryType summaryType) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FirmwareAnalysisWorkspaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource>, System.Collections.IEnumerable
    {
        protected FirmwareAnalysisWorkspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource> GetIfExists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource>> GetIfExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FirmwareAnalysisWorkspaceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceData>
    {
        public FirmwareAnalysisWorkspaceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareDefenseSku Sku { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FirmwareAnalysisWorkspaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FirmwareAnalysisWorkspaceResource() { }
        public virtual Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareUriToken> GenerateUploadUri(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareUploadUriContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareUriToken>> GenerateUploadUriAsync(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareUploadUriContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareResource> GetIotFirmware(string firmwareId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareResource>> GetIotFirmwareAsync(string firmwareId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotFirmwareDefense.IotFirmwareCollection GetIotFirmwares() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.UsageMetricResource> GetUsageMetric(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.UsageMetricResource>> GetUsageMetricAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotFirmwareDefense.UsageMetricCollection GetUsageMetrics() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource> Update(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource>> UpdateAsync(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IotFirmwareCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareResource>, System.Collections.IEnumerable
    {
        protected IotFirmwareCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string firmwareId, Azure.ResourceManager.IotFirmwareDefense.IotFirmwareData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string firmwareId, Azure.ResourceManager.IotFirmwareDefense.IotFirmwareData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string firmwareId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string firmwareId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareResource> Get(string firmwareId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareResource>> GetAsync(string firmwareId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareResource> GetIfExists(string firmwareId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareResource>> GetIfExistsAsync(string firmwareId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IotFirmwareData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareData>
    {
        public IotFirmwareData() { }
        public string Description { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public long? FileSize { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatus? Status { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatusMessage> StatusMessages { get { throw null; } }
        public string Vendor { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.IotFirmwareData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.IotFirmwareData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class IotFirmwareDefenseExtensions
    {
        public static Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryResource GetFirmwareAnalysisSummaryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource> GetFirmwareAnalysisWorkspace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource>> GetFirmwareAnalysisWorkspaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource GetFirmwareAnalysisWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceCollection GetFirmwareAnalysisWorkspaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource> GetFirmwareAnalysisWorkspaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource> GetFirmwareAnalysisWorkspacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.IotFirmwareResource GetIotFirmwareResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.UsageMetricResource GetUsageMetricResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class IotFirmwareResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotFirmwareResource() { }
        public virtual Azure.ResourceManager.IotFirmwareDefense.IotFirmwareData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string firmwareId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareUriToken> GenerateDownloadUri(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareUriToken>> GenerateDownloadUriAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareUriToken> GenerateFilesystemDownloadUri(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareUriToken>> GenerateFilesystemDownloadUriAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResult> GetBinaryHardeningResults(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResult> GetBinaryHardeningResultsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.Models.CveResult> GetCommonVulnerabilitiesAndExposures(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.Models.CveResult> GetCommonVulnerabilitiesAndExposuresAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateResult> GetCryptoCertificates(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateResult> GetCryptoCertificatesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeyResult> GetCryptoKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeyResult> GetCryptoKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.Models.CveResult> GetCves(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.Models.CveResult> GetCvesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryCollection GetFirmwareAnalysisSummaries() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryResource> GetFirmwareAnalysisSummary(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryName summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryResource> GetFirmwareAnalysisSummary(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryType summaryType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryResource>> GetFirmwareAnalysisSummaryAsync(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryName summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryResource>> GetFirmwareAnalysisSummaryAsync(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryType summaryType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHashResult> GetPasswordHashes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHashResult> GetPasswordHashesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResult> GetSbomComponents(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResult> GetSbomComponentsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.IotFirmwareDefense.IotFirmwareData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.IotFirmwareData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareResource> Update(Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwarePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareResource>> UpdateAsync(Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwarePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UsageMetricCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotFirmwareDefense.UsageMetricResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotFirmwareDefense.UsageMetricResource>, System.Collections.IEnumerable
    {
        protected UsageMetricCollection() { }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.UsageMetricResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.UsageMetricResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.UsageMetricResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.UsageMetricResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IotFirmwareDefense.UsageMetricResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IotFirmwareDefense.UsageMetricResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotFirmwareDefense.UsageMetricResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotFirmwareDefense.UsageMetricResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotFirmwareDefense.UsageMetricResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotFirmwareDefense.UsageMetricResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class UsageMetricData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.UsageMetricData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.UsageMetricData>
    {
        public UsageMetricData() { }
        public Azure.ResourceManager.IotFirmwareDefense.Models.UsageMetricProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.UsageMetricData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.UsageMetricData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.UsageMetricData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.UsageMetricData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.UsageMetricData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.UsageMetricData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.UsageMetricData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UsageMetricResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.UsageMetricData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.UsageMetricData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected UsageMetricResource() { }
        public virtual Azure.ResourceManager.IotFirmwareDefense.UsageMetricData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.UsageMetricResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.UsageMetricResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.IotFirmwareDefense.UsageMetricData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.UsageMetricData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.UsageMetricData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.UsageMetricData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.UsageMetricData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.UsageMetricData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.UsageMetricData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.IotFirmwareDefense.Mocking
{
    public partial class MockableIotFirmwareDefenseArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableIotFirmwareDefenseArmClient() { }
        public virtual Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryResource GetFirmwareAnalysisSummaryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource GetFirmwareAnalysisWorkspaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.IotFirmwareDefense.IotFirmwareResource GetIotFirmwareResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.IotFirmwareDefense.UsageMetricResource GetUsageMetricResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableIotFirmwareDefenseResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableIotFirmwareDefenseResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource> GetFirmwareAnalysisWorkspace(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource>> GetFirmwareAnalysisWorkspaceAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceCollection GetFirmwareAnalysisWorkspaces() { throw null; }
    }
    public partial class MockableIotFirmwareDefenseSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableIotFirmwareDefenseSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource> GetFirmwareAnalysisWorkspaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceResource> GetFirmwareAnalysisWorkspacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.IotFirmwareDefense.Models
{
    public static partial class ArmIotFirmwareDefenseModelFactory
    {
        public static Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResult BinaryHardeningResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string binaryHardeningId = null, Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningFeatures securityHardeningFeatures = null, string executableArchitecture = null, string filePath = null, Azure.ResourceManager.IotFirmwareDefense.Models.ExecutableClass? executableClass = default(Azure.ResourceManager.IotFirmwareDefense.Models.ExecutableClass?), string runpath = null, string rpath = null, Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState? provisioningState = default(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResult BinaryHardeningResult(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string binaryHardeningId, string architecture = null, string filePath = null, string @class = null, string runpath = null, string rpath = null, bool? nxFlag = default(bool?), bool? pieFlag = default(bool?), bool? relroFlag = default(bool?), bool? canaryFlag = default(bool?), bool? strippedFlag = default(bool?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningSummary BinaryHardeningSummary(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState? provisioningState = default(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState?), long? totalFiles = default(long?), long? notExecutableStackCount = default(long?), long? positionIndependentExecutableCount = default(long?), long? relocationReadOnlyCount = default(long?), long? stackCanaryCount = default(long?), long? strippedBinaryCount = default(long?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningSummary BinaryHardeningSummary(long? totalFiles = default(long?), int? nxPercentage = default(int?), int? piePercentage = default(int?), int? relroPercentage = default(int?), int? canaryPercentage = default(int?), int? strippedPercentage = default(int?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateResult CryptoCertificateResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string cryptoCertId = null, string certificateName = null, Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateEntity subject = null, Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateEntity issuer = null, System.DateTimeOffset? issuedOn = default(System.DateTimeOffset?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), string certificateRole = null, string signatureAlgorithm = null, long? certificateKeySize = default(long?), string certificateKeyAlgorithm = null, string encoding = null, string serialNumber = null, string fingerprint = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotFirmwareDefense.Models.CertificateUsage> certificateUsage = null, System.Collections.Generic.IEnumerable<string> filePaths = null, Azure.ResourceManager.IotFirmwareDefense.Models.CryptoPairedKey pairedKey = null, bool? isExpired = default(bool?), bool? isSelfSigned = default(bool?), bool? isWeakSignature = default(bool?), bool? isShortKeySize = default(bool?), Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState? provisioningState = default(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateResult CryptoCertificateResult(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string cryptoCertId, string namePropertiesName = null, Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateEntity subject = null, Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateEntity issuer = null, System.DateTimeOffset? issuedOn = default(System.DateTimeOffset?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), string role = null, string signatureAlgorithm = null, long? keySize = default(long?), string keyAlgorithm = null, string encoding = null, string serialNumber = null, string fingerprint = null, System.Collections.Generic.IEnumerable<string> usage = null, System.Collections.Generic.IEnumerable<string> filePaths = null, Azure.ResourceManager.IotFirmwareDefense.Models.CryptoPairedKey pairedKey = null, bool? isExpired = default(bool?), bool? isSelfSigned = default(bool?), bool? isWeakSignature = default(bool?), bool? isShortKeySize = default(bool?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateSummary CryptoCertificateSummary(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState? provisioningState = default(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState?), long? totalCertificateCount = default(long?), long? pairedKeyCount = default(long?), long? expiredCertificateCount = default(long?), long? expiringSoonCertificateCount = default(long?), long? weakSignatureCount = default(long?), long? selfSignedCertificateCount = default(long?), long? shortKeySizeCount = default(long?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateSummary CryptoCertificateSummary(long? totalCertificates = default(long?), long? pairedKeys = default(long?), long? expired = default(long?), long? expiringSoon = default(long?), long? weakSignature = default(long?), long? selfSigned = default(long?), long? shortKeySize = default(long?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeyResult CryptoKeyResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string cryptoKeyId = null, Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeyType? cryptoKeyType = default(Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeyType?), long? cryptoKeySize = default(long?), string keyAlgorithm = null, System.Collections.Generic.IEnumerable<string> cryptoKeyUsage = null, System.Collections.Generic.IEnumerable<string> filePaths = null, Azure.ResourceManager.IotFirmwareDefense.Models.CryptoPairedKey pairedKey = null, bool? isShortKeySize = default(bool?), Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState? provisioningState = default(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeyResult CryptoKeyResult(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string cryptoKeyId, string keyType, long? keySize = default(long?), string keyAlgorithm = null, System.Collections.Generic.IEnumerable<string> usage = null, System.Collections.Generic.IEnumerable<string> filePaths = null, Azure.ResourceManager.IotFirmwareDefense.Models.CryptoPairedKey pairedKey = null, bool? isShortKeySize = default(bool?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeySummary CryptoKeySummary(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState? provisioningState = default(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState?), long? totalKeyCount = default(long?), long? publicKeyCount = default(long?), long? privateKeyCount = default(long?), long? pairedKeyCount = default(long?), long? shortKeySizeCount = default(long?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeySummary CryptoKeySummary(long? totalKeys = default(long?), long? publicKeys = default(long?), long? privateKeys = default(long?), long? pairedKeys = default(long?), long? shortKeySize = default(long?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CveLink CveLink(System.Uri href = null, string label = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CveResult CveResult(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string cveId, Azure.ResourceManager.IotFirmwareDefense.Models.CveComponent component = null, string severity = null, string namePropertiesName = null, string cvssScore = null, string cvssVersion = null, string cvssV2Score = null, string cvssV3Score = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotFirmwareDefense.Models.CveLink> links = null, string description = null) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CveResult CveResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string cveId = null, string componentId = null, string componentName = null, string componentVersion = null, string severity = null, string cveName = null, Azure.ResourceManager.IotFirmwareDefense.Models.CveComponent component = null, string cvssScore = null, string cvssV2Score = null, string cvssV3Score = null, string cvssVersion = null, float? effectiveCvssScore = default(float?), int? effectiveCvssVersion = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotFirmwareDefense.Models.CvssScore> cvssScores = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotFirmwareDefense.Models.CveLink> links = null, string description = null, Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState? provisioningState = default(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary CveSummary(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState? provisioningState = default(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState?), long? criticalCveCount = default(long?), long? highCveCount = default(long?), long? mediumCveCount = default(long?), long? lowCveCount = default(long?), long? unknownCveCount = default(long?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary CveSummary(long? critical = default(long?), long? high = default(long?), long? medium = default(long?), long? low = default(long?), long? unknown = default(long?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisSummaryData FirmwareAnalysisSummaryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryProperties properties = null) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryProperties FirmwareAnalysisSummaryProperties(string summaryType = null, Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState? provisioningState = default(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceData FirmwareAnalysisWorkspaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareDefenseSku sku = null, Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState? provisioningState = default(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.IotFirmwareDefense.FirmwareAnalysisWorkspaceData FirmwareAnalysisWorkspaceData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState? provisioningState) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisWorkspacePatch FirmwareAnalysisWorkspacePatch(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState? provisioningState = default(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareSummary FirmwareSummary(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState? provisioningState = default(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState?), long? extractedSize = default(long?), long? fileSize = default(long?), long? extractedFileCount = default(long?), long? componentCount = default(long?), long? binaryCount = default(long?), long? analysisTimeSeconds = default(long?), long? rootFileSystems = default(long?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareSummary FirmwareSummary(long? extractedSize, long? fileSize, long? extractedFileCount, long? componentCount, long? binaryCount, long? analysisTimeSeconds, long? rootFileSystems) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareUriToken FirmwareUriToken(System.Uri uri = null) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.IotFirmwareData IotFirmwareData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string fileName = null, string vendor = null, string model = null, string version = null, string description = null, long? fileSize = default(long?), Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatus? status = default(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatusMessage> statusMessages = null, Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState? provisioningState = default(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwarePatch IotFirmwarePatch(string fileName = null, string vendor = null, string model = null, string version = null, string description = null, long? fileSize = default(long?), Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatus? status = default(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatusMessage> statusMessages = null, Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState? provisioningState = default(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHashResult PasswordHashResult(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string passwordHashId, string filePath, string salt, string hash, string context, string username, string algorithm) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHashResult PasswordHashResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string passwordHashId = null, string filePath = null, string salt = null, string hash = null, string context = null, string username = null, string algorithm = null, Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState? provisioningState = default(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResult SbomComponentResult(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string componentId, string componentName, string version, string license, System.Collections.Generic.IEnumerable<string> filePaths) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResult SbomComponentResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string componentId = null, string componentName = null, string version = null, string license = null, System.Collections.Generic.IEnumerable<string> filePaths = null, Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState? provisioningState = default(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.UsageMetricData UsageMetricData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.IotFirmwareDefense.Models.UsageMetricProperties properties = null) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.UsageMetricProperties UsageMetricProperties(long monthlyFirmwareUploadCount = (long)0, long totalFirmwareCount = (long)0, Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState? provisioningState = default(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState?)) { throw null; }
    }
    public partial class BinaryHardeningFeatures : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningFeatures>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningFeatures>
    {
        public BinaryHardeningFeatures() { }
        public bool? Canary { get { throw null; } set { } }
        public bool? NoExecute { get { throw null; } set { } }
        public bool? PositionIndependentExecutable { get { throw null; } set { } }
        public bool? RelocationReadOnly { get { throw null; } set { } }
        public bool? Stripped { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningFeatures System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningFeatures>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningFeatures>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningFeatures System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningFeatures>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningFeatures>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningFeatures>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BinaryHardeningResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResult>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public BinaryHardeningResult() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Architecture { get { throw null; } set { } }
        public string BinaryHardeningId { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? CanaryFlag { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Class { get { throw null; } set { } }
        public string ExecutableArchitecture { get { throw null; } set { } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.ExecutableClass? ExecutableClass { get { throw null; } set { } }
        public string FilePath { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? NXFlag { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? PieFlag { get { throw null; } set { } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState? ProvisioningState { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? RelroFlag { get { throw null; } set { } }
        public string Rpath { get { throw null; } set { } }
        public string Runpath { get { throw null; } set { } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningFeatures SecurityHardeningFeatures { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? StrippedFlag { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BinaryHardeningSummary : Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningSummary>
    {
        public BinaryHardeningSummary() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public int? CanaryPercentage { get { throw null; } }
        public long? NotExecutableStackCount { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public int? NXPercentage { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public int? PiePercentage { get { throw null; } }
        public long? PositionIndependentExecutableCount { get { throw null; } set { } }
        public long? RelocationReadOnlyCount { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public int? RelroPercentage { get { throw null; } }
        public long? StackCanaryCount { get { throw null; } set { } }
        public long? StrippedBinaryCount { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public int? StrippedPercentage { get { throw null; } }
        public long? TotalFiles { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateUsage : System.IEquatable<Azure.ResourceManager.IotFirmwareDefense.Models.CertificateUsage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateUsage(string value) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CertificateUsage ClientAuthentication { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CertificateUsage CodeSigning { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CertificateUsage ContentCommitment { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CertificateUsage CRLSign { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CertificateUsage DataEncipherment { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CertificateUsage DecipherOnly { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CertificateUsage DigitalSignature { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CertificateUsage EmailProtection { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CertificateUsage EncipherOnly { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CertificateUsage KeyAgreement { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CertificateUsage KeyCertSign { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CertificateUsage KeyEncipherment { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CertificateUsage NonRepudiation { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CertificateUsage OcspSigning { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CertificateUsage ServerAuthentication { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CertificateUsage TimeStamping { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotFirmwareDefense.Models.CertificateUsage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotFirmwareDefense.Models.CertificateUsage left, Azure.ResourceManager.IotFirmwareDefense.Models.CertificateUsage right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotFirmwareDefense.Models.CertificateUsage (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotFirmwareDefense.Models.CertificateUsage left, Azure.ResourceManager.IotFirmwareDefense.Models.CertificateUsage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CryptoCertificateEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateEntity>
    {
        public CryptoCertificateEntity() { }
        public string CommonName { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string Organization { get { throw null; } set { } }
        public string OrganizationalUnit { get { throw null; } set { } }
        public string State { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CryptoCertificateResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateResult>
    {
        public CryptoCertificateResult() { }
        public string CertificateKeyAlgorithm { get { throw null; } set { } }
        public long? CertificateKeySize { get { throw null; } set { } }
        public string CertificateName { get { throw null; } set { } }
        public string CertificateRole { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotFirmwareDefense.Models.CertificateUsage> CertificateUsage { get { throw null; } }
        public string CryptoCertId { get { throw null; } set { } }
        public string Encoding { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> FilePaths { get { throw null; } }
        public string Fingerprint { get { throw null; } set { } }
        public bool? IsExpired { get { throw null; } set { } }
        public bool? IsSelfSigned { get { throw null; } set { } }
        public bool? IsShortKeySize { get { throw null; } set { } }
        public System.DateTimeOffset? IssuedOn { get { throw null; } set { } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateEntity Issuer { get { throw null; } set { } }
        public bool? IsWeakSignature { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string KeyAlgorithm { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public long? KeySize { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string NamePropertiesName { get { throw null; } set { } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.CryptoPairedKey PairedKey { get { throw null; } set { } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState? ProvisioningState { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Role { get { throw null; } set { } }
        public string SerialNumber { get { throw null; } set { } }
        public string SignatureAlgorithm { get { throw null; } set { } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateEntity Subject { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IList<string> Usage { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CryptoCertificateSummary : Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateSummary>
    {
        public CryptoCertificateSummary() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public long? Expired { get { throw null; } }
        public long? ExpiredCertificateCount { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public long? ExpiringSoon { get { throw null; } }
        public long? ExpiringSoonCertificateCount { get { throw null; } set { } }
        public long? PairedKeyCount { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public long? PairedKeys { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public long? SelfSigned { get { throw null; } }
        public long? SelfSignedCertificateCount { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public long? ShortKeySize { get { throw null; } }
        public long? ShortKeySizeCount { get { throw null; } set { } }
        public long? TotalCertificateCount { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public long? TotalCertificates { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public long? WeakSignature { get { throw null; } }
        public long? WeakSignatureCount { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoCertificateSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CryptoKeyResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeyResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeyResult>
    {
        public CryptoKeyResult() { }
        public string CryptoKeyId { get { throw null; } set { } }
        public long? CryptoKeySize { get { throw null; } set { } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeyType? CryptoKeyType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> CryptoKeyUsage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> FilePaths { get { throw null; } }
        public bool? IsShortKeySize { get { throw null; } set { } }
        public string KeyAlgorithm { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public long? KeySize { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string KeyType { get { throw null; } set { } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.CryptoPairedKey PairedKey { get { throw null; } set { } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState? ProvisioningState { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IList<string> Usage { get { throw null; } [System.ObsoleteAttribute("This property is now deprecated. Please use the new property `CryptoKeyUsage` moving forward.")] set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeyResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeyResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeyResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeyResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeyResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeyResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeyResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CryptoKeySummary : Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeySummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeySummary>
    {
        public CryptoKeySummary() { }
        public long? PairedKeyCount { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public long? PairedKeys { get { throw null; } }
        public long? PrivateKeyCount { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public long? PrivateKeys { get { throw null; } }
        public long? PublicKeyCount { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public long? PublicKeys { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public long? ShortKeySize { get { throw null; } }
        public long? ShortKeySizeCount { get { throw null; } set { } }
        public long? TotalKeyCount { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public long? TotalKeys { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeySummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeySummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeySummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeySummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeySummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeySummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeySummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CryptoKeyType : System.IEquatable<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CryptoKeyType(string value) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeyType Private { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeyType Public { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeyType left, Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeyType left, Azure.ResourceManager.IotFirmwareDefense.Models.CryptoKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CryptoPairedKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoPairedKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoPairedKey>
    {
        public CryptoPairedKey() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Id { get { throw null; } set { } }
        public string PairedKeyId { get { throw null; } set { } }
        public string PairedKeyType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.CryptoPairedKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoPairedKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoPairedKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.CryptoPairedKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoPairedKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoPairedKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CryptoPairedKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CveComponent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveComponent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveComponent>
    {
        public CveComponent() { }
        public string ComponentId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.CveComponent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveComponent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveComponent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.CveComponent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveComponent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveComponent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveComponent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CveLink : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveLink>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveLink>
    {
        internal CveLink() { }
        public System.Uri Href { get { throw null; } }
        public string Label { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.CveLink System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveLink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveLink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.CveLink System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveLink>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveLink>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveLink>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CveResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveResult>
    {
        public CveResult() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.IotFirmwareDefense.Models.CveComponent Component { get { throw null; } set { } }
        public string ComponentId { get { throw null; } set { } }
        public string ComponentName { get { throw null; } set { } }
        public string ComponentVersion { get { throw null; } set { } }
        public string CveId { get { throw null; } set { } }
        public string CveName { get { throw null; } set { } }
        public string CvssScore { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotFirmwareDefense.Models.CvssScore> CvssScores { get { throw null; } }
        public string CvssV2Score { get { throw null; } set { } }
        public string CvssV3Score { get { throw null; } set { } }
        public string CvssVersion { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public float? EffectiveCvssScore { get { throw null; } set { } }
        public int? EffectiveCvssVersion { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.IotFirmwareDefense.Models.CveLink> Links { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string NamePropertiesName { get { throw null; } set { } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState? ProvisioningState { get { throw null; } }
        public string Severity { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.CveResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.CveResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CveSummary : Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary>
    {
        public CveSummary() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public long? Critical { get { throw null; } }
        public long? CriticalCveCount { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public long? High { get { throw null; } }
        public long? HighCveCount { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public long? Low { get { throw null; } }
        public long? LowCveCount { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public long? Medium { get { throw null; } }
        public long? MediumCveCount { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public long? Unknown { get { throw null; } }
        public long? UnknownCveCount { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CvssScore : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CvssScore>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CvssScore>
    {
        public CvssScore(int version) { }
        public float? Score { get { throw null; } set { } }
        public int Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.CvssScore System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CvssScore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CvssScore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.CvssScore System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CvssScore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CvssScore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CvssScore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExecutableClass : System.IEquatable<Azure.ResourceManager.IotFirmwareDefense.Models.ExecutableClass>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExecutableClass(string value) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.ExecutableClass X64 { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.ExecutableClass X86 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotFirmwareDefense.Models.ExecutableClass other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotFirmwareDefense.Models.ExecutableClass left, Azure.ResourceManager.IotFirmwareDefense.Models.ExecutableClass right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotFirmwareDefense.Models.ExecutableClass (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotFirmwareDefense.Models.ExecutableClass left, Azure.ResourceManager.IotFirmwareDefense.Models.ExecutableClass right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FirmwareAnalysisStatus : System.IEquatable<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FirmwareAnalysisStatus(string value) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatus Analyzing { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatus Error { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatus Extracting { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatus Ready { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatus left, Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatus left, Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FirmwareAnalysisStatusMessage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatusMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatusMessage>
    {
        public FirmwareAnalysisStatusMessage() { }
        public long? ErrorCode { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatusMessage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatusMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatusMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatusMessage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatusMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatusMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatusMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FirmwareAnalysisSummaryName : System.IEquatable<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public FirmwareAnalysisSummaryName(string value) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryName BinaryHardening { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryName CryptoCertificate { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryName CryptoKey { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryName Cve { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryName Firmware { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static bool operator ==(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryName left, Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryName right) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static implicit operator Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryName (string value) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static bool operator !=(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryName left, Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryName right) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public abstract partial class FirmwareAnalysisSummaryProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryProperties>
    {
        protected FirmwareAnalysisSummaryProperties() { }
        public Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FirmwareAnalysisSummaryType : System.IEquatable<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FirmwareAnalysisSummaryType(string value) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryType BinaryHardening { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryType CommonVulnerabilitiesAndExposures { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryType CryptoCertificate { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryType CryptoKey { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryType Firmware { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryType left, Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryType left, Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FirmwareAnalysisWorkspacePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisWorkspacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisWorkspacePatch>
    {
        public FirmwareAnalysisWorkspacePatch() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareDefenseSkuUpdate Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisWorkspacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisWorkspacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisWorkspacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisWorkspacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisWorkspacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisWorkspacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisWorkspacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FirmwareProvisioningState : System.IEquatable<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FirmwareProvisioningState(string value) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState Analyzing { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState Extracting { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState left, Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState left, Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FirmwareSummary : Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisSummaryProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareSummary>
    {
        public FirmwareSummary() { }
        public long? AnalysisTimeSeconds { get { throw null; } set { } }
        public long? BinaryCount { get { throw null; } set { } }
        public long? ComponentCount { get { throw null; } set { } }
        public long? ExtractedFileCount { get { throw null; } set { } }
        public long? ExtractedSize { get { throw null; } set { } }
        public long? FileSize { get { throw null; } set { } }
        public long? RootFileSystems { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FirmwareUploadUriContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareUploadUriContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareUploadUriContent>
    {
        public FirmwareUploadUriContent() { }
        public string FirmwareId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareUploadUriContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareUploadUriContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareUploadUriContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareUploadUriContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareUploadUriContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareUploadUriContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareUploadUriContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FirmwareUriToken : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareUriToken>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareUriToken>
    {
        internal FirmwareUriToken() { }
        public System.Uri Uri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareUriToken System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareUriToken>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareUriToken>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareUriToken System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareUriToken>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareUriToken>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareUriToken>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotFirmwareDefenseSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareDefenseSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareDefenseSku>
    {
        public IotFirmwareDefenseSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareDefenseSkuTier? Tier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareDefenseSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareDefenseSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareDefenseSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareDefenseSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareDefenseSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareDefenseSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareDefenseSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum IotFirmwareDefenseSkuTier
    {
        Free = 0,
        Basic = 1,
        Standard = 2,
        Premium = 3,
    }
    public partial class IotFirmwareDefenseSkuUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareDefenseSkuUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareDefenseSkuUpdate>
    {
        public IotFirmwareDefenseSkuUpdate() { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareDefenseSkuTier? Tier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareDefenseSkuUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareDefenseSkuUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareDefenseSkuUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareDefenseSkuUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareDefenseSkuUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareDefenseSkuUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareDefenseSkuUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotFirmwarePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwarePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwarePatch>
    {
        public IotFirmwarePatch() { }
        public string Description { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public long? FileSize { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatus? Status { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatusMessage> StatusMessages { get { throw null; } }
        public string Vendor { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwarePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwarePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwarePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwarePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwarePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwarePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwarePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PasswordHashResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHashResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHashResult>
    {
        public PasswordHashResult() { }
        public string Algorithm { get { throw null; } set { } }
        public string Context { get { throw null; } set { } }
        public string FilePath { get { throw null; } set { } }
        public string Hash { get { throw null; } set { } }
        public string PasswordHashId { get { throw null; } set { } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState? ProvisioningState { get { throw null; } }
        public string Salt { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHashResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHashResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHashResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHashResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHashResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHashResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHashResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SbomComponentResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResult>
    {
        public SbomComponentResult() { }
        public string ComponentId { get { throw null; } set { } }
        public string ComponentName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> FilePaths { get { throw null; } }
        public string License { get { throw null; } set { } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState? ProvisioningState { get { throw null; } }
        public string Version { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UsageMetricProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.UsageMetricProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.UsageMetricProperties>
    {
        public UsageMetricProperties(long monthlyFirmwareUploadCount, long totalFirmwareCount) { }
        public long MonthlyFirmwareUploadCount { get { throw null; } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareProvisioningState? ProvisioningState { get { throw null; } }
        public long TotalFirmwareCount { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.UsageMetricProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.UsageMetricProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.UsageMetricProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.UsageMetricProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.UsageMetricProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.UsageMetricProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.UsageMetricProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
