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
        public System.Collections.Generic.IList<System.BinaryData> StatusMessages { get { throw null; } }
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
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardening> GetBinaryHardeningDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardening>> GetBinaryHardeningDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardening> GetBinaryHardeningResults(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardening> GetBinaryHardeningResultsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningSummary> GetBinaryHardeningSummary(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningSummary>> GetBinaryHardeningSummaryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponent> GetComponentDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponent>> GetComponentDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificate> GetCryptoCertificates(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificate> GetCryptoCertificatesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateSummary> GetCryptoCertificateSummary(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateSummary>> GetCryptoCertificateSummaryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKey> GetCryptoKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKey> GetCryptoKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeySummary> GetCryptoKeySummary(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeySummary>> GetCryptoKeySummaryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCve> GetCves(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCve> GetCvesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary> GetCveSummary(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary>> GetCveSummaryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareSummary> GetFirmwareSummary(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareSummary>> GetFirmwareSummaryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHash> GetPasswordHashes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHash> GetPasswordHashesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponent> GetSbomComponents(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponent> GetSbomComponentsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    }
}
namespace Azure.ResourceManager.IotFirmwareDefense.Mocking
{
    public partial class MockableIotFirmwareDefenseArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableIotFirmwareDefenseArmClient() { }
        public virtual Azure.ResourceManager.IotFirmwareDefense.FirmwareResource GetFirmwareResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceResource GetFirmwareWorkspaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
        public static Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardening BinaryHardening(string binaryHardeningId = null, string architecture = null, string path = null, string @class = null, string runpath = null, string rpath = null, Azure.ResourceManager.IotFirmwareDefense.Models.NxFlag? nx = default(Azure.ResourceManager.IotFirmwareDefense.Models.NxFlag?), Azure.ResourceManager.IotFirmwareDefense.Models.PieFlag? pie = default(Azure.ResourceManager.IotFirmwareDefense.Models.PieFlag?), Azure.ResourceManager.IotFirmwareDefense.Models.RelroFlag? relro = default(Azure.ResourceManager.IotFirmwareDefense.Models.RelroFlag?), Azure.ResourceManager.IotFirmwareDefense.Models.CanaryFlag? canary = default(Azure.ResourceManager.IotFirmwareDefense.Models.CanaryFlag?), Azure.ResourceManager.IotFirmwareDefense.Models.StrippedFlag? stripped = default(Azure.ResourceManager.IotFirmwareDefense.Models.StrippedFlag?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningSummary BinaryHardeningSummary(long? totalFiles = default(long?), int? nx = default(int?), int? pie = default(int?), int? relro = default(int?), int? canary = default(int?), int? stripped = default(int?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CveLink CveLink(string href = null, string label = null) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary CveSummary(long? critical = default(long?), long? high = default(long?), long? medium = default(long?), long? low = default(long?), long? unknown = default(long?), long? undefined = default(long?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificate FirmwareCryptoCertificate(string cryptoCertId = null, string name = null, Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateEntity subject = null, Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateEntity issuer = null, System.DateTimeOffset? issuedOn = default(System.DateTimeOffset?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), string role = null, string signatureAlgorithm = null, long? keySize = default(long?), string keyAlgorithm = null, string encoding = null, string serialNumber = null, string fingerprint = null, System.Collections.Generic.IEnumerable<string> usage = null, System.Collections.Generic.IEnumerable<string> filePaths = null, Azure.ResourceManager.IotFirmwareDefense.Models.PairedKey pairedKey = null, Azure.ResourceManager.IotFirmwareDefense.Models.IsExpired? isExpired = default(Azure.ResourceManager.IotFirmwareDefense.Models.IsExpired?), Azure.ResourceManager.IotFirmwareDefense.Models.IsSelfSigned? isSelfSigned = default(Azure.ResourceManager.IotFirmwareDefense.Models.IsSelfSigned?), Azure.ResourceManager.IotFirmwareDefense.Models.IsWeakSignature? isWeakSignature = default(Azure.ResourceManager.IotFirmwareDefense.Models.IsWeakSignature?), Azure.ResourceManager.IotFirmwareDefense.Models.IsShortKeySize? isShortKeySize = default(Azure.ResourceManager.IotFirmwareDefense.Models.IsShortKeySize?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateEntity FirmwareCryptoCertificateEntity(string commonName = null, string organization = null, string organizationalUnit = null, string state = null, string country = null) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateSummary FirmwareCryptoCertificateSummary(long? totalCertificates = default(long?), long? pairedKeys = default(long?), long? expired = default(long?), long? expiringSoon = default(long?), long? weakSignature = default(long?), long? selfSigned = default(long?), long? shortKeySize = default(long?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKey FirmwareCryptoKey(string firmwareCryptoKeyId = null, string keyType = null, long? keySize = default(long?), string keyAlgorithm = null, System.Collections.Generic.IEnumerable<string> usage = null, System.Collections.Generic.IEnumerable<string> filePaths = null, Azure.ResourceManager.IotFirmwareDefense.Models.PairedKey pairedKey = null, Azure.ResourceManager.IotFirmwareDefense.Models.IsShortKeySize? isShortKeySize = default(Azure.ResourceManager.IotFirmwareDefense.Models.IsShortKeySize?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeySummary FirmwareCryptoKeySummary(long? totalKeys = default(long?), long? publicKeys = default(long?), long? privateKeys = default(long?), long? pairedKeys = default(long?), long? shortKeySize = default(long?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCve FirmwareCve(string cveId = null, System.BinaryData component = null, string severity = null, string name = null, string cvssScore = null, string cvssVersion = null, string cvssV2Score = null, string cvssV3Score = null, System.DateTimeOffset? publishOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotFirmwareDefense.Models.CveLink> links = null, string description = null) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.FirmwareData FirmwareData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string fileName = null, string vendor = null, string model = null, string version = null, string description = null, long? fileSize = default(long?), Azure.ResourceManager.IotFirmwareDefense.Models.Status? status = default(Azure.ResourceManager.IotFirmwareDefense.Models.Status?), System.Collections.Generic.IEnumerable<System.BinaryData> statusMessages = null, Azure.ResourceManager.IotFirmwareDefense.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.IotFirmwareDefense.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwarePatch FirmwarePatch(string fileName = null, string vendor = null, string model = null, string version = null, string description = null, long? fileSize = default(long?), Azure.ResourceManager.IotFirmwareDefense.Models.Status? status = default(Azure.ResourceManager.IotFirmwareDefense.Models.Status?), System.Collections.Generic.IEnumerable<System.BinaryData> statusMessages = null, Azure.ResourceManager.IotFirmwareDefense.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.IotFirmwareDefense.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareSummary FirmwareSummary(long? extractedSize = default(long?), long? fileSize = default(long?), long? extractedFileCount = default(long?), long? componentCount = default(long?), long? binaryCount = default(long?), long? analysisTimeSeconds = default(long?), long? rootFileSystems = default(long?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.FirmwareWorkspaceData FirmwareWorkspaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.IotFirmwareDefense.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.IotFirmwareDefense.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareWorkspacePatch FirmwareWorkspacePatch(Azure.ResourceManager.IotFirmwareDefense.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.IotFirmwareDefense.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.PairedKey PairedKey(string id = null, string pairedKeyType = null, System.BinaryData additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHash PasswordHash(string passwordHashId = null, string filePath = null, string salt = null, string hash = null, string context = null, string username = null, string algorithm = null) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponent SbomComponent(string componentId = null, string componentName = null, string version = null, string license = null, System.DateTimeOffset? releaseOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> paths = null, Azure.ResourceManager.IotFirmwareDefense.Models.IsUpdateAvailable? isUpdateAvailable = default(Azure.ResourceManager.IotFirmwareDefense.Models.IsUpdateAvailable?)) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.UriToken UriToken(System.Uri uri = null, System.Uri uploadUri = null) { throw null; }
    }
    public partial class BinaryHardening : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardening>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardening>
    {
        internal BinaryHardening() { }
        public string Architecture { get { throw null; } }
        public string BinaryHardeningId { get { throw null; } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.CanaryFlag? Canary { get { throw null; } }
        public string Class { get { throw null; } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.NxFlag? Nx { get { throw null; } }
        public string Path { get { throw null; } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.PieFlag? Pie { get { throw null; } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.RelroFlag? Relro { get { throw null; } }
        public string Rpath { get { throw null; } }
        public string Runpath { get { throw null; } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.StrippedFlag? Stripped { get { throw null; } }
        Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardening System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardening>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardening>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardening System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardening>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardening>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardening>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BinaryHardeningSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.BinaryHardeningSummary>
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CanaryFlag : System.IEquatable<Azure.ResourceManager.IotFirmwareDefense.Models.CanaryFlag>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CanaryFlag(string value) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CanaryFlag False { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.CanaryFlag True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotFirmwareDefense.Models.CanaryFlag other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotFirmwareDefense.Models.CanaryFlag left, Azure.ResourceManager.IotFirmwareDefense.Models.CanaryFlag right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotFirmwareDefense.Models.CanaryFlag (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotFirmwareDefense.Models.CanaryFlag left, Azure.ResourceManager.IotFirmwareDefense.Models.CanaryFlag right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CveLink : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveLink>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveLink>
    {
        internal CveLink() { }
        public string Href { get { throw null; } }
        public string Label { get { throw null; } }
        Azure.ResourceManager.IotFirmwareDefense.Models.CveLink System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveLink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveLink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.CveLink System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveLink>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveLink>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveLink>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CveSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary>
    {
        internal CveSummary() { }
        public long? Critical { get { throw null; } }
        public long? High { get { throw null; } }
        public long? Low { get { throw null; } }
        public long? Medium { get { throw null; } }
        public long? Undefined { get { throw null; } }
        public long? Unknown { get { throw null; } }
        Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.CveSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FirmwareCryptoCertificate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificate>
    {
        internal FirmwareCryptoCertificate() { }
        public string CryptoCertId { get { throw null; } }
        public string Encoding { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> FilePaths { get { throw null; } }
        public string Fingerprint { get { throw null; } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.IsExpired? IsExpired { get { throw null; } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.IsSelfSigned? IsSelfSigned { get { throw null; } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.IsShortKeySize? IsShortKeySize { get { throw null; } }
        public System.DateTimeOffset? IssuedOn { get { throw null; } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateEntity Issuer { get { throw null; } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.IsWeakSignature? IsWeakSignature { get { throw null; } }
        public string KeyAlgorithm { get { throw null; } }
        public long? KeySize { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.PairedKey PairedKey { get { throw null; } }
        public string Role { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public string SignatureAlgorithm { get { throw null; } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateEntity Subject { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Usage { get { throw null; } }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FirmwareCryptoCertificateEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateEntity>
    {
        internal FirmwareCryptoCertificateEntity() { }
        public string CommonName { get { throw null; } }
        public string Country { get { throw null; } }
        public string Organization { get { throw null; } }
        public string OrganizationalUnit { get { throw null; } }
        public string State { get { throw null; } }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FirmwareCryptoCertificateSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoCertificateSummary>
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
    public partial class FirmwareCryptoKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKey>
    {
        internal FirmwareCryptoKey() { }
        public System.Collections.Generic.IReadOnlyList<string> FilePaths { get { throw null; } }
        public string FirmwareCryptoKeyId { get { throw null; } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.IsShortKeySize? IsShortKeySize { get { throw null; } }
        public string KeyAlgorithm { get { throw null; } }
        public long? KeySize { get { throw null; } }
        public string KeyType { get { throw null; } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.PairedKey PairedKey { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Usage { get { throw null; } }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FirmwareCryptoKeySummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeySummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCryptoKeySummary>
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
    public partial class FirmwareCve : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCve>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCve>
    {
        internal FirmwareCve() { }
        public System.BinaryData Component { get { throw null; } }
        public string CveId { get { throw null; } }
        public string CvssScore { get { throw null; } }
        public string CvssV2Score { get { throw null; } }
        public string CvssV3Score { get { throw null; } }
        public string CvssVersion { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.IotFirmwareDefense.Models.CveLink> Links { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? PublishOn { get { throw null; } }
        public string Severity { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCve System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCve>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCve>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCve System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCve>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCve>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareCve>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public System.Collections.Generic.IList<System.BinaryData> StatusMessages { get { throw null; } }
        public string Vendor { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwarePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwarePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwarePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.FirmwarePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwarePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwarePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwarePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FirmwareSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.FirmwareSummary>
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsExpired : System.IEquatable<Azure.ResourceManager.IotFirmwareDefense.Models.IsExpired>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsExpired(string value) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.IsExpired False { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.IsExpired True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotFirmwareDefense.Models.IsExpired other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotFirmwareDefense.Models.IsExpired left, Azure.ResourceManager.IotFirmwareDefense.Models.IsExpired right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotFirmwareDefense.Models.IsExpired (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotFirmwareDefense.Models.IsExpired left, Azure.ResourceManager.IotFirmwareDefense.Models.IsExpired right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsSelfSigned : System.IEquatable<Azure.ResourceManager.IotFirmwareDefense.Models.IsSelfSigned>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsSelfSigned(string value) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.IsSelfSigned False { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.IsSelfSigned True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotFirmwareDefense.Models.IsSelfSigned other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotFirmwareDefense.Models.IsSelfSigned left, Azure.ResourceManager.IotFirmwareDefense.Models.IsSelfSigned right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotFirmwareDefense.Models.IsSelfSigned (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotFirmwareDefense.Models.IsSelfSigned left, Azure.ResourceManager.IotFirmwareDefense.Models.IsSelfSigned right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsShortKeySize : System.IEquatable<Azure.ResourceManager.IotFirmwareDefense.Models.IsShortKeySize>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsShortKeySize(string value) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.IsShortKeySize False { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.IsShortKeySize True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotFirmwareDefense.Models.IsShortKeySize other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotFirmwareDefense.Models.IsShortKeySize left, Azure.ResourceManager.IotFirmwareDefense.Models.IsShortKeySize right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotFirmwareDefense.Models.IsShortKeySize (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotFirmwareDefense.Models.IsShortKeySize left, Azure.ResourceManager.IotFirmwareDefense.Models.IsShortKeySize right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsUpdateAvailable : System.IEquatable<Azure.ResourceManager.IotFirmwareDefense.Models.IsUpdateAvailable>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsUpdateAvailable(string value) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.IsUpdateAvailable False { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.IsUpdateAvailable True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotFirmwareDefense.Models.IsUpdateAvailable other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotFirmwareDefense.Models.IsUpdateAvailable left, Azure.ResourceManager.IotFirmwareDefense.Models.IsUpdateAvailable right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotFirmwareDefense.Models.IsUpdateAvailable (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotFirmwareDefense.Models.IsUpdateAvailable left, Azure.ResourceManager.IotFirmwareDefense.Models.IsUpdateAvailable right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsWeakSignature : System.IEquatable<Azure.ResourceManager.IotFirmwareDefense.Models.IsWeakSignature>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsWeakSignature(string value) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.IsWeakSignature False { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.IsWeakSignature True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotFirmwareDefense.Models.IsWeakSignature other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotFirmwareDefense.Models.IsWeakSignature left, Azure.ResourceManager.IotFirmwareDefense.Models.IsWeakSignature right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotFirmwareDefense.Models.IsWeakSignature (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotFirmwareDefense.Models.IsWeakSignature left, Azure.ResourceManager.IotFirmwareDefense.Models.IsWeakSignature right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NxFlag : System.IEquatable<Azure.ResourceManager.IotFirmwareDefense.Models.NxFlag>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NxFlag(string value) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.NxFlag False { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.NxFlag True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotFirmwareDefense.Models.NxFlag other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotFirmwareDefense.Models.NxFlag left, Azure.ResourceManager.IotFirmwareDefense.Models.NxFlag right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotFirmwareDefense.Models.NxFlag (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotFirmwareDefense.Models.NxFlag left, Azure.ResourceManager.IotFirmwareDefense.Models.NxFlag right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PairedKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.PairedKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.PairedKey>
    {
        internal PairedKey() { }
        public System.BinaryData AdditionalProperties { get { throw null; } }
        public string Id { get { throw null; } }
        public string PairedKeyType { get { throw null; } }
        Azure.ResourceManager.IotFirmwareDefense.Models.PairedKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.PairedKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.PairedKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.PairedKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.PairedKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.PairedKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.PairedKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PasswordHash : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHash>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHash>
    {
        internal PasswordHash() { }
        public string Algorithm { get { throw null; } }
        public string Context { get { throw null; } }
        public string FilePath { get { throw null; } }
        public string Hash { get { throw null; } }
        public string PasswordHashId { get { throw null; } }
        public string Salt { get { throw null; } }
        public string Username { get { throw null; } }
        Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHash System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHash>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHash>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHash System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHash>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHash>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.PasswordHash>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PieFlag : System.IEquatable<Azure.ResourceManager.IotFirmwareDefense.Models.PieFlag>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PieFlag(string value) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.PieFlag False { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.PieFlag True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotFirmwareDefense.Models.PieFlag other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotFirmwareDefense.Models.PieFlag left, Azure.ResourceManager.IotFirmwareDefense.Models.PieFlag right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotFirmwareDefense.Models.PieFlag (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotFirmwareDefense.Models.PieFlag left, Azure.ResourceManager.IotFirmwareDefense.Models.PieFlag right) { throw null; }
        public override string ToString() { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RelroFlag : System.IEquatable<Azure.ResourceManager.IotFirmwareDefense.Models.RelroFlag>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RelroFlag(string value) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.RelroFlag False { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.RelroFlag True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotFirmwareDefense.Models.RelroFlag other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotFirmwareDefense.Models.RelroFlag left, Azure.ResourceManager.IotFirmwareDefense.Models.RelroFlag right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotFirmwareDefense.Models.RelroFlag (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotFirmwareDefense.Models.RelroFlag left, Azure.ResourceManager.IotFirmwareDefense.Models.RelroFlag right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SbomComponent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponent>
    {
        internal SbomComponent() { }
        public string ComponentId { get { throw null; } }
        public string ComponentName { get { throw null; } }
        public Azure.ResourceManager.IotFirmwareDefense.Models.IsUpdateAvailable? IsUpdateAvailable { get { throw null; } }
        public string License { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Paths { get { throw null; } }
        public System.DateTimeOffset? ReleaseOn { get { throw null; } }
        public string Version { get { throw null; } }
        Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.SbomComponent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StrippedFlag : System.IEquatable<Azure.ResourceManager.IotFirmwareDefense.Models.StrippedFlag>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StrippedFlag(string value) { throw null; }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.StrippedFlag False { get { throw null; } }
        public static Azure.ResourceManager.IotFirmwareDefense.Models.StrippedFlag True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotFirmwareDefense.Models.StrippedFlag other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotFirmwareDefense.Models.StrippedFlag left, Azure.ResourceManager.IotFirmwareDefense.Models.StrippedFlag right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotFirmwareDefense.Models.StrippedFlag (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotFirmwareDefense.Models.StrippedFlag left, Azure.ResourceManager.IotFirmwareDefense.Models.StrippedFlag right) { throw null; }
        public override string ToString() { throw null; }
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
        public System.Uri UploadUri { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        Azure.ResourceManager.IotFirmwareDefense.Models.UriToken System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.UriToken>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotFirmwareDefense.Models.UriToken>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotFirmwareDefense.Models.UriToken System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.UriToken>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.UriToken>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotFirmwareDefense.Models.UriToken>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
