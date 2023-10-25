namespace Azure.AI.AnomalyDetector
{
    public static partial class AIAnomalyDetectorModelFactory
    {
        public static Azure.AI.AnomalyDetector.AnomalyDetectionModel AnomalyDetectionModel(System.Guid modelId = default(System.Guid), System.DateTimeOffset createdTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedTime = default(System.DateTimeOffset), Azure.AI.AnomalyDetector.ModelInfo modelInfo = null) { throw null; }
        public static Azure.AI.AnomalyDetector.AnomalyInterpretation AnomalyInterpretation(string variable = null, float? contributionScore = default(float?), Azure.AI.AnomalyDetector.CorrelationChanges correlationChanges = null) { throw null; }
        public static Azure.AI.AnomalyDetector.AnomalyState AnomalyState(System.DateTimeOffset timestamp = default(System.DateTimeOffset), Azure.AI.AnomalyDetector.AnomalyValue value = null, System.Collections.Generic.IEnumerable<Azure.AI.AnomalyDetector.ErrorResponse> errors = null) { throw null; }
        public static Azure.AI.AnomalyDetector.AnomalyValue AnomalyValue(bool isAnomaly = false, float severity = 0f, float score = 0f, System.Collections.Generic.IEnumerable<Azure.AI.AnomalyDetector.AnomalyInterpretation> interpretation = null) { throw null; }
        public static Azure.AI.AnomalyDetector.CorrelationChanges CorrelationChanges(System.Collections.Generic.IEnumerable<string> changedVariables = null) { throw null; }
        public static Azure.AI.AnomalyDetector.ModelInfo ModelInfo(System.Uri dataSource = null, Azure.AI.AnomalyDetector.DataSchema? dataSchema = default(Azure.AI.AnomalyDetector.DataSchema?), System.DateTimeOffset startTime = default(System.DateTimeOffset), System.DateTimeOffset endTime = default(System.DateTimeOffset), string displayName = null, int? slidingWindow = default(int?), Azure.AI.AnomalyDetector.AlignPolicy alignPolicy = null, Azure.AI.AnomalyDetector.ModelStatus? status = default(Azure.AI.AnomalyDetector.ModelStatus?), System.Collections.Generic.IEnumerable<Azure.AI.AnomalyDetector.ErrorResponse> errors = null, Azure.AI.AnomalyDetector.DiagnosticsInfo diagnosticsInfo = null) { throw null; }
        public static Azure.AI.AnomalyDetector.MultivariateBatchDetectionResultSummary MultivariateBatchDetectionResultSummary(Azure.AI.AnomalyDetector.MultivariateBatchDetectionStatus status = default(Azure.AI.AnomalyDetector.MultivariateBatchDetectionStatus), System.Collections.Generic.IEnumerable<Azure.AI.AnomalyDetector.ErrorResponse> errors = null, System.Collections.Generic.IEnumerable<Azure.AI.AnomalyDetector.VariableState> variableStates = null, Azure.AI.AnomalyDetector.MultivariateBatchDetectionOptions setupInfo = null) { throw null; }
        public static Azure.AI.AnomalyDetector.MultivariateDetectionResult MultivariateDetectionResult(System.Guid resultId = default(System.Guid), Azure.AI.AnomalyDetector.MultivariateBatchDetectionResultSummary summary = null, System.Collections.Generic.IEnumerable<Azure.AI.AnomalyDetector.AnomalyState> results = null) { throw null; }
        public static Azure.AI.AnomalyDetector.MultivariateLastDetectionResult MultivariateLastDetectionResult(System.Collections.Generic.IEnumerable<Azure.AI.AnomalyDetector.VariableState> variableStates = null, System.Collections.Generic.IEnumerable<Azure.AI.AnomalyDetector.AnomalyState> results = null) { throw null; }
        public static Azure.AI.AnomalyDetector.UnivariateChangePointDetectionResult UnivariateChangePointDetectionResult(int? period = default(int?), System.Collections.Generic.IEnumerable<bool> isChangePoint = null, System.Collections.Generic.IEnumerable<float> confidenceScores = null) { throw null; }
        public static Azure.AI.AnomalyDetector.UnivariateLastDetectionResult UnivariateLastDetectionResult(int period = 0, int suggestedWindow = 0, float expectedValue = 0f, float upperMargin = 0f, float lowerMargin = 0f, bool isAnomaly = false, bool isNegativeAnomaly = false, bool isPositiveAnomaly = false, float? severity = default(float?)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlignMode : System.IEquatable<Azure.AI.AnomalyDetector.AlignMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlignMode(string value) { throw null; }
        public static Azure.AI.AnomalyDetector.AlignMode Inner { get { throw null; } }
        public static Azure.AI.AnomalyDetector.AlignMode Outer { get { throw null; } }
        public bool Equals(Azure.AI.AnomalyDetector.AlignMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AnomalyDetector.AlignMode left, Azure.AI.AnomalyDetector.AlignMode right) { throw null; }
        public static implicit operator Azure.AI.AnomalyDetector.AlignMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.AnomalyDetector.AlignMode left, Azure.AI.AnomalyDetector.AlignMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AlignPolicy
    {
        public AlignPolicy() { }
        public Azure.AI.AnomalyDetector.AlignMode? AlignMode { get { throw null; } set { } }
        public Azure.AI.AnomalyDetector.FillNAMethod? FillNAMethod { get { throw null; } set { } }
        public float? PaddingValue { get { throw null; } set { } }
    }
    public partial class AnomalyDetectionModel
    {
        internal AnomalyDetectionModel() { }
        public System.DateTimeOffset CreatedTime { get { throw null; } }
        public System.DateTimeOffset LastUpdatedTime { get { throw null; } }
        public System.Guid ModelId { get { throw null; } }
        public Azure.AI.AnomalyDetector.ModelInfo ModelInfo { get { throw null; } }
    }
    public partial class AnomalyDetectorClient
    {
        protected AnomalyDetectorClient() { }
        public AnomalyDetectorClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public AnomalyDetectorClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.AnomalyDetector.AnomalyDetectorClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response DeleteMultivariateModel(string modelId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteMultivariateModelAsync(string modelId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.AnomalyDetector.MultivariateDetectionResult> DetectMultivariateBatchAnomaly(string modelId, Azure.AI.AnomalyDetector.MultivariateBatchDetectionOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DetectMultivariateBatchAnomaly(string modelId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.AnomalyDetector.MultivariateDetectionResult>> DetectMultivariateBatchAnomalyAsync(string modelId, Azure.AI.AnomalyDetector.MultivariateBatchDetectionOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DetectMultivariateBatchAnomalyAsync(string modelId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.AnomalyDetector.MultivariateLastDetectionResult> DetectMultivariateLastAnomaly(string modelId, Azure.AI.AnomalyDetector.MultivariateLastDetectionOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DetectMultivariateLastAnomaly(string modelId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.AnomalyDetector.MultivariateLastDetectionResult>> DetectMultivariateLastAnomalyAsync(string modelId, Azure.AI.AnomalyDetector.MultivariateLastDetectionOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DetectMultivariateLastAnomalyAsync(string modelId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.AnomalyDetector.UnivariateChangePointDetectionResult> DetectUnivariateChangePoint(Azure.AI.AnomalyDetector.UnivariateChangePointDetectionOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DetectUnivariateChangePoint(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.AnomalyDetector.UnivariateChangePointDetectionResult>> DetectUnivariateChangePointAsync(Azure.AI.AnomalyDetector.UnivariateChangePointDetectionOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DetectUnivariateChangePointAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DetectUnivariateEntireSeries(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DetectUnivariateEntireSeriesAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.AnomalyDetector.UnivariateLastDetectionResult> DetectUnivariateLastPoint(Azure.AI.AnomalyDetector.UnivariateDetectionOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DetectUnivariateLastPoint(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.AnomalyDetector.UnivariateLastDetectionResult>> DetectUnivariateLastPointAsync(Azure.AI.AnomalyDetector.UnivariateDetectionOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DetectUnivariateLastPointAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetMultivariateBatchDetectionResult(System.Guid resultId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.AnomalyDetector.MultivariateDetectionResult> GetMultivariateBatchDetectionResult(System.Guid resultId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetMultivariateBatchDetectionResultAsync(System.Guid resultId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.AnomalyDetector.MultivariateDetectionResult>> GetMultivariateBatchDetectionResultAsync(System.Guid resultId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetMultivariateModel(string modelId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.AnomalyDetector.AnomalyDetectionModel> GetMultivariateModel(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetMultivariateModelAsync(string modelId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.AnomalyDetector.AnomalyDetectionModel>> GetMultivariateModelAsync(string modelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetMultivariateModels(int? skip, int? maxCount, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.AnomalyDetector.AnomalyDetectionModel> GetMultivariateModels(int? skip = default(int?), int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetMultivariateModelsAsync(int? skip, int? maxCount, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.AnomalyDetector.AnomalyDetectionModel> GetMultivariateModelsAsync(int? skip = default(int?), int? maxCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.AnomalyDetector.AnomalyDetectionModel> TrainMultivariateModel(Azure.AI.AnomalyDetector.ModelInfo modelInfo, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response TrainMultivariateModel(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.AnomalyDetector.AnomalyDetectionModel>> TrainMultivariateModelAsync(Azure.AI.AnomalyDetector.ModelInfo modelInfo, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> TrainMultivariateModelAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class AnomalyDetectorClientOptions : Azure.Core.ClientOptions
    {
        public AnomalyDetectorClientOptions(Azure.AI.AnomalyDetector.AnomalyDetectorClientOptions.ServiceVersion version = Azure.AI.AnomalyDetector.AnomalyDetectorClientOptions.ServiceVersion.V1_1) { }
        public enum ServiceVersion
        {
            V1_1 = 1,
        }
    }
    public partial class AnomalyInterpretation
    {
        internal AnomalyInterpretation() { }
        public float? ContributionScore { get { throw null; } }
        public Azure.AI.AnomalyDetector.CorrelationChanges CorrelationChanges { get { throw null; } }
        public string Variable { get { throw null; } }
    }
    public partial class AnomalyState
    {
        internal AnomalyState() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AnomalyDetector.ErrorResponse> Errors { get { throw null; } }
        public System.DateTimeOffset Timestamp { get { throw null; } }
        public Azure.AI.AnomalyDetector.AnomalyValue Value { get { throw null; } }
    }
    public partial class AnomalyValue
    {
        internal AnomalyValue() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AnomalyDetector.AnomalyInterpretation> Interpretation { get { throw null; } }
        public bool IsAnomaly { get { throw null; } }
        public float Score { get { throw null; } }
        public float Severity { get { throw null; } }
    }
    public partial class CorrelationChanges
    {
        internal CorrelationChanges() { }
        public System.Collections.Generic.IReadOnlyList<string> ChangedVariables { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataSchema : System.IEquatable<Azure.AI.AnomalyDetector.DataSchema>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataSchema(string value) { throw null; }
        public static Azure.AI.AnomalyDetector.DataSchema MultiTable { get { throw null; } }
        public static Azure.AI.AnomalyDetector.DataSchema OneTable { get { throw null; } }
        public bool Equals(Azure.AI.AnomalyDetector.DataSchema other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AnomalyDetector.DataSchema left, Azure.AI.AnomalyDetector.DataSchema right) { throw null; }
        public static implicit operator Azure.AI.AnomalyDetector.DataSchema (string value) { throw null; }
        public static bool operator !=(Azure.AI.AnomalyDetector.DataSchema left, Azure.AI.AnomalyDetector.DataSchema right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiagnosticsInfo
    {
        public DiagnosticsInfo() { }
        public Azure.AI.AnomalyDetector.ModelState ModelState { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.AnomalyDetector.VariableState> VariableStates { get { throw null; } }
    }
    public partial class ErrorResponse
    {
        public ErrorResponse(string code, string message) { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FillNAMethod : System.IEquatable<Azure.AI.AnomalyDetector.FillNAMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FillNAMethod(string value) { throw null; }
        public static Azure.AI.AnomalyDetector.FillNAMethod Fixed { get { throw null; } }
        public static Azure.AI.AnomalyDetector.FillNAMethod Linear { get { throw null; } }
        public static Azure.AI.AnomalyDetector.FillNAMethod Previous { get { throw null; } }
        public static Azure.AI.AnomalyDetector.FillNAMethod Subsequent { get { throw null; } }
        public static Azure.AI.AnomalyDetector.FillNAMethod Zero { get { throw null; } }
        public bool Equals(Azure.AI.AnomalyDetector.FillNAMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AnomalyDetector.FillNAMethod left, Azure.AI.AnomalyDetector.FillNAMethod right) { throw null; }
        public static implicit operator Azure.AI.AnomalyDetector.FillNAMethod (string value) { throw null; }
        public static bool operator !=(Azure.AI.AnomalyDetector.FillNAMethod left, Azure.AI.AnomalyDetector.FillNAMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImputeMode : System.IEquatable<Azure.AI.AnomalyDetector.ImputeMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImputeMode(string value) { throw null; }
        public static Azure.AI.AnomalyDetector.ImputeMode Auto { get { throw null; } }
        public static Azure.AI.AnomalyDetector.ImputeMode Fixed { get { throw null; } }
        public static Azure.AI.AnomalyDetector.ImputeMode Linear { get { throw null; } }
        public static Azure.AI.AnomalyDetector.ImputeMode NotFill { get { throw null; } }
        public static Azure.AI.AnomalyDetector.ImputeMode Previous { get { throw null; } }
        public static Azure.AI.AnomalyDetector.ImputeMode Zero { get { throw null; } }
        public bool Equals(Azure.AI.AnomalyDetector.ImputeMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AnomalyDetector.ImputeMode left, Azure.AI.AnomalyDetector.ImputeMode right) { throw null; }
        public static implicit operator Azure.AI.AnomalyDetector.ImputeMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.AnomalyDetector.ImputeMode left, Azure.AI.AnomalyDetector.ImputeMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ModelInfo
    {
        public ModelInfo(System.Uri dataSource, System.DateTimeOffset startTime, System.DateTimeOffset endTime) { }
        public Azure.AI.AnomalyDetector.AlignPolicy AlignPolicy { get { throw null; } set { } }
        public Azure.AI.AnomalyDetector.DataSchema? DataSchema { get { throw null; } set { } }
        public System.Uri DataSource { get { throw null; } set { } }
        public Azure.AI.AnomalyDetector.DiagnosticsInfo DiagnosticsInfo { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset EndTime { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AnomalyDetector.ErrorResponse> Errors { get { throw null; } }
        public int? SlidingWindow { get { throw null; } set { } }
        public System.DateTimeOffset StartTime { get { throw null; } set { } }
        public Azure.AI.AnomalyDetector.ModelStatus? Status { get { throw null; } }
    }
    public partial class ModelState
    {
        public ModelState() { }
        public System.Collections.Generic.IList<int> EpochIds { get { throw null; } }
        public System.Collections.Generic.IList<float> LatenciesInSeconds { get { throw null; } }
        public System.Collections.Generic.IList<float> TrainLosses { get { throw null; } }
        public System.Collections.Generic.IList<float> ValidationLosses { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ModelStatus : System.IEquatable<Azure.AI.AnomalyDetector.ModelStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ModelStatus(string value) { throw null; }
        public static Azure.AI.AnomalyDetector.ModelStatus Created { get { throw null; } }
        public static Azure.AI.AnomalyDetector.ModelStatus Failed { get { throw null; } }
        public static Azure.AI.AnomalyDetector.ModelStatus Ready { get { throw null; } }
        public static Azure.AI.AnomalyDetector.ModelStatus Running { get { throw null; } }
        public bool Equals(Azure.AI.AnomalyDetector.ModelStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AnomalyDetector.ModelStatus left, Azure.AI.AnomalyDetector.ModelStatus right) { throw null; }
        public static implicit operator Azure.AI.AnomalyDetector.ModelStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.AnomalyDetector.ModelStatus left, Azure.AI.AnomalyDetector.ModelStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MultivariateBatchDetectionOptions
    {
        public MultivariateBatchDetectionOptions(System.Uri dataSource, System.DateTimeOffset startTime, System.DateTimeOffset endTime) { }
        public System.Uri DataSource { get { throw null; } set { } }
        public System.DateTimeOffset EndTime { get { throw null; } set { } }
        public System.DateTimeOffset StartTime { get { throw null; } set { } }
        public int? TopContributorCount { get { throw null; } set { } }
    }
    public partial class MultivariateBatchDetectionResultSummary
    {
        internal MultivariateBatchDetectionResultSummary() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AnomalyDetector.ErrorResponse> Errors { get { throw null; } }
        public Azure.AI.AnomalyDetector.MultivariateBatchDetectionOptions SetupInfo { get { throw null; } }
        public Azure.AI.AnomalyDetector.MultivariateBatchDetectionStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AnomalyDetector.VariableState> VariableStates { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MultivariateBatchDetectionStatus : System.IEquatable<Azure.AI.AnomalyDetector.MultivariateBatchDetectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MultivariateBatchDetectionStatus(string value) { throw null; }
        public static Azure.AI.AnomalyDetector.MultivariateBatchDetectionStatus Created { get { throw null; } }
        public static Azure.AI.AnomalyDetector.MultivariateBatchDetectionStatus Failed { get { throw null; } }
        public static Azure.AI.AnomalyDetector.MultivariateBatchDetectionStatus Ready { get { throw null; } }
        public static Azure.AI.AnomalyDetector.MultivariateBatchDetectionStatus Running { get { throw null; } }
        public bool Equals(Azure.AI.AnomalyDetector.MultivariateBatchDetectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AnomalyDetector.MultivariateBatchDetectionStatus left, Azure.AI.AnomalyDetector.MultivariateBatchDetectionStatus right) { throw null; }
        public static implicit operator Azure.AI.AnomalyDetector.MultivariateBatchDetectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.AnomalyDetector.MultivariateBatchDetectionStatus left, Azure.AI.AnomalyDetector.MultivariateBatchDetectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MultivariateDetectionResult
    {
        internal MultivariateDetectionResult() { }
        public System.Guid ResultId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AnomalyDetector.AnomalyState> Results { get { throw null; } }
        public Azure.AI.AnomalyDetector.MultivariateBatchDetectionResultSummary Summary { get { throw null; } }
    }
    public partial class MultivariateLastDetectionOptions
    {
        public MultivariateLastDetectionOptions(System.Collections.Generic.IEnumerable<Azure.AI.AnomalyDetector.VariableValues> variables) { }
        public int? TopContributorCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.AnomalyDetector.VariableValues> Variables { get { throw null; } }
    }
    public partial class MultivariateLastDetectionResult
    {
        internal MultivariateLastDetectionResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AnomalyDetector.AnomalyState> Results { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AnomalyDetector.VariableState> VariableStates { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TimeGranularity : System.IEquatable<Azure.AI.AnomalyDetector.TimeGranularity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TimeGranularity(string value) { throw null; }
        public static Azure.AI.AnomalyDetector.TimeGranularity Daily { get { throw null; } }
        public static Azure.AI.AnomalyDetector.TimeGranularity Hourly { get { throw null; } }
        public static Azure.AI.AnomalyDetector.TimeGranularity Microsecond { get { throw null; } }
        public static Azure.AI.AnomalyDetector.TimeGranularity Monthly { get { throw null; } }
        public static Azure.AI.AnomalyDetector.TimeGranularity None { get { throw null; } }
        public static Azure.AI.AnomalyDetector.TimeGranularity PerMinute { get { throw null; } }
        public static Azure.AI.AnomalyDetector.TimeGranularity PerSecond { get { throw null; } }
        public static Azure.AI.AnomalyDetector.TimeGranularity Weekly { get { throw null; } }
        public static Azure.AI.AnomalyDetector.TimeGranularity Yearly { get { throw null; } }
        public bool Equals(Azure.AI.AnomalyDetector.TimeGranularity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AnomalyDetector.TimeGranularity left, Azure.AI.AnomalyDetector.TimeGranularity right) { throw null; }
        public static implicit operator Azure.AI.AnomalyDetector.TimeGranularity (string value) { throw null; }
        public static bool operator !=(Azure.AI.AnomalyDetector.TimeGranularity left, Azure.AI.AnomalyDetector.TimeGranularity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TimeSeriesPoint
    {
        public TimeSeriesPoint(float value) { }
        public System.DateTimeOffset? Timestamp { get { throw null; } set { } }
        public float Value { get { throw null; } }
    }
    public partial class UnivariateChangePointDetectionOptions
    {
        public UnivariateChangePointDetectionOptions(System.Collections.Generic.IEnumerable<Azure.AI.AnomalyDetector.TimeSeriesPoint> series, Azure.AI.AnomalyDetector.TimeGranularity granularity) { }
        public int? CustomInterval { get { throw null; } set { } }
        public Azure.AI.AnomalyDetector.TimeGranularity Granularity { get { throw null; } }
        public int? Period { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.AnomalyDetector.TimeSeriesPoint> Series { get { throw null; } }
        public int? StableTrendWindow { get { throw null; } set { } }
        public float? Threshold { get { throw null; } set { } }
    }
    public partial class UnivariateChangePointDetectionResult
    {
        internal UnivariateChangePointDetectionResult() { }
        public System.Collections.Generic.IReadOnlyList<float> ConfidenceScores { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<bool> IsChangePoint { get { throw null; } }
        public int? Period { get { throw null; } }
    }
    public partial class UnivariateDetectionOptions
    {
        public UnivariateDetectionOptions(System.Collections.Generic.IEnumerable<Azure.AI.AnomalyDetector.TimeSeriesPoint> series) { }
        public int? CustomInterval { get { throw null; } set { } }
        public Azure.AI.AnomalyDetector.TimeGranularity? Granularity { get { throw null; } set { } }
        public float? ImputeFixedValue { get { throw null; } set { } }
        public Azure.AI.AnomalyDetector.ImputeMode? ImputeMode { get { throw null; } set { } }
        public float? MaxAnomalyRatio { get { throw null; } set { } }
        public int? Period { get { throw null; } set { } }
        public int? Sensitivity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.AnomalyDetector.TimeSeriesPoint> Series { get { throw null; } }
    }
    public partial class UnivariateLastDetectionResult
    {
        internal UnivariateLastDetectionResult() { }
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
namespace Microsoft.Extensions.Azure
{
    public static partial class AIAnomalyDetectorClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.AnomalyDetector.AnomalyDetectorClient, Azure.AI.AnomalyDetector.AnomalyDetectorClientOptions> AddAnomalyDetectorClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.AnomalyDetector.AnomalyDetectorClient, Azure.AI.AnomalyDetector.AnomalyDetectorClientOptions> AddAnomalyDetectorClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
