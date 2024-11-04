namespace Azure.CloudMachine
{
    public partial class CloudMachineClient : Azure.CloudMachine.CloudMachineWorkspace
    {
        protected CloudMachineClient() : base (default(Azure.Core.TokenCredential), default(Microsoft.Extensions.Configuration.IConfiguration)) { }
        public CloudMachineClient(Azure.Core.TokenCredential credential = null, Microsoft.Extensions.Configuration.IConfiguration configuration = null) : base (default(Azure.Core.TokenCredential), default(Microsoft.Extensions.Configuration.IConfiguration)) { }
        public Azure.CloudMachine.MessagingServices Messaging { get { throw null; } }
        public Azure.CloudMachine.StorageServices Storage { get { throw null; } }
    }
    public partial class CloudMachineWorkspace : Azure.Core.ClientWorkspace
    {
        public CloudMachineWorkspace(Azure.Core.TokenCredential credential = null, Microsoft.Extensions.Configuration.IConfiguration configuration = null) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Id { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Core.ClientConnectionOptions GetConnectionOptions(System.Type clientType, string instanceId) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessagingServices
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public void SendMessage(object serializable) { }
        public void WhenMessageReceived(System.Action<string> received) { }
    }
    public partial class StorageFile
    {
        internal StorageFile() { }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } }
        public string Path { get { throw null; } }
        public string RequestId { get { throw null; } }
        public void Delete() { }
        public System.BinaryData Download() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static implicit operator Azure.Response (Azure.CloudMachine.StorageFile result) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageServices
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public void DeleteBlob(string path) { }
        public System.BinaryData DownloadBlob(string path) { throw null; }
        public string UploadBinaryData(System.BinaryData data, string name = null, bool overwrite = false) { throw null; }
        public string UploadBytes(byte[] bytes, string name = null, bool overwrite = false) { throw null; }
        public string UploadBytes(System.ReadOnlyMemory<byte> bytes, string name = null, bool overwrite = false) { throw null; }
        public string UploadJson(object json, string name = null, bool overwrite = false) { throw null; }
        public string UploadStream(System.IO.Stream fileStream, string name = null, bool overwrite = false) { throw null; }
        public void WhenBlobUploaded(System.Action<Azure.CloudMachine.StorageFile> function) { }
    }
}
namespace Azure.CloudMachine.KeyVault
{
    public static partial class KeyVaultExtensions
    {
        public static Azure.Security.KeyVault.Secrets.SecretClient GetKeyVaultSecretsClient(this Azure.Core.ClientWorkspace workspace) { throw null; }
    }
}
namespace Azure.CloudMachine.OpenAI
{
    public static partial class AzureOpenAIExtensions
    {
        public static OpenAI.Chat.ChatClient GetOpenAIChatClient(this Azure.Core.ClientWorkspace workspace) { throw null; }
        public static OpenAI.Embeddings.EmbeddingClient GetOpenAIEmbeddingsClient(this Azure.Core.ClientWorkspace workspace) { throw null; }
    }
}
namespace Azure.Core
{
    public partial class ClientCache
    {
        public ClientCache() { }
        public T Get<T>(System.Func<T> value, string id = null) where T : class { throw null; }
    }
    public enum ClientConnectionKind
    {
        EntraId = 0,
        ApiKey = 1,
        OutOfBand = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClientConnectionOptions
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClientConnectionOptions(string subclientId) { throw null; }
        public ClientConnectionOptions(System.Uri endpoint, Azure.Core.TokenCredential credential) { throw null; }
        public ClientConnectionOptions(System.Uri endpoint, string apiKey) { throw null; }
        public string ApiKeyCredential { get { throw null; } }
        public Azure.Core.ClientConnectionKind ConnectionKind { get { throw null; } }
        public System.Uri Endpoint { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Core.TokenCredential TokenCredential { get { throw null; } }
    }
    public abstract partial class ClientWorkspace
    {
        protected ClientWorkspace() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Core.ClientCache Subclients { get { throw null; } }
        public abstract Azure.Core.ClientConnectionOptions GetConnectionOptions(System.Type clientType, string instanceId = null);
    }
}
