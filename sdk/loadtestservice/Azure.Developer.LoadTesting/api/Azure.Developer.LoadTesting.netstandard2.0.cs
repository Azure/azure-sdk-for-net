namespace Azure.Developer.LoadTesting
{
    public partial class FileUploadResultOperation : Azure.Operation<System.BinaryData>
    {
        protected FileUploadResultOperation() { }
        public FileUploadResultOperation(string testId, string fileName, Azure.Developer.LoadTesting.LoadTestAdministrationClient client, Azure.Response initialResponse = null) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override System.BinaryData Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LoadTestAdministrationClient
    {
        protected LoadTestAdministrationClient() { }
        public LoadTestAdministrationClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public LoadTestAdministrationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Developer.LoadTesting.LoadTestingClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdateAppComponents(string testId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateAppComponentsAsync(string testId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateServerMetricsConfig(string testId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateServerMetricsConfigAsync(string testId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Developer.LoadTesting.Models.Test> CreateOrUpdateTest(Azure.Developer.LoadTesting.Models.Test test, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateOrUpdateTest(string testId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Developer.LoadTesting.Models.Test>> CreateOrUpdateTestAsync(Azure.Developer.LoadTesting.Models.Test test, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateTestAsync(string testId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteTest(string testId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTestAsync(string testId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteTestFile(string testId, string fileName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTestFileAsync(string testId, string fileName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetAppComponents(string testId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAppComponentsAsync(string testId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetServerMetricsConfig(string testId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetServerMetricsConfigAsync(string testId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTest(string testId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTestAsync(string testId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTestFile(string testId, string fileName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTestFileAsync(string testId, string fileName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTestFiles(string testId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTestFilesAsync(string testId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTests(string orderby = null, string search = null, System.DateTimeOffset? lastModifiedStartTime = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedEndTime = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTestsAsync(string orderby = null, string search = null, System.DateTimeOffset? lastModifiedStartTime = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedEndTime = default(System.DateTimeOffset?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Developer.LoadTesting.FileUploadResultOperation UploadTestFile(Azure.WaitUntil waitUntil, string testId, string fileName, Azure.Core.RequestContent content, System.TimeSpan? timeSpan = default(System.TimeSpan?), string fileType = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Developer.LoadTesting.FileUploadResultOperation> UploadTestFileAsync(Azure.WaitUntil waitUntil, string testId, string fileName, Azure.Core.RequestContent content, System.TimeSpan? timeSpan = default(System.TimeSpan?), string fileType = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class LoadTestingClientOptions : Azure.Core.ClientOptions
    {
        public LoadTestingClientOptions(Azure.Developer.LoadTesting.LoadTestingClientOptions.ServiceVersion version = Azure.Developer.LoadTesting.LoadTestingClientOptions.ServiceVersion.V2022_11_01) { }
        public enum ServiceVersion
        {
            V2022_11_01 = 1,
        }
    }
    public partial class LoadTestRunClient
    {
        protected LoadTestRunClient() { }
        public LoadTestRunClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public LoadTestRunClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Developer.LoadTesting.LoadTestingClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Developer.LoadTesting.TestRunResultOperation BeginTestRun(Azure.WaitUntil waitUntil, string testRunId, Azure.Core.RequestContent content, System.TimeSpan? timeSpan = default(System.TimeSpan?), string oldTestRunId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Developer.LoadTesting.TestRunResultOperation> BeginTestRunAsync(Azure.WaitUntil waitUntil, string testRunId, Azure.Core.RequestContent content, System.TimeSpan? timeSpan = default(System.TimeSpan?), string oldTestRunId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateAppComponents(string testRunId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateAppComponentsAsync(string testRunId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateServerMetricsConfig(string testRunId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateServerMetricsConfigAsync(string testRunId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteTestRun(string testRunId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTestRunAsync(string testRunId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetAppComponents(string testRunId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAppComponentsAsync(string testRunId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetMetricDefinitions(string testRunId, string metricNamespace, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetMetricDefinitionsAsync(string testRunId, string metricNamespace, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetMetricDimensionValues(string testRunId, string name, string metricName, string metricNamespace, string timeInterval, string interval = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetMetricDimensionValuesAsync(string testRunId, string name, string metricName, string metricNamespace, string timeInterval, string interval = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetMetricNamespaces(string testRunId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetMetricNamespacesAsync(string testRunId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetMetrics(string testRunId, string metricName, string metricNamespace, string timespan, Azure.Core.RequestContent content = null, string aggregation = null, string interval = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetMetricsAsync(string testRunId, string metricName, string metricNamespace, string timespan, Azure.Core.RequestContent content = null, string aggregation = null, string interval = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetServerMetricsConfig(string testRunId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetServerMetricsConfigAsync(string testRunId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTestRun(string testRunId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTestRunAsync(string testRunId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTestRunFile(string testRunId, string fileName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTestRunFileAsync(string testRunId, string fileName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTestRuns(string orderby = null, string search = null, string testId = null, System.DateTimeOffset? executionFrom = default(System.DateTimeOffset?), System.DateTimeOffset? executionTo = default(System.DateTimeOffset?), string status = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTestRunsAsync(string orderby = null, string search = null, string testId = null, System.DateTimeOffset? executionFrom = default(System.DateTimeOffset?), System.DateTimeOffset? executionTo = default(System.DateTimeOffset?), string status = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response StopTestRun(string testRunId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopTestRunAsync(string testRunId, Azure.RequestContext context = null) { throw null; }
    }
    public partial class TestRunResultOperation : Azure.Operation<System.BinaryData>
    {
        protected TestRunResultOperation() { }
        public TestRunResultOperation(string testRunId, Azure.Developer.LoadTesting.LoadTestRunClient client, Azure.Response initialResponse = null) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override System.BinaryData Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.Developer.LoadTesting.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AggregationType : System.IEquatable<Azure.Developer.LoadTesting.Models.AggregationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AggregationType(string value) { throw null; }
        public static Azure.Developer.LoadTesting.Models.AggregationType Average { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.AggregationType Count { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.AggregationType None { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.AggregationType Percentile90 { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.AggregationType Percentile95 { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.AggregationType Percentile99 { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.AggregationType Total { get { throw null; } }
        public bool Equals(Azure.Developer.LoadTesting.Models.AggregationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.LoadTesting.Models.AggregationType left, Azure.Developer.LoadTesting.Models.AggregationType right) { throw null; }
        public static implicit operator Azure.Developer.LoadTesting.Models.AggregationType (string value) { throw null; }
        public static bool operator !=(Azure.Developer.LoadTesting.Models.AggregationType left, Azure.Developer.LoadTesting.Models.AggregationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppComponent
    {
        public AppComponent() { }
        public string DisplayName { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public string ResourceName { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } }
    }
    public static partial class AzureLoadTestingModelFactory
    {
        public static Azure.Developer.LoadTesting.Models.AppComponent AppComponent(string resourceId = null, string resourceName = null, string resourceType = null, string displayName = null, string resourceGroup = null, string subscriptionId = null, string kind = null) { throw null; }
        public static Azure.Developer.LoadTesting.Models.DimensionValue DimensionValue(string name = null, string value = null) { throw null; }
        public static Azure.Developer.LoadTesting.Models.ErrorDetails ErrorDetails(string message = null) { throw null; }
        public static Azure.Developer.LoadTesting.Models.FileInfo FileInfo(string url = null, string fileName = null, Azure.Developer.LoadTesting.Models.FileType? fileType = default(Azure.Developer.LoadTesting.Models.FileType?), System.DateTimeOffset? expireDateTime = default(System.DateTimeOffset?), Azure.Developer.LoadTesting.Models.FileStatus? validationStatus = default(Azure.Developer.LoadTesting.Models.FileStatus?), string validationFailureDetails = null) { throw null; }
        public static Azure.Developer.LoadTesting.Models.MetricAvailability MetricAvailability(Azure.Developer.LoadTesting.Models.TimeGrain? timeGrain = default(Azure.Developer.LoadTesting.Models.TimeGrain?)) { throw null; }
        public static Azure.Developer.LoadTesting.Models.MetricDefinition MetricDefinition(System.Collections.Generic.IEnumerable<Azure.Developer.LoadTesting.Models.NameAndDesc> dimensions = null, string description = null, string name = null, string @namespace = null, Azure.Developer.LoadTesting.Models.AggregationType? primaryAggregationType = default(Azure.Developer.LoadTesting.Models.AggregationType?), System.Collections.Generic.IEnumerable<string> supportedAggregationTypes = null, Azure.Developer.LoadTesting.Models.MetricUnit? unit = default(Azure.Developer.LoadTesting.Models.MetricUnit?), System.Collections.Generic.IEnumerable<Azure.Developer.LoadTesting.Models.MetricAvailability> metricAvailabilities = null) { throw null; }
        public static Azure.Developer.LoadTesting.Models.MetricDefinitionCollection MetricDefinitionCollection(System.Collections.Generic.IEnumerable<Azure.Developer.LoadTesting.Models.MetricDefinition> value = null) { throw null; }
        public static Azure.Developer.LoadTesting.Models.MetricNamespace MetricNamespace(string description = null, string name = null) { throw null; }
        public static Azure.Developer.LoadTesting.Models.MetricNamespaceCollection MetricNamespaceCollection(System.Collections.Generic.IEnumerable<Azure.Developer.LoadTesting.Models.MetricNamespace> value = null) { throw null; }
        public static Azure.Developer.LoadTesting.Models.MetricValue MetricValue(string timestamp = null, double? value = default(double?)) { throw null; }
        public static Azure.Developer.LoadTesting.Models.NameAndDesc NameAndDesc(string description = null, string name = null) { throw null; }
        public static Azure.Developer.LoadTesting.Models.PassFailMetric PassFailMetric(Azure.Developer.LoadTesting.Models.PFMetrics? clientMetric = default(Azure.Developer.LoadTesting.Models.PFMetrics?), Azure.Developer.LoadTesting.Models.PFAgFunc? aggregate = default(Azure.Developer.LoadTesting.Models.PFAgFunc?), string condition = null, string requestName = null, double? value = default(double?), Azure.Developer.LoadTesting.Models.PFAction? action = default(Azure.Developer.LoadTesting.Models.PFAction?), double? actualValue = default(double?), Azure.Developer.LoadTesting.Models.PFResult? result = default(Azure.Developer.LoadTesting.Models.PFResult?)) { throw null; }
        public static Azure.Developer.LoadTesting.Models.ResourceMetric ResourceMetric(string id = null, string resourceId = null, string metricNamespace = null, string displayDescription = null, string name = null, string aggregation = null, string unit = null, string resourceType = null) { throw null; }
        public static Azure.Developer.LoadTesting.Models.Test Test(Azure.Developer.LoadTesting.Models.PassFailCriteria passFailCriteria = null, System.Collections.Generic.IDictionary<string, Azure.Developer.LoadTesting.Models.Secret> secrets = null, Azure.Developer.LoadTesting.Models.CertificateMetadata certificate = null, System.Collections.Generic.IDictionary<string, string> environmentVariables = null, Azure.Developer.LoadTesting.Models.LoadTestConfiguration loadTestConfiguration = null, Azure.Developer.LoadTesting.Models.TestInputArtifacts inputArtifacts = null, string testId = null, string description = null, string displayName = null, string subnetId = null, string keyvaultReferenceIdentityType = null, string keyvaultReferenceIdentityId = null, System.DateTimeOffset? createdDateTime = default(System.DateTimeOffset?), string createdBy = null, System.DateTimeOffset? lastModifiedDateTime = default(System.DateTimeOffset?), string lastModifiedBy = null) { throw null; }
        public static Azure.Developer.LoadTesting.Models.TestAppComponents TestAppComponents(System.Collections.Generic.IDictionary<string, Azure.Developer.LoadTesting.Models.AppComponent> components = null, string testId = null, System.DateTimeOffset? createdDateTime = default(System.DateTimeOffset?), string createdBy = null, System.DateTimeOffset? lastModifiedDateTime = default(System.DateTimeOffset?), string lastModifiedBy = null) { throw null; }
        public static Azure.Developer.LoadTesting.Models.TestInputArtifacts TestInputArtifacts(Azure.Developer.LoadTesting.Models.FileInfo configFileInfo = null, Azure.Developer.LoadTesting.Models.FileInfo testScriptFileInfo = null, Azure.Developer.LoadTesting.Models.FileInfo userPropFileInfo = null, Azure.Developer.LoadTesting.Models.FileInfo inputArtifactsZipFileInfo = null, System.Collections.Generic.IEnumerable<Azure.Developer.LoadTesting.Models.FileInfo> additionalFileInfo = null) { throw null; }
        public static Azure.Developer.LoadTesting.Models.TestRun TestRun(Azure.Developer.LoadTesting.Models.PassFailCriteria passFailCriteria = null, System.Collections.Generic.IDictionary<string, Azure.Developer.LoadTesting.Models.Secret> secrets = null, Azure.Developer.LoadTesting.Models.CertificateMetadata certificate = null, System.Collections.Generic.IDictionary<string, string> environmentVariables = null, System.Collections.Generic.IEnumerable<Azure.Developer.LoadTesting.Models.ErrorDetails> errorDetails = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.Developer.LoadTesting.Models.TestRunStatistics> testRunStatistics = null, Azure.Developer.LoadTesting.Models.LoadTestConfiguration loadTestConfiguration = null, Azure.Developer.LoadTesting.Models.TestRunArtifacts testArtifacts = null, Azure.Developer.LoadTesting.Models.PFTestResult? testResult = default(Azure.Developer.LoadTesting.Models.PFTestResult?), int? virtualUsers = default(int?), string testRunId = null, string displayName = null, string testId = null, string description = null, Azure.Developer.LoadTesting.Models.Status? status = default(Azure.Developer.LoadTesting.Models.Status?), System.DateTimeOffset? startDateTime = default(System.DateTimeOffset?), System.DateTimeOffset? endDateTime = default(System.DateTimeOffset?), System.DateTimeOffset? executedDateTime = default(System.DateTimeOffset?), string portalUrl = null, long? duration = default(long?), string subnetId = null, System.DateTimeOffset? createdDateTime = default(System.DateTimeOffset?), string createdBy = null, System.DateTimeOffset? lastModifiedDateTime = default(System.DateTimeOffset?), string lastModifiedBy = null) { throw null; }
        public static Azure.Developer.LoadTesting.Models.TestRunAppComponents TestRunAppComponents(System.Collections.Generic.IDictionary<string, Azure.Developer.LoadTesting.Models.AppComponent> components = null, string testRunId = null, System.DateTimeOffset? createdDateTime = default(System.DateTimeOffset?), string createdBy = null, System.DateTimeOffset? lastModifiedDateTime = default(System.DateTimeOffset?), string lastModifiedBy = null) { throw null; }
        public static Azure.Developer.LoadTesting.Models.TestRunArtifacts TestRunArtifacts(Azure.Developer.LoadTesting.Models.TestRunInputArtifacts inputArtifacts = null, Azure.Developer.LoadTesting.Models.TestRunOutputArtifacts outputArtifacts = null) { throw null; }
        public static Azure.Developer.LoadTesting.Models.TestRunInputArtifacts TestRunInputArtifacts(Azure.Developer.LoadTesting.Models.FileInfo configFileInfo = null, Azure.Developer.LoadTesting.Models.FileInfo testScriptFileInfo = null, Azure.Developer.LoadTesting.Models.FileInfo userPropFileInfo = null, Azure.Developer.LoadTesting.Models.FileInfo inputArtifactsZipFileInfo = null, System.Collections.Generic.IEnumerable<Azure.Developer.LoadTesting.Models.FileInfo> additionalFileInfo = null) { throw null; }
        public static Azure.Developer.LoadTesting.Models.TestRunOutputArtifacts TestRunOutputArtifacts(Azure.Developer.LoadTesting.Models.FileInfo resultFileInfo = null, Azure.Developer.LoadTesting.Models.FileInfo logsFileInfo = null) { throw null; }
        public static Azure.Developer.LoadTesting.Models.TestRunServerMetricConfig TestRunServerMetricConfig(string testRunId = null, System.Collections.Generic.IDictionary<string, Azure.Developer.LoadTesting.Models.ResourceMetric> metrics = null, System.DateTimeOffset? createdDateTime = default(System.DateTimeOffset?), string createdBy = null, System.DateTimeOffset? lastModifiedDateTime = default(System.DateTimeOffset?), string lastModifiedBy = null) { throw null; }
        public static Azure.Developer.LoadTesting.Models.TestRunStatistics TestRunStatistics(string transaction = null, double? sampleCount = default(double?), double? errorCount = default(double?), double? errorPct = default(double?), double? meanResTime = default(double?), double? medianResTime = default(double?), double? maxResTime = default(double?), double? minResTime = default(double?), double? pct1ResTime = default(double?), double? pct2ResTime = default(double?), double? pct3ResTime = default(double?), double? throughput = default(double?), double? receivedKBytesPerSec = default(double?), double? sentKBytesPerSec = default(double?)) { throw null; }
        public static Azure.Developer.LoadTesting.Models.TestServerMetricConfig TestServerMetricConfig(string testId = null, System.Collections.Generic.IDictionary<string, Azure.Developer.LoadTesting.Models.ResourceMetric> metrics = null, System.DateTimeOffset? createdDateTime = default(System.DateTimeOffset?), string createdBy = null, System.DateTimeOffset? lastModifiedDateTime = default(System.DateTimeOffset?), string lastModifiedBy = null) { throw null; }
        public static Azure.Developer.LoadTesting.Models.TimeSeriesElement TimeSeriesElement(System.Collections.Generic.IEnumerable<Azure.Developer.LoadTesting.Models.MetricValue> data = null, System.Collections.Generic.IEnumerable<Azure.Developer.LoadTesting.Models.DimensionValue> dimensionValues = null) { throw null; }
    }
    public partial class CertificateMetadata
    {
        public CertificateMetadata() { }
        public string Name { get { throw null; } set { } }
        public Azure.Developer.LoadTesting.Models.CertificateType? Type { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateType : System.IEquatable<Azure.Developer.LoadTesting.Models.CertificateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateType(string value) { throw null; }
        public static Azure.Developer.LoadTesting.Models.CertificateType AKVCertURI { get { throw null; } }
        public bool Equals(Azure.Developer.LoadTesting.Models.CertificateType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.LoadTesting.Models.CertificateType left, Azure.Developer.LoadTesting.Models.CertificateType right) { throw null; }
        public static implicit operator Azure.Developer.LoadTesting.Models.CertificateType (string value) { throw null; }
        public static bool operator !=(Azure.Developer.LoadTesting.Models.CertificateType left, Azure.Developer.LoadTesting.Models.CertificateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DimensionFilter
    {
        public DimensionFilter() { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
    }
    public partial class DimensionValue
    {
        internal DimensionValue() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class ErrorDetails
    {
        internal ErrorDetails() { }
        public string Message { get { throw null; } }
    }
    public partial class FileInfo
    {
        internal FileInfo() { }
        public System.DateTimeOffset? ExpireDateTime { get { throw null; } }
        public string FileName { get { throw null; } }
        public Azure.Developer.LoadTesting.Models.FileType? FileType { get { throw null; } }
        public string Url { get { throw null; } }
        public string ValidationFailureDetails { get { throw null; } }
        public Azure.Developer.LoadTesting.Models.FileStatus? ValidationStatus { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileStatus : System.IEquatable<Azure.Developer.LoadTesting.Models.FileStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileStatus(string value) { throw null; }
        public static Azure.Developer.LoadTesting.Models.FileStatus NOTValidated { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.FileStatus ValidationFailure { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.FileStatus ValidationInitiated { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.FileStatus ValidationNOTRequired { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.FileStatus ValidationSuccess { get { throw null; } }
        public bool Equals(Azure.Developer.LoadTesting.Models.FileStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.LoadTesting.Models.FileStatus left, Azure.Developer.LoadTesting.Models.FileStatus right) { throw null; }
        public static implicit operator Azure.Developer.LoadTesting.Models.FileStatus (string value) { throw null; }
        public static bool operator !=(Azure.Developer.LoadTesting.Models.FileStatus left, Azure.Developer.LoadTesting.Models.FileStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileType : System.IEquatable<Azure.Developer.LoadTesting.Models.FileType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileType(string value) { throw null; }
        public static Azure.Developer.LoadTesting.Models.FileType AdditionalArtifacts { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.FileType JMXFile { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.FileType UserProperties { get { throw null; } }
        public bool Equals(Azure.Developer.LoadTesting.Models.FileType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.LoadTesting.Models.FileType left, Azure.Developer.LoadTesting.Models.FileType right) { throw null; }
        public static implicit operator Azure.Developer.LoadTesting.Models.FileType (string value) { throw null; }
        public static bool operator !=(Azure.Developer.LoadTesting.Models.FileType left, Azure.Developer.LoadTesting.Models.FileType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Interval : System.IEquatable<Azure.Developer.LoadTesting.Models.Interval>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Interval(string value) { throw null; }
        public static Azure.Developer.LoadTesting.Models.Interval PT10S { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.Interval PT1H { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.Interval PT1M { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.Interval PT5M { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.Interval PT5S { get { throw null; } }
        public bool Equals(Azure.Developer.LoadTesting.Models.Interval other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.LoadTesting.Models.Interval left, Azure.Developer.LoadTesting.Models.Interval right) { throw null; }
        public static implicit operator Azure.Developer.LoadTesting.Models.Interval (string value) { throw null; }
        public static bool operator !=(Azure.Developer.LoadTesting.Models.Interval left, Azure.Developer.LoadTesting.Models.Interval right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LoadTestConfiguration
    {
        public LoadTestConfiguration() { }
        public int? EngineInstances { get { throw null; } set { } }
        public Azure.Developer.LoadTesting.Models.OptionalLoadTestConfig OptionalLoadTestConfig { get { throw null; } set { } }
        public bool? QuickStartTest { get { throw null; } set { } }
        public bool? SplitAllCSVs { get { throw null; } set { } }
    }
    public partial class MetricAvailability
    {
        internal MetricAvailability() { }
        public Azure.Developer.LoadTesting.Models.TimeGrain? TimeGrain { get { throw null; } }
    }
    public partial class MetricDefinition
    {
        internal MetricDefinition() { }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Developer.LoadTesting.Models.NameAndDesc> Dimensions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Developer.LoadTesting.Models.MetricAvailability> MetricAvailabilities { get { throw null; } }
        public string Name { get { throw null; } }
        public string Namespace { get { throw null; } }
        public Azure.Developer.LoadTesting.Models.AggregationType? PrimaryAggregationType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedAggregationTypes { get { throw null; } }
        public Azure.Developer.LoadTesting.Models.MetricUnit? Unit { get { throw null; } }
    }
    public partial class MetricDefinitionCollection
    {
        internal MetricDefinitionCollection() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Developer.LoadTesting.Models.MetricDefinition> Value { get { throw null; } }
    }
    public partial class MetricNamespace
    {
        internal MetricNamespace() { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class MetricNamespaceCollection
    {
        internal MetricNamespaceCollection() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Developer.LoadTesting.Models.MetricNamespace> Value { get { throw null; } }
    }
    public partial class MetricRequestPayload
    {
        public MetricRequestPayload() { }
        public System.Collections.Generic.IList<Azure.Developer.LoadTesting.Models.DimensionFilter> Filters { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MetricUnit : System.IEquatable<Azure.Developer.LoadTesting.Models.MetricUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MetricUnit(string value) { throw null; }
        public static Azure.Developer.LoadTesting.Models.MetricUnit Bytes { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.MetricUnit BytesPerSecond { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.MetricUnit Count { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.MetricUnit CountPerSecond { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.MetricUnit Milliseconds { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.MetricUnit NotSpecified { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.MetricUnit Percent { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.MetricUnit Seconds { get { throw null; } }
        public bool Equals(Azure.Developer.LoadTesting.Models.MetricUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.LoadTesting.Models.MetricUnit left, Azure.Developer.LoadTesting.Models.MetricUnit right) { throw null; }
        public static implicit operator Azure.Developer.LoadTesting.Models.MetricUnit (string value) { throw null; }
        public static bool operator !=(Azure.Developer.LoadTesting.Models.MetricUnit left, Azure.Developer.LoadTesting.Models.MetricUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MetricValue
    {
        internal MetricValue() { }
        public string Timestamp { get { throw null; } }
        public double? Value { get { throw null; } }
    }
    public partial class NameAndDesc
    {
        internal NameAndDesc() { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class OptionalLoadTestConfig
    {
        public OptionalLoadTestConfig() { }
        public int? Duration { get { throw null; } set { } }
        public string EndpointUrl { get { throw null; } set { } }
        public int? RampUpTime { get { throw null; } set { } }
        public int? VirtualUsers { get { throw null; } set { } }
    }
    public partial class PassFailCriteria
    {
        public PassFailCriteria() { }
        public System.Collections.Generic.IDictionary<string, Azure.Developer.LoadTesting.Models.PassFailMetric> PassFailMetrics { get { throw null; } }
    }
    public partial class PassFailMetric
    {
        public PassFailMetric() { }
        public Azure.Developer.LoadTesting.Models.PFAction? Action { get { throw null; } set { } }
        public double? ActualValue { get { throw null; } }
        public Azure.Developer.LoadTesting.Models.PFAgFunc? Aggregate { get { throw null; } set { } }
        public Azure.Developer.LoadTesting.Models.PFMetrics? ClientMetric { get { throw null; } set { } }
        public string Condition { get { throw null; } set { } }
        public string RequestName { get { throw null; } set { } }
        public Azure.Developer.LoadTesting.Models.PFResult? Result { get { throw null; } }
        public double? Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PFAction : System.IEquatable<Azure.Developer.LoadTesting.Models.PFAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PFAction(string value) { throw null; }
        public static Azure.Developer.LoadTesting.Models.PFAction Continue { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.PFAction Stop { get { throw null; } }
        public bool Equals(Azure.Developer.LoadTesting.Models.PFAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.LoadTesting.Models.PFAction left, Azure.Developer.LoadTesting.Models.PFAction right) { throw null; }
        public static implicit operator Azure.Developer.LoadTesting.Models.PFAction (string value) { throw null; }
        public static bool operator !=(Azure.Developer.LoadTesting.Models.PFAction left, Azure.Developer.LoadTesting.Models.PFAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PFAgFunc : System.IEquatable<Azure.Developer.LoadTesting.Models.PFAgFunc>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PFAgFunc(string value) { throw null; }
        public static Azure.Developer.LoadTesting.Models.PFAgFunc Avg { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.PFAgFunc Count { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.PFAgFunc Max { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.PFAgFunc Min { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.PFAgFunc P50 { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.PFAgFunc P90 { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.PFAgFunc P95 { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.PFAgFunc P99 { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.PFAgFunc Percentage { get { throw null; } }
        public bool Equals(Azure.Developer.LoadTesting.Models.PFAgFunc other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.LoadTesting.Models.PFAgFunc left, Azure.Developer.LoadTesting.Models.PFAgFunc right) { throw null; }
        public static implicit operator Azure.Developer.LoadTesting.Models.PFAgFunc (string value) { throw null; }
        public static bool operator !=(Azure.Developer.LoadTesting.Models.PFAgFunc left, Azure.Developer.LoadTesting.Models.PFAgFunc right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PFMetrics : System.IEquatable<Azure.Developer.LoadTesting.Models.PFMetrics>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PFMetrics(string value) { throw null; }
        public static Azure.Developer.LoadTesting.Models.PFMetrics Error { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.PFMetrics Latency { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.PFMetrics Requests { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.PFMetrics RequestsPerSec { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.PFMetrics ResponseTimeMs { get { throw null; } }
        public bool Equals(Azure.Developer.LoadTesting.Models.PFMetrics other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.LoadTesting.Models.PFMetrics left, Azure.Developer.LoadTesting.Models.PFMetrics right) { throw null; }
        public static implicit operator Azure.Developer.LoadTesting.Models.PFMetrics (string value) { throw null; }
        public static bool operator !=(Azure.Developer.LoadTesting.Models.PFMetrics left, Azure.Developer.LoadTesting.Models.PFMetrics right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PFResult : System.IEquatable<Azure.Developer.LoadTesting.Models.PFResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PFResult(string value) { throw null; }
        public static Azure.Developer.LoadTesting.Models.PFResult Failed { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.PFResult Passed { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.PFResult Undetermined { get { throw null; } }
        public bool Equals(Azure.Developer.LoadTesting.Models.PFResult other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.LoadTesting.Models.PFResult left, Azure.Developer.LoadTesting.Models.PFResult right) { throw null; }
        public static implicit operator Azure.Developer.LoadTesting.Models.PFResult (string value) { throw null; }
        public static bool operator !=(Azure.Developer.LoadTesting.Models.PFResult left, Azure.Developer.LoadTesting.Models.PFResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PFTestResult : System.IEquatable<Azure.Developer.LoadTesting.Models.PFTestResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PFTestResult(string value) { throw null; }
        public static Azure.Developer.LoadTesting.Models.PFTestResult Failed { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.PFTestResult NOTApplicable { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.PFTestResult Passed { get { throw null; } }
        public bool Equals(Azure.Developer.LoadTesting.Models.PFTestResult other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.LoadTesting.Models.PFTestResult left, Azure.Developer.LoadTesting.Models.PFTestResult right) { throw null; }
        public static implicit operator Azure.Developer.LoadTesting.Models.PFTestResult (string value) { throw null; }
        public static bool operator !=(Azure.Developer.LoadTesting.Models.PFTestResult left, Azure.Developer.LoadTesting.Models.PFTestResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceMetric
    {
        public ResourceMetric(string resourceId, string metricNamespace, string name, string aggregation, string resourceType) { }
        public string Aggregation { get { throw null; } set { } }
        public string DisplayDescription { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string MetricNamespace { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
        public string Unit { get { throw null; } set { } }
    }
    public partial class Secret
    {
        public Secret() { }
        public Azure.Developer.LoadTesting.Models.SecretType? Type { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecretType : System.IEquatable<Azure.Developer.LoadTesting.Models.SecretType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecretType(string value) { throw null; }
        public static Azure.Developer.LoadTesting.Models.SecretType AKVSecretURI { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.SecretType SecretValue { get { throw null; } }
        public bool Equals(Azure.Developer.LoadTesting.Models.SecretType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.LoadTesting.Models.SecretType left, Azure.Developer.LoadTesting.Models.SecretType right) { throw null; }
        public static implicit operator Azure.Developer.LoadTesting.Models.SecretType (string value) { throw null; }
        public static bool operator !=(Azure.Developer.LoadTesting.Models.SecretType left, Azure.Developer.LoadTesting.Models.SecretType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Status : System.IEquatable<Azure.Developer.LoadTesting.Models.Status>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Status(string value) { throw null; }
        public static Azure.Developer.LoadTesting.Models.Status Accepted { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.Status Cancelled { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.Status Cancelling { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.Status Configured { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.Status Configuring { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.Status Deprovisioned { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.Status Deprovisioning { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.Status Done { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.Status Executed { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.Status Executing { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.Status Failed { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.Status Notstarted { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.Status Provisioned { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.Status Provisioning { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.Status ValidationFailure { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.Status ValidationSuccess { get { throw null; } }
        public bool Equals(Azure.Developer.LoadTesting.Models.Status other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.LoadTesting.Models.Status left, Azure.Developer.LoadTesting.Models.Status right) { throw null; }
        public static implicit operator Azure.Developer.LoadTesting.Models.Status (string value) { throw null; }
        public static bool operator !=(Azure.Developer.LoadTesting.Models.Status left, Azure.Developer.LoadTesting.Models.Status right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Test
    {
        public Test() { }
        public Azure.Developer.LoadTesting.Models.CertificateMetadata Certificate { get { throw null; } set { } }
        public string CreatedBy { get { throw null; } }
        public System.DateTimeOffset? CreatedDateTime { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } }
        public Azure.Developer.LoadTesting.Models.TestInputArtifacts InputArtifacts { get { throw null; } }
        public string KeyvaultReferenceIdentityId { get { throw null; } set { } }
        public string KeyvaultReferenceIdentityType { get { throw null; } set { } }
        public string LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedDateTime { get { throw null; } }
        public Azure.Developer.LoadTesting.Models.LoadTestConfiguration LoadTestConfiguration { get { throw null; } set { } }
        public Azure.Developer.LoadTesting.Models.PassFailCriteria PassFailCriteria { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Developer.LoadTesting.Models.Secret> Secrets { get { throw null; } }
        public string SubnetId { get { throw null; } set { } }
        public string TestId { get { throw null; } }
    }
    public partial class TestAppComponents
    {
        public TestAppComponents(System.Collections.Generic.IDictionary<string, Azure.Developer.LoadTesting.Models.AppComponent> components) { }
        public System.Collections.Generic.IDictionary<string, Azure.Developer.LoadTesting.Models.AppComponent> Components { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public System.DateTimeOffset? CreatedDateTime { get { throw null; } }
        public string LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedDateTime { get { throw null; } }
        public string TestId { get { throw null; } }
    }
    public partial class TestInputArtifacts
    {
        internal TestInputArtifacts() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Developer.LoadTesting.Models.FileInfo> AdditionalFileInfo { get { throw null; } }
        public Azure.Developer.LoadTesting.Models.FileInfo ConfigFileInfo { get { throw null; } }
        public Azure.Developer.LoadTesting.Models.FileInfo InputArtifactsZipFileInfo { get { throw null; } }
        public Azure.Developer.LoadTesting.Models.FileInfo TestScriptFileInfo { get { throw null; } }
        public Azure.Developer.LoadTesting.Models.FileInfo UserPropFileInfo { get { throw null; } }
    }
    public partial class TestRun
    {
        public TestRun() { }
        public Azure.Developer.LoadTesting.Models.CertificateMetadata Certificate { get { throw null; } set { } }
        public string CreatedBy { get { throw null; } }
        public System.DateTimeOffset? CreatedDateTime { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public long? Duration { get { throw null; } }
        public System.DateTimeOffset? EndDateTime { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Developer.LoadTesting.Models.ErrorDetails> ErrorDetails { get { throw null; } }
        public System.DateTimeOffset? ExecutedDateTime { get { throw null; } }
        public string LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedDateTime { get { throw null; } }
        public Azure.Developer.LoadTesting.Models.LoadTestConfiguration LoadTestConfiguration { get { throw null; } set { } }
        public Azure.Developer.LoadTesting.Models.PassFailCriteria PassFailCriteria { get { throw null; } set { } }
        public string PortalUrl { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Developer.LoadTesting.Models.Secret> Secrets { get { throw null; } }
        public System.DateTimeOffset? StartDateTime { get { throw null; } }
        public Azure.Developer.LoadTesting.Models.Status? Status { get { throw null; } }
        public string SubnetId { get { throw null; } }
        public Azure.Developer.LoadTesting.Models.TestRunArtifacts TestArtifacts { get { throw null; } }
        public string TestId { get { throw null; } set { } }
        public Azure.Developer.LoadTesting.Models.PFTestResult? TestResult { get { throw null; } }
        public string TestRunId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.Developer.LoadTesting.Models.TestRunStatistics> TestRunStatistics { get { throw null; } }
        public int? VirtualUsers { get { throw null; } }
    }
    public partial class TestRunAppComponents
    {
        public TestRunAppComponents(System.Collections.Generic.IDictionary<string, Azure.Developer.LoadTesting.Models.AppComponent> components) { }
        public System.Collections.Generic.IDictionary<string, Azure.Developer.LoadTesting.Models.AppComponent> Components { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public System.DateTimeOffset? CreatedDateTime { get { throw null; } }
        public string LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedDateTime { get { throw null; } }
        public string TestRunId { get { throw null; } }
    }
    public partial class TestRunArtifacts
    {
        internal TestRunArtifacts() { }
        public Azure.Developer.LoadTesting.Models.TestRunInputArtifacts InputArtifacts { get { throw null; } }
        public Azure.Developer.LoadTesting.Models.TestRunOutputArtifacts OutputArtifacts { get { throw null; } }
    }
    public partial class TestRunInputArtifacts
    {
        internal TestRunInputArtifacts() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Developer.LoadTesting.Models.FileInfo> AdditionalFileInfo { get { throw null; } }
        public Azure.Developer.LoadTesting.Models.FileInfo ConfigFileInfo { get { throw null; } }
        public Azure.Developer.LoadTesting.Models.FileInfo InputArtifactsZipFileInfo { get { throw null; } }
        public Azure.Developer.LoadTesting.Models.FileInfo TestScriptFileInfo { get { throw null; } }
        public Azure.Developer.LoadTesting.Models.FileInfo UserPropFileInfo { get { throw null; } }
    }
    public partial class TestRunOutputArtifacts
    {
        internal TestRunOutputArtifacts() { }
        public Azure.Developer.LoadTesting.Models.FileInfo LogsFileInfo { get { throw null; } }
        public Azure.Developer.LoadTesting.Models.FileInfo ResultFileInfo { get { throw null; } }
    }
    public partial class TestRunServerMetricConfig
    {
        public TestRunServerMetricConfig() { }
        public string CreatedBy { get { throw null; } }
        public System.DateTimeOffset? CreatedDateTime { get { throw null; } }
        public string LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedDateTime { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Developer.LoadTesting.Models.ResourceMetric> Metrics { get { throw null; } }
        public string TestRunId { get { throw null; } }
    }
    public partial class TestRunStatistics
    {
        internal TestRunStatistics() { }
        public double? ErrorCount { get { throw null; } }
        public double? ErrorPct { get { throw null; } }
        public double? MaxResTime { get { throw null; } }
        public double? MeanResTime { get { throw null; } }
        public double? MedianResTime { get { throw null; } }
        public double? MinResTime { get { throw null; } }
        public double? Pct1ResTime { get { throw null; } }
        public double? Pct2ResTime { get { throw null; } }
        public double? Pct3ResTime { get { throw null; } }
        public double? ReceivedKBytesPerSec { get { throw null; } }
        public double? SampleCount { get { throw null; } }
        public double? SentKBytesPerSec { get { throw null; } }
        public double? Throughput { get { throw null; } }
        public string Transaction { get { throw null; } }
    }
    public partial class TestServerMetricConfig
    {
        public TestServerMetricConfig() { }
        public string CreatedBy { get { throw null; } }
        public System.DateTimeOffset? CreatedDateTime { get { throw null; } }
        public string LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedDateTime { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Developer.LoadTesting.Models.ResourceMetric> Metrics { get { throw null; } }
        public string TestId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TimeGrain : System.IEquatable<Azure.Developer.LoadTesting.Models.TimeGrain>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TimeGrain(string value) { throw null; }
        public static Azure.Developer.LoadTesting.Models.TimeGrain PT10S { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.TimeGrain PT1H { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.TimeGrain PT1M { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.TimeGrain PT5M { get { throw null; } }
        public static Azure.Developer.LoadTesting.Models.TimeGrain PT5S { get { throw null; } }
        public bool Equals(Azure.Developer.LoadTesting.Models.TimeGrain other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.LoadTesting.Models.TimeGrain left, Azure.Developer.LoadTesting.Models.TimeGrain right) { throw null; }
        public static implicit operator Azure.Developer.LoadTesting.Models.TimeGrain (string value) { throw null; }
        public static bool operator !=(Azure.Developer.LoadTesting.Models.TimeGrain left, Azure.Developer.LoadTesting.Models.TimeGrain right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TimeSeriesElement
    {
        internal TimeSeriesElement() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Developer.LoadTesting.Models.MetricValue> Data { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Developer.LoadTesting.Models.DimensionValue> DimensionValues { get { throw null; } }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AzureLoadTestingClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Developer.LoadTesting.LoadTestAdministrationClient, Azure.Developer.LoadTesting.LoadTestingClientOptions> AddLoadTestAdministrationClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Developer.LoadTesting.LoadTestAdministrationClient, Azure.Developer.LoadTesting.LoadTestingClientOptions> AddLoadTestAdministrationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Developer.LoadTesting.LoadTestRunClient, Azure.Developer.LoadTesting.LoadTestingClientOptions> AddLoadTestRunClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Developer.LoadTesting.LoadTestRunClient, Azure.Developer.LoadTesting.LoadTestingClientOptions> AddLoadTestRunClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
