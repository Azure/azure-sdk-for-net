namespace Azure.Storage.DataMovement.Blobs
{
    public partial class AppendBlobStorageResource : Azure.Storage.DataMovement.StorageResource
    {
        public AppendBlobStorageResource(Azure.Storage.Blobs.Specialized.AppendBlobClient blobClient, Azure.Storage.DataMovement.Blobs.AppendBlobStorageResourceOptions options = null) { }
        public override Azure.Storage.DataMovement.ProduceUriType CanProduceUri { get { throw null; } }
        public override long? Length { get { throw null; } }
        public override long MaxChunkSize { get { throw null; } }
        public override string Path { get { throw null; } }
        public override Azure.Storage.DataMovement.Models.TransferCopyMethod ServiceCopyMethod { get { throw null; } }
        public override Azure.Storage.DataMovement.TransferType TransferType { get { throw null; } }
        public override System.Uri Uri { get { throw null; } }
        public override System.Threading.Tasks.Task CompleteTransferAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task CopyBlockFromUriAsync(Azure.Storage.DataMovement.StorageResource sourceResource, Azure.HttpRange range, bool overwrite, long completeLength = (long)0, Azure.Storage.DataMovement.Models.StorageResourceCopyFromUriOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task CopyFromUriAsync(Azure.Storage.DataMovement.StorageResource sourceResource, bool overwrite, long completeLength, Azure.Storage.DataMovement.Models.StorageResourceCopyFromUriOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Storage.DataMovement.Models.StorageResourceProperties> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Storage.DataMovement.Models.ReadStreamStorageResourceResult> ReadStreamAsync(long position = (long)0, long? length = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task WriteFromStreamAsync(System.IO.Stream stream, long streamLength, bool overwrite, long position = (long)0, long completeLength = (long)0, Azure.Storage.DataMovement.Models.StorageResourceWriteToOffsetOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppendBlobStorageResourceOptions
    {
        public AppendBlobStorageResourceOptions() { }
        public Azure.Storage.Blobs.Models.AccessTier? AccessTier { get { throw null; } set { } }
        public Azure.Storage.DataMovement.Models.TransferCopyMethod CopyMethod { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobCopySourceTagsMode? CopySourceTagsMode { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.AppendBlobRequestConditions DestinationConditions { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobImmutabilityPolicy DestinationImmutabilityPolicy { get { throw null; } set { } }
        public Azure.Storage.DownloadTransferValidationOptions DownloadTransferValidationOptions { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobHttpHeaders HttpHeaders { get { throw null; } set { } }
        public bool? LegalHold { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.RehydratePriority? RehydratePriority { get { throw null; } set { } }
        public bool? ShouldSealDestination { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.AppendBlobRequestConditions SourceConditions { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
        public Azure.Storage.UploadTransferValidationOptions UploadTransferValidationOptions { get { throw null; } set { } }
    }
    public partial class BlobDirectoryStorageResourceContainer : Azure.Storage.DataMovement.StorageResourceContainer
    {
        public BlobDirectoryStorageResourceContainer(Azure.Storage.Blobs.BlobContainerClient containerClient, string directoryPrefix, Azure.Storage.DataMovement.Blobs.BlobStorageResourceContainerOptions options = null) { }
        public override Azure.Storage.DataMovement.ProduceUriType CanProduceUri { get { throw null; } }
        public override string Path { get { throw null; } }
        public override System.Uri Uri { get { throw null; } }
        public override Azure.Storage.DataMovement.StorageResource GetChildStorageResource(string path) { throw null; }
        public override Azure.Storage.DataMovement.StorageResourceContainer GetParentStorageResourceContainer() { throw null; }
        public override System.Collections.Generic.IAsyncEnumerable<Azure.Storage.DataMovement.StorageResourceBase> GetStorageResourcesAsync([System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BlobStorageResourceContainer : Azure.Storage.DataMovement.StorageResourceContainer
    {
        public BlobStorageResourceContainer(Azure.Storage.Blobs.BlobContainerClient blobContainerClient, Azure.Storage.DataMovement.Blobs.BlobStorageResourceContainerOptions options = null) { }
        public override Azure.Storage.DataMovement.ProduceUriType CanProduceUri { get { throw null; } }
        public override string Path { get { throw null; } }
        public override System.Uri Uri { get { throw null; } }
        public override Azure.Storage.DataMovement.StorageResource GetChildStorageResource(string path) { throw null; }
        public override Azure.Storage.DataMovement.StorageResourceContainer GetParentStorageResourceContainer() { throw null; }
        public override System.Collections.Generic.IAsyncEnumerable<Azure.Storage.DataMovement.StorageResourceBase> GetStorageResourcesAsync([System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BlobStorageResourceContainerOptions
    {
        public BlobStorageResourceContainerOptions() { }
        public Azure.Storage.DataMovement.Models.TransferCopyMethod CopyMethod { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobStates States { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobTraits Traits { get { throw null; } set { } }
    }
    public partial class BlockBlobStorageResource : Azure.Storage.DataMovement.StorageResource
    {
        public BlockBlobStorageResource(Azure.Storage.Blobs.Specialized.BlockBlobClient blobClient, Azure.Storage.DataMovement.Blobs.BlockBlobStorageResourceOptions options = null) { }
        public override Azure.Storage.DataMovement.ProduceUriType CanProduceUri { get { throw null; } }
        public override long? Length { get { throw null; } }
        public override long MaxChunkSize { get { throw null; } }
        public override string Path { get { throw null; } }
        public override Azure.Storage.DataMovement.Models.TransferCopyMethod ServiceCopyMethod { get { throw null; } }
        public override Azure.Storage.DataMovement.TransferType TransferType { get { throw null; } }
        public override System.Uri Uri { get { throw null; } }
        public override System.Threading.Tasks.Task CompleteTransferAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task CopyBlockFromUriAsync(Azure.Storage.DataMovement.StorageResource sourceResource, Azure.HttpRange range, bool overwrite, long completeLength = (long)0, Azure.Storage.DataMovement.Models.StorageResourceCopyFromUriOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task CopyFromUriAsync(Azure.Storage.DataMovement.StorageResource sourceResource, bool overwrite, long completeLength, Azure.Storage.DataMovement.Models.StorageResourceCopyFromUriOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Storage.DataMovement.Models.StorageResourceProperties> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Storage.DataMovement.Models.ReadStreamStorageResourceResult> ReadStreamAsync(long position = (long)0, long? length = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task WriteFromStreamAsync(System.IO.Stream stream, long streamLength, bool overwrite, long position = (long)0, long completeLength = (long)0, Azure.Storage.DataMovement.Models.StorageResourceWriteToOffsetOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BlockBlobStorageResourceOptions
    {
        public BlockBlobStorageResourceOptions() { }
        public Azure.Storage.Blobs.Models.AccessTier? AccessTier { get { throw null; } set { } }
        public Azure.Storage.DataMovement.Models.TransferCopyMethod CopyMethod { get { throw null; } set { } }
        public bool? CopySourceBlobProperties { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobCopySourceTagsMode? CopySourceTagsMode { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobRequestConditions DestinationConditions { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobImmutabilityPolicy DestinationImmutabilityPolicy { get { throw null; } set { } }
        public Azure.Storage.DownloadTransferValidationOptions DownloadTransferValidationOptions { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobHttpHeaders HttpHeaders { get { throw null; } set { } }
        public bool? LegalHold { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.RehydratePriority? RehydratePriority { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobRequestConditions SourceConditions { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
        public Azure.Storage.UploadTransferValidationOptions UploadTransferValidationOptions { get { throw null; } set { } }
    }
    public partial class PageBlobStorageResource : Azure.Storage.DataMovement.StorageResource
    {
        public PageBlobStorageResource(Azure.Storage.Blobs.Specialized.PageBlobClient blobClient, Azure.Storage.DataMovement.Blobs.PageBlobStorageResourceOptions options = null) { }
        public override Azure.Storage.DataMovement.ProduceUriType CanProduceUri { get { throw null; } }
        public override long? Length { get { throw null; } }
        public override long MaxChunkSize { get { throw null; } }
        public override string Path { get { throw null; } }
        public override Azure.Storage.DataMovement.Models.TransferCopyMethod ServiceCopyMethod { get { throw null; } }
        public override Azure.Storage.DataMovement.TransferType TransferType { get { throw null; } }
        public override System.Uri Uri { get { throw null; } }
        public override System.Threading.Tasks.Task CompleteTransferAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task CopyBlockFromUriAsync(Azure.Storage.DataMovement.StorageResource sourceResource, Azure.HttpRange range, bool overwrite, long completeLength = (long)0, Azure.Storage.DataMovement.Models.StorageResourceCopyFromUriOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task CopyFromUriAsync(Azure.Storage.DataMovement.StorageResource sourceResource, bool overwrite, long completeLength, Azure.Storage.DataMovement.Models.StorageResourceCopyFromUriOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Storage.DataMovement.Models.StorageResourceProperties> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<Azure.Storage.DataMovement.Models.ReadStreamStorageResourceResult> ReadStreamAsync(long position = (long)0, long? length = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task WriteFromStreamAsync(System.IO.Stream stream, long streamLength, bool overwrite, long position = (long)0, long completeLength = (long)0, Azure.Storage.DataMovement.Models.StorageResourceWriteToOffsetOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PageBlobStorageResourceOptions
    {
        public PageBlobStorageResourceOptions() { }
        public Azure.Storage.Blobs.Models.AccessTier? AccessTier { get { throw null; } set { } }
        public Azure.Storage.DataMovement.Models.TransferCopyMethod CopyMethod { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobCopySourceTagsMode? CopySourceTagsMode { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.PageBlobRequestConditions DestinationConditions { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobImmutabilityPolicy DestinationImmutabilityPolicy { get { throw null; } set { } }
        public Azure.Storage.DownloadTransferValidationOptions DownloadTransferValidationOptions { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.BlobHttpHeaders HttpHeaders { get { throw null; } set { } }
        public bool? LegalHold { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.RehydratePriority? RehydratePriority { get { throw null; } set { } }
        public long? SequenceNumber { get { throw null; } set { } }
        public Azure.Storage.Blobs.Models.PageBlobRequestConditions SourceConditions { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
        public Azure.Storage.UploadTransferValidationOptions UploadTransferValidationOptions { get { throw null; } set { } }
    }
}
