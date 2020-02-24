namespace Azure.Storage.Files.Shares
{
    public partial class ShareClient
    {
        protected ShareClient() { }
        public ShareClient(string connectionString, string shareName) { }
        public ShareClient(string connectionString, string shareName, Azure.Storage.Files.Shares.ShareClientOptions options) { }
        public ShareClient(System.Uri shareUri, Azure.Storage.Files.Shares.ShareClientOptions options = null) { }
        public ShareClient(System.Uri shareUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Files.Shares.ShareClientOptions options = null) { }
        public virtual string AccountName { get { throw null; } }
        public virtual string Name { get { throw null; } }
        public virtual System.Uri Uri { get { throw null; } }
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareInfo> Create(System.Collections.Generic.IDictionary<string, string> metadata = null, int? quotaInGB = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareInfo>> CreateAsync(System.Collections.Generic.IDictionary<string, string> metadata = null, int? quotaInGB = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.Shares.ShareDirectoryClient> CreateDirectory(string directoryName, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Files.Shares.Models.FileSmbProperties smbProperties = null, string filePermission = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.ShareDirectoryClient>> CreateDirectoryAsync(string directoryName, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Files.Shares.Models.FileSmbProperties smbProperties = null, string filePermission = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareInfo> CreateIfNotExists(System.Collections.Generic.IDictionary<string, string> metadata = null, int? quotaInGB = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareInfo>> CreateIfNotExistsAsync(System.Collections.Generic.IDictionary<string, string> metadata = null, int? quotaInGB = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.PermissionInfo> CreatePermission(string permission, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.PermissionInfo>> CreatePermissionAsync(string permission, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareSnapshotInfo> CreateSnapshot(System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareSnapshotInfo>> CreateSnapshotAsync(System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(bool includeSnapshots = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(bool includeSnapshots = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteDirectory(string directoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDirectoryAsync(string directoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> DeleteIfExists(bool includeSnapshots = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> DeleteIfExistsAsync(bool includeSnapshots = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IEnumerable<Azure.Storage.Files.Shares.Models.ShareSignedIdentifier>> GetAccessPolicy(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IEnumerable<Azure.Storage.Files.Shares.Models.ShareSignedIdentifier>>> GetAccessPolicyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Storage.Files.Shares.ShareDirectoryClient GetDirectoryClient(string directoryName) { throw null; }
        public virtual Azure.Response<string> GetPermission(string filePermissionKey = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> GetPermissionAsync(string filePermissionKey = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareProperties> GetProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareProperties>> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Storage.Files.Shares.ShareDirectoryClient GetRootDirectoryClient() { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareStatistics> GetStatistics(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareStatistics>> GetStatisticsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareInfo> SetAccessPolicy(System.Collections.Generic.IEnumerable<Azure.Storage.Files.Shares.Models.ShareSignedIdentifier> permissions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareInfo>> SetAccessPolicyAsync(System.Collections.Generic.IEnumerable<Azure.Storage.Files.Shares.Models.ShareSignedIdentifier> permissions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareInfo> SetMetadata(System.Collections.Generic.IDictionary<string, string> metadata, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareInfo>> SetMetadataAsync(System.Collections.Generic.IDictionary<string, string> metadata, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareInfo> SetQuota(int quotaInGB = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareInfo>> SetQuotaAsync(int quotaInGB = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Storage.Files.Shares.ShareClient WithSnapshot(string snapshot) { throw null; }
    }
    public partial class ShareClientOptions : Azure.Core.ClientOptions
    {
        public ShareClientOptions(Azure.Storage.Files.Shares.ShareClientOptions.ServiceVersion version = Azure.Storage.Files.Shares.ShareClientOptions.ServiceVersion.V2019_07_07) { }
        public Azure.Storage.Files.Shares.ShareClientOptions.ServiceVersion Version { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public enum ServiceVersion
        {
            V2019_02_02 = 1,
            V2019_07_07 = 2,
        }
    }
    public partial class ShareDirectoryClient
    {
        protected ShareDirectoryClient() { }
        public ShareDirectoryClient(string connectionString, string shareName, string directoryPath) { }
        public ShareDirectoryClient(string connectionString, string shareName, string directoryPath, Azure.Storage.Files.Shares.ShareClientOptions options) { }
        public ShareDirectoryClient(System.Uri directoryUri, Azure.Storage.Files.Shares.ShareClientOptions options = null) { }
        public ShareDirectoryClient(System.Uri directoryUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Files.Shares.ShareClientOptions options = null) { }
        public virtual string AccountName { get { throw null; } }
        public virtual string Name { get { throw null; } }
        public virtual string Path { get { throw null; } }
        public virtual string ShareName { get { throw null; } }
        public virtual System.Uri Uri { get { throw null; } }
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareDirectoryInfo> Create(System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Files.Shares.Models.FileSmbProperties smbProperties = null, string filePermission = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareDirectoryInfo>> CreateAsync(System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Files.Shares.Models.FileSmbProperties smbProperties = null, string filePermission = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.Shares.ShareFileClient> CreateFile(string fileName, long maxSize, Azure.Storage.Files.Shares.Models.ShareFileHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Files.Shares.Models.FileSmbProperties smbProperties = null, string filePermission = null, Azure.Storage.Files.Shares.Models.ShareFileRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Files.Shares.ShareFileClient> CreateFile(string fileName, long maxSize, Azure.Storage.Files.Shares.Models.ShareFileHttpHeaders httpHeaders, System.Collections.Generic.IDictionary<string, string> metadata, Azure.Storage.Files.Shares.Models.FileSmbProperties smbProperties, string filePermission, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.ShareFileClient>> CreateFileAsync(string fileName, long maxSize, Azure.Storage.Files.Shares.Models.ShareFileHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Files.Shares.Models.FileSmbProperties smbProperties = null, string filePermission = null, Azure.Storage.Files.Shares.Models.ShareFileRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.ShareFileClient>> CreateFileAsync(string fileName, long maxSize, Azure.Storage.Files.Shares.Models.ShareFileHttpHeaders httpHeaders, System.Collections.Generic.IDictionary<string, string> metadata, Azure.Storage.Files.Shares.Models.FileSmbProperties smbProperties, string filePermission, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareDirectoryInfo> CreateIfNotExists(System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Files.Shares.Models.FileSmbProperties smbProperties = null, string filePermission = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareDirectoryInfo>> CreateIfNotExistsAsync(System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Files.Shares.Models.FileSmbProperties smbProperties = null, string filePermission = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.Shares.ShareDirectoryClient> CreateSubdirectory(string subdirectoryName, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Files.Shares.Models.FileSmbProperties smbProperties = null, string filePermission = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.ShareDirectoryClient>> CreateSubdirectoryAsync(string subdirectoryName, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Files.Shares.Models.FileSmbProperties smbProperties = null, string filePermission = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteFile(string fileName, Azure.Storage.Files.Shares.Models.ShareFileRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response DeleteFile(string fileName, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteFileAsync(string fileName, Azure.Storage.Files.Shares.Models.ShareFileRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteFileAsync(string fileName, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<bool> DeleteIfExists(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> DeleteIfExistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteSubdirectory(string subdirectoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSubdirectoryAsync(string subdirectoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Storage.Files.Shares.Models.CloseHandlesResult ForceCloseAllHandles(bool? recursive = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Storage.Files.Shares.Models.CloseHandlesResult> ForceCloseAllHandlesAsync(bool? recursive = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.CloseHandlesResult> ForceCloseHandle(string handleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.CloseHandlesResult>> ForceCloseHandleAsync(string handleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Storage.Files.Shares.ShareFileClient GetFileClient(string fileName) { throw null; }
        public virtual Azure.Pageable<Azure.Storage.Files.Shares.Models.ShareFileItem> GetFilesAndDirectories(string prefix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Files.Shares.Models.ShareFileItem> GetFilesAndDirectoriesAsync(string prefix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Storage.Files.Shares.Models.ShareFileHandle> GetHandles(bool? recursive = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Files.Shares.Models.ShareFileHandle> GetHandlesAsync(bool? recursive = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareDirectoryProperties> GetProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareDirectoryProperties>> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Storage.Files.Shares.ShareDirectoryClient GetSubdirectoryClient(string subdirectoryName) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareDirectoryInfo> SetHttpHeaders(Azure.Storage.Files.Shares.Models.FileSmbProperties smbProperties = null, string filePermission = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareDirectoryInfo>> SetHttpHeadersAsync(Azure.Storage.Files.Shares.Models.FileSmbProperties smbProperties = null, string filePermission = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareDirectoryInfo> SetMetadata(System.Collections.Generic.IDictionary<string, string> metadata, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareDirectoryInfo>> SetMetadataAsync(System.Collections.Generic.IDictionary<string, string> metadata, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Storage.Files.Shares.ShareDirectoryClient WithSnapshot(string snapshot) { throw null; }
    }
    public partial class ShareFileClient
    {
        protected ShareFileClient() { }
        public ShareFileClient(string connectionString, string shareName, string filePath) { }
        public ShareFileClient(string connectionString, string shareName, string filePath, Azure.Storage.Files.Shares.ShareClientOptions options) { }
        public ShareFileClient(System.Uri fileUri, Azure.Storage.Files.Shares.ShareClientOptions options = null) { }
        public ShareFileClient(System.Uri fileUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Files.Shares.ShareClientOptions options = null) { }
        public virtual string AccountName { get { throw null; } }
        public virtual string Name { get { throw null; } }
        public virtual string Path { get { throw null; } }
        public virtual string ShareName { get { throw null; } }
        public virtual System.Uri Uri { get { throw null; } }
        public virtual Azure.Response AbortCopy(string copyId, Azure.Storage.Files.Shares.Models.ShareFileRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response AbortCopy(string copyId, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AbortCopyAsync(string copyId, Azure.Storage.Files.Shares.Models.ShareFileRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response> AbortCopyAsync(string copyId, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileUploadInfo> ClearRange(Azure.HttpRange range, Azure.Storage.Files.Shares.Models.ShareFileRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileUploadInfo>> ClearRangeAsync(Azure.HttpRange range, Azure.Storage.Files.Shares.Models.ShareFileRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileInfo> Create(long maxSize, Azure.Storage.Files.Shares.Models.ShareFileHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Files.Shares.Models.FileSmbProperties smbProperties = null, string filePermission = null, Azure.Storage.Files.Shares.Models.ShareFileRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileInfo> Create(long maxSize, Azure.Storage.Files.Shares.Models.ShareFileHttpHeaders httpHeaders, System.Collections.Generic.IDictionary<string, string> metadata, Azure.Storage.Files.Shares.Models.FileSmbProperties smbProperties, string filePermission, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileInfo>> CreateAsync(long maxSize, Azure.Storage.Files.Shares.Models.ShareFileHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Files.Shares.Models.FileSmbProperties smbProperties = null, string filePermission = null, Azure.Storage.Files.Shares.Models.ShareFileRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileInfo>> CreateAsync(long maxSize, Azure.Storage.Files.Shares.Models.ShareFileHttpHeaders httpHeaders, System.Collections.Generic.IDictionary<string, string> metadata, Azure.Storage.Files.Shares.Models.FileSmbProperties smbProperties, string filePermission, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response Delete(Azure.Storage.Files.Shares.Models.ShareFileRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response Delete(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(Azure.Storage.Files.Shares.Models.ShareFileRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<bool> DeleteIfExists(Azure.Storage.Files.Shares.Models.ShareFileRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> DeleteIfExistsAsync(Azure.Storage.Files.Shares.Models.ShareFileRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileDownloadInfo> Download(Azure.HttpRange range = default(Azure.HttpRange), bool rangeGetContentHash = false, Azure.Storage.Files.Shares.Models.ShareFileRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileDownloadInfo> Download(Azure.HttpRange range, bool rangeGetContentHash, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileDownloadInfo>> DownloadAsync(Azure.HttpRange range = default(Azure.HttpRange), bool rangeGetContentHash = false, Azure.Storage.Files.Shares.Models.ShareFileRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileDownloadInfo>> DownloadAsync(Azure.HttpRange range, bool rangeGetContentHash, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<bool> Exists(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Storage.Files.Shares.Models.CloseHandlesResult ForceCloseAllHandles(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Storage.Files.Shares.Models.CloseHandlesResult> ForceCloseAllHandlesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.CloseHandlesResult> ForceCloseHandle(string handleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.CloseHandlesResult>> ForceCloseHandleAsync(string handleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Storage.Files.Shares.Models.ShareFileHandle> GetHandles(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Files.Shares.Models.ShareFileHandle> GetHandlesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileProperties> GetProperties(Azure.Storage.Files.Shares.Models.ShareFileRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileProperties> GetProperties(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileProperties>> GetPropertiesAsync(Azure.Storage.Files.Shares.Models.ShareFileRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileProperties>> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileRangeInfo> GetRangeList(Azure.HttpRange range, Azure.Storage.Files.Shares.Models.ShareFileRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileRangeInfo> GetRangeList(Azure.HttpRange range, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileRangeInfo>> GetRangeListAsync(Azure.HttpRange range, Azure.Storage.Files.Shares.Models.ShareFileRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileRangeInfo>> GetRangeListAsync(Azure.HttpRange range, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileInfo> SetHttpHeaders(long? newSize = default(long?), Azure.Storage.Files.Shares.Models.ShareFileHttpHeaders httpHeaders = null, Azure.Storage.Files.Shares.Models.FileSmbProperties smbProperties = null, string filePermission = null, Azure.Storage.Files.Shares.Models.ShareFileRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileInfo> SetHttpHeaders(long? newSize, Azure.Storage.Files.Shares.Models.ShareFileHttpHeaders httpHeaders, Azure.Storage.Files.Shares.Models.FileSmbProperties smbProperties, string filePermission, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileInfo>> SetHttpHeadersAsync(long? newSize = default(long?), Azure.Storage.Files.Shares.Models.ShareFileHttpHeaders httpHeaders = null, Azure.Storage.Files.Shares.Models.FileSmbProperties smbProperties = null, string filePermission = null, Azure.Storage.Files.Shares.Models.ShareFileRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileInfo>> SetHttpHeadersAsync(long? newSize, Azure.Storage.Files.Shares.Models.ShareFileHttpHeaders httpHeaders, Azure.Storage.Files.Shares.Models.FileSmbProperties smbProperties, string filePermission, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileInfo> SetMetadata(System.Collections.Generic.IDictionary<string, string> metadata, Azure.Storage.Files.Shares.Models.ShareFileRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileInfo> SetMetadata(System.Collections.Generic.IDictionary<string, string> metadata, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileInfo>> SetMetadataAsync(System.Collections.Generic.IDictionary<string, string> metadata, Azure.Storage.Files.Shares.Models.ShareFileRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileInfo>> SetMetadataAsync(System.Collections.Generic.IDictionary<string, string> metadata, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileCopyInfo> StartCopy(System.Uri sourceUri, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Files.Shares.Models.FileSmbProperties smbProperties = null, string filePermission = null, Azure.Storage.Files.Shares.Models.PermissionCopyMode? filePermissionCopyMode = default(Azure.Storage.Files.Shares.Models.PermissionCopyMode?), bool? ignoreReadOnly = default(bool?), bool? setArchiveAttribute = default(bool?), Azure.Storage.Files.Shares.Models.ShareFileRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileCopyInfo> StartCopy(System.Uri sourceUri, System.Collections.Generic.IDictionary<string, string> metadata, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileCopyInfo>> StartCopyAsync(System.Uri sourceUri, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.Storage.Files.Shares.Models.FileSmbProperties smbProperties = null, string filePermission = null, Azure.Storage.Files.Shares.Models.PermissionCopyMode? filePermissionCopyMode = default(Azure.Storage.Files.Shares.Models.PermissionCopyMode?), bool? ignoreReadOnly = default(bool?), bool? setArchiveAttribute = default(bool?), Azure.Storage.Files.Shares.Models.ShareFileRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileCopyInfo>> StartCopyAsync(System.Uri sourceUri, System.Collections.Generic.IDictionary<string, string> metadata, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileUploadInfo> Upload(System.IO.Stream content, System.IProgress<long> progressHandler = null, Azure.Storage.Files.Shares.Models.ShareFileRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileUploadInfo> Upload(System.IO.Stream content, System.IProgress<long> progressHandler, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileUploadInfo>> UploadAsync(System.IO.Stream content, System.IProgress<long> progressHandler = null, Azure.Storage.Files.Shares.Models.ShareFileRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileUploadInfo>> UploadAsync(System.IO.Stream content, System.IProgress<long> progressHandler, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileUploadInfo> UploadRange(Azure.HttpRange range, System.IO.Stream content, byte[] transactionalContentHash = null, System.IProgress<long> progressHandler = null, Azure.Storage.Files.Shares.Models.ShareFileRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileUploadInfo> UploadRange(Azure.Storage.Files.Shares.Models.ShareFileRangeWriteType writeType, Azure.HttpRange range, System.IO.Stream content, byte[] transactionalContentHash = null, System.IProgress<long> progressHandler = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileUploadInfo>> UploadRangeAsync(Azure.HttpRange range, System.IO.Stream content, byte[] transactionalContentHash = null, System.IProgress<long> progressHandler = null, Azure.Storage.Files.Shares.Models.ShareFileRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileUploadInfo>> UploadRangeAsync(Azure.Storage.Files.Shares.Models.ShareFileRangeWriteType writeType, Azure.HttpRange range, System.IO.Stream content, byte[] transactionalContentHash = null, System.IProgress<long> progressHandler = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileUploadInfo> UploadRangeFromUri(System.Uri sourceUri, Azure.HttpRange range, Azure.HttpRange sourceRange, Azure.Storage.Files.Shares.Models.ShareFileRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileUploadInfo> UploadRangeFromUri(System.Uri sourceUri, Azure.HttpRange range, Azure.HttpRange sourceRange, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileUploadInfo>> UploadRangeFromUriAsync(System.Uri sourceUri, Azure.HttpRange range, Azure.HttpRange sourceRange, Azure.Storage.Files.Shares.Models.ShareFileRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileUploadInfo>> UploadRangeFromUriAsync(System.Uri sourceUri, Azure.HttpRange range, Azure.HttpRange sourceRange, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Storage.Files.Shares.ShareFileClient WithSnapshot(string shareSnapshot) { throw null; }
    }
    public partial class ShareServiceClient
    {
        protected ShareServiceClient() { }
        public ShareServiceClient(string connectionString) { }
        public ShareServiceClient(string connectionString, Azure.Storage.Files.Shares.ShareClientOptions options) { }
        public ShareServiceClient(System.Uri serviceUri, Azure.Storage.Files.Shares.ShareClientOptions options = null) { }
        public ShareServiceClient(System.Uri serviceUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Files.Shares.ShareClientOptions options = null) { }
        public virtual string AccountName { get { throw null; } }
        public virtual System.Uri Uri { get { throw null; } }
        public virtual Azure.Response<Azure.Storage.Files.Shares.ShareClient> CreateShare(string shareName, System.Collections.Generic.IDictionary<string, string> metadata = null, int? quotaInGB = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.ShareClient>> CreateShareAsync(string shareName, System.Collections.Generic.IDictionary<string, string> metadata = null, int? quotaInGB = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteShare(string shareName, bool includeSnapshots = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteShareAsync(string shareName, bool includeSnapshots = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareServiceProperties> GetProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareServiceProperties>> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Storage.Files.Shares.ShareClient GetShareClient(string shareName) { throw null; }
        public virtual Azure.Pageable<Azure.Storage.Files.Shares.Models.ShareItem> GetShares(Azure.Storage.Files.Shares.Models.ShareTraits traits = Azure.Storage.Files.Shares.Models.ShareTraits.None, Azure.Storage.Files.Shares.Models.ShareStates states = Azure.Storage.Files.Shares.Models.ShareStates.None, string prefix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Files.Shares.Models.ShareItem> GetSharesAsync(Azure.Storage.Files.Shares.Models.ShareTraits traits = Azure.Storage.Files.Shares.Models.ShareTraits.None, Azure.Storage.Files.Shares.Models.ShareStates states = Azure.Storage.Files.Shares.Models.ShareStates.None, string prefix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetProperties(Azure.Storage.Files.Shares.Models.ShareServiceProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetPropertiesAsync(Azure.Storage.Files.Shares.Models.ShareServiceProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ShareUriBuilder
    {
        public ShareUriBuilder(System.Uri uri) { }
        public string AccountName { get { throw null; } set { } }
        public string DirectoryOrFilePath { get { throw null; } set { } }
        public string Host { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public Azure.Storage.Sas.SasQueryParameters Sas { get { throw null; } set { } }
        public string Scheme { get { throw null; } set { } }
        public string ShareName { get { throw null; } set { } }
        public string Snapshot { get { throw null; } set { } }
        public override string ToString() { throw null; }
        public System.Uri ToUri() { throw null; }
    }
}
namespace Azure.Storage.Files.Shares.Models
{
    public partial class CloseHandlesResult
    {
        internal CloseHandlesResult() { }
        public int ClosedHandlesCount { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public int FailedHandlesCount { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public enum CopyStatus
    {
        Pending = 0,
        Success = 1,
        Aborted = 2,
        Failed = 3,
    }
    public partial class FileLeaseReleaseInfo
    {
        internal FileLeaseReleaseInfo() { }
        public Azure.ETag ETag { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset LastModified { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public static partial class FileModelFactory
    {
        public static Azure.Storage.Files.Shares.Models.CloseHandlesResult ClosedHandlesInfo(int closedHandlesCount) { throw null; }
        public static Azure.Storage.Files.Shares.Models.CloseHandlesResult ClosedHandlesInfo(int closedHandlesCount, int failedHandlesCount) { throw null; }
    }
    public partial class FileSmbProperties
    {
        internal FileSmbProperties() { }
        public Azure.Storage.Files.Shares.Models.NtfsFileAttributes? FileAttributes { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public System.DateTimeOffset? FileChangedOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset? FileCreatedOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string FileId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset? FileLastWrittenOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string FilePermissionKey { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string ParentId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
    }
    public static partial class FilesModelFactory
    {
        public static Azure.Storage.Files.Shares.Models.ShareDirectoryProperties StorageDirectoryProperties(System.Collections.Generic.IDictionary<string, string> metadata, Azure.ETag eTag, System.DateTimeOffset lastModified, bool isServerEncrypted, string fileAttributes, System.DateTimeOffset fileCreationTime, System.DateTimeOffset fileLastWriteTime, System.DateTimeOffset fileChangeTime, string filePermissionKey, string fileId, string fileParentId) { throw null; }
        public static Azure.Storage.Files.Shares.Models.ShareFileDownloadInfo StorageFileDownloadInfo(System.DateTimeOffset lastModified = default(System.DateTimeOffset), System.Collections.Generic.IEnumerable<string> contentLanguage = null, string acceptRanges = null, System.DateTimeOffset copyCompletionTime = default(System.DateTimeOffset), string copyStatusDescription = null, string contentDisposition = null, string copyProgress = null, System.Uri copySource = null, Azure.Storage.Files.Shares.Models.CopyStatus copyStatus = Azure.Storage.Files.Shares.Models.CopyStatus.Pending, byte[] fileContentHash = null, bool isServerEncrypted = false, string cacheControl = null, string fileAttributes = null, System.Collections.Generic.IEnumerable<string> contentEncoding = null, System.DateTimeOffset fileCreationTime = default(System.DateTimeOffset), byte[] contentHash = null, System.DateTimeOffset fileLastWriteTime = default(System.DateTimeOffset), Azure.ETag eTag = default(Azure.ETag), System.DateTimeOffset fileChangeTime = default(System.DateTimeOffset), string contentRange = null, string filePermissionKey = null, string contentType = null, string fileId = null, long contentLength = (long)0, string fileParentId = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.IO.Stream content = null, string copyId = null) { throw null; }
        public static Azure.Storage.Files.Shares.Models.ShareFileDownloadDetails StorageFileDownloadProperties(System.DateTimeOffset lastModified, System.Collections.Generic.IDictionary<string, string> metadata, string contentType, string contentRange, Azure.ETag eTag, System.Collections.Generic.IEnumerable<string> contentEncoding, string cacheControl, string contentDisposition, System.Collections.Generic.IEnumerable<string> contentLanguage, string acceptRanges, System.DateTimeOffset copyCompletedOn, string copyStatusDescription, string copyId, string copyProgress, System.Uri copySource, Azure.Storage.Files.Shares.Models.CopyStatus copyStatus, byte[] fileContentHash, bool isServiceEncrypted) { throw null; }
        public static Azure.Storage.Files.Shares.Models.ShareFileInfo StorageFileInfo(Azure.ETag eTag, System.DateTimeOffset lastModified, bool isServerEncrypted, string filePermissionKey, string fileAttributes, System.DateTimeOffset fileCreationTime, System.DateTimeOffset fileLastWriteTime, System.DateTimeOffset fileChangeTime, string fileId, string fileParentId) { throw null; }
        public static Azure.Storage.Files.Shares.Models.ShareFileItem StorageFileItem(bool isDirectory, string name, long? fileSize) { throw null; }
        public static Azure.Storage.Files.Shares.Models.ShareFileProperties StorageFileProperties(System.DateTimeOffset lastModified, System.Collections.Generic.IDictionary<string, string> metadata, long contentLength, string contentType, Azure.ETag eTag, byte[] contentHash, System.Collections.Generic.IEnumerable<string> contentEncoding, string cacheControl, string contentDisposition, System.Collections.Generic.IEnumerable<string> contentLanguage, System.DateTimeOffset copyCompletedOn, string copyStatusDescription, string copyId, string copyProgress, string copySource, Azure.Storage.Files.Shares.Models.CopyStatus copyStatus, bool isServerEncrypted, string fileAttributes, System.DateTimeOffset fileCreationTime, System.DateTimeOffset fileLastWriteTime, System.DateTimeOffset fileChangeTime, string filePermissionKey, string fileId, string fileParentId) { throw null; }
    }
    [System.FlagsAttribute]
    public enum NtfsFileAttributes
    {
        ReadOnly = 1,
        Hidden = 2,
        System = 4,
        None = 8,
        Directory = 16,
        Archive = 32,
        Temporary = 64,
        Offline = 128,
        NotContentIndexed = 256,
        NoScrubData = 512,
    }
    public enum PermissionCopyMode
    {
        Source = 0,
        Override = 1,
    }
    public partial class PermissionInfo
    {
        internal PermissionInfo() { }
        public string FilePermissionKey { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class ShareAccessPolicy
    {
        public ShareAccessPolicy() { }
        public System.DateTimeOffset ExpiresOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Permissions { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public System.DateTimeOffset StartsOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
    public partial class ShareCorsRule
    {
        public ShareCorsRule() { }
        public string AllowedHeaders { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string AllowedMethods { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string AllowedOrigins { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string ExposedHeaders { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public int MaxAgeInSeconds { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
    public partial class ShareDirectoryInfo
    {
        internal ShareDirectoryInfo() { }
        public Azure.ETag ETag { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public Azure.Storage.Files.Shares.Models.FileSmbProperties SmbProperties { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
    public partial class ShareDirectoryProperties
    {
        internal ShareDirectoryProperties() { }
        public Azure.ETag ETag { get { throw null; } }
        public bool IsServerEncrypted { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public Azure.Storage.Files.Shares.Models.FileSmbProperties SmbProperties { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ShareErrorCode : System.IEquatable<Azure.Storage.Files.Shares.Models.ShareErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ShareErrorCode(string value) { throw null; }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode AccountAlreadyExists { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode AccountBeingCreated { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode AccountIsDisabled { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode AuthenticationFailed { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode AuthorizationFailure { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode AuthorizationPermissionMismatch { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode AuthorizationProtocolMismatch { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode AuthorizationResourceTypeMismatch { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode AuthorizationServiceMismatch { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode AuthorizationSourceIPMismatch { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode CannotDeleteFileOrDirectory { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ClientCacheFlushDelay { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ConditionHeadersNotSupported { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ConditionNotMet { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ContainerQuotaDowngradeNotAllowed { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode DeletePending { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode DirectoryNotEmpty { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode EmptyMetadataKey { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode FeatureVersionMismatch { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode FileLockConflict { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode InsufficientAccountPermissions { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode InternalError { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode InvalidAuthenticationInfo { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode InvalidFileOrDirectoryPathName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode InvalidHeaderValue { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode InvalidHttpVerb { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode InvalidInput { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode InvalidMd5 { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode InvalidMetadata { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode InvalidQueryParameterValue { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode InvalidRange { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode InvalidResourceName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode InvalidUri { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode InvalidXmlDocument { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode InvalidXmlNodeValue { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode Md5Mismatch { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode MetadataTooLarge { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode MissingContentLengthHeader { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode MissingRequiredHeader { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode MissingRequiredQueryParameter { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode MissingRequiredXmlNode { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode MultipleConditionHeadersNotSupported { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode OperationTimedOut { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode OutOfRangeInput { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode OutOfRangeQueryParameterValue { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ParentNotFound { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ReadOnlyAttribute { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode RequestBodyTooLarge { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode RequestUrlFailedToParse { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ResourceAlreadyExists { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ResourceNotFound { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ResourceTypeMismatch { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ServerBusy { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ShareAlreadyExists { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ShareBeingDeleted { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ShareDisabled { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ShareHasSnapshots { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ShareNotFound { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ShareSnapshotCountExceeded { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ShareSnapshotInProgress { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode ShareSnapshotOperationNotSupported { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode SharingViolation { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode UnsupportedHeader { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode UnsupportedHttpVerb { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode UnsupportedQueryParameter { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public static Azure.Storage.Files.Shares.Models.ShareErrorCode UnsupportedXmlNode { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public bool Equals(Azure.Storage.Files.Shares.Models.ShareErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Storage.Files.Shares.Models.ShareErrorCode left, Azure.Storage.Files.Shares.Models.ShareErrorCode right) { throw null; }
        public static implicit operator Azure.Storage.Files.Shares.Models.ShareErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.Storage.Files.Shares.Models.ShareErrorCode left, Azure.Storage.Files.Shares.Models.ShareErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ShareFileCopyInfo
    {
        internal ShareFileCopyInfo() { }
        public string CopyId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.Storage.Files.Shares.Models.CopyStatus CopyStatus { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.ETag ETag { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset LastModified { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class ShareFileDownloadDetails
    {
        internal ShareFileDownloadDetails() { }
        public string AcceptRanges { get { throw null; } }
        public string CacheControl { get { throw null; } }
        public string ContentDisposition { get { throw null; } }
        public System.Collections.Generic.IEnumerable<string> ContentEncoding { get { throw null; } }
        public System.Collections.Generic.IEnumerable<string> ContentLanguage { get { throw null; } }
        public string ContentRange { get { throw null; } }
        public System.DateTimeOffset CopyCompletedOn { get { throw null; } }
        public string CopyId { get { throw null; } }
        public string CopyProgress { get { throw null; } }
        public System.Uri CopySource { get { throw null; } }
        public Azure.Storage.Files.Shares.Models.CopyStatus CopyStatus { get { throw null; } }
        public string CopyStatusDescription { get { throw null; } }
        public Azure.ETag ETag { get { throw null; } }
        public byte[] FileContentHash { get { throw null; } }
        public bool IsServerEncrypted { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public Azure.Storage.Files.Shares.Models.ShareLeaseDuration LeaseDuration { get { throw null; } }
        public Azure.Storage.Files.Shares.Models.ShareLeaseState LeaseState { get { throw null; } }
        public Azure.Storage.Files.Shares.Models.ShareLeaseStatus LeaseStatus { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public Azure.Storage.Files.Shares.Models.FileSmbProperties SmbProperties { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
    public partial class ShareFileDownloadInfo : System.IDisposable
    {
        internal ShareFileDownloadInfo() { }
        public System.IO.Stream Content { get { throw null; } }
        public byte[] ContentHash { get { throw null; } }
        public long ContentLength { get { throw null; } }
        public string ContentType { get { throw null; } }
        public Azure.Storage.Files.Shares.Models.ShareFileDownloadDetails Details { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public void Dispose() { }
    }
    public partial class ShareFileHandle
    {
        internal ShareFileHandle() { }
        public string ClientIp { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string FileId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string HandleId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset? LastReconnectedOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset? OpenedOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string ParentId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string Path { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string SessionId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class ShareFileHttpHeaders
    {
        public ShareFileHttpHeaders() { }
        public string CacheControl { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string ContentDisposition { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string[] ContentEncoding { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public byte[] ContentHash { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string[] ContentLanguage { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string ContentType { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
    }
    public partial class ShareFileInfo
    {
        internal ShareFileInfo() { }
        public Azure.ETag ETag { get { throw null; } }
        public bool IsServerEncrypted { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public Azure.Storage.Files.Shares.Models.FileSmbProperties SmbProperties { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
    public partial class ShareFileItem
    {
        internal ShareFileItem() { }
        public long? FileSize { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public bool IsDirectory { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string Name { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class ShareFileLease
    {
        internal ShareFileLease() { }
        public Azure.ETag ETag { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset LastModified { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string LeaseId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class ShareFileProperties
    {
        internal ShareFileProperties() { }
        public string CacheControl { get { throw null; } }
        public string ContentDisposition { get { throw null; } }
        public System.Collections.Generic.IEnumerable<string> ContentEncoding { get { throw null; } }
        public byte[] ContentHash { get { throw null; } }
        public System.Collections.Generic.IEnumerable<string> ContentLanguage { get { throw null; } }
        public long ContentLength { get { throw null; } }
        public string ContentType { get { throw null; } }
        public System.DateTimeOffset CopyCompletedOn { get { throw null; } }
        public string CopyId { get { throw null; } }
        public string CopyProgress { get { throw null; } }
        public string CopySource { get { throw null; } }
        public Azure.Storage.Files.Shares.Models.CopyStatus CopyStatus { get { throw null; } }
        public string CopyStatusDescription { get { throw null; } }
        public Azure.ETag ETag { get { throw null; } }
        public bool IsServerEncrypted { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public Azure.Storage.Files.Shares.Models.ShareLeaseDuration LeaseDuration { get { throw null; } }
        public Azure.Storage.Files.Shares.Models.ShareLeaseState LeaseState { get { throw null; } }
        public Azure.Storage.Files.Shares.Models.ShareLeaseStatus LeaseStatus { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public Azure.Storage.Files.Shares.Models.FileSmbProperties SmbProperties { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
    public partial class ShareFileRangeInfo
    {
        internal ShareFileRangeInfo() { }
        public Azure.ETag ETag { get { throw null; } }
        public long FileContentLength { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public System.Collections.Generic.IEnumerable<Azure.HttpRange> Ranges { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public enum ShareFileRangeWriteType
    {
        Update = 0,
        Clear = 1,
    }
    public partial class ShareFileRequestConditions
    {
        public ShareFileRequestConditions() { }
        public string LeaseId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public override string ToString() { throw null; }
    }
    public partial class ShareFileUploadInfo
    {
        internal ShareFileUploadInfo() { }
        public byte[] ContentHash { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.ETag ETag { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public bool IsServerEncrypted { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset LastModified { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class ShareInfo
    {
        internal ShareInfo() { }
        public Azure.ETag ETag { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset LastModified { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class ShareItem
    {
        internal ShareItem() { }
        public string Name { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.Storage.Files.Shares.Models.ShareProperties Properties { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string Snapshot { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public enum ShareLeaseDuration
    {
        Infinite = 0,
        Fixed = 1,
    }
    public enum ShareLeaseState
    {
        Available = 0,
        Leased = 1,
        Expired = 2,
        Breaking = 3,
        Broken = 4,
    }
    public enum ShareLeaseStatus
    {
        Locked = 0,
        Unlocked = 1,
    }
    public partial class ShareMetrics
    {
        public ShareMetrics() { }
        public bool Enabled { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public bool? IncludeApis { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public Azure.Storage.Files.Shares.Models.ShareRetentionPolicy RetentionPolicy { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Version { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
    public static partial class ShareModelFactory
    {
        public static Azure.Storage.Files.Shares.Models.FileLeaseReleaseInfo FileLeaseReleaseInfo(Azure.ETag eTag, System.DateTimeOffset lastModified) { throw null; }
        public static Azure.Storage.Files.Shares.Models.PermissionInfo PermissionInfo(string filePermissionKey) { throw null; }
        public static Azure.Storage.Files.Shares.Models.ShareFileCopyInfo ShareFileCopyInfo(Azure.ETag eTag, System.DateTimeOffset lastModified, string copyId, Azure.Storage.Files.Shares.Models.CopyStatus copyStatus) { throw null; }
        public static Azure.Storage.Files.Shares.Models.ShareFileHandle ShareFileHandle(string handleId, string path, string fileId, string sessionId, string clientIp, string parentId = null, System.DateTimeOffset? openedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastReconnectedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Storage.Files.Shares.Models.ShareFileLease ShareFileLease(Azure.ETag eTag, System.DateTimeOffset lastModified, string leaseId) { throw null; }
        public static Azure.Storage.Files.Shares.Models.ShareFileRangeInfo ShareFileRangeInfo(System.DateTimeOffset lastModified, Azure.ETag eTag, long fileContentLength, System.Collections.Generic.IEnumerable<Azure.HttpRange> ranges) { throw null; }
        public static Azure.Storage.Files.Shares.Models.ShareFileUploadInfo ShareFileUploadInfo(Azure.ETag eTag, System.DateTimeOffset lastModified, byte[] contentHash, bool isServerEncrypted) { throw null; }
        public static Azure.Storage.Files.Shares.Models.ShareInfo ShareInfo(Azure.ETag eTag, System.DateTimeOffset lastModified) { throw null; }
        public static Azure.Storage.Files.Shares.Models.ShareItem ShareItem(string name, Azure.Storage.Files.Shares.Models.ShareProperties properties, string snapshot = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Files.Shares.Models.ShareProperties ShareProperties(System.DateTimeOffset? lastModified, Azure.ETag? eTag, int? quotaInGB, System.Collections.Generic.IDictionary<string, string> metadata) { throw null; }
        public static Azure.Storage.Files.Shares.Models.ShareProperties ShareProperties(System.DateTimeOffset? lastModified = default(System.DateTimeOffset?), Azure.ETag? eTag = default(Azure.ETag?), int? provisionedIops = default(int?), int? provisionedIngressMBps = default(int?), int? provisionedEgressMBps = default(int?), System.DateTimeOffset? nextAllowedQuotaDowngradeTime = default(System.DateTimeOffset?), int? quotaInGB = default(int?), System.Collections.Generic.IDictionary<string, string> metadata = null) { throw null; }
        public static Azure.Storage.Files.Shares.Models.ShareSnapshotInfo ShareSnapshotInfo(string snapshot, Azure.ETag eTag, System.DateTimeOffset lastModified) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Files.Shares.Models.ShareStatistics ShareStatistics(int shareUsageBytes) { throw null; }
        public static Azure.Storage.Files.Shares.Models.ShareStatistics ShareStatistics(long shareUsageInBytes) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Storage.Files.Shares.Models.StorageClosedHandlesSegment StorageClosedHandlesSegment(string marker, int numberOfHandlesClosed) { throw null; }
        public static Azure.Storage.Files.Shares.Models.StorageClosedHandlesSegment StorageClosedHandlesSegment(string marker, int numberOfHandlesClosed, int numberOfHandlesFailedToClose) { throw null; }
    }
    public partial class ShareProperties
    {
        internal ShareProperties() { }
        public Azure.ETag? ETag { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset? LastModified { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset? NextAllowedQuotaDowngradeTime { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public int? ProvisionedEgressMBps { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public int? ProvisionedIngressMBps { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public int? ProvisionedIops { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public int? QuotaInGB { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class ShareRetentionPolicy
    {
        public ShareRetentionPolicy() { }
        public int? Days { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public bool Enabled { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
    public partial class ShareServiceProperties
    {
        public ShareServiceProperties() { }
        public System.Collections.Generic.IList<Azure.Storage.Files.Shares.Models.ShareCorsRule> Cors { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public Azure.Storage.Files.Shares.Models.ShareMetrics HourMetrics { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public Azure.Storage.Files.Shares.Models.ShareMetrics MinuteMetrics { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
    public partial class ShareSignedIdentifier
    {
        public ShareSignedIdentifier() { }
        public Azure.Storage.Files.Shares.Models.ShareAccessPolicy AccessPolicy { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Id { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
    public static partial class SharesModelFactory
    {
        public static Azure.Storage.Files.Shares.Models.FileSmbProperties FileSmbProperties(System.DateTimeOffset? fileChangedOn, string fileId, string parentId) { throw null; }
        public static Azure.Storage.Files.Shares.Models.ShareDirectoryInfo StorageDirectoryInfo(Azure.ETag eTag, System.DateTimeOffset lastModified, string filePermissionKey, string fileAttributes, System.DateTimeOffset fileCreationTime, System.DateTimeOffset fileLastWriteTime, System.DateTimeOffset fileChangeTime, string fileId, string fileParentId) { throw null; }
    }
    public partial class ShareSnapshotInfo
    {
        internal ShareSnapshotInfo() { }
        public Azure.ETag ETag { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset LastModified { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string Snapshot { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    [System.FlagsAttribute]
    public enum ShareStates
    {
        All = -1,
        None = 0,
        Snapshots = 1,
    }
    public partial class ShareStatistics
    {
        internal ShareStatistics() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public int ShareUsageBytes { get { throw null; } }
        public long ShareUsageInBytes { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    [System.FlagsAttribute]
    public enum ShareTraits
    {
        All = -1,
        None = 0,
        Metadata = 1,
    }
    public partial class StorageClosedHandlesSegment
    {
        internal StorageClosedHandlesSegment() { }
        public string Marker { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public int NumberOfHandlesClosed { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public int NumberOfHandlesFailedToClose { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
}
namespace Azure.Storage.Files.Shares.Specialized
{
    public partial class ShareLeaseClient
    {
        protected ShareLeaseClient() { }
        public ShareLeaseClient(Azure.Storage.Files.Shares.ShareFileClient client, string leaseId = null) { }
        protected virtual Azure.Storage.Files.Shares.ShareFileClient FileClient { get { throw null; } }
        public virtual string LeaseId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileLease> Acquire(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileLease>> AcquireAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileLease> Break(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileLease>> BreakAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileLease> Change(string proposedId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.ShareFileLease>> ChangeAsync(string proposedId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.Shares.Models.FileLeaseReleaseInfo> Release(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.Shares.Models.FileLeaseReleaseInfo>> ReleaseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class SpecializedFileExtensions
    {
        public static Azure.Storage.Files.Shares.Specialized.ShareLeaseClient GetShareLeaseClient(this Azure.Storage.Files.Shares.ShareFileClient client, string leaseId = null) { throw null; }
    }
}
namespace Azure.Storage.Sas
{
    [System.FlagsAttribute]
    public enum ShareAccountSasPermissions
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
    public enum ShareFileSasPermissions
    {
        All = -1,
        Read = 1,
        Create = 2,
        Write = 4,
        Delete = 8,
    }
    public partial class ShareSasBuilder
    {
        public ShareSasBuilder() { }
        public string CacheControl { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string ContentDisposition { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string ContentEncoding { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string ContentLanguage { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string ContentType { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public System.DateTimeOffset ExpiresOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string FilePath { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Identifier { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public Azure.Storage.Sas.SasIPRange IPRange { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Permissions { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.Storage.Sas.SasProtocol Protocol { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Resource { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string ShareName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public System.DateTimeOffset StartsOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Version { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public void SetPermissions(Azure.Storage.Sas.ShareAccountSasPermissions permissions) { }
        public void SetPermissions(Azure.Storage.Sas.ShareFileSasPermissions permissions) { }
        public void SetPermissions(Azure.Storage.Sas.ShareSasPermissions permissions) { }
        public void SetPermissions(string rawPermissions) { }
        public Azure.Storage.Sas.SasQueryParameters ToSasQueryParameters(Azure.Storage.StorageSharedKeyCredential sharedKeyCredential) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    [System.FlagsAttribute]
    public enum ShareSasPermissions
    {
        All = -1,
        Read = 1,
        Create = 2,
        Write = 4,
        Delete = 8,
        List = 16,
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class ShareClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Storage.Files.Shares.ShareServiceClient, Azure.Storage.Files.Shares.ShareClientOptions> AddFileServiceClient<TBuilder>(this TBuilder builder, string connectionString) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Storage.Files.Shares.ShareServiceClient, Azure.Storage.Files.Shares.ShareClientOptions> AddFileServiceClient<TBuilder>(this TBuilder builder, System.Uri serviceUri) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Storage.Files.Shares.ShareServiceClient, Azure.Storage.Files.Shares.ShareClientOptions> AddFileServiceClient<TBuilder>(this TBuilder builder, System.Uri serviceUri, Azure.Storage.StorageSharedKeyCredential sharedKeyCredential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Storage.Files.Shares.ShareServiceClient, Azure.Storage.Files.Shares.ShareClientOptions> AddFileServiceClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
