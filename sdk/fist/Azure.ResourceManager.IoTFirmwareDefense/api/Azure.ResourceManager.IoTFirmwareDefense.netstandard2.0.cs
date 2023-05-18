namespace Azure.ResourceManager.IoTFirmwareDefense
{
    public partial class FirmwareCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTFirmwareDefense.FirmwareResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTFirmwareDefense.FirmwareResource>, System.Collections.IEnumerable
    {
        protected FirmwareCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTFirmwareDefense.FirmwareResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string firmwareId, Azure.ResourceManager.IoTFirmwareDefense.FirmwareData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTFirmwareDefense.FirmwareResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string firmwareId, Azure.ResourceManager.IoTFirmwareDefense.FirmwareData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string firmwareId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string firmwareId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.FirmwareResource> Get(string firmwareId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTFirmwareDefense.FirmwareResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTFirmwareDefense.FirmwareResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.FirmwareResource>> GetAsync(string firmwareId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IoTFirmwareDefense.FirmwareResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTFirmwareDefense.FirmwareResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IoTFirmwareDefense.FirmwareResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTFirmwareDefense.FirmwareResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FirmwareData : Azure.ResourceManager.Models.ResourceData
    {
        public FirmwareData() { }
        public string Description { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public long? FileSize { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.Status? Status { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> StatusMessages { get { throw null; } }
        public string Vendor { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class FirmwareResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FirmwareResource() { }
        public virtual Azure.ResourceManager.IoTFirmwareDefense.FirmwareData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string firmwareId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.Models.BinaryHardening> GenerateBinaryHardeningDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.Models.BinaryHardening>> GenerateBinaryHardeningDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.Models.BinaryHardeningSummary> GenerateBinaryHardeningSummary(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.Models.BinaryHardeningSummary>> GenerateBinaryHardeningSummaryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.Models.Component> GenerateComponentDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.Models.Component>> GenerateComponentDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.Models.CryptoCertificateSummary> GenerateCryptoCertificateSummary(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.Models.CryptoCertificateSummary>> GenerateCryptoCertificateSummaryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.Models.CryptoKeySummary> GenerateCryptoKeySummary(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.Models.CryptoKeySummary>> GenerateCryptoKeySummaryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.Models.CveSummary> GenerateCveSummary(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.Models.CveSummary>> GenerateCveSummaryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.Models.UrlToken> GenerateDownloadUrl(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.Models.UrlToken>> GenerateDownloadUrlAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.Models.UrlToken> GenerateFilesystemDownloadUrl(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.Models.UrlToken>> GenerateFilesystemDownloadUrlAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.Models.FirmwareSummary> GenerateSummary(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.Models.FirmwareSummary>> GenerateSummaryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.FirmwareResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.FirmwareResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTFirmwareDefense.Models.BinaryHardening> GetGenerateBinaryHardeningList(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTFirmwareDefense.Models.BinaryHardening> GetGenerateBinaryHardeningListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTFirmwareDefense.Models.Component> GetGenerateComponentList(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTFirmwareDefense.Models.Component> GetGenerateComponentListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTFirmwareDefense.Models.CryptoCertificate> GetGenerateCryptoCertificateList(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTFirmwareDefense.Models.CryptoCertificate> GetGenerateCryptoCertificateListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTFirmwareDefense.Models.CryptoKey> GetGenerateCryptoKeyList(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTFirmwareDefense.Models.CryptoKey> GetGenerateCryptoKeyListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTFirmwareDefense.Models.Cve> GetGenerateCveList(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTFirmwareDefense.Models.Cve> GetGenerateCveListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTFirmwareDefense.Models.PasswordHash> GetGeneratePasswordHashList(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTFirmwareDefense.Models.PasswordHash> GetGeneratePasswordHashListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.FirmwareResource> Update(Azure.ResourceManager.IoTFirmwareDefense.Models.FirmwarePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.FirmwareResource>> UpdateAsync(Azure.ResourceManager.IoTFirmwareDefense.Models.FirmwarePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class IoTFirmwareDefenseExtensions
    {
        public static Azure.ResourceManager.IoTFirmwareDefense.FirmwareResource GetFirmwareResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.WorkspaceResource> GetWorkspace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.WorkspaceResource>> GetWorkspaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.WorkspaceResource GetWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.WorkspaceCollection GetWorkspaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.IoTFirmwareDefense.WorkspaceResource> GetWorkspaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.IoTFirmwareDefense.WorkspaceResource> GetWorkspacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTFirmwareDefense.WorkspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTFirmwareDefense.WorkspaceResource>, System.Collections.IEnumerable
    {
        protected WorkspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTFirmwareDefense.WorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.IoTFirmwareDefense.WorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTFirmwareDefense.WorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.IoTFirmwareDefense.WorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.WorkspaceResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTFirmwareDefense.WorkspaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTFirmwareDefense.WorkspaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.WorkspaceResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IoTFirmwareDefense.WorkspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTFirmwareDefense.WorkspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IoTFirmwareDefense.WorkspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTFirmwareDefense.WorkspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkspaceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public WorkspaceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class WorkspaceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkspaceResource() { }
        public virtual Azure.ResourceManager.IoTFirmwareDefense.WorkspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.Models.UrlToken> GenerateUploadUrl(Azure.ResourceManager.IoTFirmwareDefense.Models.GenerateUploadUrlContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.Models.UrlToken>> GenerateUploadUrlAsync(Azure.ResourceManager.IoTFirmwareDefense.Models.GenerateUploadUrlContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.WorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.WorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.FirmwareResource> GetFirmware(string firmwareId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.FirmwareResource>> GetFirmwareAsync(string firmwareId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IoTFirmwareDefense.FirmwareCollection GetFirmwares() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.WorkspaceResource> Update(Azure.ResourceManager.IoTFirmwareDefense.Models.WorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTFirmwareDefense.WorkspaceResource>> UpdateAsync(Azure.ResourceManager.IoTFirmwareDefense.Models.WorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.IoTFirmwareDefense.Models
{
    public static partial class ArmIoTFirmwareDefenseModelFactory
    {
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.BinaryHardening BinaryHardening(string binaryHardeningId = null, string architecture = null, string path = null, string @class = null, string runpath = null, string rpath = null, Azure.ResourceManager.IoTFirmwareDefense.Models.NxFlag? nx = default(Azure.ResourceManager.IoTFirmwareDefense.Models.NxFlag?), Azure.ResourceManager.IoTFirmwareDefense.Models.PieFlag? pie = default(Azure.ResourceManager.IoTFirmwareDefense.Models.PieFlag?), Azure.ResourceManager.IoTFirmwareDefense.Models.RelroFlag? relro = default(Azure.ResourceManager.IoTFirmwareDefense.Models.RelroFlag?), Azure.ResourceManager.IoTFirmwareDefense.Models.CanaryFlag? canary = default(Azure.ResourceManager.IoTFirmwareDefense.Models.CanaryFlag?), Azure.ResourceManager.IoTFirmwareDefense.Models.StrippedFlag? stripped = default(Azure.ResourceManager.IoTFirmwareDefense.Models.StrippedFlag?)) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.BinaryHardeningSummary BinaryHardeningSummary(long? totalFiles = default(long?), int? nx = default(int?), int? pie = default(int?), int? relro = default(int?), int? canary = default(int?), int? stripped = default(int?)) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.Component Component(string componentId = null, string componentName = null, string version = null, string license = null, System.DateTimeOffset? releaseOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> paths = null, Azure.ResourceManager.IoTFirmwareDefense.Models.IsUpdateAvailable? isUpdateAvailable = default(Azure.ResourceManager.IoTFirmwareDefense.Models.IsUpdateAvailable?)) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.CryptoCertificate CryptoCertificate(string cryptoCertId = null, string name = null, Azure.ResourceManager.IoTFirmwareDefense.Models.CryptoCertificateEntity subject = null, Azure.ResourceManager.IoTFirmwareDefense.Models.CryptoCertificateEntity issuer = null, System.DateTimeOffset? issuedOn = default(System.DateTimeOffset?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), string role = null, string signatureAlgorithm = null, long? keySize = default(long?), string keyAlgorithm = null, string encoding = null, string serialNumber = null, string fingerprint = null, System.Collections.Generic.IEnumerable<string> usage = null, System.Collections.Generic.IEnumerable<string> filePaths = null, Azure.ResourceManager.IoTFirmwareDefense.Models.PairedKey pairedKey = null, Azure.ResourceManager.IoTFirmwareDefense.Models.IsExpired? isExpired = default(Azure.ResourceManager.IoTFirmwareDefense.Models.IsExpired?), Azure.ResourceManager.IoTFirmwareDefense.Models.IsSelfSigned? isSelfSigned = default(Azure.ResourceManager.IoTFirmwareDefense.Models.IsSelfSigned?), Azure.ResourceManager.IoTFirmwareDefense.Models.IsWeakSignature? isWeakSignature = default(Azure.ResourceManager.IoTFirmwareDefense.Models.IsWeakSignature?), Azure.ResourceManager.IoTFirmwareDefense.Models.IsShortKeySize? isShortKeySize = default(Azure.ResourceManager.IoTFirmwareDefense.Models.IsShortKeySize?)) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.CryptoCertificateEntity CryptoCertificateEntity(string commonName = null, string organization = null, string organizationalUnit = null, string state = null, string country = null) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.CryptoCertificateSummary CryptoCertificateSummary(long? totalCertificates = default(long?), long? pairedKeys = default(long?), long? expired = default(long?), long? expiringSoon = default(long?), long? weakSignature = default(long?), long? selfSigned = default(long?), long? shortKeySize = default(long?)) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.CryptoKey CryptoKey(string cryptoKeyId = null, string keyType = null, long? keySize = default(long?), string keyAlgorithm = null, System.Collections.Generic.IEnumerable<string> usage = null, System.Collections.Generic.IEnumerable<string> filePaths = null, Azure.ResourceManager.IoTFirmwareDefense.Models.PairedKey pairedKey = null, Azure.ResourceManager.IoTFirmwareDefense.Models.IsShortKeySize? isShortKeySize = default(Azure.ResourceManager.IoTFirmwareDefense.Models.IsShortKeySize?)) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.CryptoKeySummary CryptoKeySummary(long? totalKeys = default(long?), long? publicKeys = default(long?), long? privateKeys = default(long?), long? pairedKeys = default(long?), long? shortKeySize = default(long?)) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.Cve Cve(string cveId = null, System.BinaryData component = null, string severity = null, string name = null, string cvssScore = null, string cvssVersion = null, string cvssV2Score = null, string cvssV3Score = null, System.DateTimeOffset? publishOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTFirmwareDefense.Models.CveLink> links = null, string description = null) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.CveLink CveLink(string href = null, string label = null) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.CveSummary CveSummary(long? critical = default(long?), long? high = default(long?), long? medium = default(long?), long? low = default(long?), long? unknown = default(long?), long? undefined = default(long?)) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.FirmwareData FirmwareData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string fileName = null, string vendor = null, string model = null, string version = null, string description = null, long? fileSize = default(long?), Azure.ResourceManager.IoTFirmwareDefense.Models.Status? status = default(Azure.ResourceManager.IoTFirmwareDefense.Models.Status?), System.Collections.Generic.IEnumerable<System.BinaryData> statusMessages = null, Azure.ResourceManager.IoTFirmwareDefense.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.IoTFirmwareDefense.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.FirmwareSummary FirmwareSummary(long? extractedSize = default(long?), long? fileSize = default(long?), long? extractedFileCount = default(long?), long? componentCount = default(long?), long? binaryCount = default(long?), long? analysisTimeSeconds = default(long?), long? rootFileSystems = default(long?)) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.PairedKey PairedKey(string id = null, string pairedKeyType = null, System.BinaryData additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.PasswordHash PasswordHash(string passwordHashId = null, string filePath = null, string salt = null, string hash = null, string context = null, string username = null, string algorithm = null) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.UrlToken UrlToken(System.Uri uri = null, System.Uri uploadUri = null) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.WorkspaceData WorkspaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.IoTFirmwareDefense.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.IoTFirmwareDefense.Models.ProvisioningState?)) { throw null; }
    }
    public partial class BinaryHardening
    {
        internal BinaryHardening() { }
        public string Architecture { get { throw null; } }
        public string BinaryHardeningId { get { throw null; } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.CanaryFlag? Canary { get { throw null; } }
        public string Class { get { throw null; } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.NxFlag? Nx { get { throw null; } }
        public string Path { get { throw null; } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.PieFlag? Pie { get { throw null; } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.RelroFlag? Relro { get { throw null; } }
        public string Rpath { get { throw null; } }
        public string Runpath { get { throw null; } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.StrippedFlag? Stripped { get { throw null; } }
    }
    public partial class BinaryHardeningSummary
    {
        internal BinaryHardeningSummary() { }
        public int? Canary { get { throw null; } }
        public int? Nx { get { throw null; } }
        public int? Pie { get { throw null; } }
        public int? Relro { get { throw null; } }
        public int? Stripped { get { throw null; } }
        public long? TotalFiles { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CanaryFlag : System.IEquatable<Azure.ResourceManager.IoTFirmwareDefense.Models.CanaryFlag>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CanaryFlag(string value) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.CanaryFlag False { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.CanaryFlag True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTFirmwareDefense.Models.CanaryFlag other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTFirmwareDefense.Models.CanaryFlag left, Azure.ResourceManager.IoTFirmwareDefense.Models.CanaryFlag right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTFirmwareDefense.Models.CanaryFlag (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTFirmwareDefense.Models.CanaryFlag left, Azure.ResourceManager.IoTFirmwareDefense.Models.CanaryFlag right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Component
    {
        internal Component() { }
        public string ComponentId { get { throw null; } }
        public string ComponentName { get { throw null; } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.IsUpdateAvailable? IsUpdateAvailable { get { throw null; } }
        public string License { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Paths { get { throw null; } }
        public System.DateTimeOffset? ReleaseOn { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class CryptoCertificate
    {
        internal CryptoCertificate() { }
        public string CryptoCertId { get { throw null; } }
        public string Encoding { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> FilePaths { get { throw null; } }
        public string Fingerprint { get { throw null; } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.IsExpired? IsExpired { get { throw null; } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.IsSelfSigned? IsSelfSigned { get { throw null; } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.IsShortKeySize? IsShortKeySize { get { throw null; } }
        public System.DateTimeOffset? IssuedOn { get { throw null; } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.CryptoCertificateEntity Issuer { get { throw null; } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.IsWeakSignature? IsWeakSignature { get { throw null; } }
        public string KeyAlgorithm { get { throw null; } }
        public long? KeySize { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.PairedKey PairedKey { get { throw null; } }
        public string Role { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public string SignatureAlgorithm { get { throw null; } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.CryptoCertificateEntity Subject { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Usage { get { throw null; } }
    }
    public partial class CryptoCertificateEntity
    {
        internal CryptoCertificateEntity() { }
        public string CommonName { get { throw null; } }
        public string Country { get { throw null; } }
        public string Organization { get { throw null; } }
        public string OrganizationalUnit { get { throw null; } }
        public string State { get { throw null; } }
    }
    public partial class CryptoCertificateSummary
    {
        internal CryptoCertificateSummary() { }
        public long? Expired { get { throw null; } }
        public long? ExpiringSoon { get { throw null; } }
        public long? PairedKeys { get { throw null; } }
        public long? SelfSigned { get { throw null; } }
        public long? ShortKeySize { get { throw null; } }
        public long? TotalCertificates { get { throw null; } }
        public long? WeakSignature { get { throw null; } }
    }
    public partial class CryptoKey
    {
        internal CryptoKey() { }
        public string CryptoKeyId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> FilePaths { get { throw null; } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.IsShortKeySize? IsShortKeySize { get { throw null; } }
        public string KeyAlgorithm { get { throw null; } }
        public long? KeySize { get { throw null; } }
        public string KeyType { get { throw null; } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.PairedKey PairedKey { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Usage { get { throw null; } }
    }
    public partial class CryptoKeySummary
    {
        internal CryptoKeySummary() { }
        public long? PairedKeys { get { throw null; } }
        public long? PrivateKeys { get { throw null; } }
        public long? PublicKeys { get { throw null; } }
        public long? ShortKeySize { get { throw null; } }
        public long? TotalKeys { get { throw null; } }
    }
    public partial class Cve
    {
        internal Cve() { }
        public System.BinaryData Component { get { throw null; } }
        public string CveId { get { throw null; } }
        public string CvssScore { get { throw null; } }
        public string CvssV2Score { get { throw null; } }
        public string CvssV3Score { get { throw null; } }
        public string CvssVersion { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.IoTFirmwareDefense.Models.CveLink> Links { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? PublishOn { get { throw null; } }
        public string Severity { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
    }
    public partial class CveLink
    {
        internal CveLink() { }
        public string Href { get { throw null; } }
        public string Label { get { throw null; } }
    }
    public partial class CveSummary
    {
        internal CveSummary() { }
        public long? Critical { get { throw null; } }
        public long? High { get { throw null; } }
        public long? Low { get { throw null; } }
        public long? Medium { get { throw null; } }
        public long? Undefined { get { throw null; } }
        public long? Unknown { get { throw null; } }
    }
    public partial class FirmwarePatch
    {
        public FirmwarePatch() { }
        public string Description { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public long? FileSize { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.Status? Status { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> StatusMessages { get { throw null; } }
        public string Vendor { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class FirmwareSummary
    {
        internal FirmwareSummary() { }
        public long? AnalysisTimeSeconds { get { throw null; } }
        public long? BinaryCount { get { throw null; } }
        public long? ComponentCount { get { throw null; } }
        public long? ExtractedFileCount { get { throw null; } }
        public long? ExtractedSize { get { throw null; } }
        public long? FileSize { get { throw null; } }
        public long? RootFileSystems { get { throw null; } }
    }
    public partial class GenerateUploadUrlContent
    {
        public GenerateUploadUrlContent() { }
        public string FirmwareId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsExpired : System.IEquatable<Azure.ResourceManager.IoTFirmwareDefense.Models.IsExpired>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsExpired(string value) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.IsExpired False { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.IsExpired True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTFirmwareDefense.Models.IsExpired other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTFirmwareDefense.Models.IsExpired left, Azure.ResourceManager.IoTFirmwareDefense.Models.IsExpired right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTFirmwareDefense.Models.IsExpired (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTFirmwareDefense.Models.IsExpired left, Azure.ResourceManager.IoTFirmwareDefense.Models.IsExpired right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsSelfSigned : System.IEquatable<Azure.ResourceManager.IoTFirmwareDefense.Models.IsSelfSigned>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsSelfSigned(string value) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.IsSelfSigned False { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.IsSelfSigned True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTFirmwareDefense.Models.IsSelfSigned other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTFirmwareDefense.Models.IsSelfSigned left, Azure.ResourceManager.IoTFirmwareDefense.Models.IsSelfSigned right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTFirmwareDefense.Models.IsSelfSigned (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTFirmwareDefense.Models.IsSelfSigned left, Azure.ResourceManager.IoTFirmwareDefense.Models.IsSelfSigned right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsShortKeySize : System.IEquatable<Azure.ResourceManager.IoTFirmwareDefense.Models.IsShortKeySize>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsShortKeySize(string value) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.IsShortKeySize False { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.IsShortKeySize True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTFirmwareDefense.Models.IsShortKeySize other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTFirmwareDefense.Models.IsShortKeySize left, Azure.ResourceManager.IoTFirmwareDefense.Models.IsShortKeySize right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTFirmwareDefense.Models.IsShortKeySize (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTFirmwareDefense.Models.IsShortKeySize left, Azure.ResourceManager.IoTFirmwareDefense.Models.IsShortKeySize right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsUpdateAvailable : System.IEquatable<Azure.ResourceManager.IoTFirmwareDefense.Models.IsUpdateAvailable>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsUpdateAvailable(string value) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.IsUpdateAvailable False { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.IsUpdateAvailable True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTFirmwareDefense.Models.IsUpdateAvailable other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTFirmwareDefense.Models.IsUpdateAvailable left, Azure.ResourceManager.IoTFirmwareDefense.Models.IsUpdateAvailable right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTFirmwareDefense.Models.IsUpdateAvailable (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTFirmwareDefense.Models.IsUpdateAvailable left, Azure.ResourceManager.IoTFirmwareDefense.Models.IsUpdateAvailable right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsWeakSignature : System.IEquatable<Azure.ResourceManager.IoTFirmwareDefense.Models.IsWeakSignature>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsWeakSignature(string value) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.IsWeakSignature False { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.IsWeakSignature True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTFirmwareDefense.Models.IsWeakSignature other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTFirmwareDefense.Models.IsWeakSignature left, Azure.ResourceManager.IoTFirmwareDefense.Models.IsWeakSignature right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTFirmwareDefense.Models.IsWeakSignature (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTFirmwareDefense.Models.IsWeakSignature left, Azure.ResourceManager.IoTFirmwareDefense.Models.IsWeakSignature right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NxFlag : System.IEquatable<Azure.ResourceManager.IoTFirmwareDefense.Models.NxFlag>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NxFlag(string value) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.NxFlag False { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.NxFlag True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTFirmwareDefense.Models.NxFlag other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTFirmwareDefense.Models.NxFlag left, Azure.ResourceManager.IoTFirmwareDefense.Models.NxFlag right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTFirmwareDefense.Models.NxFlag (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTFirmwareDefense.Models.NxFlag left, Azure.ResourceManager.IoTFirmwareDefense.Models.NxFlag right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PairedKey
    {
        internal PairedKey() { }
        public System.BinaryData AdditionalProperties { get { throw null; } }
        public string Id { get { throw null; } }
        public string PairedKeyType { get { throw null; } }
    }
    public partial class PasswordHash
    {
        internal PasswordHash() { }
        public string Algorithm { get { throw null; } }
        public string Context { get { throw null; } }
        public string FilePath { get { throw null; } }
        public string Hash { get { throw null; } }
        public string PasswordHashId { get { throw null; } }
        public string Salt { get { throw null; } }
        public string Username { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PieFlag : System.IEquatable<Azure.ResourceManager.IoTFirmwareDefense.Models.PieFlag>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PieFlag(string value) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.PieFlag False { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.PieFlag True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTFirmwareDefense.Models.PieFlag other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTFirmwareDefense.Models.PieFlag left, Azure.ResourceManager.IoTFirmwareDefense.Models.PieFlag right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTFirmwareDefense.Models.PieFlag (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTFirmwareDefense.Models.PieFlag left, Azure.ResourceManager.IoTFirmwareDefense.Models.PieFlag right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.IoTFirmwareDefense.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTFirmwareDefense.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTFirmwareDefense.Models.ProvisioningState left, Azure.ResourceManager.IoTFirmwareDefense.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTFirmwareDefense.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTFirmwareDefense.Models.ProvisioningState left, Azure.ResourceManager.IoTFirmwareDefense.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RelroFlag : System.IEquatable<Azure.ResourceManager.IoTFirmwareDefense.Models.RelroFlag>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RelroFlag(string value) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.RelroFlag False { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.RelroFlag True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTFirmwareDefense.Models.RelroFlag other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTFirmwareDefense.Models.RelroFlag left, Azure.ResourceManager.IoTFirmwareDefense.Models.RelroFlag right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTFirmwareDefense.Models.RelroFlag (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTFirmwareDefense.Models.RelroFlag left, Azure.ResourceManager.IoTFirmwareDefense.Models.RelroFlag right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Status : System.IEquatable<Azure.ResourceManager.IoTFirmwareDefense.Models.Status>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Status(string value) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.Status Analyzing { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.Status Error { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.Status Extracting { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.Status Pending { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.Status Ready { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTFirmwareDefense.Models.Status other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTFirmwareDefense.Models.Status left, Azure.ResourceManager.IoTFirmwareDefense.Models.Status right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTFirmwareDefense.Models.Status (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTFirmwareDefense.Models.Status left, Azure.ResourceManager.IoTFirmwareDefense.Models.Status right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StrippedFlag : System.IEquatable<Azure.ResourceManager.IoTFirmwareDefense.Models.StrippedFlag>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StrippedFlag(string value) { throw null; }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.StrippedFlag False { get { throw null; } }
        public static Azure.ResourceManager.IoTFirmwareDefense.Models.StrippedFlag True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTFirmwareDefense.Models.StrippedFlag other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTFirmwareDefense.Models.StrippedFlag left, Azure.ResourceManager.IoTFirmwareDefense.Models.StrippedFlag right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTFirmwareDefense.Models.StrippedFlag (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTFirmwareDefense.Models.StrippedFlag left, Azure.ResourceManager.IoTFirmwareDefense.Models.StrippedFlag right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UrlToken
    {
        internal UrlToken() { }
        public System.Uri UploadUri { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
    }
    public partial class WorkspacePatch
    {
        public WorkspacePatch() { }
        public Azure.ResourceManager.IoTFirmwareDefense.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
}
