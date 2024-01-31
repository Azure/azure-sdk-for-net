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
        public static Azure.AI.AnomalyDetector.TimeSeriesPoint TimeSeriesPoint(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), float value = 0f) { throw null; }
        public static Azure.AI.AnomalyDetector.UnivariateChangePointDetectionOptions UnivariateChangePointDetectionOptions(System.Collections.Generic.IEnumerable<Azure.AI.AnomalyDetector.TimeSeriesPoint> series = null, Azure.AI.AnomalyDetector.TimeGranularity granularity = default(Azure.AI.AnomalyDetector.TimeGranularity), int? customInterval = default(int?), int? period = default(int?), int? stableTrendWindow = default(int?), float? threshold = default(float?)) { throw null; }
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
    public partial class AlignPolicy : System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.AlignPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.AlignPolicy>
    {
        public AlignPolicy() { }
        public Azure.AI.AnomalyDetector.AlignMode? AlignMode { get { throw null; } set { } }
        public Azure.AI.AnomalyDetector.FillNAMethod? FillNAMethod { get { throw null; } set { } }
        public float? PaddingValue { get { throw null; } set { } }
        Azure.AI.AnomalyDetector.AlignPolicy System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.AlignPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.AlignPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AnomalyDetector.AlignPolicy System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.AlignPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.AlignPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.AlignPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnomalyDetectionModel : System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.AnomalyDetectionModel>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.AnomalyDetectionModel>
    {
        internal AnomalyDetectionModel() { }
        public System.DateTimeOffset CreatedTime { get { throw null; } }
        public System.DateTimeOffset LastUpdatedTime { get { throw null; } }
        public System.Guid ModelId { get { throw null; } }
        public Azure.AI.AnomalyDetector.ModelInfo ModelInfo { get { throw null; } }
        Azure.AI.AnomalyDetector.AnomalyDetectionModel System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.AnomalyDetectionModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.AnomalyDetectionModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AnomalyDetector.AnomalyDetectionModel System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.AnomalyDetectionModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.AnomalyDetectionModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.AnomalyDetectionModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnomalyDetectorClient
    {
        protected AnomalyDetectorClient() { }
        public AnomalyDetectorClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public AnomalyDetectorClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.AnomalyDetector.AnomalyDetectorClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.AI.AnomalyDetector.Multivariate GetMultivariateClient(string apiVersion = "v1.1") { throw null; }
        public virtual Azure.AI.AnomalyDetector.Univariate GetUnivariateClient(string apiVersion = "v1.1") { throw null; }
    }
    public partial class AnomalyDetectorClientOptions : Azure.Core.ClientOptions
    {
        public AnomalyDetectorClientOptions(Azure.AI.AnomalyDetector.AnomalyDetectorClientOptions.ServiceVersion version = Azure.AI.AnomalyDetector.AnomalyDetectorClientOptions.ServiceVersion.V1_1) { }
        public enum ServiceVersion
        {
            V1_1 = 1,
        }
    }
    public partial class AnomalyInterpretation : System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.AnomalyInterpretation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.AnomalyInterpretation>
    {
        internal AnomalyInterpretation() { }
        public float? ContributionScore { get { throw null; } }
        public Azure.AI.AnomalyDetector.CorrelationChanges CorrelationChanges { get { throw null; } }
        public string Variable { get { throw null; } }
        Azure.AI.AnomalyDetector.AnomalyInterpretation System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.AnomalyInterpretation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.AnomalyInterpretation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AnomalyDetector.AnomalyInterpretation System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.AnomalyInterpretation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.AnomalyInterpretation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.AnomalyInterpretation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnomalyState : System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.AnomalyState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.AnomalyState>
    {
        internal AnomalyState() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AnomalyDetector.ErrorResponse> Errors { get { throw null; } }
        public System.DateTimeOffset Timestamp { get { throw null; } }
        public Azure.AI.AnomalyDetector.AnomalyValue Value { get { throw null; } }
        Azure.AI.AnomalyDetector.AnomalyState System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.AnomalyState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.AnomalyState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AnomalyDetector.AnomalyState System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.AnomalyState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.AnomalyState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.AnomalyState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnomalyValue : System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.AnomalyValue>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.AnomalyValue>
    {
        internal AnomalyValue() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AnomalyDetector.AnomalyInterpretation> Interpretation { get { throw null; } }
        public bool IsAnomaly { get { throw null; } }
        public float Score { get { throw null; } }
        public float Severity { get { throw null; } }
        Azure.AI.AnomalyDetector.AnomalyValue System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.AnomalyValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.AnomalyValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AnomalyDetector.AnomalyValue System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.AnomalyValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.AnomalyValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.AnomalyValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CorrelationChanges : System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.CorrelationChanges>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.CorrelationChanges>
    {
        internal CorrelationChanges() { }
        public System.Collections.Generic.IReadOnlyList<string> ChangedVariables { get { throw null; } }
        Azure.AI.AnomalyDetector.CorrelationChanges System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.CorrelationChanges>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.CorrelationChanges>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AnomalyDetector.CorrelationChanges System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.CorrelationChanges>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.CorrelationChanges>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.CorrelationChanges>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class DiagnosticsInfo : System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.DiagnosticsInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.DiagnosticsInfo>
    {
        public DiagnosticsInfo() { }
        public Azure.AI.AnomalyDetector.ModelState ModelState { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.AnomalyDetector.VariableState> VariableStates { get { throw null; } }
        Azure.AI.AnomalyDetector.DiagnosticsInfo System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.DiagnosticsInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.DiagnosticsInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AnomalyDetector.DiagnosticsInfo System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.DiagnosticsInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.DiagnosticsInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.DiagnosticsInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ErrorResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.ErrorResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.ErrorResponse>
    {
        public ErrorResponse(string code, string message) { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        Azure.AI.AnomalyDetector.ErrorResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.ErrorResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.ErrorResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AnomalyDetector.ErrorResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.ErrorResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.ErrorResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.ErrorResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ModelInfo : System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.ModelInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.ModelInfo>
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
        Azure.AI.AnomalyDetector.ModelInfo System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.ModelInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.ModelInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AnomalyDetector.ModelInfo System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.ModelInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.ModelInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.ModelInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ModelState : System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.ModelState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.ModelState>
    {
        public ModelState() { }
        public System.Collections.Generic.IList<int> EpochIds { get { throw null; } }
        public System.Collections.Generic.IList<float> LatenciesInSeconds { get { throw null; } }
        public System.Collections.Generic.IList<float> TrainLosses { get { throw null; } }
        public System.Collections.Generic.IList<float> ValidationLosses { get { throw null; } }
        Azure.AI.AnomalyDetector.ModelState System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.ModelState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.ModelState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AnomalyDetector.ModelState System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.ModelState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.ModelState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.ModelState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class Multivariate
    {
        protected Multivariate() { }
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
    public partial class MultivariateBatchDetectionOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.MultivariateBatchDetectionOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.MultivariateBatchDetectionOptions>
    {
        public MultivariateBatchDetectionOptions(System.Uri dataSource, System.DateTimeOffset startTime, System.DateTimeOffset endTime) { }
        public System.Uri DataSource { get { throw null; } set { } }
        public System.DateTimeOffset EndTime { get { throw null; } set { } }
        public System.DateTimeOffset StartTime { get { throw null; } set { } }
        public int? TopContributorCount { get { throw null; } set { } }
        Azure.AI.AnomalyDetector.MultivariateBatchDetectionOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.MultivariateBatchDetectionOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.MultivariateBatchDetectionOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AnomalyDetector.MultivariateBatchDetectionOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.MultivariateBatchDetectionOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.MultivariateBatchDetectionOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.MultivariateBatchDetectionOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MultivariateBatchDetectionResultSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.MultivariateBatchDetectionResultSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.MultivariateBatchDetectionResultSummary>
    {
        internal MultivariateBatchDetectionResultSummary() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AnomalyDetector.ErrorResponse> Errors { get { throw null; } }
        public Azure.AI.AnomalyDetector.MultivariateBatchDetectionOptions SetupInfo { get { throw null; } }
        public Azure.AI.AnomalyDetector.MultivariateBatchDetectionStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AnomalyDetector.VariableState> VariableStates { get { throw null; } }
        Azure.AI.AnomalyDetector.MultivariateBatchDetectionResultSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.MultivariateBatchDetectionResultSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.MultivariateBatchDetectionResultSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AnomalyDetector.MultivariateBatchDetectionResultSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.MultivariateBatchDetectionResultSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.MultivariateBatchDetectionResultSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.MultivariateBatchDetectionResultSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class MultivariateDetectionResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.MultivariateDetectionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.MultivariateDetectionResult>
    {
        internal MultivariateDetectionResult() { }
        public System.Guid ResultId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AnomalyDetector.AnomalyState> Results { get { throw null; } }
        public Azure.AI.AnomalyDetector.MultivariateBatchDetectionResultSummary Summary { get { throw null; } }
        Azure.AI.AnomalyDetector.MultivariateDetectionResult System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.MultivariateDetectionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.MultivariateDetectionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AnomalyDetector.MultivariateDetectionResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.MultivariateDetectionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.MultivariateDetectionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.MultivariateDetectionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MultivariateLastDetectionOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.MultivariateLastDetectionOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.MultivariateLastDetectionOptions>
    {
        public MultivariateLastDetectionOptions(System.Collections.Generic.IEnumerable<Azure.AI.AnomalyDetector.VariableValues> variables) { }
        public int? TopContributorCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.AnomalyDetector.VariableValues> Variables { get { throw null; } }
        Azure.AI.AnomalyDetector.MultivariateLastDetectionOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.MultivariateLastDetectionOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.MultivariateLastDetectionOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AnomalyDetector.MultivariateLastDetectionOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.MultivariateLastDetectionOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.MultivariateLastDetectionOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.MultivariateLastDetectionOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MultivariateLastDetectionResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.MultivariateLastDetectionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.MultivariateLastDetectionResult>
    {
        internal MultivariateLastDetectionResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AnomalyDetector.AnomalyState> Results { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AnomalyDetector.VariableState> VariableStates { get { throw null; } }
        Azure.AI.AnomalyDetector.MultivariateLastDetectionResult System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.MultivariateLastDetectionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.MultivariateLastDetectionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AnomalyDetector.MultivariateLastDetectionResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.MultivariateLastDetectionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.MultivariateLastDetectionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.MultivariateLastDetectionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class TimeSeriesPoint : System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.TimeSeriesPoint>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.TimeSeriesPoint>
    {
        public TimeSeriesPoint(float value) { }
        public System.DateTimeOffset? Timestamp { get { throw null; } set { } }
        public float Value { get { throw null; } }
        Azure.AI.AnomalyDetector.TimeSeriesPoint System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.TimeSeriesPoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.TimeSeriesPoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AnomalyDetector.TimeSeriesPoint System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.TimeSeriesPoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.TimeSeriesPoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.TimeSeriesPoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Univariate
    {
        protected Univariate() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
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
    }
    public partial class UnivariateChangePointDetectionOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.UnivariateChangePointDetectionOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.UnivariateChangePointDetectionOptions>
    {
        public UnivariateChangePointDetectionOptions(System.Collections.Generic.IEnumerable<Azure.AI.AnomalyDetector.TimeSeriesPoint> series, Azure.AI.AnomalyDetector.TimeGranularity granularity) { }
        public int? CustomInterval { get { throw null; } set { } }
        public Azure.AI.AnomalyDetector.TimeGranularity Granularity { get { throw null; } }
        public int? Period { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.AnomalyDetector.TimeSeriesPoint> Series { get { throw null; } }
        public int? StableTrendWindow { get { throw null; } set { } }
        public float? Threshold { get { throw null; } set { } }
        Azure.AI.AnomalyDetector.UnivariateChangePointDetectionOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.UnivariateChangePointDetectionOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.UnivariateChangePointDetectionOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AnomalyDetector.UnivariateChangePointDetectionOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.UnivariateChangePointDetectionOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.UnivariateChangePointDetectionOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.UnivariateChangePointDetectionOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UnivariateChangePointDetectionResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.UnivariateChangePointDetectionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.UnivariateChangePointDetectionResult>
    {
        internal UnivariateChangePointDetectionResult() { }
        public System.Collections.Generic.IReadOnlyList<float> ConfidenceScores { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<bool> IsChangePoint { get { throw null; } }
        public int? Period { get { throw null; } }
        Azure.AI.AnomalyDetector.UnivariateChangePointDetectionResult System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.UnivariateChangePointDetectionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.UnivariateChangePointDetectionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AnomalyDetector.UnivariateChangePointDetectionResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.UnivariateChangePointDetectionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.UnivariateChangePointDetectionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.UnivariateChangePointDetectionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UnivariateDetectionOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.UnivariateDetectionOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.UnivariateDetectionOptions>
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
        Azure.AI.AnomalyDetector.UnivariateDetectionOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.UnivariateDetectionOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.UnivariateDetectionOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AnomalyDetector.UnivariateDetectionOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.UnivariateDetectionOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.UnivariateDetectionOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.UnivariateDetectionOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UnivariateLastDetectionResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.UnivariateLastDetectionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.UnivariateLastDetectionResult>
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
        Azure.AI.AnomalyDetector.UnivariateLastDetectionResult System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.UnivariateLastDetectionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.UnivariateLastDetectionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AnomalyDetector.UnivariateLastDetectionResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.UnivariateLastDetectionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.UnivariateLastDetectionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.UnivariateLastDetectionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VariableState : System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.VariableState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.VariableState>
    {
        public VariableState() { }
        public int? EffectiveCount { get { throw null; } set { } }
        public float? FilledNARatio { get { throw null; } set { } }
        public System.DateTimeOffset? FirstTimestamp { get { throw null; } set { } }
        public System.DateTimeOffset? LastTimestamp { get { throw null; } set { } }
        public string Variable { get { throw null; } set { } }
        Azure.AI.AnomalyDetector.VariableState System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.VariableState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.VariableState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AnomalyDetector.VariableState System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.VariableState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.VariableState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.VariableState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VariableValues : System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.VariableValues>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.VariableValues>
    {
        public VariableValues(string variable, System.Collections.Generic.IEnumerable<string> timestamps, System.Collections.Generic.IEnumerable<float> values) { }
        public System.Collections.Generic.IList<string> Timestamps { get { throw null; } }
        public System.Collections.Generic.IList<float> Values { get { throw null; } }
        public string Variable { get { throw null; } }
        Azure.AI.AnomalyDetector.VariableValues System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.VariableValues>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AnomalyDetector.VariableValues>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AnomalyDetector.VariableValues System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.VariableValues>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.VariableValues>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AnomalyDetector.VariableValues>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
