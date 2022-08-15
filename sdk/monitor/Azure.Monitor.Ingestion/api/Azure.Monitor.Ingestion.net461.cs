namespace Azure.Monitor.Ingestion
{
    public partial class LogsIngestionClient
    {
        protected LogsIngestionClient() { }
        public LogsIngestionClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public LogsIngestionClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Monitor.Ingestion.LogsIngestionClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Upload(string ruleId, string streamName, Azure.Core.RequestContent content, string contentEncoding = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UploadAsync(string ruleId, string streamName, Azure.Core.RequestContent content, string contentEncoding = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UploadAsync<T>(string ruleId, string streamName, System.Collections.Generic.IEnumerable<T> logEntries, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Upload<T>(string ruleId, string streamName, System.Collections.Generic.IEnumerable<T> logEntries, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogsIngestionClientOptions : Azure.Core.ClientOptions
    {
        public LogsIngestionClientOptions(Azure.Monitor.Ingestion.LogsIngestionClientOptions.ServiceVersion version = Azure.Monitor.Ingestion.LogsIngestionClientOptions.ServiceVersion.V2021_11_01_Preview) { }
        public enum ServiceVersion
        {
            V2021_11_01_Preview = 1,
        }
    }
}
