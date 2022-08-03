namespace Azure.Analytics.LoadTestService
{
    public partial class AppComponentClient
    {
        protected AppComponentClient() { }
        public AppComponentClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public AppComponentClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.LoadTestService.AzureLoadTestingClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdateAppComponents(string name, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateAppComponentsAsync(string name, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteAppComponent(string name, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAppComponentAsync(string name, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetAppComponent(string testRunId = null, string testId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAppComponentAsync(string testRunId = null, string testId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetAppComponentByName(string name, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAppComponentByNameAsync(string name, Azure.RequestContext context = null) { throw null; }
    }
    public partial class AzureLoadTestingClientOptions : Azure.Core.ClientOptions
    {
        public AzureLoadTestingClientOptions(Azure.Analytics.LoadTestService.AzureLoadTestingClientOptions.ServiceVersion version = Azure.Analytics.LoadTestService.AzureLoadTestingClientOptions.ServiceVersion.V2022_06_01_preview) { }
        public enum ServiceVersion
        {
            V2022_06_01_preview = 1,
        }
    }
    public partial class ServerMetricsClient
    {
        protected ServerMetricsClient() { }
        public ServerMetricsClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public ServerMetricsClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.LoadTestService.AzureLoadTestingClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdateServerMetricsConfig(string name, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateServerMetricsConfigAsync(string name, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteServerMetrics(string name, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteServerMetricsAsync(string name, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetServerDefaultMetrics(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetServerDefaultMetricsAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetServerMetrics(string testRunId = null, string testId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetServerMetricsAsync(string testRunId = null, string testId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetServerMetricsByName(string name, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetServerMetricsByNameAsync(string name, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetSupportedResourceTypes(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSupportedResourceTypesAsync(Azure.RequestContext context = null) { throw null; }
    }
    public partial class TestClient
    {
        protected TestClient() { }
        public TestClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public TestClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.LoadTestService.AzureLoadTestingClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdateTest(string testId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateTestAsync(string testId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteLoadTest(string testId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteLoadTestAsync(string testId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteTestFile(string testId, string fileId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTestFileAsync(string testId, string fileId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetAllTestFiles(string testId, string continuationToken = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAllTestFilesAsync(string testId, string continuationToken = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetLoadTest(string testId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLoadTestAsync(string testId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetLoadTestSearches(string orderBy = null, string search = null, System.DateTimeOffset? lastUpdatedStartTime = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdatedEndTime = default(System.DateTimeOffset?), string continuationToken = null, int? maxPageSize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLoadTestSearchesAsync(string orderBy = null, string search = null, System.DateTimeOffset? lastUpdatedStartTime = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdatedEndTime = default(System.DateTimeOffset?), string continuationToken = null, int? maxPageSize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTestFile(string testId, string fileId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTestFileAsync(string testId, string fileId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UploadTestFile(string testId, string fileId, Azure.Core.RequestContent content, int? fileType = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UploadTestFileAsync(string testId, string fileId, Azure.Core.RequestContent content, int? fileType = default(int?), Azure.RequestContext context = null) { throw null; }
    }
    public partial class TestRunClient
    {
        protected TestRunClient() { }
        public TestRunClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public TestRunClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.LoadTestService.AzureLoadTestingClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateAndUpdateTest(string testRunId, Azure.Core.RequestContent content, string oldTestRunId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAndUpdateTestAsync(string testRunId, Azure.Core.RequestContent content, string oldTestRunId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteTestRun(string testRunId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTestRunAsync(string testRunId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTestRun(string testRunId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTestRunAsync(string testRunId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTestRunClientMetrics(string testRunId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTestRunClientMetricsAsync(string testRunId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTestRunClientMetricsFilters(string testRunId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTestRunClientMetricsFiltersAsync(string testRunId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTestRunFile(string testRunId, string fileId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTestRunFileAsync(string testRunId, string fileId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTestRunsSearches(string orderBy = null, string continuationToken = null, string search = null, System.DateTimeOffset? executionFrom = default(System.DateTimeOffset?), System.DateTimeOffset? executionTo = default(System.DateTimeOffset?), string status = null, int? maxPageSize = default(int?), string testId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTestRunsSearchesAsync(string orderBy = null, string continuationToken = null, string search = null, System.DateTimeOffset? executionFrom = default(System.DateTimeOffset?), System.DateTimeOffset? executionTo = default(System.DateTimeOffset?), string status = null, int? maxPageSize = default(int?), string testId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response StopTestRun(string testRunId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopTestRunAsync(string testRunId, Azure.RequestContext context = null) { throw null; }
    }
}
