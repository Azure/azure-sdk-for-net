namespace Azure.Storage.Blobs.DataMovement
{
    public partial class BlobDirectoryStorageResourceContainer : Azure.Storage.DataMovement.StorageResourceContainer
    {
        public BlobDirectoryStorageResourceContainer(Azure.Storage.Blobs.BlobContainerClient containerClient, System.Collections.Generic.List<string> directoryPrefix) { }
        public BlobDirectoryStorageResourceContainer(Azure.Storage.Blobs.BlobContainerClient containerClient, string directoryPrefix) { }
        public override Azure.Storage.DataMovement.ProduceUriType CanProduceUri() { throw null; }
        public override System.Collections.Generic.List<string> GetPath() { throw null; }
        public override Azure.Storage.DataMovement.StorageResource GetStorageResource(System.Collections.Generic.List<string> encodedPath) { throw null; }
        public override Azure.Storage.DataMovement.StorageResourceContainer GetStorageResourceContainer(System.Collections.Generic.List<string> encodedPath) { throw null; }
        public Azure.Storage.DataMovement.StorageResourceContainer GetStorageResourceParentContainer() { throw null; }
        public override System.Uri GetUri() { throw null; }
        public override System.Collections.Generic.IAsyncEnumerable<Azure.Storage.DataMovement.StorageResource> ListStorageResources(Azure.Storage.DataMovement.Models.ListStorageResourceOptions options = null, [System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BlockBlobStorageResource : Azure.Storage.DataMovement.StorageResource
    {
        public BlockBlobStorageResource(Azure.Storage.Blobs.Specialized.BlockBlobClient blobClient) { }
        public override Azure.Storage.DataMovement.Models.CanCommitListType CanCommitBlockListType() { throw null; }
        public override Azure.Storage.DataMovement.StreamConsumableType CanConsumeReadableStream() { throw null; }
        public override Azure.Storage.DataMovement.ProduceUriType CanProduceUri() { throw null; }
        public override System.Threading.Tasks.Task CommitBlockList(System.Collections.Generic.IEnumerable<string> base64BlockIds, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.Task ConsumePartialOffsetReadableStream(long offset, long length, System.IO.Stream stream, Azure.Storage.DataMovement.Models.ConsumePartialReadableStreamOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task ConsumeReadableStream(System.IO.Stream stream, Azure.Storage.DataMovement.Models.ConsumeReadableStreamOptions options, System.Threading.CancellationToken token = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task ConsumeUri(System.Uri uri) { throw null; }
        public override System.IO.Stream GetConsumableStream() { throw null; }
        public override System.Collections.Generic.List<string> GetPath() { throw null; }
        public override System.Threading.Tasks.Task<Azure.Storage.DataMovement.Models.StorageResourceProperties> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.IO.Stream GetReadableInputStream() { throw null; }
        public override System.Uri GetUri() { throw null; }
    }
}
