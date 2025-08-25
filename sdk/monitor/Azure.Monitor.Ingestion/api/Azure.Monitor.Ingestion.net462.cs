namespace Azure.Monitor.Ingestion
{
    public partial class AzureMonitorIngestionContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        public AzureMonitorIngestionContext() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogsIngestionAudience : System.IEquatable<Azure.Monitor.Ingestion.LogsIngestionAudience>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogsIngestionAudience(string value) { throw null; }
        public static Azure.Monitor.Ingestion.LogsIngestionAudience AzureChina { get { throw null; } }
        public static Azure.Monitor.Ingestion.LogsIngestionAudience AzureGovernment { get { throw null; } }
        public static Azure.Monitor.Ingestion.LogsIngestionAudience AzurePublicCloud { get { throw null; } }
        public bool Equals(Azure.Monitor.Ingestion.LogsIngestionAudience other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Monitor.Ingestion.LogsIngestionAudience left, Azure.Monitor.Ingestion.LogsIngestionAudience right) { throw null; }
        public static implicit operator Azure.Monitor.Ingestion.LogsIngestionAudience (string value) { throw null; }
        public static bool operator !=(Azure.Monitor.Ingestion.LogsIngestionAudience left, Azure.Monitor.Ingestion.LogsIngestionAudience right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogsIngestionClient
    {
        protected LogsIngestionClient() { }
        public LogsIngestionClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public LogsIngestionClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Monitor.Ingestion.LogsIngestionClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Upload(string ruleId, string streamName, Azure.Core.RequestContent content, string contentEncoding = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Upload(string ruleId, string streamName, System.Collections.Generic.IEnumerable<System.BinaryData> logs, Azure.Monitor.Ingestion.LogsUploadOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UploadAsync(string ruleId, string streamName, Azure.Core.RequestContent content, string contentEncoding = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UploadAsync(string ruleId, string streamName, System.Collections.Generic.IEnumerable<System.BinaryData> logs, Azure.Monitor.Ingestion.LogsUploadOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UploadAsync<T>(string ruleId, string streamName, System.Collections.Generic.IEnumerable<T> logs, Azure.Monitor.Ingestion.LogsUploadOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Upload<T>(string ruleId, string streamName, System.Collections.Generic.IEnumerable<T> logs, Azure.Monitor.Ingestion.LogsUploadOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogsIngestionClientOptions : Azure.Core.ClientOptions
    {
        public LogsIngestionClientOptions(Azure.Monitor.Ingestion.LogsIngestionClientOptions.ServiceVersion version = Azure.Monitor.Ingestion.LogsIngestionClientOptions.ServiceVersion.V2023_01_01) { }
        public Azure.Monitor.Ingestion.LogsIngestionAudience? Audience { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V2023_01_01 = 1,
        }
    }
    public partial class LogsUploadFailedEventArgs : Azure.SyncAsyncEventArgs
    {
        public LogsUploadFailedEventArgs(System.Collections.Generic.IEnumerable<object> failedLogs, System.Exception exception, bool isRunningSynchronously, System.Threading.CancellationToken cancellationToken) : base (default(bool), default(System.Threading.CancellationToken)) { }
        public System.Exception Exception { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<object> FailedLogs { get { throw null; } }
    }
    public partial class LogsUploadOptions
    {
        public LogsUploadOptions() { }
        public int MaxConcurrency { get { throw null; } set { } }
        public Azure.Core.Serialization.ObjectSerializer Serializer { get { throw null; } set { } }
        public event Azure.Core.SyncAsyncEventHandler<Azure.Monitor.Ingestion.LogsUploadFailedEventArgs> UploadFailed { add { } remove { } }
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
