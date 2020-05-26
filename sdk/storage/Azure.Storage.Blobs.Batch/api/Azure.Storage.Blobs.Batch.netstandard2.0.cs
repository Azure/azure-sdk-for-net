namespace Azure.Storage.Blobs.Specialized
{
    public partial class BlobBatch : System.IDisposable
    {
        protected BlobBatch() { }
        public BlobBatch(Azure.Storage.Blobs.Specialized.BlobBatchClient client) { }
        public int RequestCount { get { throw null; } }
        public virtual Azure.Response DeleteBlob(string blobContainerName, string blobName, Azure.Storage.Blobs.Models.DeleteSnapshotsOption snapshotsOption = Azure.Storage.Blobs.Models.DeleteSnapshotsOption.None, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null) { throw null; }
        public virtual Azure.Response DeleteBlob(System.Uri blobUri, Azure.Storage.Blobs.Models.DeleteSnapshotsOption snapshotsOption = Azure.Storage.Blobs.Models.DeleteSnapshotsOption.None, Azure.Storage.Blobs.Models.BlobRequestConditions conditions = null) { throw null; }
        public void Dispose() { }
        public virtual Azure.Response SetBlobAccessTier(string blobContainerName, string blobName, Azure.Storage.Blobs.Models.AccessTier accessTier, Azure.Storage.Blobs.Models.RehydratePriority? rehydratePriority = default(Azure.Storage.Blobs.Models.RehydratePriority?), Azure.Storage.Blobs.Models.BlobRequestConditions leaseAccessConditions = null) { throw null; }
        public virtual Azure.Response SetBlobAccessTier(System.Uri blobUri, Azure.Storage.Blobs.Models.AccessTier accessTier, Azure.Storage.Blobs.Models.RehydratePriority? rehydratePriority = default(Azure.Storage.Blobs.Models.RehydratePriority?), Azure.Storage.Blobs.Models.BlobRequestConditions leaseAccessConditions = null) { throw null; }
    }
    public partial class BlobBatchClient
    {
        protected BlobBatchClient() { }
        public BlobBatchClient(Azure.Storage.Blobs.BlobServiceClient client) { }
        public virtual System.Uri Uri { get { throw null; } }
        public virtual Azure.Storage.Blobs.Specialized.BlobBatch CreateBatch() { throw null; }
        public virtual Azure.Response[] DeleteBlobs(System.Collections.Generic.IEnumerable<System.Uri> blobUris, Azure.Storage.Blobs.Models.DeleteSnapshotsOption snapshotsOption = Azure.Storage.Blobs.Models.DeleteSnapshotsOption.None, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response[]> DeleteBlobsAsync(System.Collections.Generic.IEnumerable<System.Uri> blobUris, Azure.Storage.Blobs.Models.DeleteSnapshotsOption snapshotsOption = Azure.Storage.Blobs.Models.DeleteSnapshotsOption.None, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response[] SetBlobsAccessTier(System.Collections.Generic.IEnumerable<System.Uri> blobUris, Azure.Storage.Blobs.Models.AccessTier accessTier, Azure.Storage.Blobs.Models.RehydratePriority? rehydratePriority = default(Azure.Storage.Blobs.Models.RehydratePriority?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response[]> SetBlobsAccessTierAsync(System.Collections.Generic.IEnumerable<System.Uri> blobUris, Azure.Storage.Blobs.Models.AccessTier accessTier, Azure.Storage.Blobs.Models.RehydratePriority? rehydratePriority = default(Azure.Storage.Blobs.Models.RehydratePriority?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SubmitBatch(Azure.Storage.Blobs.Specialized.BlobBatch batch, bool throwOnAnyFailure = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SubmitBatchAsync(Azure.Storage.Blobs.Specialized.BlobBatch batch, bool throwOnAnyFailure = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class SpecializedBlobExtensions
    {
        public static Azure.Storage.Blobs.Specialized.BlobBatchClient GetBlobBatchClient(this Azure.Storage.Blobs.BlobServiceClient client) { throw null; }
    }
}
