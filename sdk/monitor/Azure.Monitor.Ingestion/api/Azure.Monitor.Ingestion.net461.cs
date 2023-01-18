namespace Azure.Monitor.Ingestion
{
    public partial class LogsIngestionClient
    {
        protected LogsIngestionClient() { }
        public LogsIngestionClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public LogsIngestionClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Monitor.Ingestion.LogsIngestionClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Upload(string ruleId, string streamName, Azure.Core.RequestContent content, string contentEncoding = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Upload(string ruleId, string streamName, System.Collections.Generic.IEnumerable<object> logs, Azure.Monitor.Ingestion.UploadLogsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UploadAsync(string ruleId, string streamName, Azure.Core.RequestContent content, string contentEncoding = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UploadAsync(string ruleId, string streamName, System.Collections.Generic.IEnumerable<object> logs, Azure.Monitor.Ingestion.UploadLogsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogsIngestionClientOptions : Azure.Core.ClientOptions
    {
        public LogsIngestionClientOptions(Azure.Monitor.Ingestion.LogsIngestionClientOptions.ServiceVersion version = Azure.Monitor.Ingestion.LogsIngestionClientOptions.ServiceVersion.V2021_11_01_Preview) { }
        public enum ServiceVersion
        {
            V2021_11_01_Preview = 1,
        }
    }
    public partial class UploadFailedArgs : Azure.SyncAsyncEventArgs
    {
        internal UploadFailedArgs() : base (default(bool), default(System.Threading.CancellationToken)) { }
        public System.Exception Exception { get { throw null; } }
        public int FailedLogs { get { throw null; } }
    }
    public partial class UploadLogsOptions
    {
        public UploadLogsOptions() { }
        public int MaxConcurrency { get { throw null; } set { } }
        public Azure.Core.Serialization.ObjectSerializer Serializer { get { throw null; } set { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Monitor.Ingestion.UploadFailedArgs> UploadFailed { add { } remove { } }
        protected internal static void OnException(int logsCount, Azure.Monitor.Ingestion.UploadLogsOptions options, Azure.Response response, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        protected internal static System.Threading.Tasks.Task OnExceptionAsync(int logsCount, Azure.Monitor.Ingestion.UploadLogsOptions options, Azure.Response response, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class IngestionClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Monitor.Ingestion.LogsIngestionClient, Azure.Monitor.Ingestion.LogsIngestionClientOptions> AddLogsIngestionClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Monitor.Ingestion.LogsIngestionClient, Azure.Monitor.Ingestion.LogsIngestionClientOptions> AddLogsIngestionClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
