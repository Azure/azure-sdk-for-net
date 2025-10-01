namespace Azure.Storage.Blobs
{
    public partial class BlobClient : Azure.Storage.Blobs.Specialized.BlobBaseClient
    {
        protected BlobClient() { }
        public BlobClient(string connectionString, string blobContainerName, string blobName) { }
        public BlobClient(string connectionString, string blobContainerName, string blobName, Azure.Storage.Blobs.BlobClientOptions options) { }
        public BlobClient(System.Uri blobUri, Azure.AzureSasCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public BlobClient(System.Uri blobUri, Azure.Core.TokenCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public BlobClient(System.Uri blobUri, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public BlobClient(System.Uri blobUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public virtual System.IO.Stream OpenWrite(bool overwrite, Azure.Storage.Blobs.Models.BlobOpenWriteOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.IO.Stream> OpenWriteAsync(bool overwrite, Azure.Storage.Blobs.Models.BlobOpenWriteOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> Upload(System.BinaryData content) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> Upload(System.BinaryData content, Azure.Storage.Blobs.Models.BlobUploadOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> Upload(System.BinaryData content, bool overwrite = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> Upload(System.BinaryData content, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> Upload(System.IO.Stream content) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> Upload(System.IO.Stream content, Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.IProgress<long> progressHandler = null, Azure.Storage.Blobs.Models.AccessTier? accessTier = default(Azure.Storage.Blobs.Models.AccessTier?), Azure.Storage.StorageTransferOptions transferOptions = default(Azure.Storage.StorageTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> Upload(System.IO.Stream content, Azure.Storage.Blobs.Models.BlobUploadOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> Upload(System.IO.Stream content, bool overwrite = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> Upload(System.IO.Stream content, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> Upload(string path) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> Upload(string path, Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.IProgress<long> progressHandler = null, Azure.Storage.Blobs.Models.AccessTier? accessTier = default(Azure.Storage.Blobs.Models.AccessTier?), Azure.Storage.StorageTransferOptions transferOptions = default(Azure.Storage.StorageTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> Upload(string path, Azure.Storage.Blobs.Models.BlobUploadOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> Upload(string path, bool overwrite = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> Upload(string path, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> UploadAsync(System.BinaryData content) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> UploadAsync(System.BinaryData content, Azure.Storage.Blobs.Models.BlobUploadOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> UploadAsync(System.BinaryData content, bool overwrite = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> UploadAsync(System.BinaryData content, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> UploadAsync(System.IO.Stream content) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> UploadAsync(System.IO.Stream content, Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.IProgress<long> progressHandler = null, Azure.Storage.Blobs.Models.AccessTier? accessTier = default(Azure.Storage.Blobs.Models.AccessTier?), Azure.Storage.StorageTransferOptions transferOptions = default(Azure.Storage.StorageTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> UploadAsync(System.IO.Stream content, Azure.Storage.Blobs.Models.BlobUploadOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> UploadAsync(System.IO.Stream content, bool overwrite = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> UploadAsync(System.IO.Stream content, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> UploadAsync(string path) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> UploadAsync(string path, Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.IProgress<long> progressHandler = null, Azure.Storage.Blobs.Models.AccessTier? accessTier = default(Azure.Storage.Blobs.Models.AccessTier?), Azure.Storage.StorageTransferOptions transferOptions = default(Azure.Storage.StorageTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> UploadAsync(string path, Azure.Storage.Blobs.Models.BlobUploadOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> UploadAsync(string path, bool overwrite = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> UploadAsync(string path, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected internal virtual Azure.Storage.Blobs.BlobClient WithClientSideEncryptionOptionsCore(Azure.Storage.ClientSideEncryptionOptions clientSideEncryptionOptions) { throw null; }
        public new Azure.Storage.Blobs.BlobClient WithCustomerProvidedKey(Azure.Storage.Blobs.Models.CustomerProvidedKey? customerProvidedKey) { throw null; }
        public new Azure.Storage.Blobs.BlobClient WithEncryptionScope(string encryptionScope) { throw null; }
        public new Azure.Storage.Blobs.BlobClient WithSnapshot(string snapshot) { throw null; }
        public new Azure.Storage.Blobs.BlobClient WithVersion(string versionId) { throw null; }
    }
    public partial class BlobClientOptions : Azure.Core.ClientOptions
    {
        public BlobClientOptions(Azure.Storage.Blobs.BlobClientOptions.ServiceVersion version = Azure.Storage.Blobs.BlobClientOptions.ServiceVersion.V2026_02_06) { }
        public Azure.Storage.Blobs.Models.BlobAudience? Audience { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.CustomerProvidedKey? CustomerProvidedKey { get { throw null; } set { } }
        public bool EnableTenantDiscovery { get { throw null; } set { } }
        public string EncryptionScope { get { throw null; } set { } }
        public System.Uri GeoRedundantSecondaryUri { get { throw null; } set { } }
        public Azure.Storage.Request100ContinueOptions Request100ContinueOptions { get { throw null; } set { } }
        public Azure.Storage.TransferValidationOptions TransferValidation { get { throw null; } }
        public bool TrimBlobNameSlashes { get { throw null; } set { } }
        public Azure.Storage.Blobs.BlobClientOptions.ServiceVersion Version { get { throw null; } }
        public enum ServiceVersion
        {
            V2019_02_02 = 1,
            V2019_07_07 = 2,
            V2019_12_12 = 3,
            V2020_02_10 = 4,
            V2020_04_08 = 5,
            V2020_06_12 = 6,
            V2020_08_04 = 7,
            V2020_10_02 = 8,
            V2020_12_06 = 9,
            V2021_02_12 = 10,
            V2021_04_10 = 11,
            V2021_06_08 = 12,
            V2021_08_06 = 13,
            V2021_10_04 = 14,
            V2021_12_02 = 15,
            V2022_11_02 = 16,
            V2023_01_03 = 17,
            V2023_05_03 = 18,
            V2023_08_03 = 19,
            V2023_11_03 = 20,
            V2024_02_04 = 21,
            V2024_05_04 = 22,
            V2024_08_04 = 23,
            V2024_11_04 = 24,
            V2025_01_05 = 25,
            V2025_05_05 = 26,
            V2025_07_05 = 27,
            V2025_11_05 = 28,
            V2026_02_06 = 29,
            V2026_04_06 = 30,
        }
    }
    public partial class BlobContainerClient
    {
        public static readonly string LogsBlobContainerName;
        public static readonly string RootBlobContainerName;
        public static readonly string WebBlobContainerName;
        protected BlobContainerClient() { }
        public BlobContainerClient(string connectionString, string blobContainerName) { }
        public BlobContainerClient(string connectionString, string blobContainerName, Azure.Storage.Blobs.BlobClientOptions options) { }
        public BlobContainerClient(System.Uri blobContainerUri, Azure.AzureSasCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public BlobContainerClient(System.Uri blobContainerUri, Azure.Core.TokenCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public BlobContainerClient(System.Uri blobContainerUri, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public BlobContainerClient(System.Uri blobContainerUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public virtual string AccountName { get { throw null; } }
        public virtual bool CanGenerateSasUri { get { throw null; } }
        public virtual string Name { get { throw null; } }
        public virtual System.Uri Uri { get { throw null; } }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContainerInfo> Create(Azure.Storage.Blobs.Models.PublicAccessType publicAccessType = Azure.Storage.Blobs.Models.PublicAccessType.None, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.BlobContainerEncryptionScopeOptions encryptionScopeOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContainerInfo> Create(Azure.Storage.Blobs.Models.PublicAccessType publicAccessType, System.Collections.Generic.IDictionary<string, string> metadata, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContainerInfo>> CreateAsync(Azure.Storage.Blobs.Models.PublicAccessType publicAccessType = Azure.Storage.Blobs.Models.PublicAccessType.None, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.BlobContainerEncryptionScopeOptions encryptionScopeOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContainerInfo>> CreateAsync(Azure.Storage.Blobs.Models.PublicAccessType publicAccessType, System.Collections.Generic.IDictionary<string, string> metadata, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected static Azure.Storage.Blobs.BlobContainerClient CreateClient(System.Uri containerUri, Azure.Storage.Blobs.BlobClientOptions options, Azure.Core.Pipeline.HttpPipeline pipeline) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContainerInfo> CreateIfNotExists(Azure.Storage.Blobs.Models.PublicAccessType publicAccessType = Azure.Storage.Blobs.Models.PublicAccessType.None, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.BlobContainerEncryptionScopeOptions encryptionScopeOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContainerInfo> CreateIfNotExists(Azure.Storage.Blobs.Models.PublicAccessType publicAccessType, System.Collections.Generic.IDictionary<string, string> metadata, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContainerInfo>> CreateIfNotExistsAsync(Azure.Storage.Blobs.Models.PublicAccessType publicAccessType = Azure.Storage.Blobs.Models.PublicAccessType.None, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.BlobContainerEncryptionScopeOptions encryptionScopeOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContainerInfo>> CreateIfNotExistsAsync(Azure.Storage.Blobs.Models.PublicAccessType publicAccessType, System.Collections.Generic.IDictionary<string, string> metadata, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response Delete(Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteBlob(string blobName, Azure.Storage.Blobs.Models.DeleteSnapshotsOption snapshotsOption = Azure.Storage.Blobs.Models.DeleteSnapshotsOption.None, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteBlobAsync(string blobName, Azure.Storage.Blobs.Models.DeleteSnapshotsOption snapshotsOption = Azure.Storage.Blobs.Models.DeleteSnapshotsOption.None, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> DeleteBlobIfExists(string blobName, Azure.Storage.Blobs.Models.DeleteSnapshotsOption snapshotsOption = Azure.Storage.Blobs.Models.DeleteSnapshotsOption.None, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> DeleteBlobIfExistsAsync(string blobName, Azure.Storage.Blobs.Models.DeleteSnapshotsOption snapshotsOption = Azure.Storage.Blobs.Models.DeleteSnapshotsOption.None, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> DeleteIfExists(Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> DeleteIfExistsAsync(Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Storage.Blobs.Models.TaggedBlobItem> FindBlobsByTags(string tagFilterSqlExpression, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Blobs.Models.TaggedBlobItem> FindBlobsByTagsAsync(string tagFilterSqlExpression, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Uri GenerateSasUri(Azure.Storage.Sas.BlobContainerSasPermissions permissions, System.DateTimeOffset expiresOn) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Uri GenerateSasUri(Azure.Storage.Sas.BlobContainerSasPermissions permissions, System.DateTimeOffset expiresOn, out string stringToSign) { throw null; }
        public virtual System.Uri GenerateSasUri(Azure.Storage.Sas.BlobSasBuilder builder) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Uri GenerateSasUri(Azure.Storage.Sas.BlobSasBuilder builder, out string stringToSign) { throw null; }
        public virtual System.Uri GenerateUserDelegationSasUri(Azure.Storage.Sas.BlobContainerSasPermissions permissions, System.DateTimeOffset expiresOn, Azure.Storage.Blobs.Models.UserDelegationKey userDelegationKey) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Uri GenerateUserDelegationSasUri(Azure.Storage.Sas.BlobContainerSasPermissions permissions, System.DateTimeOffset expiresOn, Azure.Storage.Blobs.Models.UserDelegationKey userDelegationKey, out string stringToSign) { throw null; }
        public virtual System.Uri GenerateUserDelegationSasUri(Azure.Storage.Sas.BlobSasBuilder builder, Azure.Storage.Blobs.Models.UserDelegationKey userDelegationKey) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Uri GenerateUserDelegationSasUri(Azure.Storage.Sas.BlobSasBuilder builder, Azure.Storage.Blobs.Models.UserDelegationKey userDelegationKey, out string stringToSign) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContainerAccessPolicy> GetAccessPolicy(Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContainerAccessPolicy>> GetAccessPolicyAsync(Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.AccountInfo> GetAccountInfo(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.AccountInfo>> GetAccountInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected internal virtual Azure.Storage.Blobs.Specialized.AppendBlobClient GetAppendBlobClientCore(string blobName) { throw null; }
        protected internal virtual Azure.Storage.Blobs.Specialized.BlobBaseClient GetBlobBaseClientCore(string blobName) { throw null; }
        public virtual Azure.Storage.Blobs.BlobClient GetBlobClient(string blobName) { throw null; }
        protected internal virtual Azure.Storage.Blobs.Specialized.BlobLeaseClient GetBlobLeaseClientCore(string leaseId) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.Storage.Blobs.Models.BlobItem> GetBlobs(Azure.Storage.Blobs.Models.BlobTraits traits, Azure.Storage.Blobs.Models.BlobStates states, string prefix, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Pageable<Azure.Storage.Blobs.Models.BlobItem> GetBlobs(Azure.Storage.Blobs.Models.GetBlobsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.Storage.Blobs.Models.BlobItem> GetBlobsAsync(Azure.Storage.Blobs.Models.BlobTraits traits, Azure.Storage.Blobs.Models.BlobStates states, string prefix, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Blobs.Models.BlobItem> GetBlobsAsync(Azure.Storage.Blobs.Models.GetBlobsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.Storage.Blobs.Models.BlobHierarchyItem> GetBlobsByHierarchy(Azure.Storage.Blobs.Models.BlobTraits traits, Azure.Storage.Blobs.Models.BlobStates states, string delimiter, string prefix, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Storage.Blobs.Models.BlobHierarchyItem> GetBlobsByHierarchy(Azure.Storage.Blobs.Models.GetBlobsByHierarchyOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.Storage.Blobs.Models.BlobHierarchyItem> GetBlobsByHierarchyAsync(Azure.Storage.Blobs.Models.BlobTraits traits, Azure.Storage.Blobs.Models.BlobStates states, string delimiter, string prefix, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Blobs.Models.BlobHierarchyItem> GetBlobsByHierarchyAsync(Azure.Storage.Blobs.Models.GetBlobsByHierarchyOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected internal virtual Azure.Storage.Blobs.Specialized.BlockBlobClient GetBlockBlobClientCore(string blobName) { throw null; }
        protected internal virtual Azure.Storage.Blobs.Specialized.PageBlobClient GetPageBlobClientCore(string blobName) { throw null; }
        protected internal virtual Azure.Storage.Blobs.BlobServiceClient GetParentBlobServiceClientCore() { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContainerProperties> GetProperties(Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContainerProperties>> GetPropertiesAsync(Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContainerInfo> SetAccessPolicy(Azure.Storage.Blobs.Models.PublicAccessType accessType = Azure.Storage.Blobs.Models.PublicAccessType.None, System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.BlobSignedIdentifier> permissions = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContainerInfo>> SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType accessType = Azure.Storage.Blobs.Models.PublicAccessType.None, System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.BlobSignedIdentifier> permissions = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContainerInfo> SetMetadata(System.Collections.Generic.IDictionary<string, string> metadata, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContainerInfo>> SetMetadataAsync(System.Collections.Generic.IDictionary<string, string> metadata, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> UploadBlob(string blobName, System.BinaryData content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> UploadBlob(string blobName, System.IO.Stream content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> UploadBlobAsync(string blobName, System.BinaryData content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> UploadBlobAsync(string blobName, System.IO.Stream content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BlobServiceClient
    {
        protected BlobServiceClient() { }
        public BlobServiceClient(string connectionString) { }
        public BlobServiceClient(string connectionString, Azure.Storage.Blobs.BlobClientOptions options) { }
        public BlobServiceClient(System.Uri serviceUri, Azure.AzureSasCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public BlobServiceClient(System.Uri serviceUri, Azure.Core.TokenCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public BlobServiceClient(System.Uri serviceUri, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public BlobServiceClient(System.Uri serviceUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public virtual string AccountName { get { throw null; } }
        public virtual bool CanGenerateAccountSasUri { get { throw null; } }
        public virtual System.Uri Uri { get { throw null; } }
        public virtual Azure.Response<Azure.Storage.Blobs.BlobContainerClient> CreateBlobContainer(string blobContainerName, Azure.Storage.Blobs.Models.PublicAccessType publicAccessType = Azure.Storage.Blobs.Models.PublicAccessType.None, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.BlobContainerClient>> CreateBlobContainerAsync(string blobContainerName, Azure.Storage.Blobs.Models.PublicAccessType publicAccessType = Azure.Storage.Blobs.Models.PublicAccessType.None, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        protected static Azure.Storage.Blobs.BlobServiceClient CreateClient(System.Uri serviceUri, Azure.Storage.Blobs.BlobClientOptions options, Azure.Core.Pipeline.HttpPipelinePolicy authentication, Azure.Core.Pipeline.HttpPipeline pipeline) { throw null; }
        protected static Azure.Storage.Blobs.BlobServiceClient CreateClient(System.Uri serviceUri, Azure.Storage.Blobs.BlobClientOptions options, Azure.Core.Pipeline.HttpPipelinePolicy authentication, Azure.Core.Pipeline.HttpPipeline pipeline, Azure.Storage.StorageSharedKeyCredential sharedKeyCredential, Azure.AzureSasCredential sasCredential, Azure.Core.TokenCredential tokenCredential) { throw null; }
        public virtual Azure.Response DeleteBlobContainer(string blobContainerName, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteBlobContainerAsync(string blobContainerName, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Storage.Blobs.Models.TaggedBlobItem> FindBlobsByTags(string tagFilterSqlExpression, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Blobs.Models.TaggedBlobItem> FindBlobsByTagsAsync(string tagFilterSqlExpression, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Uri GenerateAccountSasUri(Azure.Storage.Sas.AccountSasBuilder builder) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Uri GenerateAccountSasUri(Azure.Storage.Sas.AccountSasBuilder builder, out string stringToSign) { throw null; }
        public System.Uri GenerateAccountSasUri(Azure.Storage.Sas.AccountSasPermissions permissions, System.DateTimeOffset expiresOn, Azure.Storage.Sas.AccountSasResourceTypes resourceTypes) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Uri GenerateAccountSasUri(Azure.Storage.Sas.AccountSasPermissions permissions, System.DateTimeOffset expiresOn, Azure.Storage.Sas.AccountSasResourceTypes resourceTypes, out string stringToSign) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.AccountInfo> GetAccountInfo(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.AccountInfo>> GetAccountInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected static Azure.Core.Pipeline.HttpPipelinePolicy GetAuthenticationPolicy(Azure.Storage.Blobs.BlobServiceClient client) { throw null; }
        public virtual Azure.Storage.Blobs.BlobContainerClient GetBlobContainerClient(string blobContainerName) { throw null; }
        public virtual Azure.Pageable<Azure.Storage.Blobs.Models.BlobContainerItem> GetBlobContainers(Azure.Storage.Blobs.Models.BlobContainerTraits traits = Azure.Storage.Blobs.Models.BlobContainerTraits.None, Azure.Storage.Blobs.Models.BlobContainerStates states = Azure.Storage.Blobs.Models.BlobContainerStates.None, string prefix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.Storage.Blobs.Models.BlobContainerItem> GetBlobContainers(Azure.Storage.Blobs.Models.BlobContainerTraits traits, string prefix, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Blobs.Models.BlobContainerItem> GetBlobContainersAsync(Azure.Storage.Blobs.Models.BlobContainerTraits traits = Azure.Storage.Blobs.Models.BlobContainerTraits.None, Azure.Storage.Blobs.Models.BlobContainerStates states = Azure.Storage.Blobs.Models.BlobContainerStates.None, string prefix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.Storage.Blobs.Models.BlobContainerItem> GetBlobContainersAsync(Azure.Storage.Blobs.Models.BlobContainerTraits traits, string prefix, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected static Azure.Storage.Blobs.BlobClientOptions GetClientOptions(Azure.Storage.Blobs.BlobServiceClient client) { throw null; }
        protected static Azure.Core.Pipeline.HttpPipeline GetHttpPipeline(Azure.Storage.Blobs.BlobServiceClient client) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobServiceProperties> GetProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobServiceProperties>> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobServiceStatistics> GetStatistics(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobServiceStatistics>> GetStatisticsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.UserDelegationKey> GetUserDelegationKey(System.DateTimeOffset? startsOn, System.DateTimeOffset expiresOn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.UserDelegationKey>> GetUserDelegationKeyAsync(System.DateTimeOffset? startsOn, System.DateTimeOffset expiresOn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetProperties(Azure.Storage.Blobs.Models.BlobServiceProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetPropertiesAsync(Azure.Storage.Blobs.Models.BlobServiceProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Blobs.BlobContainerClient> UndeleteBlobContainer(string deletedContainerName, string deletedContainerVersion, string destinationContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.BlobContainerClient> UndeleteBlobContainer(string deletedContainerName, string deletedContainerVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.BlobContainerClient>> UndeleteBlobContainerAsync(string deletedContainerName, string deletedContainerVersion, string destinationContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.BlobContainerClient>> UndeleteBlobContainerAsync(string deletedContainerName, string deletedContainerVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BlobUriBuilder
    {
        public BlobUriBuilder(System.Uri uri) { }
        public BlobUriBuilder(System.Uri uri, bool trimBlobNameSlashes) { }
        public string AccountName { get { throw null; } set { } }
        public string BlobContainerName { get { throw null; } set { } }
        public string BlobName { get { throw null; } set { } }
        public string Host { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public Azure.Storage.Sas.BlobSasQueryParameters Sas { get { throw null; } set { } }
        public string Scheme { get { throw null; } set { } }
        public string Snapshot { get { throw null; } set { } }
        public bool TrimBlobNameSlashes { get { throw null; } }
        public string VersionId { get { throw null; } set { } }
        public override string ToString() { throw null; }
        public System.Uri ToUri() { throw null; }
    }
}
namespace Azure.Storage.Blobs.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessTier : System.IEquatable<Azure.Storage.Blobs.Models.AccessTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessTier(string value) { throw null; }
        public static Azure.Storage.Blobs.Models.AccessTier Archive { get { throw null; } }
        public static Azure.Storage.Blobs.Models.AccessTier Cold { get { throw null; } }
        public static Azure.Storage.Blobs.Models.AccessTier Cool { get { throw null; } }
        public static Azure.Storage.Blobs.Models.AccessTier Hot { get { throw null; } }
        public static Azure.Storage.Blobs.Models.AccessTier P10 { get { throw null; } }
        public static Azure.Storage.Blobs.Models.AccessTier P15 { get { throw null; } }
        public static Azure.Storage.Blobs.Models.AccessTier P20 { get { throw null; } }
        public static Azure.Storage.Blobs.Models.AccessTier P30 { get { throw null; } }
        public static Azure.Storage.Blobs.Models.AccessTier P4 { get { throw null; } }
        public static Azure.Storage.Blobs.Models.AccessTier P40 { get { throw null; } }
        public static Azure.Storage.Blobs.Models.AccessTier P50 { get { throw null; } }
        public static Azure.Storage.Blobs.Models.AccessTier P6 { get { throw null; } }
        public static Azure.Storage.Blobs.Models.AccessTier P60 { get { throw null; } }
        public static Azure.Storage.Blobs.Models.AccessTier P70 { get { throw null; } }
        public static Azure.Storage.Blobs.Models.AccessTier P80 { get { throw null; } }
        public static Azure.Storage.Blobs.Models.AccessTier Premium { get { throw null; } }
        public bool Equals(Azure.Storage.Blobs.Models.AccessTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Storage.Blobs.Models.AccessTier left, Azure.Storage.Blobs.Models.AccessTier right) { throw null; }
        public static implicit operator Azure.Storage.Blobs.Models.AccessTier (string value) { throw null; }
        public static bool operator !=(Azure.Storage.Blobs.Models.AccessTier left, Azure.Storage.Blobs.Models.AccessTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AccountInfo
    {
        internal AccountInfo() { }
        public Azure.Storage.Blobs.Models.AccountKind AccountKind { get { throw null; } }
        public bool IsHierarchicalNamespaceEnabled { get { throw null; } }
        public Azure.Storage.Blobs.Models.SkuName SkuName { get { throw null; } }
    }
    public enum AccountKind
    {
        Storage = 0,
        BlobStorage = 1,
        StorageV2 = 2,
        FileStorage = 3,
        BlockBlobStorage = 4,
    }
    public partial class AppendBlobAppendBlockFromUriOptions
    {
        public AppendBlobAppendBlockFromUriOptions() { }
        public Azure.Storage.Blobs.Models.AppendBlobRequestConditions DestinationConditions { get { throw null; } set { } }
        public Azure.HttpAuthorization SourceAuthentication { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.AppendBlobRequestConditions SourceConditions { get { throw null; } set { } }
        public byte[] SourceContentHash { get { throw null; } set { } }
        public Azure.HttpRange SourceRange { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.FileShareTokenIntent? SourceShareTokenIntent { get { throw null; } set { } }
    }
    public partial class AppendBlobAppendBlockOptions
    {
        public AppendBlobAppendBlockOptions() { }
        public Azure.Storage.Blobs.Models.AppendBlobRequestConditions Conditions { get { throw null; } set { } }
        public System.IProgress<long> ProgressHandler { get { throw null; } set { } }
        public Azure.Storage.UploadTransferValidationOptions TransferValidation { get { throw null; } set { } }
    }
    public partial class AppendBlobCreateOptions
    {
        public AppendBlobCreateOptions() { }
        public Azure.Storage.Blobs.Models.AppendBlobRequestConditions Conditions { get { throw null; } set { } }
        public bool? HasLegalHold { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobHttpHeaders HttpHeaders { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobImmutabilityPolicy ImmutabilityPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    public partial class AppendBlobOpenWriteOptions
    {
        public AppendBlobOpenWriteOptions() { }
        public long? BufferSize { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.AppendBlobRequestConditions OpenConditions { get { throw null; } set { } }
        public System.IProgress<long> ProgressHandler { get { throw null; } set { } }
        public Azure.Storage.UploadTransferValidationOptions TransferValidation { get { throw null; } set { } }
    }
    public partial class AppendBlobRequestConditions : Azure.Storage.Blobs.Models.BlobRequestConditions
    {
        public AppendBlobRequestConditions() { }
        public long? IfAppendPositionEqual { get { throw null; } set { } }
        public long? IfMaxSizeLessThanOrEqual { get { throw null; } set { } }
    }
    public enum ArchiveStatus
    {
        RehydratePendingToHot = 0,
        RehydratePendingToCool = 1,
        RehydratePendingToCold = 2,
    }
    public partial class BlobAccessPolicy
    {
        public BlobAccessPolicy() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.DateTimeOffset ExpiresOn { get { throw null; } set { } }
        public string Permissions { get { throw null; } set { } }
        public System.DateTimeOffset? PolicyExpiresOn { get { throw null; } set { } }
        public System.DateTimeOffset? PolicyStartsOn { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.DateTimeOffset StartsOn { get { throw null; } set { } }
    }
    public partial class BlobAnalyticsLogging
    {
        public BlobAnalyticsLogging() { }
        public bool Delete { get { throw null; } set { } }
        public bool Read { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobRetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        public bool Write { get { throw null; } set { } }
    }
    public partial class BlobAppendInfo
    {
        internal BlobAppendInfo() { }
        public string BlobAppendOffset { get { throw null; } }
        public int BlobCommittedBlockCount { get { throw null; } }
        public byte[] ContentCrc64 { get { throw null; } }
        public byte[] ContentHash { get { throw null; } }
        public string EncryptionKeySha256 { get { throw null; } }
        public string EncryptionScope { get { throw null; } }
        public Azure.ETag ETag { get { throw null; } }
        public bool IsServerEncrypted { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlobAudience : System.IEquatable<Azure.Storage.Blobs.Models.BlobAudience>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlobAudience(string value) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobAudience DefaultAudience { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobAudience CreateBlobServiceAccountAudience(string storageAccountName) { throw null; }
        public bool Equals(Azure.Storage.Blobs.Models.BlobAudience other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Storage.Blobs.Models.BlobAudience left, Azure.Storage.Blobs.Models.BlobAudience right) { throw null; }
        public static implicit operator Azure.Storage.Blobs.Models.BlobAudience (string value) { throw null; }
        public static bool operator !=(Azure.Storage.Blobs.Models.BlobAudience left, Azure.Storage.Blobs.Models.BlobAudience right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlobBlock : System.IEquatable<Azure.Storage.Blobs.Models.BlobBlock>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public string Name { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public int Size { get { throw null; } }
        public long SizeLong { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool Equals(Azure.Storage.Blobs.Models.BlobBlock other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
    }
    public partial class BlobContainerAccessPolicy
    {
        public BlobContainerAccessPolicy() { }
        public Azure.Storage.Blobs.Models.PublicAccessType BlobPublicAccess { get { throw null; } }
        public Azure.ETag ETag { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.BlobSignedIdentifier> SignedIdentifiers { get { throw null; } }
    }
    public partial class BlobContainerEncryptionScopeOptions
    {
        public BlobContainerEncryptionScopeOptions() { }
        public string DefaultEncryptionScope { get { throw null; } set { } }
        public bool PreventEncryptionScopeOverride { get { throw null; } set { } }
    }
    public partial class BlobContainerInfo
    {
        internal BlobContainerInfo() { }
        public Azure.ETag ETag { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
    }
    public partial class BlobContainerItem
    {
        internal BlobContainerItem() { }
        public bool? IsDeleted { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Storage.Blobs.Models.BlobContainerProperties Properties { get { throw null; } }
        public string VersionId { get { throw null; } }
    }
    public partial class BlobContainerProperties
    {
        internal BlobContainerProperties() { }
        public string DefaultEncryptionScope { get { throw null; } }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public Azure.ETag ETag { get { throw null; } }
        public bool? HasImmutabilityPolicy { get { throw null; } }
        public bool HasImmutableStorageWithVersioning { get { throw null; } }
        public bool? HasLegalHold { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public Azure.Storage.Blobs.Models.LeaseDurationType? LeaseDuration { get { throw null; } }
        public Azure.Storage.Blobs.Models.LeaseState? LeaseState { get { throw null; } }
        public Azure.Storage.Blobs.Models.LeaseStatus? LeaseStatus { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public bool? PreventEncryptionScopeOverride { get { throw null; } }
        public Azure.Storage.Blobs.Models.PublicAccessType? PublicAccess { get { throw null; } }
        public int? RemainingRetentionDays { get { throw null; } }
    }
    [System.FlagsAttribute]
    public enum BlobContainerStates
    {
        None = 0,
        Deleted = 1,
        System = 2,
    }
    [System.FlagsAttribute]
    public enum BlobContainerTraits
    {
        None = 0,
        Metadata = 1,
    }
    public partial class BlobContentInfo
    {
        internal BlobContentInfo() { }
        public long BlobSequenceNumber { get { throw null; } }
        public byte[] ContentHash { get { throw null; } }
        public string EncryptionKeySha256 { get { throw null; } }
        public string EncryptionScope { get { throw null; } }
        public Azure.ETag ETag { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public string VersionId { get { throw null; } }
    }
    public partial class BlobCopyFromUriOptions
    {
        public BlobCopyFromUriOptions() { }
        public Azure.Storage.Blobs.Models.AccessTier? AccessTier { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobCopySourceTagsMode? CopySourceTagsMode { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobRequestConditions DestinationConditions { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobImmutabilityPolicy DestinationImmutabilityPolicy { get { throw null; } set { } }
        public bool? LegalHold { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.RehydratePriority? RehydratePriority { get { throw null; } set { } }
        public bool? ShouldSealDestination { get { throw null; } set { } }
        public Azure.HttpAuthorization SourceAuthentication { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobRequestConditions SourceConditions { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.FileShareTokenIntent? SourceShareTokenIntent { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    public partial class BlobCopyInfo
    {
        internal BlobCopyInfo() { }
        public string CopyId { get { throw null; } }
        public Azure.Storage.Blobs.Models.CopyStatus CopyStatus { get { throw null; } }
        public string EncryptionScope { get { throw null; } }
        public Azure.ETag ETag { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public string VersionId { get { throw null; } }
    }
    public enum BlobCopySourceTagsMode
    {
        Replace = 0,
        Copy = 1,
    }
    public partial class BlobCorsRule
    {
        public BlobCorsRule() { }
        public string AllowedHeaders { get { throw null; } set { } }
        public string AllowedMethods { get { throw null; } set { } }
        public string AllowedOrigins { get { throw null; } set { } }
        public string ExposedHeaders { get { throw null; } set { } }
        public int MaxAgeInSeconds { get { throw null; } set { } }
    }
    public partial class BlobDownloadDetails
    {
        public BlobDownloadDetails() { }
        public string AcceptRanges { get { throw null; } }
        public int BlobCommittedBlockCount { get { throw null; } }
        public byte[] BlobContentHash { get { throw null; } }
        public long BlobSequenceNumber { get { throw null; } }
        public Azure.Storage.Blobs.Models.BlobType BlobType { get { throw null; } }
        public string CacheControl { get { throw null; } }
        public string ContentDisposition { get { throw null; } }
        public string ContentEncoding { get { throw null; } }
        public byte[] ContentHash { get { throw null; } }
        public string ContentLanguage { get { throw null; } }
        public long ContentLength { get { throw null; } }
        public string ContentRange { get { throw null; } }
        public string ContentType { get { throw null; } }
        public System.DateTimeOffset CopyCompletedOn { get { throw null; } }
        public string CopyId { get { throw null; } }
        public string CopyProgress { get { throw null; } }
        public System.Uri CopySource { get { throw null; } }
        public Azure.Storage.Blobs.Models.CopyStatus CopyStatus { get { throw null; } }
        public string CopyStatusDescription { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string EncryptionKeySha256 { get { throw null; } }
        public string EncryptionScope { get { throw null; } }
        public Azure.ETag ETag { get { throw null; } }
        public bool HasLegalHold { get { throw null; } }
        public Azure.Storage.Blobs.Models.BlobImmutabilityPolicy ImmutabilityPolicy { get { throw null; } }
        public bool IsSealed { get { throw null; } }
        public bool IsServerEncrypted { get { throw null; } }
        public System.DateTimeOffset LastAccessed { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public Azure.Storage.Blobs.Models.LeaseDurationType LeaseDuration { get { throw null; } }
        public Azure.Storage.Blobs.Models.LeaseState LeaseState { get { throw null; } }
        public Azure.Storage.Blobs.Models.LeaseStatus LeaseStatus { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string ObjectReplicationDestinationPolicyId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Storage.Blobs.Models.ObjectReplicationPolicy> ObjectReplicationSourceProperties { get { throw null; } }
        public long TagCount { get { throw null; } }
        public string VersionId { get { throw null; } }
    }
    public partial class BlobDownloadInfo : System.IDisposable
    {
        internal BlobDownloadInfo() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Storage.Blobs.Models.BlobType BlobType { get { throw null; } }
        public System.IO.Stream Content { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public byte[] ContentHash { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public long ContentLength { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string ContentType { get { throw null; } }
        public Azure.Storage.Blobs.Models.BlobDownloadDetails Details { get { throw null; } }
        public void Dispose() { }
    }
    public partial class BlobDownloadOptions
    {
        public BlobDownloadOptions() { }
        public Azure.Storage.Blobs.Models.BlobRequestConditions Conditions { get { throw null; } set { } }
        public System.IProgress<long> ProgressHandler { get { throw null; } set { } }
        public Azure.HttpRange Range { get { throw null; } set { } }
        public Azure.Storage.DownloadTransferValidationOptions TransferValidation { get { throw null; } set { } }
    }
    public partial class BlobDownloadResult
    {
        internal BlobDownloadResult() { }
        public System.BinaryData Content { get { throw null; } }
        public Azure.Storage.Blobs.Models.BlobDownloadDetails Details { get { throw null; } }
    }
    public partial class BlobDownloadStreamingResult : System.IDisposable
    {
        internal BlobDownloadStreamingResult() { }
        public System.IO.Stream Content { get { throw null; } }
        public Azure.Storage.Blobs.Models.BlobDownloadDetails Details { get { throw null; } }
        public void Dispose() { }
    }
    public partial class BlobDownloadToOptions
    {
        public BlobDownloadToOptions() { }
        public Azure.Storage.Blobs.Models.BlobRequestConditions Conditions { get { throw null; } set { } }
        public System.IProgress<long> ProgressHandler { get { throw null; } set { } }
        public Azure.Storage.StorageTransferOptions TransferOptions { get { throw null; } set { } }
        public Azure.Storage.DownloadTransferValidationOptions TransferValidation { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlobErrorCode : System.IEquatable<Azure.Storage.Blobs.Models.BlobErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlobErrorCode(string value) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobErrorCode AccountAlreadyExists { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode AccountBeingCreated { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode AccountIsDisabled { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode AppendPositionConditionNotMet { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode AuthenticationFailed { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode AuthorizationFailure { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode AuthorizationPermissionMismatch { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode AuthorizationProtocolMismatch { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode AuthorizationResourceTypeMismatch { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode AuthorizationServiceMismatch { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode AuthorizationSourceIPMismatch { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode BlobAccessTierNotSupportedForAccountType { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode BlobAlreadyExists { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode BlobArchived { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode BlobBeingRehydrated { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode BlobImmutableDueToPolicy { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode BlobNotArchived { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode BlobNotFound { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode BlobOverwritten { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode BlobTierInadequateForContentLength { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode BlobUsesCustomerSpecifiedEncryption { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode BlockCountExceedsLimit { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode BlockListTooLong { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode CannotChangeToLowerTier { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode CannotVerifyCopySource { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode ConditionHeadersNotSupported { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode ConditionNotMet { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode ContainerAlreadyExists { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode ContainerBeingDeleted { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode ContainerDisabled { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode ContainerNotFound { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode ContentLengthLargerThanTierLimit { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode CopyAcrossAccountsNotSupported { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode CopyIdMismatch { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode EmptyMetadataKey { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode FeatureVersionMismatch { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode IncrementalCopyBlobMismatch { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode IncrementalCopyOfEarlierVersionSnapshotNotAllowed { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlobErrorCode IncrementalCopyOfEralierVersionSnapshotNotAllowed { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode IncrementalCopySourceMustBeSnapshot { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode InfiniteLeaseDurationRequired { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode InsufficientAccountPermissions { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode InternalError { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidAuthenticationInfo { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidBlobOrBlock { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidBlobTier { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidBlobType { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidBlockId { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidBlockList { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidHeaderValue { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidHttpVerb { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidInput { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidMd5 { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidMetadata { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidOperation { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidPageRange { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidQueryParameterValue { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidRange { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidResourceName { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidSourceBlobType { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidSourceBlobUrl { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidUri { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidVersionForPageBlobOperation { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidXmlDocument { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode InvalidXmlNodeValue { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode LeaseAlreadyBroken { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode LeaseAlreadyPresent { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode LeaseIdMismatchWithBlobOperation { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode LeaseIdMismatchWithContainerOperation { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode LeaseIdMismatchWithLeaseOperation { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode LeaseIdMissing { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode LeaseIsBreakingAndCannotBeAcquired { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode LeaseIsBreakingAndCannotBeChanged { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode LeaseIsBrokenAndCannotBeRenewed { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode LeaseLost { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode LeaseNotPresentWithBlobOperation { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode LeaseNotPresentWithContainerOperation { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode LeaseNotPresentWithLeaseOperation { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode MaxBlobSizeConditionNotMet { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode Md5Mismatch { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode MetadataTooLarge { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode MissingContentLengthHeader { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode MissingRequiredHeader { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode MissingRequiredQueryParameter { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode MissingRequiredXmlNode { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode MultipleConditionHeadersNotSupported { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode NoAuthenticationInformation { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode NoPendingCopyOperation { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode OperationNotAllowedOnIncrementalCopyBlob { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode OperationTimedOut { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode OutOfRangeInput { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode OutOfRangeQueryParameterValue { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode PendingCopyOperation { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode PreviousSnapshotCannotBeNewer { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode PreviousSnapshotNotFound { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode PreviousSnapshotOperationNotSupported { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode RequestBodyTooLarge { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode RequestUrlFailedToParse { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode ResourceAlreadyExists { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode ResourceNotFound { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode ResourceTypeMismatch { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode SequenceNumberConditionNotMet { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode SequenceNumberIncrementTooLarge { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode ServerBusy { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlobErrorCode SnaphotOperationRateExceeded { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode SnapshotCountExceeded { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode SnapshotOperationRateExceeded { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode SnapshotsPresent { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode SourceConditionNotMet { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode SystemInUse { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode TargetConditionNotMet { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode UnauthorizedBlobOverwrite { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode UnsupportedHeader { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode UnsupportedHttpVerb { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode UnsupportedQueryParameter { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode UnsupportedXmlNode { get { throw null; } }
        public bool Equals(Azure.Storage.Blobs.Models.BlobErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        public bool Equals(string value) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Storage.Blobs.Models.BlobErrorCode left, Azure.Storage.Blobs.Models.BlobErrorCode right) { throw null; }
        public static bool operator ==(Azure.Storage.Blobs.Models.BlobErrorCode code, string value) { throw null; }
        public static bool operator ==(string value, Azure.Storage.Blobs.Models.BlobErrorCode code) { throw null; }
        public static implicit operator Azure.Storage.Blobs.Models.BlobErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.Storage.Blobs.Models.BlobErrorCode left, Azure.Storage.Blobs.Models.BlobErrorCode right) { throw null; }
        public static bool operator !=(Azure.Storage.Blobs.Models.BlobErrorCode code, string value) { throw null; }
        public static bool operator !=(string value, Azure.Storage.Blobs.Models.BlobErrorCode code) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BlobGeoReplication
    {
        internal BlobGeoReplication() { }
        public System.DateTimeOffset? LastSyncedOn { get { throw null; } }
        public Azure.Storage.Blobs.Models.BlobGeoReplicationStatus Status { get { throw null; } }
    }
    public enum BlobGeoReplicationStatus
    {
        Live = 0,
        Bootstrap = 1,
        Unavailable = 2,
    }
    public partial class BlobHierarchyItem
    {
        internal BlobHierarchyItem() { }
        public Azure.Storage.Blobs.Models.BlobItem Blob { get { throw null; } }
        public bool IsBlob { get { throw null; } }
        public bool IsPrefix { get { throw null; } }
        public string Prefix { get { throw null; } }
    }
    public partial class BlobHttpHeaders
    {
        public BlobHttpHeaders() { }
        public string CacheControl { get { throw null; } set { } }
        public string ContentDisposition { get { throw null; } set { } }
        public string ContentEncoding { get { throw null; } set { } }
        public byte[] ContentHash { get { throw null; } set { } }
        public string ContentLanguage { get { throw null; } set { } }
        public string ContentType { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class BlobImmutabilityPolicy
    {
        public BlobImmutabilityPolicy() { }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobImmutabilityPolicyMode? PolicyMode { get { throw null; } set { } }
    }
    public enum BlobImmutabilityPolicyMode
    {
        Mutable = 0,
        Unlocked = 1,
        Locked = 2,
    }
    public partial class BlobInfo
    {
        internal BlobInfo() { }
        public long BlobSequenceNumber { get { throw null; } }
        public Azure.ETag ETag { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public string VersionId { get { throw null; } }
    }
    public partial class BlobItem
    {
        internal BlobItem() { }
        public bool Deleted { get { throw null; } }
        public bool? HasVersionsOnly { get { throw null; } }
        public bool? IsLatestVersion { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Storage.Blobs.Models.ObjectReplicationPolicy> ObjectReplicationSourceProperties { get { throw null; } }
        public Azure.Storage.Blobs.Models.BlobItemProperties Properties { get { throw null; } }
        public string Snapshot { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string VersionId { get { throw null; } }
    }
    public partial class BlobItemProperties
    {
        internal BlobItemProperties() { }
        public Azure.Storage.Blobs.Models.AccessTier? AccessTier { get { throw null; } }
        public System.DateTimeOffset? AccessTierChangedOn { get { throw null; } }
        public bool AccessTierInferred { get { throw null; } }
        public Azure.Storage.Blobs.Models.ArchiveStatus? ArchiveStatus { get { throw null; } }
        public long? BlobSequenceNumber { get { throw null; } }
        public Azure.Storage.Blobs.Models.BlobType? BlobType { get { throw null; } }
        public string CacheControl { get { throw null; } }
        public string ContentDisposition { get { throw null; } }
        public string ContentEncoding { get { throw null; } }
        public byte[] ContentHash { get { throw null; } }
        public string ContentLanguage { get { throw null; } }
        public long? ContentLength { get { throw null; } }
        public string ContentType { get { throw null; } }
        public System.DateTimeOffset? CopyCompletedOn { get { throw null; } }
        public string CopyId { get { throw null; } }
        public string CopyProgress { get { throw null; } }
        public System.Uri CopySource { get { throw null; } }
        public Azure.Storage.Blobs.Models.CopyStatus? CopyStatus { get { throw null; } }
        public string CopyStatusDescription { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string CustomerProvidedKeySha256 { get { throw null; } }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public string DestinationSnapshot { get { throw null; } }
        public string EncryptionScope { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public bool HasLegalHold { get { throw null; } }
        public Azure.Storage.Blobs.Models.BlobImmutabilityPolicy ImmutabilityPolicy { get { throw null; } }
        public bool? IncrementalCopy { get { throw null; } }
        public bool? IsSealed { get { throw null; } }
        public System.DateTimeOffset? LastAccessedOn { get { throw null; } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public Azure.Storage.Blobs.Models.LeaseDurationType? LeaseDuration { get { throw null; } }
        public Azure.Storage.Blobs.Models.LeaseState? LeaseState { get { throw null; } }
        public Azure.Storage.Blobs.Models.LeaseStatus? LeaseStatus { get { throw null; } }
        public Azure.Storage.Blobs.Models.RehydratePriority? RehydratePriority { get { throw null; } }
        public int? RemainingRetentionDays { get { throw null; } }
        public bool? ServerEncrypted { get { throw null; } }
        public long? TagCount { get { throw null; } }
    }
    public partial class BlobLease
    {
        internal BlobLease() { }
        public Azure.ETag ETag { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public string LeaseId { get { throw null; } }
        public int? LeaseTime { get { throw null; } }
    }
    public partial class BlobLeaseRequestConditions : Azure.RequestConditions
    {
        public BlobLeaseRequestConditions() { }
        public string TagConditions { get { throw null; } set { } }
    }
    public partial class BlobLegalHoldResult
    {
        public BlobLegalHoldResult() { }
        public bool HasLegalHold { get { throw null; } }
    }
    public partial class BlobMetrics
    {
        public BlobMetrics() { }
        public bool Enabled { get { throw null; } set { } }
        public bool? IncludeApis { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobRetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class BlobOpenReadOptions
    {
        public BlobOpenReadOptions(bool allowModifications) { }
        public int? BufferSize { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobRequestConditions Conditions { get { throw null; } set { } }
        public long Position { get { throw null; } set { } }
        public Azure.Storage.DownloadTransferValidationOptions TransferValidation { get { throw null; } set { } }
    }
    public partial class BlobOpenWriteOptions
    {
        public BlobOpenWriteOptions() { }
        public long? BufferSize { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobHttpHeaders HttpHeaders { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobRequestConditions OpenConditions { get { throw null; } set { } }
        public System.IProgress<long> ProgressHandler { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
        public Azure.Storage.UploadTransferValidationOptions TransferValidation { get { throw null; } set { } }
    }
    public partial class BlobProperties
    {
        public BlobProperties() { }
        public string AcceptRanges { get { throw null; } }
        public string AccessTier { get { throw null; } }
        public System.DateTimeOffset AccessTierChangedOn { get { throw null; } }
        public bool AccessTierInferred { get { throw null; } }
        public string ArchiveStatus { get { throw null; } }
        public int BlobCommittedBlockCount { get { throw null; } }
        public Azure.Storage.Blobs.Models.CopyStatus? BlobCopyStatus { get { throw null; } }
        public long BlobSequenceNumber { get { throw null; } }
        public Azure.Storage.Blobs.Models.BlobType BlobType { get { throw null; } }
        public string CacheControl { get { throw null; } }
        public string ContentDisposition { get { throw null; } }
        public string ContentEncoding { get { throw null; } }
        public byte[] ContentHash { get { throw null; } }
        public string ContentLanguage { get { throw null; } }
        public long ContentLength { get { throw null; } }
        public string ContentType { get { throw null; } }
        public System.DateTimeOffset CopyCompletedOn { get { throw null; } }
        public string CopyId { get { throw null; } }
        public string CopyProgress { get { throw null; } }
        public System.Uri CopySource { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Storage.Blobs.Models.CopyStatus CopyStatus { get { throw null; } }
        public string CopyStatusDescription { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string DestinationSnapshot { get { throw null; } }
        public string EncryptionKeySha256 { get { throw null; } }
        public string EncryptionScope { get { throw null; } }
        public Azure.ETag ETag { get { throw null; } }
        public System.DateTimeOffset ExpiresOn { get { throw null; } }
        public bool HasLegalHold { get { throw null; } }
        public Azure.Storage.Blobs.Models.BlobImmutabilityPolicy ImmutabilityPolicy { get { throw null; } }
        public bool IsIncrementalCopy { get { throw null; } }
        public bool IsLatestVersion { get { throw null; } }
        public bool IsSealed { get { throw null; } }
        public bool IsServerEncrypted { get { throw null; } }
        public System.DateTimeOffset LastAccessed { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public Azure.Storage.Blobs.Models.LeaseDurationType LeaseDuration { get { throw null; } }
        public Azure.Storage.Blobs.Models.LeaseState LeaseState { get { throw null; } }
        public Azure.Storage.Blobs.Models.LeaseStatus LeaseStatus { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string ObjectReplicationDestinationPolicyId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Storage.Blobs.Models.ObjectReplicationPolicy> ObjectReplicationSourceProperties { get { throw null; } }
        public string RehydratePriority { get { throw null; } }
        public long TagCount { get { throw null; } }
        public string VersionId { get { throw null; } }
    }
    public partial class BlobQueryArrowField
    {
        public BlobQueryArrowField() { }
        public string Name { get { throw null; } set { } }
        public int Precision { get { throw null; } set { } }
        public int Scale { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobQueryArrowFieldType Type { get { throw null; } set { } }
    }
    public enum BlobQueryArrowFieldType
    {
        Int64 = 0,
        Bool = 1,
        Timestamp = 2,
        String = 3,
        Double = 4,
        Decimal = 5,
    }
    public partial class BlobQueryArrowOptions : Azure.Storage.Blobs.Models.BlobQueryTextOptions
    {
        public BlobQueryArrowOptions() { }
        public System.Collections.Generic.IList<Azure.Storage.Blobs.Models.BlobQueryArrowField> Schema { get { throw null; } set { } }
    }
    public partial class BlobQueryCsvTextOptions : Azure.Storage.Blobs.Models.BlobQueryTextOptions
    {
        public BlobQueryCsvTextOptions() { }
        public string ColumnSeparator { get { throw null; } set { } }
        public char? EscapeCharacter { get { throw null; } set { } }
        public bool HasHeaders { get { throw null; } set { } }
        public char? QuotationCharacter { get { throw null; } set { } }
        public string RecordSeparator { get { throw null; } set { } }
    }
    public partial class BlobQueryError
    {
        internal BlobQueryError() { }
        public string Description { get { throw null; } }
        public bool IsFatal { get { throw null; } }
        public string Name { get { throw null; } }
        public long Position { get { throw null; } }
    }
    public partial class BlobQueryJsonTextOptions : Azure.Storage.Blobs.Models.BlobQueryTextOptions
    {
        public BlobQueryJsonTextOptions() { }
        public string RecordSeparator { get { throw null; } set { } }
    }
    public partial class BlobQueryOptions
    {
        public BlobQueryOptions() { }
        public Azure.Storage.Blobs.Models.BlobRequestConditions Conditions { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobQueryTextOptions InputTextConfiguration { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobQueryTextOptions OutputTextConfiguration { get { throw null; } set { } }
        public System.IProgress<long> ProgressHandler { get { throw null; } set { } }
        public event System.Action<Azure.Storage.Blobs.Models.BlobQueryError> ErrorHandler { add { } remove { } }
    }
    public partial class BlobQueryParquetTextOptions : Azure.Storage.Blobs.Models.BlobQueryTextOptions
    {
        public BlobQueryParquetTextOptions() { }
    }
    public abstract partial class BlobQueryTextOptions
    {
        protected BlobQueryTextOptions() { }
    }
    public partial class BlobRequestConditions : Azure.Storage.Blobs.Models.BlobLeaseRequestConditions
    {
        public BlobRequestConditions() { }
        public string LeaseId { get { throw null; } set { } }
        public override string ToString() { throw null; }
    }
    public partial class BlobRetentionPolicy
    {
        public BlobRetentionPolicy() { }
        public int? Days { get { throw null; } set { } }
        public bool Enabled { get { throw null; } set { } }
    }
    public partial class BlobServiceProperties
    {
        public BlobServiceProperties() { }
        public System.Collections.Generic.IList<Azure.Storage.Blobs.Models.BlobCorsRule> Cors { get { throw null; } set { } }
        public string DefaultServiceVersion { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobRetentionPolicy DeleteRetentionPolicy { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobMetrics HourMetrics { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobAnalyticsLogging Logging { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobMetrics MinuteMetrics { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobStaticWebsite StaticWebsite { get { throw null; } set { } }
    }
    public partial class BlobServiceStatistics
    {
        internal BlobServiceStatistics() { }
        public Azure.Storage.Blobs.Models.BlobGeoReplication GeoReplication { get { throw null; } }
    }
    public partial class BlobSignedIdentifier
    {
        public BlobSignedIdentifier() { }
        public Azure.Storage.Blobs.Models.BlobAccessPolicy AccessPolicy { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
    }
    public static partial class BlobsModelFactory
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.AccountInfo AccountInfo(Azure.Storage.Blobs.Models.SkuName skuName, Azure.Storage.Blobs.Models.AccountKind accountKind) { throw null; }
        public static Azure.Storage.Blobs.Models.AccountInfo AccountInfo(Azure.Storage.Blobs.Models.SkuName skuName, Azure.Storage.Blobs.Models.AccountKind accountKind, bool isHierarchicalNamespaceEnabled) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlobAppendInfo BlobAppendInfo(Azure.ETag eTag, System.DateTimeOffset lastModified, byte[] contentHash, byte[] contentCrc64, string blobAppendOffset, int blobCommittedBlockCount, bool isServerEncrypted, string encryptionKeySha256) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobAppendInfo BlobAppendInfo(Azure.ETag eTag, System.DateTimeOffset lastModified, byte[] contentHash, byte[] contentCrc64, string blobAppendOffset, int blobCommittedBlockCount, bool isServerEncrypted, string encryptionKeySha256, string encryptionScope) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlobBlock BlobBlock(string name, int size) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobBlock BlobBlock(string name, long size) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobContainerAccessPolicy BlobContainerAccessPolicy(Azure.Storage.Blobs.Models.PublicAccessType blobPublicAccess, Azure.ETag eTag, System.DateTimeOffset lastModified, System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.BlobSignedIdentifier> signedIdentifiers) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobContainerInfo BlobContainerInfo(Azure.ETag eTag, System.DateTimeOffset lastModified) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlobContainerItem BlobContainerItem(string name, Azure.Storage.Blobs.Models.BlobContainerProperties properties) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobContainerItem BlobContainerItem(string name, Azure.Storage.Blobs.Models.BlobContainerProperties properties, bool? isDeleted = default(bool?), string versionId = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlobContainerProperties BlobContainerProperties(System.DateTimeOffset lastModified, Azure.ETag eTag, Azure.Storage.Blobs.Models.LeaseState? leaseState, Azure.Storage.Blobs.Models.LeaseDurationType? leaseDuration, Azure.Storage.Blobs.Models.PublicAccessType? publicAccess, Azure.Storage.Blobs.Models.LeaseStatus? leaseStatus, bool? hasLegalHold, string defaultEncryptionScope, bool? preventEncryptionScopeOverride, System.Collections.Generic.IDictionary<string, string> metadata, bool? hasImmutabilityPolicy) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlobContainerProperties BlobContainerProperties(System.DateTimeOffset lastModified, Azure.ETag eTag, Azure.Storage.Blobs.Models.LeaseState? leaseState, Azure.Storage.Blobs.Models.LeaseDurationType? leaseDuration, Azure.Storage.Blobs.Models.PublicAccessType? publicAccess, bool? hasImmutabilityPolicy, Azure.Storage.Blobs.Models.LeaseStatus? leaseStatus, string defaultEncryptionScope, bool? preventEncryptionScopeOverride, System.Collections.Generic.IDictionary<string, string> metadata, bool? hasLegalHold) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobContainerProperties BlobContainerProperties(System.DateTimeOffset lastModified, Azure.ETag eTag, Azure.Storage.Blobs.Models.LeaseState? leaseState = default(Azure.Storage.Blobs.Models.LeaseState?), Azure.Storage.Blobs.Models.LeaseDurationType? leaseDuration = default(Azure.Storage.Blobs.Models.LeaseDurationType?), Azure.Storage.Blobs.Models.PublicAccessType? publicAccess = default(Azure.Storage.Blobs.Models.PublicAccessType?), bool? hasImmutabilityPolicy = default(bool?), Azure.Storage.Blobs.Models.LeaseStatus? leaseStatus = default(Azure.Storage.Blobs.Models.LeaseStatus?), string defaultEncryptionScope = null, bool? preventEncryptionScopeOverride = default(bool?), System.DateTimeOffset? deletedOn = default(System.DateTimeOffset?), int? remainingRetentionDays = default(int?), System.Collections.Generic.IDictionary<string, string> metadata = null, bool? hasLegalHold = default(bool?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlobContainerProperties BlobContainerProperties(System.DateTimeOffset lastModified, Azure.ETag eTag, Azure.Storage.Blobs.Models.LeaseStatus? leaseStatus, Azure.Storage.Blobs.Models.LeaseState? leaseState, Azure.Storage.Blobs.Models.LeaseDurationType? leaseDuration, Azure.Storage.Blobs.Models.PublicAccessType? publicAccess, bool? hasImmutabilityPolicy, bool? hasLegalHold, System.Collections.Generic.IDictionary<string, string> metadata) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlobContentInfo BlobContentInfo(Azure.ETag eTag, System.DateTimeOffset lastModified, byte[] contentHash, string encryptionKeySha256, long blobSequenceNumber) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlobContentInfo BlobContentInfo(Azure.ETag eTag, System.DateTimeOffset lastModified, byte[] contentHash, string encryptionKeySha256, string encryptionScope, long blobSequenceNumber) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobContentInfo BlobContentInfo(Azure.ETag eTag, System.DateTimeOffset lastModified, byte[] contentHash, string versionId, string encryptionKeySha256, string encryptionScope, long blobSequenceNumber) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlobCopyInfo BlobCopyInfo(Azure.ETag eTag, System.DateTimeOffset lastModified, string copyId, Azure.Storage.Blobs.Models.CopyStatus copyStatus) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobCopyInfo BlobCopyInfo(Azure.ETag eTag, System.DateTimeOffset lastModified, string versionId, string copyId, Azure.Storage.Blobs.Models.CopyStatus copyStatus) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlobDownloadDetails BlobDownloadDetails(Azure.Storage.Blobs.Models.BlobType blobType, long contentLength, string contentType, byte[] contentHash, System.DateTimeOffset lastModified, System.Collections.Generic.IDictionary<string, string> metadata, string contentRange, string contentEncoding, string cacheControl, string contentDisposition, string contentLanguage, long blobSequenceNumber, System.DateTimeOffset copyCompletedOn, string copyStatusDescription, string copyId, string copyProgress, System.Uri copySource, Azure.Storage.Blobs.Models.CopyStatus copyStatus, Azure.Storage.Blobs.Models.LeaseDurationType leaseDuration, Azure.Storage.Blobs.Models.LeaseState leaseState, Azure.Storage.Blobs.Models.LeaseStatus leaseStatus, string acceptRanges, int blobCommittedBlockCount, bool isServerEncrypted, string encryptionKeySha256, string encryptionScope, byte[] blobContentHash, long tagCount, string versionId, bool isSealed, System.Collections.Generic.IList<Azure.Storage.Blobs.Models.ObjectReplicationPolicy> objectReplicationSourceProperties, string objectReplicationDestinationPolicy) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlobDownloadDetails BlobDownloadDetails(Azure.Storage.Blobs.Models.BlobType blobType, long contentLength, string contentType, byte[] contentHash, System.DateTimeOffset lastModified, System.Collections.Generic.IDictionary<string, string> metadata, string contentRange, string contentEncoding, string cacheControl, string contentDisposition, string contentLanguage, long blobSequenceNumber, System.DateTimeOffset copyCompletedOn, string copyStatusDescription, string copyId, string copyProgress, System.Uri copySource, Azure.Storage.Blobs.Models.CopyStatus copyStatus, Azure.Storage.Blobs.Models.LeaseDurationType leaseDuration, Azure.Storage.Blobs.Models.LeaseState leaseState, Azure.Storage.Blobs.Models.LeaseStatus leaseStatus, string acceptRanges, int blobCommittedBlockCount, bool isServerEncrypted, string encryptionKeySha256, string encryptionScope, byte[] blobContentHash, long tagCount, string versionId, bool isSealed, System.Collections.Generic.IList<Azure.Storage.Blobs.Models.ObjectReplicationPolicy> objectReplicationSourceProperties, string objectReplicationDestinationPolicy, bool hasLegalHold, System.DateTimeOffset createdOn) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobDownloadDetails BlobDownloadDetails(Azure.Storage.Blobs.Models.BlobType blobType = Azure.Storage.Blobs.Models.BlobType.Block, long contentLength = (long)0, string contentType = null, byte[] contentHash = null, System.DateTimeOffset lastModified = default(System.DateTimeOffset), System.Collections.Generic.IDictionary<string, string> metadata = null, string contentRange = null, string contentEncoding = null, string cacheControl = null, string contentDisposition = null, string contentLanguage = null, long blobSequenceNumber = (long)0, System.DateTimeOffset copyCompletedOn = default(System.DateTimeOffset), string copyStatusDescription = null, string copyId = null, string copyProgress = null, System.Uri copySource = null, Azure.Storage.Blobs.Models.CopyStatus copyStatus = Azure.Storage.Blobs.Models.CopyStatus.Pending, Azure.Storage.Blobs.Models.LeaseDurationType leaseDuration = Azure.Storage.Blobs.Models.LeaseDurationType.Infinite, Azure.Storage.Blobs.Models.LeaseState leaseState = Azure.Storage.Blobs.Models.LeaseState.Available, Azure.Storage.Blobs.Models.LeaseStatus leaseStatus = Azure.Storage.Blobs.Models.LeaseStatus.Locked, string acceptRanges = null, int blobCommittedBlockCount = 0, bool isServerEncrypted = false, string encryptionKeySha256 = null, string encryptionScope = null, byte[] blobContentHash = null, long tagCount = (long)0, string versionId = null, bool isSealed = false, System.Collections.Generic.IList<Azure.Storage.Blobs.Models.ObjectReplicationPolicy> objectReplicationSourceProperties = null, string objectReplicationDestinationPolicy = null, bool hasLegalHold = false, System.DateTimeOffset createdOn = default(System.DateTimeOffset), Azure.ETag eTag = default(Azure.ETag)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlobDownloadDetails BlobDownloadDetails(System.DateTimeOffset lastModified, System.Collections.Generic.IDictionary<string, string> metadata, string contentRange, string contentEncoding, string cacheControl, string contentDisposition, string contentLanguage, long blobSequenceNumber, System.DateTimeOffset copyCompletedOn, string copyStatusDescription, string copyId, string copyProgress, System.Uri copySource, Azure.Storage.Blobs.Models.CopyStatus copyStatus, Azure.Storage.Blobs.Models.LeaseDurationType leaseDuration, Azure.Storage.Blobs.Models.LeaseState leaseState, Azure.Storage.Blobs.Models.LeaseStatus leaseStatus, string acceptRanges, int blobCommittedBlockCount, bool isServerEncrypted, string encryptionKeySha256, string encryptionScope, byte[] blobContentHash, long tagCount, string versionId, bool isSealed, System.Collections.Generic.IList<Azure.Storage.Blobs.Models.ObjectReplicationPolicy> objectReplicationSourceProperties, string objectReplicationDestinationPolicy) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlobDownloadInfo BlobDownloadInfo(System.DateTimeOffset lastModified, long blobSequenceNumber, Azure.Storage.Blobs.Models.BlobType blobType, byte[] contentCrc64, string contentLanguage, string copyStatusDescription, string copyId, string copyProgress, System.Uri copySource, Azure.Storage.Blobs.Models.CopyStatus copyStatus, string contentDisposition, Azure.Storage.Blobs.Models.LeaseDurationType leaseDuration, string cacheControl, Azure.Storage.Blobs.Models.LeaseState leaseState, string contentEncoding, Azure.Storage.Blobs.Models.LeaseStatus leaseStatus, byte[] contentHash, string acceptRanges, Azure.ETag eTag, int blobCommittedBlockCount, string contentRange, bool isServerEncrypted, string contentType, string encryptionKeySha256, long contentLength, byte[] blobContentHash, System.Collections.Generic.IDictionary<string, string> metadata, System.IO.Stream content, System.DateTimeOffset copyCompletionTime) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlobDownloadInfo BlobDownloadInfo(System.DateTimeOffset lastModified, long blobSequenceNumber, Azure.Storage.Blobs.Models.BlobType blobType, byte[] contentCrc64, string contentLanguage, string copyStatusDescription, string copyId, string copyProgress, System.Uri copySource, Azure.Storage.Blobs.Models.CopyStatus copyStatus, string contentDisposition, Azure.Storage.Blobs.Models.LeaseDurationType leaseDuration, string cacheControl, Azure.Storage.Blobs.Models.LeaseState leaseState, string contentEncoding, Azure.Storage.Blobs.Models.LeaseStatus leaseStatus, byte[] contentHash, string acceptRanges, Azure.ETag eTag, int blobCommittedBlockCount, string contentRange, bool isServerEncrypted, string contentType, string encryptionKeySha256, string encryptionScope, long contentLength, byte[] blobContentHash, System.Collections.Generic.IDictionary<string, string> metadata, System.IO.Stream content, System.DateTimeOffset copyCompletionTime) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlobDownloadInfo BlobDownloadInfo(System.DateTimeOffset lastModified, long blobSequenceNumber, Azure.Storage.Blobs.Models.BlobType blobType, byte[] contentCrc64, string contentLanguage, string copyStatusDescription, string copyId, string copyProgress, System.Uri copySource, Azure.Storage.Blobs.Models.CopyStatus copyStatus, string contentDisposition, Azure.Storage.Blobs.Models.LeaseDurationType leaseDuration, string cacheControl, Azure.Storage.Blobs.Models.LeaseState leaseState, string contentEncoding, Azure.Storage.Blobs.Models.LeaseStatus leaseStatus, byte[] contentHash, string acceptRanges, Azure.ETag eTag, int blobCommittedBlockCount, string contentRange, bool isServerEncrypted, string contentType, string encryptionKeySha256, string encryptionScope, long contentLength, byte[] blobContentHash, string versionId, System.Collections.Generic.IDictionary<string, string> metadata, System.IO.Stream content, System.DateTimeOffset copyCompletionTime, long tagCount) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobDownloadInfo BlobDownloadInfo(System.DateTimeOffset lastModified = default(System.DateTimeOffset), long blobSequenceNumber = (long)0, Azure.Storage.Blobs.Models.BlobType blobType = Azure.Storage.Blobs.Models.BlobType.Block, byte[] contentCrc64 = null, string contentLanguage = null, string copyStatusDescription = null, string copyId = null, string copyProgress = null, System.Uri copySource = null, Azure.Storage.Blobs.Models.CopyStatus copyStatus = Azure.Storage.Blobs.Models.CopyStatus.Pending, string contentDisposition = null, Azure.Storage.Blobs.Models.LeaseDurationType leaseDuration = Azure.Storage.Blobs.Models.LeaseDurationType.Infinite, string cacheControl = null, Azure.Storage.Blobs.Models.LeaseState leaseState = Azure.Storage.Blobs.Models.LeaseState.Available, string contentEncoding = null, Azure.Storage.Blobs.Models.LeaseStatus leaseStatus = Azure.Storage.Blobs.Models.LeaseStatus.Locked, byte[] contentHash = null, string acceptRanges = null, Azure.ETag eTag = default(Azure.ETag), int blobCommittedBlockCount = 0, string contentRange = null, bool isServerEncrypted = false, string contentType = null, string encryptionKeySha256 = null, string encryptionScope = null, long contentLength = (long)0, byte[] blobContentHash = null, string versionId = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.IO.Stream content = null, System.DateTimeOffset copyCompletionTime = default(System.DateTimeOffset), long tagCount = (long)0, System.DateTimeOffset lastAccessed = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobDownloadResult BlobDownloadResult(System.BinaryData content = null, Azure.Storage.Blobs.Models.BlobDownloadDetails details = null) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobDownloadStreamingResult BlobDownloadStreamingResult(System.IO.Stream content = null, Azure.Storage.Blobs.Models.BlobDownloadDetails details = null) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobGeoReplication BlobGeoReplication(Azure.Storage.Blobs.Models.BlobGeoReplicationStatus status, System.DateTimeOffset? lastSyncedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobHierarchyItem BlobHierarchyItem(string prefix, Azure.Storage.Blobs.Models.BlobItem blob) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobInfo BlobInfo(Azure.ETag eTag, System.DateTimeOffset lastModified) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobInfo blobInfo(Azure.ETag eTag = default(Azure.ETag), System.DateTimeOffset lastModifed = default(System.DateTimeOffset), long blobSequenceNumber = (long)0, string versionId = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlobItem BlobItem(string name, bool deleted, Azure.Storage.Blobs.Models.BlobItemProperties properties, string snapshot, System.Collections.Generic.IDictionary<string, string> metadata) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlobItem BlobItem(string name, bool deleted, Azure.Storage.Blobs.Models.BlobItemProperties properties, string snapshot, string versionId, bool? isLatestVersion, System.Collections.Generic.IDictionary<string, string> metadata, System.Collections.Generic.IDictionary<string, string> tags, System.Collections.Generic.List<Azure.Storage.Blobs.Models.ObjectReplicationPolicy> objectReplicationSourcePolicies) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobItem BlobItem(string name = null, bool deleted = false, Azure.Storage.Blobs.Models.BlobItemProperties properties = null, string snapshot = null, string versionId = null, bool? isLatestVersion = default(bool?), System.Collections.Generic.IDictionary<string, string> metadata = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.List<Azure.Storage.Blobs.Models.ObjectReplicationPolicy> objectReplicationSourcePolicies = null, bool? hasVersionsOnly = default(bool?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlobItemProperties BlobItemProperties(bool accessTierInferred, bool? serverEncrypted, string contentType, string contentEncoding, string contentLanguage, byte[] contentHash, string contentDisposition, string cacheControl, long? blobSequenceNumber, Azure.Storage.Blobs.Models.BlobType? blobType, Azure.Storage.Blobs.Models.LeaseStatus? leaseStatus, Azure.Storage.Blobs.Models.LeaseState? leaseState, Azure.Storage.Blobs.Models.LeaseDurationType? leaseDuration, string copyId, Azure.Storage.Blobs.Models.CopyStatus? copyStatus, System.Uri copySource, string copyProgress, string copyStatusDescription, long? contentLength, bool? incrementalCopy, string destinationSnapshot, int? remainingRetentionDays, Azure.Storage.Blobs.Models.AccessTier? accessTier, System.DateTimeOffset? lastModified, Azure.Storage.Blobs.Models.ArchiveStatus? archiveStatus, string customerProvidedKeySha256, string encryptionScope, long? tagCount, System.DateTimeOffset? expiresOn, bool? isSealed, Azure.Storage.Blobs.Models.RehydratePriority? rehydratePriority, Azure.ETag? eTag, System.DateTimeOffset? createdOn, System.DateTimeOffset? copyCompletedOn, System.DateTimeOffset? deletedOn, System.DateTimeOffset? accessTierChangedOn) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobItemProperties BlobItemProperties(bool accessTierInferred, bool? serverEncrypted = default(bool?), string contentType = null, string contentEncoding = null, string contentLanguage = null, byte[] contentHash = null, string contentDisposition = null, string cacheControl = null, long? blobSequenceNumber = default(long?), Azure.Storage.Blobs.Models.BlobType? blobType = default(Azure.Storage.Blobs.Models.BlobType?), Azure.Storage.Blobs.Models.LeaseStatus? leaseStatus = default(Azure.Storage.Blobs.Models.LeaseStatus?), Azure.Storage.Blobs.Models.LeaseState? leaseState = default(Azure.Storage.Blobs.Models.LeaseState?), Azure.Storage.Blobs.Models.LeaseDurationType? leaseDuration = default(Azure.Storage.Blobs.Models.LeaseDurationType?), string copyId = null, Azure.Storage.Blobs.Models.CopyStatus? copyStatus = default(Azure.Storage.Blobs.Models.CopyStatus?), System.Uri copySource = null, string copyProgress = null, string copyStatusDescription = null, long? contentLength = default(long?), bool? incrementalCopy = default(bool?), string destinationSnapshot = null, int? remainingRetentionDays = default(int?), Azure.Storage.Blobs.Models.AccessTier? accessTier = default(Azure.Storage.Blobs.Models.AccessTier?), System.DateTimeOffset? lastModified = default(System.DateTimeOffset?), Azure.Storage.Blobs.Models.ArchiveStatus? archiveStatus = default(Azure.Storage.Blobs.Models.ArchiveStatus?), string customerProvidedKeySha256 = null, string encryptionScope = null, long? tagCount = default(long?), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), bool? isSealed = default(bool?), Azure.Storage.Blobs.Models.RehydratePriority? rehydratePriority = default(Azure.Storage.Blobs.Models.RehydratePriority?), System.DateTimeOffset? lastAccessedOn = default(System.DateTimeOffset?), Azure.ETag? eTag = default(Azure.ETag?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? copyCompletedOn = default(System.DateTimeOffset?), System.DateTimeOffset? deletedOn = default(System.DateTimeOffset?), System.DateTimeOffset? accessTierChangedOn = default(System.DateTimeOffset?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlobItemProperties BlobItemProperties(bool accessTierInferred, string copyProgress, string contentType, string contentEncoding, string contentLanguage, byte[] contentHash, string contentDisposition, string cacheControl, long? blobSequenceNumber, Azure.Storage.Blobs.Models.BlobType? blobType, Azure.Storage.Blobs.Models.LeaseStatus? leaseStatus, Azure.Storage.Blobs.Models.LeaseState? leaseState, Azure.Storage.Blobs.Models.LeaseDurationType? leaseDuration, string copyId, Azure.Storage.Blobs.Models.CopyStatus? copyStatus, System.Uri copySource, long? contentLength, string copyStatusDescription, bool? serverEncrypted, bool? incrementalCopy, string destinationSnapshot, int? remainingRetentionDays, Azure.Storage.Blobs.Models.AccessTier? accessTier, System.DateTimeOffset? lastModified, Azure.Storage.Blobs.Models.ArchiveStatus? archiveStatus, string customerProvidedKeySha256, string encryptionScope, Azure.ETag? eTag, System.DateTimeOffset? createdOn, System.DateTimeOffset? copyCompletedOn, System.DateTimeOffset? deletedOn, System.DateTimeOffset? accessTierChangedOn) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlobItemProperties BlobItemProperties(bool accessTierInferred, System.Uri copySource, string contentType, string contentEncoding, string contentLanguage, byte[] contentHash, string contentDisposition, string cacheControl, long? blobSequenceNumber, Azure.Storage.Blobs.Models.BlobType? blobType, Azure.Storage.Blobs.Models.LeaseStatus? leaseStatus, Azure.Storage.Blobs.Models.LeaseState? leaseState, Azure.Storage.Blobs.Models.LeaseDurationType? leaseDuration, string copyId, Azure.Storage.Blobs.Models.CopyStatus? copyStatus, long? contentLength, string copyProgress, string copyStatusDescription, bool? serverEncrypted, bool? incrementalCopy, string destinationSnapshot, int? remainingRetentionDays, Azure.Storage.Blobs.Models.AccessTier? accessTier, System.DateTimeOffset? lastModified, Azure.Storage.Blobs.Models.ArchiveStatus? archiveStatus, string customerProvidedKeySha256, Azure.ETag? eTag, System.DateTimeOffset? createdOn, System.DateTimeOffset? copyCompletedOn, System.DateTimeOffset? deletedOn, System.DateTimeOffset? accessTierChangedOn) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobLease BlobLease(Azure.ETag eTag, System.DateTimeOffset lastModified, string leaseId) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlobProperties BlobProperties(System.DateTimeOffset lastModified, Azure.Storage.Blobs.Models.LeaseDurationType leaseDuration, Azure.Storage.Blobs.Models.LeaseState leaseState, Azure.Storage.Blobs.Models.LeaseStatus leaseStatus, long contentLength, string destinationSnapshot, Azure.ETag eTag, byte[] contentHash, string contentEncoding, string contentDisposition, string contentLanguage, bool isIncrementalCopy, string cacheControl, Azure.Storage.Blobs.Models.CopyStatus copyStatus, long blobSequenceNumber, System.Uri copySource, string acceptRanges, string copyProgress, int blobCommittedBlockCount, string copyId, bool isServerEncrypted, string copyStatusDescription, string encryptionKeySha256, System.DateTimeOffset copyCompletedOn, string accessTier, Azure.Storage.Blobs.Models.BlobType blobType, bool accessTierInferred, System.Collections.Generic.IDictionary<string, string> metadata, string archiveStatus, System.DateTimeOffset createdOn, System.DateTimeOffset accessTierChangedOn, string contentType) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlobProperties BlobProperties(System.DateTimeOffset lastModified, Azure.Storage.Blobs.Models.LeaseState leaseState, Azure.Storage.Blobs.Models.LeaseStatus leaseStatus, long contentLength, Azure.Storage.Blobs.Models.LeaseDurationType leaseDuration, Azure.ETag eTag, byte[] contentHash, string contentEncoding, string contentDisposition, string contentLanguage, string destinationSnapshot, string cacheControl, bool isIncrementalCopy, long blobSequenceNumber, Azure.Storage.Blobs.Models.CopyStatus copyStatus, string acceptRanges, System.Uri copySource, int blobCommittedBlockCount, string copyProgress, bool isServerEncrypted, string copyId, string encryptionKeySha256, string copyStatusDescription, string encryptionScope, System.DateTimeOffset copyCompletedOn, string accessTier, Azure.Storage.Blobs.Models.BlobType blobType, bool accessTierInferred, System.Collections.Generic.IDictionary<string, string> metadata, string archiveStatus, System.DateTimeOffset createdOn, System.DateTimeOffset accessTierChangedOn, string contentType) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlobProperties BlobProperties(System.DateTimeOffset lastModified, Azure.Storage.Blobs.Models.LeaseStatus leaseStatus, long contentLength, string contentType, Azure.ETag eTag, Azure.Storage.Blobs.Models.LeaseState leaseState, string contentEncoding, string contentDisposition, string contentLanguage, string cacheControl, long blobSequenceNumber, Azure.Storage.Blobs.Models.LeaseDurationType leaseDuration, string acceptRanges, string destinationSnapshot, int blobCommittedBlockCount, bool isIncrementalCopy, bool isServerEncrypted, Azure.Storage.Blobs.Models.CopyStatus copyStatus, string encryptionKeySha256, System.Uri copySource, string encryptionScope, string copyProgress, string accessTier, string copyId, bool accessTierInferred, string copyStatusDescription, string archiveStatus, System.DateTimeOffset copyCompletedOn, System.DateTimeOffset accessTierChangedOn, Azure.Storage.Blobs.Models.BlobType blobType, string versionId, System.Collections.Generic.IList<Azure.Storage.Blobs.Models.ObjectReplicationPolicy> objectReplicationSourceProperties, bool isLatestVersion, string objectReplicationDestinationPolicyId, long tagCount, System.Collections.Generic.IDictionary<string, string> metadata, System.DateTimeOffset expiresOn, System.DateTimeOffset createdOn, bool isSealed, string rehydratePriority, byte[] contentHash) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlobProperties BlobProperties(System.DateTimeOffset lastModified, Azure.Storage.Blobs.Models.LeaseStatus leaseStatus, long contentLength, string contentType, Azure.ETag eTag, Azure.Storage.Blobs.Models.LeaseState leaseState, string contentEncoding, string contentDisposition, string contentLanguage, string cacheControl, long blobSequenceNumber, Azure.Storage.Blobs.Models.LeaseDurationType leaseDuration, string acceptRanges, string destinationSnapshot, int blobCommittedBlockCount, bool isIncrementalCopy, bool isServerEncrypted, Azure.Storage.Blobs.Models.CopyStatus copyStatus, string encryptionKeySha256, System.Uri copySource, string encryptionScope, string copyProgress, string accessTier, string copyId, bool accessTierInferred, string copyStatusDescription, string archiveStatus, System.DateTimeOffset copyCompletedOn, System.DateTimeOffset accessTierChangedOn, Azure.Storage.Blobs.Models.BlobType blobType, string versionId, System.Collections.Generic.IList<Azure.Storage.Blobs.Models.ObjectReplicationPolicy> objectReplicationSourceProperties, bool isLatestVersion, string objectReplicationDestinationPolicyId, long tagCount, System.Collections.Generic.IDictionary<string, string> metadata, System.DateTimeOffset expiresOn, System.DateTimeOffset createdOn, bool isSealed, string rehydratePriority, byte[] contentHash, System.DateTimeOffset lastAccessed) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlobProperties BlobProperties(System.DateTimeOffset lastModified, Azure.Storage.Blobs.Models.LeaseStatus leaseStatus, long contentLength, string contentType, Azure.ETag eTag, Azure.Storage.Blobs.Models.LeaseState leaseState, string contentEncoding, string contentDisposition, string contentLanguage, string cacheControl, long blobSequenceNumber, Azure.Storage.Blobs.Models.LeaseDurationType leaseDuration, string acceptRanges, string destinationSnapshot, int blobCommittedBlockCount, bool isIncrementalCopy, bool isServerEncrypted, Azure.Storage.Blobs.Models.CopyStatus copyStatus, string encryptionKeySha256, System.Uri copySource, string encryptionScope, string copyProgress, string accessTier, string copyId, bool accessTierInferred, string copyStatusDescription, string archiveStatus, System.DateTimeOffset copyCompletedOn, System.DateTimeOffset accessTierChangedOn, Azure.Storage.Blobs.Models.BlobType blobType, string versionId, System.Collections.Generic.IList<Azure.Storage.Blobs.Models.ObjectReplicationPolicy> objectReplicationSourceProperties, bool isLatestVersion, string objectReplicationDestinationPolicyId, long tagCount, System.Collections.Generic.IDictionary<string, string> metadata, System.DateTimeOffset expiresOn, System.DateTimeOffset createdOn, bool isSealed, string rehydratePriority, byte[] contentHash, System.DateTimeOffset lastAccessed, Azure.Storage.Blobs.Models.BlobImmutabilityPolicy immutabilityPolicy, bool hasLegalHold) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobProperties BlobProperties(System.DateTimeOffset lastModified = default(System.DateTimeOffset), Azure.Storage.Blobs.Models.LeaseStatus leaseStatus = Azure.Storage.Blobs.Models.LeaseStatus.Locked, long contentLength = (long)0, string contentType = null, Azure.ETag eTag = default(Azure.ETag), Azure.Storage.Blobs.Models.LeaseState leaseState = Azure.Storage.Blobs.Models.LeaseState.Available, string contentEncoding = null, string contentDisposition = null, string contentLanguage = null, string cacheControl = null, long blobSequenceNumber = (long)0, Azure.Storage.Blobs.Models.LeaseDurationType leaseDuration = Azure.Storage.Blobs.Models.LeaseDurationType.Infinite, string acceptRanges = null, string destinationSnapshot = null, int blobCommittedBlockCount = 0, bool isIncrementalCopy = false, bool isServerEncrypted = false, Azure.Storage.Blobs.Models.CopyStatus? blobCopyStatus = default(Azure.Storage.Blobs.Models.CopyStatus?), string encryptionKeySha256 = null, System.Uri copySource = null, string encryptionScope = null, string copyProgress = null, string accessTier = null, string copyId = null, bool accessTierInferred = false, string copyStatusDescription = null, string archiveStatus = null, System.DateTimeOffset copyCompletedOn = default(System.DateTimeOffset), System.DateTimeOffset accessTierChangedOn = default(System.DateTimeOffset), Azure.Storage.Blobs.Models.BlobType blobType = Azure.Storage.Blobs.Models.BlobType.Block, string versionId = null, System.Collections.Generic.IList<Azure.Storage.Blobs.Models.ObjectReplicationPolicy> objectReplicationSourceProperties = null, bool isLatestVersion = false, string objectReplicationDestinationPolicyId = null, long tagCount = (long)0, System.Collections.Generic.IDictionary<string, string> metadata = null, System.DateTimeOffset expiresOn = default(System.DateTimeOffset), System.DateTimeOffset createdOn = default(System.DateTimeOffset), bool isSealed = false, string rehydratePriority = null, byte[] contentHash = null, System.DateTimeOffset lastAccessed = default(System.DateTimeOffset), Azure.Storage.Blobs.Models.BlobImmutabilityPolicy immutabilityPolicy = null, bool hasLegalHold = false) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobQueryError BlobQueryError(string name = null, string description = null, bool isFatal = false, long position = (long)0) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobServiceStatistics BlobServiceStatistics(Azure.Storage.Blobs.Models.BlobGeoReplication geoReplication = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlobSnapshotInfo BlobSnapshotInfo(string snapshot, Azure.ETag eTag, System.DateTimeOffset lastModified, bool isServerEncrypted) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobSnapshotInfo BlobSnapshotInfo(string snapshot, Azure.ETag eTag, System.DateTimeOffset lastModified, string versionId, bool isServerEncrypted) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlockInfo BlockInfo(byte[] contentHash, byte[] contentCrc64, string encryptionKeySha256) { throw null; }
        public static Azure.Storage.Blobs.Models.BlockInfo BlockInfo(byte[] contentHash, byte[] contentCrc64, string encryptionKeySha256, string encryptionScope) { throw null; }
        public static Azure.Storage.Blobs.Models.BlockList BlockList(System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.BlobBlock> committedBlocks = null, System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.BlobBlock> uncommittedBlocks = null) { throw null; }
        public static Azure.Storage.Blobs.Models.GetBlobTagResult GetBlobTagResult(System.Collections.Generic.IDictionary<string, string> tags) { throw null; }
        public static Azure.Storage.Blobs.Models.ObjectReplicationPolicy ObjectReplicationPolicy(string policyId, System.Collections.Generic.IList<Azure.Storage.Blobs.Models.ObjectReplicationRule> rules) { throw null; }
        public static Azure.Storage.Blobs.Models.ObjectReplicationRule ObjectReplicationRule(string ruleId, Azure.Storage.Blobs.Models.ObjectReplicationStatus replicationStatus) { throw null; }
        public static Azure.Storage.Blobs.Models.PageBlobInfo PageBlobInfo(Azure.ETag eTag, System.DateTimeOffset lastModified, long blobSequenceNumber) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.PageInfo PageInfo(Azure.ETag eTag, System.DateTimeOffset lastModified, byte[] contentHash, byte[] contentCrc64, long blobSequenceNumber, string encryptionKeySha256) { throw null; }
        public static Azure.Storage.Blobs.Models.PageInfo PageInfo(Azure.ETag eTag, System.DateTimeOffset lastModified, byte[] contentHash, byte[] contentCrc64, long blobSequenceNumber, string encryptionKeySha256, string encryptionScope) { throw null; }
        public static Azure.Storage.Blobs.Models.PageRangesInfo PageRangesInfo(System.DateTimeOffset lastModified, Azure.ETag eTag, long blobContentLength, System.Collections.Generic.IEnumerable<Azure.HttpRange> pageRanges, System.Collections.Generic.IEnumerable<Azure.HttpRange> clearRanges) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.TaggedBlobItem TaggedBlobItem(string blobName = null, string blobContainerName = null) { throw null; }
        public static Azure.Storage.Blobs.Models.TaggedBlobItem TaggedBlobItem(string blobName = null, string blobContainerName = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.Storage.Blobs.Models.UserDelegationKey UserDelegationKey(string signedObjectId = null, string signedTenantId = null, System.DateTimeOffset signedStartsOn = default(System.DateTimeOffset), System.DateTimeOffset signedExpiresOn = default(System.DateTimeOffset), string signedService = null, string signedVersion = null, string value = null) { throw null; }
        public static Azure.Storage.Blobs.Models.UserDelegationKey UserDelegationKey(string signedObjectId, string signedTenantId, string signedService, string signedVersion, string value, System.DateTimeOffset signedExpiresOn, System.DateTimeOffset signedStartsOn) { throw null; }
    }
    public partial class BlobSnapshotInfo
    {
        internal BlobSnapshotInfo() { }
        public Azure.ETag ETag { get { throw null; } }
        public bool IsServerEncrypted { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public string Snapshot { get { throw null; } }
        public string VersionId { get { throw null; } }
    }
    [System.FlagsAttribute]
    public enum BlobStates
    {
        All = -1,
        None = 0,
        Snapshots = 1,
        Uncommitted = 2,
        Deleted = 4,
        Version = 8,
        DeletedWithVersions = 16,
    }
    public partial class BlobStaticWebsite
    {
        public BlobStaticWebsite() { }
        public string DefaultIndexDocumentPath { get { throw null; } set { } }
        public bool Enabled { get { throw null; } set { } }
        public string ErrorDocument404Path { get { throw null; } set { } }
        public string IndexDocument { get { throw null; } set { } }
    }
    public partial class BlobSyncUploadFromUriOptions
    {
        public BlobSyncUploadFromUriOptions() { }
        public Azure.Storage.Blobs.Models.AccessTier? AccessTier { get { throw null; } set { } }
        public byte[] ContentHash { get { throw null; } set { } }
        public bool? CopySourceBlobProperties { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobCopySourceTagsMode? CopySourceTagsMode { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobRequestConditions DestinationConditions { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobHttpHeaders HttpHeaders { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public Azure.HttpAuthorization SourceAuthentication { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobRequestConditions SourceConditions { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.FileShareTokenIntent? SourceShareTokenIntent { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    [System.FlagsAttribute]
    public enum BlobTraits
    {
        All = -1,
        None = 0,
        CopyStatus = 1,
        Metadata = 2,
        Tags = 4,
        ImmutabilityPolicy = 8,
        LegalHold = 16,
    }
    public enum BlobType
    {
        Block = 0,
        Page = 1,
        Append = 2,
    }
    public partial class BlobUploadOptions
    {
        public BlobUploadOptions() { }
        public Azure.Storage.Blobs.Models.AccessTier? AccessTier { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobRequestConditions Conditions { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobHttpHeaders HttpHeaders { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobImmutabilityPolicy ImmutabilityPolicy { get { throw null; } set { } }
        public bool? LegalHold { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public System.IProgress<long> ProgressHandler { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
        public Azure.Storage.StorageTransferOptions TransferOptions { get { throw null; } set { } }
        public Azure.Storage.UploadTransferValidationOptions TransferValidation { get { throw null; } set { } }
    }
    public partial class BlockBlobOpenWriteOptions
    {
        public BlockBlobOpenWriteOptions() { }
        public long? BufferSize { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobHttpHeaders HttpHeaders { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobRequestConditions OpenConditions { get { throw null; } set { } }
        public System.IProgress<long> ProgressHandler { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
        public Azure.Storage.UploadTransferValidationOptions TransferValidation { get { throw null; } set { } }
    }
    public partial class BlockBlobStageBlockOptions
    {
        public BlockBlobStageBlockOptions() { }
        public Azure.Storage.Blobs.Models.BlobRequestConditions Conditions { get { throw null; } set { } }
        public System.IProgress<long> ProgressHandler { get { throw null; } set { } }
        public Azure.Storage.UploadTransferValidationOptions TransferValidation { get { throw null; } set { } }
    }
    public partial class BlockInfo
    {
        internal BlockInfo() { }
        public byte[] ContentCrc64 { get { throw null; } }
        public byte[] ContentHash { get { throw null; } }
        public string EncryptionKeySha256 { get { throw null; } }
        public string EncryptionScope { get { throw null; } }
    }
    public partial class BlockList
    {
        internal BlockList() { }
        public long BlobContentLength { get { throw null; } }
        public System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.BlobBlock> CommittedBlocks { get { throw null; } }
        public string ContentType { get { throw null; } }
        public Azure.ETag ETag { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.BlobBlock> UncommittedBlocks { get { throw null; } }
    }
    [System.FlagsAttribute]
    public enum BlockListTypes
    {
        Committed = 1,
        Uncommitted = 2,
        All = 3,
    }
    public partial class CommitBlockListOptions
    {
        public CommitBlockListOptions() { }
        public Azure.Storage.Blobs.Models.AccessTier? AccessTier { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobRequestConditions Conditions { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobHttpHeaders HttpHeaders { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobImmutabilityPolicy ImmutabilityPolicy { get { throw null; } set { } }
        public bool? LegalHold { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    public partial class CopyFromUriOperation : Azure.Operation<long>
    {
        protected CopyFromUriOperation() { }
        public CopyFromUriOperation(string id, Azure.Storage.Blobs.Specialized.BlobBaseClient client) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override long Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<long>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<long>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public enum CopyStatus
    {
        Pending = 0,
        Success = 1,
        Aborted = 2,
        Failed = 3,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CustomerProvidedKey : System.IEquatable<Azure.Storage.Blobs.Models.CustomerProvidedKey>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CustomerProvidedKey(byte[] key) { throw null; }
        public CustomerProvidedKey(string key) { throw null; }
        public Azure.Storage.Blobs.Models.EncryptionAlgorithmType EncryptionAlgorithm { get { throw null; } }
        public string EncryptionKey { get { throw null; } }
        public string EncryptionKeyHash { get { throw null; } }
        public bool Equals(Azure.Storage.Blobs.Models.CustomerProvidedKey other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Storage.Blobs.Models.CustomerProvidedKey left, Azure.Storage.Blobs.Models.CustomerProvidedKey right) { throw null; }
        public static bool operator !=(Azure.Storage.Blobs.Models.CustomerProvidedKey left, Azure.Storage.Blobs.Models.CustomerProvidedKey right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum DeleteSnapshotsOption
    {
        None = 0,
        IncludeSnapshots = 1,
        OnlySnapshots = 2,
    }
    public enum EncryptionAlgorithmType
    {
        Aes256 = 0,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileShareTokenIntent : System.IEquatable<Azure.Storage.Blobs.Models.FileShareTokenIntent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileShareTokenIntent(string value) { throw null; }
        public static Azure.Storage.Blobs.Models.FileShareTokenIntent Backup { get { throw null; } }
        public bool Equals(Azure.Storage.Blobs.Models.FileShareTokenIntent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Storage.Blobs.Models.FileShareTokenIntent left, Azure.Storage.Blobs.Models.FileShareTokenIntent right) { throw null; }
        public static implicit operator Azure.Storage.Blobs.Models.FileShareTokenIntent (string value) { throw null; }
        public static bool operator !=(Azure.Storage.Blobs.Models.FileShareTokenIntent left, Azure.Storage.Blobs.Models.FileShareTokenIntent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GetBlobsByHierarchyOptions
    {
        public GetBlobsByHierarchyOptions() { }
        public string Delimiter { get { throw null; } set { } }
        public string Prefix { get { throw null; } set { } }
        public string StartFrom { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobStates States { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobTraits Traits { get { throw null; } set { } }
    }
    public partial class GetBlobsOptions
    {
        public GetBlobsOptions() { }
        public string Prefix { get { throw null; } set { } }
        public string StartFrom { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobStates States { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobTraits Traits { get { throw null; } set { } }
    }
    public partial class GetBlobTagResult
    {
        public GetBlobTagResult() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class GetPageRangesDiffOptions
    {
        public GetPageRangesDiffOptions() { }
        public Azure.Storage.Blobs.Models.PageBlobRequestConditions Conditions { get { throw null; } set { } }
        public string PreviousSnapshot { get { throw null; } set { } }
        public Azure.HttpRange? Range { get { throw null; } set { } }
        public string Snapshot { get { throw null; } set { } }
    }
    public partial class GetPageRangesOptions
    {
        public GetPageRangesOptions() { }
        public Azure.Storage.Blobs.Models.PageBlobRequestConditions Conditions { get { throw null; } set { } }
        public Azure.HttpRange? Range { get { throw null; } set { } }
        public string Snapshot { get { throw null; } set { } }
    }
    public enum LeaseDurationType
    {
        Infinite = 0,
        Fixed = 1,
    }
    public enum LeaseState
    {
        Available = 0,
        Leased = 1,
        Expired = 2,
        Breaking = 3,
        Broken = 4,
    }
    public enum LeaseStatus
    {
        Locked = 0,
        Unlocked = 1,
    }
    public partial class ObjectReplicationPolicy
    {
        internal ObjectReplicationPolicy() { }
        public string PolicyId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Storage.Blobs.Models.ObjectReplicationRule> Rules { get { throw null; } }
    }
    public partial class ObjectReplicationRule
    {
        internal ObjectReplicationRule() { }
        public Azure.Storage.Blobs.Models.ObjectReplicationStatus ReplicationStatus { get { throw null; } }
        public string RuleId { get { throw null; } }
    }
    [System.FlagsAttribute]
    public enum ObjectReplicationStatus
    {
        Complete = 0,
        Failed = 1,
    }
    public partial class PageBlobCreateOptions
    {
        public PageBlobCreateOptions() { }
        public Azure.Storage.Blobs.Models.PageBlobRequestConditions Conditions { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobHttpHeaders HttpHeaders { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobImmutabilityPolicy ImmutabilityPolicy { get { throw null; } set { } }
        public bool? LegalHold { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.PremiumPageBlobAccessTier? PremiumPageBlobAccessTier { get { throw null; } set { } }
        public long? SequenceNumber { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    public partial class PageBlobInfo
    {
        internal PageBlobInfo() { }
        public long BlobSequenceNumber { get { throw null; } }
        public Azure.ETag ETag { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
    }
    public partial class PageBlobOpenWriteOptions
    {
        public PageBlobOpenWriteOptions() { }
        public long? BufferSize { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.PageBlobRequestConditions OpenConditions { get { throw null; } set { } }
        public System.IProgress<long> ProgressHandler { get { throw null; } set { } }
        public long? Size { get { throw null; } set { } }
        public Azure.Storage.UploadTransferValidationOptions TransferValidation { get { throw null; } set { } }
    }
    public partial class PageBlobRequestConditions : Azure.Storage.Blobs.Models.BlobRequestConditions
    {
        public PageBlobRequestConditions() { }
        public long? IfSequenceNumberEqual { get { throw null; } set { } }
        public long? IfSequenceNumberLessThan { get { throw null; } set { } }
        public long? IfSequenceNumberLessThanOrEqual { get { throw null; } set { } }
    }
    public partial class PageBlobUploadPagesFromUriOptions
    {
        public PageBlobUploadPagesFromUriOptions() { }
        public Azure.Storage.Blobs.Models.PageBlobRequestConditions DestinationConditions { get { throw null; } set { } }
        public Azure.HttpAuthorization SourceAuthentication { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.PageBlobRequestConditions SourceConditions { get { throw null; } set { } }
        public byte[] SourceContentHash { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.FileShareTokenIntent? SourceShareTokenIntent { get { throw null; } set { } }
    }
    public partial class PageBlobUploadPagesOptions
    {
        public PageBlobUploadPagesOptions() { }
        public Azure.Storage.Blobs.Models.PageBlobRequestConditions Conditions { get { throw null; } set { } }
        public System.IProgress<long> ProgressHandler { get { throw null; } set { } }
        public Azure.Storage.UploadTransferValidationOptions TransferValidation { get { throw null; } set { } }
    }
    public partial class PageInfo
    {
        internal PageInfo() { }
        public long BlobSequenceNumber { get { throw null; } }
        public byte[] ContentCrc64 { get { throw null; } }
        public byte[] ContentHash { get { throw null; } }
        public string EncryptionKeySha256 { get { throw null; } }
        public string EncryptionScope { get { throw null; } }
        public Azure.ETag ETag { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
    }
    public partial class PageRangeItem
    {
        public PageRangeItem() { }
        public bool IsClear { get { throw null; } }
        public Azure.HttpRange Range { get { throw null; } }
    }
    public partial class PageRangesInfo
    {
        internal PageRangesInfo() { }
        public long BlobContentLength { get { throw null; } }
        public System.Collections.Generic.IEnumerable<Azure.HttpRange> ClearRanges { get { throw null; } }
        public Azure.ETag ETag { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public System.Collections.Generic.IEnumerable<Azure.HttpRange> PageRanges { get { throw null; } }
    }
    public enum PathRenameMode
    {
        Legacy = 0,
        Posix = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PremiumPageBlobAccessTier : System.IEquatable<Azure.Storage.Blobs.Models.PremiumPageBlobAccessTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PremiumPageBlobAccessTier(string value) { throw null; }
        public static Azure.Storage.Blobs.Models.PremiumPageBlobAccessTier P10 { get { throw null; } }
        public static Azure.Storage.Blobs.Models.PremiumPageBlobAccessTier P15 { get { throw null; } }
        public static Azure.Storage.Blobs.Models.PremiumPageBlobAccessTier P20 { get { throw null; } }
        public static Azure.Storage.Blobs.Models.PremiumPageBlobAccessTier P30 { get { throw null; } }
        public static Azure.Storage.Blobs.Models.PremiumPageBlobAccessTier P4 { get { throw null; } }
        public static Azure.Storage.Blobs.Models.PremiumPageBlobAccessTier P40 { get { throw null; } }
        public static Azure.Storage.Blobs.Models.PremiumPageBlobAccessTier P50 { get { throw null; } }
        public static Azure.Storage.Blobs.Models.PremiumPageBlobAccessTier P6 { get { throw null; } }
        public static Azure.Storage.Blobs.Models.PremiumPageBlobAccessTier P60 { get { throw null; } }
        public static Azure.Storage.Blobs.Models.PremiumPageBlobAccessTier P70 { get { throw null; } }
        public static Azure.Storage.Blobs.Models.PremiumPageBlobAccessTier P80 { get { throw null; } }
        public bool Equals(Azure.Storage.Blobs.Models.PremiumPageBlobAccessTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Storage.Blobs.Models.PremiumPageBlobAccessTier left, Azure.Storage.Blobs.Models.PremiumPageBlobAccessTier right) { throw null; }
        public static implicit operator Azure.Storage.Blobs.Models.PremiumPageBlobAccessTier (string value) { throw null; }
        public static bool operator !=(Azure.Storage.Blobs.Models.PremiumPageBlobAccessTier left, Azure.Storage.Blobs.Models.PremiumPageBlobAccessTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum PublicAccessType
    {
        None = 0,
        BlobContainer = 1,
        Blob = 2,
    }
    public enum RehydratePriority
    {
        High = 0,
        Standard = 1,
    }
    public partial class ReleasedObjectInfo
    {
        public ReleasedObjectInfo(Azure.ETag eTag, System.DateTimeOffset lastModified) { }
        public Azure.ETag ETag { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public enum SequenceNumberAction
    {
        Max = 0,
        Update = 1,
        Increment = 2,
    }
    public enum SkuName
    {
        StandardLrs = 0,
        StandardGrs = 1,
        StandardRagrs = 2,
        StandardZrs = 3,
        PremiumLrs = 4,
    }
    public partial class StageBlockFromUriOptions
    {
        public StageBlockFromUriOptions() { }
        public Azure.Storage.Blobs.Models.BlobRequestConditions DestinationConditions { get { throw null; } set { } }
        public Azure.HttpAuthorization SourceAuthentication { get { throw null; } set { } }
        public Azure.RequestConditions SourceConditions { get { throw null; } set { } }
        public byte[] SourceContentHash { get { throw null; } set { } }
        public Azure.HttpRange SourceRange { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.FileShareTokenIntent? SourceShareTokenIntent { get { throw null; } set { } }
    }
    public partial class TaggedBlobItem
    {
        internal TaggedBlobItem() { }
        public string BlobContainerName { get { throw null; } }
        public string BlobName { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class UserDelegationKey
    {
        internal UserDelegationKey() { }
        public System.DateTimeOffset SignedExpiresOn { get { throw null; } }
        public string SignedObjectId { get { throw null; } }
        public string SignedService { get { throw null; } }
        public System.DateTimeOffset SignedStartsOn { get { throw null; } }
        public string SignedTenantId { get { throw null; } }
        public string SignedVersion { get { throw null; } }
        public string Value { get { throw null; } }
    }
}
namespace Azure.Storage.Blobs.Specialized
{
    public partial class AppendBlobClient : Azure.Storage.Blobs.Specialized.BlobBaseClient
    {
        protected AppendBlobClient() { }
        public AppendBlobClient(string connectionString, string blobContainerName, string blobName) { }
        public AppendBlobClient(string connectionString, string blobContainerName, string blobName, Azure.Storage.Blobs.BlobClientOptions options) { }
        public AppendBlobClient(System.Uri blobUri, Azure.AzureSasCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public AppendBlobClient(System.Uri blobUri, Azure.Core.TokenCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public AppendBlobClient(System.Uri blobUri, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public AppendBlobClient(System.Uri blobUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public virtual int AppendBlobMaxAppendBlockBytes { get { throw null; } }
        public virtual int AppendBlobMaxBlocks { get { throw null; } }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobAppendInfo> AppendBlock(System.IO.Stream content, Azure.Storage.Blobs.Models.AppendBlobAppendBlockOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobAppendInfo> AppendBlock(System.IO.Stream content, byte[] transactionalContentHash, Azure.Storage.Blobs.Models.AppendBlobRequestConditions conditions, System.IProgress<long> progressHandler, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobAppendInfo>> AppendBlockAsync(System.IO.Stream content, Azure.Storage.Blobs.Models.AppendBlobAppendBlockOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobAppendInfo>> AppendBlockAsync(System.IO.Stream content, byte[] transactionalContentHash, Azure.Storage.Blobs.Models.AppendBlobRequestConditions conditions, System.IProgress<long> progressHandler, System.Threading.CancellationToken cancellationToken) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobAppendInfo> AppendBlockFromUri(System.Uri sourceUri, Azure.HttpRange sourceRange, byte[] sourceContentHash, Azure.Storage.Blobs.Models.AppendBlobRequestConditions conditions, Azure.Storage.Blobs.Models.AppendBlobRequestConditions sourceConditions, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobAppendInfo> AppendBlockFromUri(System.Uri sourceUri, Azure.Storage.Blobs.Models.AppendBlobAppendBlockFromUriOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobAppendInfo>> AppendBlockFromUriAsync(System.Uri sourceUri, Azure.HttpRange sourceRange, byte[] sourceContentHash, Azure.Storage.Blobs.Models.AppendBlobRequestConditions conditions, Azure.Storage.Blobs.Models.AppendBlobRequestConditions sourceConditions, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobAppendInfo>> AppendBlockFromUriAsync(System.Uri sourceUri, Azure.Storage.Blobs.Models.AppendBlobAppendBlockFromUriOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> Create(Azure.Storage.Blobs.Models.AppendBlobCreateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> Create(Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.AppendBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> CreateAsync(Azure.Storage.Blobs.Models.AppendBlobCreateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> CreateAsync(Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.AppendBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> CreateIfNotExists(Azure.Storage.Blobs.Models.AppendBlobCreateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> CreateIfNotExists(Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> CreateIfNotExistsAsync(Azure.Storage.Blobs.Models.AppendBlobCreateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> CreateIfNotExistsAsync(Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.IO.Stream OpenWrite(bool overwrite, Azure.Storage.Blobs.Models.AppendBlobOpenWriteOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.IO.Stream> OpenWriteAsync(bool overwrite, Azure.Storage.Blobs.Models.AppendBlobOpenWriteOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobInfo> Seal(Azure.Storage.Blobs.Models.AppendBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobInfo>> SealAsync(Azure.Storage.Blobs.Models.AppendBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public new Azure.Storage.Blobs.Specialized.AppendBlobClient WithCustomerProvidedKey(Azure.Storage.Blobs.Models.CustomerProvidedKey? customerProvidedKey) { throw null; }
        public new Azure.Storage.Blobs.Specialized.AppendBlobClient WithEncryptionScope(string encryptionScope) { throw null; }
        public new Azure.Storage.Blobs.Specialized.AppendBlobClient WithSnapshot(string snapshot) { throw null; }
        public new Azure.Storage.Blobs.Specialized.AppendBlobClient WithVersion(string versionId) { throw null; }
    }
    public partial class BlobBaseClient
    {
        protected BlobBaseClient() { }
        public BlobBaseClient(string connectionString, string blobContainerName, string blobName) { }
        public BlobBaseClient(string connectionString, string blobContainerName, string blobName, Azure.Storage.Blobs.BlobClientOptions options) { }
        public BlobBaseClient(System.Uri blobUri, Azure.AzureSasCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public BlobBaseClient(System.Uri blobUri, Azure.Core.TokenCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public BlobBaseClient(System.Uri blobUri, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public BlobBaseClient(System.Uri blobUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public virtual string AccountName { get { throw null; } }
        public virtual string BlobContainerName { get { throw null; } }
        public virtual bool CanGenerateSasUri { get { throw null; } }
        public virtual string Name { get { throw null; } }
        public virtual System.Uri Uri { get { throw null; } }
        public virtual Azure.Response AbortCopyFromUri(string copyId, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AbortCopyFromUriAsync(string copyId, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobSnapshotInfo> CreateSnapshot(System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobSnapshotInfo>> CreateSnapshotAsync(System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(Azure.Storage.Blobs.Models.DeleteSnapshotsOption snapshotsOption = Azure.Storage.Blobs.Models.DeleteSnapshotsOption.None, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(Azure.Storage.Blobs.Models.DeleteSnapshotsOption snapshotsOption = Azure.Storage.Blobs.Models.DeleteSnapshotsOption.None, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> DeleteIfExists(Azure.Storage.Blobs.Models.DeleteSnapshotsOption snapshotsOption = Azure.Storage.Blobs.Models.DeleteSnapshotsOption.None, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> DeleteIfExistsAsync(Azure.Storage.Blobs.Models.DeleteSnapshotsOption snapshotsOption = Azure.Storage.Blobs.Models.DeleteSnapshotsOption.None, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteImmutabilityPolicy(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteImmutabilityPolicyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobDownloadInfo> Download() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobDownloadInfo> Download(Azure.HttpRange range = default(Azure.HttpRange), Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, bool rangeGetContentHash = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobDownloadInfo> Download(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobDownloadInfo>> DownloadAsync() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobDownloadInfo>> DownloadAsync(Azure.HttpRange range = default(Azure.HttpRange), Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, bool rangeGetContentHash = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobDownloadInfo>> DownloadAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobDownloadResult> DownloadContent() { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobDownloadResult> DownloadContent(Azure.Storage.Blobs.Models.BlobDownloadOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobDownloadResult> DownloadContent(Azure.Storage.Blobs.Models.BlobRequestConditions conditions, System.IProgress<long> progressHandler, Azure.HttpRange range, System.Threading.CancellationToken cancellationToken) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobDownloadResult> DownloadContent(Azure.Storage.Blobs.Models.BlobRequestConditions conditions, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobDownloadResult> DownloadContent(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobDownloadResult>> DownloadContentAsync() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobDownloadResult>> DownloadContentAsync(Azure.Storage.Blobs.Models.BlobDownloadOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobDownloadResult>> DownloadContentAsync(Azure.Storage.Blobs.Models.BlobRequestConditions conditions, System.IProgress<long> progressHandler, Azure.HttpRange range, System.Threading.CancellationToken cancellationToken) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobDownloadResult>> DownloadContentAsync(Azure.Storage.Blobs.Models.BlobRequestConditions conditions, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobDownloadResult>> DownloadContentAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobDownloadStreamingResult> DownloadStreaming(Azure.HttpRange range, Azure.Storage.Blobs.Models.BlobRequestConditions conditions, bool rangeGetContentHash, System.IProgress<long> progressHandler, System.Threading.CancellationToken cancellationToken) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobDownloadStreamingResult> DownloadStreaming(Azure.HttpRange range, Azure.Storage.Blobs.Models.BlobRequestConditions conditions, bool rangeGetContentHash, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobDownloadStreamingResult> DownloadStreaming(Azure.Storage.Blobs.Models.BlobDownloadOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobDownloadStreamingResult>> DownloadStreamingAsync(Azure.HttpRange range, Azure.Storage.Blobs.Models.BlobRequestConditions conditions, bool rangeGetContentHash, System.IProgress<long> progressHandler, System.Threading.CancellationToken cancellationToken) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobDownloadStreamingResult>> DownloadStreamingAsync(Azure.HttpRange range, Azure.Storage.Blobs.Models.BlobRequestConditions conditions, bool rangeGetContentHash, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobDownloadStreamingResult>> DownloadStreamingAsync(Azure.Storage.Blobs.Models.BlobDownloadOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadTo(System.IO.Stream destination) { throw null; }
        public virtual Azure.Response DownloadTo(System.IO.Stream destination, Azure.Storage.Blobs.Models.BlobDownloadToOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response DownloadTo(System.IO.Stream destination, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, Azure.Storage.StorageTransferOptions transferOptions = default(Azure.Storage.StorageTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadTo(System.IO.Stream destination, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response DownloadTo(string path) { throw null; }
        public virtual Azure.Response DownloadTo(string path, Azure.Storage.Blobs.Models.BlobDownloadToOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response DownloadTo(string path, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, Azure.Storage.StorageTransferOptions transferOptions = default(Azure.Storage.StorageTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadTo(string path, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadToAsync(System.IO.Stream destination) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadToAsync(System.IO.Stream destination, Azure.Storage.Blobs.Models.BlobDownloadToOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadToAsync(System.IO.Stream destination, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, Azure.Storage.StorageTransferOptions transferOptions = default(Azure.Storage.StorageTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadToAsync(System.IO.Stream destination, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadToAsync(string path) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadToAsync(string path, Azure.Storage.Blobs.Models.BlobDownloadToOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadToAsync(string path, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, Azure.Storage.StorageTransferOptions transferOptions = default(Azure.Storage.StorageTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadToAsync(string path, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<bool> Exists(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Uri GenerateSasUri(Azure.Storage.Sas.BlobSasBuilder builder) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Uri GenerateSasUri(Azure.Storage.Sas.BlobSasBuilder builder, out string stringToSign) { throw null; }
        public virtual System.Uri GenerateSasUri(Azure.Storage.Sas.BlobSasPermissions permissions, System.DateTimeOffset expiresOn) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Uri GenerateSasUri(Azure.Storage.Sas.BlobSasPermissions permissions, System.DateTimeOffset expiresOn, out string stringToSign) { throw null; }
        public virtual System.Uri GenerateUserDelegationSasUri(Azure.Storage.Sas.BlobSasBuilder builder, Azure.Storage.Blobs.Models.UserDelegationKey userDelegationKey) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Uri GenerateUserDelegationSasUri(Azure.Storage.Sas.BlobSasBuilder builder, Azure.Storage.Blobs.Models.UserDelegationKey userDelegationKey, out string stringToSign) { throw null; }
        public virtual System.Uri GenerateUserDelegationSasUri(Azure.Storage.Sas.BlobSasPermissions permissions, System.DateTimeOffset expiresOn, Azure.Storage.Blobs.Models.UserDelegationKey userDelegationKey) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Uri GenerateUserDelegationSasUri(Azure.Storage.Sas.BlobSasPermissions permissions, System.DateTimeOffset expiresOn, Azure.Storage.Blobs.Models.UserDelegationKey userDelegationKey, out string stringToSign) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.AccountInfo> GetAccountInfo(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.AccountInfo>> GetAccountInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected internal virtual Azure.Storage.Blobs.Specialized.BlobLeaseClient GetBlobLeaseClientCore(string leaseId) { throw null; }
        protected static System.Threading.Tasks.Task<Azure.HttpAuthorization> GetCopyAuthorizationHeaderAsync(Azure.Storage.Blobs.Specialized.BlobBaseClient client, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected internal virtual Azure.Storage.Blobs.BlobContainerClient GetParentBlobContainerClientCore() { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobProperties> GetProperties(Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobProperties>> GetPropertiesAsync(Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.GetBlobTagResult> GetTags(Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.GetBlobTagResult>> GetTagsAsync(Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.IO.Stream OpenRead(Azure.Storage.Blobs.Models.BlobOpenReadOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.IO.Stream OpenRead(bool allowBlobModifications, long position = (long)0, int? bufferSize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.IO.Stream OpenRead(long position = (long)0, int? bufferSize = default(int?), Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.IO.Stream> OpenReadAsync(Azure.Storage.Blobs.Models.BlobOpenReadOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<System.IO.Stream> OpenReadAsync(bool allowBlobModifications, long position = (long)0, int? bufferSize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<System.IO.Stream> OpenReadAsync(long position = (long)0, int? bufferSize = default(int?), Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetAccessTier(Azure.Storage.Blobs.Models.AccessTier accessTier, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, Azure.Storage.Blobs.Models.RehydratePriority? rehydratePriority = default(Azure.Storage.Blobs.Models.RehydratePriority?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetAccessTierAsync(Azure.Storage.Blobs.Models.AccessTier accessTier, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, Azure.Storage.Blobs.Models.RehydratePriority? rehydratePriority = default(Azure.Storage.Blobs.Models.RehydratePriority?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobInfo> SetHttpHeaders(Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobInfo>> SetHttpHeadersAsync(Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobImmutabilityPolicy> SetImmutabilityPolicy(Azure.Storage.Blobs.Models.BlobImmutabilityPolicy immutabilityPolicy, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobImmutabilityPolicy>> SetImmutabilityPolicyAsync(Azure.Storage.Blobs.Models.BlobImmutabilityPolicy immutabilityPolicy, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobLegalHoldResult> SetLegalHold(bool hasLegalHold, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobLegalHoldResult>> SetLegalHoldAsync(bool hasLegalHold, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobInfo> SetMetadata(System.Collections.Generic.IDictionary<string, string> metadata, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobInfo>> SetMetadataAsync(System.Collections.Generic.IDictionary<string, string> metadata, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetTags(System.Collections.Generic.IDictionary<string, string> tags, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Storage.Blobs.Models.CopyFromUriOperation StartCopyFromUri(System.Uri source, Azure.Storage.Blobs.Models.BlobCopyFromUriOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Storage.Blobs.Models.CopyFromUriOperation StartCopyFromUri(System.Uri source, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.AccessTier? accessTier = default(Azure.Storage.Blobs.Models.AccessTier?), Azure.Storage.Blobs.Models.BlobRequestConditions sourceConditions = null, Azure.Storage.Blobs.Models.BlobRequestConditions destinationConditions = null, Azure.Storage.Blobs.Models.RehydratePriority? rehydratePriority = default(Azure.Storage.Blobs.Models.RehydratePriority?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Storage.Blobs.Models.CopyFromUriOperation> StartCopyFromUriAsync(System.Uri source, Azure.Storage.Blobs.Models.BlobCopyFromUriOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Storage.Blobs.Models.CopyFromUriOperation> StartCopyFromUriAsync(System.Uri source, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.AccessTier? accessTier = default(Azure.Storage.Blobs.Models.AccessTier?), Azure.Storage.Blobs.Models.BlobRequestConditions sourceConditions = null, Azure.Storage.Blobs.Models.BlobRequestConditions destinationConditions = null, Azure.Storage.Blobs.Models.RehydratePriority? rehydratePriority = default(Azure.Storage.Blobs.Models.RehydratePriority?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobCopyInfo> SyncCopyFromUri(System.Uri source, Azure.Storage.Blobs.Models.BlobCopyFromUriOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobCopyInfo>> SyncCopyFromUriAsync(System.Uri source, Azure.Storage.Blobs.Models.BlobCopyFromUriOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Undelete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UndeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Storage.Blobs.Specialized.BlobBaseClient WithCustomerProvidedKey(Azure.Storage.Blobs.Models.CustomerProvidedKey? customerProvidedKey) { throw null; }
        public virtual Azure.Storage.Blobs.Specialized.BlobBaseClient WithEncryptionScope(string encryptionScope) { throw null; }
        public virtual Azure.Storage.Blobs.Specialized.BlobBaseClient WithSnapshot(string snapshot) { throw null; }
        protected virtual Azure.Storage.Blobs.Specialized.BlobBaseClient WithSnapshotCore(string snapshot) { throw null; }
        public virtual Azure.Storage.Blobs.Specialized.BlobBaseClient WithVersion(string versionId) { throw null; }
    }
    public partial class BlobLeaseClient
    {
        public static readonly System.TimeSpan InfiniteLeaseDuration;
        protected BlobLeaseClient() { }
        public BlobLeaseClient(Azure.Storage.Blobs.BlobContainerClient client, string leaseId = null) { }
        public BlobLeaseClient(Azure.Storage.Blobs.Specialized.BlobBaseClient client, string leaseId = null) { }
        protected virtual Azure.Storage.Blobs.Specialized.BlobBaseClient BlobClient { get { throw null; } }
        protected virtual Azure.Storage.Blobs.BlobContainerClient BlobContainerClient { get { throw null; } }
        public virtual string LeaseId { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        public virtual Azure.Response Acquire(System.TimeSpan duration, Azure.RequestConditions conditions, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobLease> Acquire(System.TimeSpan duration, Azure.RequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AcquireAsync(System.TimeSpan duration, Azure.RequestConditions conditions, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobLease>> AcquireAsync(System.TimeSpan duration, Azure.RequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobLease> Break(System.TimeSpan? breakPeriod = default(System.TimeSpan?), Azure.RequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobLease>> BreakAsync(System.TimeSpan? breakPeriod = default(System.TimeSpan?), Azure.RequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobLease> Change(string proposedId, Azure.RequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobLease>> ChangeAsync(string proposedId, Azure.RequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.ReleasedObjectInfo> Release(Azure.RequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.ReleasedObjectInfo>> ReleaseAsync(Azure.RequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.ReleasedObjectInfo>> ReleaseInternal(Azure.RequestConditions conditions, bool async, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobLease> Renew(Azure.RequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobLease>> RenewAsync(Azure.RequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BlockBlobClient : Azure.Storage.Blobs.Specialized.BlobBaseClient
    {
        protected BlockBlobClient() { }
        public BlockBlobClient(string connectionString, string containerName, string blobName) { }
        public BlockBlobClient(string connectionString, string blobContainerName, string blobName, Azure.Storage.Blobs.BlobClientOptions options) { }
        public BlockBlobClient(System.Uri blobUri, Azure.AzureSasCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public BlockBlobClient(System.Uri blobUri, Azure.Core.TokenCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public BlockBlobClient(System.Uri blobUri, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public BlockBlobClient(System.Uri blobUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public virtual int BlockBlobMaxBlocks { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual int BlockBlobMaxStageBlockBytes { get { throw null; } }
        public virtual long BlockBlobMaxStageBlockLongBytes { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual int BlockBlobMaxUploadBlobBytes { get { throw null; } }
        public virtual long BlockBlobMaxUploadBlobLongBytes { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> CommitBlockList(System.Collections.Generic.IEnumerable<string> base64BlockIds, Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, Azure.Storage.Blobs.Models.AccessTier? accessTier = default(Azure.Storage.Blobs.Models.AccessTier?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> CommitBlockList(System.Collections.Generic.IEnumerable<string> base64BlockIds, Azure.Storage.Blobs.Models.CommitBlockListOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> CommitBlockListAsync(System.Collections.Generic.IEnumerable<string> base64BlockIds, Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, Azure.Storage.Blobs.Models.AccessTier? accessTier = default(Azure.Storage.Blobs.Models.AccessTier?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> CommitBlockListAsync(System.Collections.Generic.IEnumerable<string> base64BlockIds, Azure.Storage.Blobs.Models.CommitBlockListOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected static Azure.Storage.Blobs.Specialized.BlockBlobClient CreateClient(System.Uri blobUri, Azure.Storage.Blobs.BlobClientOptions options, Azure.Core.Pipeline.HttpPipeline pipeline) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlockList> GetBlockList(Azure.Storage.Blobs.Models.BlockListTypes blockListTypes = Azure.Storage.Blobs.Models.BlockListTypes.All, string snapshot = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlockList>> GetBlockListAsync(Azure.Storage.Blobs.Models.BlockListTypes blockListTypes = Azure.Storage.Blobs.Models.BlockListTypes.All, string snapshot = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.IO.Stream OpenWrite(bool overwrite, Azure.Storage.Blobs.Models.BlockBlobOpenWriteOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.IO.Stream> OpenWriteAsync(bool overwrite, Azure.Storage.Blobs.Models.BlockBlobOpenWriteOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobDownloadInfo> Query(string querySqlExpression, Azure.Storage.Blobs.Models.BlobQueryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobDownloadInfo>> QueryAsync(string querySqlExpression, Azure.Storage.Blobs.Models.BlobQueryOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlockInfo> StageBlock(string base64BlockId, System.IO.Stream content, Azure.Storage.Blobs.Models.BlockBlobStageBlockOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlockInfo> StageBlock(string base64BlockId, System.IO.Stream content, byte[] transactionalContentHash, Azure.Storage.Blobs.Models.BlobRequestConditions conditions, System.IProgress<long> progressHandler, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlockInfo>> StageBlockAsync(string base64BlockId, System.IO.Stream content, Azure.Storage.Blobs.Models.BlockBlobStageBlockOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlockInfo>> StageBlockAsync(string base64BlockId, System.IO.Stream content, byte[] transactionalContentHash, Azure.Storage.Blobs.Models.BlobRequestConditions conditions, System.IProgress<long> progressHandler, System.Threading.CancellationToken cancellationToken) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlockInfo> StageBlockFromUri(System.Uri sourceUri, string base64BlockId, Azure.HttpRange sourceRange, byte[] sourceContentHash, Azure.RequestConditions sourceConditions, Azure.Storage.Blobs.Models.BlobRequestConditions conditions, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlockInfo> StageBlockFromUri(System.Uri sourceUri, string base64BlockId, Azure.Storage.Blobs.Models.StageBlockFromUriOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlockInfo>> StageBlockFromUriAsync(System.Uri sourceUri, string base64BlockId, Azure.HttpRange sourceRange, byte[] sourceContentHash, Azure.RequestConditions sourceConditions, Azure.Storage.Blobs.Models.BlobRequestConditions conditions, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlockInfo>> StageBlockFromUriAsync(System.Uri sourceUri, string base64BlockId, Azure.Storage.Blobs.Models.StageBlockFromUriOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> SyncUploadFromUri(System.Uri copySource, Azure.Storage.Blobs.Models.BlobSyncUploadFromUriOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> SyncUploadFromUri(System.Uri copySource, bool overwrite = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> SyncUploadFromUriAsync(System.Uri copySource, Azure.Storage.Blobs.Models.BlobSyncUploadFromUriOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> SyncUploadFromUriAsync(System.Uri copySource, bool overwrite = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> Upload(System.IO.Stream content, Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, Azure.Storage.Blobs.Models.AccessTier? accessTier = default(Azure.Storage.Blobs.Models.AccessTier?), System.IProgress<long> progressHandler = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> Upload(System.IO.Stream content, Azure.Storage.Blobs.Models.BlobUploadOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> UploadAsync(System.IO.Stream content, Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, Azure.Storage.Blobs.Models.AccessTier? accessTier = default(Azure.Storage.Blobs.Models.AccessTier?), System.IProgress<long> progressHandler = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> UploadAsync(System.IO.Stream content, Azure.Storage.Blobs.Models.BlobUploadOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public new Azure.Storage.Blobs.Specialized.BlockBlobClient WithCustomerProvidedKey(Azure.Storage.Blobs.Models.CustomerProvidedKey? customerProvidedKey) { throw null; }
        public new Azure.Storage.Blobs.Specialized.BlockBlobClient WithEncryptionScope(string encryptionScope) { throw null; }
        public new Azure.Storage.Blobs.Specialized.BlockBlobClient WithSnapshot(string snapshot) { throw null; }
        protected sealed override Azure.Storage.Blobs.Specialized.BlobBaseClient WithSnapshotCore(string snapshot) { throw null; }
        public new Azure.Storage.Blobs.Specialized.BlockBlobClient WithVersion(string versionId) { throw null; }
    }
    public partial class PageBlobClient : Azure.Storage.Blobs.Specialized.BlobBaseClient
    {
        protected PageBlobClient() { }
        public PageBlobClient(string connectionString, string blobContainerName, string blobName) { }
        public PageBlobClient(string connectionString, string blobContainerName, string blobName, Azure.Storage.Blobs.BlobClientOptions options) { }
        public PageBlobClient(System.Uri blobUri, Azure.AzureSasCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public PageBlobClient(System.Uri blobUri, Azure.Core.TokenCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public PageBlobClient(System.Uri blobUri, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public PageBlobClient(System.Uri blobUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public virtual int PageBlobMaxUploadPagesBytes { get { throw null; } }
        public virtual int PageBlobPageBytes { get { throw null; } }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.PageInfo> ClearPages(Azure.HttpRange range, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.PageInfo>> ClearPagesAsync(Azure.HttpRange range, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> Create(long size, Azure.Storage.Blobs.Models.PageBlobCreateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> Create(long size, long? sequenceNumber = default(long?), Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> CreateAsync(long size, Azure.Storage.Blobs.Models.PageBlobCreateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> CreateAsync(long size, long? sequenceNumber = default(long?), Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> CreateIfNotExists(long size, Azure.Storage.Blobs.Models.PageBlobCreateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> CreateIfNotExists(long size, long? sequenceNumber = default(long?), Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> CreateIfNotExistsAsync(long size, Azure.Storage.Blobs.Models.PageBlobCreateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> CreateIfNotExistsAsync(long size, long? sequenceNumber = default(long?), Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Storage.Blobs.Models.PageRangeItem> GetAllPageRanges(Azure.Storage.Blobs.Models.GetPageRangesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Blobs.Models.PageRangeItem> GetAllPageRangesAsync(Azure.Storage.Blobs.Models.GetPageRangesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Storage.Blobs.Models.PageRangeItem> GetAllPageRangesDiff(Azure.Storage.Blobs.Models.GetPageRangesDiffOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Blobs.Models.PageRangeItem> GetAllPageRangesDiffAsync(Azure.Storage.Blobs.Models.GetPageRangesDiffOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.PageRangesInfo> GetManagedDiskPageRangesDiff(Azure.HttpRange? range = default(Azure.HttpRange?), string snapshot = null, System.Uri previousSnapshotUri = null, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.PageRangesInfo>> GetManagedDiskPageRangesDiffAsync(Azure.HttpRange? range = default(Azure.HttpRange?), string snapshot = null, System.Uri previousSnapshotUri = null, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Blobs.Models.PageRangesInfo> GetPageRanges(Azure.HttpRange? range = default(Azure.HttpRange?), string snapshot = null, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.PageRangesInfo>> GetPageRangesAsync(Azure.HttpRange? range = default(Azure.HttpRange?), string snapshot = null, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Blobs.Models.PageRangesInfo> GetPageRangesDiff(Azure.HttpRange? range = default(Azure.HttpRange?), string snapshot = null, string previousSnapshot = null, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.PageRangesInfo>> GetPageRangesDiffAsync(Azure.HttpRange? range = default(Azure.HttpRange?), string snapshot = null, string previousSnapshot = null, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.IO.Stream OpenWrite(bool overwrite, long position, Azure.Storage.Blobs.Models.PageBlobOpenWriteOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.IO.Stream> OpenWriteAsync(bool overwrite, long position, Azure.Storage.Blobs.Models.PageBlobOpenWriteOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.PageBlobInfo> Resize(long size, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.PageBlobInfo>> ResizeAsync(long size, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Storage.Blobs.Models.CopyFromUriOperation StartCopyIncremental(System.Uri sourceUri, string snapshot, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Storage.Blobs.Models.CopyFromUriOperation> StartCopyIncrementalAsync(System.Uri sourceUri, string snapshot, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.PageBlobInfo> UpdateSequenceNumber(Azure.Storage.Blobs.Models.SequenceNumberAction action, long? sequenceNumber = default(long?), Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.PageBlobInfo>> UpdateSequenceNumberAsync(Azure.Storage.Blobs.Models.SequenceNumberAction action, long? sequenceNumber = default(long?), Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.PageInfo> UploadPages(System.IO.Stream content, long offset, Azure.Storage.Blobs.Models.PageBlobUploadPagesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Blobs.Models.PageInfo> UploadPages(System.IO.Stream content, long offset, byte[] transactionalContentHash, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions, System.IProgress<long> progressHandler, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.PageInfo>> UploadPagesAsync(System.IO.Stream content, long offset, Azure.Storage.Blobs.Models.PageBlobUploadPagesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.PageInfo>> UploadPagesAsync(System.IO.Stream content, long offset, byte[] transactionalContentHash, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions, System.IProgress<long> progressHandler, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.PageInfo> UploadPagesFromUri(System.Uri sourceUri, Azure.HttpRange sourceRange, Azure.HttpRange range, Azure.Storage.Blobs.Models.PageBlobUploadPagesFromUriOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Blobs.Models.PageInfo> UploadPagesFromUri(System.Uri sourceUri, Azure.HttpRange sourceRange, Azure.HttpRange range, byte[] sourceContentHash, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions, Azure.Storage.Blobs.Models.PageBlobRequestConditions sourceConditions, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.PageInfo>> UploadPagesFromUriAsync(System.Uri sourceUri, Azure.HttpRange sourceRange, Azure.HttpRange range, Azure.Storage.Blobs.Models.PageBlobUploadPagesFromUriOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.PageInfo>> UploadPagesFromUriAsync(System.Uri sourceUri, Azure.HttpRange sourceRange, Azure.HttpRange range, byte[] sourceContentHash, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions, Azure.Storage.Blobs.Models.PageBlobRequestConditions sourceConditions, System.Threading.CancellationToken cancellationToken) { throw null; }
        public new Azure.Storage.Blobs.Specialized.PageBlobClient WithCustomerProvidedKey(Azure.Storage.Blobs.Models.CustomerProvidedKey? customerProvidedKey) { throw null; }
        public new Azure.Storage.Blobs.Specialized.PageBlobClient WithEncryptionScope(string encryptionScope) { throw null; }
        public new Azure.Storage.Blobs.Specialized.PageBlobClient WithSnapshot(string snapshot) { throw null; }
        protected sealed override Azure.Storage.Blobs.Specialized.BlobBaseClient WithSnapshotCore(string snapshot) { throw null; }
        public new Azure.Storage.Blobs.Specialized.PageBlobClient WithVersion(string versionId) { throw null; }
    }
    public partial class SpecializedBlobClientOptions : Azure.Storage.Blobs.BlobClientOptions
    {
        public SpecializedBlobClientOptions(Azure.Storage.Blobs.BlobClientOptions.ServiceVersion version = Azure.Storage.Blobs.BlobClientOptions.ServiceVersion.V2026_02_06) : base (default(Azure.Storage.Blobs.BlobClientOptions.ServiceVersion)) { }
        public Azure.Storage.ClientSideEncryptionOptions ClientSideEncryption { get { throw null; } set { } }
    }
    public static partial class SpecializedBlobExtensions
    {
        public static Azure.Storage.Blobs.Specialized.AppendBlobClient GetAppendBlobClient(this Azure.Storage.Blobs.BlobContainerClient client, string blobName) { throw null; }
        public static Azure.Storage.Blobs.Specialized.BlobBaseClient GetBlobBaseClient(this Azure.Storage.Blobs.BlobContainerClient client, string blobName) { throw null; }
        public static Azure.Storage.Blobs.Specialized.BlobLeaseClient GetBlobLeaseClient(this Azure.Storage.Blobs.BlobContainerClient client, string leaseId = null) { throw null; }
        public static Azure.Storage.Blobs.Specialized.BlobLeaseClient GetBlobLeaseClient(this Azure.Storage.Blobs.Specialized.BlobBaseClient client, string leaseId = null) { throw null; }
        public static Azure.Storage.Blobs.Specialized.BlockBlobClient GetBlockBlobClient(this Azure.Storage.Blobs.BlobContainerClient client, string blobName) { throw null; }
        public static Azure.Storage.Blobs.Specialized.PageBlobClient GetPageBlobClient(this Azure.Storage.Blobs.BlobContainerClient client, string blobName) { throw null; }
        public static Azure.Storage.Blobs.BlobContainerClient GetParentBlobContainerClient(this Azure.Storage.Blobs.Specialized.BlobBaseClient client) { throw null; }
        public static Azure.Storage.Blobs.BlobServiceClient GetParentBlobServiceClient(this Azure.Storage.Blobs.BlobContainerClient client) { throw null; }
        public static void UpdateClientSideKeyEncryptionKey(this Azure.Storage.Blobs.BlobClient client, Azure.Storage.ClientSideEncryptionOptions encryptionOptionsOverride = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public static System.Threading.Tasks.Task UpdateClientSideKeyEncryptionKeyAsync(this Azure.Storage.Blobs.BlobClient client, Azure.Storage.ClientSideEncryptionOptions encryptionOptionsOverride = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Storage.Blobs.BlobClient WithClientSideEncryptionOptions(this Azure.Storage.Blobs.BlobClient client, Azure.Storage.ClientSideEncryptionOptions clientSideEncryptionOptions) { throw null; }
    }
}
namespace Azure.Storage.Sas
{
    [System.FlagsAttribute]
    public enum BlobAccountSasPermissions
    {
        All = -1,
        Read = 1,
        Add = 2,
        Create = 4,
        Write = 8,
        Delete = 16,
        List = 32,
    }
    [System.FlagsAttribute]
    public enum BlobContainerSasPermissions
    {
        All = -1,
        Read = 1,
        Add = 2,
        Create = 4,
        Write = 8,
        Delete = 16,
        List = 32,
        Tag = 64,
        DeleteBlobVersion = 128,
        Move = 256,
        Execute = 512,
        SetImmutabilityPolicy = 1024,
        Filter = 2048,
    }
    public partial class BlobSasBuilder
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public BlobSasBuilder() { }
        public BlobSasBuilder(Azure.Storage.Sas.BlobContainerSasPermissions permissions, System.DateTimeOffset expiresOn) { }
        public BlobSasBuilder(Azure.Storage.Sas.BlobSasPermissions permissions, System.DateTimeOffset expiresOn) { }
        public string BlobContainerName { get { throw null; } set { } }
        public string BlobName { get { throw null; } set { } }
        public string BlobVersionId { get { throw null; } set { } }
        public string CacheControl { get { throw null; } set { } }
        public string ContentDisposition { get { throw null; } set { } }
        public string ContentEncoding { get { throw null; } set { } }
        public string ContentLanguage { get { throw null; } set { } }
        public string ContentType { get { throw null; } set { } }
        public string CorrelationId { get { throw null; } set { } }
        public string DelegatedUserObjectId { get { throw null; } set { } }
        public string EncryptionScope { get { throw null; } set { } }
        public System.DateTimeOffset ExpiresOn { get { throw null; } set { } }
        public string Identifier { get { throw null; } set { } }
        public Azure.Storage.Sas.SasIPRange IPRange { get { throw null; } set { } }
        public string Permissions { get { throw null; } }
        public string PreauthorizedAgentObjectId { get { throw null; } set { } }
        public Azure.Storage.Sas.SasProtocol Protocol { get { throw null; } set { } }
        public string Resource { get { throw null; } set { } }
        public string Snapshot { get { throw null; } set { } }
        public System.DateTimeOffset StartsOn { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Version { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public void SetPermissions(Azure.Storage.Sas.BlobAccountSasPermissions permissions) { }
        public void SetPermissions(Azure.Storage.Sas.BlobContainerSasPermissions permissions) { }
        public void SetPermissions(Azure.Storage.Sas.BlobSasPermissions permissions) { }
        public void SetPermissions(Azure.Storage.Sas.BlobVersionSasPermissions permissions) { }
        public void SetPermissions(Azure.Storage.Sas.SnapshotSasPermissions permissions) { }
        public void SetPermissions(string rawPermissions) { }
        public void SetPermissions(string rawPermissions, bool normalize = false) { }
        public Azure.Storage.Sas.BlobSasQueryParameters ToSasQueryParameters(Azure.Storage.Blobs.Models.UserDelegationKey userDelegationKey, string accountName) { throw null; }
        public Azure.Storage.Sas.BlobSasQueryParameters ToSasQueryParameters(Azure.Storage.Blobs.Models.UserDelegationKey userDelegationKey, string accountName, out string stringToSign) { throw null; }
        public Azure.Storage.Sas.BlobSasQueryParameters ToSasQueryParameters(Azure.Storage.StorageSharedKeyCredential sharedKeyCredential) { throw null; }
        public Azure.Storage.Sas.BlobSasQueryParameters ToSasQueryParameters(Azure.Storage.StorageSharedKeyCredential sharedKeyCredential, out string stringToSign) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    [System.FlagsAttribute]
    public enum BlobSasPermissions
    {
        All = -1,
        Read = 1,
        Add = 2,
        Create = 4,
        Write = 8,
        Delete = 16,
        Tag = 32,
        DeleteBlobVersion = 64,
        List = 128,
        Move = 256,
        Execute = 512,
        SetImmutabilityPolicy = 1024,
        PermanentDelete = 2048,
    }
    public sealed partial class BlobSasQueryParameters : Azure.Storage.Sas.SasQueryParameters
    {
        internal BlobSasQueryParameters() { }
        public static new Azure.Storage.Sas.BlobSasQueryParameters Empty { get { throw null; } }
        public System.DateTimeOffset KeyExpiresOn { get { throw null; } }
        public string KeyObjectId { get { throw null; } }
        public string KeyService { get { throw null; } }
        public System.DateTimeOffset KeyStartsOn { get { throw null; } }
        public string KeyTenantId { get { throw null; } }
        public string KeyVersion { get { throw null; } }
        public override string ToString() { throw null; }
    }
    [System.FlagsAttribute]
    public enum BlobVersionSasPermissions
    {
        All = -1,
        Delete = 1,
        SetImmutabilityPolicy = 2,
        PermanentDelete = 4,
    }
    [System.FlagsAttribute]
    public enum SnapshotSasPermissions
    {
        All = -1,
        Read = 1,
        Write = 2,
        Delete = 4,
        SetImmutabilityPolicy = 8,
        PermanentDelete = 16,
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class BlobClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Storage.Blobs.BlobServiceClient, Azure.Storage.Blobs.BlobClientOptions> AddBlobServiceClient<TBuilder>(this TBuilder builder, string connectionString) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Storage.Blobs.BlobServiceClient, Azure.Storage.Blobs.BlobClientOptions> AddBlobServiceClient<TBuilder>(this TBuilder builder, System.Uri serviceUri) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Storage.Blobs.BlobServiceClient, Azure.Storage.Blobs.BlobClientOptions> AddBlobServiceClient<TBuilder>(this TBuilder builder, System.Uri serviceUri, Azure.AzureSasCredential sasCredential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Storage.Blobs.BlobServiceClient, Azure.Storage.Blobs.BlobClientOptions> AddBlobServiceClient<TBuilder>(this TBuilder builder, System.Uri serviceUri, Azure.Core.TokenCredential tokenCredential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Storage.Blobs.BlobServiceClient, Azure.Storage.Blobs.BlobClientOptions> AddBlobServiceClient<TBuilder>(this TBuilder builder, System.Uri serviceUri, Azure.Storage.StorageSharedKeyCredential sharedKeyCredential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Storage.Blobs.BlobServiceClient, Azure.Storage.Blobs.BlobClientOptions> AddBlobServiceClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
