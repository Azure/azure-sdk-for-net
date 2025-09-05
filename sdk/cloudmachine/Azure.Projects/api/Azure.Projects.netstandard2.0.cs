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
namespace Azure.Projects
{
    public static partial class AppConfigurationExtensions
    {
        public static Azure.Data.AppConfiguration.ConfigurationClient GetConfigurationClient(this System.ClientModel.Primitives.ClientConnectionProvider provider) { throw null; }
    }
    public static partial class BlobExtensions
    {
        public static Azure.Storage.Blobs.BlobContainerClient GetBlobContainerClient(this System.ClientModel.Primitives.ClientConnectionProvider provider, string containerName = "default") { throw null; }
    }
    public static partial class KeyVaultExtensions
    {
        public static Azure.Security.KeyVault.Secrets.SecretClient GetSecretClient(this System.ClientModel.Primitives.ClientConnectionProvider workspace) { throw null; }
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
    public partial class OfxClient : Azure.Projects.ProjectClient
    {
        public OfxClient() { }
        public OfxClient(string projectId, System.ClientModel.Primitives.ClientConnectionProvider connections) { }
        public Azure.Projects.MessagingServices Messaging { get { throw null; } }
        public Azure.Projects.StorageServices Storage { get { throw null; } }
    }
    public partial class ProjectClient : System.ClientModel.Primitives.ClientConnectionProvider
    {
        public ProjectClient() : base (default(int)) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ProjectClient(string projectId, System.ClientModel.Primitives.ClientConnectionProvider connections) : base (default(int)) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string ProjectId { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override System.Collections.Generic.IEnumerable<System.ClientModel.Primitives.ClientConnection> GetAllConnections() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override System.ClientModel.Primitives.ClientConnection GetConnection(string connectionId) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static string ReadOrCreateProjectId() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public static partial class ServiceBusExtensions
    {
        public static Azure.Messaging.ServiceBus.ServiceBusClient GetServiceBusClient(this System.ClientModel.Primitives.ClientConnectionProvider provider, string namespaceName = null) { throw null; }
        public static Azure.Messaging.ServiceBus.ServiceBusProcessor GetServiceBusProcessor(this System.ClientModel.Primitives.ClientConnectionProvider project, string namespaceName, string subscriptionName) { throw null; }
        public static Azure.Messaging.ServiceBus.ServiceBusSender GetServiceBusSender(this System.ClientModel.Primitives.ClientConnectionProvider project, string namespaceName, string topicName) { throw null; }
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
        public static implicit operator Azure.Response (Azure.Projects.StorageFile result) { throw null; }
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
        public void WhenUploaded(System.Action<Azure.Projects.StorageFile> function) { }
        public void WhenUploaded(System.Action<System.BinaryData> function) { }
    }
}
