namespace Azure.Storage.Blobs.Specialized
{
    public partial class EncryptedBlockBlobClient : Azure.Storage.Blobs.Specialized.BlobBaseClient
    {
        protected EncryptedBlockBlobClient() { }
        public EncryptedBlockBlobClient(string connectionString, string containerName, string blobName) { }
        public EncryptedBlockBlobClient(string connectionString, string containerName, string blobName, Azure.Storage.Blobs.BlobClientOptions options) { }
        public EncryptedBlockBlobClient(System.Uri blobUri, Azure.Core.TokenCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public EncryptedBlockBlobClient(System.Uri blobUri, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public EncryptedBlockBlobClient(System.Uri blobUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
    }
    public static partial class SpecializedBlobExtensions
    {
        public static Azure.Storage.Blobs.Specialized.EncryptedBlockBlobClient GetEncryptedBlockBlobClient(this Azure.Storage.Blobs.BlobContainerClient client, string blobName) { throw null; }
    }
}
