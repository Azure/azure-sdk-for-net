namespace Azure.Analytics.Synapse.Spark
{
    public partial class SparkBatchClient
    {
        protected SparkBatchClient() { }
        public SparkBatchClient(System.Uri endpoint, string sparkPoolName, Azure.Core.TokenCredential credential, string livyApiVersion = "2019-11-01-preview", Azure.Analytics.Synapse.Spark.SparkClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CancelSparkBatchJob(int batchId, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelSparkBatchJobAsync(int batchId, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response CreateSparkBatchJob(Azure.Core.RequestContent requestBody, bool? detailed = default(bool?), Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateSparkBatchJobAsync(Azure.Core.RequestContent requestBody, bool? detailed = default(bool?), Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetSparkBatchJob(int batchId, bool? detailed = default(bool?), Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSparkBatchJobAsync(int batchId, bool? detailed = default(bool?), Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetSparkBatchJobs(int? from = default(int?), int? size = default(int?), bool? detailed = default(bool?), Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSparkBatchJobsAsync(int? from = default(int?), int? size = default(int?), bool? detailed = default(bool?), Azure.RequestOptions requestOptions = null) { throw null; }
    }
    public partial class SparkClientOptions : Azure.Core.ClientOptions
    {
        public SparkClientOptions(Azure.Analytics.Synapse.Spark.SparkClientOptions.ServiceVersion version = Azure.Analytics.Synapse.Spark.SparkClientOptions.ServiceVersion.V2019_11_01_preview) { }
        public enum ServiceVersion
        {
            V2019_11_01_preview = 1,
        }
    }
    public partial class SparkSessionClient
    {
        protected SparkSessionClient() { }
        public SparkSessionClient(System.Uri endpoint, string sparkPoolName, Azure.Core.TokenCredential credential, string livyApiVersion = "2019-11-01-preview", Azure.Analytics.Synapse.Spark.SparkClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CancelSparkSession(int sessionId, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelSparkSessionAsync(int sessionId, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response CancelSparkStatement(int sessionId, int statementId, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelSparkStatementAsync(int sessionId, int statementId, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response CreateSparkSession(Azure.Core.RequestContent requestBody, bool? detailed = default(bool?), Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateSparkSessionAsync(Azure.Core.RequestContent requestBody, bool? detailed = default(bool?), Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response CreateSparkStatement(int sessionId, Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateSparkStatementAsync(int sessionId, Azure.Core.RequestContent requestBody, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetSparkSession(int sessionId, bool? detailed = default(bool?), Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSparkSessionAsync(int sessionId, bool? detailed = default(bool?), Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetSparkSessions(int? from = default(int?), int? size = default(int?), bool? detailed = default(bool?), Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSparkSessionsAsync(int? from = default(int?), int? size = default(int?), bool? detailed = default(bool?), Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetSparkStatement(int sessionId, int statementId, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSparkStatementAsync(int sessionId, int statementId, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response GetSparkStatements(int sessionId, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSparkStatementsAsync(int sessionId, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual Azure.Response ResetSparkSessionTimeout(int sessionId, Azure.RequestOptions requestOptions = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResetSparkSessionTimeoutAsync(int sessionId, Azure.RequestOptions requestOptions = null) { throw null; }
    }
}
