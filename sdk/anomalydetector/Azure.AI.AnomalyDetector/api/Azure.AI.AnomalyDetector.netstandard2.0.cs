namespace Azure.AI.AnomalyDetector
{
    public partial class AnomalyDetectorClientOptions : Azure.Core.ClientOptions
    {
        public AnomalyDetectorClientOptions(Azure.AI.AnomalyDetector.AnomalyDetectorClientOptions.ServiceVersion version = Azure.AI.AnomalyDetector.AnomalyDetectorClientOptions.ServiceVersion.V1_0) { }
        public enum ServiceVersion
        {
            V1_0 = 1,
        }
    }
    public partial class MultivariateClient
    {
        protected MultivariateClient() { }
        public MultivariateClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public MultivariateClient(System.Uri endpoint, Azure.AzureKeyCredential credential, string apiVersion, Azure.AI.AnomalyDetector.AnomalyDetectorClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.AnomalyDetector.Models.Model> CreateAndTrainMultivariateModel(Azure.AI.AnomalyDetector.Models.ModelInfo body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateAndTrainMultivariateModel(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.AnomalyDetector.Models.Model>> CreateAndTrainMultivariateModelAsync(Azure.AI.AnomalyDetector.Models.ModelInfo body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAndTrainMultivariateModelAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteMultivariateModel(string modelId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteMultivariateModelAsync(string modelId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.AnomalyDetector.Models.DetectionResult> DetectMultivariateBatchAnomaly(string modelId, Azure.AI.AnomalyDetector.Models.DetectionRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DetectMultivariateBatchAnomaly(string modelId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.AnomalyDetector.Models.DetectionResult>> DetectMultivariateBatchAnomalyAsync(string modelId, Azure.AI.AnomalyDetector.Models.DetectionRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DetectMultivariateBatchAnomalyAsync(string modelId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.AnomalyDetector.Models.LastDetectionResult> DetectMultivariateLastAnomaly(string modelId, Azure.AI.AnomalyDetector.Models.LastDetectionRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DetectMultivariateLastAnomaly(string modelId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.AnomalyDetector.Models.LastDetectionResult>> DetectMultivariateLastAnomalyAsync(string modelId, Azure.AI.AnomalyDetector.Models.LastDetectionRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DetectMultivariateLastAnomalyAsync(string modelId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetBatchDetectionResult(string resultId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetBatchDetectionResultAsync(string resultId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.AnomalyDetector.Models.DetectionResult> GetBatchDetectionResultValue(string resultId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.AnomalyDetector.Models.DetectionResult>> GetBatchDetectionResultValueAsync(string resultId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetMultivariateModel(string modelId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetMultivariateModelAsync(string modelId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetMultivariateModels(int? skip = default(int?), int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetMultivariateModelsAsync(int? skip = default(int?), int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.AnomalyDetector.Models.Model> GetMultivariateModelValue(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.AnomalyDetector.Models.Model>> GetMultivariateModelValueAsync(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UnivariateClient
    {
        protected UnivariateClient() { }
        public UnivariateClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public UnivariateClient(System.Uri endpoint, Azure.AzureKeyCredential credential, string apiVersion, Azure.AI.AnomalyDetector.AnomalyDetectorClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.AnomalyDetector.Models.ChangePointDetectResponse> DetectUnivariateChangePoint(Azure.AI.AnomalyDetector.Models.ChangePointDetectRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DetectUnivariateChangePoint(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.AnomalyDetector.Models.ChangePointDetectResponse>> DetectUnivariateChangePointAsync(Azure.AI.AnomalyDetector.Models.ChangePointDetectRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DetectUnivariateChangePointAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.AnomalyDetector.Models.EntireDetectResponse> DetectUnivariateEntireSeries(Azure.AI.AnomalyDetector.Models.DetectRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DetectUnivariateEntireSeries(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.AnomalyDetector.Models.EntireDetectResponse>> DetectUnivariateEntireSeriesAsync(Azure.AI.AnomalyDetector.Models.DetectRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DetectUnivariateEntireSeriesAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.AnomalyDetector.Models.LastDetectResponse> DetectUnivariateLastPoint(Azure.AI.AnomalyDetector.Models.DetectRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DetectUnivariateLastPoint(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.AnomalyDetector.Models.LastDetectResponse>> DetectUnivariateLastPointAsync(Azure.AI.AnomalyDetector.Models.DetectRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DetectUnivariateLastPointAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
}
namespace Azure.AI.AnomalyDetector.Models
{
    public enum AlignMode
    {
        Inner = 0,
        Outer = 1,
    }
    public partial class AlignPolicy
    {
        public AlignPolicy() { }
        public Azure.AI.AnomalyDetector.Models.AlignMode? AlignMode { get { throw null; } set { } }
        public Azure.AI.AnomalyDetector.Models.FillNAMethod? FillNAMethod { get { throw null; } set { } }
        public float? PaddingValue { get { throw null; } set { } }
    }
    public partial class AnomalyInterpretation
    {
        internal AnomalyInterpretation() { }
        public float? ContributionScore { get { throw null; } }
        public Azure.AI.AnomalyDetector.Models.CorrelationChanges CorrelationChanges { get { throw null; } }
        public string Variable { get { throw null; } }
    }
    public partial class AnomalyState
    {
        internal AnomalyState() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AnomalyDetector.Models.ErrorResponse> Errors { get { throw null; } }
        public System.DateTimeOffset Timestamp { get { throw null; } }
        public Azure.AI.AnomalyDetector.Models.AnomalyValue Value { get { throw null; } }
    }
    public partial class AnomalyValue
    {
        internal AnomalyValue() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AnomalyDetector.Models.AnomalyInterpretation> Interpretation { get { throw null; } }
        public bool IsAnomaly { get { throw null; } }
        public float Score { get { throw null; } }
        public float Severity { get { throw null; } }
    }
    public partial class ChangePointDetectRequest
    {
        public ChangePointDetectRequest(System.Collections.Generic.IEnumerable<Azure.AI.AnomalyDetector.Models.TimeSeriesPoint> series, Azure.AI.AnomalyDetector.Models.TimeGranularity granularity) { }
        public int? CustomInterval { get { throw null; } set { } }
        public Azure.AI.AnomalyDetector.Models.TimeGranularity Granularity { get { throw null; } }
        public int? Period { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.AnomalyDetector.Models.TimeSeriesPoint> Series { get { throw null; } }
        public int? StableTrendWindow { get { throw null; } set { } }
        public float? Threshold { get { throw null; } set { } }
    }
    public partial class ChangePointDetectResponse
    {
        internal ChangePointDetectResponse() { }
        public System.Collections.Generic.IReadOnlyList<float> ConfidenceScores { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<bool> IsChangePoint { get { throw null; } }
        public int? Period { get { throw null; } }
    }
    public partial class CorrelationChanges
    {
        internal CorrelationChanges() { }
        public System.Collections.Generic.IReadOnlyList<string> ChangedVariables { get { throw null; } }
    }
    public enum DataSchema
    {
        OneTable = 0,
        MultiTable = 1,
    }
    public partial class DetectionRequest
    {
        public DetectionRequest(string dataSource, int topContributorCount, System.DateTimeOffset startTime, System.DateTimeOffset endTime) { }
        public string DataSource { get { throw null; } set { } }
        public System.DateTimeOffset EndTime { get { throw null; } set { } }
        public System.DateTimeOffset StartTime { get { throw null; } set { } }
        public int TopContributorCount { get { throw null; } set { } }
    }
    public partial class DetectionResult
    {
        internal DetectionResult() { }
        public string ResultId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AnomalyDetector.Models.AnomalyState> Results { get { throw null; } }
        public Azure.AI.AnomalyDetector.Models.DetectionResultSummary Summary { get { throw null; } }
    }
    public partial class DetectionResultSummary
    {
        internal DetectionResultSummary() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AnomalyDetector.Models.ErrorResponse> Errors { get { throw null; } }
        public Azure.AI.AnomalyDetector.Models.DetectionRequest SetupInfo { get { throw null; } }
        public Azure.AI.AnomalyDetector.Models.DetectionStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AnomalyDetector.Models.VariableState> VariableStates { get { throw null; } }
    }
    public enum DetectionStatus
    {
        Created = 0,
        Running = 1,
        Ready = 2,
        Failed = 3,
    }
    public partial class DetectRequest
    {
        public DetectRequest(System.Collections.Generic.IEnumerable<Azure.AI.AnomalyDetector.Models.TimeSeriesPoint> series) { }
        public int? CustomInterval { get { throw null; } set { } }
        public Azure.AI.AnomalyDetector.Models.TimeGranularity? Granularity { get { throw null; } set { } }
        public float? ImputeFixedValue { get { throw null; } set { } }
        public Azure.AI.AnomalyDetector.Models.ImputeMode? ImputeMode { get { throw null; } set { } }
        public float? MaxAnomalyRatio { get { throw null; } set { } }
        public int? Period { get { throw null; } set { } }
        public int? Sensitivity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.AnomalyDetector.Models.TimeSeriesPoint> Series { get { throw null; } }
    }
    public partial class DiagnosticsInfo
    {
        public DiagnosticsInfo() { }
        public Azure.AI.AnomalyDetector.Models.ModelState ModelState { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.AnomalyDetector.Models.VariableState> VariableStates { get { throw null; } }
    }
    public partial class EntireDetectResponse
    {
        internal EntireDetectResponse() { }
        public System.Collections.Generic.IReadOnlyList<float> ExpectedValues { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<bool> IsAnomaly { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<bool> IsNegativeAnomaly { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<bool> IsPositiveAnomaly { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<float> LowerMargins { get { throw null; } }
        public int Period { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<float> Severity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<float> UpperMargins { get { throw null; } }
    }
    public partial class ErrorResponse
    {
        public ErrorResponse(string code, string message) { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FillNAMethod : System.IEquatable<Azure.AI.AnomalyDetector.Models.FillNAMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FillNAMethod(string value) { throw null; }
        public static Azure.AI.AnomalyDetector.Models.FillNAMethod Fixed { get { throw null; } }
        public static Azure.AI.AnomalyDetector.Models.FillNAMethod Linear { get { throw null; } }
        public static Azure.AI.AnomalyDetector.Models.FillNAMethod Previous { get { throw null; } }
        public static Azure.AI.AnomalyDetector.Models.FillNAMethod Subsequent { get { throw null; } }
        public static Azure.AI.AnomalyDetector.Models.FillNAMethod Zero { get { throw null; } }
        public bool Equals(Azure.AI.AnomalyDetector.Models.FillNAMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AnomalyDetector.Models.FillNAMethod left, Azure.AI.AnomalyDetector.Models.FillNAMethod right) { throw null; }
        public static implicit operator Azure.AI.AnomalyDetector.Models.FillNAMethod (string value) { throw null; }
        public static bool operator !=(Azure.AI.AnomalyDetector.Models.FillNAMethod left, Azure.AI.AnomalyDetector.Models.FillNAMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImputeMode : System.IEquatable<Azure.AI.AnomalyDetector.Models.ImputeMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImputeMode(string value) { throw null; }
        public static Azure.AI.AnomalyDetector.Models.ImputeMode Auto { get { throw null; } }
        public static Azure.AI.AnomalyDetector.Models.ImputeMode Fixed { get { throw null; } }
        public static Azure.AI.AnomalyDetector.Models.ImputeMode Linear { get { throw null; } }
        public static Azure.AI.AnomalyDetector.Models.ImputeMode NotFill { get { throw null; } }
        public static Azure.AI.AnomalyDetector.Models.ImputeMode Previous { get { throw null; } }
        public static Azure.AI.AnomalyDetector.Models.ImputeMode Zero { get { throw null; } }
        public bool Equals(Azure.AI.AnomalyDetector.Models.ImputeMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AnomalyDetector.Models.ImputeMode left, Azure.AI.AnomalyDetector.Models.ImputeMode right) { throw null; }
        public static implicit operator Azure.AI.AnomalyDetector.Models.ImputeMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.AnomalyDetector.Models.ImputeMode left, Azure.AI.AnomalyDetector.Models.ImputeMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LastDetectionRequest
    {
        public LastDetectionRequest(System.Collections.Generic.IEnumerable<Azure.AI.AnomalyDetector.Models.VariableValues> variables, int topContributorCount) { }
        public int TopContributorCount { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.AnomalyDetector.Models.VariableValues> Variables { get { throw null; } }
    }
    public partial class LastDetectionResult
    {
        internal LastDetectionResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AnomalyDetector.Models.AnomalyState> Results { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AnomalyDetector.Models.VariableState> VariableStates { get { throw null; } }
    }
    public partial class LastDetectResponse
    {
        internal LastDetectResponse() { }
        public float ExpectedValue { get { throw null; } }
        public bool IsAnomaly { get { throw null; } }
        public bool IsNegativeAnomaly { get { throw null; } }
        public bool IsPositiveAnomaly { get { throw null; } }
        public float LowerMargin { get { throw null; } }
        public int Period { get { throw null; } }
        public float? Severity { get { throw null; } }
        public int SuggestedWindow { get { throw null; } }
        public float UpperMargin { get { throw null; } }
    }
    public partial class Model
    {
        internal Model() { }
        public System.DateTimeOffset CreatedTime { get { throw null; } }
        public System.DateTimeOffset LastUpdatedTime { get { throw null; } }
        public string ModelId { get { throw null; } }
        public Azure.AI.AnomalyDetector.Models.ModelInfo ModelInfo { get { throw null; } }
    }
    public partial class ModelInfo
    {
        public ModelInfo(string dataSource, System.DateTimeOffset startTime, System.DateTimeOffset endTime) { }
        public Azure.AI.AnomalyDetector.Models.AlignPolicy AlignPolicy { get { throw null; } set { } }
        public Azure.AI.AnomalyDetector.Models.DataSchema? DataSchema { get { throw null; } set { } }
        public string DataSource { get { throw null; } set { } }
        public Azure.AI.AnomalyDetector.Models.DiagnosticsInfo DiagnosticsInfo { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset EndTime { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.AnomalyDetector.Models.ErrorResponse> Errors { get { throw null; } }
        public int? SlidingWindow { get { throw null; } set { } }
        public System.DateTimeOffset StartTime { get { throw null; } set { } }
        public Azure.AI.AnomalyDetector.Models.ModelStatus? Status { get { throw null; } set { } }
    }
    public partial class ModelList
    {
        internal ModelList() { }
        public int CurrentCount { get { throw null; } }
        public int MaxCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AnomalyDetector.Models.Model> Models { get { throw null; } }
        public string NextLink { get { throw null; } }
    }
    public partial class ModelState
    {
        public ModelState() { }
        public System.Collections.Generic.IList<int> EpochIds { get { throw null; } }
        public System.Collections.Generic.IList<float> LatenciesInSeconds { get { throw null; } }
        public System.Collections.Generic.IList<float> TrainLosses { get { throw null; } }
        public System.Collections.Generic.IList<float> ValidationLosses { get { throw null; } }
    }
    public enum ModelStatus
    {
        Created = 0,
        Running = 1,
        Ready = 2,
        Failed = 3,
    }
    public enum TimeGranularity
    {
        Yearly = 0,
        Monthly = 1,
        Weekly = 2,
        Daily = 3,
        Hourly = 4,
        PerMinute = 5,
        PerSecond = 6,
        Microsecond = 7,
        None = 8,
    }
    public partial class TimeSeriesPoint
    {
        public TimeSeriesPoint(float value) { }
        public System.DateTimeOffset? Timestamp { get { throw null; } set { } }
        public float Value { get { throw null; } }
    }
    public partial class VariableState
    {
        public VariableState() { }
        public int? EffectiveCount { get { throw null; } set { } }
        public float? FilledNARatio { get { throw null; } set { } }
        public System.DateTimeOffset? FirstTimestamp { get { throw null; } set { } }
        public System.DateTimeOffset? LastTimestamp { get { throw null; } set { } }
        public string Variable { get { throw null; } set { } }
    }
    public partial class VariableValues
    {
        public VariableValues(string variable, System.Collections.Generic.IEnumerable<string> timestamps, System.Collections.Generic.IEnumerable<float> values) { }
        public System.Collections.Generic.IList<string> Timestamps { get { throw null; } }
        public System.Collections.Generic.IList<float> Values { get { throw null; } }
        public string Variable { get { throw null; } }
    }
}
