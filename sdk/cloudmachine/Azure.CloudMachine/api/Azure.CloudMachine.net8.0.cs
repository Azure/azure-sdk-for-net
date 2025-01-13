namespace Azure.CloudMachine
{
    public partial class CloudMachineClient : Azure.Core.ClientWorkspace
    {
        protected CloudMachineClient() : base (default(Azure.Core.TokenCredential)) { }
        public CloudMachineClient(Microsoft.Extensions.Configuration.IConfiguration configuration, Azure.Core.TokenCredential credential = null) : base (default(Azure.Core.TokenCredential)) { }
        public CloudMachineClient(System.Collections.Generic.IEnumerable<Azure.Core.ClientConnection> connections = null, Azure.Core.TokenCredential credential = null) : base (default(Azure.Core.TokenCredential)) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Core.ConnectionCollection Connections { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Id { get { throw null; } }
        public Azure.CloudMachine.MessagingServices Messaging { get { throw null; } }
        public Azure.CloudMachine.StorageServices Storage { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        public override System.Collections.Generic.IEnumerable<Azure.Core.ClientConnection> GetAllConnectionOptions() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Core.ClientConnection GetConnectionOptions(string connectionId) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static string ReadOrCreateCloudMachineId() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessagingServices
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public void SendJson(object serializable) { }
        public System.Threading.Tasks.Task SendJsonAsync(object serializable) { throw null; }
        public void WhenMessageReceived(System.Action<string> received) { }
    }
    public partial class StorageFile
    {
        internal StorageFile() { }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } }
        public string Path { get { throw null; } }
        public string RequestId { get { throw null; } }
        public void Delete() { }
        public System.Threading.Tasks.Task DeleteAsync() { throw null; }
        public System.BinaryData Download() { throw null; }
        public System.Threading.Tasks.Task<System.BinaryData> DownloadAsync() { throw null; }
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
        public void Delete(string path) { }
        public System.Threading.Tasks.Task DeleteAsync(string path) { throw null; }
        public System.BinaryData Download(string path) { throw null; }
        public System.Threading.Tasks.Task<System.BinaryData> DownloadAsync(string path) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Storage.Blobs.BlobContainerClient GetContainer(string containerName = null) { throw null; }
        public string Upload(System.BinaryData data, string name = null, bool overwrite = false) { throw null; }
        public string Upload(System.IO.Stream fileStream, string name = null, string contentType = null, bool overwrite = false) { throw null; }
        public System.Threading.Tasks.Task<string> UploadAsync(System.BinaryData data, string name = null, bool overwrite = false) { throw null; }
        public System.Threading.Tasks.Task<string> UploadAsync(System.IO.Stream fileStream, string name = null, string contentType = null, bool overwrite = false) { throw null; }
        public string UploadJson(object serializable, string name = null, bool overwrite = false) { throw null; }
        public System.Threading.Tasks.Task<string> UploadJsonAsync(object serializable, string name = null, bool overwrite = false) { throw null; }
        public void WhenUploaded(System.Action<Azure.CloudMachine.StorageFile> function) { }
        public void WhenUploaded(System.Action<System.BinaryData> function) { }
    }
}
namespace Azure.CloudMachine.KeyVault
{
    public static partial class KeyVaultExtensions
    {
        public static Azure.Security.KeyVault.Secrets.SecretClient GetKeyVaultSecretsClient(this Azure.Core.ClientWorkspace workspace) { throw null; }
    }
}
namespace Azure.Core
{
    public enum ClientAuthenticationMethod
    {
        EntraId = 0,
        ApiKey = 1,
        Subclient = 2,
    }
    public partial class ClientCache
    {
        public ClientCache() { }
        public T Get<T>(System.Func<T> value, string id = null) where T : class { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClientConnection
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ClientConnection() { throw null; }
        public ClientConnection(string id, string locator, Azure.Core.ClientAuthenticationMethod auth = Azure.Core.ClientAuthenticationMethod.EntraId) { throw null; }
        public ClientConnection(string id, string locator, string apiKey) { throw null; }
        public string ApiKeyCredential { get { throw null; } }
        public Azure.Core.ClientAuthenticationMethod Authentication { get { throw null; } }
        public string Id { get { throw null; } }
        public string Locator { get { throw null; } }
        public override string ToString() { throw null; }
        public System.Uri ToUri() { throw null; }
    }
    public abstract partial class ClientWorkspace
    {
        protected ClientWorkspace(Azure.Core.TokenCredential credential) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Core.TokenCredential Credential { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Core.ClientCache Subclients { get { throw null; } }
        public abstract System.Collections.Generic.IEnumerable<Azure.Core.ClientConnection> GetAllConnectionOptions();
        public abstract Azure.Core.ClientConnection GetConnectionOptions(string connectionId);
    }
    public static partial class CloudMachineClientConfiguration
    {
        public static Microsoft.Extensions.Configuration.IConfigurationBuilder AddCloudMachineConnections(this Microsoft.Extensions.Configuration.IConfigurationBuilder builder, Azure.Core.ConnectionCollection connections) { throw null; }
        public static Microsoft.Extensions.Configuration.IConfigurationBuilder AddCloudMachineId(this Microsoft.Extensions.Configuration.IConfigurationBuilder builder, string id) { throw null; }
    }
    public partial class ConnectionCollection : System.Collections.ObjectModel.KeyedCollection<string, Azure.Core.ClientConnection>
    {
        public ConnectionCollection() { }
        protected override string GetKeyForItem(Azure.Core.ClientConnection item) { throw null; }
    }
}
namespace Azure.Core.Rest
{
    public partial class RestCallFailedException : System.Exception
    {
        public RestCallFailedException(string message, System.ClientModel.Primitives.PipelineResponse response) { }
    }
    public partial class RestClient
    {
        public RestClient() { }
        public RestClient(System.ClientModel.Primitives.PipelinePolicy auth) { }
        public static Azure.Core.Rest.RestClient Shared { get { throw null; } }
        public System.ClientModel.Primitives.PipelineMessage Create(string method, System.Uri uri) { throw null; }
        public System.ClientModel.Primitives.PipelineResponse Get(string uri, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public System.ClientModel.Primitives.PipelineResponse Patch(string uri, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public System.ClientModel.Primitives.PipelineResponse Post(string uri, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public System.ClientModel.Primitives.PipelineResponse Put(string uri, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public System.ClientModel.Primitives.PipelineResponse Send(System.ClientModel.Primitives.PipelineMessage message, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
    }
    public partial class RestClientOptions : System.ClientModel.Primitives.ClientPipelineOptions
    {
        public RestClientOptions() { }
    }
}
