namespace Azure.Analytics.Synapse.Monitoring
{
    public partial class AzureAnalyticsSynapseMonitoringContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAnalyticsSynapseMonitoringContext() { }
        public static Azure.Analytics.Synapse.Monitoring.AzureAnalyticsSynapseMonitoringContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
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
        public MonitoringClientOptions(Azure.Analytics.Synapse.Monitoring.MonitoringClientOptions.ServiceVersion version = Azure.Analytics.Synapse.Monitoring.MonitoringClientOptions.ServiceVersion.V2019_11_01_Preview) { }
        public enum ServiceVersion
        {
            V2019_11_01_Preview = 1,
        }
    }
}
namespace Azure.Analytics.Synapse.Monitoring.Models
{
    public static partial class AnalyticsSynapseMonitoringModelFactory
    {
        public static Azure.Analytics.Synapse.Monitoring.Models.SparkJob SparkJob(string state = null, string name = null, string submitter = null, string compute = null, string sparkApplicationId = null, string livyId = null, System.Collections.Generic.IEnumerable<string> timing = null, string sparkJobDefinition = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Monitoring.Models.SparkJob> pipeline = null, string jobType = null, System.DateTimeOffset? submitTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string queuedDuration = null, string runningDuration = null, string totalDuration = null) { throw null; }
        public static Azure.Analytics.Synapse.Monitoring.Models.SparkJobListViewResponse SparkJobListViewResponse(int? nJobs = default(int?), System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.Monitoring.Models.SparkJob> sparkJobs = null) { throw null; }
        public static Azure.Analytics.Synapse.Monitoring.Models.SqlQueryStringDataModel SqlQueryStringDataModel(string query = null) { throw null; }
    }
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
