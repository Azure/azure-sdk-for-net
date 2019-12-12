namespace Azure.Storage.Blobs.Specialized
{
    public partial class EncryptedBlockBlobClient : Azure.Storage.Blobs.BlobClient
    {
        protected EncryptedBlockBlobClient() { }
        public EncryptedBlockBlobClient(string connectionString, string containerName, string blobName) { }
        public EncryptedBlockBlobClient(string connectionString, string containerName, string blobName, Azure.Storage.Blobs.BlobClientOptions options) { }
        public EncryptedBlockBlobClient(System.Uri blobUri, Azure.Core.TokenCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public EncryptedBlockBlobClient(System.Uri blobUri, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public EncryptedBlockBlobClient(System.Uri blobUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Blobs.BlobClientOptions options = null) { }
    }
}
