namespace Azure.Storage.Blobs.Specialized
{
    public partial class ClientsideEncryptionOptions
    {
        public ClientsideEncryptionOptions() { }
        public string EncryptionKeyWrapAlgorithm { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public Azure.Core.Cryptography.IKeyEncryptionKey KeyEncryptionKey { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public Azure.Core.Cryptography.IKeyEncryptionKeyResolver KeyResolver { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
    public partial class EncryptedBlobClient : Azure.Storage.Blobs.BlobClient
    {
        protected EncryptedBlobClient() { }
        public EncryptedBlobClient(string connectionString, string blobContainerName, string blobName, Azure.Storage.Blobs.Specialized.ClientsideEncryptionOptions encryptionOptions, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public EncryptedBlobClient(System.Uri blobUri, Azure.Core.TokenCredential credential, Azure.Storage.Blobs.Specialized.ClientsideEncryptionOptions encryptionOptions, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public EncryptedBlobClient(System.Uri blobUri, Azure.Storage.Blobs.Specialized.ClientsideEncryptionOptions encryptionOptions, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public EncryptedBlobClient(System.Uri blobUri, Azure.Storage.StorageSharedKeyCredential credential, Azure.Storage.Blobs.Specialized.ClientsideEncryptionOptions encryptionOptions, Azure.Storage.Blobs.BlobClientOptions options = null) { }
        public override (System.IO.Stream, System.Collections.Generic.IDictionary<string, string>) TransformContent(System.IO.Stream content, System.Collections.Generic.IDictionary<string, string> metadata) { throw null; }
    }
    public static partial class SpecializedBlobExtensions
    {
        public static Azure.Storage.Blobs.Specialized.EncryptedBlobClient GetEncryptedBlobClient(this Azure.Storage.Blobs.BlobContainerClient containerClient, string blobName, Azure.Storage.Blobs.Specialized.ClientsideEncryptionOptions encryptionOptions) { throw null; }
    }
}
namespace Azure.Storage.Blobs.Specialized.Models
{
    public enum ClientsideEncryptionAlgorithm
    {
        AES_CBC_256 = 0,
    }
    public partial class EncryptionAgent
    {
        public EncryptionAgent() { }
        public string EncryptionAlgorithm { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Protocol { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
    public partial class EncryptionData
    {
        public EncryptionData() { }
        public byte[] ContentEncryptionIV { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public Azure.Storage.Blobs.Specialized.Models.EncryptionAgent EncryptionAgent { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string EncryptionMode { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public System.Collections.Generic.IDictionary<string, string> KeyWrappingMetadata { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public Azure.Storage.Blobs.Specialized.Models.WrappedKey WrappedContentKey { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public static Azure.Storage.Blobs.Specialized.Models.EncryptionData Deserialize(string json) { throw null; }
        public string Serialize() { throw null; }
    }
    public partial class WrappedKey
    {
        public WrappedKey() { }
        public string Algorithm { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public byte[] EncryptedKey { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string KeyId { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
    }
}
