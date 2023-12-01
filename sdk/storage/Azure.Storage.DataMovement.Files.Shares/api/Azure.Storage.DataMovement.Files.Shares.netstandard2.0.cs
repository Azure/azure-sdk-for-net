namespace Azure.Storage.DataMovement.Files.Shares
{
    public partial class ShareDirectoryClientTransferOptions
    {
        public ShareDirectoryClientTransferOptions() { }
        public Azure.Storage.DataMovement.Files.Shares.ShareFileStorageResourceOptions ShareDirectoryOptions { get { throw null; } set { } }
        public Azure.Storage.DataMovement.DataTransferOptions TransferOptions { get { throw null; } set { } }
    }
    public partial class ShareFilesStorageResourceProvider : Azure.Storage.DataMovement.StorageResourceProvider
    {
        public ShareFilesStorageResourceProvider() { }
        public ShareFilesStorageResourceProvider(Azure.AzureSasCredential credential) { }
        public ShareFilesStorageResourceProvider(Azure.Core.TokenCredential credential) { }
        public ShareFilesStorageResourceProvider(Azure.Storage.DataMovement.Files.Shares.ShareFilesStorageResourceProvider.GetAzureSasCredential getAzureSasCredentialAsync) { }
        public ShareFilesStorageResourceProvider(Azure.Storage.DataMovement.Files.Shares.ShareFilesStorageResourceProvider.GetStorageSharedKeyCredential getStorageSharedKeyCredentialAsync) { }
        public ShareFilesStorageResourceProvider(Azure.Storage.DataMovement.Files.Shares.ShareFilesStorageResourceProvider.GetTokenCredential getTokenCredentialAsync) { }
        public ShareFilesStorageResourceProvider(Azure.Storage.StorageSharedKeyCredential credential) { }
        protected override string ProviderId { get { throw null; } }
        public Azure.Storage.DataMovement.StorageResource FromClient(Azure.Storage.Files.Shares.ShareDirectoryClient client, Azure.Storage.DataMovement.Files.Shares.ShareFileStorageResourceOptions options = null) { throw null; }
        public Azure.Storage.DataMovement.StorageResource FromClient(Azure.Storage.Files.Shares.ShareFileClient client, Azure.Storage.DataMovement.Files.Shares.ShareFileStorageResourceOptions options = null) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.Storage.DataMovement.StorageResource> FromDestinationAsync(Azure.Storage.DataMovement.DataTransferProperties properties, System.Threading.CancellationToken cancellationToken) { throw null; }
        public Azure.Storage.DataMovement.StorageResource FromDirectory(string directoryUri, Azure.Storage.DataMovement.Files.Shares.ShareFileStorageResourceOptions options = null) { throw null; }
        public Azure.Storage.DataMovement.StorageResource FromFile(string fileUri, Azure.Storage.DataMovement.Files.Shares.ShareFileStorageResourceOptions options = null) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.Storage.DataMovement.StorageResource> FromSourceAsync(Azure.Storage.DataMovement.DataTransferProperties properties, System.Threading.CancellationToken cancellationToken) { throw null; }
        public delegate Azure.AzureSasCredential GetAzureSasCredential(string uri, bool readOnly);
        public delegate Azure.Storage.StorageSharedKeyCredential GetStorageSharedKeyCredential(string uri, bool readOnly);
        public delegate Azure.Core.TokenCredential GetTokenCredential(string uri, bool readOnly);
    }
    public partial class ShareFileStorageResourceOptions
    {
        public ShareFileStorageResourceOptions() { }
        public Azure.Storage.Files.Shares.Models.ShareFileRequestConditions DestinationConditions { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> DirectoryMetadata { get { throw null; } set { } }
        public Azure.Storage.DownloadTransferValidationOptions DownloadTransferValidationOptions { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> FileMetadata { get { throw null; } set { } }
        public string FilePermissions { get { throw null; } set { } }
        public Azure.Storage.Files.Shares.Models.ShareFileHttpHeaders HttpHeaders { get { throw null; } set { } }
        public Azure.Storage.Files.Shares.Models.FileSmbProperties SmbProperties { get { throw null; } set { } }
        public Azure.Storage.Files.Shares.Models.ShareFileRequestConditions SourceConditions { get { throw null; } set { } }
        public Azure.Storage.UploadTransferValidationOptions UploadTransferValidationOptions { get { throw null; } set { } }
    }
}
namespace Azure.Storage.Files.Shares
{
    public static partial class ShareDirectoryClientExtensions
    {
        public static System.Threading.Tasks.Task<Azure.Storage.DataMovement.DataTransfer> StartDownloadToDirectoryAsync(this Azure.Storage.Files.Shares.ShareDirectoryClient client, string localDirectoryPath, Azure.Storage.DataMovement.Files.Shares.ShareDirectoryClientTransferOptions options = null) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Storage.DataMovement.DataTransfer> StartUploadDirectoryAsync(this Azure.Storage.Files.Shares.ShareDirectoryClient client, string localDirectoryPath, Azure.Storage.DataMovement.Files.Shares.ShareDirectoryClientTransferOptions options = null) { throw null; }
    }
}
