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
    public partial class LoadTestConfiguration
    {
        public LoadTestConfiguration() { }
        public int? EngineInstances { get { throw null; } set { } }
        public Azure.Developer.LoadTesting.Models.OptionalLoadTestConfig OptionalLoadTestConfig { get { throw null; } set { } }
        public bool? QuickStartTest { get { throw null; } set { } }
        public bool? SplitAllCSVs { get { throw null; } set { } }
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
    public partial class Test : Azure.Core.Serialization.IModelJsonSerializable<Azure.Developer.LoadTesting.Models.Test>, Azure.Core.Serialization.IModelSerializable<Azure.Developer.LoadTesting.Models.Test>
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
        Azure.Developer.LoadTesting.Models.Test Azure.Core.Serialization.IModelJsonSerializable<Azure.Developer.LoadTesting.Models.Test>.Deserialize(ref System.Text.Json.Utf8JsonReader reader, Azure.Core.Serialization.ModelSerializerOptions options) { throw null; }
        void Azure.Core.Serialization.IModelJsonSerializable<Azure.Developer.LoadTesting.Models.Test>.Serialize(System.Text.Json.Utf8JsonWriter writer, Azure.Core.Serialization.ModelSerializerOptions options) { }
        Azure.Developer.LoadTesting.Models.Test Azure.Core.Serialization.IModelSerializable<Azure.Developer.LoadTesting.Models.Test>.Deserialize(System.BinaryData data, Azure.Core.Serialization.ModelSerializerOptions options) { throw null; }
        System.BinaryData Azure.Core.Serialization.IModelSerializable<Azure.Developer.LoadTesting.Models.Test>.Serialize(Azure.Core.Serialization.ModelSerializerOptions options) { throw null; }
        public static explicit operator Azure.Developer.LoadTesting.Models.Test (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Developer.LoadTesting.Models.Test model) { throw null; }
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
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AzureLoadTestingClientBuilderExtensions
    {
    }
}
