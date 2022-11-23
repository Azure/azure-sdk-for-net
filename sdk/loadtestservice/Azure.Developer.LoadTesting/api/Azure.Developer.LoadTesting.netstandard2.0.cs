namespace Azure.Developer.LoadTesting
{
    public partial class AzureLoadTestingClientOptions : Azure.Core.ClientOptions
    {
        public AzureLoadTestingClientOptions(Azure.Developer.LoadTesting.AzureLoadTestingClientOptions.ServiceVersion version = Azure.Developer.LoadTesting.AzureLoadTestingClientOptions.ServiceVersion.V2022_11_01) { }
        public enum ServiceVersion
        {
            V2022_11_01 = 1,
        }
    }
    public partial class LoadTestAdministrationClient
    {
        protected LoadTestAdministrationClient() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Developer.LoadTesting.TestFileValidationStatus BeginTestScriptValidationStatus(string testId, int refreshTime = 10000, int timeOut = 600000) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Developer.LoadTesting.TestFileValidationStatus> BeginTestScriptValidationStatusAsync(string testId, int refreshTime = 10000, int timeOut = 600000) { throw null; }
        public virtual Azure.Response CreateOrUpdateAppComponents(string testId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateAppComponentsAsync(string testId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateServerMetricsConfig(string testId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateServerMetricsConfigAsync(string testId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateTest(string testId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateTestAsync(string testId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteTest(string testId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTestAsync(string testId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteTestFile(string testId, string fileName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTestFileAsync(string testId, string fileName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetAppComponents(string testId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAppComponentsAsync(string testId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetServerMetricsConfigs(string testId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetServerMetricsConfigsAsync(string testId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTest(string testId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTestAsync(string testId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTestFile(string testId, string fileName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTestFileAsync(string testId, string fileName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTestFiles(string testId, string continuationToken = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTestFilesAsync(string testId, string continuationToken = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTests(string orderby = null, string search = null, System.DateTimeOffset? lastModifiedStartTime = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedEndTime = default(System.DateTimeOffset?), string continuationToken = null, int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTestsAsync(string orderby = null, string search = null, System.DateTimeOffset? lastModifiedStartTime = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedEndTime = default(System.DateTimeOffset?), string continuationToken = null, int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UploadTestFile(string testId, string fileName, Azure.Core.RequestContent content, string fileType = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UploadTestFile(string testId, string fileId, System.IO.FileStream file, string fileType, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UploadTestFile(string testId, string fileId, string fileName, Azure.Core.RequestContent content, string fileType, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UploadTestFileAsync(string testId, string fileName, Azure.Core.RequestContent content, string fileType = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UploadTestFileAsync(string testId, string fileId, System.IO.FileStream file, string fileType, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UploadTestFileAsync(string testId, string fileId, string fileName, Azure.Core.RequestContent content, string fileType, Azure.RequestContext context = null) { throw null; }
    }
    public partial class LoadTestingClient
    {
        protected LoadTestingClient() { }
        public LoadTestingClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public LoadTestingClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Developer.LoadTesting.AzureLoadTestingClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public Azure.Developer.LoadTesting.LoadTestAdministrationClient getLoadTestAdministration() { throw null; }
        public Azure.Developer.LoadTesting.LoadTestRunClient getLoadTestRun() { throw null; }
    }
    public partial class LoadTestRunClient
    {
        protected LoadTestRunClient() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Developer.LoadTesting.TestRunStatus BeginTestRunStatus(string testRunId, int refreshTime = 10000, int timeOut = 60000) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Developer.LoadTesting.TestRunStatus> BeginTestRunStatusAsync(string testRunId, int refreshTime = 10000, int timeOut = 60000) { throw null; }
        public virtual Azure.Response CreateOrUpdateAppComponents(string testRunId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateAppComponentsAsync(string testRunId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateServerMetricsConfig(string testRunId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateServerMetricsConfigAsync(string testRunId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateTestRun(string testRunId, Azure.Core.RequestContent content, string oldTestRunId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateTestRunAsync(string testRunId, Azure.Core.RequestContent content, string oldTestRunId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteTestRun(string testRunId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTestRunAsync(string testRunId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetAppComponents(string testRunId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAppComponentsAsync(string testRunId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetMetricDefinitions(string testRunId, string metricNamespace, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetMetricDefinitionsAsync(string testRunId, string metricNamespace, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetMetricDimensionValues(string testRunId, string name, string metricname, string metricNamespace, string timespan, string interval = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetMetricDimensionValuesAsync(string testRunId, string name, string metricname, string metricNamespace, string timespan, string interval = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetMetricNamespaces(string testRunId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetMetricNamespacesAsync(string testRunId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetMetrics(string testRunId, string metricname, string metricNamespace, string timespan, Azure.Core.RequestContent content, string aggregation = null, string interval = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetMetricsAsync(string testRunId, string metricname, string metricNamespace, string timespan, Azure.Core.RequestContent content, string aggregation = null, string interval = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetServerMetricsConfigs(string testRunId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetServerMetricsConfigsAsync(string testRunId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTestRun(string testRunId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTestRunAsync(string testRunId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTestRunFile(string testRunId, string fileName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTestRunFileAsync(string testRunId, string fileName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTestRuns(string orderby = null, string continuationToken = null, string search = null, string testId = null, System.DateTimeOffset? executionFrom = default(System.DateTimeOffset?), System.DateTimeOffset? executionTo = default(System.DateTimeOffset?), string status = null, int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTestRunsAsync(string orderby = null, string continuationToken = null, string search = null, string testId = null, System.DateTimeOffset? executionFrom = default(System.DateTimeOffset?), System.DateTimeOffset? executionTo = default(System.DateTimeOffset?), string status = null, int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response StopTestRun(string testRunId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopTestRunAsync(string testRunId, Azure.RequestContext context = null) { throw null; }
    }
    public enum TestFileValidationStatus
    {
        ValidationInitiated = 0,
        ValidationSuccess = 1,
        ValidationFailed = 2,
        ValidationCheckTimeout = 3,
    }
    public enum TestRunStatus
    {
        Accepted = 0,
        NotStarted = 1,
        Provisioning = 2,
        Provisioned = 3,
        Configuring = 4,
        Configured = 5,
        Executing = 6,
        Executed = 7,
        Deprovisioning = 8,
        Deprovisioned = 9,
        Done = 10,
        Cancelling = 11,
        Cancelled = 12,
        Failed = 13,
        ValidationSuccess = 14,
        ValidationFailed = 15,
        CheckTimeout = 16,
    }
}
