namespace Azure.AI.AnomalyDetector
{
    public partial class AnomalyDetectorClient
    {
        protected AnomalyDetectorClient() { }
        public AnomalyDetectorClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.AnomalyDetector.AnomalyDetectorClientOptions options = null) { }
        public AnomalyDetectorClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.AnomalyDetector.AnomalyDetectorClientOptions options = null) { }
        public virtual Azure.Response DeleteMultivariateModel(System.Guid modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteMultivariateModelAsync(System.Guid modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DetectAnomaly(System.Guid modelId, Azure.AI.AnomalyDetector.Models.DetectionRequest detectionRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DetectAnomalyAsync(System.Guid modelId, Azure.AI.AnomalyDetector.Models.DetectionRequest detectionRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.AnomalyDetector.Models.ChangePointDetectResponse> DetectChangePoint(Azure.AI.AnomalyDetector.Models.ChangePointDetectRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.AnomalyDetector.Models.ChangePointDetectResponse>> DetectChangePointAsync(Azure.AI.AnomalyDetector.Models.ChangePointDetectRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.AnomalyDetector.Models.EntireDetectResponse> DetectEntireSeries(Azure.AI.AnomalyDetector.Models.DetectRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.AnomalyDetector.Models.EntireDetectResponse>> DetectEntireSeriesAsync(Azure.AI.AnomalyDetector.Models.DetectRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.AnomalyDetector.Models.LastDetectResponse> DetectLastPoint(Azure.AI.AnomalyDetector.Models.DetectRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.AnomalyDetector.Models.LastDetectResponse>> DetectLastPointAsync(Azure.AI.AnomalyDetector.Models.DetectRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> ExportModel(System.Guid modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> ExportModelAsync(System.Guid modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.AnomalyDetector.Models.DetectionResult> GetDetectionResult(System.Guid resultId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.AnomalyDetector.Models.DetectionResult>> GetDetectionResultAsync(System.Guid resultId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.AnomalyDetector.Models.Model> GetMultivariateModel(System.Guid modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.AnomalyDetector.Models.Model>> GetMultivariateModelAsync(System.Guid modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.AnomalyDetector.Models.ModelSnapshot> ListMultivariateModel(int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.AnomalyDetector.Models.ModelSnapshot> ListMultivariateModelAsync(int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response TrainMultivariateModel(Azure.AI.AnomalyDetector.Models.ModelInfo modelRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> TrainMultivariateModelAsync(Azure.AI.AnomalyDetector.Models.ModelInfo modelRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AnomalyDetectorClientOptions : Azure.Core.ClientOptions
    {
        public AnomalyDetectorClientOptions(Azure.AI.AnomalyDetector.AnomalyDetectorClientOptions.ServiceVersion version = Azure.AI.AnomalyDetector.AnomalyDetectorClientOptions.ServiceVersion.V1_1_preview) { }
        public enum ServiceVersion
        {
            V1_1_preview = 1,
        }
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
        public int? PaddingValue { get { throw null; } set { } }
    }
    public partial class AnomalyContributor
    {
        internal AnomalyContributor() { }
        public float? ContributionScore { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AnomalyDetector.Models.AnomalyContributor> Contributors { get { throw null; } }
        public bool IsAnomaly { get { throw null; } }
        public float? Score { get { throw null; } }
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
    public partial class DetectionRequest
    {
        public DetectionRequest(string source, System.DateTimeOffset startTime, System.DateTimeOffset endTime) { }
        public System.DateTimeOffset EndTime { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        public System.DateTimeOffset StartTime { get { throw null; } set { } }
    }
    public partial class DetectionResult
    {
        internal DetectionResult() { }
        public System.Guid ResultId { get { throw null; } }
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
        public float? MaxAnomalyRatio { get { throw null; } set { } }
        public int? Period { get { throw null; } set { } }
        public int? Sensitivity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.AnomalyDetector.Models.TimeSeriesPoint> Series { get { throw null; } }
    }
    public partial class DiagnosticsInfo
    {
        internal DiagnosticsInfo() { }
        public Azure.AI.AnomalyDetector.Models.ModelState ModelState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AnomalyDetector.Models.VariableState> VariableStates { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyList<float> UpperMargins { get { throw null; } }
    }
    public partial class ErrorResponse
    {
        internal ErrorResponse() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public enum FillNAMethod
    {
        Previous = 0,
        Subsequent = 1,
        Linear = 2,
        Zero = 3,
        Pad = 4,
        NotFill = 5,
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
        public int SuggestedWindow { get { throw null; } }
        public float UpperMargin { get { throw null; } }
    }
    public partial class Model
    {
        internal Model() { }
        public System.DateTimeOffset CreatedTime { get { throw null; } }
        public System.DateTimeOffset LastUpdatedTime { get { throw null; } }
        public System.Guid ModelId { get { throw null; } }
        public Azure.AI.AnomalyDetector.Models.ModelInfo ModelInfo { get { throw null; } }
    }
    public partial class ModelInfo
    {
        public ModelInfo(string source, System.DateTimeOffset startTime, System.DateTimeOffset endTime) { }
        public Azure.AI.AnomalyDetector.Models.AlignPolicy AlignPolicy { get { throw null; } set { } }
        public Azure.AI.AnomalyDetector.Models.DiagnosticsInfo DiagnosticsInfo { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset EndTime { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AnomalyDetector.Models.ErrorResponse> Errors { get { throw null; } }
        public int? SlidingWindow { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        public System.DateTimeOffset StartTime { get { throw null; } set { } }
        public Azure.AI.AnomalyDetector.Models.ModelStatus? Status { get { throw null; } }
    }
    public partial class ModelSnapshot
    {
        internal ModelSnapshot() { }
        public System.DateTimeOffset CreatedTime { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.DateTimeOffset LastUpdatedTime { get { throw null; } }
        public System.Guid ModelId { get { throw null; } }
        public Azure.AI.AnomalyDetector.Models.ModelStatus Status { get { throw null; } }
        public int VariablesCount { get { throw null; } }
    }
    public partial class ModelState
    {
        internal ModelState() { }
        public System.Collections.Generic.IReadOnlyList<int> EpochIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<float> LatenciesInSeconds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<float> TrainLosses { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<float> ValidationLosses { get { throw null; } }
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
        internal VariableState() { }
        public int? EffectiveCount { get { throw null; } }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AnomalyDetector.Models.ErrorResponse> Errors { get { throw null; } }
        public float? FilledNARatio { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public string Variable { get { throw null; } }
    }
}
