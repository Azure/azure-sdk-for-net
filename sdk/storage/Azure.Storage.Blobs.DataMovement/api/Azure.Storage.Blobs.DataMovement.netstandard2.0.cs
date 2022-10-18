namespace Azure.Storage.Blobs.DataMovement
{
    public partial class BlobDirectoryStorageResourceContainer : Azure.Storage.DataMovement.StorageResourceContainer
    {
        public BlobDirectoryStorageResourceContainer(Azure.Storage.Blobs.BlobContainerClient containerClient, System.Collections.Generic.List<string> directoryPrefix) { }
        public BlobDirectoryStorageResourceContainer(Azure.Storage.Blobs.BlobContainerClient containerClient, string directoryPrefix, Azure.Storage.Blobs.DataMovement.BlobDirectoryStorageResourceContainerOptions options = null) { }
        public override Azure.Storage.DataMovement.ProduceUriType CanProduceUri() { throw null; }
        public override System.Collections.Generic.List<string> GetPath() { throw null; }
        public override Azure.Storage.DataMovement.StorageResource GetStorageResource(System.Collections.Generic.List<string> encodedPath) { throw null; }
        public override Azure.Storage.DataMovement.StorageResourceContainer GetStorageResourceContainer(System.Collections.Generic.List<string> encodedPath) { throw null; }
        public Azure.Storage.DataMovement.StorageResourceContainer GetStorageResourceParentContainer() { throw null; }
        public override System.Uri GetUri() { throw null; }
        public override System.Collections.Generic.IAsyncEnumerable<Azure.Storage.DataMovement.StorageResource> ListStorageResources([System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BlobDirectoryStorageResourceContainerOptions
    {
        public BlobDirectoryStorageResourceContainerOptions() { }
        public Azure.Storage.Blobs.Models.BlobStates States { get { throw null; } }
        public Azure.Storage.Blobs.Models.BlobTraits Traits { get { throw null; } }
    }
    public partial class BlockBlobStorageResource : Azure.Storage.DataMovement.StorageResource
    {
        public BlockBlobStorageResource(Azure.Storage.Blobs.Specialized.BlockBlobClient blobClient, Azure.Storage.Blobs.DataMovement.BlockBlobStorageResourceOptions options = null) { }
        public override Azure.Storage.DataMovement.Models.CanCommitListType CanCommitBlockListType() { throw null; }
        public override Azure.Storage.DataMovement.StreamConsumableType CanConsumeReadableStream() { throw null; }
        public override Azure.Storage.DataMovement.ProduceUriType CanProduceUri() { throw null; }
        public override System.Threading.Tasks.Task CommitBlockList(System.Collections.Generic.IEnumerable<string> base64BlockIds, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.Task ConsumePartialReadableStream(long offset, long length, System.IO.Stream stream, Azure.Storage.DataMovement.Models.ConsumePartialReadableStreamOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task ConsumeReadableStream(System.IO.Stream stream, System.Threading.CancellationToken token = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task ConsumeUri(System.Uri uri) { throw null; }
        public override System.IO.Stream GetConsumableStream() { throw null; }
        public override System.Collections.Generic.List<string> GetPath() { throw null; }
        public override System.Threading.Tasks.Task<Azure.Storage.DataMovement.Models.StorageResourceProperties> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.IO.Stream GetReadableInputStream() { throw null; }
        public override System.Uri GetUri() { throw null; }
    }
    public partial class BlockBlobStorageResourceDownloadOptions
    {
        public BlockBlobStorageResourceDownloadOptions() { }
        public Azure.Storage.Blobs.Models.BlobRequestConditions Conditions { get { throw null; } set { } }
        public Azure.Storage.DownloadTransferValidationOptions TransferValidationOptions { get { throw null; } set { } }
    }
    public partial class BlockBlobStorageResourceOptions
    {
        public BlockBlobStorageResourceOptions() { }
        public Azure.Storage.Blobs.DataMovement.BlockBlobStorageResourceDownloadOptions ConsumePartialOffsetReadableStream { get { throw null; } }
        public Azure.Storage.Blobs.DataMovement.BlockBlobStorageResourceUploadOptions UploadOptions { get { throw null; } }
    }
    public partial class BlockBlobStorageResourceUploadOptions
    {
        public BlockBlobStorageResourceUploadOptions() { }
        public Azure.Storage.Blobs.Models.AccessTier? AccessTier { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobRequestConditions Conditions { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobHttpHeaders HttpHeaders { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobImmutabilityPolicy ImmutabilityPolicy { get { throw null; } set { } }
        public bool? LegalHold { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
        public Azure.Storage.UploadTransferValidationOptions TransferValidationOptions { get { throw null; } set { } }
    }
}
