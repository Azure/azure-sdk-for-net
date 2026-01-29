namespace Azure.AI.ContentUnderstanding
{
    public partial class AnalyzeInput : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.AnalyzeInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.AnalyzeInput>
    {
        public AnalyzeInput() { }
        public System.BinaryData Data { get { throw null; } set { } }
        public string InputRange { get { throw null; } set { } }
        public string MimeType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Uri Url { get { throw null; } set { } }
        protected virtual Azure.AI.ContentUnderstanding.AnalyzeInput JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentUnderstanding.AnalyzeInput PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.AnalyzeInput System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.AnalyzeInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.AnalyzeInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.AnalyzeInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.AnalyzeInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.AnalyzeInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.AnalyzeInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.AnalyzeResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.AnalyzeResult>
    {
        internal AnalyzeResult() { }
        public string AnalyzerId { get { throw null; } }
        public string ApiVersion { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ContentUnderstanding.MediaContent> Contents { get { throw null; } }
        public System.DateTimeOffset? CreatedAt { get { throw null; } }
        public string StringEncoding { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual Azure.AI.ContentUnderstanding.AnalyzeResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentUnderstanding.AnalyzeResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.AnalyzeResult System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.AnalyzeResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.AnalyzeResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.AnalyzeResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.AnalyzeResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.AnalyzeResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.AnalyzeResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnnotationFormat : System.IEquatable<Azure.AI.ContentUnderstanding.AnnotationFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnnotationFormat(string value) { throw null; }
        public static Azure.AI.ContentUnderstanding.AnnotationFormat Markdown { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.AnnotationFormat None { get { throw null; } }
        public bool Equals(Azure.AI.ContentUnderstanding.AnnotationFormat other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.ContentUnderstanding.AnnotationFormat left, Azure.AI.ContentUnderstanding.AnnotationFormat right) { throw null; }
        public static implicit operator Azure.AI.ContentUnderstanding.AnnotationFormat (string value) { throw null; }
        public static implicit operator Azure.AI.ContentUnderstanding.AnnotationFormat? (string value) { throw null; }
        public static bool operator !=(Azure.AI.ContentUnderstanding.AnnotationFormat left, Azure.AI.ContentUnderstanding.AnnotationFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArrayField : Azure.AI.ContentUnderstanding.ContentField, System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.ArrayField>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ArrayField>
    {
        internal ArrayField() { }
        public int Count { get { throw null; } }
        public Azure.AI.ContentUnderstanding.ContentField this[int index] { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ContentUnderstanding.ContentField> ValueArray { get { throw null; } }
        protected override Azure.AI.ContentUnderstanding.ContentField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.ContentUnderstanding.ContentField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.ArrayField System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.ArrayField>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.ArrayField>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.ArrayField System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ArrayField>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ArrayField>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ArrayField>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AudioVisualContent : Azure.AI.ContentUnderstanding.MediaContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.AudioVisualContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.AudioVisualContent>
    {
        internal AudioVisualContent() { }
        public System.Collections.Generic.IList<long> CameraShotTimesMs { get { throw null; } }
        public long EndTimeMs { get { throw null; } }
        public int? Height { get { throw null; } }
        public System.Collections.Generic.IList<long> KeyFrameTimesMs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ContentUnderstanding.AudioVisualContentSegment> Segments { get { throw null; } }
        public long StartTimeMs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ContentUnderstanding.TranscriptPhrase> TranscriptPhrases { get { throw null; } }
        public int? Width { get { throw null; } }
        protected override Azure.AI.ContentUnderstanding.MediaContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.ContentUnderstanding.MediaContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.AudioVisualContent System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.AudioVisualContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.AudioVisualContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.AudioVisualContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.AudioVisualContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.AudioVisualContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.AudioVisualContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AudioVisualContentSegment : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.AudioVisualContentSegment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.AudioVisualContentSegment>
    {
        internal AudioVisualContentSegment() { }
        public string Category { get { throw null; } }
        public long EndTimeMs { get { throw null; } }
        public string SegmentId { get { throw null; } }
        public Azure.AI.ContentUnderstanding.ContentSpan Span { get { throw null; } }
        public long StartTimeMs { get { throw null; } }
        protected virtual Azure.AI.ContentUnderstanding.AudioVisualContentSegment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentUnderstanding.AudioVisualContentSegment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.AudioVisualContentSegment System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.AudioVisualContentSegment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.AudioVisualContentSegment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.AudioVisualContentSegment System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.AudioVisualContentSegment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.AudioVisualContentSegment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.AudioVisualContentSegment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureAIContentUnderstandingContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAIContentUnderstandingContext() { }
        public static Azure.AI.ContentUnderstanding.AzureAIContentUnderstandingContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class BooleanField : Azure.AI.ContentUnderstanding.ContentField, System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.BooleanField>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.BooleanField>
    {
        internal BooleanField() { }
        public bool? ValueBoolean { get { throw null; } }
        protected override Azure.AI.ContentUnderstanding.ContentField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.ContentUnderstanding.ContentField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.BooleanField System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.BooleanField>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.BooleanField>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.BooleanField System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.BooleanField>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.BooleanField>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.BooleanField>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChartFormat : System.IEquatable<Azure.AI.ContentUnderstanding.ChartFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChartFormat(string value) { throw null; }
        public static Azure.AI.ContentUnderstanding.ChartFormat ChartJs { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.ChartFormat Markdown { get { throw null; } }
        public bool Equals(Azure.AI.ContentUnderstanding.ChartFormat other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.ContentUnderstanding.ChartFormat left, Azure.AI.ContentUnderstanding.ChartFormat right) { throw null; }
        public static implicit operator Azure.AI.ContentUnderstanding.ChartFormat (string value) { throw null; }
        public static implicit operator Azure.AI.ContentUnderstanding.ChartFormat? (string value) { throw null; }
        public static bool operator !=(Azure.AI.ContentUnderstanding.ChartFormat left, Azure.AI.ContentUnderstanding.ChartFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContentAnalyzer : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.ContentAnalyzer>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ContentAnalyzer>
    {
        public ContentAnalyzer() { }
        public string AnalyzerId { get { throw null; } }
        public string BaseAnalyzerId { get { throw null; } set { } }
        public Azure.AI.ContentUnderstanding.ContentAnalyzerConfig Config { get { throw null; } set { } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? DynamicFieldSchema { get { throw null; } set { } }
        public Azure.AI.ContentUnderstanding.ContentFieldSchema FieldSchema { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.ContentUnderstanding.KnowledgeSource> KnowledgeSources { get { throw null; } }
        public System.DateTimeOffset LastModifiedAt { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Models { get { throw null; } }
        public Azure.AI.ContentUnderstanding.ProcessingLocation? ProcessingLocation { get { throw null; } set { } }
        public Azure.AI.ContentUnderstanding.ContentAnalyzerStatus Status { get { throw null; } }
        public Azure.AI.ContentUnderstanding.SupportedModels SupportedModels { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual Azure.AI.ContentUnderstanding.ContentAnalyzer JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.ContentUnderstanding.ContentAnalyzer (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.AI.ContentUnderstanding.ContentAnalyzer contentAnalyzer) { throw null; }
        protected virtual Azure.AI.ContentUnderstanding.ContentAnalyzer PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.ContentAnalyzer System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.ContentAnalyzer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.ContentAnalyzer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.ContentAnalyzer System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ContentAnalyzer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ContentAnalyzer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ContentAnalyzer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentAnalyzerConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.ContentAnalyzerConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ContentAnalyzerConfig>
    {
        public ContentAnalyzerConfig() { }
        public Azure.AI.ContentUnderstanding.AnnotationFormat? AnnotationFormat { get { throw null; } set { } }
        public Azure.AI.ContentUnderstanding.ChartFormat? ChartFormat { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.ContentUnderstanding.ContentCategoryDefinition> ContentCategories { get { throw null; } }
        public bool? DisableFaceBlurring { get { throw null; } set { } }
        public bool? EnableFigureAnalysis { get { throw null; } set { } }
        public bool? EnableFigureDescription { get { throw null; } set { } }
        public bool? EnableFormula { get { throw null; } set { } }
        public bool? EnableLayout { get { throw null; } set { } }
        public bool? EnableOcr { get { throw null; } set { } }
        public bool? EnableSegment { get { throw null; } set { } }
        public bool? EstimateFieldSourceAndConfidence { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Locales { get { throw null; } }
        public bool? OmitContent { get { throw null; } set { } }
        public bool? ReturnDetails { get { throw null; } set { } }
        public bool? SegmentPerPage { get { throw null; } set { } }
        public Azure.AI.ContentUnderstanding.TableFormat? TableFormat { get { throw null; } set { } }
        protected virtual Azure.AI.ContentUnderstanding.ContentAnalyzerConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentUnderstanding.ContentAnalyzerConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.ContentAnalyzerConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.ContentAnalyzerConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.ContentAnalyzerConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.ContentAnalyzerConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ContentAnalyzerConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ContentAnalyzerConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ContentAnalyzerConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentAnalyzerStatus : System.IEquatable<Azure.AI.ContentUnderstanding.ContentAnalyzerStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentAnalyzerStatus(string value) { throw null; }
        public static Azure.AI.ContentUnderstanding.ContentAnalyzerStatus Creating { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.ContentAnalyzerStatus Deleting { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.ContentAnalyzerStatus Failed { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.ContentAnalyzerStatus Ready { get { throw null; } }
        public bool Equals(Azure.AI.ContentUnderstanding.ContentAnalyzerStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.ContentUnderstanding.ContentAnalyzerStatus left, Azure.AI.ContentUnderstanding.ContentAnalyzerStatus right) { throw null; }
        public static implicit operator Azure.AI.ContentUnderstanding.ContentAnalyzerStatus (string value) { throw null; }
        public static implicit operator Azure.AI.ContentUnderstanding.ContentAnalyzerStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.ContentUnderstanding.ContentAnalyzerStatus left, Azure.AI.ContentUnderstanding.ContentAnalyzerStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContentCategoryDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.ContentCategoryDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ContentCategoryDefinition>
    {
        public ContentCategoryDefinition() { }
        public Azure.AI.ContentUnderstanding.ContentAnalyzer Analyzer { get { throw null; } set { } }
        public string AnalyzerId { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        protected virtual Azure.AI.ContentUnderstanding.ContentCategoryDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentUnderstanding.ContentCategoryDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.ContentCategoryDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.ContentCategoryDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.ContentCategoryDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.ContentCategoryDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ContentCategoryDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ContentCategoryDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ContentCategoryDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ContentField : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.ContentField>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ContentField>
    {
        internal ContentField() { }
        public float? Confidence { get { throw null; } }
        public string Source { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ContentUnderstanding.ContentSpan> Spans { get { throw null; } }
        public object Value { get { throw null; } }
        protected virtual Azure.AI.ContentUnderstanding.ContentField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentUnderstanding.ContentField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.ContentField System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.ContentField>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.ContentField>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.ContentField System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ContentField>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ContentField>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ContentField>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentFieldDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.ContentFieldDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ContentFieldDefinition>
    {
        public ContentFieldDefinition() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Enum { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> EnumDescriptions { get { throw null; } }
        public bool? EstimateSourceAndConfidence { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Examples { get { throw null; } }
        public Azure.AI.ContentUnderstanding.ContentFieldDefinition ItemDefinition { get { throw null; } set { } }
        public Azure.AI.ContentUnderstanding.GenerationMethod? Method { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.ContentUnderstanding.ContentFieldDefinition> Properties { get { throw null; } }
        public string Ref { get { throw null; } set { } }
        public Azure.AI.ContentUnderstanding.ContentFieldType? Type { get { throw null; } set { } }
        protected virtual Azure.AI.ContentUnderstanding.ContentFieldDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentUnderstanding.ContentFieldDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.ContentFieldDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.ContentFieldDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.ContentFieldDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.ContentFieldDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ContentFieldDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ContentFieldDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ContentFieldDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ContentFieldDictionaryExtensions
    {
        public static Azure.AI.ContentUnderstanding.ContentField GetFieldOrDefault(this System.Collections.Generic.IDictionary<string, Azure.AI.ContentUnderstanding.ContentField> fields, string fieldName) { throw null; }
    }
    public partial class ContentFieldSchema : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.ContentFieldSchema>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ContentFieldSchema>
    {
        public ContentFieldSchema(System.Collections.Generic.IDictionary<string, Azure.AI.ContentUnderstanding.ContentFieldDefinition> fields) { }
        public System.Collections.Generic.IDictionary<string, Azure.AI.ContentUnderstanding.ContentFieldDefinition> Definitions { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.ContentUnderstanding.ContentFieldDefinition> Fields { get { throw null; } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.AI.ContentUnderstanding.ContentFieldSchema JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentUnderstanding.ContentFieldSchema PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.ContentFieldSchema System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.ContentFieldSchema>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.ContentFieldSchema>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.ContentFieldSchema System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ContentFieldSchema>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ContentFieldSchema>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ContentFieldSchema>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentFieldType : System.IEquatable<Azure.AI.ContentUnderstanding.ContentFieldType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentFieldType(string value) { throw null; }
        public static Azure.AI.ContentUnderstanding.ContentFieldType Array { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.ContentFieldType Boolean { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.ContentFieldType Date { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.ContentFieldType Integer { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.ContentFieldType Json { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.ContentFieldType Number { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.ContentFieldType Object { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.ContentFieldType String { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.ContentFieldType Time { get { throw null; } }
        public bool Equals(Azure.AI.ContentUnderstanding.ContentFieldType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.ContentUnderstanding.ContentFieldType left, Azure.AI.ContentUnderstanding.ContentFieldType right) { throw null; }
        public static implicit operator Azure.AI.ContentUnderstanding.ContentFieldType (string value) { throw null; }
        public static implicit operator Azure.AI.ContentUnderstanding.ContentFieldType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.ContentUnderstanding.ContentFieldType left, Azure.AI.ContentUnderstanding.ContentFieldType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContentSpan : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.ContentSpan>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ContentSpan>
    {
        internal ContentSpan() { }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        protected virtual Azure.AI.ContentUnderstanding.ContentSpan JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentUnderstanding.ContentSpan PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.ContentSpan System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.ContentSpan>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.ContentSpan>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.ContentSpan System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ContentSpan>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ContentSpan>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ContentSpan>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentUnderstandingClient
    {
        protected ContentUnderstandingClient() { }
        public ContentUnderstandingClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public ContentUnderstandingClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.ContentUnderstanding.ContentUnderstandingClientOptions options) { }
        public ContentUnderstandingClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ContentUnderstandingClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.ContentUnderstanding.ContentUnderstandingClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> Analyze(Azure.WaitUntil waitUntil, string analyzerId, Azure.Core.RequestContent content, string stringEncoding = null, string processingLocation = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.AI.ContentUnderstanding.AnalyzeResult> Analyze(Azure.WaitUntil waitUntil, string analyzerId, System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.AnalyzeInput>? inputs = null, System.Collections.Generic.IDictionary<string, string>? modelDeployments = null, Azure.AI.ContentUnderstanding.ProcessingLocation? processingLocation = default(Azure.AI.ContentUnderstanding.ProcessingLocation?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> AnalyzeAsync(Azure.WaitUntil waitUntil, string analyzerId, Azure.Core.RequestContent content, string stringEncoding = null, string processingLocation = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.ContentUnderstanding.AnalyzeResult>> AnalyzeAsync(Azure.WaitUntil waitUntil, string analyzerId, System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.AnalyzeInput>? inputs = null, System.Collections.Generic.IDictionary<string, string>? modelDeployments = null, Azure.AI.ContentUnderstanding.ProcessingLocation? processingLocation = default(Azure.AI.ContentUnderstanding.ProcessingLocation?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> AnalyzeBinary(Azure.WaitUntil waitUntil, string analyzerId, Azure.Core.RequestContent content, string contentType = null, string stringEncoding = null, string processingLocation = null, string inputRange = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.AI.ContentUnderstanding.AnalyzeResult> AnalyzeBinary(Azure.WaitUntil waitUntil, string analyzerId, System.BinaryData binaryInput, string? contentType = null, Azure.AI.ContentUnderstanding.ProcessingLocation? processingLocation = default(Azure.AI.ContentUnderstanding.ProcessingLocation?), string? inputRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> AnalyzeBinaryAsync(Azure.WaitUntil waitUntil, string analyzerId, Azure.Core.RequestContent content, string contentType = null, string stringEncoding = null, string processingLocation = null, string inputRange = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.ContentUnderstanding.AnalyzeResult>> AnalyzeBinaryAsync(Azure.WaitUntil waitUntil, string analyzerId, System.BinaryData binaryInput, string? contentType = null, Azure.AI.ContentUnderstanding.ProcessingLocation? processingLocation = default(Azure.AI.ContentUnderstanding.ProcessingLocation?), string? inputRange = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> CopyAnalyzer(Azure.WaitUntil waitUntil, string analyzerId, Azure.Core.RequestContent content, bool? allowReplace = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.AI.ContentUnderstanding.ContentAnalyzer> CopyAnalyzer(Azure.WaitUntil waitUntil, string analyzerId, string sourceAnalyzerId, string sourceAzureResourceId = null, string sourceRegion = null, bool? allowReplace = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CopyAnalyzerAsync(Azure.WaitUntil waitUntil, string analyzerId, Azure.Core.RequestContent content, bool? allowReplace = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.ContentUnderstanding.ContentAnalyzer>> CopyAnalyzerAsync(Azure.WaitUntil waitUntil, string analyzerId, string sourceAnalyzerId, string sourceAzureResourceId = null, string sourceRegion = null, bool? allowReplace = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<Azure.AI.ContentUnderstanding.ContentAnalyzer> CreateAnalyzer(Azure.WaitUntil waitUntil, string analyzerId, Azure.AI.ContentUnderstanding.ContentAnalyzer resource, bool? allowReplace = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> CreateAnalyzer(Azure.WaitUntil waitUntil, string analyzerId, Azure.Core.RequestContent content, bool? allowReplace = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.ContentUnderstanding.ContentAnalyzer>> CreateAnalyzerAsync(Azure.WaitUntil waitUntil, string analyzerId, Azure.AI.ContentUnderstanding.ContentAnalyzer resource, bool? allowReplace = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CreateAnalyzerAsync(Azure.WaitUntil waitUntil, string analyzerId, Azure.Core.RequestContent content, bool? allowReplace = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteAnalyzer(string analyzerId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteAnalyzer(string analyzerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAnalyzerAsync(string analyzerId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAnalyzerAsync(string analyzerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteResult(string operationId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteResult(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteResultAsync(string operationId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteResultAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetAnalyzer(string analyzerId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.ContentUnderstanding.ContentAnalyzer> GetAnalyzer(string analyzerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAnalyzerAsync(string analyzerId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.ContentUnderstanding.ContentAnalyzer>> GetAnalyzerAsync(string analyzerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAnalyzers(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.ContentUnderstanding.ContentAnalyzer> GetAnalyzers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAnalyzersAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.ContentUnderstanding.ContentAnalyzer> GetAnalyzersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDefaults(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.ContentUnderstanding.ContentUnderstandingDefaults> GetDefaults(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDefaultsAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.ContentUnderstanding.ContentUnderstandingDefaults>> GetDefaultsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetResultFile(string operationId, string path, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetResultFile(string operationId, string path, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetResultFileAsync(string operationId, string path, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetResultFileAsync(string operationId, string path, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GrantCopyAuthorization(string analyzerId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.ContentUnderstanding.CopyAuthorization> GrantCopyAuthorization(string analyzerId, string targetAzureResourceId, string targetRegion = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GrantCopyAuthorizationAsync(string analyzerId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.ContentUnderstanding.CopyAuthorization>> GrantCopyAuthorizationAsync(string analyzerId, string targetAzureResourceId, string targetRegion = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateAnalyzer(string analyzerId, Azure.AI.ContentUnderstanding.ContentAnalyzer resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateAnalyzer(string analyzerId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAnalyzerAsync(string analyzerId, Azure.AI.ContentUnderstanding.ContentAnalyzer resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAnalyzerAsync(string analyzerId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpdateDefaults(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.ContentUnderstanding.ContentUnderstandingDefaults> UpdateDefaults(System.Collections.Generic.IDictionary<string, string> modelDeployments, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateDefaultsAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.ContentUnderstanding.ContentUnderstandingDefaults>> UpdateDefaultsAsync(System.Collections.Generic.IDictionary<string, string> modelDeployments, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContentUnderstandingClientOptions : Azure.Core.ClientOptions
    {
        public ContentUnderstandingClientOptions(Azure.AI.ContentUnderstanding.ContentUnderstandingClientOptions.ServiceVersion version = Azure.AI.ContentUnderstanding.ContentUnderstandingClientOptions.ServiceVersion.V2025_11_01) { }
        public enum ServiceVersion
        {
            V2025_11_01 = 1,
        }
    }
    public partial class ContentUnderstandingDefaults : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.ContentUnderstandingDefaults>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ContentUnderstandingDefaults>
    {
        internal ContentUnderstandingDefaults() { }
        public System.Collections.Generic.IDictionary<string, string> ModelDeployments { get { throw null; } }
        protected virtual Azure.AI.ContentUnderstanding.ContentUnderstandingDefaults JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.ContentUnderstanding.ContentUnderstandingDefaults (Azure.Response response) { throw null; }
        protected virtual Azure.AI.ContentUnderstanding.ContentUnderstandingDefaults PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.ContentUnderstandingDefaults System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.ContentUnderstandingDefaults>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.ContentUnderstandingDefaults>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.ContentUnderstandingDefaults System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ContentUnderstandingDefaults>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ContentUnderstandingDefaults>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ContentUnderstandingDefaults>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ContentUnderstandingModelFactory
    {
        public static Azure.AI.ContentUnderstanding.AnalyzeInput AnalyzeInput(System.Uri url = null, System.BinaryData data = null, string name = null, string mimeType = null, string inputRange = null) { throw null; }
        public static Azure.AI.ContentUnderstanding.AnalyzeResult AnalyzeResult(string analyzerId = null, string apiVersion = null, System.DateTimeOffset? createdAt = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, string stringEncoding = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.MediaContent> contents = null) { throw null; }
        public static Azure.AI.ContentUnderstanding.ArrayField ArrayField(System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.ContentSpan> spans = null, float? confidence = default(float?), string source = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.ContentField> valueArray = null) { throw null; }
        public static Azure.AI.ContentUnderstanding.AudioVisualContent AudioVisualContent(string mimeType = null, string analyzerId = null, string category = null, string path = null, string markdown = null, System.Collections.Generic.IDictionary<string, Azure.AI.ContentUnderstanding.ContentField> fields = null, long startTimeMs = (long)0, long endTimeMs = (long)0, int? width = default(int?), int? height = default(int?), System.Collections.Generic.IEnumerable<long> cameraShotTimesMs = null, System.Collections.Generic.IEnumerable<long> keyFrameTimesMs = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.TranscriptPhrase> transcriptPhrases = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.AudioVisualContentSegment> segments = null) { throw null; }
        public static Azure.AI.ContentUnderstanding.AudioVisualContentSegment AudioVisualContentSegment(string segmentId = null, string category = null, Azure.AI.ContentUnderstanding.ContentSpan span = null, long startTimeMs = (long)0, long endTimeMs = (long)0) { throw null; }
        public static Azure.AI.ContentUnderstanding.BooleanField BooleanField(System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.ContentSpan> spans = null, float? confidence = default(float?), string source = null, bool? valueBoolean = default(bool?)) { throw null; }
        public static Azure.AI.ContentUnderstanding.ContentAnalyzer ContentAnalyzer(string analyzerId = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.AI.ContentUnderstanding.ContentAnalyzerStatus status = default(Azure.AI.ContentUnderstanding.ContentAnalyzerStatus), System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset lastModifiedAt = default(System.DateTimeOffset), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, string baseAnalyzerId = null, Azure.AI.ContentUnderstanding.ContentAnalyzerConfig config = null, Azure.AI.ContentUnderstanding.ContentFieldSchema fieldSchema = null, bool? dynamicFieldSchema = default(bool?), Azure.AI.ContentUnderstanding.ProcessingLocation? processingLocation = default(Azure.AI.ContentUnderstanding.ProcessingLocation?), System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.KnowledgeSource> knowledgeSources = null, System.Collections.Generic.IDictionary<string, string> models = null, Azure.AI.ContentUnderstanding.SupportedModels supportedModels = null) { throw null; }
        public static Azure.AI.ContentUnderstanding.ContentAnalyzerConfig ContentAnalyzerConfig(bool? returnDetails = default(bool?), System.Collections.Generic.IEnumerable<string> locales = null, bool? enableOcr = default(bool?), bool? enableLayout = default(bool?), bool? enableFigureDescription = default(bool?), bool? enableFigureAnalysis = default(bool?), bool? enableFormula = default(bool?), Azure.AI.ContentUnderstanding.TableFormat? tableFormat = default(Azure.AI.ContentUnderstanding.TableFormat?), Azure.AI.ContentUnderstanding.ChartFormat? chartFormat = default(Azure.AI.ContentUnderstanding.ChartFormat?), Azure.AI.ContentUnderstanding.AnnotationFormat? annotationFormat = default(Azure.AI.ContentUnderstanding.AnnotationFormat?), bool? disableFaceBlurring = default(bool?), bool? estimateFieldSourceAndConfidence = default(bool?), System.Collections.Generic.IDictionary<string, Azure.AI.ContentUnderstanding.ContentCategoryDefinition> contentCategories = null, bool? enableSegment = default(bool?), bool? segmentPerPage = default(bool?), bool? omitContent = default(bool?)) { throw null; }
        public static Azure.AI.ContentUnderstanding.ContentCategoryDefinition ContentCategoryDefinition(string description = null, string analyzerId = null, Azure.AI.ContentUnderstanding.ContentAnalyzer analyzer = null) { throw null; }
        public static Azure.AI.ContentUnderstanding.ContentField ContentField(string type = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.ContentSpan> spans = null, float? confidence = default(float?), string source = null) { throw null; }
        public static Azure.AI.ContentUnderstanding.ContentFieldDefinition ContentFieldDefinition(Azure.AI.ContentUnderstanding.GenerationMethod? method = default(Azure.AI.ContentUnderstanding.GenerationMethod?), Azure.AI.ContentUnderstanding.ContentFieldType? type = default(Azure.AI.ContentUnderstanding.ContentFieldType?), string description = null, Azure.AI.ContentUnderstanding.ContentFieldDefinition itemDefinition = null, System.Collections.Generic.IDictionary<string, Azure.AI.ContentUnderstanding.ContentFieldDefinition> properties = null, System.Collections.Generic.IEnumerable<string> examples = null, System.Collections.Generic.IEnumerable<string> @enum = null, System.Collections.Generic.IDictionary<string, string> enumDescriptions = null, string @ref = null, bool? estimateSourceAndConfidence = default(bool?)) { throw null; }
        public static Azure.AI.ContentUnderstanding.ContentFieldSchema ContentFieldSchema(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.ContentUnderstanding.ContentFieldDefinition> fields = null, System.Collections.Generic.IDictionary<string, Azure.AI.ContentUnderstanding.ContentFieldDefinition> definitions = null) { throw null; }
        public static Azure.AI.ContentUnderstanding.ContentSpan ContentSpan(int offset = 0, int length = 0) { throw null; }
        public static Azure.AI.ContentUnderstanding.ContentUnderstandingDefaults ContentUnderstandingDefaults(System.Collections.Generic.IDictionary<string, string> modelDeployments = null) { throw null; }
        public static Azure.AI.ContentUnderstanding.CopyAuthorization CopyAuthorization(string source = null, string targetAzureResourceId = null, System.DateTimeOffset expiresAt = default(System.DateTimeOffset)) { throw null; }
        public static Azure.AI.ContentUnderstanding.DateField DateField(System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.ContentSpan> spans = null, float? confidence = default(float?), string source = null, System.DateTimeOffset? valueDate = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.ContentUnderstanding.DocumentAnnotation DocumentAnnotation(string id = null, Azure.AI.ContentUnderstanding.DocumentAnnotationKind kind = default(Azure.AI.ContentUnderstanding.DocumentAnnotationKind), System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.ContentSpan> spans = null, string source = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.DocumentAnnotationComment> comments = null, string author = null, System.DateTimeOffset? createdAt = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedAt = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> tags = null) { throw null; }
        public static Azure.AI.ContentUnderstanding.DocumentAnnotationComment DocumentAnnotationComment(string message = null, string author = null, System.DateTimeOffset? createdAt = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedAt = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> tags = null) { throw null; }
        public static Azure.AI.ContentUnderstanding.DocumentBarcode DocumentBarcode(Azure.AI.ContentUnderstanding.DocumentBarcodeKind kind = default(Azure.AI.ContentUnderstanding.DocumentBarcodeKind), string value = null, string source = null, Azure.AI.ContentUnderstanding.ContentSpan span = null, float? confidence = default(float?)) { throw null; }
        public static Azure.AI.ContentUnderstanding.DocumentCaption DocumentCaption(string content = null, string source = null, Azure.AI.ContentUnderstanding.ContentSpan span = null, System.Collections.Generic.IEnumerable<string> elements = null) { throw null; }
        public static Azure.AI.ContentUnderstanding.DocumentChartFigure DocumentChartFigure(string id = null, string source = null, Azure.AI.ContentUnderstanding.ContentSpan span = null, System.Collections.Generic.IEnumerable<string> elements = null, Azure.AI.ContentUnderstanding.DocumentCaption caption = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.DocumentFootnote> footnotes = null, string description = null, Azure.AI.ContentUnderstanding.SemanticRole? role = default(Azure.AI.ContentUnderstanding.SemanticRole?), System.Collections.Generic.IDictionary<string, System.BinaryData> content = null) { throw null; }
        public static Azure.AI.ContentUnderstanding.DocumentContent DocumentContent(string mimeType = null, string analyzerId = null, string category = null, string path = null, string markdown = null, System.Collections.Generic.IDictionary<string, Azure.AI.ContentUnderstanding.ContentField> fields = null, int startPageNumber = 0, int endPageNumber = 0, Azure.AI.ContentUnderstanding.LengthUnit? unit = default(Azure.AI.ContentUnderstanding.LengthUnit?), System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.DocumentPage> pages = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.DocumentParagraph> paragraphs = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.DocumentSection> sections = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.DocumentTable> tables = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.DocumentFigure> figures = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.DocumentAnnotation> annotations = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.DocumentHyperlink> hyperlinks = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.DocumentContentSegment> segments = null) { throw null; }
        public static Azure.AI.ContentUnderstanding.DocumentContentSegment DocumentContentSegment(string segmentId = null, string category = null, Azure.AI.ContentUnderstanding.ContentSpan span = null, int startPageNumber = 0, int endPageNumber = 0) { throw null; }
        public static Azure.AI.ContentUnderstanding.DocumentFigure DocumentFigure(string kind = null, string id = null, string source = null, Azure.AI.ContentUnderstanding.ContentSpan span = null, System.Collections.Generic.IEnumerable<string> elements = null, Azure.AI.ContentUnderstanding.DocumentCaption caption = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.DocumentFootnote> footnotes = null, string description = null, Azure.AI.ContentUnderstanding.SemanticRole? role = default(Azure.AI.ContentUnderstanding.SemanticRole?)) { throw null; }
        public static Azure.AI.ContentUnderstanding.DocumentFootnote DocumentFootnote(string content = null, string source = null, Azure.AI.ContentUnderstanding.ContentSpan span = null, System.Collections.Generic.IEnumerable<string> elements = null) { throw null; }
        public static Azure.AI.ContentUnderstanding.DocumentFormula DocumentFormula(Azure.AI.ContentUnderstanding.DocumentFormulaKind kind = default(Azure.AI.ContentUnderstanding.DocumentFormulaKind), string value = null, string source = null, Azure.AI.ContentUnderstanding.ContentSpan span = null, float? confidence = default(float?)) { throw null; }
        public static Azure.AI.ContentUnderstanding.DocumentHyperlink DocumentHyperlink(string content = null, string url = null, Azure.AI.ContentUnderstanding.ContentSpan span = null, string source = null) { throw null; }
        public static Azure.AI.ContentUnderstanding.DocumentLine DocumentLine(string content = null, string source = null, Azure.AI.ContentUnderstanding.ContentSpan span = null) { throw null; }
        public static Azure.AI.ContentUnderstanding.DocumentMermaidFigure DocumentMermaidFigure(string id = null, string source = null, Azure.AI.ContentUnderstanding.ContentSpan span = null, System.Collections.Generic.IEnumerable<string> elements = null, Azure.AI.ContentUnderstanding.DocumentCaption caption = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.DocumentFootnote> footnotes = null, string description = null, Azure.AI.ContentUnderstanding.SemanticRole? role = default(Azure.AI.ContentUnderstanding.SemanticRole?), string content = null) { throw null; }
        public static Azure.AI.ContentUnderstanding.DocumentPage DocumentPage(int pageNumber = 0, float? width = default(float?), float? height = default(float?), System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.ContentSpan> spans = null, float? angle = default(float?), System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.DocumentWord> words = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.DocumentLine> lines = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.DocumentBarcode> barcodes = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.DocumentFormula> formulas = null) { throw null; }
        public static Azure.AI.ContentUnderstanding.DocumentParagraph DocumentParagraph(Azure.AI.ContentUnderstanding.SemanticRole? role = default(Azure.AI.ContentUnderstanding.SemanticRole?), string content = null, string source = null, Azure.AI.ContentUnderstanding.ContentSpan span = null) { throw null; }
        public static Azure.AI.ContentUnderstanding.DocumentSection DocumentSection(Azure.AI.ContentUnderstanding.ContentSpan span = null, System.Collections.Generic.IEnumerable<string> elements = null) { throw null; }
        public static Azure.AI.ContentUnderstanding.DocumentTable DocumentTable(int rowCount = 0, int columnCount = 0, System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.DocumentTableCell> cells = null, string source = null, Azure.AI.ContentUnderstanding.ContentSpan span = null, Azure.AI.ContentUnderstanding.DocumentCaption caption = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.DocumentFootnote> footnotes = null, Azure.AI.ContentUnderstanding.SemanticRole? role = default(Azure.AI.ContentUnderstanding.SemanticRole?)) { throw null; }
        public static Azure.AI.ContentUnderstanding.DocumentTableCell DocumentTableCell(Azure.AI.ContentUnderstanding.DocumentTableCellKind? kind = default(Azure.AI.ContentUnderstanding.DocumentTableCellKind?), int rowIndex = 0, int columnIndex = 0, int? rowSpan = default(int?), int? columnSpan = default(int?), string content = null, string source = null, Azure.AI.ContentUnderstanding.ContentSpan span = null, System.Collections.Generic.IEnumerable<string> elements = null) { throw null; }
        public static Azure.AI.ContentUnderstanding.DocumentWord DocumentWord(string content = null, string source = null, Azure.AI.ContentUnderstanding.ContentSpan span = null, float? confidence = default(float?)) { throw null; }
        public static Azure.AI.ContentUnderstanding.IntegerField IntegerField(System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.ContentSpan> spans = null, float? confidence = default(float?), string source = null, long? valueInteger = default(long?)) { throw null; }
        public static Azure.AI.ContentUnderstanding.JsonField JsonField(System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.ContentSpan> spans = null, float? confidence = default(float?), string source = null, System.BinaryData valueJson = null) { throw null; }
        public static Azure.AI.ContentUnderstanding.KnowledgeSource KnowledgeSource(string kind = null) { throw null; }
        public static Azure.AI.ContentUnderstanding.LabeledDataKnowledgeSource LabeledDataKnowledgeSource(System.Uri containerUrl = null, string prefix = null, string fileListPath = null) { throw null; }
        public static Azure.AI.ContentUnderstanding.MediaContent MediaContent(string kind = null, string mimeType = null, string analyzerId = null, string category = null, string path = null, string markdown = null, System.Collections.Generic.IDictionary<string, Azure.AI.ContentUnderstanding.ContentField> fields = null) { throw null; }
        public static Azure.AI.ContentUnderstanding.NumberField NumberField(System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.ContentSpan> spans = null, float? confidence = default(float?), string source = null, double? valueNumber = default(double?)) { throw null; }
        public static Azure.AI.ContentUnderstanding.ObjectField ObjectField(System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.ContentSpan> spans = null, float? confidence = default(float?), string source = null, System.Collections.Generic.IDictionary<string, Azure.AI.ContentUnderstanding.ContentField> valueObject = null) { throw null; }
        public static Azure.AI.ContentUnderstanding.StringField StringField(System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.ContentSpan> spans = null, float? confidence = default(float?), string source = null, string valueString = null) { throw null; }
        public static Azure.AI.ContentUnderstanding.SupportedModels SupportedModels(System.Collections.Generic.IEnumerable<string> completion = null, System.Collections.Generic.IEnumerable<string> embedding = null) { throw null; }
        public static Azure.AI.ContentUnderstanding.TimeField TimeField(System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.ContentSpan> spans = null, float? confidence = default(float?), string source = null, System.TimeSpan? valueTime = default(System.TimeSpan?)) { throw null; }
        public static Azure.AI.ContentUnderstanding.TranscriptPhrase TranscriptPhrase(string speaker = null, long startTimeMs = (long)0, long endTimeMs = (long)0, string locale = null, string text = null, float? confidence = default(float?), Azure.AI.ContentUnderstanding.ContentSpan span = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentUnderstanding.TranscriptWord> words = null) { throw null; }
        public static Azure.AI.ContentUnderstanding.TranscriptWord TranscriptWord(long startTimeMs = (long)0, long endTimeMs = (long)0, string text = null, Azure.AI.ContentUnderstanding.ContentSpan span = null) { throw null; }
    }
    public partial class CopyAuthorization : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.CopyAuthorization>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.CopyAuthorization>
    {
        internal CopyAuthorization() { }
        public System.DateTimeOffset ExpiresAt { get { throw null; } }
        public string Source { get { throw null; } }
        public string TargetAzureResourceId { get { throw null; } }
        protected virtual Azure.AI.ContentUnderstanding.CopyAuthorization JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.ContentUnderstanding.CopyAuthorization (Azure.Response response) { throw null; }
        protected virtual Azure.AI.ContentUnderstanding.CopyAuthorization PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.CopyAuthorization System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.CopyAuthorization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.CopyAuthorization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.CopyAuthorization System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.CopyAuthorization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.CopyAuthorization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.CopyAuthorization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DateField : Azure.AI.ContentUnderstanding.ContentField, System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DateField>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DateField>
    {
        internal DateField() { }
        public System.DateTimeOffset? ValueDate { get { throw null; } }
        protected override Azure.AI.ContentUnderstanding.ContentField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.ContentUnderstanding.ContentField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.DateField System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DateField>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DateField>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.DateField System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DateField>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DateField>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DateField>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentAnnotation : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentAnnotation>
    {
        internal DocumentAnnotation() { }
        public string Author { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ContentUnderstanding.DocumentAnnotationComment> Comments { get { throw null; } }
        public System.DateTimeOffset? CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.ContentUnderstanding.DocumentAnnotationKind Kind { get { throw null; } }
        public System.DateTimeOffset? LastModifiedAt { get { throw null; } }
        public string Source { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ContentUnderstanding.ContentSpan> Spans { get { throw null; } }
        public System.Collections.Generic.IList<string> Tags { get { throw null; } }
        protected virtual Azure.AI.ContentUnderstanding.DocumentAnnotation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentUnderstanding.DocumentAnnotation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.DocumentAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.DocumentAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentAnnotationComment : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentAnnotationComment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentAnnotationComment>
    {
        internal DocumentAnnotationComment() { }
        public string Author { get { throw null; } }
        public System.DateTimeOffset? CreatedAt { get { throw null; } }
        public System.DateTimeOffset? LastModifiedAt { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IList<string> Tags { get { throw null; } }
        protected virtual Azure.AI.ContentUnderstanding.DocumentAnnotationComment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentUnderstanding.DocumentAnnotationComment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.DocumentAnnotationComment System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentAnnotationComment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentAnnotationComment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.DocumentAnnotationComment System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentAnnotationComment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentAnnotationComment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentAnnotationComment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentAnnotationKind : System.IEquatable<Azure.AI.ContentUnderstanding.DocumentAnnotationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentAnnotationKind(string value) { throw null; }
        public static Azure.AI.ContentUnderstanding.DocumentAnnotationKind Bold { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.DocumentAnnotationKind Circle { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.DocumentAnnotationKind Highlight { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.DocumentAnnotationKind Italic { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.DocumentAnnotationKind Note { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.DocumentAnnotationKind Strikethrough { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.DocumentAnnotationKind Underline { get { throw null; } }
        public bool Equals(Azure.AI.ContentUnderstanding.DocumentAnnotationKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.ContentUnderstanding.DocumentAnnotationKind left, Azure.AI.ContentUnderstanding.DocumentAnnotationKind right) { throw null; }
        public static implicit operator Azure.AI.ContentUnderstanding.DocumentAnnotationKind (string value) { throw null; }
        public static implicit operator Azure.AI.ContentUnderstanding.DocumentAnnotationKind? (string value) { throw null; }
        public static bool operator !=(Azure.AI.ContentUnderstanding.DocumentAnnotationKind left, Azure.AI.ContentUnderstanding.DocumentAnnotationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentBarcode : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentBarcode>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentBarcode>
    {
        internal DocumentBarcode() { }
        public float? Confidence { get { throw null; } }
        public Azure.AI.ContentUnderstanding.DocumentBarcodeKind Kind { get { throw null; } }
        public string Source { get { throw null; } }
        public Azure.AI.ContentUnderstanding.ContentSpan Span { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.AI.ContentUnderstanding.DocumentBarcode JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentUnderstanding.DocumentBarcode PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.DocumentBarcode System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentBarcode>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentBarcode>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.DocumentBarcode System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentBarcode>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentBarcode>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentBarcode>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentBarcodeKind : System.IEquatable<Azure.AI.ContentUnderstanding.DocumentBarcodeKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentBarcodeKind(string value) { throw null; }
        public static Azure.AI.ContentUnderstanding.DocumentBarcodeKind Aztec { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.DocumentBarcodeKind Codabar { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.DocumentBarcodeKind Code128 { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.DocumentBarcodeKind Code39 { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.DocumentBarcodeKind Code93 { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.DocumentBarcodeKind DataBar { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.DocumentBarcodeKind DataBarExpanded { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.DocumentBarcodeKind DataMatrix { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.DocumentBarcodeKind EAN13 { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.DocumentBarcodeKind EAN8 { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.DocumentBarcodeKind ITF { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.DocumentBarcodeKind MaxiCode { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.DocumentBarcodeKind MicroQRCode { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.DocumentBarcodeKind PDF417 { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.DocumentBarcodeKind QRCode { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.DocumentBarcodeKind UPCA { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.DocumentBarcodeKind UPCE { get { throw null; } }
        public bool Equals(Azure.AI.ContentUnderstanding.DocumentBarcodeKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.ContentUnderstanding.DocumentBarcodeKind left, Azure.AI.ContentUnderstanding.DocumentBarcodeKind right) { throw null; }
        public static implicit operator Azure.AI.ContentUnderstanding.DocumentBarcodeKind (string value) { throw null; }
        public static implicit operator Azure.AI.ContentUnderstanding.DocumentBarcodeKind? (string value) { throw null; }
        public static bool operator !=(Azure.AI.ContentUnderstanding.DocumentBarcodeKind left, Azure.AI.ContentUnderstanding.DocumentBarcodeKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentCaption : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentCaption>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentCaption>
    {
        internal DocumentCaption() { }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IList<string> Elements { get { throw null; } }
        public string Source { get { throw null; } }
        public Azure.AI.ContentUnderstanding.ContentSpan Span { get { throw null; } }
        protected virtual Azure.AI.ContentUnderstanding.DocumentCaption JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentUnderstanding.DocumentCaption PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.DocumentCaption System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentCaption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentCaption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.DocumentCaption System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentCaption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentCaption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentCaption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentChartFigure : Azure.AI.ContentUnderstanding.DocumentFigure, System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentChartFigure>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentChartFigure>
    {
        internal DocumentChartFigure() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Content { get { throw null; } }
        protected override Azure.AI.ContentUnderstanding.DocumentFigure JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.ContentUnderstanding.DocumentFigure PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.DocumentChartFigure System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentChartFigure>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentChartFigure>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.DocumentChartFigure System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentChartFigure>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentChartFigure>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentChartFigure>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentContent : Azure.AI.ContentUnderstanding.MediaContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentContent>
    {
        internal DocumentContent() { }
        public System.Collections.Generic.IList<Azure.AI.ContentUnderstanding.DocumentAnnotation> Annotations { get { throw null; } }
        public int EndPageNumber { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ContentUnderstanding.DocumentFigure> Figures { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ContentUnderstanding.DocumentHyperlink> Hyperlinks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ContentUnderstanding.DocumentPage> Pages { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ContentUnderstanding.DocumentParagraph> Paragraphs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ContentUnderstanding.DocumentSection> Sections { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ContentUnderstanding.DocumentContentSegment> Segments { get { throw null; } }
        public int StartPageNumber { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ContentUnderstanding.DocumentTable> Tables { get { throw null; } }
        public Azure.AI.ContentUnderstanding.LengthUnit? Unit { get { throw null; } }
        protected override Azure.AI.ContentUnderstanding.MediaContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.ContentUnderstanding.MediaContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.DocumentContent System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.DocumentContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentContentSegment : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentContentSegment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentContentSegment>
    {
        internal DocumentContentSegment() { }
        public string Category { get { throw null; } }
        public int EndPageNumber { get { throw null; } }
        public string SegmentId { get { throw null; } }
        public Azure.AI.ContentUnderstanding.ContentSpan Span { get { throw null; } }
        public int StartPageNumber { get { throw null; } }
        protected virtual Azure.AI.ContentUnderstanding.DocumentContentSegment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentUnderstanding.DocumentContentSegment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.DocumentContentSegment System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentContentSegment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentContentSegment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.DocumentContentSegment System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentContentSegment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentContentSegment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentContentSegment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DocumentFigure : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentFigure>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentFigure>
    {
        internal DocumentFigure() { }
        public Azure.AI.ContentUnderstanding.DocumentCaption Caption { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IList<string> Elements { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ContentUnderstanding.DocumentFootnote> Footnotes { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.ContentUnderstanding.SemanticRole? Role { get { throw null; } }
        public string Source { get { throw null; } }
        public Azure.AI.ContentUnderstanding.ContentSpan Span { get { throw null; } }
        protected virtual Azure.AI.ContentUnderstanding.DocumentFigure JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentUnderstanding.DocumentFigure PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.DocumentFigure System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentFigure>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentFigure>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.DocumentFigure System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentFigure>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentFigure>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentFigure>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentFootnote : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentFootnote>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentFootnote>
    {
        internal DocumentFootnote() { }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IList<string> Elements { get { throw null; } }
        public string Source { get { throw null; } }
        public Azure.AI.ContentUnderstanding.ContentSpan Span { get { throw null; } }
        protected virtual Azure.AI.ContentUnderstanding.DocumentFootnote JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentUnderstanding.DocumentFootnote PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.DocumentFootnote System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentFootnote>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentFootnote>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.DocumentFootnote System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentFootnote>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentFootnote>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentFootnote>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentFormula : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentFormula>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentFormula>
    {
        internal DocumentFormula() { }
        public float? Confidence { get { throw null; } }
        public Azure.AI.ContentUnderstanding.DocumentFormulaKind Kind { get { throw null; } }
        public string Source { get { throw null; } }
        public Azure.AI.ContentUnderstanding.ContentSpan Span { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.AI.ContentUnderstanding.DocumentFormula JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentUnderstanding.DocumentFormula PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.DocumentFormula System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentFormula>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentFormula>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.DocumentFormula System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentFormula>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentFormula>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentFormula>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentFormulaKind : System.IEquatable<Azure.AI.ContentUnderstanding.DocumentFormulaKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentFormulaKind(string value) { throw null; }
        public static Azure.AI.ContentUnderstanding.DocumentFormulaKind Display { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.DocumentFormulaKind Inline { get { throw null; } }
        public bool Equals(Azure.AI.ContentUnderstanding.DocumentFormulaKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.ContentUnderstanding.DocumentFormulaKind left, Azure.AI.ContentUnderstanding.DocumentFormulaKind right) { throw null; }
        public static implicit operator Azure.AI.ContentUnderstanding.DocumentFormulaKind (string value) { throw null; }
        public static implicit operator Azure.AI.ContentUnderstanding.DocumentFormulaKind? (string value) { throw null; }
        public static bool operator !=(Azure.AI.ContentUnderstanding.DocumentFormulaKind left, Azure.AI.ContentUnderstanding.DocumentFormulaKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentHyperlink : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentHyperlink>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentHyperlink>
    {
        internal DocumentHyperlink() { }
        public string Content { get { throw null; } }
        public string Source { get { throw null; } }
        public Azure.AI.ContentUnderstanding.ContentSpan Span { get { throw null; } }
        public string Url { get { throw null; } }
        protected virtual Azure.AI.ContentUnderstanding.DocumentHyperlink JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentUnderstanding.DocumentHyperlink PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.DocumentHyperlink System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentHyperlink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentHyperlink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.DocumentHyperlink System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentHyperlink>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentHyperlink>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentHyperlink>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentLine : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentLine>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentLine>
    {
        internal DocumentLine() { }
        public string Content { get { throw null; } }
        public string Source { get { throw null; } }
        public Azure.AI.ContentUnderstanding.ContentSpan Span { get { throw null; } }
        protected virtual Azure.AI.ContentUnderstanding.DocumentLine JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentUnderstanding.DocumentLine PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.DocumentLine System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentLine>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentLine>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.DocumentLine System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentLine>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentLine>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentLine>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentMermaidFigure : Azure.AI.ContentUnderstanding.DocumentFigure, System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentMermaidFigure>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentMermaidFigure>
    {
        internal DocumentMermaidFigure() { }
        public string Content { get { throw null; } }
        protected override Azure.AI.ContentUnderstanding.DocumentFigure JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.ContentUnderstanding.DocumentFigure PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.DocumentMermaidFigure System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentMermaidFigure>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentMermaidFigure>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.DocumentMermaidFigure System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentMermaidFigure>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentMermaidFigure>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentMermaidFigure>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentPage : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentPage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentPage>
    {
        internal DocumentPage() { }
        public float? Angle { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ContentUnderstanding.DocumentBarcode> Barcodes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ContentUnderstanding.DocumentFormula> Formulas { get { throw null; } }
        public float? Height { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ContentUnderstanding.DocumentLine> Lines { get { throw null; } }
        public int PageNumber { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ContentUnderstanding.ContentSpan> Spans { get { throw null; } }
        public float? Width { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ContentUnderstanding.DocumentWord> Words { get { throw null; } }
        protected virtual Azure.AI.ContentUnderstanding.DocumentPage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentUnderstanding.DocumentPage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.DocumentPage System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentPage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentPage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.DocumentPage System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentPage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentPage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentPage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentParagraph : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentParagraph>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentParagraph>
    {
        internal DocumentParagraph() { }
        public string Content { get { throw null; } }
        public Azure.AI.ContentUnderstanding.SemanticRole? Role { get { throw null; } }
        public string Source { get { throw null; } }
        public Azure.AI.ContentUnderstanding.ContentSpan Span { get { throw null; } }
        protected virtual Azure.AI.ContentUnderstanding.DocumentParagraph JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentUnderstanding.DocumentParagraph PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.DocumentParagraph System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentParagraph>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentParagraph>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.DocumentParagraph System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentParagraph>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentParagraph>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentParagraph>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentSection : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentSection>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentSection>
    {
        internal DocumentSection() { }
        public System.Collections.Generic.IList<string> Elements { get { throw null; } }
        public Azure.AI.ContentUnderstanding.ContentSpan Span { get { throw null; } }
        protected virtual Azure.AI.ContentUnderstanding.DocumentSection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentUnderstanding.DocumentSection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.DocumentSection System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentSection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentSection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.DocumentSection System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentSection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentSection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentSection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentTable : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentTable>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentTable>
    {
        internal DocumentTable() { }
        public Azure.AI.ContentUnderstanding.DocumentCaption Caption { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ContentUnderstanding.DocumentTableCell> Cells { get { throw null; } }
        public int ColumnCount { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ContentUnderstanding.DocumentFootnote> Footnotes { get { throw null; } }
        public Azure.AI.ContentUnderstanding.SemanticRole? Role { get { throw null; } }
        public int RowCount { get { throw null; } }
        public string Source { get { throw null; } }
        public Azure.AI.ContentUnderstanding.ContentSpan Span { get { throw null; } }
        protected virtual Azure.AI.ContentUnderstanding.DocumentTable JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentUnderstanding.DocumentTable PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.DocumentTable System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentTable>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentTable>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.DocumentTable System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentTable>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentTable>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentTable>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentTableCell : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentTableCell>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentTableCell>
    {
        internal DocumentTableCell() { }
        public int ColumnIndex { get { throw null; } }
        public int? ColumnSpan { get { throw null; } }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IList<string> Elements { get { throw null; } }
        public Azure.AI.ContentUnderstanding.DocumentTableCellKind? Kind { get { throw null; } }
        public int RowIndex { get { throw null; } }
        public int? RowSpan { get { throw null; } }
        public string Source { get { throw null; } }
        public Azure.AI.ContentUnderstanding.ContentSpan Span { get { throw null; } }
        protected virtual Azure.AI.ContentUnderstanding.DocumentTableCell JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentUnderstanding.DocumentTableCell PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.DocumentTableCell System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentTableCell>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentTableCell>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.DocumentTableCell System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentTableCell>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentTableCell>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentTableCell>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentTableCellKind : System.IEquatable<Azure.AI.ContentUnderstanding.DocumentTableCellKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentTableCellKind(string value) { throw null; }
        public static Azure.AI.ContentUnderstanding.DocumentTableCellKind ColumnHeader { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.DocumentTableCellKind Content { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.DocumentTableCellKind Description { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.DocumentTableCellKind RowHeader { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.DocumentTableCellKind StubHead { get { throw null; } }
        public bool Equals(Azure.AI.ContentUnderstanding.DocumentTableCellKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.ContentUnderstanding.DocumentTableCellKind left, Azure.AI.ContentUnderstanding.DocumentTableCellKind right) { throw null; }
        public static implicit operator Azure.AI.ContentUnderstanding.DocumentTableCellKind (string value) { throw null; }
        public static implicit operator Azure.AI.ContentUnderstanding.DocumentTableCellKind? (string value) { throw null; }
        public static bool operator !=(Azure.AI.ContentUnderstanding.DocumentTableCellKind left, Azure.AI.ContentUnderstanding.DocumentTableCellKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentWord : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentWord>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentWord>
    {
        internal DocumentWord() { }
        public float? Confidence { get { throw null; } }
        public string Content { get { throw null; } }
        public string Source { get { throw null; } }
        public Azure.AI.ContentUnderstanding.ContentSpan Span { get { throw null; } }
        protected virtual Azure.AI.ContentUnderstanding.DocumentWord JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentUnderstanding.DocumentWord PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.DocumentWord System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentWord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.DocumentWord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.DocumentWord System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentWord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentWord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.DocumentWord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GenerationMethod : System.IEquatable<Azure.AI.ContentUnderstanding.GenerationMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GenerationMethod(string value) { throw null; }
        public static Azure.AI.ContentUnderstanding.GenerationMethod Classify { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.GenerationMethod Extract { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.GenerationMethod Generate { get { throw null; } }
        public bool Equals(Azure.AI.ContentUnderstanding.GenerationMethod other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.ContentUnderstanding.GenerationMethod left, Azure.AI.ContentUnderstanding.GenerationMethod right) { throw null; }
        public static implicit operator Azure.AI.ContentUnderstanding.GenerationMethod (string value) { throw null; }
        public static implicit operator Azure.AI.ContentUnderstanding.GenerationMethod? (string value) { throw null; }
        public static bool operator !=(Azure.AI.ContentUnderstanding.GenerationMethod left, Azure.AI.ContentUnderstanding.GenerationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegerField : Azure.AI.ContentUnderstanding.ContentField, System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.IntegerField>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.IntegerField>
    {
        internal IntegerField() { }
        public long? ValueInteger { get { throw null; } }
        protected override Azure.AI.ContentUnderstanding.ContentField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.ContentUnderstanding.ContentField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.IntegerField System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.IntegerField>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.IntegerField>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.IntegerField System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.IntegerField>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.IntegerField>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.IntegerField>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class JsonField : Azure.AI.ContentUnderstanding.ContentField, System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.JsonField>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.JsonField>
    {
        internal JsonField() { }
        public System.BinaryData ValueJson { get { throw null; } }
        protected override Azure.AI.ContentUnderstanding.ContentField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.ContentUnderstanding.ContentField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.JsonField System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.JsonField>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.JsonField>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.JsonField System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.JsonField>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.JsonField>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.JsonField>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class KnowledgeSource : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.KnowledgeSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.KnowledgeSource>
    {
        internal KnowledgeSource() { }
        protected virtual Azure.AI.ContentUnderstanding.KnowledgeSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentUnderstanding.KnowledgeSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.KnowledgeSource System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.KnowledgeSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.KnowledgeSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.KnowledgeSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.KnowledgeSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.KnowledgeSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.KnowledgeSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LabeledDataKnowledgeSource : Azure.AI.ContentUnderstanding.KnowledgeSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.LabeledDataKnowledgeSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.LabeledDataKnowledgeSource>
    {
        public LabeledDataKnowledgeSource(System.Uri containerUrl) { }
        public LabeledDataKnowledgeSource(System.Uri containerUrl, string fileListPath) { }
        public System.Uri ContainerUrl { get { throw null; } set { } }
        public string FileListPath { get { throw null; } set { } }
        public string Prefix { get { throw null; } set { } }
        protected override Azure.AI.ContentUnderstanding.KnowledgeSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.ContentUnderstanding.KnowledgeSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.LabeledDataKnowledgeSource System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.LabeledDataKnowledgeSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.LabeledDataKnowledgeSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.LabeledDataKnowledgeSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.LabeledDataKnowledgeSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.LabeledDataKnowledgeSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.LabeledDataKnowledgeSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LengthUnit : System.IEquatable<Azure.AI.ContentUnderstanding.LengthUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LengthUnit(string value) { throw null; }
        public static Azure.AI.ContentUnderstanding.LengthUnit Inch { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.LengthUnit Pixel { get { throw null; } }
        public bool Equals(Azure.AI.ContentUnderstanding.LengthUnit other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.ContentUnderstanding.LengthUnit left, Azure.AI.ContentUnderstanding.LengthUnit right) { throw null; }
        public static implicit operator Azure.AI.ContentUnderstanding.LengthUnit (string value) { throw null; }
        public static implicit operator Azure.AI.ContentUnderstanding.LengthUnit? (string value) { throw null; }
        public static bool operator !=(Azure.AI.ContentUnderstanding.LengthUnit left, Azure.AI.ContentUnderstanding.LengthUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class MediaContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.MediaContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.MediaContent>
    {
        internal MediaContent() { }
        public string AnalyzerId { get { throw null; } }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.ContentUnderstanding.ContentField> Fields { get { throw null; } }
        public string Markdown { get { throw null; } }
        public string MimeType { get { throw null; } }
        public string Path { get { throw null; } }
        protected virtual Azure.AI.ContentUnderstanding.MediaContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentUnderstanding.MediaContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.MediaContent System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.MediaContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.MediaContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.MediaContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.MediaContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.MediaContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.MediaContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NumberField : Azure.AI.ContentUnderstanding.ContentField, System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.NumberField>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.NumberField>
    {
        internal NumberField() { }
        public double? ValueNumber { get { throw null; } }
        protected override Azure.AI.ContentUnderstanding.ContentField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.ContentUnderstanding.ContentField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.NumberField System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.NumberField>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.NumberField>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.NumberField System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.NumberField>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.NumberField>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.NumberField>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ObjectField : Azure.AI.ContentUnderstanding.ContentField, System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.ObjectField>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ObjectField>
    {
        internal ObjectField() { }
        public Azure.AI.ContentUnderstanding.ContentField this[string fieldName] { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.ContentUnderstanding.ContentField> ValueObject { get { throw null; } }
        protected override Azure.AI.ContentUnderstanding.ContentField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.ContentUnderstanding.ContentField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.ObjectField System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.ObjectField>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.ObjectField>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.ObjectField System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ObjectField>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ObjectField>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.ObjectField>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProcessingLocation : System.IEquatable<Azure.AI.ContentUnderstanding.ProcessingLocation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProcessingLocation(string value) { throw null; }
        public static Azure.AI.ContentUnderstanding.ProcessingLocation DataZone { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.ProcessingLocation Geography { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.ProcessingLocation Global { get { throw null; } }
        public bool Equals(Azure.AI.ContentUnderstanding.ProcessingLocation other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.ContentUnderstanding.ProcessingLocation left, Azure.AI.ContentUnderstanding.ProcessingLocation right) { throw null; }
        public static implicit operator Azure.AI.ContentUnderstanding.ProcessingLocation (string value) { throw null; }
        public static implicit operator Azure.AI.ContentUnderstanding.ProcessingLocation? (string value) { throw null; }
        public static bool operator !=(Azure.AI.ContentUnderstanding.ProcessingLocation left, Azure.AI.ContentUnderstanding.ProcessingLocation right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SemanticRole : System.IEquatable<Azure.AI.ContentUnderstanding.SemanticRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SemanticRole(string value) { throw null; }
        public static Azure.AI.ContentUnderstanding.SemanticRole Footnote { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.SemanticRole FormulaBlock { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.SemanticRole PageFooter { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.SemanticRole PageHeader { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.SemanticRole PageNumber { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.SemanticRole SectionHeading { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.SemanticRole Title { get { throw null; } }
        public bool Equals(Azure.AI.ContentUnderstanding.SemanticRole other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.ContentUnderstanding.SemanticRole left, Azure.AI.ContentUnderstanding.SemanticRole right) { throw null; }
        public static implicit operator Azure.AI.ContentUnderstanding.SemanticRole (string value) { throw null; }
        public static implicit operator Azure.AI.ContentUnderstanding.SemanticRole? (string value) { throw null; }
        public static bool operator !=(Azure.AI.ContentUnderstanding.SemanticRole left, Azure.AI.ContentUnderstanding.SemanticRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StringField : Azure.AI.ContentUnderstanding.ContentField, System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.StringField>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.StringField>
    {
        internal StringField() { }
        public string ValueString { get { throw null; } }
        protected override Azure.AI.ContentUnderstanding.ContentField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.ContentUnderstanding.ContentField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.StringField System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.StringField>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.StringField>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.StringField System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.StringField>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.StringField>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.StringField>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SupportedModels : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.SupportedModels>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.SupportedModels>
    {
        internal SupportedModels() { }
        public System.Collections.Generic.IList<string> Completion { get { throw null; } }
        public System.Collections.Generic.IList<string> Embedding { get { throw null; } }
        protected virtual Azure.AI.ContentUnderstanding.SupportedModels JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentUnderstanding.SupportedModels PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.SupportedModels System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.SupportedModels>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.SupportedModels>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.SupportedModels System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.SupportedModels>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.SupportedModels>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.SupportedModels>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TableFormat : System.IEquatable<Azure.AI.ContentUnderstanding.TableFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TableFormat(string value) { throw null; }
        public static Azure.AI.ContentUnderstanding.TableFormat Html { get { throw null; } }
        public static Azure.AI.ContentUnderstanding.TableFormat Markdown { get { throw null; } }
        public bool Equals(Azure.AI.ContentUnderstanding.TableFormat other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.ContentUnderstanding.TableFormat left, Azure.AI.ContentUnderstanding.TableFormat right) { throw null; }
        public static implicit operator Azure.AI.ContentUnderstanding.TableFormat (string value) { throw null; }
        public static implicit operator Azure.AI.ContentUnderstanding.TableFormat? (string value) { throw null; }
        public static bool operator !=(Azure.AI.ContentUnderstanding.TableFormat left, Azure.AI.ContentUnderstanding.TableFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TimeField : Azure.AI.ContentUnderstanding.ContentField, System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.TimeField>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.TimeField>
    {
        internal TimeField() { }
        public System.TimeSpan? ValueTime { get { throw null; } }
        protected override Azure.AI.ContentUnderstanding.ContentField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.ContentUnderstanding.ContentField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.TimeField System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.TimeField>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.TimeField>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.TimeField System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.TimeField>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.TimeField>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.TimeField>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TranscriptPhrase : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.TranscriptPhrase>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.TranscriptPhrase>
    {
        internal TranscriptPhrase() { }
        public float? Confidence { get { throw null; } }
        public long EndTimeMs { get { throw null; } }
        public string Locale { get { throw null; } }
        public Azure.AI.ContentUnderstanding.ContentSpan Span { get { throw null; } }
        public string Speaker { get { throw null; } }
        public long StartTimeMs { get { throw null; } }
        public string Text { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ContentUnderstanding.TranscriptWord> Words { get { throw null; } }
        protected virtual Azure.AI.ContentUnderstanding.TranscriptPhrase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentUnderstanding.TranscriptPhrase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.TranscriptPhrase System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.TranscriptPhrase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.TranscriptPhrase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.TranscriptPhrase System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.TranscriptPhrase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.TranscriptPhrase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.TranscriptPhrase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TranscriptWord : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.TranscriptWord>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.TranscriptWord>
    {
        internal TranscriptWord() { }
        public long EndTimeMs { get { throw null; } }
        public Azure.AI.ContentUnderstanding.ContentSpan Span { get { throw null; } }
        public long StartTimeMs { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual Azure.AI.ContentUnderstanding.TranscriptWord JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentUnderstanding.TranscriptWord PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentUnderstanding.TranscriptWord System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.TranscriptWord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentUnderstanding.TranscriptWord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentUnderstanding.TranscriptWord System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.TranscriptWord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.TranscriptWord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentUnderstanding.TranscriptWord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class ContentUnderstandingClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.ContentUnderstanding.ContentUnderstandingClient, Azure.AI.ContentUnderstanding.ContentUnderstandingClientOptions> AddContentUnderstandingClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.ContentUnderstanding.ContentUnderstandingClient, Azure.AI.ContentUnderstanding.ContentUnderstandingClientOptions> AddContentUnderstandingClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.ContentUnderstanding.ContentUnderstandingClient, Azure.AI.ContentUnderstanding.ContentUnderstandingClientOptions> AddContentUnderstandingClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
