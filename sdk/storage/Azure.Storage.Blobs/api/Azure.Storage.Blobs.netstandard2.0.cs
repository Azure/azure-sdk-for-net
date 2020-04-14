namespace Azure.Storage.Blobs
{
    public partial class BlobClient : Azure.Storage.Blobs.Specialized.BlobBaseClient
    {
        protected BlobClient() { }
        public BlobClient(string connectionString, string blobContainerName, string blobName) { }
        public BlobClient(string connectionString, string blobContainerName, string blobName, Azure.Storage.Blobs.BlobClientOptions options) { }
        public BlobClient(System.Uri blobUri, Azure.Core.TokenCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public BlobClient(System.Uri blobUri, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public BlobClient(System.Uri blobUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> Upload(System.IO.Stream content) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> Upload(System.IO.Stream content, Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.IProgress<long> progressHandler = null, Azure.Storage.Blobs.Models.AccessTier? accessTier = default(Azure.Storage.Blobs.Models.AccessTier?), Azure.Storage.StorageTransferOptions transferOptions = default(Azure.Storage.StorageTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> Upload(System.IO.Stream content, bool overwrite = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> Upload(System.IO.Stream content, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> Upload(string path) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> Upload(string path, Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.IProgress<long> progressHandler = null, Azure.Storage.Blobs.Models.AccessTier? accessTier = default(Azure.Storage.Blobs.Models.AccessTier?), Azure.Storage.StorageTransferOptions transferOptions = default(Azure.Storage.StorageTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> Upload(string path, bool overwrite = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> Upload(string path, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> UploadAsync(System.IO.Stream content) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> UploadAsync(System.IO.Stream content, Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.IProgress<long> progressHandler = null, Azure.Storage.Blobs.Models.AccessTier? accessTier = default(Azure.Storage.Blobs.Models.AccessTier?), Azure.Storage.StorageTransferOptions transferOptions = default(Azure.Storage.StorageTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> UploadAsync(System.IO.Stream content, bool overwrite = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> UploadAsync(System.IO.Stream content, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> UploadAsync(string path) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> UploadAsync(string path, Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.IProgress<long> progressHandler = null, Azure.Storage.Blobs.Models.AccessTier? accessTier = default(Azure.Storage.Blobs.Models.AccessTier?), Azure.Storage.StorageTransferOptions transferOptions = default(Azure.Storage.StorageTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> UploadAsync(string path, bool overwrite = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> UploadAsync(string path, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class BlobClientOptions : Azure.Core.ClientOptions
    {
        public BlobClientOptions(Azure.Storage.Blobs.BlobClientOptions.ServiceVersion version = Azure.Storage.Blobs.BlobClientOptions.ServiceVersion.V2019_07_07) { }
        public Azure.Storage.Blobs.Models.CustomerProvidedKey? CustomerProvidedKey { get { throw null; } set { } }
        public string EncryptionScope { get { throw null; } set { } }
        public System.Uri GeoRedundantSecondaryUri { get { throw null; } set { } }
        public Azure.Storage.Blobs.BlobClientOptions.ServiceVersion Version { get { throw null; } }
        public enum ServiceVersion
        {
            V2019_02_02 = 1,
            V2019_07_07 = 2,
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
        public BlobContainerClient(System.Uri blobContainerUri, Azure.Core.TokenCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public BlobContainerClient(System.Uri blobContainerUri, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public BlobContainerClient(System.Uri blobContainerUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public virtual string AccountName { get { throw null; } }
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
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContainerAccessPolicy> GetAccessPolicy(Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContainerAccessPolicy>> GetAccessPolicyAsync(Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Storage.Blobs.BlobClient GetBlobClient(string blobName) { throw null; }
        public virtual Azure.Pageable<Azure.Storage.Blobs.Models.BlobItem> GetBlobs(Azure.Storage.Blobs.Models.BlobTraits traits = Azure.Storage.Blobs.Models.BlobTraits.None, Azure.Storage.Blobs.Models.BlobStates states = Azure.Storage.Blobs.Models.BlobStates.None, string prefix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Blobs.Models.BlobItem> GetBlobsAsync(Azure.Storage.Blobs.Models.BlobTraits traits = Azure.Storage.Blobs.Models.BlobTraits.None, Azure.Storage.Blobs.Models.BlobStates states = Azure.Storage.Blobs.Models.BlobStates.None, string prefix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Storage.Blobs.Models.BlobHierarchyItem> GetBlobsByHierarchy(Azure.Storage.Blobs.Models.BlobTraits traits = Azure.Storage.Blobs.Models.BlobTraits.None, Azure.Storage.Blobs.Models.BlobStates states = Azure.Storage.Blobs.Models.BlobStates.None, string delimiter = null, string prefix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Blobs.Models.BlobHierarchyItem> GetBlobsByHierarchyAsync(Azure.Storage.Blobs.Models.BlobTraits traits = Azure.Storage.Blobs.Models.BlobTraits.None, Azure.Storage.Blobs.Models.BlobStates states = Azure.Storage.Blobs.Models.BlobStates.None, string delimiter = null, string prefix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContainerProperties> GetProperties(Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContainerProperties>> GetPropertiesAsync(Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContainerInfo> SetAccessPolicy(Azure.Storage.Blobs.Models.PublicAccessType accessType = Azure.Storage.Blobs.Models.PublicAccessType.None, System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.BlobSignedIdentifier> permissions = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContainerInfo>> SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType accessType = Azure.Storage.Blobs.Models.PublicAccessType.None, System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.BlobSignedIdentifier> permissions = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContainerInfo> SetMetadata(System.Collections.Generic.IDictionary<string, string> metadata, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContainerInfo>> SetMetadataAsync(System.Collections.Generic.IDictionary<string, string> metadata, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> UploadBlob(string blobName, System.IO.Stream content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> UploadBlobAsync(string blobName, System.IO.Stream content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BlobServiceClient
    {
        protected BlobServiceClient() { }
        public BlobServiceClient(string connectionString) { }
        public BlobServiceClient(string connectionString, Azure.Storage.Blobs.BlobClientOptions options) { }
        public BlobServiceClient(System.Uri serviceUri, Azure.Core.TokenCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public BlobServiceClient(System.Uri serviceUri, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public BlobServiceClient(System.Uri serviceUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public string AccountName { get { throw null; } }
        public virtual System.Uri Uri { get { throw null; } }
        public virtual Azure.Response<Azure.Storage.Blobs.BlobContainerClient> CreateBlobContainer(string blobContainerName, Azure.Storage.Blobs.Models.PublicAccessType publicAccessType = Azure.Storage.Blobs.Models.PublicAccessType.None, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.BlobContainerClient>> CreateBlobContainerAsync(string blobContainerName, Azure.Storage.Blobs.Models.PublicAccessType publicAccessType = Azure.Storage.Blobs.Models.PublicAccessType.None, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected static Azure.Storage.Blobs.BlobServiceClient CreateClient(System.Uri serviceUri, Azure.Storage.Blobs.BlobClientOptions options, Azure.Core.Pipeline.HttpPipelinePolicy authentication, Azure.Core.Pipeline.HttpPipeline pipeline) { throw null; }
        public virtual Azure.Response DeleteBlobContainer(string blobContainerName, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteBlobContainerAsync(string blobContainerName, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.AccountInfo> GetAccountInfo(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.AccountInfo>> GetAccountInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected static Azure.Core.Pipeline.HttpPipelinePolicy GetAuthenticationPolicy(Azure.Storage.Blobs.BlobServiceClient client) { throw null; }
        public virtual Azure.Storage.Blobs.BlobContainerClient GetBlobContainerClient(string blobContainerName) { throw null; }
        public virtual Azure.Pageable<Azure.Storage.Blobs.Models.BlobContainerItem> GetBlobContainers(Azure.Storage.Blobs.Models.BlobContainerTraits traits = Azure.Storage.Blobs.Models.BlobContainerTraits.None, string prefix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Blobs.Models.BlobContainerItem> GetBlobContainersAsync(Azure.Storage.Blobs.Models.BlobContainerTraits traits = Azure.Storage.Blobs.Models.BlobContainerTraits.None, string prefix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    }
    public partial class BlobUriBuilder
    {
        public BlobUriBuilder(System.Uri uri) { }
        public string AccountName { get { throw null; } set { } }
        public string BlobContainerName { get { throw null; } set { } }
        public string BlobName { get { throw null; } set { } }
        public string Host { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public Azure.Storage.Sas.BlobSasQueryParameters Sas { get { throw null; } set { } }
        public string Scheme { get { throw null; } set { } }
        public string Snapshot { get { throw null; } set { } }
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
        public Azure.Storage.Blobs.Models.SkuName SkuName { get { throw null; } }
    }
    public enum AccountKind
    {
        Storage = 0,
        BlobStorage = 1,
        StorageV2 = 2,
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
    }
    public partial class BlobAccessPolicy
    {
        public BlobAccessPolicy() { }
        public System.DateTimeOffset ExpiresOn { get { throw null; } set { } }
        public string Permissions { get { throw null; } set { } }
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
    public readonly partial struct BlobBlock : System.IEquatable<Azure.Storage.Blobs.Models.BlobBlock>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public string Name { get { throw null; } }
        public int Size { get { throw null; } }
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
        public string Name { get { throw null; } }
        public Azure.Storage.Blobs.Models.BlobContainerProperties Properties { get { throw null; } }
    }
    public partial class BlobContainerProperties
    {
        internal BlobContainerProperties() { }
        public string DefaultEncryptionScope { get { throw null; } }
        public Azure.ETag ETag { get { throw null; } }
        public bool? HasImmutabilityPolicy { get { throw null; } }
        public bool? HasLegalHold { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public Azure.Storage.Blobs.Models.LeaseDurationType? LeaseDuration { get { throw null; } }
        public Azure.Storage.Blobs.Models.LeaseState? LeaseState { get { throw null; } }
        public Azure.Storage.Blobs.Models.LeaseStatus? LeaseStatus { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public bool? PreventEncryptionScopeOverride { get { throw null; } }
        public Azure.Storage.Blobs.Models.PublicAccessType? PublicAccess { get { throw null; } }
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
    }
    public partial class BlobCopyInfo
    {
        internal BlobCopyInfo() { }
        public string CopyId { get { throw null; } }
        public Azure.Storage.Blobs.Models.CopyStatus CopyStatus { get { throw null; } }
        public Azure.ETag ETag { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
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
        public string CacheControl { get { throw null; } }
        public string ContentDisposition { get { throw null; } }
        public string ContentEncoding { get { throw null; } }
        public string ContentLanguage { get { throw null; } }
        public string ContentRange { get { throw null; } }
        public System.DateTimeOffset CopyCompletedOn { get { throw null; } }
        public string CopyId { get { throw null; } }
        public string CopyProgress { get { throw null; } }
        public System.Uri CopySource { get { throw null; } }
        public Azure.Storage.Blobs.Models.CopyStatus CopyStatus { get { throw null; } }
        public string CopyStatusDescription { get { throw null; } }
        public string EncryptionKeySha256 { get { throw null; } }
        public string EncryptionScope { get { throw null; } }
        public Azure.ETag ETag { get { throw null; } }
        public bool IsServerEncrypted { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public Azure.Storage.Blobs.Models.LeaseDurationType LeaseDuration { get { throw null; } }
        public Azure.Storage.Blobs.Models.LeaseState LeaseState { get { throw null; } }
        public Azure.Storage.Blobs.Models.LeaseStatus LeaseStatus { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
    }
    public partial class BlobDownloadInfo : System.IDisposable
    {
        internal BlobDownloadInfo() { }
        public Azure.Storage.Blobs.Models.BlobType BlobType { get { throw null; } }
        public System.IO.Stream Content { get { throw null; } }
        public byte[] ContentHash { get { throw null; } }
        public long ContentLength { get { throw null; } }
        public string ContentType { get { throw null; } }
        public Azure.Storage.Blobs.Models.BlobDownloadDetails Details { get { throw null; } }
        public void Dispose() { }
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
        public static Azure.Storage.Blobs.Models.BlobErrorCode BlobAlreadyExists { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode BlobArchived { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode BlobBeingRehydrated { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode BlobNotArchived { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode BlobNotFound { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode BlobOverwritten { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode BlobTierInadequateForContentLength { get { throw null; } }
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
        public static Azure.Storage.Blobs.Models.BlobErrorCode SnaphotOperationRateExceeded { get { throw null; } }
        public static Azure.Storage.Blobs.Models.BlobErrorCode SnapshotCountExceeded { get { throw null; } }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Storage.Blobs.Models.BlobErrorCode left, Azure.Storage.Blobs.Models.BlobErrorCode right) { throw null; }
        public static implicit operator Azure.Storage.Blobs.Models.BlobErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.Storage.Blobs.Models.BlobErrorCode left, Azure.Storage.Blobs.Models.BlobErrorCode right) { throw null; }
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
    public partial class BlobInfo
    {
        internal BlobInfo() { }
        public long BlobSequenceNumber { get { throw null; } }
        public Azure.ETag ETag { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
    }
    public partial class BlobItem
    {
        internal BlobItem() { }
        public bool Deleted { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Storage.Blobs.Models.BlobItemProperties Properties { get { throw null; } }
        public string Snapshot { get { throw null; } }
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
        public bool? IncrementalCopy { get { throw null; } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public Azure.Storage.Blobs.Models.LeaseDurationType? LeaseDuration { get { throw null; } }
        public Azure.Storage.Blobs.Models.LeaseState? LeaseState { get { throw null; } }
        public Azure.Storage.Blobs.Models.LeaseStatus? LeaseStatus { get { throw null; } }
        public int? RemainingRetentionDays { get { throw null; } }
        public bool? ServerEncrypted { get { throw null; } }
    }
    public partial class BlobLease
    {
        internal BlobLease() { }
        public Azure.ETag ETag { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public string LeaseId { get { throw null; } }
        public int? LeaseTime { get { throw null; } }
    }
    public partial class BlobMetrics
    {
        public BlobMetrics() { }
        public bool Enabled { get { throw null; } set { } }
        public bool? IncludeApis { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobRetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
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
        public Azure.Storage.Blobs.Models.CopyStatus CopyStatus { get { throw null; } }
        public string CopyStatusDescription { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string DestinationSnapshot { get { throw null; } }
        public string EncryptionKeySha256 { get { throw null; } }
        public string EncryptionScope { get { throw null; } }
        public Azure.ETag ETag { get { throw null; } }
        public bool IsIncrementalCopy { get { throw null; } }
        public bool IsServerEncrypted { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public Azure.Storage.Blobs.Models.LeaseDurationType LeaseDuration { get { throw null; } }
        public Azure.Storage.Blobs.Models.LeaseState LeaseState { get { throw null; } }
        public Azure.Storage.Blobs.Models.LeaseStatus LeaseStatus { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
    }
    public partial class BlobRequestConditions : Azure.RequestConditions
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
        public static Azure.Storage.Blobs.Models.AccountInfo AccountInfo(Azure.Storage.Blobs.Models.SkuName skuName, Azure.Storage.Blobs.Models.AccountKind accountKind) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlobAppendInfo BlobAppendInfo(Azure.ETag eTag, System.DateTimeOffset lastModified, byte[] contentHash, byte[] contentCrc64, string blobAppendOffset, int blobCommittedBlockCount, bool isServerEncrypted, string encryptionKeySha256) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobAppendInfo BlobAppendInfo(Azure.ETag eTag, System.DateTimeOffset lastModified, byte[] contentHash, byte[] contentCrc64, string blobAppendOffset, int blobCommittedBlockCount, bool isServerEncrypted, string encryptionKeySha256, string encryptionScope) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobBlock BlobBlock(string name, int size) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobContainerAccessPolicy BlobContainerAccessPolicy(Azure.Storage.Blobs.Models.PublicAccessType blobPublicAccess, Azure.ETag eTag, System.DateTimeOffset lastModified, System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.BlobSignedIdentifier> signedIdentifiers) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobContainerInfo BlobContainerInfo(Azure.ETag eTag, System.DateTimeOffset lastModified) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobContainerItem BlobContainerItem(string name, Azure.Storage.Blobs.Models.BlobContainerProperties properties) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobContainerProperties BlobContainerProperties(System.DateTimeOffset lastModified, Azure.ETag eTag, Azure.Storage.Blobs.Models.LeaseState? leaseState = default(Azure.Storage.Blobs.Models.LeaseState?), Azure.Storage.Blobs.Models.LeaseDurationType? leaseDuration = default(Azure.Storage.Blobs.Models.LeaseDurationType?), Azure.Storage.Blobs.Models.PublicAccessType? publicAccess = default(Azure.Storage.Blobs.Models.PublicAccessType?), Azure.Storage.Blobs.Models.LeaseStatus? leaseStatus = default(Azure.Storage.Blobs.Models.LeaseStatus?), bool? hasLegalHold = default(bool?), string defaultEncryptionScope = null, bool? preventEncryptionScopeOverride = default(bool?), System.Collections.Generic.IDictionary<string, string> metadata = null, bool? hasImmutabilityPolicy = default(bool?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlobContainerProperties BlobContainerProperties(System.DateTimeOffset lastModified, Azure.ETag eTag, Azure.Storage.Blobs.Models.LeaseStatus? leaseStatus, Azure.Storage.Blobs.Models.LeaseState? leaseState, Azure.Storage.Blobs.Models.LeaseDurationType? leaseDuration, Azure.Storage.Blobs.Models.PublicAccessType? publicAccess, bool? hasImmutabilityPolicy, bool? hasLegalHold, System.Collections.Generic.IDictionary<string, string> metadata) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlobContentInfo BlobContentInfo(Azure.ETag eTag, System.DateTimeOffset lastModified, byte[] contentHash, string encryptionKeySha256, long blobSequenceNumber) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobContentInfo BlobContentInfo(Azure.ETag eTag, System.DateTimeOffset lastModified, byte[] contentHash, string encryptionKeySha256, string encryptionScope, long blobSequenceNumber) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobCopyInfo BlobCopyInfo(Azure.ETag eTag, System.DateTimeOffset lastModified, string copyId, Azure.Storage.Blobs.Models.CopyStatus copyStatus) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobDownloadInfo BlobDownloadInfo(System.DateTimeOffset lastModified, long blobSequenceNumber, Azure.Storage.Blobs.Models.BlobType blobType, byte[] contentCrc64, string contentLanguage, string copyStatusDescription, string copyId, string copyProgress, System.Uri copySource, Azure.Storage.Blobs.Models.CopyStatus copyStatus, string contentDisposition, Azure.Storage.Blobs.Models.LeaseDurationType leaseDuration, string cacheControl, Azure.Storage.Blobs.Models.LeaseState leaseState, string contentEncoding, Azure.Storage.Blobs.Models.LeaseStatus leaseStatus, byte[] contentHash, string acceptRanges, Azure.ETag eTag, int blobCommittedBlockCount, string contentRange, bool isServerEncrypted, string contentType, string encryptionKeySha256, long contentLength, byte[] blobContentHash, System.Collections.Generic.IDictionary<string, string> metadata, System.IO.Stream content, System.DateTimeOffset copyCompletionTime) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobDownloadInfo BlobDownloadInfo(System.DateTimeOffset lastModified = default(System.DateTimeOffset), long blobSequenceNumber = (long)0, Azure.Storage.Blobs.Models.BlobType blobType = Azure.Storage.Blobs.Models.BlobType.Block, byte[] contentCrc64 = null, string contentLanguage = null, string copyStatusDescription = null, string copyId = null, string copyProgress = null, System.Uri copySource = null, Azure.Storage.Blobs.Models.CopyStatus copyStatus = Azure.Storage.Blobs.Models.CopyStatus.Pending, string contentDisposition = null, Azure.Storage.Blobs.Models.LeaseDurationType leaseDuration = Azure.Storage.Blobs.Models.LeaseDurationType.Infinite, string cacheControl = null, Azure.Storage.Blobs.Models.LeaseState leaseState = Azure.Storage.Blobs.Models.LeaseState.Available, string contentEncoding = null, Azure.Storage.Blobs.Models.LeaseStatus leaseStatus = Azure.Storage.Blobs.Models.LeaseStatus.Locked, byte[] contentHash = null, string acceptRanges = null, Azure.ETag eTag = default(Azure.ETag), int blobCommittedBlockCount = 0, string contentRange = null, bool isServerEncrypted = false, string contentType = null, string encryptionKeySha256 = null, string encryptionScope = null, long contentLength = (long)0, byte[] blobContentHash = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.IO.Stream content = null, System.DateTimeOffset copyCompletionTime = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobGeoReplication BlobGeoReplication(Azure.Storage.Blobs.Models.BlobGeoReplicationStatus status, System.DateTimeOffset? lastSyncedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobHierarchyItem BlobHierarchyItem(string prefix, Azure.Storage.Blobs.Models.BlobItem blob) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobInfo BlobInfo(Azure.ETag eTag, System.DateTimeOffset lastModified) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobItem BlobItem(string name, bool deleted, Azure.Storage.Blobs.Models.BlobItemProperties properties, string snapshot = null, System.Collections.Generic.IDictionary<string, string> metadata = null) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobItemProperties BlobItemProperties(bool accessTierInferred, string copyProgress = null, string contentType = null, string contentEncoding = null, string contentLanguage = null, byte[] contentHash = null, string contentDisposition = null, string cacheControl = null, long? blobSequenceNumber = default(long?), Azure.Storage.Blobs.Models.BlobType? blobType = default(Azure.Storage.Blobs.Models.BlobType?), Azure.Storage.Blobs.Models.LeaseStatus? leaseStatus = default(Azure.Storage.Blobs.Models.LeaseStatus?), Azure.Storage.Blobs.Models.LeaseState? leaseState = default(Azure.Storage.Blobs.Models.LeaseState?), Azure.Storage.Blobs.Models.LeaseDurationType? leaseDuration = default(Azure.Storage.Blobs.Models.LeaseDurationType?), string copyId = null, Azure.Storage.Blobs.Models.CopyStatus? copyStatus = default(Azure.Storage.Blobs.Models.CopyStatus?), System.Uri copySource = null, long? contentLength = default(long?), string copyStatusDescription = null, bool? serverEncrypted = default(bool?), bool? incrementalCopy = default(bool?), string destinationSnapshot = null, int? remainingRetentionDays = default(int?), Azure.Storage.Blobs.Models.AccessTier? accessTier = default(Azure.Storage.Blobs.Models.AccessTier?), System.DateTimeOffset? lastModified = default(System.DateTimeOffset?), Azure.Storage.Blobs.Models.ArchiveStatus? archiveStatus = default(Azure.Storage.Blobs.Models.ArchiveStatus?), string customerProvidedKeySha256 = null, string encryptionScope = null, Azure.ETag? eTag = default(Azure.ETag?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? copyCompletedOn = default(System.DateTimeOffset?), System.DateTimeOffset? deletedOn = default(System.DateTimeOffset?), System.DateTimeOffset? accessTierChangedOn = default(System.DateTimeOffset?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlobItemProperties BlobItemProperties(bool accessTierInferred, System.Uri copySource, string contentType, string contentEncoding, string contentLanguage, byte[] contentHash, string contentDisposition, string cacheControl, long? blobSequenceNumber, Azure.Storage.Blobs.Models.BlobType? blobType, Azure.Storage.Blobs.Models.LeaseStatus? leaseStatus, Azure.Storage.Blobs.Models.LeaseState? leaseState, Azure.Storage.Blobs.Models.LeaseDurationType? leaseDuration, string copyId, Azure.Storage.Blobs.Models.CopyStatus? copyStatus, long? contentLength, string copyProgress, string copyStatusDescription, bool? serverEncrypted, bool? incrementalCopy, string destinationSnapshot, int? remainingRetentionDays, Azure.Storage.Blobs.Models.AccessTier? accessTier, System.DateTimeOffset? lastModified, Azure.Storage.Blobs.Models.ArchiveStatus? archiveStatus, string customerProvidedKeySha256, Azure.ETag? eTag, System.DateTimeOffset? createdOn, System.DateTimeOffset? copyCompletedOn, System.DateTimeOffset? deletedOn, System.DateTimeOffset? accessTierChangedOn) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobLease BlobLease(Azure.ETag eTag, System.DateTimeOffset lastModified, string leaseId) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlobProperties BlobProperties(System.DateTimeOffset lastModified, Azure.Storage.Blobs.Models.LeaseDurationType leaseDuration, Azure.Storage.Blobs.Models.LeaseState leaseState, Azure.Storage.Blobs.Models.LeaseStatus leaseStatus, long contentLength, string destinationSnapshot, Azure.ETag eTag, byte[] contentHash, string contentEncoding, string contentDisposition, string contentLanguage, bool isIncrementalCopy, string cacheControl, Azure.Storage.Blobs.Models.CopyStatus copyStatus, long blobSequenceNumber, System.Uri copySource, string acceptRanges, string copyProgress, int blobCommittedBlockCount, string copyId, bool isServerEncrypted, string copyStatusDescription, string encryptionKeySha256, System.DateTimeOffset copyCompletedOn, string accessTier, Azure.Storage.Blobs.Models.BlobType blobType, bool accessTierInferred, System.Collections.Generic.IDictionary<string, string> metadata, string archiveStatus, System.DateTimeOffset createdOn, System.DateTimeOffset accessTierChangedOn, string contentType) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobProperties BlobProperties(System.DateTimeOffset lastModified, Azure.Storage.Blobs.Models.LeaseState leaseState, Azure.Storage.Blobs.Models.LeaseStatus leaseStatus, long contentLength, Azure.Storage.Blobs.Models.LeaseDurationType leaseDuration, Azure.ETag eTag, byte[] contentHash, string contentEncoding, string contentDisposition, string contentLanguage, string destinationSnapshot, string cacheControl, bool isIncrementalCopy, long blobSequenceNumber, Azure.Storage.Blobs.Models.CopyStatus copyStatus, string acceptRanges, System.Uri copySource, int blobCommittedBlockCount, string copyProgress, bool isServerEncrypted, string copyId, string encryptionKeySha256, string copyStatusDescription, string encryptionScope, System.DateTimeOffset copyCompletedOn, string accessTier, Azure.Storage.Blobs.Models.BlobType blobType, bool accessTierInferred, System.Collections.Generic.IDictionary<string, string> metadata, string archiveStatus, System.DateTimeOffset createdOn, System.DateTimeOffset accessTierChangedOn, string contentType) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobServiceStatistics BlobServiceStatistics(Azure.Storage.Blobs.Models.BlobGeoReplication geoReplication = null) { throw null; }
        public static Azure.Storage.Blobs.Models.BlobSnapshotInfo BlobSnapshotInfo(string snapshot, Azure.ETag eTag, System.DateTimeOffset lastModified, bool isServerEncrypted) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.BlockInfo BlockInfo(byte[] contentHash, byte[] contentCrc64, string encryptionKeySha256) { throw null; }
        public static Azure.Storage.Blobs.Models.BlockInfo BlockInfo(byte[] contentHash, byte[] contentCrc64, string encryptionKeySha256, string encryptionScope) { throw null; }
        public static Azure.Storage.Blobs.Models.BlockList BlockList(System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.BlobBlock> committedBlocks = null, System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.BlobBlock> uncommittedBlocks = null) { throw null; }
        public static Azure.Storage.Blobs.Models.PageBlobInfo PageBlobInfo(Azure.ETag eTag, System.DateTimeOffset lastModified, long blobSequenceNumber) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Blobs.Models.PageInfo PageInfo(Azure.ETag eTag, System.DateTimeOffset lastModified, byte[] contentHash, byte[] contentCrc64, long blobSequenceNumber, string encryptionKeySha256) { throw null; }
        public static Azure.Storage.Blobs.Models.PageInfo PageInfo(Azure.ETag eTag, System.DateTimeOffset lastModified, byte[] contentHash, byte[] contentCrc64, long blobSequenceNumber, string encryptionKeySha256, string encryptionScope) { throw null; }
        public static Azure.Storage.Blobs.Models.PageRangesInfo PageRangesInfo(System.DateTimeOffset lastModified, Azure.ETag eTag, long blobContentLength, System.Collections.Generic.IEnumerable<Azure.HttpRange> pageRanges, System.Collections.Generic.IEnumerable<Azure.HttpRange> clearRanges) { throw null; }
        public static Azure.Storage.Blobs.Models.UserDelegationKey UserDelegationKey(string signedObjectId, string signedTenantId, string signedService, string signedVersion, string value, System.DateTimeOffset signedExpiresOn, System.DateTimeOffset signedStartsOn) { throw null; }
    }
    public partial class BlobSnapshotInfo
    {
        internal BlobSnapshotInfo() { }
        public Azure.ETag ETag { get { throw null; } }
        public bool IsServerEncrypted { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public string Snapshot { get { throw null; } }
    }
    [System.FlagsAttribute]
    public enum BlobStates
    {
        All = -1,
        None = 0,
        Snapshots = 1,
        Uncommitted = 2,
        Deleted = 4,
    }
    public partial class BlobStaticWebsite
    {
        public BlobStaticWebsite() { }
        public bool Enabled { get { throw null; } set { } }
        public string ErrorDocument404Path { get { throw null; } set { } }
        public string IndexDocument { get { throw null; } set { } }
    }
    [System.FlagsAttribute]
    public enum BlobTraits
    {
        All = -1,
        None = 0,
        CopyStatus = 1,
        Metadata = 2,
    }
    public enum BlobType
    {
        Block = 0,
        Page = 1,
        Append = 2,
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
    public partial class PageBlobInfo
    {
        internal PageBlobInfo() { }
        public long BlobSequenceNumber { get { throw null; } }
        public Azure.ETag ETag { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
    }
    public partial class PageBlobRequestConditions : Azure.Storage.Blobs.Models.BlobRequestConditions
    {
        public PageBlobRequestConditions() { }
        public long? IfSequenceNumberEqual { get { throw null; } set { } }
        public long? IfSequenceNumberLessThan { get { throw null; } set { } }
        public long? IfSequenceNumberLessThanOrEqual { get { throw null; } set { } }
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
        public AppendBlobClient(System.Uri blobUri, Azure.Core.TokenCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public AppendBlobClient(System.Uri blobUri, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public AppendBlobClient(System.Uri blobUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public virtual int AppendBlobMaxAppendBlockBytes { get { throw null; } }
        public virtual int AppendBlobMaxBlocks { get { throw null; } }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobAppendInfo> AppendBlock(System.IO.Stream content, byte[] transactionalContentHash = null, Azure.Storage.Blobs.Models.AppendBlobRequestConditions conditions = null, System.IProgress<long> progressHandler = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobAppendInfo>> AppendBlockAsync(System.IO.Stream content, byte[] transactionalContentHash = null, Azure.Storage.Blobs.Models.AppendBlobRequestConditions conditions = null, System.IProgress<long> progressHandler = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobAppendInfo> AppendBlockFromUri(System.Uri sourceUri, Azure.HttpRange sourceRange = default(Azure.HttpRange), byte[] sourceContentHash = null, Azure.Storage.Blobs.Models.AppendBlobRequestConditions conditions = null, Azure.Storage.Blobs.Models.AppendBlobRequestConditions sourceConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobAppendInfo>> AppendBlockFromUriAsync(System.Uri sourceUri, Azure.HttpRange sourceRange = default(Azure.HttpRange), byte[] sourceContentHash = null, Azure.Storage.Blobs.Models.AppendBlobRequestConditions conditions = null, Azure.Storage.Blobs.Models.AppendBlobRequestConditions sourceConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> Create(Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.AppendBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> CreateAsync(Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.AppendBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> CreateIfNotExists(Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> CreateIfNotExistsAsync(Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public new Azure.Storage.Blobs.Specialized.AppendBlobClient WithSnapshot(string snapshot) { throw null; }
    }
    public partial class BlobBaseClient
    {
        protected BlobBaseClient() { }
        public BlobBaseClient(string connectionString, string blobContainerName, string blobName) { }
        public BlobBaseClient(string connectionString, string blobContainerName, string blobName, Azure.Storage.Blobs.BlobClientOptions options) { }
        public BlobBaseClient(System.Uri blobUri, Azure.Core.TokenCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public BlobBaseClient(System.Uri blobUri, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public BlobBaseClient(System.Uri blobUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public virtual string AccountName { get { throw null; } }
        public virtual string BlobContainerName { get { throw null; } }
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
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobDownloadInfo> Download() { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobDownloadInfo> Download(Azure.HttpRange range = default(Azure.HttpRange), Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, bool rangeGetContentHash = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobDownloadInfo> Download(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobDownloadInfo>> DownloadAsync() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobDownloadInfo>> DownloadAsync(Azure.HttpRange range = default(Azure.HttpRange), Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, bool rangeGetContentHash = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobDownloadInfo>> DownloadAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response DownloadTo(System.IO.Stream destination) { throw null; }
        public virtual Azure.Response DownloadTo(System.IO.Stream destination, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, Azure.Storage.StorageTransferOptions transferOptions = default(Azure.Storage.StorageTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadTo(System.IO.Stream destination, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response DownloadTo(string path) { throw null; }
        public virtual Azure.Response DownloadTo(string path, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, Azure.Storage.StorageTransferOptions transferOptions = default(Azure.Storage.StorageTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadTo(string path, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadToAsync(System.IO.Stream destination) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadToAsync(System.IO.Stream destination, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, Azure.Storage.StorageTransferOptions transferOptions = default(Azure.Storage.StorageTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadToAsync(System.IO.Stream destination, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadToAsync(string path) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadToAsync(string path, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, Azure.Storage.StorageTransferOptions transferOptions = default(Azure.Storage.StorageTransferOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadToAsync(string path, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<bool> Exists(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobProperties> GetProperties(Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobProperties>> GetPropertiesAsync(Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetAccessTier(Azure.Storage.Blobs.Models.AccessTier accessTier, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, Azure.Storage.Blobs.Models.RehydratePriority? rehydratePriority = default(Azure.Storage.Blobs.Models.RehydratePriority?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetAccessTierAsync(Azure.Storage.Blobs.Models.AccessTier accessTier, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, Azure.Storage.Blobs.Models.RehydratePriority? rehydratePriority = default(Azure.Storage.Blobs.Models.RehydratePriority?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobInfo> SetHttpHeaders(Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobInfo>> SetHttpHeadersAsync(Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobInfo> SetMetadata(System.Collections.Generic.IDictionary<string, string> metadata, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobInfo>> SetMetadataAsync(System.Collections.Generic.IDictionary<string, string> metadata, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Storage.Blobs.Models.CopyFromUriOperation StartCopyFromUri(System.Uri source, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.AccessTier? accessTier = default(Azure.Storage.Blobs.Models.AccessTier?), Azure.Storage.Blobs.Models.BlobRequestConditions sourceConditions = null, Azure.Storage.Blobs.Models.BlobRequestConditions destinationConditions = null, Azure.Storage.Blobs.Models.RehydratePriority? rehydratePriority = default(Azure.Storage.Blobs.Models.RehydratePriority?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Storage.Blobs.Models.CopyFromUriOperation> StartCopyFromUriAsync(System.Uri source, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.AccessTier? accessTier = default(Azure.Storage.Blobs.Models.AccessTier?), Azure.Storage.Blobs.Models.BlobRequestConditions sourceConditions = null, Azure.Storage.Blobs.Models.BlobRequestConditions destinationConditions = null, Azure.Storage.Blobs.Models.RehydratePriority? rehydratePriority = default(Azure.Storage.Blobs.Models.RehydratePriority?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Undelete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UndeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Storage.Blobs.Specialized.BlobBaseClient WithSnapshot(string snapshot) { throw null; }
        protected virtual Azure.Storage.Blobs.Specialized.BlobBaseClient WithSnapshotCore(string snapshot) { throw null; }
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
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobLease> Acquire(System.TimeSpan duration, Azure.RequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public BlockBlobClient(System.Uri blobUri, Azure.Core.TokenCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public BlockBlobClient(System.Uri blobUri, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public BlockBlobClient(System.Uri blobUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public virtual int BlockBlobMaxBlocks { get { throw null; } }
        public virtual int BlockBlobMaxStageBlockBytes { get { throw null; } }
        public virtual int BlockBlobMaxUploadBlobBytes { get { throw null; } }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> CommitBlockList(System.Collections.Generic.IEnumerable<string> base64BlockIds, Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, Azure.Storage.Blobs.Models.AccessTier? accessTier = default(Azure.Storage.Blobs.Models.AccessTier?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> CommitBlockListAsync(System.Collections.Generic.IEnumerable<string> base64BlockIds, Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, Azure.Storage.Blobs.Models.AccessTier? accessTier = default(Azure.Storage.Blobs.Models.AccessTier?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected static Azure.Storage.Blobs.Specialized.BlockBlobClient CreateClient(System.Uri blobUri, Azure.Storage.Blobs.BlobClientOptions options, Azure.Core.Pipeline.HttpPipeline pipeline) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlockList> GetBlockList(Azure.Storage.Blobs.Models.BlockListTypes blockListTypes = Azure.Storage.Blobs.Models.BlockListTypes.All, string snapshot = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlockList>> GetBlockListAsync(Azure.Storage.Blobs.Models.BlockListTypes blockListTypes = Azure.Storage.Blobs.Models.BlockListTypes.All, string snapshot = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlockInfo> StageBlock(string base64BlockId, System.IO.Stream content, byte[] transactionalContentHash = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.IProgress<long> progressHandler = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlockInfo>> StageBlockAsync(string base64BlockId, System.IO.Stream content, byte[] transactionalContentHash = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.IProgress<long> progressHandler = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlockInfo> StageBlockFromUri(System.Uri sourceUri, string base64BlockId, Azure.HttpRange sourceRange = default(Azure.HttpRange), byte[] sourceContentHash = null, Azure.RequestConditions sourceConditions = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlockInfo>> StageBlockFromUriAsync(System.Uri sourceUri, string base64BlockId, Azure.HttpRange sourceRange = default(Azure.HttpRange), byte[] sourceContentHash = null, Azure.RequestConditions sourceConditions = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> Upload(System.IO.Stream content, Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, Azure.Storage.Blobs.Models.AccessTier? accessTier = default(Azure.Storage.Blobs.Models.AccessTier?), System.IProgress<long> progressHandler = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> UploadAsync(System.IO.Stream content, Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null, Azure.Storage.Blobs.Models.AccessTier? accessTier = default(Azure.Storage.Blobs.Models.AccessTier?), System.IProgress<long> progressHandler = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public new Azure.Storage.Blobs.Specialized.BlockBlobClient WithSnapshot(string snapshot) { throw null; }
        protected sealed override Azure.Storage.Blobs.Specialized.BlobBaseClient WithSnapshotCore(string snapshot) { throw null; }
    }
    public partial class PageBlobClient : Azure.Storage.Blobs.Specialized.BlobBaseClient
    {
        protected PageBlobClient() { }
        public PageBlobClient(string connectionString, string blobContainerName, string blobName) { }
        public PageBlobClient(string connectionString, string blobContainerName, string blobName, Azure.Storage.Blobs.BlobClientOptions options) { }
        public PageBlobClient(System.Uri blobUri, Azure.Core.TokenCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public PageBlobClient(System.Uri blobUri, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public PageBlobClient(System.Uri blobUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public virtual int PageBlobMaxUploadPagesBytes { get { throw null; } }
        public virtual int PageBlobPageBytes { get { throw null; } }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.PageInfo> ClearPages(Azure.HttpRange range, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.PageInfo>> ClearPagesAsync(Azure.HttpRange range, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> Create(long size, long? sequenceNumber = default(long?), Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> CreateAsync(long size, long? sequenceNumber = default(long?), Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo> CreateIfNotExists(long size, long? sequenceNumber = default(long?), Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.BlobContentInfo>> CreateIfNotExistsAsync(long size, long? sequenceNumber = default(long?), Azure.Storage.Blobs.Models.BlobHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.PageRangesInfo> GetManagedDiskPageRangesDiff(Azure.HttpRange? range = default(Azure.HttpRange?), string snapshot = null, System.Uri previousSnapshotUri = null, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.PageRangesInfo>> GetManagedDiskPageRangesDiffAsync(Azure.HttpRange? range = default(Azure.HttpRange?), string snapshot = null, System.Uri previousSnapshotUri = null, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.PageRangesInfo> GetPageRanges(Azure.HttpRange? range = default(Azure.HttpRange?), string snapshot = null, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.PageRangesInfo>> GetPageRangesAsync(Azure.HttpRange? range = default(Azure.HttpRange?), string snapshot = null, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.PageRangesInfo> GetPageRangesDiff(Azure.HttpRange? range = default(Azure.HttpRange?), string snapshot = null, string previousSnapshot = null, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.PageRangesInfo>> GetPageRangesDiffAsync(Azure.HttpRange? range = default(Azure.HttpRange?), string snapshot = null, string previousSnapshot = null, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.PageBlobInfo> Resize(long size, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.PageBlobInfo>> ResizeAsync(long size, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Storage.Blobs.Models.CopyFromUriOperation StartCopyIncremental(System.Uri sourceUri, string snapshot, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Storage.Blobs.Models.CopyFromUriOperation> StartCopyIncrementalAsync(System.Uri sourceUri, string snapshot, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.PageBlobInfo> UpdateSequenceNumber(Azure.Storage.Blobs.Models.SequenceNumberAction action, long? sequenceNumber = default(long?), Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.PageBlobInfo>> UpdateSequenceNumberAsync(Azure.Storage.Blobs.Models.SequenceNumberAction action, long? sequenceNumber = default(long?), Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.PageInfo> UploadPages(System.IO.Stream content, long offset, byte[] transactionalContentHash = null, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.IProgress<long> progressHandler = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.PageInfo>> UploadPagesAsync(System.IO.Stream content, long offset, byte[] transactionalContentHash = null, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, System.IProgress<long> progressHandler = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Blobs.Models.PageInfo> UploadPagesFromUri(System.Uri sourceUri, Azure.HttpRange sourceRange, Azure.HttpRange range, byte[] sourceContentHash = null, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, Azure.Storage.Blobs.Models.PageBlobRequestConditions sourceConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Blobs.Models.PageInfo>> UploadPagesFromUriAsync(System.Uri sourceUri, Azure.HttpRange sourceRange, Azure.HttpRange range, byte[] sourceContentHash = null, Azure.Storage.Blobs.Models.PageBlobRequestConditions conditions = null, Azure.Storage.Blobs.Models.PageBlobRequestConditions sourceConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public new Azure.Storage.Blobs.Specialized.PageBlobClient WithSnapshot(string snapshot) { throw null; }
        protected sealed override Azure.Storage.Blobs.Specialized.BlobBaseClient WithSnapshotCore(string snapshot) { throw null; }
    }
    public static partial class SpecializedBlobExtensions
    {
        public static Azure.Storage.Blobs.Specialized.AppendBlobClient GetAppendBlobClient(this Azure.Storage.Blobs.BlobContainerClient client, string blobName) { throw null; }
        public static Azure.Storage.Blobs.Specialized.BlobBaseClient GetBlobBaseClient(this Azure.Storage.Blobs.BlobContainerClient client, string blobName) { throw null; }
        public static Azure.Storage.Blobs.Specialized.BlobLeaseClient GetBlobLeaseClient(this Azure.Storage.Blobs.BlobContainerClient client, string leaseId = null) { throw null; }
        public static Azure.Storage.Blobs.Specialized.BlobLeaseClient GetBlobLeaseClient(this Azure.Storage.Blobs.Specialized.BlobBaseClient client, string leaseId = null) { throw null; }
        public static Azure.Storage.Blobs.Specialized.BlockBlobClient GetBlockBlobClient(this Azure.Storage.Blobs.BlobContainerClient client, string blobName) { throw null; }
        public static Azure.Storage.Blobs.Specialized.PageBlobClient GetPageBlobClient(this Azure.Storage.Blobs.BlobContainerClient client, string blobName) { throw null; }
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
    }
    public partial class BlobSasBuilder
    {
        public BlobSasBuilder() { }
        public string BlobContainerName { get { throw null; } set { } }
        public string BlobName { get { throw null; } set { } }
        public string CacheControl { get { throw null; } set { } }
        public string ContentDisposition { get { throw null; } set { } }
        public string ContentEncoding { get { throw null; } set { } }
        public string ContentLanguage { get { throw null; } set { } }
        public string ContentType { get { throw null; } set { } }
        public System.DateTimeOffset ExpiresOn { get { throw null; } set { } }
        public string Identifier { get { throw null; } set { } }
        public Azure.Storage.Sas.SasIPRange IPRange { get { throw null; } set { } }
        public string Permissions { get { throw null; } }
        public Azure.Storage.Sas.SasProtocol Protocol { get { throw null; } set { } }
        public string Resource { get { throw null; } set { } }
        public string Snapshot { get { throw null; } set { } }
        public System.DateTimeOffset StartsOn { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public void SetPermissions(Azure.Storage.Sas.BlobAccountSasPermissions permissions) { }
        public void SetPermissions(Azure.Storage.Sas.BlobContainerSasPermissions permissions) { }
        public void SetPermissions(Azure.Storage.Sas.BlobSasPermissions permissions) { }
        public void SetPermissions(Azure.Storage.Sas.SnapshotSasPermissions permissions) { }
        public void SetPermissions(string rawPermissions) { }
        public Azure.Storage.Sas.BlobSasQueryParameters ToSasQueryParameters(Azure.Storage.Blobs.Models.UserDelegationKey userDelegationKey, string accountName) { throw null; }
        public Azure.Storage.Sas.BlobSasQueryParameters ToSasQueryParameters(Azure.Storage.StorageSharedKeyCredential sharedKeyCredential) { throw null; }
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
    public enum SnapshotSasPermissions
    {
        All = -1,
        Read = 1,
        Write = 2,
        Delete = 4,
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class BlobClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Storage.Blobs.BlobServiceClient, Azure.Storage.Blobs.BlobClientOptions> AddBlobServiceClient<TBuilder>(this TBuilder builder, string connectionString) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Storage.Blobs.BlobServiceClient, Azure.Storage.Blobs.BlobClientOptions> AddBlobServiceClient<TBuilder>(this TBuilder builder, System.Uri serviceUri) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Storage.Blobs.BlobServiceClient, Azure.Storage.Blobs.BlobClientOptions> AddBlobServiceClient<TBuilder>(this TBuilder builder, System.Uri serviceUri, Azure.Storage.StorageSharedKeyCredential sharedKeyCredential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Storage.Blobs.BlobServiceClient, Azure.Storage.Blobs.BlobClientOptions> AddBlobServiceClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
