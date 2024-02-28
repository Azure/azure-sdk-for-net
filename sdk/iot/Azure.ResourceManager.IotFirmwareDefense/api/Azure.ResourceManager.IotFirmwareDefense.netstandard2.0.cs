namespace Azure.ResourceManager.IotFirmwareDefense
{
    public partial class IotFirmwareAnalysisSummaryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareAnalysisSummaryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareAnalysisSummaryResource>, System.Collections.IEnumerable
    {
        protected IotFirmwareAnalysisSummaryCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.IotFirmwareDefense.Models.SummaryName summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.IotFirmwareDefense.Models.SummaryName summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareAnalysisSummaryResource> Get(Azure.ResourceManager.IotFirmwareDefense.Models.SummaryName summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareAnalysisSummaryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareAnalysisSummaryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareAnalysisSummaryResource>> GetAsync(Azure.ResourceManager.IotFirmwareDefense.Models.SummaryName summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareAnalysisSummaryResource> GetIfExists(Azure.ResourceManager.IotFirmwareDefense.Models.SummaryName summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareAnalysisSummaryResource>> GetIfExistsAsync(Azure.ResourceManager.IotFirmwareDefense.Models.SummaryName summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareAnalysisSummaryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareAnalysisSummaryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareAnalysisSummaryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareAnalysisSummaryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IotFirmwareAnalysisSummaryData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareAnalysisSummaryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareAnalysisSummaryData>
    {
        public IotFirmwareAnalysisSummaryData() { }
        public Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareAnalysisSummaryProperties Properties { get { throw null; } }
        Azure.ResourceManager.IotFirmwareDefense.IotFirmwareAnalysisSummaryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareAnalysisSummaryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareAnalysisSummaryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.IotFirmwareAnalysisSummaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareAnalysisSummaryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareAnalysisSummaryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareAnalysisSummaryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotFirmwareAnalysisSummaryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotFirmwareAnalysisSummaryResource() { }
        public virtual Azure.ResourceManager.IotFirmwareDefense.IotFirmwareAnalysisSummaryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string firmwareId, Azure.ResourceManager.IotFirmwareDefense.Models.SummaryName summaryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareAnalysisSummaryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareAnalysisSummaryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareScanStatus? Status { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatusMessage> StatusMessages { get { throw null; } }
        public string Vendor { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        Azure.ResourceManager.IotFirmwareDefense.IotFirmwareData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.IotFirmwareData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class IotFirmwareDefenseExtensions
    {
        public static Azure.ResourceManager.IotFirmwareDefense.IotFirmwareAnalysisSummaryResource GetIotFirmwareAnalysisSummaryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.IotFirmwareResource GetIotFirmwareResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceResource> GetIotFirmwareWorkspace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceResource>> GetIotFirmwareWorkspaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceResource GetIotFirmwareWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceCollection GetIotFirmwareWorkspaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceResource> GetIotFirmwareWorkspaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceResource> GetIotFirmwareWorkspacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IotFirmwareResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotFirmwareResource() { }
        public virtual Azure.ResourceManager.IotFirmwareDefense.IotFirmwareData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string firmwareId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.Models.UriToken> GenerateDownloadUri(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.Models.UriToken>> GenerateDownloadUriAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.Models.UriToken> GenerateFilesystemDownloadUri(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.Models.UriToken>> GenerateFilesystemDownloadUriAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResult> GetBinaryHardeningResults(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResult> GetBinaryHardeningResultsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateResult> GetCryptoCertificates(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateResult> GetCryptoCertificatesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeyResult> GetCryptoKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeyResult> GetCryptoKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.Models.CveResult> GetCves(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.Models.CveResult> GetCvesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotFirmwareDefense.IotFirmwareAnalysisSummaryCollection GetIotFirmwareAnalysisSummaries() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareAnalysisSummaryResource> GetIotFirmwareAnalysisSummary(Azure.ResourceManager.IotFirmwareDefense.Models.SummaryName summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareAnalysisSummaryResource>> GetIotFirmwareAnalysisSummaryAsync(Azure.ResourceManager.IotFirmwareDefense.Models.SummaryName summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHashResult> GetPasswordHashes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHashResult> GetPasswordHashesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResult> GetSbomComponents(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResult> GetSbomComponentsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareResource> Update(Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwarePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareResource>> UpdateAsync(Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwarePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IotFirmwareWorkspaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceResource>, System.Collections.IEnumerable
    {
        protected IotFirmwareWorkspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceResource> GetIfExists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceResource>> GetIfExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IotFirmwareWorkspaceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceData>
    {
        public IotFirmwareWorkspaceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotFirmwareWorkspaceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotFirmwareWorkspaceResource() { }
        public virtual Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.Models.UriToken> GenerateUploadUri(Azure.ResourceManager.IotFirmwareDefense.Models.UploadUriContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.Models.UriToken>> GenerateUploadUriAsync(Azure.ResourceManager.IotFirmwareDefense.Models.UploadUriContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareResource> GetIotFirmware(string firmwareId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareResource>> GetIotFirmwareAsync(string firmwareId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotFirmwareDefense.IotFirmwareCollection GetIotFirmwares() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceResource> Update(Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceResource>> UpdateAsync(Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.IotFirmwareDefense.Mocking
{
    public partial class MockableIotFirmwareDefenseArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableIotFirmwareDefenseArmClient() { }
        public virtual Azure.ResourceManager.IotFirmwareDefense.IotFirmwareAnalysisSummaryResource GetIotFirmwareAnalysisSummaryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.IotFirmwareDefense.IotFirmwareResource GetIotFirmwareResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceResource GetIotFirmwareWorkspaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableIotFirmwareDefenseResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableIotFirmwareDefenseResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceResource> GetIotFirmwareWorkspace(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceResource>> GetIotFirmwareWorkspaceAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceCollection GetIotFirmwareWorkspaces() { throw null; }
    }
    public partial class MockableIotFirmwareDefenseSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableIotFirmwareDefenseSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceResource> GetIotFirmwareWorkspaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceResource> GetIotFirmwareWorkspacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.IotFirmwareDefense.Models
{
    public static partial class ArmIotFirmwareDefenseModelFactory
    {
        public static Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResult BinaryHardeningResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string binaryHardeningId = null, string architecture = null, string filePath = null, string @class = null, string runpath = null, string rpath = null, bool? nxFlag = default(bool?), bool? pieFlag = default(bool?), bool? relroFlag = default(bool?), bool? canaryFlag = default(bool?), bool? strippedFlag = default(bool?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningSummary BinaryHardeningSummary(long? totalFiles = default(long?), int? nxPercentage = default(int?), int? piePercentage = default(int?), int? relroPercentage = default(int?), int? canaryPercentage = default(int?), int? strippedPercentage = default(int?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CveLink CveLink(System.Uri href = null, string label = null) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CveResult CveResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string cveId = null, Azure.ResourceManager.IotFirmwareDefense.Models.CveComponent component = null, string severity = null, string namePropertiesName = null, string cvssScore = null, string cvssVersion = null, string cvssV2Score = null, string cvssV3Score = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotFirmwareDefense.Models.CveLink> links = null, string description = null) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary CveSummary(long? critical = default(long?), long? high = default(long?), long? medium = default(long?), long? low = default(long?), long? unknown = default(long?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateResult FirmwareCryptoCertificateResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string cryptoCertId = null, string namePropertiesName = null, Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateEntity subject = null, Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateEntity issuer = null, System.DateTimeOffset? issuedOn = default(System.DateTimeOffset?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), string role = null, string signatureAlgorithm = null, long? keySize = default(long?), string keyAlgorithm = null, string encoding = null, string serialNumber = null, string fingerprint = null, System.Collections.Generic.IEnumerable<string> usage = null, System.Collections.Generic.IEnumerable<string> filePaths = null, Azure.ResourceManager.IotFirmwareDefense.Models.PairedKey pairedKey = null, bool? isExpired = default(bool?), bool? isSelfSigned = default(bool?), bool? isWeakSignature = default(bool?), bool? isShortKeySize = default(bool?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateSummary FirmwareCryptoCertificateSummary(long? totalCertificates = default(long?), long? pairedKeys = default(long?), long? expired = default(long?), long? expiringSoon = default(long?), long? weakSignature = default(long?), long? selfSigned = default(long?), long? shortKeySize = default(long?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeyResult FirmwareCryptoKeyResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string firmwareCryptoKeyId = null, string keyType = null, long? keySize = default(long?), string keyAlgorithm = null, System.Collections.Generic.IEnumerable<string> usage = null, System.Collections.Generic.IEnumerable<string> filePaths = null, Azure.ResourceManager.IotFirmwareDefense.Models.PairedKey pairedKey = null, bool? isShortKeySize = default(bool?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeySummary FirmwareCryptoKeySummary(long? totalKeys = default(long?), long? publicKeys = default(long?), long? privateKeys = default(long?), long? pairedKeys = default(long?), long? shortKeySize = default(long?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareSummary FirmwareSummary(long? extractedSize = default(long?), long? fileSize = default(long?), long? extractedFileCount = default(long?), long? componentCount = default(long?), long? binaryCount = default(long?), long? analysisTimeSeconds = default(long?), long? rootFileSystems = default(long?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.IotFirmwareAnalysisSummaryData IotFirmwareAnalysisSummaryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareAnalysisSummaryProperties properties = null) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.IotFirmwareData IotFirmwareData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string fileName = null, string vendor = null, string model = null, string version = null, string description = null, long? fileSize = default(long?), Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareScanStatus? status = default(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareScanStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatusMessage> statusMessages = null, Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareProvisioningState? provisioningState = default(Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwarePatch IotFirmwarePatch(string fileName = null, string vendor = null, string model = null, string version = null, string description = null, long? fileSize = default(long?), Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareScanStatus? status = default(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareScanStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatusMessage> statusMessages = null, Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareProvisioningState? provisioningState = default(Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.IotFirmwareWorkspaceData IotFirmwareWorkspaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareProvisioningState? provisioningState = default(Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareWorkspacePatch IotFirmwareWorkspacePatch(Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareProvisioningState? provisioningState = default(Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHashResult PasswordHashResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string passwordHashId = null, string filePath = null, string salt = null, string hash = null, string context = null, string username = null, string algorithm = null) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResult SbomComponentResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string componentId = null, string componentName = null, string version = null, string license = null, System.Collections.Generic.IEnumerable<string> filePaths = null) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.UriToken UriToken(System.Uri uri = null) { throw null; }
    }
    public partial class BinaryHardeningResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResult>
    {
        public BinaryHardeningResult() { }
        public string Architecture { get { throw null; } set { } }
        public string BinaryHardeningId { get { throw null; } set { } }
        public bool? CanaryFlag { get { throw null; } set { } }
        public string Class { get { throw null; } set { } }
        public string FilePath { get { throw null; } set { } }
        public bool? NXFlag { get { throw null; } set { } }
        public bool? PieFlag { get { throw null; } set { } }
        public bool? RelroFlag { get { throw null; } set { } }
        public string Rpath { get { throw null; } set { } }
        public string Runpath { get { throw null; } set { } }
        public bool? StrippedFlag { get { throw null; } set { } }
        Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BinaryHardeningSummary : Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareAnalysisSummaryProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningSummary>
    {
        internal BinaryHardeningSummary() { }
        public int? CanaryPercentage { get { throw null; } }
        public int? NXPercentage { get { throw null; } }
        public int? PiePercentage { get { throw null; } }
        public int? RelroPercentage { get { throw null; } }
        public int? StrippedPercentage { get { throw null; } }
        public long? TotalFiles { get { throw null; } }
        Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CveComponent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveComponent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveComponent>
    {
        public CveComponent() { }
        public string ComponentId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
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
        Azure.ResourceManager.IotFirmwareDefense.Models.CveLink System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveLink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveLink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.CveLink System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveLink>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveLink>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveLink>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CveResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveResult>
    {
        public CveResult() { }
        public Azure.ResourceManager.IotFirmwareDefense.Models.CveComponent Component { get { throw null; } set { } }
        public string CveId { get { throw null; } set { } }
        public string CvssScore { get { throw null; } set { } }
        public string CvssV2Score { get { throw null; } set { } }
        public string CvssV3Score { get { throw null; } set { } }
        public string CvssVersion { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.IotFirmwareDefense.Models.CveLink> Links { get { throw null; } }
        public string NamePropertiesName { get { throw null; } set { } }
        public string Severity { get { throw null; } set { } }
        Azure.ResourceManager.IotFirmwareDefense.Models.CveResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.CveResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CveSummary : Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareAnalysisSummaryProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary>
    {
        internal CveSummary() { }
        public long? Critical { get { throw null; } }
        public long? High { get { throw null; } }
        public long? Low { get { throw null; } }
        public long? Medium { get { throw null; } }
        public long? Unknown { get { throw null; } }
        Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FirmwareAnalysisStatusMessage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatusMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatusMessage>
    {
        public FirmwareAnalysisStatusMessage() { }
        public long? ErrorCode { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatusMessage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatusMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatusMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatusMessage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatusMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatusMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatusMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FirmwareCryptoCertificateEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateEntity>
    {
        public FirmwareCryptoCertificateEntity() { }
        public string CommonName { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string Organization { get { throw null; } set { } }
        public string OrganizationalUnit { get { throw null; } set { } }
        public string State { get { throw null; } set { } }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FirmwareCryptoCertificateResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateResult>
    {
        public FirmwareCryptoCertificateResult() { }
        public string CryptoCertId { get { throw null; } set { } }
        public string Encoding { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> FilePaths { get { throw null; } }
        public string Fingerprint { get { throw null; } set { } }
        public bool? IsExpired { get { throw null; } set { } }
        public bool? IsSelfSigned { get { throw null; } set { } }
        public bool? IsShortKeySize { get { throw null; } set { } }
        public System.DateTimeOffset? IssuedOn { get { throw null; } set { } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateEntity Issuer { get { throw null; } set { } }
        public bool? IsWeakSignature { get { throw null; } set { } }
        public string KeyAlgorithm { get { throw null; } set { } }
        public long? KeySize { get { throw null; } set { } }
        public string NamePropertiesName { get { throw null; } set { } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.PairedKey PairedKey { get { throw null; } set { } }
        public string Role { get { throw null; } set { } }
        public string SerialNumber { get { throw null; } set { } }
        public string SignatureAlgorithm { get { throw null; } set { } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateEntity Subject { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Usage { get { throw null; } set { } }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FirmwareCryptoCertificateSummary : Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareAnalysisSummaryProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateSummary>
    {
        internal FirmwareCryptoCertificateSummary() { }
        public long? Expired { get { throw null; } }
        public long? ExpiringSoon { get { throw null; } }
        public long? PairedKeys { get { throw null; } }
        public long? SelfSigned { get { throw null; } }
        public long? ShortKeySize { get { throw null; } }
        public long? TotalCertificates { get { throw null; } }
        public long? WeakSignature { get { throw null; } }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FirmwareCryptoKeyResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeyResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeyResult>
    {
        public FirmwareCryptoKeyResult() { }
        public System.Collections.Generic.IReadOnlyList<string> FilePaths { get { throw null; } }
        public string FirmwareCryptoKeyId { get { throw null; } set { } }
        public bool? IsShortKeySize { get { throw null; } set { } }
        public string KeyAlgorithm { get { throw null; } set { } }
        public long? KeySize { get { throw null; } set { } }
        public string KeyType { get { throw null; } set { } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.PairedKey PairedKey { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Usage { get { throw null; } set { } }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeyResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeyResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeyResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeyResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeyResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeyResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeyResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FirmwareCryptoKeySummary : Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareAnalysisSummaryProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeySummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeySummary>
    {
        internal FirmwareCryptoKeySummary() { }
        public long? PairedKeys { get { throw null; } }
        public long? PrivateKeys { get { throw null; } }
        public long? PublicKeys { get { throw null; } }
        public long? ShortKeySize { get { throw null; } }
        public long? TotalKeys { get { throw null; } }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeySummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeySummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeySummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeySummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeySummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeySummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeySummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FirmwareScanStatus : System.IEquatable<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareScanStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FirmwareScanStatus(string value) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareScanStatus Analyzing { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareScanStatus Error { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareScanStatus Extracting { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareScanStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareScanStatus Ready { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareScanStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareScanStatus left, Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareScanStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareScanStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareScanStatus left, Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareScanStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FirmwareSummary : Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareAnalysisSummaryProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareSummary>
    {
        internal FirmwareSummary() { }
        public long? AnalysisTimeSeconds { get { throw null; } }
        public long? BinaryCount { get { throw null; } }
        public long? ComponentCount { get { throw null; } }
        public long? ExtractedFileCount { get { throw null; } }
        public long? ExtractedSize { get { throw null; } }
        public long? FileSize { get { throw null; } }
        public long? RootFileSystems { get { throw null; } }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class IotFirmwareAnalysisSummaryProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareAnalysisSummaryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareAnalysisSummaryProperties>
    {
        protected IotFirmwareAnalysisSummaryProperties() { }
        Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareAnalysisSummaryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareAnalysisSummaryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareAnalysisSummaryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareAnalysisSummaryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareAnalysisSummaryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareAnalysisSummaryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareAnalysisSummaryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotFirmwarePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwarePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwarePatch>
    {
        public IotFirmwarePatch() { }
        public string Description { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public long? FileSize { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareScanStatus? Status { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareAnalysisStatusMessage> StatusMessages { get { throw null; } }
        public string Vendor { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwarePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwarePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwarePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwarePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwarePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwarePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwarePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotFirmwareProvisioningState : System.IEquatable<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotFirmwareProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareProvisioningState left, Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareProvisioningState left, Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotFirmwareWorkspacePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareWorkspacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareWorkspacePatch>
    {
        public IotFirmwareWorkspacePatch() { }
        public Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareWorkspacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareWorkspacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareWorkspacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareWorkspacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareWorkspacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareWorkspacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.IotFirmwareWorkspacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PairedKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.PairedKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.PairedKey>
    {
        public PairedKey() { }
        public string Id { get { throw null; } set { } }
        public string PairedKeyType { get { throw null; } set { } }
        Azure.ResourceManager.IotFirmwareDefense.Models.PairedKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.PairedKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.PairedKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.PairedKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.PairedKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.PairedKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.PairedKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PasswordHashResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHashResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHashResult>
    {
        public PasswordHashResult() { }
        public string Algorithm { get { throw null; } set { } }
        public string Context { get { throw null; } set { } }
        public string FilePath { get { throw null; } set { } }
        public string Hash { get { throw null; } set { } }
        public string PasswordHashId { get { throw null; } set { } }
        public string Salt { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
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
        public string Version { get { throw null; } set { } }
        Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SummaryName : System.IEquatable<Azure.ResourceManager.IotFirmwareDefense.Models.SummaryName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SummaryName(string value) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.SummaryName BinaryHardening { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.SummaryName CVE { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.SummaryName Firmware { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.SummaryName FirmwareCryptoCertificate { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.SummaryName FirmwareCryptoKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotFirmwareDefense.Models.SummaryName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotFirmwareDefense.Models.SummaryName left, Azure.ResourceManager.IotFirmwareDefense.Models.SummaryName right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotFirmwareDefense.Models.SummaryName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotFirmwareDefense.Models.SummaryName left, Azure.ResourceManager.IotFirmwareDefense.Models.SummaryName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UploadUriContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.UploadUriContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.UploadUriContent>
    {
        public UploadUriContent() { }
        public string FirmwareId { get { throw null; } set { } }
        Azure.ResourceManager.IotFirmwareDefense.Models.UploadUriContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.UploadUriContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.UploadUriContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.UploadUriContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.UploadUriContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.UploadUriContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.UploadUriContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UriToken : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.UriToken>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.UriToken>
    {
        internal UriToken() { }
        public System.Uri Uri { get { throw null; } }
        Azure.ResourceManager.IotFirmwareDefense.Models.UriToken System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.UriToken>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.UriToken>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.UriToken System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.UriToken>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.UriToken>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.UriToken>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
