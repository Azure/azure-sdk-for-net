namespace Azure.AI.Language.Text
{
    public partial class AbstractiveSummarizationActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AbstractiveSummarizationActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AbstractiveSummarizationActionContent>
    {
        public AbstractiveSummarizationActionContent() { }
        public string Instruction { get { throw null; } set { } }
        public bool? LoggingOptOut { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        public int? SentenceCount { get { throw null; } set { } }
        public Azure.AI.Language.Text.StringIndexType? StringIndexType { get { throw null; } set { } }
        public Azure.AI.Language.Text.SummaryLengthBucket? SummaryLength { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AbstractiveSummarizationActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AbstractiveSummarizationActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AbstractiveSummarizationActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AbstractiveSummarizationActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AbstractiveSummarizationActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AbstractiveSummarizationActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AbstractiveSummarizationActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AbstractiveSummarizationOperationAction : Azure.AI.Language.Text.AnalyzeTextOperationAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AbstractiveSummarizationOperationAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AbstractiveSummarizationOperationAction>
    {
        public AbstractiveSummarizationOperationAction() { }
        public Azure.AI.Language.Text.AbstractiveSummarizationActionContent ActionContent { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AbstractiveSummarizationOperationAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AbstractiveSummarizationOperationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AbstractiveSummarizationOperationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AbstractiveSummarizationOperationAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AbstractiveSummarizationOperationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AbstractiveSummarizationOperationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AbstractiveSummarizationOperationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AbstractiveSummarizationOperationResult : Azure.AI.Language.Text.AnalyzeTextOperationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AbstractiveSummarizationOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AbstractiveSummarizationOperationResult>
    {
        internal AbstractiveSummarizationOperationResult() : base (default(System.DateTimeOffset), default(Azure.AI.Language.Text.TextActionState)) { }
        public Azure.AI.Language.Text.AbstractiveSummarizationResult Results { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AbstractiveSummarizationOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AbstractiveSummarizationOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AbstractiveSummarizationOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AbstractiveSummarizationOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AbstractiveSummarizationOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AbstractiveSummarizationOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AbstractiveSummarizationOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AbstractiveSummarizationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AbstractiveSummarizationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AbstractiveSummarizationResult>
    {
        internal AbstractiveSummarizationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.AbstractiveSummaryActionResult> Documents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.DocumentError> Errors { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.Language.Text.RequestStatistics Statistics { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AbstractiveSummarizationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AbstractiveSummarizationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AbstractiveSummarizationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AbstractiveSummarizationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AbstractiveSummarizationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AbstractiveSummarizationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AbstractiveSummarizationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AbstractiveSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AbstractiveSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AbstractiveSummary>
    {
        internal AbstractiveSummary() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.SummaryContext> Contexts { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AbstractiveSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AbstractiveSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AbstractiveSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AbstractiveSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AbstractiveSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AbstractiveSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AbstractiveSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AbstractiveSummaryActionResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AbstractiveSummaryActionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AbstractiveSummaryActionResult>
    {
        internal AbstractiveSummaryActionResult() { }
        public Azure.AI.Language.Text.DetectedLanguage DetectedLanguage { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Language.Text.DocumentStatistics Statistics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.AbstractiveSummary> Summaries { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.DocumentWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AbstractiveSummaryActionResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AbstractiveSummaryActionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AbstractiveSummaryActionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AbstractiveSummaryActionResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AbstractiveSummaryActionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AbstractiveSummaryActionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AbstractiveSummaryActionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgeMetadata : Azure.AI.Language.Text.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AgeMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AgeMetadata>
    {
        internal AgeMetadata() { }
        public Azure.AI.Language.Text.AgeUnit Unit { get { throw null; } }
        public double Value { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AgeMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AgeMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AgeMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AgeMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AgeMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AgeMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AgeMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgeUnit : System.IEquatable<Azure.AI.Language.Text.AgeUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgeUnit(string value) { throw null; }
        public static Azure.AI.Language.Text.AgeUnit Day { get { throw null; } }
        public static Azure.AI.Language.Text.AgeUnit Month { get { throw null; } }
        public static Azure.AI.Language.Text.AgeUnit Unspecified { get { throw null; } }
        public static Azure.AI.Language.Text.AgeUnit Week { get { throw null; } }
        public static Azure.AI.Language.Text.AgeUnit Year { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.AgeUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.AgeUnit left, Azure.AI.Language.Text.AgeUnit right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.AgeUnit (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.AgeUnit left, Azure.AI.Language.Text.AgeUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AllowOverlapEntityPolicyType : Azure.AI.Language.Text.EntityOverlapPolicy, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AllowOverlapEntityPolicyType>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AllowOverlapEntityPolicyType>
    {
        public AllowOverlapEntityPolicyType() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AllowOverlapEntityPolicyType System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AllowOverlapEntityPolicyType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AllowOverlapEntityPolicyType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AllowOverlapEntityPolicyType System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AllowOverlapEntityPolicyType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AllowOverlapEntityPolicyType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AllowOverlapEntityPolicyType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeTextEntitiesResult : Azure.AI.Language.Text.AnalyzeTextResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextEntitiesResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextEntitiesResult>
    {
        internal AnalyzeTextEntitiesResult() { }
        public Azure.AI.Language.Text.EntitiesWithMetadataAutoResult Results { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AnalyzeTextEntitiesResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextEntitiesResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextEntitiesResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AnalyzeTextEntitiesResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextEntitiesResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextEntitiesResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextEntitiesResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeTextEntityLinkingResult : Azure.AI.Language.Text.AnalyzeTextResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextEntityLinkingResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextEntityLinkingResult>
    {
        internal AnalyzeTextEntityLinkingResult() { }
        public Azure.AI.Language.Text.EntityLinkingResult Results { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AnalyzeTextEntityLinkingResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextEntityLinkingResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextEntityLinkingResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AnalyzeTextEntityLinkingResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextEntityLinkingResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextEntityLinkingResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextEntityLinkingResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeTextError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextError>
    {
        internal AnalyzeTextError() { }
        public Azure.AI.Language.Text.AnalyzeTextErrorCode Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.AnalyzeTextError> Details { get { throw null; } }
        public Azure.AI.Language.Text.InnerErrorModel Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AnalyzeTextError System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AnalyzeTextError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnalyzeTextErrorCode : System.IEquatable<Azure.AI.Language.Text.AnalyzeTextErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnalyzeTextErrorCode(string value) { throw null; }
        public static Azure.AI.Language.Text.AnalyzeTextErrorCode AzureCognitiveSearchIndexLimitReached { get { throw null; } }
        public static Azure.AI.Language.Text.AnalyzeTextErrorCode AzureCognitiveSearchIndexNotFound { get { throw null; } }
        public static Azure.AI.Language.Text.AnalyzeTextErrorCode AzureCognitiveSearchNotFound { get { throw null; } }
        public static Azure.AI.Language.Text.AnalyzeTextErrorCode AzureCognitiveSearchThrottling { get { throw null; } }
        public static Azure.AI.Language.Text.AnalyzeTextErrorCode Conflict { get { throw null; } }
        public static Azure.AI.Language.Text.AnalyzeTextErrorCode Forbidden { get { throw null; } }
        public static Azure.AI.Language.Text.AnalyzeTextErrorCode InternalServerError { get { throw null; } }
        public static Azure.AI.Language.Text.AnalyzeTextErrorCode InvalidArgument { get { throw null; } }
        public static Azure.AI.Language.Text.AnalyzeTextErrorCode InvalidRequest { get { throw null; } }
        public static Azure.AI.Language.Text.AnalyzeTextErrorCode NotFound { get { throw null; } }
        public static Azure.AI.Language.Text.AnalyzeTextErrorCode OperationNotFound { get { throw null; } }
        public static Azure.AI.Language.Text.AnalyzeTextErrorCode ProjectNotFound { get { throw null; } }
        public static Azure.AI.Language.Text.AnalyzeTextErrorCode QuotaExceeded { get { throw null; } }
        public static Azure.AI.Language.Text.AnalyzeTextErrorCode ServiceUnavailable { get { throw null; } }
        public static Azure.AI.Language.Text.AnalyzeTextErrorCode Timeout { get { throw null; } }
        public static Azure.AI.Language.Text.AnalyzeTextErrorCode TooManyRequests { get { throw null; } }
        public static Azure.AI.Language.Text.AnalyzeTextErrorCode Unauthorized { get { throw null; } }
        public static Azure.AI.Language.Text.AnalyzeTextErrorCode Warning { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.AnalyzeTextErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.AnalyzeTextErrorCode left, Azure.AI.Language.Text.AnalyzeTextErrorCode right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.AnalyzeTextErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.AnalyzeTextErrorCode left, Azure.AI.Language.Text.AnalyzeTextErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class AnalyzeTextInput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextInput>
    {
        protected AnalyzeTextInput() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AnalyzeTextInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AnalyzeTextInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeTextKeyPhraseResult : Azure.AI.Language.Text.AnalyzeTextResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextKeyPhraseResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextKeyPhraseResult>
    {
        internal AnalyzeTextKeyPhraseResult() { }
        public Azure.AI.Language.Text.KeyPhraseResult Results { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AnalyzeTextKeyPhraseResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextKeyPhraseResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextKeyPhraseResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AnalyzeTextKeyPhraseResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextKeyPhraseResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextKeyPhraseResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextKeyPhraseResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeTextLanguageDetectionResult : Azure.AI.Language.Text.AnalyzeTextResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextLanguageDetectionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextLanguageDetectionResult>
    {
        internal AnalyzeTextLanguageDetectionResult() { }
        public Azure.AI.Language.Text.LanguageDetectionResult Results { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AnalyzeTextLanguageDetectionResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextLanguageDetectionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextLanguageDetectionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AnalyzeTextLanguageDetectionResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextLanguageDetectionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextLanguageDetectionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextLanguageDetectionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AnalyzeTextOperationAction : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextOperationAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextOperationAction>
    {
        protected AnalyzeTextOperationAction() { }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AnalyzeTextOperationAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextOperationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextOperationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AnalyzeTextOperationAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextOperationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextOperationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextOperationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AnalyzeTextOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextOperationResult>
    {
        protected AnalyzeTextOperationResult(System.DateTimeOffset lastUpdateDateTime, Azure.AI.Language.Text.TextActionState status) { }
        public System.DateTimeOffset LastUpdateDateTime { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Language.Text.TextActionState Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AnalyzeTextOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AnalyzeTextOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeTextOperationState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextOperationState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextOperationState>
    {
        internal AnalyzeTextOperationState() { }
        public Azure.AI.Language.Text.TextActions Actions { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.AnalyzeTextError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public System.Guid JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedAt { get { throw null; } }
        public string NextLink { get { throw null; } }
        public Azure.AI.Language.Text.RequestStatistics Statistics { get { throw null; } }
        public Azure.AI.Language.Text.TextActionState Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AnalyzeTextOperationState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextOperationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextOperationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AnalyzeTextOperationState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextOperationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextOperationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextOperationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeTextPiiResult : Azure.AI.Language.Text.AnalyzeTextResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextPiiResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextPiiResult>
    {
        internal AnalyzeTextPiiResult() { }
        public Azure.AI.Language.Text.PiiResult Results { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AnalyzeTextPiiResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextPiiResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextPiiResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AnalyzeTextPiiResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextPiiResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextPiiResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextPiiResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AnalyzeTextResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextResult>
    {
        protected AnalyzeTextResult() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AnalyzeTextResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AnalyzeTextResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeTextSentimentResult : Azure.AI.Language.Text.AnalyzeTextResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextSentimentResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextSentimentResult>
    {
        internal AnalyzeTextSentimentResult() { }
        public Azure.AI.Language.Text.SentimentResult Results { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AnalyzeTextSentimentResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextSentimentResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AnalyzeTextSentimentResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AnalyzeTextSentimentResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextSentimentResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextSentimentResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AnalyzeTextSentimentResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AreaMetadata : Azure.AI.Language.Text.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AreaMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AreaMetadata>
    {
        internal AreaMetadata() { }
        public Azure.AI.Language.Text.AreaUnit Unit { get { throw null; } }
        public double Value { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AreaMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AreaMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.AreaMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.AreaMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AreaMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AreaMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.AreaMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AreaUnit : System.IEquatable<Azure.AI.Language.Text.AreaUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AreaUnit(string value) { throw null; }
        public static Azure.AI.Language.Text.AreaUnit Acre { get { throw null; } }
        public static Azure.AI.Language.Text.AreaUnit SquareCentimeter { get { throw null; } }
        public static Azure.AI.Language.Text.AreaUnit SquareDecameter { get { throw null; } }
        public static Azure.AI.Language.Text.AreaUnit SquareDecimeter { get { throw null; } }
        public static Azure.AI.Language.Text.AreaUnit SquareFoot { get { throw null; } }
        public static Azure.AI.Language.Text.AreaUnit SquareHectometer { get { throw null; } }
        public static Azure.AI.Language.Text.AreaUnit SquareInch { get { throw null; } }
        public static Azure.AI.Language.Text.AreaUnit SquareKilometer { get { throw null; } }
        public static Azure.AI.Language.Text.AreaUnit SquareMeter { get { throw null; } }
        public static Azure.AI.Language.Text.AreaUnit SquareMile { get { throw null; } }
        public static Azure.AI.Language.Text.AreaUnit SquareMillimeter { get { throw null; } }
        public static Azure.AI.Language.Text.AreaUnit SquareYard { get { throw null; } }
        public static Azure.AI.Language.Text.AreaUnit Unspecified { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.AreaUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.AreaUnit left, Azure.AI.Language.Text.AreaUnit right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.AreaUnit (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.AreaUnit left, Azure.AI.Language.Text.AreaUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureAILanguageTextContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAILanguageTextContext() { }
        public static Azure.AI.Language.Text.AzureAILanguageTextContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public abstract partial class BaseMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.BaseMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.BaseMetadata>
    {
        protected BaseMetadata() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.BaseMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.BaseMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.BaseMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.BaseMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.BaseMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.BaseMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.BaseMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class BaseRedactionPolicy : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.BaseRedactionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.BaseRedactionPolicy>
    {
        protected BaseRedactionPolicy() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.BaseRedactionPolicy System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.BaseRedactionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.BaseRedactionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.BaseRedactionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.BaseRedactionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.BaseRedactionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.BaseRedactionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CharacterMaskPolicyType : Azure.AI.Language.Text.BaseRedactionPolicy, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CharacterMaskPolicyType>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CharacterMaskPolicyType>
    {
        public CharacterMaskPolicyType() { }
        public Azure.AI.Language.Text.RedactionCharacter? RedactionCharacter { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.CharacterMaskPolicyType System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CharacterMaskPolicyType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CharacterMaskPolicyType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.CharacterMaskPolicyType System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CharacterMaskPolicyType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CharacterMaskPolicyType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CharacterMaskPolicyType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClassificationActionResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.ClassificationActionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.ClassificationActionResult>
    {
        internal ClassificationActionResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.ClassificationResult> Class { get { throw null; } }
        public Azure.AI.Language.Text.DetectedLanguage DetectedLanguage { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Language.Text.DocumentStatistics Statistics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.DocumentWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.ClassificationActionResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.ClassificationActionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.ClassificationActionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.ClassificationActionResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.ClassificationActionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.ClassificationActionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.ClassificationActionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClassificationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.ClassificationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.ClassificationResult>
    {
        internal ClassificationResult() { }
        public string Category { get { throw null; } }
        public double ConfidenceScore { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.ClassificationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.ClassificationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.ClassificationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.ClassificationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.ClassificationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.ClassificationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.ClassificationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CurrencyMetadata : Azure.AI.Language.Text.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CurrencyMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CurrencyMetadata>
    {
        internal CurrencyMetadata() { }
        public string Iso4217 { get { throw null; } }
        public string Unit { get { throw null; } }
        public double Value { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.CurrencyMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CurrencyMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CurrencyMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.CurrencyMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CurrencyMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CurrencyMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CurrencyMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomEntitiesActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomEntitiesActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomEntitiesActionContent>
    {
        public CustomEntitiesActionContent(string projectName, string deploymentName) { }
        public string DeploymentName { get { throw null; } }
        public bool? LoggingOptOut { get { throw null; } set { } }
        public string ProjectName { get { throw null; } }
        public Azure.AI.Language.Text.StringIndexType? StringIndexType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.CustomEntitiesActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomEntitiesActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomEntitiesActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.CustomEntitiesActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomEntitiesActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomEntitiesActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomEntitiesActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomEntitiesOperationAction : Azure.AI.Language.Text.AnalyzeTextOperationAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomEntitiesOperationAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomEntitiesOperationAction>
    {
        public CustomEntitiesOperationAction() { }
        public Azure.AI.Language.Text.CustomEntitiesActionContent ActionContent { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.CustomEntitiesOperationAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomEntitiesOperationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomEntitiesOperationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.CustomEntitiesOperationAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomEntitiesOperationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomEntitiesOperationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomEntitiesOperationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomEntitiesResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomEntitiesResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomEntitiesResult>
    {
        internal CustomEntitiesResult() { }
        public string DeploymentName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.CustomEntityActionResult> Documents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.DocumentError> Errors { get { throw null; } }
        public string ProjectName { get { throw null; } }
        public Azure.AI.Language.Text.RequestStatistics Statistics { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.CustomEntitiesResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomEntitiesResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomEntitiesResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.CustomEntitiesResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomEntitiesResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomEntitiesResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomEntitiesResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomEntityActionResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomEntityActionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomEntityActionResult>
    {
        internal CustomEntityActionResult() { }
        public Azure.AI.Language.Text.DetectedLanguage DetectedLanguage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.NamedEntity> Entities { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Language.Text.DocumentStatistics Statistics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.DocumentWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.CustomEntityActionResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomEntityActionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomEntityActionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.CustomEntityActionResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomEntityActionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomEntityActionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomEntityActionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomEntityRecognitionOperationResult : Azure.AI.Language.Text.AnalyzeTextOperationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomEntityRecognitionOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomEntityRecognitionOperationResult>
    {
        internal CustomEntityRecognitionOperationResult() : base (default(System.DateTimeOffset), default(Azure.AI.Language.Text.TextActionState)) { }
        public Azure.AI.Language.Text.CustomEntitiesResult Results { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.CustomEntityRecognitionOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomEntityRecognitionOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomEntityRecognitionOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.CustomEntityRecognitionOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomEntityRecognitionOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomEntityRecognitionOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomEntityRecognitionOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomLabelClassificationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomLabelClassificationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomLabelClassificationResult>
    {
        internal CustomLabelClassificationResult() { }
        public string DeploymentName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.ClassificationActionResult> Documents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.DocumentError> Errors { get { throw null; } }
        public string ProjectName { get { throw null; } }
        public Azure.AI.Language.Text.RequestStatistics Statistics { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.CustomLabelClassificationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomLabelClassificationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomLabelClassificationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.CustomLabelClassificationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomLabelClassificationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomLabelClassificationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomLabelClassificationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomMultiLabelClassificationActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomMultiLabelClassificationActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomMultiLabelClassificationActionContent>
    {
        public CustomMultiLabelClassificationActionContent(string projectName, string deploymentName) { }
        public string DeploymentName { get { throw null; } }
        public bool? LoggingOptOut { get { throw null; } set { } }
        public string ProjectName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.CustomMultiLabelClassificationActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomMultiLabelClassificationActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomMultiLabelClassificationActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.CustomMultiLabelClassificationActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomMultiLabelClassificationActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomMultiLabelClassificationActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomMultiLabelClassificationActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomMultiLabelClassificationOperationAction : Azure.AI.Language.Text.AnalyzeTextOperationAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomMultiLabelClassificationOperationAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomMultiLabelClassificationOperationAction>
    {
        public CustomMultiLabelClassificationOperationAction() { }
        public Azure.AI.Language.Text.CustomMultiLabelClassificationActionContent ActionContent { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.CustomMultiLabelClassificationOperationAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomMultiLabelClassificationOperationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomMultiLabelClassificationOperationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.CustomMultiLabelClassificationOperationAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomMultiLabelClassificationOperationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomMultiLabelClassificationOperationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomMultiLabelClassificationOperationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomMultiLabelClassificationOperationResult : Azure.AI.Language.Text.AnalyzeTextOperationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomMultiLabelClassificationOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomMultiLabelClassificationOperationResult>
    {
        internal CustomMultiLabelClassificationOperationResult() : base (default(System.DateTimeOffset), default(Azure.AI.Language.Text.TextActionState)) { }
        public Azure.AI.Language.Text.CustomLabelClassificationResult Results { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.CustomMultiLabelClassificationOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomMultiLabelClassificationOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomMultiLabelClassificationOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.CustomMultiLabelClassificationOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomMultiLabelClassificationOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomMultiLabelClassificationOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomMultiLabelClassificationOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomSingleLabelClassificationActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomSingleLabelClassificationActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomSingleLabelClassificationActionContent>
    {
        public CustomSingleLabelClassificationActionContent(string projectName, string deploymentName) { }
        public string DeploymentName { get { throw null; } }
        public bool? LoggingOptOut { get { throw null; } set { } }
        public string ProjectName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.CustomSingleLabelClassificationActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomSingleLabelClassificationActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomSingleLabelClassificationActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.CustomSingleLabelClassificationActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomSingleLabelClassificationActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomSingleLabelClassificationActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomSingleLabelClassificationActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomSingleLabelClassificationOperationAction : Azure.AI.Language.Text.AnalyzeTextOperationAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomSingleLabelClassificationOperationAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomSingleLabelClassificationOperationAction>
    {
        public CustomSingleLabelClassificationOperationAction() { }
        public Azure.AI.Language.Text.CustomSingleLabelClassificationActionContent ActionContent { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.CustomSingleLabelClassificationOperationAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomSingleLabelClassificationOperationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomSingleLabelClassificationOperationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.CustomSingleLabelClassificationOperationAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomSingleLabelClassificationOperationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomSingleLabelClassificationOperationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomSingleLabelClassificationOperationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomSingleLabelClassificationOperationResult : Azure.AI.Language.Text.AnalyzeTextOperationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomSingleLabelClassificationOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomSingleLabelClassificationOperationResult>
    {
        internal CustomSingleLabelClassificationOperationResult() : base (default(System.DateTimeOffset), default(Azure.AI.Language.Text.TextActionState)) { }
        public Azure.AI.Language.Text.CustomLabelClassificationResult Results { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.CustomSingleLabelClassificationOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomSingleLabelClassificationOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.CustomSingleLabelClassificationOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.CustomSingleLabelClassificationOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomSingleLabelClassificationOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomSingleLabelClassificationOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.CustomSingleLabelClassificationOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DateMetadata : Azure.AI.Language.Text.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.DateMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.DateMetadata>
    {
        internal DateMetadata() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.DateValue> Dates { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.DateMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.DateMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.DateMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.DateMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.DateMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.DateMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.DateMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DateTimeMetadata : Azure.AI.Language.Text.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.DateTimeMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.DateTimeMetadata>
    {
        internal DateTimeMetadata() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.DateValue> Dates { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.DateTimeMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.DateTimeMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.DateTimeMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.DateTimeMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.DateTimeMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.DateTimeMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.DateTimeMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DateValue : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.DateValue>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.DateValue>
    {
        internal DateValue() { }
        public Azure.AI.Language.Text.TemporalModifier? Modifier { get { throw null; } }
        public string Timex { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.DateValue System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.DateValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.DateValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.DateValue System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.DateValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.DateValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.DateValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DetectedLanguage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.DetectedLanguage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.DetectedLanguage>
    {
        internal DetectedLanguage() { }
        public double ConfidenceScore { get { throw null; } }
        public string Iso6391Name { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Language.Text.ScriptCode? ScriptIso15924Code { get { throw null; } }
        public Azure.AI.Language.Text.ScriptKind? ScriptName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.DetectedLanguage System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.DetectedLanguage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.DetectedLanguage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.DetectedLanguage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.DetectedLanguage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.DetectedLanguage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.DetectedLanguage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.DocumentError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.DocumentError>
    {
        internal DocumentError() { }
        public Azure.AI.Language.Text.AnalyzeTextError Error { get { throw null; } }
        public string Id { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.DocumentError System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.DocumentError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.DocumentError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.DocumentError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.DocumentError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.DocumentError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.DocumentError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum DocumentSentiment
    {
        Positive = 0,
        Neutral = 1,
        Negative = 2,
        Mixed = 3,
    }
    public partial class DocumentStatistics : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.DocumentStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.DocumentStatistics>
    {
        internal DocumentStatistics() { }
        public int CharactersCount { get { throw null; } }
        public int TransactionsCount { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.DocumentStatistics System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.DocumentStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.DocumentStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.DocumentStatistics System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.DocumentStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.DocumentStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.DocumentStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentWarning : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.DocumentWarning>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.DocumentWarning>
    {
        internal DocumentWarning() { }
        public Azure.AI.Language.Text.WarningCode Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string TargetRef { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.DocumentWarning System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.DocumentWarning>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.DocumentWarning>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.DocumentWarning System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.DocumentWarning>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.DocumentWarning>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.DocumentWarning>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntitiesActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntitiesActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntitiesActionContent>
    {
        public EntitiesActionContent() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.EntityCategory> Exclusions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.EntityCategory> Inclusions { get { throw null; } }
        public Azure.AI.Language.Text.EntityInferenceConfig InferenceOptions { get { throw null; } set { } }
        public bool? LoggingOptOut { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        public Azure.AI.Language.Text.EntityOverlapPolicy OverlapPolicy { get { throw null; } set { } }
        public Azure.AI.Language.Text.StringIndexType? StringIndexType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntitiesActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntitiesActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntitiesActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntitiesActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntitiesActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntitiesActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntitiesActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntitiesOperationAction : Azure.AI.Language.Text.AnalyzeTextOperationAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntitiesOperationAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntitiesOperationAction>
    {
        public EntitiesOperationAction() { }
        public Azure.AI.Language.Text.EntitiesActionContent ActionContent { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntitiesOperationAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntitiesOperationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntitiesOperationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntitiesOperationAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntitiesOperationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntitiesOperationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntitiesOperationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntitiesResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntitiesResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntitiesResult>
    {
        internal EntitiesResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.EntityActionResultWithMetadata> Documents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.DocumentError> Errors { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.Language.Text.RequestStatistics Statistics { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntitiesResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntitiesResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntitiesResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntitiesResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntitiesResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntitiesResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntitiesResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntitiesWithMetadataAutoResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntitiesWithMetadataAutoResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntitiesWithMetadataAutoResult>
    {
        internal EntitiesWithMetadataAutoResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.EntityActionResult> Documents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.DocumentError> Errors { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.Language.Text.RequestStatistics Statistics { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntitiesWithMetadataAutoResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntitiesWithMetadataAutoResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntitiesWithMetadataAutoResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntitiesWithMetadataAutoResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntitiesWithMetadataAutoResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntitiesWithMetadataAutoResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntitiesWithMetadataAutoResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityActionResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityActionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityActionResult>
    {
        internal EntityActionResult() { }
        public Azure.AI.Language.Text.DetectedLanguage DetectedLanguage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.NamedEntityWithMetadata> Entities { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Language.Text.DocumentStatistics Statistics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.DocumentWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntityActionResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityActionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityActionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntityActionResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityActionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityActionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityActionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityActionResultWithMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityActionResultWithMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityActionResultWithMetadata>
    {
        internal EntityActionResultWithMetadata() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.NamedEntityWithMetadata> Entities { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Language.Text.DocumentStatistics Statistics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.DocumentWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntityActionResultWithMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityActionResultWithMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityActionResultWithMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntityActionResultWithMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityActionResultWithMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityActionResultWithMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityActionResultWithMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EntityCategory : System.IEquatable<Azure.AI.Language.Text.EntityCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EntityCategory(string value) { throw null; }
        public static Azure.AI.Language.Text.EntityCategory Address { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory Age { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory Airport { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory Area { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory City { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory ComputingProduct { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory Continent { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory CountryRegion { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory CulturalEvent { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory Currency { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory Date { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory DateRange { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory DateTime { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory DateTimeRange { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory Dimension { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory Duration { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory Email { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory Event { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory Geological { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory GeoPoliticalEntity { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory Height { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory Information { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory IpAddress { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory Length { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory Location { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory NaturalEvent { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory Number { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory NumberRange { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory Numeric { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory Ordinal { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory Organization { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory OrganizationMedical { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory OrganizationSports { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory OrganizationStockExchange { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory Percentage { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory Person { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory PersonType { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory PhoneNumber { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory Product { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory SetTemporal { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory Skill { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory Speed { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory SportsEvent { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory State { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory Structural { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory Temperature { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory Temporal { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory Time { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory TimeRange { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory Uri { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory Volume { get { throw null; } }
        public static Azure.AI.Language.Text.EntityCategory Weight { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.EntityCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.EntityCategory left, Azure.AI.Language.Text.EntityCategory right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.EntityCategory (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.EntityCategory left, Azure.AI.Language.Text.EntityCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EntityInferenceConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityInferenceConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityInferenceConfig>
    {
        public EntityInferenceConfig() { }
        public bool? ExcludeNormalizedValues { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntityInferenceConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityInferenceConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityInferenceConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntityInferenceConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityInferenceConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityInferenceConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityInferenceConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityLinkingActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityLinkingActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityLinkingActionContent>
    {
        public EntityLinkingActionContent() { }
        public bool? LoggingOptOut { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        public Azure.AI.Language.Text.StringIndexType? StringIndexType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntityLinkingActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityLinkingActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityLinkingActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntityLinkingActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityLinkingActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityLinkingActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityLinkingActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityLinkingActionResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityLinkingActionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityLinkingActionResult>
    {
        internal EntityLinkingActionResult() { }
        public Azure.AI.Language.Text.DetectedLanguage DetectedLanguage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.LinkedEntity> Entities { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Language.Text.DocumentStatistics Statistics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.DocumentWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntityLinkingActionResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityLinkingActionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityLinkingActionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntityLinkingActionResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityLinkingActionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityLinkingActionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityLinkingActionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityLinkingMatch : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityLinkingMatch>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityLinkingMatch>
    {
        internal EntityLinkingMatch() { }
        public double ConfidenceScore { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntityLinkingMatch System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityLinkingMatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityLinkingMatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntityLinkingMatch System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityLinkingMatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityLinkingMatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityLinkingMatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityLinkingOperationAction : Azure.AI.Language.Text.AnalyzeTextOperationAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityLinkingOperationAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityLinkingOperationAction>
    {
        public EntityLinkingOperationAction() { }
        public Azure.AI.Language.Text.EntityLinkingActionContent ActionContent { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntityLinkingOperationAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityLinkingOperationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityLinkingOperationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntityLinkingOperationAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityLinkingOperationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityLinkingOperationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityLinkingOperationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityLinkingOperationResult : Azure.AI.Language.Text.AnalyzeTextOperationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityLinkingOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityLinkingOperationResult>
    {
        internal EntityLinkingOperationResult() : base (default(System.DateTimeOffset), default(Azure.AI.Language.Text.TextActionState)) { }
        public Azure.AI.Language.Text.EntityLinkingResult Results { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntityLinkingOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityLinkingOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityLinkingOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntityLinkingOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityLinkingOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityLinkingOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityLinkingOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityLinkingResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityLinkingResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityLinkingResult>
    {
        internal EntityLinkingResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.EntityLinkingActionResult> Documents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.DocumentError> Errors { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.Language.Text.RequestStatistics Statistics { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntityLinkingResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityLinkingResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityLinkingResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntityLinkingResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityLinkingResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityLinkingResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityLinkingResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityMaskPolicyType : Azure.AI.Language.Text.BaseRedactionPolicy, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityMaskPolicyType>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityMaskPolicyType>
    {
        public EntityMaskPolicyType() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntityMaskPolicyType System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityMaskPolicyType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityMaskPolicyType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntityMaskPolicyType System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityMaskPolicyType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityMaskPolicyType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityMaskPolicyType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class EntityOverlapPolicy : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityOverlapPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityOverlapPolicy>
    {
        protected EntityOverlapPolicy() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntityOverlapPolicy System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityOverlapPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityOverlapPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntityOverlapPolicy System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityOverlapPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityOverlapPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityOverlapPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityRecognitionOperationResult : Azure.AI.Language.Text.AnalyzeTextOperationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityRecognitionOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityRecognitionOperationResult>
    {
        internal EntityRecognitionOperationResult() : base (default(System.DateTimeOffset), default(Azure.AI.Language.Text.TextActionState)) { }
        public Azure.AI.Language.Text.EntitiesResult Results { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntityRecognitionOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityRecognitionOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityRecognitionOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntityRecognitionOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityRecognitionOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityRecognitionOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityRecognitionOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityTag : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityTag>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityTag>
    {
        internal EntityTag() { }
        public double? ConfidenceScore { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntityTag System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.EntityTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.EntityTag System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.EntityTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtractedSummaryActionResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.ExtractedSummaryActionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.ExtractedSummaryActionResult>
    {
        internal ExtractedSummaryActionResult() { }
        public Azure.AI.Language.Text.DetectedLanguage DetectedLanguage { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.ExtractedSummarySentence> Sentences { get { throw null; } }
        public Azure.AI.Language.Text.DocumentStatistics Statistics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.DocumentWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.ExtractedSummaryActionResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.ExtractedSummaryActionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.ExtractedSummaryActionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.ExtractedSummaryActionResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.ExtractedSummaryActionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.ExtractedSummaryActionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.ExtractedSummaryActionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtractedSummarySentence : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.ExtractedSummarySentence>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.ExtractedSummarySentence>
    {
        internal ExtractedSummarySentence() { }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        public double RankScore { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.ExtractedSummarySentence System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.ExtractedSummarySentence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.ExtractedSummarySentence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.ExtractedSummarySentence System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.ExtractedSummarySentence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.ExtractedSummarySentence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.ExtractedSummarySentence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtractiveSummarizationActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.ExtractiveSummarizationActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.ExtractiveSummarizationActionContent>
    {
        public ExtractiveSummarizationActionContent() { }
        public bool? LoggingOptOut { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public long? SentenceCount { get { throw null; } set { } }
        public Azure.AI.Language.Text.ExtractiveSummarizationSortingCriteria? SortBy { get { throw null; } set { } }
        public Azure.AI.Language.Text.StringIndexType? StringIndexType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.ExtractiveSummarizationActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.ExtractiveSummarizationActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.ExtractiveSummarizationActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.ExtractiveSummarizationActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.ExtractiveSummarizationActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.ExtractiveSummarizationActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.ExtractiveSummarizationActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtractiveSummarizationOperationAction : Azure.AI.Language.Text.AnalyzeTextOperationAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.ExtractiveSummarizationOperationAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.ExtractiveSummarizationOperationAction>
    {
        public ExtractiveSummarizationOperationAction() { }
        public Azure.AI.Language.Text.ExtractiveSummarizationActionContent ActionContent { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.ExtractiveSummarizationOperationAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.ExtractiveSummarizationOperationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.ExtractiveSummarizationOperationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.ExtractiveSummarizationOperationAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.ExtractiveSummarizationOperationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.ExtractiveSummarizationOperationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.ExtractiveSummarizationOperationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtractiveSummarizationOperationResult : Azure.AI.Language.Text.AnalyzeTextOperationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.ExtractiveSummarizationOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.ExtractiveSummarizationOperationResult>
    {
        internal ExtractiveSummarizationOperationResult() : base (default(System.DateTimeOffset), default(Azure.AI.Language.Text.TextActionState)) { }
        public Azure.AI.Language.Text.ExtractiveSummarizationResult Results { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.ExtractiveSummarizationOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.ExtractiveSummarizationOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.ExtractiveSummarizationOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.ExtractiveSummarizationOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.ExtractiveSummarizationOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.ExtractiveSummarizationOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.ExtractiveSummarizationOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtractiveSummarizationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.ExtractiveSummarizationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.ExtractiveSummarizationResult>
    {
        internal ExtractiveSummarizationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.ExtractedSummaryActionResult> Documents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.DocumentError> Errors { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.Language.Text.RequestStatistics Statistics { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.ExtractiveSummarizationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.ExtractiveSummarizationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.ExtractiveSummarizationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.ExtractiveSummarizationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.ExtractiveSummarizationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.ExtractiveSummarizationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.ExtractiveSummarizationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExtractiveSummarizationSortingCriteria : System.IEquatable<Azure.AI.Language.Text.ExtractiveSummarizationSortingCriteria>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExtractiveSummarizationSortingCriteria(string value) { throw null; }
        public static Azure.AI.Language.Text.ExtractiveSummarizationSortingCriteria Offset { get { throw null; } }
        public static Azure.AI.Language.Text.ExtractiveSummarizationSortingCriteria Rank { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.ExtractiveSummarizationSortingCriteria other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.ExtractiveSummarizationSortingCriteria left, Azure.AI.Language.Text.ExtractiveSummarizationSortingCriteria right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.ExtractiveSummarizationSortingCriteria (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.ExtractiveSummarizationSortingCriteria left, Azure.AI.Language.Text.ExtractiveSummarizationSortingCriteria right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FhirBundle : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.FhirBundle>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.FhirBundle>
    {
        internal FhirBundle() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.FhirBundle System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.FhirBundle>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.FhirBundle>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.FhirBundle System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.FhirBundle>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.FhirBundle>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.FhirBundle>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FhirVersion : System.IEquatable<Azure.AI.Language.Text.FhirVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FhirVersion(string value) { throw null; }
        public static Azure.AI.Language.Text.FhirVersion _401 { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.FhirVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.FhirVersion left, Azure.AI.Language.Text.FhirVersion right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.FhirVersion (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.FhirVersion left, Azure.AI.Language.Text.FhirVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HealthcareActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.HealthcareActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareActionContent>
    {
        public HealthcareActionContent() { }
        public Azure.AI.Language.Text.HealthcareDocumentType? DocumentType { get { throw null; } set { } }
        public Azure.AI.Language.Text.FhirVersion? FhirVersion { get { throw null; } set { } }
        public bool? LoggingOptOut { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        public Azure.AI.Language.Text.StringIndexType? StringIndexType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.HealthcareActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.HealthcareActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.HealthcareActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.HealthcareActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareActionResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.HealthcareActionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareActionResult>
    {
        internal HealthcareActionResult() { }
        public Azure.AI.Language.Text.DetectedLanguage DetectedLanguage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.HealthcareEntity> Entities { get { throw null; } }
        public Azure.AI.Language.Text.FhirBundle FhirBundle { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.HealthcareRelation> Relations { get { throw null; } }
        public Azure.AI.Language.Text.DocumentStatistics Statistics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.DocumentWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.HealthcareActionResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.HealthcareActionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.HealthcareActionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.HealthcareActionResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareActionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareActionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareActionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareAssertion : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.HealthcareAssertion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareAssertion>
    {
        internal HealthcareAssertion() { }
        public Azure.AI.Language.Text.HealthcareAssertionAssociation? Association { get { throw null; } }
        public Azure.AI.Language.Text.HealthcareAssertionCertainty? Certainty { get { throw null; } }
        public Azure.AI.Language.Text.HealthcareAssertionConditionality? Conditionality { get { throw null; } }
        public Azure.AI.Language.Text.HealthcareAssertionTemporality? Temporality { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.HealthcareAssertion System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.HealthcareAssertion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.HealthcareAssertion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.HealthcareAssertion System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareAssertion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareAssertion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareAssertion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum HealthcareAssertionAssociation
    {
        Subject = 0,
        Other = 1,
    }
    public enum HealthcareAssertionCertainty
    {
        Positive = 0,
        PositivePossible = 1,
        NeutralPossible = 2,
        NegativePossible = 3,
        Negative = 4,
    }
    public enum HealthcareAssertionConditionality
    {
        Hypothetical = 0,
        Conditional = 1,
    }
    public enum HealthcareAssertionTemporality
    {
        Current = 0,
        Past = 1,
        Future = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HealthcareDocumentType : System.IEquatable<Azure.AI.Language.Text.HealthcareDocumentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HealthcareDocumentType(string value) { throw null; }
        public static Azure.AI.Language.Text.HealthcareDocumentType ClinicalTrial { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareDocumentType Consult { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareDocumentType DischargeSummary { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareDocumentType HistoryAndPhysical { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareDocumentType Imaging { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareDocumentType None { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareDocumentType Pathology { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareDocumentType ProcedureNote { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareDocumentType ProgressNote { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.HealthcareDocumentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.HealthcareDocumentType left, Azure.AI.Language.Text.HealthcareDocumentType right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.HealthcareDocumentType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.HealthcareDocumentType left, Azure.AI.Language.Text.HealthcareDocumentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HealthcareEntity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.HealthcareEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareEntity>
    {
        internal HealthcareEntity() { }
        public Azure.AI.Language.Text.HealthcareAssertion Assertion { get { throw null; } }
        public Azure.AI.Language.Text.HealthcareEntityCategory Category { get { throw null; } }
        public double ConfidenceScore { get { throw null; } }
        public int Length { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.HealthcareEntityLink> Links { get { throw null; } }
        public string Name { get { throw null; } }
        public int Offset { get { throw null; } }
        public string Subcategory { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.HealthcareEntity System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.HealthcareEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.HealthcareEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.HealthcareEntity System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HealthcareEntityCategory : System.IEquatable<Azure.AI.Language.Text.HealthcareEntityCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HealthcareEntityCategory(string value) { throw null; }
        public static Azure.AI.Language.Text.HealthcareEntityCategory AdministrativeEvent { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory Age { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory Allergen { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory BodyStructure { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory CareEnvironment { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory ConditionQualifier { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory ConditionScale { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory Course { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory Date { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory Diagnosis { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory Direction { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory Dosage { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory Employment { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory Ethnicity { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory ExaminationName { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory Expression { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory FamilyRelation { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory Frequency { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory Gender { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory GeneOrProtein { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory HealthcareProfession { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory LivingStatus { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory MeasurementUnit { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory MeasurementValue { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory MedicationClass { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory MedicationForm { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory MedicationName { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory MedicationRoute { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory MutationType { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory RelationalOperator { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory SubstanceUse { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory SubstanceUseAmount { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory SymptomOrSign { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory Time { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory TreatmentName { get { throw null; } }
        public static Azure.AI.Language.Text.HealthcareEntityCategory Variant { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.HealthcareEntityCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.HealthcareEntityCategory left, Azure.AI.Language.Text.HealthcareEntityCategory right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.HealthcareEntityCategory (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.HealthcareEntityCategory left, Azure.AI.Language.Text.HealthcareEntityCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HealthcareEntityLink : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.HealthcareEntityLink>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareEntityLink>
    {
        internal HealthcareEntityLink() { }
        public string DataSource { get { throw null; } }
        public string Id { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.HealthcareEntityLink System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.HealthcareEntityLink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.HealthcareEntityLink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.HealthcareEntityLink System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareEntityLink>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareEntityLink>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareEntityLink>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareOperationAction : Azure.AI.Language.Text.AnalyzeTextOperationAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.HealthcareOperationAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareOperationAction>
    {
        public HealthcareOperationAction() { }
        public Azure.AI.Language.Text.HealthcareActionContent ActionContent { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.HealthcareOperationAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.HealthcareOperationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.HealthcareOperationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.HealthcareOperationAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareOperationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareOperationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareOperationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareOperationResult : Azure.AI.Language.Text.AnalyzeTextOperationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.HealthcareOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareOperationResult>
    {
        internal HealthcareOperationResult() : base (default(System.DateTimeOffset), default(Azure.AI.Language.Text.TextActionState)) { }
        public Azure.AI.Language.Text.HealthcareResult Results { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.HealthcareOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.HealthcareOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.HealthcareOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.HealthcareOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareRelation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.HealthcareRelation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareRelation>
    {
        internal HealthcareRelation() { }
        public double? ConfidenceScore { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.HealthcareRelationEntity> Entities { get { throw null; } }
        public Azure.AI.Language.Text.RelationType RelationType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.HealthcareRelation System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.HealthcareRelation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.HealthcareRelation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.HealthcareRelation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareRelation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareRelation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareRelation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareRelationEntity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.HealthcareRelationEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareRelationEntity>
    {
        internal HealthcareRelationEntity() { }
        public string Ref { get { throw null; } }
        public string Role { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.HealthcareRelationEntity System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.HealthcareRelationEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.HealthcareRelationEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.HealthcareRelationEntity System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareRelationEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareRelationEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareRelationEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.HealthcareResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareResult>
    {
        internal HealthcareResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.HealthcareActionResult> Documents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.DocumentError> Errors { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.Language.Text.RequestStatistics Statistics { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.HealthcareResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.HealthcareResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.HealthcareResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.HealthcareResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.HealthcareResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InformationMetadata : Azure.AI.Language.Text.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.InformationMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.InformationMetadata>
    {
        internal InformationMetadata() { }
        public Azure.AI.Language.Text.InformationUnit Unit { get { throw null; } }
        public double Value { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.InformationMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.InformationMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.InformationMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.InformationMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.InformationMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.InformationMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.InformationMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InformationUnit : System.IEquatable<Azure.AI.Language.Text.InformationUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InformationUnit(string value) { throw null; }
        public static Azure.AI.Language.Text.InformationUnit Bit { get { throw null; } }
        public static Azure.AI.Language.Text.InformationUnit Byte { get { throw null; } }
        public static Azure.AI.Language.Text.InformationUnit Gigabit { get { throw null; } }
        public static Azure.AI.Language.Text.InformationUnit Gigabyte { get { throw null; } }
        public static Azure.AI.Language.Text.InformationUnit Kilobit { get { throw null; } }
        public static Azure.AI.Language.Text.InformationUnit Kilobyte { get { throw null; } }
        public static Azure.AI.Language.Text.InformationUnit Megabit { get { throw null; } }
        public static Azure.AI.Language.Text.InformationUnit Megabyte { get { throw null; } }
        public static Azure.AI.Language.Text.InformationUnit Petabit { get { throw null; } }
        public static Azure.AI.Language.Text.InformationUnit Petabyte { get { throw null; } }
        public static Azure.AI.Language.Text.InformationUnit Terabit { get { throw null; } }
        public static Azure.AI.Language.Text.InformationUnit Terabyte { get { throw null; } }
        public static Azure.AI.Language.Text.InformationUnit Unspecified { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.InformationUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.InformationUnit left, Azure.AI.Language.Text.InformationUnit right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.InformationUnit (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.InformationUnit left, Azure.AI.Language.Text.InformationUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InnerErrorCode : System.IEquatable<Azure.AI.Language.Text.InnerErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InnerErrorCode(string value) { throw null; }
        public static Azure.AI.Language.Text.InnerErrorCode AzureCognitiveSearchNotFound { get { throw null; } }
        public static Azure.AI.Language.Text.InnerErrorCode AzureCognitiveSearchThrottling { get { throw null; } }
        public static Azure.AI.Language.Text.InnerErrorCode EmptyRequest { get { throw null; } }
        public static Azure.AI.Language.Text.InnerErrorCode ExtractionFailure { get { throw null; } }
        public static Azure.AI.Language.Text.InnerErrorCode InvalidCountryHint { get { throw null; } }
        public static Azure.AI.Language.Text.InnerErrorCode InvalidDocument { get { throw null; } }
        public static Azure.AI.Language.Text.InnerErrorCode InvalidDocumentBatch { get { throw null; } }
        public static Azure.AI.Language.Text.InnerErrorCode InvalidParameterValue { get { throw null; } }
        public static Azure.AI.Language.Text.InnerErrorCode InvalidRequest { get { throw null; } }
        public static Azure.AI.Language.Text.InnerErrorCode InvalidRequestBodyFormat { get { throw null; } }
        public static Azure.AI.Language.Text.InnerErrorCode KnowledgeBaseNotFound { get { throw null; } }
        public static Azure.AI.Language.Text.InnerErrorCode MissingInputDocuments { get { throw null; } }
        public static Azure.AI.Language.Text.InnerErrorCode ModelVersionIncorrect { get { throw null; } }
        public static Azure.AI.Language.Text.InnerErrorCode UnsupportedLanguageCode { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.InnerErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.InnerErrorCode left, Azure.AI.Language.Text.InnerErrorCode right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.InnerErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.InnerErrorCode left, Azure.AI.Language.Text.InnerErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InnerErrorModel : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.InnerErrorModel>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.InnerErrorModel>
    {
        internal InnerErrorModel() { }
        public Azure.AI.Language.Text.InnerErrorCode Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Details { get { throw null; } }
        public Azure.AI.Language.Text.InnerErrorModel Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.InnerErrorModel System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.InnerErrorModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.InnerErrorModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.InnerErrorModel System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.InnerErrorModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.InnerErrorModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.InnerErrorModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyPhraseActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.KeyPhraseActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.KeyPhraseActionContent>
    {
        public KeyPhraseActionContent() { }
        public bool? LoggingOptOut { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.KeyPhraseActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.KeyPhraseActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.KeyPhraseActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.KeyPhraseActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.KeyPhraseActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.KeyPhraseActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.KeyPhraseActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyPhraseExtractionOperationResult : Azure.AI.Language.Text.AnalyzeTextOperationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.KeyPhraseExtractionOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.KeyPhraseExtractionOperationResult>
    {
        internal KeyPhraseExtractionOperationResult() : base (default(System.DateTimeOffset), default(Azure.AI.Language.Text.TextActionState)) { }
        public Azure.AI.Language.Text.KeyPhraseResult Results { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.KeyPhraseExtractionOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.KeyPhraseExtractionOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.KeyPhraseExtractionOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.KeyPhraseExtractionOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.KeyPhraseExtractionOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.KeyPhraseExtractionOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.KeyPhraseExtractionOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyPhraseOperationAction : Azure.AI.Language.Text.AnalyzeTextOperationAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.KeyPhraseOperationAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.KeyPhraseOperationAction>
    {
        public KeyPhraseOperationAction() { }
        public Azure.AI.Language.Text.KeyPhraseActionContent ActionContent { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.KeyPhraseOperationAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.KeyPhraseOperationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.KeyPhraseOperationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.KeyPhraseOperationAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.KeyPhraseOperationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.KeyPhraseOperationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.KeyPhraseOperationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyPhraseResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.KeyPhraseResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.KeyPhraseResult>
    {
        internal KeyPhraseResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.KeyPhrasesActionResult> Documents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.DocumentError> Errors { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.Language.Text.RequestStatistics Statistics { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.KeyPhraseResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.KeyPhraseResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.KeyPhraseResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.KeyPhraseResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.KeyPhraseResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.KeyPhraseResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.KeyPhraseResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyPhrasesActionResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.KeyPhrasesActionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.KeyPhrasesActionResult>
    {
        internal KeyPhrasesActionResult() { }
        public Azure.AI.Language.Text.DetectedLanguage DetectedLanguage { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> KeyPhrases { get { throw null; } }
        public Azure.AI.Language.Text.DocumentStatistics Statistics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.DocumentWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.KeyPhrasesActionResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.KeyPhrasesActionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.KeyPhrasesActionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.KeyPhrasesActionResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.KeyPhrasesActionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.KeyPhrasesActionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.KeyPhrasesActionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LanguageDetectionActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.LanguageDetectionActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.LanguageDetectionActionContent>
    {
        public LanguageDetectionActionContent() { }
        public bool? LoggingOptOut { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.LanguageDetectionActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.LanguageDetectionActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.LanguageDetectionActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.LanguageDetectionActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.LanguageDetectionActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.LanguageDetectionActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.LanguageDetectionActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LanguageDetectionDocumentResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.LanguageDetectionDocumentResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.LanguageDetectionDocumentResult>
    {
        internal LanguageDetectionDocumentResult() { }
        public Azure.AI.Language.Text.DetectedLanguage DetectedLanguage { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Language.Text.DocumentStatistics Statistics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.DocumentWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.LanguageDetectionDocumentResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.LanguageDetectionDocumentResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.LanguageDetectionDocumentResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.LanguageDetectionDocumentResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.LanguageDetectionDocumentResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.LanguageDetectionDocumentResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.LanguageDetectionDocumentResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LanguageDetectionResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.LanguageDetectionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.LanguageDetectionResult>
    {
        internal LanguageDetectionResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.LanguageDetectionDocumentResult> Documents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.DocumentError> Errors { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.Language.Text.RequestStatistics Statistics { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.LanguageDetectionResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.LanguageDetectionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.LanguageDetectionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.LanguageDetectionResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.LanguageDetectionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.LanguageDetectionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.LanguageDetectionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LanguageDetectionTextInput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.LanguageDetectionTextInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.LanguageDetectionTextInput>
    {
        public LanguageDetectionTextInput() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.LanguageInput> LanguageInputs { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.LanguageDetectionTextInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.LanguageDetectionTextInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.LanguageDetectionTextInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.LanguageDetectionTextInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.LanguageDetectionTextInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.LanguageDetectionTextInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.LanguageDetectionTextInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LanguageInput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.LanguageInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.LanguageInput>
    {
        public LanguageInput(string id, string text) { }
        public string CountryHint { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.LanguageInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.LanguageInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.LanguageInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.LanguageInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.LanguageInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.LanguageInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.LanguageInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LengthMetadata : Azure.AI.Language.Text.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.LengthMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.LengthMetadata>
    {
        internal LengthMetadata() { }
        public Azure.AI.Language.Text.LengthUnit Unit { get { throw null; } }
        public double Value { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.LengthMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.LengthMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.LengthMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.LengthMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.LengthMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.LengthMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.LengthMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LengthUnit : System.IEquatable<Azure.AI.Language.Text.LengthUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LengthUnit(string value) { throw null; }
        public static Azure.AI.Language.Text.LengthUnit Centimeter { get { throw null; } }
        public static Azure.AI.Language.Text.LengthUnit Decameter { get { throw null; } }
        public static Azure.AI.Language.Text.LengthUnit Decimeter { get { throw null; } }
        public static Azure.AI.Language.Text.LengthUnit Foot { get { throw null; } }
        public static Azure.AI.Language.Text.LengthUnit Hectometer { get { throw null; } }
        public static Azure.AI.Language.Text.LengthUnit Inch { get { throw null; } }
        public static Azure.AI.Language.Text.LengthUnit Kilometer { get { throw null; } }
        public static Azure.AI.Language.Text.LengthUnit LightYear { get { throw null; } }
        public static Azure.AI.Language.Text.LengthUnit Meter { get { throw null; } }
        public static Azure.AI.Language.Text.LengthUnit Micrometer { get { throw null; } }
        public static Azure.AI.Language.Text.LengthUnit Mile { get { throw null; } }
        public static Azure.AI.Language.Text.LengthUnit Millimeter { get { throw null; } }
        public static Azure.AI.Language.Text.LengthUnit Nanometer { get { throw null; } }
        public static Azure.AI.Language.Text.LengthUnit Picometer { get { throw null; } }
        public static Azure.AI.Language.Text.LengthUnit Point { get { throw null; } }
        public static Azure.AI.Language.Text.LengthUnit Unspecified { get { throw null; } }
        public static Azure.AI.Language.Text.LengthUnit Yard { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.LengthUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.LengthUnit left, Azure.AI.Language.Text.LengthUnit right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.LengthUnit (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.LengthUnit left, Azure.AI.Language.Text.LengthUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LinkedEntity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.LinkedEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.LinkedEntity>
    {
        internal LinkedEntity() { }
        public string BingId { get { throw null; } }
        public string DataSource { get { throw null; } }
        public string Id { get { throw null; } }
        public string Language { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.EntityLinkingMatch> Matches { get { throw null; } }
        public string Name { get { throw null; } }
        public string Url { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.LinkedEntity System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.LinkedEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.LinkedEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.LinkedEntity System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.LinkedEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.LinkedEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.LinkedEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MatchLongestEntityPolicyType : Azure.AI.Language.Text.EntityOverlapPolicy, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.MatchLongestEntityPolicyType>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.MatchLongestEntityPolicyType>
    {
        public MatchLongestEntityPolicyType() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.MatchLongestEntityPolicyType System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.MatchLongestEntityPolicyType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.MatchLongestEntityPolicyType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.MatchLongestEntityPolicyType System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.MatchLongestEntityPolicyType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.MatchLongestEntityPolicyType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.MatchLongestEntityPolicyType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MultiLanguageInput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.MultiLanguageInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.MultiLanguageInput>
    {
        public MultiLanguageInput(string id, string text) { }
        public string Id { get { throw null; } }
        public string Language { get { throw null; } set { } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.MultiLanguageInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.MultiLanguageInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.MultiLanguageInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.MultiLanguageInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.MultiLanguageInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.MultiLanguageInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.MultiLanguageInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MultiLanguageTextInput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.MultiLanguageTextInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.MultiLanguageTextInput>
    {
        public MultiLanguageTextInput() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.MultiLanguageInput> MultiLanguageInputs { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.MultiLanguageTextInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.MultiLanguageTextInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.MultiLanguageTextInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.MultiLanguageTextInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.MultiLanguageTextInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.MultiLanguageTextInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.MultiLanguageTextInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamedEntity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.NamedEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.NamedEntity>
    {
        internal NamedEntity() { }
        public string Category { get { throw null; } }
        public double ConfidenceScore { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        public string Subcategory { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.NamedEntity System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.NamedEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.NamedEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.NamedEntity System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.NamedEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.NamedEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.NamedEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamedEntityWithMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.NamedEntityWithMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.NamedEntityWithMetadata>
    {
        internal NamedEntityWithMetadata() { }
        public string Category { get { throw null; } }
        public double ConfidenceScore { get { throw null; } }
        public int Length { get { throw null; } }
        public Azure.AI.Language.Text.BaseMetadata Metadata { get { throw null; } }
        public int Offset { get { throw null; } }
        public string Subcategory { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.EntityTag> Tags { get { throw null; } }
        public string Text { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.NamedEntityWithMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.NamedEntityWithMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.NamedEntityWithMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.NamedEntityWithMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.NamedEntityWithMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.NamedEntityWithMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.NamedEntityWithMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NoMaskPolicyType : Azure.AI.Language.Text.BaseRedactionPolicy, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.NoMaskPolicyType>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.NoMaskPolicyType>
    {
        public NoMaskPolicyType() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.NoMaskPolicyType System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.NoMaskPolicyType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.NoMaskPolicyType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.NoMaskPolicyType System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.NoMaskPolicyType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.NoMaskPolicyType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.NoMaskPolicyType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NumberKind : System.IEquatable<Azure.AI.Language.Text.NumberKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NumberKind(string value) { throw null; }
        public static Azure.AI.Language.Text.NumberKind Decimal { get { throw null; } }
        public static Azure.AI.Language.Text.NumberKind Fraction { get { throw null; } }
        public static Azure.AI.Language.Text.NumberKind Integer { get { throw null; } }
        public static Azure.AI.Language.Text.NumberKind Percent { get { throw null; } }
        public static Azure.AI.Language.Text.NumberKind Power { get { throw null; } }
        public static Azure.AI.Language.Text.NumberKind Unspecified { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.NumberKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.NumberKind left, Azure.AI.Language.Text.NumberKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.NumberKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.NumberKind left, Azure.AI.Language.Text.NumberKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NumberMetadata : Azure.AI.Language.Text.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.NumberMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.NumberMetadata>
    {
        internal NumberMetadata() { }
        public Azure.AI.Language.Text.NumberKind NumberKind { get { throw null; } }
        public double Value { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.NumberMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.NumberMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.NumberMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.NumberMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.NumberMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.NumberMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.NumberMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NumericRangeMetadata : Azure.AI.Language.Text.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.NumericRangeMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.NumericRangeMetadata>
    {
        internal NumericRangeMetadata() { }
        public double Maximum { get { throw null; } }
        public double Minimum { get { throw null; } }
        public Azure.AI.Language.Text.RangeInclusivity? RangeInclusivity { get { throw null; } }
        public Azure.AI.Language.Text.RangeKind RangeKind { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.NumericRangeMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.NumericRangeMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.NumericRangeMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.NumericRangeMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.NumericRangeMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.NumericRangeMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.NumericRangeMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrdinalMetadata : Azure.AI.Language.Text.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.OrdinalMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.OrdinalMetadata>
    {
        internal OrdinalMetadata() { }
        public string Offset { get { throw null; } }
        public Azure.AI.Language.Text.RelativeTo RelativeTo { get { throw null; } }
        public string Value { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.OrdinalMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.OrdinalMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.OrdinalMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.OrdinalMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.OrdinalMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.OrdinalMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.OrdinalMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PiiActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.PiiActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.PiiActionContent>
    {
        public PiiActionContent() { }
        public Azure.AI.Language.Text.PiiDomain? Domain { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.PiiCategoriesExclude> ExcludePiiCategories { get { throw null; } }
        public bool? LoggingOptOut { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.PiiCategory> PiiCategories { get { throw null; } }
        public Azure.AI.Language.Text.BaseRedactionPolicy RedactionPolicy { get { throw null; } set { } }
        public Azure.AI.Language.Text.StringIndexType? StringIndexType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.PiiActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.PiiActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.PiiActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.PiiActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.PiiActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.PiiActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.PiiActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PiiActionResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.PiiActionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.PiiActionResult>
    {
        internal PiiActionResult() { }
        public Azure.AI.Language.Text.DetectedLanguage DetectedLanguage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.PiiEntity> Entities { get { throw null; } }
        public string Id { get { throw null; } }
        public string RedactedText { get { throw null; } }
        public Azure.AI.Language.Text.DocumentStatistics Statistics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.DocumentWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.PiiActionResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.PiiActionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.PiiActionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.PiiActionResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.PiiActionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.PiiActionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.PiiActionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PiiCategoriesExclude : System.IEquatable<Azure.AI.Language.Text.PiiCategoriesExclude>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PiiCategoriesExclude(string value) { throw null; }
        public static Azure.AI.Language.Text.PiiCategoriesExclude AbaRoutingNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude Address { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude Age { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude ArNationalIdentityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude AtIdentityCard { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude AtTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude AtValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude AuBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude AuBusinessNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude AuCompanyNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude AuDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude AuMedicalAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude AuPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude AuTaxFileNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude AzureDocumentDbauthKey { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude AzureIaasDatabaseConnectionAndSqlString { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude AzureIoTConnectionString { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude AzurePublishSettingPassword { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude AzureRedisCacheString { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude AzureSas { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude AzureServiceBusString { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude AzureStorageAccountGeneric { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude AzureStorageAccountKey { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude BeNationalNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude BeNationalNumberV2 { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude BeValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude BgUniformCivilNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude BrCpfNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude BrLegalEntityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude BrNationalIdRg { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude CaBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude CaDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude CaHealthServiceNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude CaPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude CaPersonalHealthIdentification { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude CaSocialInsuranceNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude ChSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude ClIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude CnResidentIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude CreditCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude CyIdentityCard { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude CyTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude CzPersonalIdentityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude CzPersonalIdentityV2 { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude Date { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude DeDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude DeIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude DePassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude DeTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude DeValueAddedNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude DkPersonalIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude DkPersonalIdentificationV2 { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude DrugEnforcementAgencyNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude EePersonalIdentificationCode { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude Email { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude EsDni { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude EsSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude EsTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude EuDebitCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude EuDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude EuGpsCoordinates { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude EuNationalIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude EuPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude EuSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude EuTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude FiEuropeanHealthNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude FiNationalId { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude FiNationalIdV2 { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude FiPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude FrDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude FrHealthInsuranceNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude FrNationalId { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude FrPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude FrSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude FrTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude FrValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude GrNationalIdCard { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude GrNationalIdV2 { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude GrTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude HkIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude HrIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude HrNationalIdNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude HrPersonalIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude HrPersonalIdentificationOIBNumberV2 { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude HuPersonalIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude HuTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude HuValueAddedNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude IdIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude IePersonalPublicServiceNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude IePersonalPublicServiceNumberV2 { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude IlBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude IlNationalId { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude InPermanentAccount { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude InternationalBankingAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude InUniqueIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude IPAddress { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude ItDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude ItFiscalCode { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude ItValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude JpBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude JpDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude JpMyNumberCorporate { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude JpMyNumberPersonal { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude JpPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude JpResidenceCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude JpResidentRegistrationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude JpSocialInsuranceNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude KrResidentRegistrationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude LtPersonalCode { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude LuNationalIdentificationNumberNatural { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude LuNationalIdentificationNumberNonNatural { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude LvPersonalCode { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude MtIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude MtTaxIdNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude MyIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude NlCitizensServiceNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude NlCitizensServiceNumberV2 { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude NlTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude NlValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude NoIdentityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude NzBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude NzDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude NzInlandRevenueNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude NzMinistryOfHealthNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude NzSocialWelfareNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude Organization { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude Person { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude PhoneNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude PhUnifiedMultiPurposeIdNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude PlIdentityCard { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude PlNationalId { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude PlNationalIdV2 { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude PlPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude PlRegonNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude PlTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude PtCitizenCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude PtCitizenCardNumberV2 { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude PtTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude RoPersonalNumericalCode { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude RuPassportNumberDomestic { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude RuPassportNumberInternational { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude SaNationalId { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude SeNationalId { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude SeNationalIdV2 { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude SePassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude SeTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude SgNationalRegistrationIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude SiTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude SiUniqueMasterCitizenNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude SkPersonalNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude SqlServerConnectionString { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude SwiftCode { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude ThPopulationIdentificationCode { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude TrNationalIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude TwNationalId { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude TwPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude TwResidentCertificate { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude UaPassportNumberDomestic { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude UaPassportNumberInternational { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude UkDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude UkElectoralRollNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude UkNationalHealthNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude UkNationalInsuranceNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude UkUniqueTaxpayerNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude URL { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude UsBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude UsDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude UsIndividualTaxpayerIdentification { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude UsSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude UsUkPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategoriesExclude ZaIdentificationNumber { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.PiiCategoriesExclude other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.PiiCategoriesExclude left, Azure.AI.Language.Text.PiiCategoriesExclude right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.PiiCategoriesExclude (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.PiiCategoriesExclude left, Azure.AI.Language.Text.PiiCategoriesExclude right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PiiCategory : System.IEquatable<Azure.AI.Language.Text.PiiCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PiiCategory(string value) { throw null; }
        public static Azure.AI.Language.Text.PiiCategory AbaRoutingNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory Address { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory Age { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory All { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory ArNationalIdentityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory AtIdentityCard { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory AtTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory AtValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory AuBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory AuBusinessNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory AuCompanyNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory AuDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory AuMedicalAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory AuPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory AuTaxFileNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory AzureDocumentDbauthKey { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory AzureIaasDatabaseConnectionAndSqlString { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory AzureIoTConnectionString { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory AzurePublishSettingPassword { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory AzureRedisCacheString { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory AzureSas { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory AzureServiceBusString { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory AzureStorageAccountGeneric { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory AzureStorageAccountKey { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory BeNationalNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory BeNationalNumberV2 { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory BeValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory BgUniformCivilNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory BrCpfNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory BrLegalEntityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory BrNationalIdRg { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory CaBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory CaDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory CaHealthServiceNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory CaPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory CaPersonalHealthIdentification { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory CaSocialInsuranceNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory ChSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory ClIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory CnResidentIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory CreditCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory CyIdentityCard { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory CyTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory CzPersonalIdentityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory CzPersonalIdentityV2 { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory Date { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory DeDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory Default { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory DeIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory DePassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory DeTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory DeValueAddedNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory DkPersonalIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory DkPersonalIdentificationV2 { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory DrugEnforcementAgencyNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory EePersonalIdentificationCode { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory Email { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory EsDni { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory EsSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory EsTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory EuDebitCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory EuDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory EuGpsCoordinates { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory EuNationalIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory EuPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory EuSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory EuTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory FiEuropeanHealthNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory FiNationalId { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory FiNationalIdV2 { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory FiPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory FrDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory FrHealthInsuranceNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory FrNationalId { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory FrPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory FrSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory FrTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory FrValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory GrNationalIdCard { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory GrNationalIdV2 { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory GrTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory HkIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory HrIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory HrNationalIdNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory HrPersonalIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory HrPersonalIdentificationOIBNumberV2 { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory HuPersonalIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory HuTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory HuValueAddedNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory IdIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory IePersonalPublicServiceNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory IePersonalPublicServiceNumberV2 { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory IlBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory IlNationalId { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory InPermanentAccount { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory InternationalBankingAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory InUniqueIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory IPAddress { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory ItDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory ItFiscalCode { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory ItValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory JpBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory JpDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory JpMyNumberCorporate { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory JpMyNumberPersonal { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory JpPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory JpResidenceCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory JpResidentRegistrationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory JpSocialInsuranceNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory KrResidentRegistrationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory LtPersonalCode { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory LuNationalIdentificationNumberNatural { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory LuNationalIdentificationNumberNonNatural { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory LvPersonalCode { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory MtIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory MtTaxIdNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory MyIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory NlCitizensServiceNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory NlCitizensServiceNumberV2 { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory NlTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory NlValueAddedTaxNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory NoIdentityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory NzBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory NzDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory NzInlandRevenueNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory NzMinistryOfHealthNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory NzSocialWelfareNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory Organization { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory Person { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory PhoneNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory PhUnifiedMultiPurposeIdNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory PlIdentityCard { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory PlNationalId { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory PlNationalIdV2 { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory PlPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory PlRegonNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory PlTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory PtCitizenCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory PtCitizenCardNumberV2 { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory PtTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory RoPersonalNumericalCode { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory RuPassportNumberDomestic { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory RuPassportNumberInternational { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory SaNationalId { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory SeNationalId { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory SeNationalIdV2 { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory SePassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory SeTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory SgNationalRegistrationIdentityCardNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory SiTaxIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory SiUniqueMasterCitizenNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory SkPersonalNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory SqlServerConnectionString { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory SwiftCode { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory ThPopulationIdentificationCode { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory TrNationalIdentificationNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory TwNationalId { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory TwPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory TwResidentCertificate { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory UaPassportNumberDomestic { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory UaPassportNumberInternational { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory UkDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory UkElectoralRollNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory UkNationalHealthNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory UkNationalInsuranceNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory UkUniqueTaxpayerNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory URL { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory UsBankAccountNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory UsDriversLicenseNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory UsIndividualTaxpayerIdentification { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory UsSocialSecurityNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory UsUkPassportNumber { get { throw null; } }
        public static Azure.AI.Language.Text.PiiCategory ZaIdentificationNumber { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.PiiCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.PiiCategory left, Azure.AI.Language.Text.PiiCategory right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.PiiCategory (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.PiiCategory left, Azure.AI.Language.Text.PiiCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PiiDomain : System.IEquatable<Azure.AI.Language.Text.PiiDomain>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PiiDomain(string value) { throw null; }
        public static Azure.AI.Language.Text.PiiDomain None { get { throw null; } }
        public static Azure.AI.Language.Text.PiiDomain Phi { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.PiiDomain other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.PiiDomain left, Azure.AI.Language.Text.PiiDomain right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.PiiDomain (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.PiiDomain left, Azure.AI.Language.Text.PiiDomain right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PiiEntity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.PiiEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.PiiEntity>
    {
        internal PiiEntity() { }
        public string Category { get { throw null; } }
        public double ConfidenceScore { get { throw null; } }
        public int Length { get { throw null; } }
        public string Mask { get { throw null; } }
        public int? MaskLength { get { throw null; } }
        public int? MaskOffset { get { throw null; } }
        public int Offset { get { throw null; } }
        public string Subcategory { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.EntityTag> Tags { get { throw null; } }
        public string Text { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.PiiEntity System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.PiiEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.PiiEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.PiiEntity System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.PiiEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.PiiEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.PiiEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PiiEntityRecognitionOperationResult : Azure.AI.Language.Text.AnalyzeTextOperationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.PiiEntityRecognitionOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.PiiEntityRecognitionOperationResult>
    {
        internal PiiEntityRecognitionOperationResult() : base (default(System.DateTimeOffset), default(Azure.AI.Language.Text.TextActionState)) { }
        public Azure.AI.Language.Text.PiiResult Results { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.PiiEntityRecognitionOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.PiiEntityRecognitionOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.PiiEntityRecognitionOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.PiiEntityRecognitionOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.PiiEntityRecognitionOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.PiiEntityRecognitionOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.PiiEntityRecognitionOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PiiOperationAction : Azure.AI.Language.Text.AnalyzeTextOperationAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.PiiOperationAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.PiiOperationAction>
    {
        public PiiOperationAction() { }
        public Azure.AI.Language.Text.PiiActionContent ActionContent { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.PiiOperationAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.PiiOperationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.PiiOperationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.PiiOperationAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.PiiOperationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.PiiOperationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.PiiOperationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PiiResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.PiiResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.PiiResult>
    {
        internal PiiResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.PiiActionResult> Documents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.DocumentError> Errors { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.Language.Text.RequestStatistics Statistics { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.PiiResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.PiiResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.PiiResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.PiiResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.PiiResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.PiiResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.PiiResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RangeInclusivity : System.IEquatable<Azure.AI.Language.Text.RangeInclusivity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RangeInclusivity(string value) { throw null; }
        public static Azure.AI.Language.Text.RangeInclusivity LeftInclusive { get { throw null; } }
        public static Azure.AI.Language.Text.RangeInclusivity LeftRightInclusive { get { throw null; } }
        public static Azure.AI.Language.Text.RangeInclusivity NoneInclusive { get { throw null; } }
        public static Azure.AI.Language.Text.RangeInclusivity RightInclusive { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.RangeInclusivity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.RangeInclusivity left, Azure.AI.Language.Text.RangeInclusivity right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.RangeInclusivity (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.RangeInclusivity left, Azure.AI.Language.Text.RangeInclusivity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RangeKind : System.IEquatable<Azure.AI.Language.Text.RangeKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RangeKind(string value) { throw null; }
        public static Azure.AI.Language.Text.RangeKind Age { get { throw null; } }
        public static Azure.AI.Language.Text.RangeKind Area { get { throw null; } }
        public static Azure.AI.Language.Text.RangeKind Currency { get { throw null; } }
        public static Azure.AI.Language.Text.RangeKind Information { get { throw null; } }
        public static Azure.AI.Language.Text.RangeKind Length { get { throw null; } }
        public static Azure.AI.Language.Text.RangeKind Number { get { throw null; } }
        public static Azure.AI.Language.Text.RangeKind Speed { get { throw null; } }
        public static Azure.AI.Language.Text.RangeKind Temperature { get { throw null; } }
        public static Azure.AI.Language.Text.RangeKind Volume { get { throw null; } }
        public static Azure.AI.Language.Text.RangeKind Weight { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.RangeKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.RangeKind left, Azure.AI.Language.Text.RangeKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.RangeKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.RangeKind left, Azure.AI.Language.Text.RangeKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedactionCharacter : System.IEquatable<Azure.AI.Language.Text.RedactionCharacter>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedactionCharacter(string value) { throw null; }
        public static Azure.AI.Language.Text.RedactionCharacter Ampersand { get { throw null; } }
        public static Azure.AI.Language.Text.RedactionCharacter Asterisk { get { throw null; } }
        public static Azure.AI.Language.Text.RedactionCharacter AtSign { get { throw null; } }
        public static Azure.AI.Language.Text.RedactionCharacter Caret { get { throw null; } }
        public static Azure.AI.Language.Text.RedactionCharacter Dollar { get { throw null; } }
        public static Azure.AI.Language.Text.RedactionCharacter EqualsValue { get { throw null; } }
        public static Azure.AI.Language.Text.RedactionCharacter ExclamationPoint { get { throw null; } }
        public static Azure.AI.Language.Text.RedactionCharacter Minus { get { throw null; } }
        public static Azure.AI.Language.Text.RedactionCharacter NumberSign { get { throw null; } }
        public static Azure.AI.Language.Text.RedactionCharacter PerCent { get { throw null; } }
        public static Azure.AI.Language.Text.RedactionCharacter Plus { get { throw null; } }
        public static Azure.AI.Language.Text.RedactionCharacter QuestionMark { get { throw null; } }
        public static Azure.AI.Language.Text.RedactionCharacter Tilde { get { throw null; } }
        public static Azure.AI.Language.Text.RedactionCharacter Underscore { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.RedactionCharacter other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.RedactionCharacter left, Azure.AI.Language.Text.RedactionCharacter right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.RedactionCharacter (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.RedactionCharacter left, Azure.AI.Language.Text.RedactionCharacter right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RelationType : System.IEquatable<Azure.AI.Language.Text.RelationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RelationType(string value) { throw null; }
        public static Azure.AI.Language.Text.RelationType Abbreviation { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType BodySiteOfCondition { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType BodySiteOfTreatment { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType CourseOfCondition { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType CourseOfExamination { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType CourseOfMedication { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType CourseOfTreatment { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType DirectionOfBodyStructure { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType DirectionOfCondition { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType DirectionOfExamination { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType DirectionOfTreatment { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType DosageOfMedication { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType ExaminationFindsCondition { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType ExpressionOfGene { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType ExpressionOfVariant { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType FormOfMedication { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType FrequencyOfCondition { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType FrequencyOfMedication { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType FrequencyOfTreatment { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType MutationTypeOfGene { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType MutationTypeOfVariant { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType QualifierOfCondition { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType RelationOfExamination { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType RouteOfMedication { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType ScaleOfCondition { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType TimeOfCondition { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType TimeOfEvent { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType TimeOfExamination { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType TimeOfMedication { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType TimeOfTreatment { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType UnitOfCondition { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType UnitOfExamination { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType ValueOfCondition { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType ValueOfExamination { get { throw null; } }
        public static Azure.AI.Language.Text.RelationType VariantOfGene { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.RelationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.RelationType left, Azure.AI.Language.Text.RelationType right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.RelationType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.RelationType left, Azure.AI.Language.Text.RelationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RelativeTo : System.IEquatable<Azure.AI.Language.Text.RelativeTo>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RelativeTo(string value) { throw null; }
        public static Azure.AI.Language.Text.RelativeTo Current { get { throw null; } }
        public static Azure.AI.Language.Text.RelativeTo End { get { throw null; } }
        public static Azure.AI.Language.Text.RelativeTo Start { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.RelativeTo other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.RelativeTo left, Azure.AI.Language.Text.RelativeTo right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.RelativeTo (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.RelativeTo left, Azure.AI.Language.Text.RelativeTo right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RequestStatistics : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.RequestStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.RequestStatistics>
    {
        internal RequestStatistics() { }
        public int DocumentsCount { get { throw null; } }
        public int ErroneousDocumentsCount { get { throw null; } }
        public long TransactionsCount { get { throw null; } }
        public int ValidDocumentsCount { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.RequestStatistics System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.RequestStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.RequestStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.RequestStatistics System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.RequestStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.RequestStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.RequestStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptCode : System.IEquatable<Azure.AI.Language.Text.ScriptCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptCode(string value) { throw null; }
        public static Azure.AI.Language.Text.ScriptCode Arab { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptCode Armn { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptCode Beng { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptCode Cans { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptCode Cyrl { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptCode Deva { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptCode Ethi { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptCode Geor { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptCode Grek { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptCode Gujr { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptCode Guru { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptCode Hang { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptCode Hani { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptCode Hans { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptCode Hant { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptCode Hebr { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptCode Jpan { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptCode Khmr { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptCode Knda { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptCode Laoo { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptCode Latn { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptCode Mlym { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptCode Mong { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptCode Mtei { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptCode Mymr { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptCode Olck { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptCode Orya { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptCode Shrd { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptCode Sinh { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptCode Taml { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptCode Telu { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptCode Thaa { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptCode Thai { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptCode Tibt { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.ScriptCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.ScriptCode left, Azure.AI.Language.Text.ScriptCode right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.ScriptCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.ScriptCode left, Azure.AI.Language.Text.ScriptCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptKind : System.IEquatable<Azure.AI.Language.Text.ScriptKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptKind(string value) { throw null; }
        public static Azure.AI.Language.Text.ScriptKind Arabic { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptKind Armenian { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptKind Bangla { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptKind Cyrillic { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptKind Devanagari { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptKind Ethiopic { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptKind Georgian { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptKind Greek { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptKind Gujarati { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptKind Gurmukhi { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptKind Hangul { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptKind HanLiteral { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptKind HanSimplified { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptKind HanTraditional { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptKind Hebrew { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptKind Japanese { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptKind Kannada { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptKind Khmer { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptKind Lao { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptKind Latin { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptKind Malayalam { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptKind Meitei { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptKind Mongolian { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptKind Myanmar { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptKind Odia { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptKind Santali { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptKind Sharada { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptKind Sinhala { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptKind Tamil { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptKind Telugu { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptKind Thaana { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptKind Thai { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptKind Tibetan { get { throw null; } }
        public static Azure.AI.Language.Text.ScriptKind UnifiedCanadianAboriginalSyllabics { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.ScriptKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.ScriptKind left, Azure.AI.Language.Text.ScriptKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.ScriptKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.ScriptKind left, Azure.AI.Language.Text.ScriptKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SentenceAssessment : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.SentenceAssessment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentenceAssessment>
    {
        internal SentenceAssessment() { }
        public Azure.AI.Language.Text.TargetConfidenceScoreLabel ConfidenceScores { get { throw null; } }
        public bool IsNegated { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        public Azure.AI.Language.Text.TokenSentiment Sentiment { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.SentenceAssessment System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.SentenceAssessment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.SentenceAssessment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.SentenceAssessment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentenceAssessment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentenceAssessment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentenceAssessment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SentenceSentiment : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.SentenceSentiment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentenceSentiment>
    {
        internal SentenceSentiment() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.SentenceAssessment> Assessments { get { throw null; } }
        public Azure.AI.Language.Text.SentimentConfidenceScores ConfidenceScores { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        public Azure.AI.Language.Text.SentenceSentimentValue Sentiment { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.SentenceTarget> Targets { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.SentenceSentiment System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.SentenceSentiment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.SentenceSentiment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.SentenceSentiment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentenceSentiment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentenceSentiment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentenceSentiment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum SentenceSentimentValue
    {
        Positive = 0,
        Neutral = 1,
        Negative = 2,
    }
    public partial class SentenceTarget : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.SentenceTarget>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentenceTarget>
    {
        internal SentenceTarget() { }
        public Azure.AI.Language.Text.TargetConfidenceScoreLabel ConfidenceScores { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.TargetRelation> Relations { get { throw null; } }
        public Azure.AI.Language.Text.TokenSentiment Sentiment { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.SentenceTarget System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.SentenceTarget>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.SentenceTarget>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.SentenceTarget System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentenceTarget>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentenceTarget>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentenceTarget>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SentimentActionResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.SentimentActionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentimentActionResult>
    {
        internal SentimentActionResult() { }
        public Azure.AI.Language.Text.SentimentConfidenceScores ConfidenceScores { get { throw null; } }
        public Azure.AI.Language.Text.DetectedLanguage DetectedLanguage { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.SentenceSentiment> Sentences { get { throw null; } }
        public Azure.AI.Language.Text.DocumentSentiment Sentiment { get { throw null; } }
        public Azure.AI.Language.Text.DocumentStatistics Statistics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.DocumentWarning> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.SentimentActionResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.SentimentActionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.SentimentActionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.SentimentActionResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentimentActionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentimentActionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentimentActionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SentimentAnalysisActionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.SentimentAnalysisActionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentimentAnalysisActionContent>
    {
        public SentimentAnalysisActionContent() { }
        public bool? LoggingOptOut { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        public bool? OpinionMining { get { throw null; } set { } }
        public Azure.AI.Language.Text.StringIndexType? StringIndexType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.SentimentAnalysisActionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.SentimentAnalysisActionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.SentimentAnalysisActionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.SentimentAnalysisActionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentimentAnalysisActionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentimentAnalysisActionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentimentAnalysisActionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SentimentAnalysisOperationAction : Azure.AI.Language.Text.AnalyzeTextOperationAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.SentimentAnalysisOperationAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentimentAnalysisOperationAction>
    {
        public SentimentAnalysisOperationAction() { }
        public Azure.AI.Language.Text.SentimentAnalysisActionContent ActionContent { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.SentimentAnalysisOperationAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.SentimentAnalysisOperationAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.SentimentAnalysisOperationAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.SentimentAnalysisOperationAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentimentAnalysisOperationAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentimentAnalysisOperationAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentimentAnalysisOperationAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SentimentConfidenceScores : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.SentimentConfidenceScores>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentimentConfidenceScores>
    {
        internal SentimentConfidenceScores() { }
        public double Negative { get { throw null; } }
        public double Neutral { get { throw null; } }
        public double Positive { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.SentimentConfidenceScores System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.SentimentConfidenceScores>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.SentimentConfidenceScores>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.SentimentConfidenceScores System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentimentConfidenceScores>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentimentConfidenceScores>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentimentConfidenceScores>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SentimentOperationResult : Azure.AI.Language.Text.AnalyzeTextOperationResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.SentimentOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentimentOperationResult>
    {
        internal SentimentOperationResult() : base (default(System.DateTimeOffset), default(Azure.AI.Language.Text.TextActionState)) { }
        public Azure.AI.Language.Text.SentimentResult Results { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.SentimentOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.SentimentOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.SentimentOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.SentimentOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentimentOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentimentOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentimentOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SentimentResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.SentimentResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentimentResult>
    {
        internal SentimentResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.SentimentActionResult> Documents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.DocumentError> Errors { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.Language.Text.RequestStatistics Statistics { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.SentimentResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.SentimentResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.SentimentResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.SentimentResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentimentResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentimentResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SentimentResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpeedMetadata : Azure.AI.Language.Text.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.SpeedMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SpeedMetadata>
    {
        internal SpeedMetadata() { }
        public Azure.AI.Language.Text.SpeedUnit Unit { get { throw null; } }
        public double Value { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.SpeedMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.SpeedMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.SpeedMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.SpeedMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SpeedMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SpeedMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SpeedMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SpeedUnit : System.IEquatable<Azure.AI.Language.Text.SpeedUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SpeedUnit(string value) { throw null; }
        public static Azure.AI.Language.Text.SpeedUnit CentimetersPerMillisecond { get { throw null; } }
        public static Azure.AI.Language.Text.SpeedUnit FeetPerMinute { get { throw null; } }
        public static Azure.AI.Language.Text.SpeedUnit FeetPerSecond { get { throw null; } }
        public static Azure.AI.Language.Text.SpeedUnit KilometersPerHour { get { throw null; } }
        public static Azure.AI.Language.Text.SpeedUnit KilometersPerMillisecond { get { throw null; } }
        public static Azure.AI.Language.Text.SpeedUnit KilometersPerMinute { get { throw null; } }
        public static Azure.AI.Language.Text.SpeedUnit KilometersPerSecond { get { throw null; } }
        public static Azure.AI.Language.Text.SpeedUnit Knots { get { throw null; } }
        public static Azure.AI.Language.Text.SpeedUnit MetersPerMillisecond { get { throw null; } }
        public static Azure.AI.Language.Text.SpeedUnit MetersPerSecond { get { throw null; } }
        public static Azure.AI.Language.Text.SpeedUnit MilesPerHour { get { throw null; } }
        public static Azure.AI.Language.Text.SpeedUnit Unspecified { get { throw null; } }
        public static Azure.AI.Language.Text.SpeedUnit YardsPerMinute { get { throw null; } }
        public static Azure.AI.Language.Text.SpeedUnit YardsPerSecond { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.SpeedUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.SpeedUnit left, Azure.AI.Language.Text.SpeedUnit right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.SpeedUnit (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.SpeedUnit left, Azure.AI.Language.Text.SpeedUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StringIndexType : System.IEquatable<Azure.AI.Language.Text.StringIndexType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StringIndexType(string value) { throw null; }
        public static Azure.AI.Language.Text.StringIndexType TextElementsV8 { get { throw null; } }
        public static Azure.AI.Language.Text.StringIndexType UnicodeCodePoint { get { throw null; } }
        public static Azure.AI.Language.Text.StringIndexType Utf16CodeUnit { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.StringIndexType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.StringIndexType left, Azure.AI.Language.Text.StringIndexType right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.StringIndexType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.StringIndexType left, Azure.AI.Language.Text.StringIndexType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SummaryContext : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.SummaryContext>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SummaryContext>
    {
        internal SummaryContext() { }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.SummaryContext System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.SummaryContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.SummaryContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.SummaryContext System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SummaryContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SummaryContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.SummaryContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SummaryLengthBucket : System.IEquatable<Azure.AI.Language.Text.SummaryLengthBucket>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SummaryLengthBucket(string value) { throw null; }
        public static Azure.AI.Language.Text.SummaryLengthBucket Long { get { throw null; } }
        public static Azure.AI.Language.Text.SummaryLengthBucket Medium { get { throw null; } }
        public static Azure.AI.Language.Text.SummaryLengthBucket Short { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.SummaryLengthBucket other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.SummaryLengthBucket left, Azure.AI.Language.Text.SummaryLengthBucket right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.SummaryLengthBucket (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.SummaryLengthBucket left, Azure.AI.Language.Text.SummaryLengthBucket right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TargetConfidenceScoreLabel : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TargetConfidenceScoreLabel>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TargetConfidenceScoreLabel>
    {
        internal TargetConfidenceScoreLabel() { }
        public double Negative { get { throw null; } }
        public double Positive { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.TargetConfidenceScoreLabel System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TargetConfidenceScoreLabel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TargetConfidenceScoreLabel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.TargetConfidenceScoreLabel System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TargetConfidenceScoreLabel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TargetConfidenceScoreLabel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TargetConfidenceScoreLabel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TargetRelation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TargetRelation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TargetRelation>
    {
        internal TargetRelation() { }
        public string Ref { get { throw null; } }
        public Azure.AI.Language.Text.TargetRelationType RelationType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.TargetRelation System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TargetRelation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TargetRelation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.TargetRelation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TargetRelation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TargetRelation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TargetRelation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum TargetRelationType
    {
        Assessment = 0,
        Target = 1,
    }
    public partial class TemperatureMetadata : Azure.AI.Language.Text.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TemperatureMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TemperatureMetadata>
    {
        internal TemperatureMetadata() { }
        public Azure.AI.Language.Text.TemperatureUnit Unit { get { throw null; } }
        public double Value { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.TemperatureMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TemperatureMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TemperatureMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.TemperatureMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TemperatureMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TemperatureMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TemperatureMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TemperatureUnit : System.IEquatable<Azure.AI.Language.Text.TemperatureUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TemperatureUnit(string value) { throw null; }
        public static Azure.AI.Language.Text.TemperatureUnit Celsius { get { throw null; } }
        public static Azure.AI.Language.Text.TemperatureUnit Fahrenheit { get { throw null; } }
        public static Azure.AI.Language.Text.TemperatureUnit Kelvin { get { throw null; } }
        public static Azure.AI.Language.Text.TemperatureUnit Rankine { get { throw null; } }
        public static Azure.AI.Language.Text.TemperatureUnit Unspecified { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.TemperatureUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.TemperatureUnit left, Azure.AI.Language.Text.TemperatureUnit right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.TemperatureUnit (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.TemperatureUnit left, Azure.AI.Language.Text.TemperatureUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TemporalModifier : System.IEquatable<Azure.AI.Language.Text.TemporalModifier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TemporalModifier(string value) { throw null; }
        public static Azure.AI.Language.Text.TemporalModifier After { get { throw null; } }
        public static Azure.AI.Language.Text.TemporalModifier AfterApprox { get { throw null; } }
        public static Azure.AI.Language.Text.TemporalModifier AfterMid { get { throw null; } }
        public static Azure.AI.Language.Text.TemporalModifier AfterStart { get { throw null; } }
        public static Azure.AI.Language.Text.TemporalModifier Approx { get { throw null; } }
        public static Azure.AI.Language.Text.TemporalModifier Before { get { throw null; } }
        public static Azure.AI.Language.Text.TemporalModifier BeforeApprox { get { throw null; } }
        public static Azure.AI.Language.Text.TemporalModifier BeforeEnd { get { throw null; } }
        public static Azure.AI.Language.Text.TemporalModifier BeforeStart { get { throw null; } }
        public static Azure.AI.Language.Text.TemporalModifier End { get { throw null; } }
        public static Azure.AI.Language.Text.TemporalModifier Less { get { throw null; } }
        public static Azure.AI.Language.Text.TemporalModifier Mid { get { throw null; } }
        public static Azure.AI.Language.Text.TemporalModifier More { get { throw null; } }
        public static Azure.AI.Language.Text.TemporalModifier ReferenceUndefined { get { throw null; } }
        public static Azure.AI.Language.Text.TemporalModifier Since { get { throw null; } }
        public static Azure.AI.Language.Text.TemporalModifier SinceEnd { get { throw null; } }
        public static Azure.AI.Language.Text.TemporalModifier Start { get { throw null; } }
        public static Azure.AI.Language.Text.TemporalModifier Until { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.TemporalModifier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.TemporalModifier left, Azure.AI.Language.Text.TemporalModifier right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.TemporalModifier (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.TemporalModifier left, Azure.AI.Language.Text.TemporalModifier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TemporalSetMetadata : Azure.AI.Language.Text.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TemporalSetMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TemporalSetMetadata>
    {
        internal TemporalSetMetadata() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.DateValue> Dates { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.TemporalSetMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TemporalSetMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TemporalSetMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.TemporalSetMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TemporalSetMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TemporalSetMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TemporalSetMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TemporalSpanMetadata : Azure.AI.Language.Text.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TemporalSpanMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TemporalSpanMetadata>
    {
        internal TemporalSpanMetadata() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.TemporalSpanValues> SpanValues { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.TemporalSpanMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TemporalSpanMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TemporalSpanMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.TemporalSpanMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TemporalSpanMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TemporalSpanMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TemporalSpanMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TemporalSpanValues : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TemporalSpanValues>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TemporalSpanValues>
    {
        internal TemporalSpanValues() { }
        public string Begin { get { throw null; } }
        public string Duration { get { throw null; } }
        public string End { get { throw null; } }
        public Azure.AI.Language.Text.TemporalModifier? Modifier { get { throw null; } }
        public string Timex { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.TemporalSpanValues System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TemporalSpanValues>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TemporalSpanValues>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.TemporalSpanValues System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TemporalSpanValues>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TemporalSpanValues>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TemporalSpanValues>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextActions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TextActions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TextActions>
    {
        internal TextActions() { }
        public int Completed { get { throw null; } }
        public int Failed { get { throw null; } }
        public int InProgress { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.AnalyzeTextOperationResult> Items { get { throw null; } }
        public int Total { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.TextActions System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TextActions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TextActions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.TextActions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TextActions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TextActions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TextActions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TextActionState : System.IEquatable<Azure.AI.Language.Text.TextActionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TextActionState(string value) { throw null; }
        public static Azure.AI.Language.Text.TextActionState Cancelled { get { throw null; } }
        public static Azure.AI.Language.Text.TextActionState Cancelling { get { throw null; } }
        public static Azure.AI.Language.Text.TextActionState Failed { get { throw null; } }
        public static Azure.AI.Language.Text.TextActionState NotStarted { get { throw null; } }
        public static Azure.AI.Language.Text.TextActionState PartiallyCompleted { get { throw null; } }
        public static Azure.AI.Language.Text.TextActionState Running { get { throw null; } }
        public static Azure.AI.Language.Text.TextActionState Succeeded { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.TextActionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.TextActionState left, Azure.AI.Language.Text.TextActionState right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.TextActionState (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.TextActionState left, Azure.AI.Language.Text.TextActionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TextAnalysisClient
    {
        protected TextAnalysisClient() { }
        public TextAnalysisClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public TextAnalysisClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Language.Text.TextAnalysisClientOptions options) { }
        public TextAnalysisClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public TextAnalysisClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Language.Text.TextAnalysisClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.Language.Text.AnalyzeTextResult> AnalyzeText(Azure.AI.Language.Text.AnalyzeTextInput analyzeTextInput, bool? showStatistics = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AnalyzeText(Azure.Core.RequestContent content, bool? showStatistics = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.AnalyzeTextResult>> AnalyzeTextAsync(Azure.AI.Language.Text.AnalyzeTextInput analyzeTextInput, bool? showStatistics = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AnalyzeTextAsync(Azure.Core.RequestContent content, bool? showStatistics = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation AnalyzeTextCancelOperation(Azure.WaitUntil waitUntil, System.Guid jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> AnalyzeTextCancelOperationAsync(Azure.WaitUntil waitUntil, System.Guid jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.AnalyzeTextOperationState> AnalyzeTextOperation(Azure.AI.Language.Text.MultiLanguageTextInput textInput, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.AnalyzeTextOperationAction> actions, string displayName = null, string defaultLanguage = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.AnalyzeTextOperationState>> AnalyzeTextOperationAsync(Azure.AI.Language.Text.MultiLanguageTextInput textInput, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.AnalyzeTextOperationAction> actions, string displayName = null, string defaultLanguage = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AnalyzeTextOperationStatus(System.Guid jobId, bool? showStats, int? top, int? skip, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.AnalyzeTextOperationState> AnalyzeTextOperationStatus(System.Guid jobId, bool? showStats = default(bool?), int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AnalyzeTextOperationStatusAsync(System.Guid jobId, bool? showStats, int? top, int? skip, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.AnalyzeTextOperationState>> AnalyzeTextOperationStatusAsync(System.Guid jobId, bool? showStats = default(bool?), int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation AnalyzeTextSubmitOperation(Azure.WaitUntil waitUntil, Azure.AI.Language.Text.MultiLanguageTextInput textInput, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.AnalyzeTextOperationAction> actions, string displayName = null, string defaultLanguage = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation AnalyzeTextSubmitOperation(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> AnalyzeTextSubmitOperationAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Text.MultiLanguageTextInput textInput, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.AnalyzeTextOperationAction> actions, string displayName = null, string defaultLanguage = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> AnalyzeTextSubmitOperationAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public static partial class TextAnalysisClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Text.TextAnalysisClient, Azure.AI.Language.Text.TextAnalysisClientOptions> AddTextAnalysisClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Text.TextAnalysisClient, Azure.AI.Language.Text.TextAnalysisClientOptions> AddTextAnalysisClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Text.TextAnalysisClient, Azure.AI.Language.Text.TextAnalysisClientOptions> AddTextAnalysisClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
    public partial class TextAnalysisClientOptions : Azure.Core.ClientOptions
    {
        public TextAnalysisClientOptions(Azure.AI.Language.Text.TextAnalysisClientOptions.ServiceVersion version = Azure.AI.Language.Text.TextAnalysisClientOptions.ServiceVersion.V2024_11_15_Preview) { }
        public enum ServiceVersion
        {
            V2022_05_01 = 1,
            V2023_04_01 = 2,
            V2024_11_01 = 3,
            V2024_11_15_Preview = 4,
        }
    }
    public static partial class TextAnalysisModelFactory
    {
        public static Azure.AI.Language.Text.AbstractiveSummarizationOperationResult AbstractiveSummarizationOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Text.TextActionState status = default(Azure.AI.Language.Text.TextActionState), string name = null, Azure.AI.Language.Text.AbstractiveSummarizationResult results = null) { throw null; }
        public static Azure.AI.Language.Text.AbstractiveSummarizationResult AbstractiveSummarizationResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.DocumentError> errors = null, Azure.AI.Language.Text.RequestStatistics statistics = null, string modelVersion = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.AbstractiveSummaryActionResult> documents = null) { throw null; }
        public static Azure.AI.Language.Text.AbstractiveSummary AbstractiveSummary(string text = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.SummaryContext> contexts = null) { throw null; }
        public static Azure.AI.Language.Text.AbstractiveSummaryActionResult AbstractiveSummaryActionResult(string id = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.DocumentWarning> warnings = null, Azure.AI.Language.Text.DocumentStatistics statistics = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.AbstractiveSummary> summaries = null, Azure.AI.Language.Text.DetectedLanguage detectedLanguage = null) { throw null; }
        public static Azure.AI.Language.Text.AgeMetadata AgeMetadata(double value = 0, Azure.AI.Language.Text.AgeUnit unit = default(Azure.AI.Language.Text.AgeUnit)) { throw null; }
        public static Azure.AI.Language.Text.AnalyzeTextEntitiesResult AnalyzeTextEntitiesResult(Azure.AI.Language.Text.EntitiesWithMetadataAutoResult results = null) { throw null; }
        public static Azure.AI.Language.Text.AnalyzeTextEntityLinkingResult AnalyzeTextEntityLinkingResult(Azure.AI.Language.Text.EntityLinkingResult results = null) { throw null; }
        public static Azure.AI.Language.Text.AnalyzeTextError AnalyzeTextError(Azure.AI.Language.Text.AnalyzeTextErrorCode code = default(Azure.AI.Language.Text.AnalyzeTextErrorCode), string message = null, string target = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.AnalyzeTextError> details = null, Azure.AI.Language.Text.InnerErrorModel innererror = null) { throw null; }
        public static Azure.AI.Language.Text.AnalyzeTextKeyPhraseResult AnalyzeTextKeyPhraseResult(Azure.AI.Language.Text.KeyPhraseResult results = null) { throw null; }
        public static Azure.AI.Language.Text.AnalyzeTextLanguageDetectionResult AnalyzeTextLanguageDetectionResult(Azure.AI.Language.Text.LanguageDetectionResult results = null) { throw null; }
        public static Azure.AI.Language.Text.AnalyzeTextOperationResult AnalyzeTextOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Text.TextActionState status = default(Azure.AI.Language.Text.TextActionState), string name = null, string kind = null) { throw null; }
        public static Azure.AI.Language.Text.AnalyzeTextOperationState AnalyzeTextOperationState(string displayName = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), System.Guid jobId = default(System.Guid), System.DateTimeOffset lastUpdatedAt = default(System.DateTimeOffset), Azure.AI.Language.Text.TextActionState status = default(Azure.AI.Language.Text.TextActionState), System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.AnalyzeTextError> errors = null, string nextLink = null, Azure.AI.Language.Text.TextActions actions = null, Azure.AI.Language.Text.RequestStatistics statistics = null) { throw null; }
        public static Azure.AI.Language.Text.AnalyzeTextPiiResult AnalyzeTextPiiResult(Azure.AI.Language.Text.PiiResult results = null) { throw null; }
        public static Azure.AI.Language.Text.AnalyzeTextSentimentResult AnalyzeTextSentimentResult(Azure.AI.Language.Text.SentimentResult results = null) { throw null; }
        public static Azure.AI.Language.Text.AreaMetadata AreaMetadata(double value = 0, Azure.AI.Language.Text.AreaUnit unit = default(Azure.AI.Language.Text.AreaUnit)) { throw null; }
        public static Azure.AI.Language.Text.ClassificationActionResult ClassificationActionResult(string id = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.DocumentWarning> warnings = null, Azure.AI.Language.Text.DocumentStatistics statistics = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.ClassificationResult> @class = null, Azure.AI.Language.Text.DetectedLanguage detectedLanguage = null) { throw null; }
        public static Azure.AI.Language.Text.ClassificationResult ClassificationResult(string category = null, double confidenceScore = 0) { throw null; }
        public static Azure.AI.Language.Text.CurrencyMetadata CurrencyMetadata(double value = 0, string unit = null, string iso4217 = null) { throw null; }
        public static Azure.AI.Language.Text.CustomEntitiesActionContent CustomEntitiesActionContent(bool? loggingOptOut = default(bool?), string projectName = null, string deploymentName = null, Azure.AI.Language.Text.StringIndexType? stringIndexType = default(Azure.AI.Language.Text.StringIndexType?)) { throw null; }
        public static Azure.AI.Language.Text.CustomEntitiesResult CustomEntitiesResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.DocumentError> errors = null, Azure.AI.Language.Text.RequestStatistics statistics = null, string projectName = null, string deploymentName = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.CustomEntityActionResult> documents = null) { throw null; }
        public static Azure.AI.Language.Text.CustomEntityActionResult CustomEntityActionResult(string id = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.DocumentWarning> warnings = null, Azure.AI.Language.Text.DocumentStatistics statistics = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.NamedEntity> entities = null, Azure.AI.Language.Text.DetectedLanguage detectedLanguage = null) { throw null; }
        public static Azure.AI.Language.Text.CustomEntityRecognitionOperationResult CustomEntityRecognitionOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Text.TextActionState status = default(Azure.AI.Language.Text.TextActionState), string name = null, Azure.AI.Language.Text.CustomEntitiesResult results = null) { throw null; }
        public static Azure.AI.Language.Text.CustomLabelClassificationResult CustomLabelClassificationResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.DocumentError> errors = null, Azure.AI.Language.Text.RequestStatistics statistics = null, string projectName = null, string deploymentName = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.ClassificationActionResult> documents = null) { throw null; }
        public static Azure.AI.Language.Text.CustomMultiLabelClassificationActionContent CustomMultiLabelClassificationActionContent(bool? loggingOptOut = default(bool?), string projectName = null, string deploymentName = null) { throw null; }
        public static Azure.AI.Language.Text.CustomMultiLabelClassificationOperationResult CustomMultiLabelClassificationOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Text.TextActionState status = default(Azure.AI.Language.Text.TextActionState), string name = null, Azure.AI.Language.Text.CustomLabelClassificationResult results = null) { throw null; }
        public static Azure.AI.Language.Text.CustomSingleLabelClassificationActionContent CustomSingleLabelClassificationActionContent(bool? loggingOptOut = default(bool?), string projectName = null, string deploymentName = null) { throw null; }
        public static Azure.AI.Language.Text.CustomSingleLabelClassificationOperationResult CustomSingleLabelClassificationOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Text.TextActionState status = default(Azure.AI.Language.Text.TextActionState), string name = null, Azure.AI.Language.Text.CustomLabelClassificationResult results = null) { throw null; }
        public static Azure.AI.Language.Text.DateMetadata DateMetadata(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.DateValue> dates = null) { throw null; }
        public static Azure.AI.Language.Text.DateTimeMetadata DateTimeMetadata(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.DateValue> dates = null) { throw null; }
        public static Azure.AI.Language.Text.DateValue DateValue(string timex = null, string value = null, Azure.AI.Language.Text.TemporalModifier? modifier = default(Azure.AI.Language.Text.TemporalModifier?)) { throw null; }
        public static Azure.AI.Language.Text.DetectedLanguage DetectedLanguage(string name = null, string iso6391Name = null, double confidenceScore = 0, Azure.AI.Language.Text.ScriptKind? scriptName = default(Azure.AI.Language.Text.ScriptKind?), Azure.AI.Language.Text.ScriptCode? scriptIso15924Code = default(Azure.AI.Language.Text.ScriptCode?)) { throw null; }
        public static Azure.AI.Language.Text.DocumentError DocumentError(string id = null, Azure.AI.Language.Text.AnalyzeTextError error = null) { throw null; }
        public static Azure.AI.Language.Text.DocumentStatistics DocumentStatistics(int charactersCount = 0, int transactionsCount = 0) { throw null; }
        public static Azure.AI.Language.Text.DocumentWarning DocumentWarning(Azure.AI.Language.Text.WarningCode code = default(Azure.AI.Language.Text.WarningCode), string message = null, string targetRef = null) { throw null; }
        public static Azure.AI.Language.Text.EntitiesResult EntitiesResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.DocumentError> errors = null, Azure.AI.Language.Text.RequestStatistics statistics = null, string modelVersion = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.EntityActionResultWithMetadata> documents = null) { throw null; }
        public static Azure.AI.Language.Text.EntitiesWithMetadataAutoResult EntitiesWithMetadataAutoResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.DocumentError> errors = null, Azure.AI.Language.Text.RequestStatistics statistics = null, string modelVersion = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.EntityActionResult> documents = null) { throw null; }
        public static Azure.AI.Language.Text.EntityActionResult EntityActionResult(string id = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.DocumentWarning> warnings = null, Azure.AI.Language.Text.DocumentStatistics statistics = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.NamedEntityWithMetadata> entities = null, Azure.AI.Language.Text.DetectedLanguage detectedLanguage = null) { throw null; }
        public static Azure.AI.Language.Text.EntityActionResultWithMetadata EntityActionResultWithMetadata(string id = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.DocumentWarning> warnings = null, Azure.AI.Language.Text.DocumentStatistics statistics = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.NamedEntityWithMetadata> entities = null) { throw null; }
        public static Azure.AI.Language.Text.EntityLinkingActionResult EntityLinkingActionResult(string id = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.DocumentWarning> warnings = null, Azure.AI.Language.Text.DocumentStatistics statistics = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.LinkedEntity> entities = null, Azure.AI.Language.Text.DetectedLanguage detectedLanguage = null) { throw null; }
        public static Azure.AI.Language.Text.EntityLinkingMatch EntityLinkingMatch(double confidenceScore = 0, string text = null, int offset = 0, int length = 0) { throw null; }
        public static Azure.AI.Language.Text.EntityLinkingOperationResult EntityLinkingOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Text.TextActionState status = default(Azure.AI.Language.Text.TextActionState), string name = null, Azure.AI.Language.Text.EntityLinkingResult results = null) { throw null; }
        public static Azure.AI.Language.Text.EntityLinkingResult EntityLinkingResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.DocumentError> errors = null, Azure.AI.Language.Text.RequestStatistics statistics = null, string modelVersion = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.EntityLinkingActionResult> documents = null) { throw null; }
        public static Azure.AI.Language.Text.EntityRecognitionOperationResult EntityRecognitionOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Text.TextActionState status = default(Azure.AI.Language.Text.TextActionState), string name = null, Azure.AI.Language.Text.EntitiesResult results = null) { throw null; }
        public static Azure.AI.Language.Text.EntityTag EntityTag(string name = null, double? confidenceScore = default(double?)) { throw null; }
        public static Azure.AI.Language.Text.ExtractedSummaryActionResult ExtractedSummaryActionResult(string id = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.DocumentWarning> warnings = null, Azure.AI.Language.Text.DocumentStatistics statistics = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.ExtractedSummarySentence> sentences = null, Azure.AI.Language.Text.DetectedLanguage detectedLanguage = null) { throw null; }
        public static Azure.AI.Language.Text.ExtractedSummarySentence ExtractedSummarySentence(string text = null, double rankScore = 0, int offset = 0, int length = 0) { throw null; }
        public static Azure.AI.Language.Text.ExtractiveSummarizationOperationResult ExtractiveSummarizationOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Text.TextActionState status = default(Azure.AI.Language.Text.TextActionState), string name = null, Azure.AI.Language.Text.ExtractiveSummarizationResult results = null) { throw null; }
        public static Azure.AI.Language.Text.ExtractiveSummarizationResult ExtractiveSummarizationResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.DocumentError> errors = null, Azure.AI.Language.Text.RequestStatistics statistics = null, string modelVersion = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.ExtractedSummaryActionResult> documents = null) { throw null; }
        public static Azure.AI.Language.Text.FhirBundle FhirBundle(System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.AI.Language.Text.HealthcareActionResult HealthcareActionResult(string id = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.DocumentWarning> warnings = null, Azure.AI.Language.Text.DocumentStatistics statistics = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.HealthcareEntity> entities = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.HealthcareRelation> relations = null, Azure.AI.Language.Text.FhirBundle fhirBundle = null, Azure.AI.Language.Text.DetectedLanguage detectedLanguage = null) { throw null; }
        public static Azure.AI.Language.Text.HealthcareAssertion HealthcareAssertion(Azure.AI.Language.Text.HealthcareAssertionConditionality? conditionality = default(Azure.AI.Language.Text.HealthcareAssertionConditionality?), Azure.AI.Language.Text.HealthcareAssertionCertainty? certainty = default(Azure.AI.Language.Text.HealthcareAssertionCertainty?), Azure.AI.Language.Text.HealthcareAssertionAssociation? association = default(Azure.AI.Language.Text.HealthcareAssertionAssociation?), Azure.AI.Language.Text.HealthcareAssertionTemporality? temporality = default(Azure.AI.Language.Text.HealthcareAssertionTemporality?)) { throw null; }
        public static Azure.AI.Language.Text.HealthcareEntity HealthcareEntity(string text = null, Azure.AI.Language.Text.HealthcareEntityCategory category = default(Azure.AI.Language.Text.HealthcareEntityCategory), string subcategory = null, int offset = 0, int length = 0, double confidenceScore = 0, Azure.AI.Language.Text.HealthcareAssertion assertion = null, string name = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.HealthcareEntityLink> links = null) { throw null; }
        public static Azure.AI.Language.Text.HealthcareEntityLink HealthcareEntityLink(string dataSource = null, string id = null) { throw null; }
        public static Azure.AI.Language.Text.HealthcareOperationResult HealthcareOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Text.TextActionState status = default(Azure.AI.Language.Text.TextActionState), string name = null, Azure.AI.Language.Text.HealthcareResult results = null) { throw null; }
        public static Azure.AI.Language.Text.HealthcareRelation HealthcareRelation(Azure.AI.Language.Text.RelationType relationType = default(Azure.AI.Language.Text.RelationType), System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.HealthcareRelationEntity> entities = null, double? confidenceScore = default(double?)) { throw null; }
        public static Azure.AI.Language.Text.HealthcareRelationEntity HealthcareRelationEntity(string @ref = null, string role = null) { throw null; }
        public static Azure.AI.Language.Text.HealthcareResult HealthcareResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.DocumentError> errors = null, Azure.AI.Language.Text.RequestStatistics statistics = null, string modelVersion = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.HealthcareActionResult> documents = null) { throw null; }
        public static Azure.AI.Language.Text.InformationMetadata InformationMetadata(double value = 0, Azure.AI.Language.Text.InformationUnit unit = default(Azure.AI.Language.Text.InformationUnit)) { throw null; }
        public static Azure.AI.Language.Text.InnerErrorModel InnerErrorModel(Azure.AI.Language.Text.InnerErrorCode code = default(Azure.AI.Language.Text.InnerErrorCode), string message = null, System.Collections.Generic.IReadOnlyDictionary<string, string> details = null, string target = null, Azure.AI.Language.Text.InnerErrorModel innererror = null) { throw null; }
        public static Azure.AI.Language.Text.KeyPhraseExtractionOperationResult KeyPhraseExtractionOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Text.TextActionState status = default(Azure.AI.Language.Text.TextActionState), string name = null, Azure.AI.Language.Text.KeyPhraseResult results = null) { throw null; }
        public static Azure.AI.Language.Text.KeyPhraseResult KeyPhraseResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.DocumentError> errors = null, Azure.AI.Language.Text.RequestStatistics statistics = null, string modelVersion = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.KeyPhrasesActionResult> documents = null) { throw null; }
        public static Azure.AI.Language.Text.KeyPhrasesActionResult KeyPhrasesActionResult(string id = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.DocumentWarning> warnings = null, Azure.AI.Language.Text.DocumentStatistics statistics = null, System.Collections.Generic.IEnumerable<string> keyPhrases = null, Azure.AI.Language.Text.DetectedLanguage detectedLanguage = null) { throw null; }
        public static Azure.AI.Language.Text.LanguageDetectionDocumentResult LanguageDetectionDocumentResult(string id = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.DocumentWarning> warnings = null, Azure.AI.Language.Text.DocumentStatistics statistics = null, Azure.AI.Language.Text.DetectedLanguage detectedLanguage = null) { throw null; }
        public static Azure.AI.Language.Text.LanguageDetectionResult LanguageDetectionResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.DocumentError> errors = null, Azure.AI.Language.Text.RequestStatistics statistics = null, string modelVersion = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.LanguageDetectionDocumentResult> documents = null) { throw null; }
        public static Azure.AI.Language.Text.LanguageInput LanguageInput(string id = null, string text = null, string countryHint = null) { throw null; }
        public static Azure.AI.Language.Text.LengthMetadata LengthMetadata(double value = 0, Azure.AI.Language.Text.LengthUnit unit = default(Azure.AI.Language.Text.LengthUnit)) { throw null; }
        public static Azure.AI.Language.Text.LinkedEntity LinkedEntity(string name = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.EntityLinkingMatch> matches = null, string language = null, string id = null, string url = null, string dataSource = null, string bingId = null) { throw null; }
        public static Azure.AI.Language.Text.MultiLanguageInput MultiLanguageInput(string id = null, string text = null, string language = null) { throw null; }
        public static Azure.AI.Language.Text.NamedEntity NamedEntity(string text = null, string category = null, string subcategory = null, int offset = 0, int length = 0, double confidenceScore = 0) { throw null; }
        public static Azure.AI.Language.Text.NamedEntityWithMetadata NamedEntityWithMetadata(string text = null, string category = null, string subcategory = null, int offset = 0, int length = 0, double confidenceScore = 0, string type = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.EntityTag> tags = null, Azure.AI.Language.Text.BaseMetadata metadata = null) { throw null; }
        public static Azure.AI.Language.Text.NumberMetadata NumberMetadata(Azure.AI.Language.Text.NumberKind numberKind = default(Azure.AI.Language.Text.NumberKind), double value = 0) { throw null; }
        public static Azure.AI.Language.Text.NumericRangeMetadata NumericRangeMetadata(Azure.AI.Language.Text.RangeKind rangeKind = default(Azure.AI.Language.Text.RangeKind), double minimum = 0, double maximum = 0, Azure.AI.Language.Text.RangeInclusivity? rangeInclusivity = default(Azure.AI.Language.Text.RangeInclusivity?)) { throw null; }
        public static Azure.AI.Language.Text.OrdinalMetadata OrdinalMetadata(string offset = null, Azure.AI.Language.Text.RelativeTo relativeTo = default(Azure.AI.Language.Text.RelativeTo), string value = null) { throw null; }
        public static Azure.AI.Language.Text.PiiActionResult PiiActionResult(string id = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.DocumentWarning> warnings = null, Azure.AI.Language.Text.DocumentStatistics statistics = null, string redactedText = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.PiiEntity> entities = null, Azure.AI.Language.Text.DetectedLanguage detectedLanguage = null) { throw null; }
        public static Azure.AI.Language.Text.PiiEntity PiiEntity(string text = null, string category = null, string subcategory = null, int offset = 0, int length = 0, double confidenceScore = 0, string type = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.EntityTag> tags = null, string mask = null, int? maskOffset = default(int?), int? maskLength = default(int?)) { throw null; }
        public static Azure.AI.Language.Text.PiiEntityRecognitionOperationResult PiiEntityRecognitionOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Text.TextActionState status = default(Azure.AI.Language.Text.TextActionState), string name = null, Azure.AI.Language.Text.PiiResult results = null) { throw null; }
        public static Azure.AI.Language.Text.PiiResult PiiResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.DocumentError> errors = null, Azure.AI.Language.Text.RequestStatistics statistics = null, string modelVersion = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.PiiActionResult> documents = null) { throw null; }
        public static Azure.AI.Language.Text.RequestStatistics RequestStatistics(int documentsCount = 0, int validDocumentsCount = 0, int erroneousDocumentsCount = 0, long transactionsCount = (long)0) { throw null; }
        public static Azure.AI.Language.Text.SentenceAssessment SentenceAssessment(Azure.AI.Language.Text.TokenSentiment sentiment = Azure.AI.Language.Text.TokenSentiment.Positive, Azure.AI.Language.Text.TargetConfidenceScoreLabel confidenceScores = null, int offset = 0, int length = 0, string text = null, bool isNegated = false) { throw null; }
        public static Azure.AI.Language.Text.SentenceSentiment SentenceSentiment(string text = null, Azure.AI.Language.Text.SentenceSentimentValue sentiment = Azure.AI.Language.Text.SentenceSentimentValue.Positive, Azure.AI.Language.Text.SentimentConfidenceScores confidenceScores = null, int offset = 0, int length = 0, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.SentenceTarget> targets = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.SentenceAssessment> assessments = null) { throw null; }
        public static Azure.AI.Language.Text.SentenceTarget SentenceTarget(Azure.AI.Language.Text.TokenSentiment sentiment = Azure.AI.Language.Text.TokenSentiment.Positive, Azure.AI.Language.Text.TargetConfidenceScoreLabel confidenceScores = null, int offset = 0, int length = 0, string text = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.TargetRelation> relations = null) { throw null; }
        public static Azure.AI.Language.Text.SentimentActionResult SentimentActionResult(string id = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.DocumentWarning> warnings = null, Azure.AI.Language.Text.DocumentStatistics statistics = null, Azure.AI.Language.Text.DocumentSentiment sentiment = Azure.AI.Language.Text.DocumentSentiment.Positive, Azure.AI.Language.Text.SentimentConfidenceScores confidenceScores = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.SentenceSentiment> sentences = null, Azure.AI.Language.Text.DetectedLanguage detectedLanguage = null) { throw null; }
        public static Azure.AI.Language.Text.SentimentConfidenceScores SentimentConfidenceScores(double positive = 0, double neutral = 0, double negative = 0) { throw null; }
        public static Azure.AI.Language.Text.SentimentOperationResult SentimentOperationResult(System.DateTimeOffset lastUpdateDateTime = default(System.DateTimeOffset), Azure.AI.Language.Text.TextActionState status = default(Azure.AI.Language.Text.TextActionState), string name = null, Azure.AI.Language.Text.SentimentResult results = null) { throw null; }
        public static Azure.AI.Language.Text.SentimentResult SentimentResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.DocumentError> errors = null, Azure.AI.Language.Text.RequestStatistics statistics = null, string modelVersion = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.SentimentActionResult> documents = null) { throw null; }
        public static Azure.AI.Language.Text.SpeedMetadata SpeedMetadata(double value = 0, Azure.AI.Language.Text.SpeedUnit unit = default(Azure.AI.Language.Text.SpeedUnit)) { throw null; }
        public static Azure.AI.Language.Text.SummaryContext SummaryContext(int offset = 0, int length = 0) { throw null; }
        public static Azure.AI.Language.Text.TargetConfidenceScoreLabel TargetConfidenceScoreLabel(double positive = 0, double negative = 0) { throw null; }
        public static Azure.AI.Language.Text.TargetRelation TargetRelation(string @ref = null, Azure.AI.Language.Text.TargetRelationType relationType = Azure.AI.Language.Text.TargetRelationType.Assessment) { throw null; }
        public static Azure.AI.Language.Text.TemperatureMetadata TemperatureMetadata(double value = 0, Azure.AI.Language.Text.TemperatureUnit unit = default(Azure.AI.Language.Text.TemperatureUnit)) { throw null; }
        public static Azure.AI.Language.Text.TemporalSetMetadata TemporalSetMetadata(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.DateValue> dates = null) { throw null; }
        public static Azure.AI.Language.Text.TemporalSpanMetadata TemporalSpanMetadata(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.TemporalSpanValues> spanValues = null) { throw null; }
        public static Azure.AI.Language.Text.TemporalSpanValues TemporalSpanValues(string begin = null, string end = null, string duration = null, Azure.AI.Language.Text.TemporalModifier? modifier = default(Azure.AI.Language.Text.TemporalModifier?), string timex = null) { throw null; }
        public static Azure.AI.Language.Text.TextActions TextActions(int completed = 0, int failed = 0, int inProgress = 0, int total = 0, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.AnalyzeTextOperationResult> items = null) { throw null; }
        public static Azure.AI.Language.Text.TimeMetadata TimeMetadata(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.DateValue> dates = null) { throw null; }
        public static Azure.AI.Language.Text.VolumeMetadata VolumeMetadata(double value = 0, Azure.AI.Language.Text.VolumeUnit unit = default(Azure.AI.Language.Text.VolumeUnit)) { throw null; }
        public static Azure.AI.Language.Text.WeightMetadata WeightMetadata(double value = 0, Azure.AI.Language.Text.WeightUnit unit = default(Azure.AI.Language.Text.WeightUnit)) { throw null; }
    }
    public partial class TextEntityLinkingInput : Azure.AI.Language.Text.AnalyzeTextInput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TextEntityLinkingInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TextEntityLinkingInput>
    {
        public TextEntityLinkingInput() { }
        public Azure.AI.Language.Text.EntityLinkingActionContent ActionContent { get { throw null; } set { } }
        public Azure.AI.Language.Text.MultiLanguageTextInput TextInput { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.TextEntityLinkingInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TextEntityLinkingInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TextEntityLinkingInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.TextEntityLinkingInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TextEntityLinkingInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TextEntityLinkingInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TextEntityLinkingInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextEntityRecognitionInput : Azure.AI.Language.Text.AnalyzeTextInput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TextEntityRecognitionInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TextEntityRecognitionInput>
    {
        public TextEntityRecognitionInput() { }
        public Azure.AI.Language.Text.EntitiesActionContent ActionContent { get { throw null; } set { } }
        public Azure.AI.Language.Text.MultiLanguageTextInput TextInput { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.TextEntityRecognitionInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TextEntityRecognitionInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TextEntityRecognitionInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.TextEntityRecognitionInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TextEntityRecognitionInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TextEntityRecognitionInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TextEntityRecognitionInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextKeyPhraseExtractionInput : Azure.AI.Language.Text.AnalyzeTextInput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TextKeyPhraseExtractionInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TextKeyPhraseExtractionInput>
    {
        public TextKeyPhraseExtractionInput() { }
        public Azure.AI.Language.Text.KeyPhraseActionContent ActionContent { get { throw null; } set { } }
        public Azure.AI.Language.Text.MultiLanguageTextInput TextInput { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.TextKeyPhraseExtractionInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TextKeyPhraseExtractionInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TextKeyPhraseExtractionInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.TextKeyPhraseExtractionInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TextKeyPhraseExtractionInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TextKeyPhraseExtractionInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TextKeyPhraseExtractionInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextLanguageDetectionInput : Azure.AI.Language.Text.AnalyzeTextInput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TextLanguageDetectionInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TextLanguageDetectionInput>
    {
        public TextLanguageDetectionInput() { }
        public Azure.AI.Language.Text.LanguageDetectionActionContent ActionContent { get { throw null; } set { } }
        public Azure.AI.Language.Text.LanguageDetectionTextInput TextInput { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.TextLanguageDetectionInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TextLanguageDetectionInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TextLanguageDetectionInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.TextLanguageDetectionInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TextLanguageDetectionInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TextLanguageDetectionInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TextLanguageDetectionInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextPiiEntitiesRecognitionInput : Azure.AI.Language.Text.AnalyzeTextInput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TextPiiEntitiesRecognitionInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TextPiiEntitiesRecognitionInput>
    {
        public TextPiiEntitiesRecognitionInput() { }
        public Azure.AI.Language.Text.PiiActionContent ActionContent { get { throw null; } set { } }
        public Azure.AI.Language.Text.MultiLanguageTextInput TextInput { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.TextPiiEntitiesRecognitionInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TextPiiEntitiesRecognitionInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TextPiiEntitiesRecognitionInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.TextPiiEntitiesRecognitionInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TextPiiEntitiesRecognitionInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TextPiiEntitiesRecognitionInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TextPiiEntitiesRecognitionInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextSentimentAnalysisInput : Azure.AI.Language.Text.AnalyzeTextInput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TextSentimentAnalysisInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TextSentimentAnalysisInput>
    {
        public TextSentimentAnalysisInput() { }
        public Azure.AI.Language.Text.SentimentAnalysisActionContent ActionContent { get { throw null; } set { } }
        public Azure.AI.Language.Text.MultiLanguageTextInput TextInput { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.TextSentimentAnalysisInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TextSentimentAnalysisInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TextSentimentAnalysisInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.TextSentimentAnalysisInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TextSentimentAnalysisInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TextSentimentAnalysisInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TextSentimentAnalysisInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TimeMetadata : Azure.AI.Language.Text.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TimeMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TimeMetadata>
    {
        internal TimeMetadata() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.DateValue> Dates { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.TimeMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TimeMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.TimeMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.TimeMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TimeMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TimeMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.TimeMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum TokenSentiment
    {
        Positive = 0,
        Mixed = 1,
        Negative = 2,
    }
    public partial class VolumeMetadata : Azure.AI.Language.Text.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.VolumeMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.VolumeMetadata>
    {
        internal VolumeMetadata() { }
        public Azure.AI.Language.Text.VolumeUnit Unit { get { throw null; } }
        public double Value { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.VolumeMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.VolumeMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.VolumeMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.VolumeMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.VolumeMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.VolumeMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.VolumeMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VolumeUnit : System.IEquatable<Azure.AI.Language.Text.VolumeUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VolumeUnit(string value) { throw null; }
        public static Azure.AI.Language.Text.VolumeUnit Barrel { get { throw null; } }
        public static Azure.AI.Language.Text.VolumeUnit Bushel { get { throw null; } }
        public static Azure.AI.Language.Text.VolumeUnit Centiliter { get { throw null; } }
        public static Azure.AI.Language.Text.VolumeUnit Cord { get { throw null; } }
        public static Azure.AI.Language.Text.VolumeUnit CubicCentimeter { get { throw null; } }
        public static Azure.AI.Language.Text.VolumeUnit CubicFoot { get { throw null; } }
        public static Azure.AI.Language.Text.VolumeUnit CubicInch { get { throw null; } }
        public static Azure.AI.Language.Text.VolumeUnit CubicMeter { get { throw null; } }
        public static Azure.AI.Language.Text.VolumeUnit CubicMile { get { throw null; } }
        public static Azure.AI.Language.Text.VolumeUnit CubicMillimeter { get { throw null; } }
        public static Azure.AI.Language.Text.VolumeUnit CubicYard { get { throw null; } }
        public static Azure.AI.Language.Text.VolumeUnit Cup { get { throw null; } }
        public static Azure.AI.Language.Text.VolumeUnit Decaliter { get { throw null; } }
        public static Azure.AI.Language.Text.VolumeUnit FluidDram { get { throw null; } }
        public static Azure.AI.Language.Text.VolumeUnit FluidOunce { get { throw null; } }
        public static Azure.AI.Language.Text.VolumeUnit Gill { get { throw null; } }
        public static Azure.AI.Language.Text.VolumeUnit Hectoliter { get { throw null; } }
        public static Azure.AI.Language.Text.VolumeUnit Hogshead { get { throw null; } }
        public static Azure.AI.Language.Text.VolumeUnit Liter { get { throw null; } }
        public static Azure.AI.Language.Text.VolumeUnit Milliliter { get { throw null; } }
        public static Azure.AI.Language.Text.VolumeUnit Minim { get { throw null; } }
        public static Azure.AI.Language.Text.VolumeUnit Peck { get { throw null; } }
        public static Azure.AI.Language.Text.VolumeUnit Pinch { get { throw null; } }
        public static Azure.AI.Language.Text.VolumeUnit Pint { get { throw null; } }
        public static Azure.AI.Language.Text.VolumeUnit Quart { get { throw null; } }
        public static Azure.AI.Language.Text.VolumeUnit Tablespoon { get { throw null; } }
        public static Azure.AI.Language.Text.VolumeUnit Teaspoon { get { throw null; } }
        public static Azure.AI.Language.Text.VolumeUnit Unspecified { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.VolumeUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.VolumeUnit left, Azure.AI.Language.Text.VolumeUnit right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.VolumeUnit (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.VolumeUnit left, Azure.AI.Language.Text.VolumeUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WarningCode : System.IEquatable<Azure.AI.Language.Text.WarningCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WarningCode(string value) { throw null; }
        public static Azure.AI.Language.Text.WarningCode DocumentTruncated { get { throw null; } }
        public static Azure.AI.Language.Text.WarningCode LongWordsInDocument { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.WarningCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.WarningCode left, Azure.AI.Language.Text.WarningCode right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.WarningCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.WarningCode left, Azure.AI.Language.Text.WarningCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WeightMetadata : Azure.AI.Language.Text.BaseMetadata, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.WeightMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.WeightMetadata>
    {
        internal WeightMetadata() { }
        public Azure.AI.Language.Text.WeightUnit Unit { get { throw null; } }
        public double Value { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.WeightMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.WeightMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.WeightMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.WeightMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.WeightMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.WeightMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.WeightMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WeightUnit : System.IEquatable<Azure.AI.Language.Text.WeightUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WeightUnit(string value) { throw null; }
        public static Azure.AI.Language.Text.WeightUnit Dram { get { throw null; } }
        public static Azure.AI.Language.Text.WeightUnit Gallon { get { throw null; } }
        public static Azure.AI.Language.Text.WeightUnit Grain { get { throw null; } }
        public static Azure.AI.Language.Text.WeightUnit Gram { get { throw null; } }
        public static Azure.AI.Language.Text.WeightUnit Kilogram { get { throw null; } }
        public static Azure.AI.Language.Text.WeightUnit LongTonBritish { get { throw null; } }
        public static Azure.AI.Language.Text.WeightUnit MetricTon { get { throw null; } }
        public static Azure.AI.Language.Text.WeightUnit Milligram { get { throw null; } }
        public static Azure.AI.Language.Text.WeightUnit Ounce { get { throw null; } }
        public static Azure.AI.Language.Text.WeightUnit PennyWeight { get { throw null; } }
        public static Azure.AI.Language.Text.WeightUnit Pound { get { throw null; } }
        public static Azure.AI.Language.Text.WeightUnit ShortHundredWeightUs { get { throw null; } }
        public static Azure.AI.Language.Text.WeightUnit ShortTonUs { get { throw null; } }
        public static Azure.AI.Language.Text.WeightUnit Stone { get { throw null; } }
        public static Azure.AI.Language.Text.WeightUnit Ton { get { throw null; } }
        public static Azure.AI.Language.Text.WeightUnit Unspecified { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.WeightUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.WeightUnit left, Azure.AI.Language.Text.WeightUnit right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.WeightUnit (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.WeightUnit left, Azure.AI.Language.Text.WeightUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
}
