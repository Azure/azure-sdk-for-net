namespace Azure.Storage.Blobs
{
    public static partial class BlobContainerClientExtensions
    {
        public static System.Threading.Tasks.Task<Azure.Storage.DataMovement.TransferOperation> DownloadToDirectoryAsync(this Azure.Storage.Blobs.BlobContainerClient client, Azure.WaitUntil waitUntil, string localDirectoryPath, Azure.Storage.DataMovement.Blobs.BlobContainerClientTransferOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Storage.DataMovement.TransferOperation> DownloadToDirectoryAsync(this Azure.Storage.Blobs.BlobContainerClient client, Azure.WaitUntil waitUntil, string localDirectoryPath, string blobDirectoryPrefix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Storage.DataMovement.TransferOperation> UploadDirectoryAsync(this Azure.Storage.Blobs.BlobContainerClient client, Azure.WaitUntil waitUntil, string localDirectoryPath, Azure.Storage.DataMovement.Blobs.BlobContainerClientTransferOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Storage.DataMovement.TransferOperation> UploadDirectoryAsync(this Azure.Storage.Blobs.BlobContainerClient client, Azure.WaitUntil waitUntil, string localDirectoryPath, string blobDirectoryPrefix = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.Storage.DataMovement.Blobs
{
    public partial class AppendBlobStorageResourceOptions : Azure.Storage.DataMovement.Blobs.BlobStorageResourceOptions
    {
        public AppendBlobStorageResourceOptions() { }
        public Azure.Storage.Blobs.Models.AppendBlobRequestConditions DestinationConditions { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.AppendBlobRequestConditions SourceConditions { get { throw null; } set { } }
    }
    public partial class BlobContainerClientTransferOptions
    {
        public BlobContainerClientTransferOptions() { }
        public Azure.Storage.DataMovement.Blobs.BlobStorageResourceContainerOptions BlobContainerOptions { get { throw null; } set { } }
        public Azure.Storage.DataMovement.TransferOptions TransferOptions { get { throw null; } set { } }
    }
    public partial class BlobsStorageResourceProvider : Azure.Storage.DataMovement.StorageResourceProvider
    {
        public BlobsStorageResourceProvider() { }
        public BlobsStorageResourceProvider(Azure.AzureSasCredential credential) { }
        public BlobsStorageResourceProvider(Azure.Core.TokenCredential credential) { }
        public BlobsStorageResourceProvider(Azure.Storage.DataMovement.Blobs.BlobsStorageResourceProvider.GetAzureSasCredential getAzureSasCredentialAsync) { }
        public BlobsStorageResourceProvider(Azure.Storage.DataMovement.Blobs.BlobsStorageResourceProvider.GetStorageSharedKeyCredential getStorageSharedKeyCredentialAsync) { }
        public BlobsStorageResourceProvider(Azure.Storage.DataMovement.Blobs.BlobsStorageResourceProvider.GetTokenCredential getTokenCredentialAsync) { }
        public BlobsStorageResourceProvider(Azure.Storage.StorageSharedKeyCredential credential) { }
        protected override string ProviderId { get { throw null; } }
        public Azure.Storage.DataMovement.StorageResource FromBlob(System.Uri blobUri, Azure.Storage.DataMovement.Blobs.BlobStorageResourceOptions options = null) { throw null; }
        public Azure.Storage.DataMovement.StorageResource FromClient(Azure.Storage.Blobs.BlobContainerClient client, Azure.Storage.DataMovement.Blobs.BlobStorageResourceContainerOptions options = null) { throw null; }
        public Azure.Storage.DataMovement.StorageResource FromClient(Azure.Storage.Blobs.Specialized.AppendBlobClient client, Azure.Storage.DataMovement.Blobs.AppendBlobStorageResourceOptions options = null) { throw null; }
        public Azure.Storage.DataMovement.StorageResource FromClient(Azure.Storage.Blobs.Specialized.BlockBlobClient client, Azure.Storage.DataMovement.Blobs.BlockBlobStorageResourceOptions options = null) { throw null; }
        public Azure.Storage.DataMovement.StorageResource FromClient(Azure.Storage.Blobs.Specialized.PageBlobClient client, Azure.Storage.DataMovement.Blobs.PageBlobStorageResourceOptions options = null) { throw null; }
        public Azure.Storage.DataMovement.StorageResource FromContainer(System.Uri containerUri, Azure.Storage.DataMovement.Blobs.BlobStorageResourceContainerOptions options = null) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.Storage.DataMovement.StorageResource> FromDestinationAsync(Azure.Storage.DataMovement.TransferProperties properties, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.Storage.DataMovement.StorageResource> FromSourceAsync(Azure.Storage.DataMovement.TransferProperties properties, System.Threading.CancellationToken cancellationToken) { throw null; }
        public delegate Azure.AzureSasCredential GetAzureSasCredential(System.Uri uri, bool readOnly);
        public delegate Azure.Storage.StorageSharedKeyCredential GetStorageSharedKeyCredential(System.Uri uri, bool readOnly);
        public delegate Azure.Core.TokenCredential GetTokenCredential(System.Uri uri, bool readOnly);
    }
    public partial class BlobStorageResourceContainerOptions
    {
        public BlobStorageResourceContainerOptions() { }
        public string BlobDirectoryPrefix { get { throw null; } set { } }
        public Azure.Storage.DataMovement.Blobs.BlobStorageResourceOptions BlobOptions { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobType? BlobType { get { throw null; } set { } }
    }
    public partial class BlobStorageResourceOptions
    {
        public BlobStorageResourceOptions() { }
        public Azure.Storage.Blobs.Models.AccessTier? AccessTier { get { throw null; } set { } }
        public string CacheControl { get { throw null; } set { } }
        public string ContentDisposition { get { throw null; } set { } }
        public string ContentEncoding { get { throw null; } set { } }
        public string ContentLanguage { get { throw null; } set { } }
        public string ContentType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
    }
    public partial class BlockBlobStorageResourceOptions : Azure.Storage.DataMovement.Blobs.BlobStorageResourceOptions
    {
        public BlockBlobStorageResourceOptions() { }
        public Azure.Storage.Blobs.Models.BlobRequestConditions DestinationConditions { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobRequestConditions SourceConditions { get { throw null; } set { } }
    }
    public partial class PageBlobStorageResourceOptions : Azure.Storage.DataMovement.Blobs.BlobStorageResourceOptions
    {
        public PageBlobStorageResourceOptions() { }
        public Azure.Storage.Blobs.Models.PageBlobRequestConditions DestinationConditions { get { throw null; } set { } }
        public long? SequenceNumber { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.PageBlobRequestConditions SourceConditions { get { throw null; } set { } }
    }
}
