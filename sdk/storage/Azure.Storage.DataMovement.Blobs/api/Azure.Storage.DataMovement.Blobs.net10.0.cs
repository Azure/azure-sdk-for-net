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
        public BlobsStorageResourceProvider(Azure.Storage.StorageSharedKeyCredential credential) { }
        public BlobsStorageResourceProvider(System.Func<System.Uri, System.Threading.CancellationToken, System.Threading.Tasks.ValueTask<Azure.AzureSasCredential>> getAzureSasCredentialAsync) { }
        public BlobsStorageResourceProvider(System.Func<System.Uri, System.Threading.CancellationToken, System.Threading.Tasks.ValueTask<Azure.Storage.StorageSharedKeyCredential>> getStorageSharedKeyCredentialAsync) { }
        protected override string ProviderId { get { throw null; } }
        public System.Threading.Tasks.ValueTask<Azure.Storage.DataMovement.StorageResource> FromBlobAsync(System.Uri blobUri, Azure.Storage.DataMovement.Blobs.BlobStorageResourceOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Storage.DataMovement.StorageResource FromClient(Azure.Storage.Blobs.BlobContainerClient client, Azure.Storage.DataMovement.Blobs.BlobStorageResourceContainerOptions options = null) { throw null; }
        public static Azure.Storage.DataMovement.StorageResource FromClient(Azure.Storage.Blobs.Specialized.AppendBlobClient client, Azure.Storage.DataMovement.Blobs.AppendBlobStorageResourceOptions options = null) { throw null; }
        public static Azure.Storage.DataMovement.StorageResource FromClient(Azure.Storage.Blobs.Specialized.BlockBlobClient client, Azure.Storage.DataMovement.Blobs.BlockBlobStorageResourceOptions options = null) { throw null; }
        public static Azure.Storage.DataMovement.StorageResource FromClient(Azure.Storage.Blobs.Specialized.PageBlobClient client, Azure.Storage.DataMovement.Blobs.PageBlobStorageResourceOptions options = null) { throw null; }
        public System.Threading.Tasks.ValueTask<Azure.Storage.DataMovement.StorageResource> FromContainerAsync(System.Uri containerUri, Azure.Storage.DataMovement.Blobs.BlobStorageResourceContainerOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        protected override System.Threading.Tasks.ValueTask<Azure.Storage.DataMovement.StorageResource> FromDestinationAsync(Azure.Storage.DataMovement.TransferProperties properties, System.Threading.CancellationToken cancellationToken) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        protected override System.Threading.Tasks.ValueTask<Azure.Storage.DataMovement.StorageResource> FromSourceAsync(Azure.Storage.DataMovement.TransferProperties properties, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class BlobStorageResourceContainerOptions
    {
        public BlobStorageResourceContainerOptions() { }
        public Azure.Storage.DataMovement.Blobs.BlobStorageResourceOptions BlobOptions { get { throw null; } set { } }
        public string BlobPrefix { get { throw null; } set { } }
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
