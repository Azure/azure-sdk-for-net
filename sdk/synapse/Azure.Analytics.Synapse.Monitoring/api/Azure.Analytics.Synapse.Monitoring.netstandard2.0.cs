namespace Azure.Analytics.Synapse.Monitoring
{
    public partial class MonitoringClient
    {
        protected MonitoringClient() { }
        public MonitoringClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Monitoring.MonitoringClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetSparkJobList(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSparkJobListAsync(Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetSqlJobQueryString(string filter = null, string orderby = null, string skip = null, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSqlJobQueryStringAsync(string filter = null, string orderby = null, string skip = null, Azure.RequestOptions requestOptions = null) { throw null; }
    }
    public partial class MonitoringClientOptions : Azure.Core.ClientOptions
    {
        public MonitoringClientOptions(Azure.Analytics.Synapse.Monitoring.MonitoringClientOptions.ServiceVersion version = Azure.Analytics.Synapse.Monitoring.MonitoringClientOptions.ServiceVersion.V2019_11_01_preview) { }
        public enum ServiceVersion
        {
            V2019_11_01_preview = 1,
        }
    }
}
