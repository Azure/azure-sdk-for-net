namespace Azure.Storage.Files.DataLake
{
    public partial class DataLakeClientOptions : Azure.Core.ClientOptions
    {
        public DataLakeClientOptions(Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion version = Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion.V2019_02_02) { }
        public System.Uri GeoRedundantSecondaryUri { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public Azure.Storage.Files.DataLake.DataLakeClientOptions.ServiceVersion Version { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public enum ServiceVersion
        {
            V2019_02_02 = 1,
        }
    }
    public partial class DataLakeDirectoryClient : Azure.Storage.Files.DataLake.DataLakePathClient
    {
        protected DataLakeDirectoryClient() { }
        public DataLakeDirectoryClient(System.Uri directoryUri) { }
        public DataLakeDirectoryClient(System.Uri directoryUri, Azure.Core.TokenCredential credential) { }
        public DataLakeDirectoryClient(System.Uri directoryUri, Azure.Core.TokenCredential credential, Azure.Storage.Files.DataLake.DataLakeClientOptions options) { }
        public DataLakeDirectoryClient(System.Uri directoryUri, Azure.Storage.Files.DataLake.DataLakeClientOptions options) { }
        public DataLakeDirectoryClient(System.Uri directoryUri, Azure.Storage.StorageSharedKeyCredential credential) { }
        public DataLakeDirectoryClient(System.Uri directoryUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Files.DataLake.DataLakeClientOptions options) { }
        public virtual string Name { get { throw null; } }
        public virtual Azure.Response<Azure.Storage.Files.DataLake.Models.PathInfo> Create(Azure.Storage.Files.DataLake.Models.PathHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, string permissions = null, string umask = null, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.DataLake.Models.PathInfo>> CreateAsync(Azure.Storage.Files.DataLake.Models.PathHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, string permissions = null, string umask = null, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.DataLake.DataLakeFileClient> CreateFile(string fileName, Azure.Storage.Files.DataLake.Models.PathHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, string permissions = null, string umask = null, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.DataLake.DataLakeFileClient>> CreateFileAsync(string fileName, Azure.Storage.Files.DataLake.Models.PathHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, string permissions = null, string umask = null, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.DataLake.DataLakeDirectoryClient> CreateSubDirectory(string path, Azure.Storage.Files.DataLake.Models.PathHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, string permissions = null, string umask = null, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.DataLake.DataLakeDirectoryClient>> CreateSubDirectoryAsync(string path, Azure.Storage.Files.DataLake.Models.PathHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, string permissions = null, string umask = null, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteFile(string fileName, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteFileAsync(string fileName, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteSubDirectory(string path, string continuation = null, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSubDirectoryAsync(string path, string continuation = null, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Storage.Files.DataLake.DataLakeFileClient GetFileClient(string fileName) { throw null; }
        public virtual Azure.Storage.Files.DataLake.DataLakeDirectoryClient GetSubDirectoryClient(string subdirectoryName) { throw null; }
        public virtual new Azure.Response<Azure.Storage.Files.DataLake.DataLakeDirectoryClient> Rename(string destinationPath, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions sourceConditions = null, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions destinationConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.DataLake.DataLakeDirectoryClient>> RenameAsync(string destinationPath, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions sourceConditions = null, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions destinationConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataLakeFileClient : Azure.Storage.Files.DataLake.DataLakePathClient
    {
        protected DataLakeFileClient() { }
        public DataLakeFileClient(System.Uri fileUri) { }
        public DataLakeFileClient(System.Uri fileUri, Azure.Core.TokenCredential credential) { }
        public DataLakeFileClient(System.Uri fileUri, Azure.Core.TokenCredential credential, Azure.Storage.Files.DataLake.DataLakeClientOptions options) { }
        public DataLakeFileClient(System.Uri fileUri, Azure.Storage.Files.DataLake.DataLakeClientOptions options) { }
        public DataLakeFileClient(System.Uri fileUri, Azure.Storage.StorageSharedKeyCredential credential) { }
        public DataLakeFileClient(System.Uri fileUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Files.DataLake.DataLakeClientOptions options) { }
        public virtual string Name { get { throw null; } }
        public virtual Azure.Response Append(System.IO.Stream content, long offset, byte[] contentHash = null, string leaseId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AppendAsync(System.IO.Stream content, long offset, byte[] contentHash = null, string leaseId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.DataLake.Models.PathInfo> Create(Azure.Storage.Files.DataLake.Models.PathHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, string permissions = null, string umask = null, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.DataLake.Models.PathInfo>> CreateAsync(Azure.Storage.Files.DataLake.Models.PathHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, string permissions = null, string umask = null, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.DataLake.Models.PathInfo> Flush(long position, bool? retainUncommittedData = default(bool?), bool? close = default(bool?), Azure.Storage.Files.DataLake.Models.PathHttpHeaders httpHeaders = null, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.DataLake.Models.PathInfo>> FlushAsync(long position, bool? retainUncommittedData = default(bool?), bool? close = default(bool?), Azure.Storage.Files.DataLake.Models.PathHttpHeaders httpHeaders = null, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.DataLake.Models.FileDownloadInfo> Read() { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.DataLake.Models.FileDownloadInfo> Read(Azure.HttpRange range = default(Azure.HttpRange), Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, bool rangeGetContentHash = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.DataLake.Models.FileDownloadInfo> Read(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.DataLake.Models.FileDownloadInfo>> ReadAsync() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.DataLake.Models.FileDownloadInfo>> ReadAsync(Azure.HttpRange range = default(Azure.HttpRange), Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, bool rangeGetContentHash = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.DataLake.Models.FileDownloadInfo>> ReadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new Azure.Response<Azure.Storage.Files.DataLake.DataLakeFileClient> Rename(string destinationPath, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions sourceConditions = null, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions destinationConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual new System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.DataLake.DataLakeFileClient>> RenameAsync(string destinationPath, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions sourceConditions = null, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions destinationConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataLakeFileSystemClient
    {
        protected DataLakeFileSystemClient() { }
        public DataLakeFileSystemClient(System.Uri fileSystemUri) { }
        public DataLakeFileSystemClient(System.Uri fileSystemUri, Azure.Core.TokenCredential credential) { }
        public DataLakeFileSystemClient(System.Uri fileSystemUri, Azure.Core.TokenCredential credential, Azure.Storage.Files.DataLake.DataLakeClientOptions options) { }
        public DataLakeFileSystemClient(System.Uri fileSystemUri, Azure.Storage.Files.DataLake.DataLakeClientOptions options) { }
        public DataLakeFileSystemClient(System.Uri fileSystemUri, Azure.Storage.StorageSharedKeyCredential credential) { }
        public DataLakeFileSystemClient(System.Uri fileSystemUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Files.DataLake.DataLakeClientOptions options) { }
        public virtual string AccountName { get { throw null; } }
        public virtual string Name { get { throw null; } }
        protected virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual System.Uri Uri { get { throw null; } }
        public virtual Azure.Response<Azure.Storage.Files.DataLake.Models.FileSystemInfo> Create(Azure.Storage.Files.DataLake.Models.PublicAccessType publicAccessType = Azure.Storage.Files.DataLake.Models.PublicAccessType.None, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.DataLake.Models.FileSystemInfo>> CreateAsync(Azure.Storage.Files.DataLake.Models.PublicAccessType publicAccessType = Azure.Storage.Files.DataLake.Models.PublicAccessType.None, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.DataLake.DataLakeDirectoryClient> CreateDirectory(string path, Azure.Storage.Files.DataLake.Models.PathHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, string permissions = null, string umask = null, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.DataLake.DataLakeDirectoryClient>> CreateDirectoryAsync(string path, Azure.Storage.Files.DataLake.Models.PathHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, string permissions = null, string umask = null, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.DataLake.DataLakeFileClient> CreateFile(string path, Azure.Storage.Files.DataLake.Models.PathHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, string permissions = null, string umask = null, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.DataLake.DataLakeFileClient>> CreateFileAsync(string path, Azure.Storage.Files.DataLake.Models.PathHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, string permissions = null, string umask = null, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteDirectory(string path, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDirectoryAsync(string path, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteFile(string path, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteFileAsync(string path, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Storage.Files.DataLake.DataLakeDirectoryClient GetDirectoryClient(string directoryName) { throw null; }
        public virtual Azure.Storage.Files.DataLake.DataLakeFileClient GetFileClient(string fileName) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.DataLake.Models.FileSystemProperties> GetProperties(Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.DataLake.Models.FileSystemProperties>> GetPropertiesAsync(Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Storage.Files.DataLake.Models.PathItem> ListPaths(string path = null, bool recursive = false, bool userPrincipalName = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Files.DataLake.Models.PathItem> ListPathsAsync(string path = null, bool recursive = false, bool userPrincipalName = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.DataLake.Models.FileSystemInfo> SetMetadata(System.Collections.Generic.IDictionary<string, string> metadata, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.DataLake.Models.FileSystemInfo>> SetMetadataAsync(System.Collections.Generic.IDictionary<string, string> metadata, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataLakeLeaseClient
    {
        public static readonly System.TimeSpan InfiniteLeaseDuration;
        protected DataLakeLeaseClient() { }
        public DataLakeLeaseClient(Azure.Storage.Files.DataLake.DataLakeFileSystemClient client, string leaseId = null) { }
        public DataLakeLeaseClient(Azure.Storage.Files.DataLake.DataLakePathClient client, string leaseId = null) { }
        public virtual string LeaseId { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        public virtual Azure.Response<Azure.Storage.Files.DataLake.Models.DataLakeLease> Acquire(System.TimeSpan duration, Azure.RequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.DataLake.Models.DataLakeLease>> AcquireAsync(System.TimeSpan duration, Azure.RequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.DataLake.Models.DataLakeLease> Break(System.TimeSpan? breakPeriod = default(System.TimeSpan?), Azure.RequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.DataLake.Models.DataLakeLease>> BreakAsync(System.TimeSpan? breakPeriod = default(System.TimeSpan?), Azure.RequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.DataLake.Models.DataLakeLease> Change(string proposedId, Azure.RequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.DataLake.Models.DataLakeLease>> ChangeAsync(string proposedId, Azure.RequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.DataLake.Models.ReleasedObjectInfo> Release(Azure.RequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.DataLake.Models.ReleasedObjectInfo>> ReleaseAsync(Azure.RequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.DataLake.Models.DataLakeLease> Renew(Azure.RequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.DataLake.Models.DataLakeLease>> RenewAsync(Azure.RequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class DataLakeLeaseClientExtensions
    {
        public static Azure.Storage.Files.DataLake.DataLakeLeaseClient GetDataLakeLeaseClient(this Azure.Storage.Files.DataLake.DataLakeFileSystemClient client, string leaseId = null) { throw null; }
        public static Azure.Storage.Files.DataLake.DataLakeLeaseClient GetDataLakeLeaseClient(this Azure.Storage.Files.DataLake.DataLakePathClient client, string leaseId = null) { throw null; }
    }
    public partial class DataLakePathClient
    {
        protected DataLakePathClient() { }
        public DataLakePathClient(System.Uri pathUri) { }
        public DataLakePathClient(System.Uri pathUri, Azure.Core.TokenCredential credential) { }
        public DataLakePathClient(System.Uri pathUri, Azure.Core.TokenCredential credential, Azure.Storage.Files.DataLake.DataLakeClientOptions options) { }
        public DataLakePathClient(System.Uri pathUri, Azure.Storage.Files.DataLake.DataLakeClientOptions options) { }
        public DataLakePathClient(System.Uri pathUri, Azure.Storage.StorageSharedKeyCredential credential) { }
        public DataLakePathClient(System.Uri pathUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Files.DataLake.DataLakeClientOptions options) { }
        public virtual string AccountName { get { throw null; } }
        public virtual string FileSystemName { get { throw null; } }
        public virtual System.Uri Uri { get { throw null; } }
        protected virtual Azure.Response<Azure.Storage.Files.DataLake.Models.PathInfo> Create(Azure.Storage.Files.DataLake.Models.PathResourceType resourceType, Azure.Storage.Files.DataLake.Models.PathHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, string permissions = null, string umask = null, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.DataLake.Models.PathInfo>> CreateAsync(Azure.Storage.Files.DataLake.Models.PathResourceType resourceType, Azure.Storage.Files.DataLake.Models.PathHttpHeaders httpHeaders = null, System.Collections.Generic.IDictionary<string, string> metadata = null, string permissions = null, string umask = null, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(bool? recursive = default(bool?), Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(bool? recursive = default(bool?), Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.DataLake.Models.PathAccessControl> GetAccessControl(bool? userPrincipalName = default(bool?), Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.DataLake.Models.PathAccessControl>> GetAccessControlAsync(bool? userPrincipalName = default(bool?), Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.DataLake.Models.PathProperties> GetProperties(Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.DataLake.Models.PathProperties>> GetPropertiesAsync(Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.DataLake.DataLakePathClient> Rename(string destinationPath, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions sourceConditions = null, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions destinationConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.DataLake.DataLakePathClient>> RenameAsync(string destinationPath, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions sourceConditions = null, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions destinationConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.DataLake.Models.PathInfo> SetAccessControl(string acl, string owner = null, string group = null, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.DataLake.Models.PathInfo>> SetAccessControlAsync(string acl, string owner = null, string group = null, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.DataLake.Models.PathInfo> SetHttpHeaders(Azure.Storage.Files.DataLake.Models.PathHttpHeaders httpHeaders = null, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.DataLake.Models.PathInfo>> SetHttpHeadersAsync(Azure.Storage.Files.DataLake.Models.PathHttpHeaders httpHeaders = null, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.DataLake.Models.PathInfo> SetMetadata(System.Collections.Generic.IDictionary<string, string> metadata, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.DataLake.Models.PathInfo>> SetMetadataAsync(System.Collections.Generic.IDictionary<string, string> metadata, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.DataLake.Models.PathInfo> SetPermissions(string permissions, string owner = null, string group = null, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.DataLake.Models.PathInfo>> SetPermissionsAsync(string permissions, string owner = null, string group = null, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataLakeServiceClient
    {
        protected DataLakeServiceClient() { }
        public DataLakeServiceClient(System.Uri serviceUri) { }
        public DataLakeServiceClient(System.Uri serviceUri, Azure.Core.TokenCredential credential) { }
        public DataLakeServiceClient(System.Uri serviceUri, Azure.Core.TokenCredential credential, Azure.Storage.Files.DataLake.DataLakeClientOptions options) { }
        public DataLakeServiceClient(System.Uri serviceUri, Azure.Storage.Files.DataLake.DataLakeClientOptions options) { }
        public DataLakeServiceClient(System.Uri serviceUri, Azure.Storage.StorageSharedKeyCredential credential) { }
        public DataLakeServiceClient(System.Uri serviceUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Files.DataLake.DataLakeClientOptions options) { }
        public virtual string AccountName { get { throw null; } }
        protected virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual System.Uri Uri { get { throw null; } }
        public virtual Azure.Response<Azure.Storage.Files.DataLake.DataLakeFileSystemClient> CreateFileSystem(string fileSystemName, Azure.Storage.Files.DataLake.Models.PublicAccessType publicAccessType = Azure.Storage.Files.DataLake.Models.PublicAccessType.None, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.DataLake.DataLakeFileSystemClient>> CreateFileSystemAsync(string fileSystemName, Azure.Storage.Files.DataLake.Models.PublicAccessType publicAccessType = Azure.Storage.Files.DataLake.Models.PublicAccessType.None, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteFileSystem(string fileSystemName, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteFileSystemAsync(string fileSystemName, Azure.Storage.Files.DataLake.Models.DataLakeRequestConditions conditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Storage.Files.DataLake.DataLakeFileSystemClient GetFileSystemClient(string fileSystemName) { throw null; }
        public virtual Azure.Pageable<Azure.Storage.Files.DataLake.Models.FileSystemItem> GetFileSystems(Azure.Storage.Files.DataLake.Models.FileSystemTraits traits = Azure.Storage.Files.DataLake.Models.FileSystemTraits.None, string prefix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Storage.Files.DataLake.Models.FileSystemItem> GetFileSystemsAsync(Azure.Storage.Files.DataLake.Models.FileSystemTraits traits = Azure.Storage.Files.DataLake.Models.FileSystemTraits.None, string prefix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Storage.Files.DataLake.Models.UserDelegationKey> GetUserDelegationKey(System.DateTimeOffset? startsOn, System.DateTimeOffset expiresOn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Storage.Files.DataLake.Models.UserDelegationKey>> GetUserDelegationKeyAsync(System.DateTimeOffset? startsOn, System.DateTimeOffset expiresOn, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataLakeUriBuilder
    {
        public DataLakeUriBuilder(System.Uri uri) { }
        public string AccountName { get { throw null; } set { } }
        public string DirectoryOrFilePath { get { throw null; } set { } }
        public string FileSystemName { get { throw null; } set { } }
        public string Host { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public Azure.Storage.Sas.SasQueryParameters Sas { get { throw null; } set { } }
        public string Scheme { get { throw null; } set { } }
        public string Snapshot { get { throw null; } set { } }
        public override string ToString() { throw null; }
        public System.Uri ToUri() { throw null; }
    }
}
namespace Azure.Storage.Files.DataLake.Models
{
    public enum CopyStatus
    {
        Pending = 0,
        Success = 1,
        Aborted = 2,
        Failed = 3,
    }
    public partial class DataLakeLease
    {
        internal DataLakeLease() { }
        public Azure.ETag ETag { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset LastModified { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string LeaseId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public int? LeaseTime { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public static partial class DataLakeModelFactory
    {
        public static Azure.Storage.Files.DataLake.Models.FileDownloadDetails FileDownloadDetails(System.DateTimeOffset lastModified, System.Collections.Generic.IDictionary<string, string> metadata, string contentRange, Azure.ETag eTag, string contentEncoding, string cacheControl, string contentDisposition, string contentLanguage, System.DateTimeOffset copyCompletionTime, string copyStatusDescription, string copyId, string copyProgress, System.Uri copySource, Azure.Storage.Files.DataLake.Models.CopyStatus copyStatus, Azure.Storage.Files.DataLake.Models.LeaseDurationType leaseDuration, Azure.Storage.Files.DataLake.Models.LeaseState leaseState, Azure.Storage.Files.DataLake.Models.LeaseStatus leaseStatus, string acceptRanges, bool isServerEncrypted, string encryptionKeySha256, byte[] contentHash) { throw null; }
        public static Azure.Storage.Files.DataLake.Models.FileDownloadInfo FileDownloadInfo(long contentLength, System.IO.Stream content, byte[] contentHash, Azure.Storage.Files.DataLake.Models.FileDownloadDetails properties) { throw null; }
        public static Azure.Storage.Files.DataLake.Models.FileSystemInfo FileSystemInfo(Azure.ETag etag, System.DateTimeOffset lastModified) { throw null; }
        public static Azure.Storage.Files.DataLake.Models.FileSystemItem FileSystemItem(string name, Azure.Storage.Files.DataLake.Models.FileSystemProperties properties) { throw null; }
        public static Azure.Storage.Files.DataLake.Models.FileSystemProperties FileSystemProperties(System.DateTimeOffset lastModified, Azure.Storage.Files.DataLake.Models.LeaseStatus? leaseStatus, Azure.Storage.Files.DataLake.Models.LeaseState? leaseState, Azure.Storage.Files.DataLake.Models.LeaseDurationType? leaseDuration, Azure.Storage.Files.DataLake.Models.PublicAccessType? publicAccess, bool? hasImmutabilityPolicy, bool? hasLegalHold, Azure.ETag eTag) { throw null; }
        public static Azure.Storage.Files.DataLake.Models.DataLakeLease Lease(Azure.ETag eTag, System.DateTimeOffset lastModified, string leaseId, int? leaseTime) { throw null; }
        public static Azure.Storage.Files.DataLake.Models.PathAccessControl PathAccessControl(string owner, string group, string permissions, string acl) { throw null; }
        public static Azure.Storage.Files.DataLake.Models.PathContentInfo PathContentInfo(string contentHash, Azure.ETag eTag, System.DateTimeOffset lastModified, string acceptRanges, string cacheControl, string contentDisposition, string contentEncoding, string contentLanguage, long contentLength, string contentRange, string contentType, System.Collections.Generic.IDictionary<string, string> metadata) { throw null; }
        public static Azure.Storage.Files.DataLake.Models.PathCreateInfo PathCreateInfo(Azure.Storage.Files.DataLake.Models.PathInfo pathInfo, string continuation) { throw null; }
        public static Azure.Storage.Files.DataLake.Models.PathInfo PathInfo(Azure.ETag eTag, System.DateTimeOffset lastModified) { throw null; }
        public static Azure.Storage.Files.DataLake.Models.PathItem PathItem(string name, bool? isDirectory, System.DateTimeOffset lastModified, Azure.ETag eTag, long? contentLength, string owner, string group, string permissions) { throw null; }
        public static Azure.Storage.Files.DataLake.Models.PathProperties PathProperties(System.DateTimeOffset lastModified, System.DateTimeOffset creationTime, System.Collections.Generic.IDictionary<string, string> metadata, System.DateTimeOffset copyCompletionTime, string copyStatusDescription, string copyId, string copyProgress, System.Uri copySource, Azure.Storage.Files.DataLake.Models.CopyStatus copyStatus, bool isIncrementalCopy, Azure.Storage.Files.DataLake.Models.LeaseDurationType leaseDuration, Azure.Storage.Files.DataLake.Models.LeaseState leaseState, Azure.Storage.Files.DataLake.Models.LeaseStatus leaseStatus, long contentLength, string contentType, Azure.ETag eTag, byte[] contentHash, string contentEncoding, string contentDisposition, string contentLanguage, string cacheControl, string acceptRanges, bool isServerEncrypted, string encryptionKeySha256, string accessTier, string archiveStatus, System.DateTimeOffset accessTierChangeTime) { throw null; }
        public static Azure.Storage.Files.DataLake.Models.UserDelegationKey UserDelegationKey(string signedObjectId, string signedTenantId, System.DateTimeOffset signedStart, System.DateTimeOffset signedExpiry, string signedService, string signedVersion, string value) { throw null; }
    }
    public partial class DataLakeRequestConditions : Azure.RequestConditions
    {
        public DataLakeRequestConditions() { }
        public string LeaseId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public override string ToString() { throw null; }
    }
    public partial class FileDownloadDetails
    {
        internal FileDownloadDetails() { }
        public string AcceptRanges { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string CacheControl { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string ContentDisposition { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string ContentEncoding { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public byte[] ContentHash { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string ContentLanguage { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string ContentRange { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset CopyCompletedOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string CopyId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string CopyProgress { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Uri CopySource { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.Storage.Files.DataLake.Models.CopyStatus CopyStatus { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string CopyStatusDescription { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string EncryptionKeySha256 { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.ETag ETag { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public bool IsServerEncrypted { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset LastModified { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.Storage.Files.DataLake.Models.LeaseDurationType LeaseDuration { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.Storage.Files.DataLake.Models.LeaseState LeaseState { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.Storage.Files.DataLake.Models.LeaseStatus LeaseStatus { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class FileDownloadInfo
    {
        internal FileDownloadInfo() { }
        public System.IO.Stream Content { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public byte[] ContentHash { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public long ContentLength { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.Storage.Files.DataLake.Models.FileDownloadDetails Properties { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class FileSystemInfo
    {
        internal FileSystemInfo() { }
        public Azure.ETag ETag { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset LastModified { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class FileSystemItem
    {
        internal FileSystemItem() { }
        public string Name { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.Storage.Files.DataLake.Models.FileSystemProperties Properties { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class FileSystemProperties
    {
        internal FileSystemProperties() { }
        public Azure.ETag ETag { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public bool? HasImmutabilityPolicy { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public bool? HasLegalHold { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset LastModified { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.Storage.Files.DataLake.Models.LeaseDurationType? LeaseDuration { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.Storage.Files.DataLake.Models.LeaseState? LeaseState { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.Storage.Files.DataLake.Models.LeaseStatus? LeaseStatus { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.Storage.Files.DataLake.Models.PublicAccessType? PublicAccess { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    [System.FlagsAttribute]
    public enum FileSystemTraits
    {
        None = 0,
        Metadata = 1,
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
    public partial class PathAccessControl
    {
        internal PathAccessControl() { }
        public string Acl { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string Group { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string Owner { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string Permissions { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class PathContentInfo
    {
        internal PathContentInfo() { }
        public string AcceptRanges { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string CacheControl { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string ContentDisposition { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string ContentEncoding { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string ContentHash { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string ContentLanguage { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public long ContentLength { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string ContentRange { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string ContentType { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.ETag ETag { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset LastModified { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class PathCreateInfo
    {
        internal PathCreateInfo() { }
        public string Continuation { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.Storage.Files.DataLake.Models.PathInfo PathInfo { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public enum PathGetPropertiesAction
    {
        GetAccessControl = 0,
        GetStatus = 1,
    }
    public partial class PathHttpHeaders
    {
        public PathHttpHeaders() { }
        public string CacheControl { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string ContentDisposition { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string ContentEncoding { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public byte[] ContentHash { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string ContentLanguage { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string ContentType { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class PathInfo
    {
        internal PathInfo() { }
        public Azure.ETag ETag { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset LastModified { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class PathItem
    {
        internal PathItem() { }
        public long? ContentLength { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.ETag ETag { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string Group { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public bool? IsDirectory { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset LastModified { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string Name { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string Owner { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string Permissions { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public enum PathLeaseAction
    {
        Acquire = 0,
        Break = 1,
        Change = 2,
        Renew = 3,
        Release = 4,
    }
    public partial class PathProperties
    {
        internal PathProperties() { }
        public string AcceptRanges { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string AccessTier { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset AccessTierChangedOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string ArchiveStatus { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string CacheControl { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string ContentDisposition { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string ContentEncoding { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public byte[] ContentHash { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string ContentLanguage { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public long ContentLength { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string ContentType { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset CopyCompletedOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string CopyId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string CopyProgress { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Uri CopySource { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.Storage.Files.DataLake.Models.CopyStatus CopyStatus { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string CopyStatusDescription { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset CreatedOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string EncryptionKeySha256 { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.ETag ETag { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public bool IsIncrementalCopy { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public bool IsServerEncrypted { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset LastModified { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.Storage.Files.DataLake.Models.LeaseDurationType LeaseDuration { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.Storage.Files.DataLake.Models.LeaseState LeaseState { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.Storage.Files.DataLake.Models.LeaseStatus LeaseStatus { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public enum PathRenameMode
    {
        Legacy = 0,
        Posix = 1,
    }
    public enum PathResourceType
    {
        Directory = 0,
        File = 1,
    }
    public enum PathUpdateAction
    {
        Append = 0,
        Flush = 1,
        SetProperties = 2,
        SetAccessControl = 3,
    }
    public enum PublicAccessType
    {
        None = 0,
        FileSystem = 1,
        Path = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReleasedObjectInfo : System.IEquatable<Azure.Storage.Files.DataLake.Models.ReleasedObjectInfo>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReleasedObjectInfo(Azure.ETag eTag, System.DateTimeOffset lastModified) { throw null; }
        public Azure.ETag ETag { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset LastModified { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public bool Equals(Azure.Storage.Files.DataLake.Models.ReleasedObjectInfo other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Storage.Files.DataLake.Models.ReleasedObjectInfo left, Azure.Storage.Files.DataLake.Models.ReleasedObjectInfo right) { throw null; }
        public static bool operator !=(Azure.Storage.Files.DataLake.Models.ReleasedObjectInfo left, Azure.Storage.Files.DataLake.Models.ReleasedObjectInfo right) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class UserDelegationKey
    {
        internal UserDelegationKey() { }
        public System.DateTimeOffset SignedExpiresOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string SignedObjectId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string SignedService { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.DateTimeOffset SignedStartsOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string SignedTenantId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string SignedVersion { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string Value { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
}
namespace Azure.Storage.Files.DataLake.Sas
{
    [System.FlagsAttribute]
    public enum DataLakeAccountSasPermissions
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
    public enum DataLakeFileSystemSasPermissions
    {
        All = -1,
        Read = 1,
        Add = 2,
        Create = 4,
        Write = 8,
        Delete = 16,
        List = 32,
    }
    public partial class DataLakeSasBuilder
    {
        public DataLakeSasBuilder() { }
        public string CacheControl { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string ContentDisposition { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string ContentEncoding { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string ContentLanguage { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string ContentType { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public System.DateTimeOffset ExpiresOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string FileSystemName { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Identifier { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public Azure.Storage.Sas.SasIPRange IPRange { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Path { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Permissions { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.Storage.Sas.SasProtocol Protocol { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Resource { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public System.DateTimeOffset StartsOn { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Version { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public void SetPermissions(Azure.Storage.Files.DataLake.Sas.DataLakeAccountSasPermissions permissions) { }
        public void SetPermissions(Azure.Storage.Files.DataLake.Sas.DataLakeFileSystemSasPermissions permissions) { }
        public void SetPermissions(Azure.Storage.Files.DataLake.Sas.DataLakeSasPermissions permissions) { }
        public void SetPermissions(string rawPermissions) { }
        public Azure.Storage.Files.DataLake.Sas.DataLakeSasQueryParameters ToSasQueryParameters(Azure.Storage.Files.DataLake.Models.UserDelegationKey userDelegationKey, string accountName) { throw null; }
        public Azure.Storage.Files.DataLake.Sas.DataLakeSasQueryParameters ToSasQueryParameters(Azure.Storage.StorageSharedKeyCredential sharedKeyCredential) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    [System.FlagsAttribute]
    public enum DataLakeSasPermissions
    {
        All = -1,
        Read = 1,
        Add = 2,
        Create = 4,
        Write = 8,
        Delete = 16,
    }
    public sealed partial class DataLakeSasQueryParameters : Azure.Storage.Sas.SasQueryParameters
    {
        internal DataLakeSasQueryParameters() { }
        public static new Azure.Storage.Files.DataLake.Sas.DataLakeSasQueryParameters Empty { get { throw null; } }
        public System.DateTimeOffset KeyExpiresOn { get { throw null; } }
        public string KeyObjectId { get { throw null; } }
        public string KeyService { get { throw null; } }
        public System.DateTimeOffset KeyStartsOn { get { throw null; } }
        public string KeyTenantId { get { throw null; } }
        public string KeyVersion { get { throw null; } }
        public override string ToString() { throw null; }
    }
}
