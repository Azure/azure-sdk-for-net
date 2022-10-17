namespace Azure.Storage.Blobs.DataMovement
{
    public static partial class BlobStorageResourceFactory
    {
        public static Azure.Storage.DataMovement.StorageResourceContainer GetBlobVirtualDirectory(Azure.Storage.Blobs.BlobContainerClient containerClient, string encodedPath) { throw null; }
        public static Azure.Storage.DataMovement.StorageResource GetBlockBlob(Azure.Storage.Blobs.Specialized.BlockBlobClient blobClient) { throw null; }
    }
}
namespace Azure.Storage.Blobs.DataMovement.Models
{
    public enum BlobCopyMethod
    {
        Copy = 0,
        SyncCopy = 1,
        UploadFromUriCopy = 2,
    }
}
