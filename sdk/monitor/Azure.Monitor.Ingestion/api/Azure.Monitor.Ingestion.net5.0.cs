namespace Azure.Monitor.Ingestion
{
    public partial class LogsIngestionClient
    {
        protected LogsIngestionClient() { }
        public LogsIngestionClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public LogsIngestionClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Monitor.Ingestion.LogsIngestionClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Upload(string ruleId, string streamName, Azure.Core.RequestContent content, string contentEncoding = "gzip", Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UploadAsync(string ruleId, string streamName, Azure.Core.RequestContent content, string contentEncoding = "gzip", Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Monitor.Ingestion.UploadLogsResult>> UploadAsync<T>(string ruleId, string streamName, System.Collections.Generic.IEnumerable<T> logEntries, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Monitor.Ingestion.UploadLogsResult> Upload<T>(string ruleId, string streamName, System.Collections.Generic.IEnumerable<T> logEntries, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogsIngestionClientOptions : Azure.Core.ClientOptions
    {
        public LogsIngestionClientOptions(Azure.Monitor.Ingestion.LogsIngestionClientOptions.ServiceVersion version = Azure.Monitor.Ingestion.LogsIngestionClientOptions.ServiceVersion.V2021_11_01_Preview) { }
        public enum ServiceVersion
        {
            V2021_11_01_Preview = 1,
        }
    }
    public partial class UploadLogsError
    {
        internal UploadLogsError() { }
        public Azure.ResponseError Error { get { throw null; } }
        public System.Collections.Generic.IEnumerable<object> FailedLogs { get { throw null; } }
    }
    public partial class UploadLogsResult
    {
        internal UploadLogsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Monitor.Ingestion.UploadLogsError> Errors { get { throw null; } }
        public Azure.Monitor.Ingestion.UploadLogsStatus Status { get { throw null; } }
    }
    public enum UploadLogsStatus
    {
        Success = 0,
        PartialFailure = 1,
        Failure = 2,
    }
}
