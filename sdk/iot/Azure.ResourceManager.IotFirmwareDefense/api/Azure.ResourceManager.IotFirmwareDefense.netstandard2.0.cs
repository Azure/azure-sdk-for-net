namespace Azure.ResourceManager.IotFirmwareDefense
{
    public partial class FirmwareCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotFirmwareDefense.FirmwareResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotFirmwareDefense.FirmwareResource>, System.Collections.IEnumerable
    {
        protected FirmwareCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotFirmwareDefense.FirmwareResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string firmwareName, Azure.ResourceManager.IotFirmwareDefense.FirmwareData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotFirmwareDefense.FirmwareResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string firmwareName, Azure.ResourceManager.IotFirmwareDefense.FirmwareData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string firmwareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string firmwareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareResource> Get(string firmwareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.FirmwareResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.FirmwareResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareResource>> GetAsync(string firmwareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IotFirmwareDefense.FirmwareResource> GetIfExists(string firmwareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IotFirmwareDefense.FirmwareResource>> GetIfExistsAsync(string firmwareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotFirmwareDefense.FirmwareResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotFirmwareDefense.FirmwareResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotFirmwareDefense.FirmwareResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotFirmwareDefense.FirmwareResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FirmwareData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareData>
    {
        public FirmwareData() { }
        public string Description { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public long? FileSize { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.Status? Status { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotFirmwareDefense.Models.StatusMessage> StatusMessages { get { throw null; } }
        public string Vendor { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        Azure.ResourceManager.IotFirmwareDefense.FirmwareData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.FirmwareData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FirmwareResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FirmwareResource() { }
        public virtual Azure.ResourceManager.IotFirmwareDefense.FirmwareData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string firmwareName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.Models.UriToken> GenerateDownloadUrl(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.Models.UriToken>> GenerateDownloadUrlAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.Models.UriToken> GenerateFilesystemDownloadUrl(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.Models.UriToken>> GenerateFilesystemDownloadUrlAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResource> GetBinaryHardenings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResource> GetBinaryHardeningsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateResource> GetCryptoCertificates(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateResource> GetCryptoCertificatesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeyResource> GetCryptoKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeyResource> GetCryptoKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.Models.CveResource> GetCves(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.Models.CveResource> GetCvesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHashResource> GetPasswordHashes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHashResource> GetPasswordHashesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResource> GetSbomComponents(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResource> GetSbomComponentsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.SummaryResource> GetSummaryResource(Azure.ResourceManager.IotFirmwareDefense.Models.SummaryName summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.SummaryResource>> GetSummaryResourceAsync(Azure.ResourceManager.IotFirmwareDefense.Models.SummaryName summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotFirmwareDefense.SummaryResourceCollection GetSummaryResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareResource> Update(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwarePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareResource>> UpdateAsync(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwarePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FirmwareWorkspaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceResource>, System.Collections.IEnumerable
    {
        protected FirmwareWorkspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceResource> GetIfExists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceResource>> GetIfExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FirmwareWorkspaceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceData>
    {
        public FirmwareWorkspaceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.IotFirmwareDefense.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FirmwareWorkspaceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FirmwareWorkspaceResource() { }
        public virtual Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.Models.UriToken> GenerateUploadUrl(Azure.ResourceManager.IotFirmwareDefense.Models.UploadUrlContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.Models.UriToken>> GenerateUploadUrlAsync(Azure.ResourceManager.IotFirmwareDefense.Models.UploadUrlContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareResource> GetFirmware(string firmwareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareResource>> GetFirmwareAsync(string firmwareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotFirmwareDefense.FirmwareCollection GetFirmwares() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceResource> Update(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceResource>> UpdateAsync(Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class IotFirmwareDefenseExtensions
    {
        public static Azure.ResourceManager.IotFirmwareDefense.FirmwareResource GetFirmwareResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceResource> GetFirmwareWorkspace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceResource>> GetFirmwareWorkspaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceResource GetFirmwareWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceCollection GetFirmwareWorkspaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceResource> GetFirmwareWorkspaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceResource> GetFirmwareWorkspacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.SummaryResource GetSummaryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class SummaryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SummaryResource() { }
        public virtual Azure.ResourceManager.IotFirmwareDefense.SummaryResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string firmwareName, Azure.ResourceManager.IotFirmwareDefense.Models.SummaryName summaryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.SummaryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.SummaryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SummaryResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotFirmwareDefense.SummaryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotFirmwareDefense.SummaryResource>, System.Collections.IEnumerable
    {
        protected SummaryResourceCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.IotFirmwareDefense.Models.SummaryName summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.IotFirmwareDefense.Models.SummaryName summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.SummaryResource> Get(Azure.ResourceManager.IotFirmwareDefense.Models.SummaryName summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.SummaryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.SummaryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.SummaryResource>> GetAsync(Azure.ResourceManager.IotFirmwareDefense.Models.SummaryName summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IotFirmwareDefense.SummaryResource> GetIfExists(Azure.ResourceManager.IotFirmwareDefense.Models.SummaryName summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IotFirmwareDefense.SummaryResource>> GetIfExistsAsync(Azure.ResourceManager.IotFirmwareDefense.Models.SummaryName summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotFirmwareDefense.SummaryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotFirmwareDefense.SummaryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotFirmwareDefense.SummaryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotFirmwareDefense.SummaryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SummaryResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.SummaryResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.SummaryResourceData>
    {
        public SummaryResourceData() { }
        public Azure.ResourceManager.IotFirmwareDefense.Models.SummaryResourceProperties Properties { get { throw null; } }
        Azure.ResourceManager.IotFirmwareDefense.SummaryResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.SummaryResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.SummaryResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.SummaryResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.SummaryResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.SummaryResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.SummaryResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.IotFirmwareDefense.Mocking
{
    public partial class MockableIotFirmwareDefenseArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableIotFirmwareDefenseArmClient() { }
        public virtual Azure.ResourceManager.IotFirmwareDefense.FirmwareResource GetFirmwareResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceResource GetFirmwareWorkspaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.IotFirmwareDefense.SummaryResource GetSummaryResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableIotFirmwareDefenseResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableIotFirmwareDefenseResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceResource> GetFirmwareWorkspace(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceResource>> GetFirmwareWorkspaceAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceCollection GetFirmwareWorkspaces() { throw null; }
    }
    public partial class MockableIotFirmwareDefenseSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableIotFirmwareDefenseSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceResource> GetFirmwareWorkspaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceResource> GetFirmwareWorkspacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.IotFirmwareDefense.Models
{
    public static partial class ArmIotFirmwareDefenseModelFactory
    {
        public static Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResource BinaryHardeningResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string binaryHardeningId = null, string architecture = null, string filePath = null, string @class = null, string runpath = null, string rpath = null, bool? nx = default(bool?), bool? pie = default(bool?), bool? relro = default(bool?), bool? canary = default(bool?), bool? stripped = default(bool?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningSummary BinaryHardeningSummary(long? totalFiles = default(long?), int? nx = default(int?), int? pie = default(int?), int? relro = default(int?), int? canary = default(int?), int? stripped = default(int?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CveLink CveLink(System.Uri href = null, string label = null) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CveResource CveResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string cveId = null, Azure.ResourceManager.IotFirmwareDefense.Models.CveComponent component = null, string severity = null, string namePropertiesName = null, string cvssScore = null, string cvssVersion = null, string cvssV2Score = null, string cvssV3Score = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotFirmwareDefense.Models.CveLink> links = null, string description = null) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary CveSummary(long? critical = default(long?), long? high = default(long?), long? medium = default(long?), long? low = default(long?), long? unknown = default(long?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateResource FirmwareCryptoCertificateResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string cryptoCertId = null, string namePropertiesName = null, Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateEntity subject = null, Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateEntity issuer = null, System.DateTimeOffset? issuedOn = default(System.DateTimeOffset?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), string role = null, string signatureAlgorithm = null, long? keySize = default(long?), string keyAlgorithm = null, string encoding = null, string serialNumber = null, string fingerprint = null, System.Collections.Generic.IEnumerable<string> usage = null, System.Collections.Generic.IEnumerable<string> filePaths = null, Azure.ResourceManager.IotFirmwareDefense.Models.PairedKey pairedKey = null, bool? isExpired = default(bool?), bool? isSelfSigned = default(bool?), bool? isWeakSignature = default(bool?), bool? isShortKeySize = default(bool?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateSummaryResource FirmwareCryptoCertificateSummaryResource(long? totalCertificates = default(long?), long? pairedKeys = default(long?), long? expired = default(long?), long? expiringSoon = default(long?), long? weakSignature = default(long?), long? selfSigned = default(long?), long? shortKeySize = default(long?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeyResource FirmwareCryptoKeyResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string firmwareCryptoKeyId = null, string keyType = null, long? keySize = default(long?), string keyAlgorithm = null, System.Collections.Generic.IEnumerable<string> usage = null, System.Collections.Generic.IEnumerable<string> filePaths = null, Azure.ResourceManager.IotFirmwareDefense.Models.PairedKey pairedKey = null, bool? isShortKeySize = default(bool?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeySummaryResource FirmwareCryptoKeySummaryResource(long? totalKeys = default(long?), long? publicKeys = default(long?), long? privateKeys = default(long?), long? pairedKeys = default(long?), long? shortKeySize = default(long?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.FirmwareData FirmwareData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string fileName = null, string vendor = null, string model = null, string version = null, string description = null, long? fileSize = default(long?), Azure.ResourceManager.IotFirmwareDefense.Models.Status? status = default(Azure.ResourceManager.IotFirmwareDefense.Models.Status?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotFirmwareDefense.Models.StatusMessage> statusMessages = null, Azure.ResourceManager.IotFirmwareDefense.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.IotFirmwareDefense.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwarePatch FirmwarePatch(string fileName = null, string vendor = null, string model = null, string version = null, string description = null, long? fileSize = default(long?), Azure.ResourceManager.IotFirmwareDefense.Models.Status? status = default(Azure.ResourceManager.IotFirmwareDefense.Models.Status?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotFirmwareDefense.Models.StatusMessage> statusMessages = null, Azure.ResourceManager.IotFirmwareDefense.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.IotFirmwareDefense.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareSummary FirmwareSummary(long? extractedSize = default(long?), long? fileSize = default(long?), long? extractedFileCount = default(long?), long? componentCount = default(long?), long? binaryCount = default(long?), long? analysisTimeSeconds = default(long?), long? rootFileSystems = default(long?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceData FirmwareWorkspaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.IotFirmwareDefense.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.IotFirmwareDefense.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareWorkspacePatch FirmwareWorkspacePatch(Azure.ResourceManager.IotFirmwareDefense.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.IotFirmwareDefense.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHashResource PasswordHashResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string passwordHashId = null, string filePath = null, string salt = null, string hash = null, string context = null, string username = null, string algorithm = null) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResource SbomComponentResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string componentId = null, string componentName = null, string version = null, string license = null, System.Collections.Generic.IEnumerable<string> filePaths = null) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.SummaryResourceData SummaryResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.IotFirmwareDefense.Models.SummaryResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.UriToken UriToken(System.Uri uri = null) { throw null; }
    }
    public partial class BinaryHardeningResource : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResource>
    {
        public BinaryHardeningResource() { }
        public string Architecture { get { throw null; } set { } }
        public string BinaryHardeningId { get { throw null; } set { } }
        public bool? Canary { get { throw null; } set { } }
        public string Class { get { throw null; } set { } }
        public string FilePath { get { throw null; } set { } }
        public bool? Nx { get { throw null; } set { } }
        public bool? Pie { get { throw null; } set { } }
        public bool? Relro { get { throw null; } set { } }
        public string Rpath { get { throw null; } set { } }
        public string Runpath { get { throw null; } set { } }
        public bool? Stripped { get { throw null; } set { } }
        Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BinaryHardeningSummary : Azure.ResourceManager.IotFirmwareDefense.Models.SummaryResourceProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningSummary>
    {
        internal BinaryHardeningSummary() { }
        public int? Canary { get { throw null; } }
        public int? Nx { get { throw null; } }
        public int? Pie { get { throw null; } }
        public int? Relro { get { throw null; } }
        public int? Stripped { get { throw null; } }
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
    public partial class CveResource : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveResource>
    {
        public CveResource() { }
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
        Azure.ResourceManager.IotFirmwareDefense.Models.CveResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.CveResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CveSummary : Azure.ResourceManager.IotFirmwareDefense.Models.SummaryResourceProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary>
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
    public partial class FirmwareCryptoCertificateResource : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateResource>
    {
        public FirmwareCryptoCertificateResource() { }
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
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FirmwareCryptoCertificateSummaryResource : Azure.ResourceManager.IotFirmwareDefense.Models.SummaryResourceProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateSummaryResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateSummaryResource>
    {
        internal FirmwareCryptoCertificateSummaryResource() { }
        public long? Expired { get { throw null; } }
        public long? ExpiringSoon { get { throw null; } }
        public long? PairedKeys { get { throw null; } }
        public long? SelfSigned { get { throw null; } }
        public long? ShortKeySize { get { throw null; } }
        public long? TotalCertificates { get { throw null; } }
        public long? WeakSignature { get { throw null; } }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateSummaryResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateSummaryResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateSummaryResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateSummaryResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateSummaryResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateSummaryResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateSummaryResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FirmwareCryptoKeyResource : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeyResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeyResource>
    {
        public FirmwareCryptoKeyResource() { }
        public System.Collections.Generic.IReadOnlyList<string> FilePaths { get { throw null; } }
        public string FirmwareCryptoKeyId { get { throw null; } set { } }
        public bool? IsShortKeySize { get { throw null; } set { } }
        public string KeyAlgorithm { get { throw null; } set { } }
        public long? KeySize { get { throw null; } set { } }
        public string KeyType { get { throw null; } set { } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.PairedKey PairedKey { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Usage { get { throw null; } set { } }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeyResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeyResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeyResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeyResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeyResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeyResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeyResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FirmwareCryptoKeySummaryResource : Azure.ResourceManager.IotFirmwareDefense.Models.SummaryResourceProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeySummaryResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeySummaryResource>
    {
        internal FirmwareCryptoKeySummaryResource() { }
        public long? PairedKeys { get { throw null; } }
        public long? PrivateKeys { get { throw null; } }
        public long? PublicKeys { get { throw null; } }
        public long? ShortKeySize { get { throw null; } }
        public long? TotalKeys { get { throw null; } }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeySummaryResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeySummaryResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeySummaryResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeySummaryResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeySummaryResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeySummaryResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeySummaryResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FirmwarePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwarePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwarePatch>
    {
        public FirmwarePatch() { }
        public string Description { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public long? FileSize { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.Status? Status { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotFirmwareDefense.Models.StatusMessage> StatusMessages { get { throw null; } }
        public string Vendor { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwarePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwarePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwarePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwarePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwarePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwarePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwarePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FirmwareSummary : Azure.ResourceManager.IotFirmwareDefense.Models.SummaryResourceProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareSummary>
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
    public partial class FirmwareWorkspacePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareWorkspacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareWorkspacePatch>
    {
        public FirmwareWorkspacePatch() { }
        public Azure.ResourceManager.IotFirmwareDefense.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareWorkspacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareWorkspacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareWorkspacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareWorkspacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareWorkspacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareWorkspacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareWorkspacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PasswordHashResource : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHashResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHashResource>
    {
        public PasswordHashResource() { }
        public string Algorithm { get { throw null; } set { } }
        public string Context { get { throw null; } set { } }
        public string FilePath { get { throw null; } set { } }
        public string Hash { get { throw null; } set { } }
        public string PasswordHashId { get { throw null; } set { } }
        public string Salt { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHashResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHashResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHashResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHashResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHashResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHashResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHashResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.IotFirmwareDefense.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotFirmwareDefense.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotFirmwareDefense.Models.ProvisioningState left, Azure.ResourceManager.IotFirmwareDefense.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotFirmwareDefense.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotFirmwareDefense.Models.ProvisioningState left, Azure.ResourceManager.IotFirmwareDefense.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SbomComponentResource : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResource>
    {
        public SbomComponentResource() { }
        public string ComponentId { get { throw null; } set { } }
        public string ComponentName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> FilePaths { get { throw null; } }
        public string License { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponentResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Status : System.IEquatable<Azure.ResourceManager.IotFirmwareDefense.Models.Status>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Status(string value) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.Status Analyzing { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.Status Error { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.Status Extracting { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.Status Pending { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.Status Ready { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotFirmwareDefense.Models.Status other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotFirmwareDefense.Models.Status left, Azure.ResourceManager.IotFirmwareDefense.Models.Status right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotFirmwareDefense.Models.Status (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotFirmwareDefense.Models.Status left, Azure.ResourceManager.IotFirmwareDefense.Models.Status right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StatusMessage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.StatusMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.StatusMessage>
    {
        public StatusMessage() { }
        public long? ErrorCode { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        Azure.ResourceManager.IotFirmwareDefense.Models.StatusMessage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.StatusMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.StatusMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.StatusMessage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.StatusMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.StatusMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.StatusMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public abstract partial class SummaryResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.SummaryResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.SummaryResourceProperties>
    {
        protected SummaryResourceProperties() { }
        Azure.ResourceManager.IotFirmwareDefense.Models.SummaryResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.SummaryResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.SummaryResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.SummaryResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.SummaryResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.SummaryResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.SummaryResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UploadUrlContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.UploadUrlContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.UploadUrlContent>
    {
        public UploadUrlContent() { }
        public string FirmwareName { get { throw null; } set { } }
        Azure.ResourceManager.IotFirmwareDefense.Models.UploadUrlContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.UploadUrlContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.UploadUrlContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.UploadUrlContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.UploadUrlContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.UploadUrlContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.UploadUrlContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
