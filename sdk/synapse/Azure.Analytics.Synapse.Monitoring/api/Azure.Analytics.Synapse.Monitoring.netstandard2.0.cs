namespace Azure.Analytics.Synapse.Monitoring
{
    public partial class MonitoringClient
    {
        protected MonitoringClient() { }
        public MonitoringClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.Monitoring.MonitoringClientOptions options = null) { }
        public virtual Azure.Response<Azure.Analytics.Synapse.Monitoring.Models.SparkJobListViewResponse> GetSparkJobList(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Monitoring.Models.SparkJobListViewResponse>> GetSparkJobListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.Monitoring.Models.SqlQueryStringDataModel> GetSqlJobQueryString(string filter = null, string orderby = null, string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.Monitoring.Models.SqlQueryStringDataModel>> GetSqlJobQueryStringAsync(string filter = null, string orderby = null, string skip = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
namespace Azure.Analytics.Synapse.Monitoring.Models
{
    public partial class SparkJob
    {
        internal SparkJob() { }
        public string Compute { get { throw null; } }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public string JobType { get { throw null; } }
        public string LivyId { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Synapse.Monitoring.Models.SparkJob> Pipeline { get { throw null; } }
        public string QueuedDuration { get { throw null; } }
        public string RunningDuration { get { throw null; } }
        public string SparkApplicationId { get { throw null; } }
        public string SparkJobDefinition { get { throw null; } }
        public string State { get { throw null; } }
        public string Submitter { get { throw null; } }
        public System.DateTimeOffset? SubmitTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Timing { get { throw null; } }
        public string TotalDuration { get { throw null; } }
    }
    public partial class SparkJobListViewResponse
    {
        internal SparkJobListViewResponse() { }
        public int? NJobs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Synapse.Monitoring.Models.SparkJob> SparkJobs { get { throw null; } }
    }
    public partial class SqlQueryStringDataModel
    {
        internal SqlQueryStringDataModel() { }
        public string Query { get { throw null; } }
    }
}
