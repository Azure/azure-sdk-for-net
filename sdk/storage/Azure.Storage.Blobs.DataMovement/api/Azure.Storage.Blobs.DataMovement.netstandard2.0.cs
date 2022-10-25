namespace Azure.Storage.Blobs.DataMovement
{
    public partial class AppendBlobStorageResource : Azure.Storage.DataMovement.StorageResource
    {
        public AppendBlobStorageResource(Azure.Storage.Blobs.Specialized.AppendBlobClient blobClient, Azure.Storage.Blobs.DataMovement.AppendBlobStorageResourceOptions options = null) { }
        public override Azure.Storage.DataMovement.StreamConsumableType CanCreateOpenReadStream { get { throw null; } }
        public override Azure.Storage.DataMovement.ProduceUriType CanProduceUri { get { throw null; } }
        public override System.Collections.Generic.List<string> Path { get { throw null; } }
        public override Azure.Storage.DataMovement.Models.RequiresCompleteTransferType RequiresCompleteTransfer { get { throw null; } }
        public override System.Uri Uri { get { throw null; } }
        public override System.Threading.Tasks.Task CompleteTransferAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.Task CopyFromUriAsync(System.Uri uri) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Storage.DataMovement.Models.StorageResourceProperties> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.Task<System.IO.Stream> OpenReadStreamAsync(long? position = default(long?)) { throw null; }
        public override System.Threading.Tasks.Task<System.IO.Stream> OpenWriteStreamAsync() { throw null; }
        public override System.Threading.Tasks.Task WriteFromStreamAsync(System.IO.Stream stream, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.Task WriteStreamToOffsetAsync(long offset, long length, System.IO.Stream stream, Azure.Storage.DataMovement.Models.ConsumePartialReadableStreamOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppendBlobStorageResourceOptions
    {
        public AppendBlobStorageResourceOptions() { }
        public Azure.Storage.Blobs.DataMovement.AppendBlobStorageResourceServiceCopyOptions CopyOptions { get { throw null; } set { } }
        public Azure.Storage.Blobs.DataMovement.BlobStorageResourceDownloadOptions DownloadOptions { get { throw null; } set { } }
        public Azure.Storage.Blobs.DataMovement.AppendBlobStorageResourceUploadOptions UploadOptions { get { throw null; } set { } }
    }
    public partial class AppendBlobStorageResourceServiceCopyOptions
    {
        public AppendBlobStorageResourceServiceCopyOptions() { }
        public Azure.Storage.DataMovement.Models.TransferCopyMethod CopyMethod { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.AppendBlobRequestConditions DestinationConditions { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.AppendBlobRequestConditions SourceConditions { get { throw null; } set { } }
    }
    public partial class AppendBlobStorageResourceUploadOptions
    {
        public AppendBlobStorageResourceUploadOptions() { }
        public Azure.Storage.Blobs.Models.AppendBlobRequestConditions Conditions { get { throw null; } set { } }
        public Azure.Storage.DataMovement.Models.TransferCopyMethod CopyMethod { get { throw null; } set { } }
        public Azure.Storage.UploadTransferValidationOptions TransferValidationOptions { get { throw null; } set { } }
    }
    public partial class BlobDirectoryStorageResourceContainer : Azure.Storage.DataMovement.StorageResourceContainer
    {
        public BlobDirectoryStorageResourceContainer(Azure.Storage.Blobs.BlobContainerClient containerClient, System.Collections.Generic.List<string> directoryPrefix) { }
        public BlobDirectoryStorageResourceContainer(Azure.Storage.Blobs.BlobContainerClient containerClient, string directoryPrefix, Azure.Storage.Blobs.DataMovement.BlobDirectoryStorageResourceContainerOptions options = null) { }
        public override Azure.Storage.DataMovement.ProduceUriType CanProduceUri { get { throw null; } }
        public override System.Collections.Generic.List<string> Path { get { throw null; } }
        public override System.Uri Uri { get { throw null; } }
        public override Azure.Storage.DataMovement.StorageResource GetChildStorageResource(System.Collections.Generic.List<string> encodedPath) { throw null; }
        public override Azure.Storage.DataMovement.StorageResourceContainer GetParentStorageResourceContainer(System.Collections.Generic.List<string> encodedPath) { throw null; }
        public Azure.Storage.DataMovement.StorageResourceContainer GetStorageResourceParentContainer() { throw null; }
        public override System.Collections.Generic.IAsyncEnumerable<Azure.Storage.DataMovement.StorageResource> GetStorageResources([System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BlobDirectoryStorageResourceContainerOptions
    {
        public BlobDirectoryStorageResourceContainerOptions() { }
        public Azure.Storage.Blobs.DataMovement.BlockBlobStorageResourceServiceCopyOptions CopyOptions { get { throw null; } set { } }
        public Azure.Storage.Blobs.DataMovement.BlobStorageResourceDownloadOptions DownloadOptions { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobStates States { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobTraits Traits { get { throw null; } set { } }
        public Azure.Storage.Blobs.DataMovement.BlockBlobStorageResourceUploadOptions UploadOptions { get { throw null; } set { } }
    }
    public partial class BlobStorageResourceDownloadOptions
    {
        public BlobStorageResourceDownloadOptions() { }
        public Azure.Storage.Blobs.Models.BlobRequestConditions Conditions { get { throw null; } set { } }
        public Azure.Storage.DownloadTransferValidationOptions TransferValidationOptions { get { throw null; } set { } }
    }
    public partial class BlockBlobStorageResource : Azure.Storage.DataMovement.StorageResource
    {
        public BlockBlobStorageResource(Azure.Storage.Blobs.Specialized.BlockBlobClient blobClient, Azure.Storage.Blobs.DataMovement.BlockBlobStorageResourceOptions options = null) { }
        public override Azure.Storage.DataMovement.StreamConsumableType CanCreateOpenReadStream { get { throw null; } }
        public override Azure.Storage.DataMovement.ProduceUriType CanProduceUri { get { throw null; } }
        public override System.Collections.Generic.List<string> Path { get { throw null; } }
        public override Azure.Storage.DataMovement.Models.RequiresCompleteTransferType RequiresCompleteTransfer { get { throw null; } }
        public override System.Uri Uri { get { throw null; } }
        public override System.Threading.Tasks.Task CompleteTransferAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.Task CopyFromUriAsync(System.Uri uri) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Storage.DataMovement.Models.StorageResourceProperties> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.Task<System.IO.Stream> OpenReadStreamAsync(long? position = default(long?)) { throw null; }
        public override System.Threading.Tasks.Task<System.IO.Stream> OpenWriteStreamAsync() { throw null; }
        public override System.Threading.Tasks.Task WriteFromStreamAsync(System.IO.Stream stream, System.Threading.CancellationToken token = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task WriteStreamToOffsetAsync(long offset, long length, System.IO.Stream stream, Azure.Storage.DataMovement.Models.ConsumePartialReadableStreamOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BlockBlobStorageResourceOptions
    {
        public BlockBlobStorageResourceOptions() { }
        public Azure.Storage.Blobs.DataMovement.BlockBlobStorageResourceServiceCopyOptions CopyOptions { get { throw null; } set { } }
        public Azure.Storage.Blobs.DataMovement.BlobStorageResourceDownloadOptions DownloadOptions { get { throw null; } set { } }
        public Azure.Storage.Blobs.DataMovement.BlockBlobStorageResourceUploadOptions UploadOptions { get { throw null; } set { } }
    }
    public partial class BlockBlobStorageResourceServiceCopyOptions
    {
        public BlockBlobStorageResourceServiceCopyOptions() { }
        public Azure.Storage.Blobs.Models.AccessTier? AccessTier { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobRequestConditions Conditions { get { throw null; } set { } }
        public Azure.Storage.DataMovement.Models.TransferCopyMethod CopyMethod { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobCopySourceTagsMode? CopySourceTagsMode { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobImmutabilityPolicy DestinationImmutabilityPolicy { get { throw null; } set { } }
        public bool? LegalHold { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.RehydratePriority? RehydratePriority { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
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
    public partial class PageBlobStorageResource : Azure.Storage.DataMovement.StorageResource
    {
        public PageBlobStorageResource(Azure.Storage.Blobs.Specialized.PageBlobClient blobClient, Azure.Storage.Blobs.DataMovement.PageBlobStorageResourceOptions options = null) { }
        public override Azure.Storage.DataMovement.StreamConsumableType CanCreateOpenReadStream { get { throw null; } }
        public override Azure.Storage.DataMovement.ProduceUriType CanProduceUri { get { throw null; } }
        public override System.Collections.Generic.List<string> Path { get { throw null; } }
        public override Azure.Storage.DataMovement.Models.RequiresCompleteTransferType RequiresCompleteTransfer { get { throw null; } }
        public override System.Uri Uri { get { throw null; } }
        public override System.Threading.Tasks.Task CompleteTransferAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.Task CopyFromUriAsync(System.Uri uri) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Storage.DataMovement.Models.StorageResourceProperties> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.Task<System.IO.Stream> OpenReadStreamAsync(long? position = default(long?)) { throw null; }
        public override System.Threading.Tasks.Task<System.IO.Stream> OpenWriteStreamAsync() { throw null; }
        public override System.Threading.Tasks.Task WriteFromStreamAsync(System.IO.Stream stream, System.Threading.CancellationToken token) { throw null; }
        public override System.Threading.Tasks.Task WriteStreamToOffsetAsync(long offset, long length, System.IO.Stream stream, Azure.Storage.DataMovement.Models.ConsumePartialReadableStreamOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PageBlobStorageResourceOptions
    {
        public PageBlobStorageResourceOptions() { }
        public Azure.Storage.Blobs.DataMovement.PageBlobStorageResourceServiceCopyOptions CopyOptions { get { throw null; } set { } }
        public Azure.Storage.Blobs.DataMovement.BlobStorageResourceDownloadOptions DownloadOptions { get { throw null; } set { } }
        public Azure.Storage.Blobs.DataMovement.PageBlobStorageResourceUploadOptions UploadOptions { get { throw null; } set { } }
    }
    public partial class PageBlobStorageResourceServiceCopyOptions
    {
        public PageBlobStorageResourceServiceCopyOptions() { }
        public Azure.Storage.DataMovement.Models.TransferCopyMethod CopyMethod { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.PageBlobRequestConditions DestinationConditions { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.PageBlobRequestConditions SourceConditions { get { throw null; } set { } }
    }
    public partial class PageBlobStorageResourceUploadOptions
    {
        public PageBlobStorageResourceUploadOptions() { }
        public Azure.Storage.Blobs.Models.PageBlobRequestConditions Conditions { get { throw null; } set { } }
        public Azure.Storage.UploadTransferValidationOptions TransferValidationOptions { get { throw null; } set { } }
    }
}
